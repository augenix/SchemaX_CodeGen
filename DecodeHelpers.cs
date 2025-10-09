using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace SchemaX_CodeGen;

public static class DecodeHelpers
{
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (int segmentIndex, int structIndex) GetStructCursor(Span<ulong> frame, SegmentMeta meta, int segmentIndex,
        int pointerIndex)
    {
        var pointer = segmentIndex > 0 ? frame[BaseOfSegment(meta, segmentIndex) + pointerIndex] : frame[pointerIndex];
        frame.DereferencePointer(meta, segmentIndex, pointerIndex, pointer, out int targetSegment, out var resolvedPointer,
            out var resolvedPointerIndex);
        int structIndex = UnpackPointerOffset(resolvedPointer) + resolvedPointerIndex + 1;
        return (targetSegment, structIndex);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static int GetListLength(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
    {
        int srcBase = BaseOfSegment(meta, segmentIndex);
        ulong pointer = frame[srcBase + pointerIndex];
        return (int)((pointer >> 2) & 0x3FFFFFFFUL);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (int segmentIndex, int elementIndex) GetListElementCursor(
        Span<ulong> frame,  
        SegmentMeta meta,
        int segmentIndex,
        int tagIndex,
        int index)
    {
        var tagWord = segmentIndex > 0 ? frame[BaseOfSegment(meta, segmentIndex) + tagIndex] : frame[tagIndex];
        int dataWords = (int)(tagWord >> 32 & 0xFFFFUL);
        int pointerWords = (int)(tagWord >> 48 & 0xFFFFUL);
        int stride = dataWords + pointerWords;
        int elementIndex = 1 + tagIndex + index * stride;
        return (segmentIndex, elementIndex);
    }
    
    
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static string ReadText(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
    {
        var pointer = segmentIndex > 0 ? frame[BaseOfSegment(meta, segmentIndex) + pointerIndex] : frame[pointerIndex];
        frame.DereferencePointer(meta, segmentIndex, pointerIndex, pointer, out int targetSegment, out var resolvedPointer,
            out var resolvedPointerIndex);
        if (resolvedPointer == 0) return string.Empty;
        var start = BaseOfSegment(meta, targetSegment);
        var length = meta.GetWordCount(targetSegment);
        var segT = frame.Slice(start, length);
        int offset = UnpackPointerOffset(resolvedPointer) + 1;
        int byteLength = (int)((resolvedPointer >> 35) & 0x1FFFFFFFUL);
        var structIndex = resolvedPointerIndex + offset;
        Span<byte> bytes = MemoryMarshal.AsBytes(segT.Slice(structIndex));
        ReadOnlySpan<byte> slice = bytes.Slice(0, byteLength - 1);
        return Encoding.UTF8.GetString(slice);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ReadOnlySpan<string> ReadList_Text(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
    {
        var pointer = segmentIndex > 0 ? frame[BaseOfSegment(meta, segmentIndex) + pointerIndex] : frame[pointerIndex];
        frame.DereferencePointer(meta, segmentIndex, pointerIndex, pointer, out int targetSegment, out var resolvedPointer,
            out var resolvedPointerIndex);
        var start = BaseOfSegment(meta, targetSegment);
        var length = meta.GetWordCount(targetSegment);
        var segT = frame.Slice(start, length);
        
        if (resolvedPointer == 0) return ReadOnlySpan<string>.Empty;
        
        if ((resolvedPointer & 0b11UL) != 1) throw new InvalidOperationException("Pointer is not a list pointer.");
        int offset = UnpackPointerOffset(resolvedPointer);
        int elementSize = (int)((resolvedPointer >> 32) & 0b111UL);
        int numItems = (int)((resolvedPointer >> 35) & 0x1FFFFFFFUL);
        if (elementSize != 6) throw new InvalidOperationException("Expected pointer list (element size = 6)");

        string[] results = new string[numItems];


        var listPointerIndex = resolvedPointerIndex + offset + 1;

        for (int i = 0; i < numItems; i++)
        {
            ulong strPtr = segT[listPointerIndex + i];

            if (strPtr == 0)
            {
                results[i] = string.Empty;
                continue;
            }

            if ((strPtr & 0b11UL) != 1)
                throw new InvalidOperationException("Expected list pointer for string element.");

            int strOffset = (int)((strPtr >> 2) & 0x3FFFFFFF);
            int payloadWordIndex = 1 + (listPointerIndex + i) + strOffset;

            int strElementSize = (int)((strPtr >> 32) & 0b111UL);
            if (strElementSize != 2)
                throw new InvalidOperationException("Expected byte list for text.");
            int byteCountWithNull = (int)((strPtr >> 35) & 0x1FFFFFFFUL);
            if (byteCountWithNull <= 1)
            {
                results[i] = string.Empty;
                continue;
            }

            int byteCount = byteCountWithNull - 1;
            int wordCount = (byteCount + 7) / 8;

            Span<byte> byteSpan = MemoryMarshal.AsBytes(segT.Slice(payloadWordIndex, wordCount));
            results[i] = Encoding.UTF8.GetString(byteSpan.Slice(0, byteCount));
        }

        return new ReadOnlySpan<string>(results);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ReadOnlySpan<T> ReadList_Primitive<T>(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        where T : unmanaged
    {
        var pointer = segmentIndex > 0 ? frame[BaseOfSegment(meta, segmentIndex) + pointerIndex] : frame[pointerIndex];
        frame.DereferencePointer(meta, segmentIndex, pointerIndex, pointer, out int targetSegment, out var resolvedPointer,
            out var resolvedPointerIndex);
        var start = BaseOfSegment(meta, targetSegment);
        var length = meta.GetWordCount(targetSegment);
        var segT = frame.Slice(start, length);

        if (resolvedPointer == 0)
            return ReadOnlySpan<T>.Empty;
        if ((resolvedPointer & 0b11UL) != 1)
            throw new InvalidOperationException("Pointer is not a list pointer.");

        int listStartIndex = UnpackPointerOffset(resolvedPointer) + resolvedPointerIndex + 1;
        int sizeCode = (int)((resolvedPointer >> 32) & 0b111UL);
        int numItems = (int)((resolvedPointer >> 35) & 0x1FFFFFFFUL);
        int elementSize = SizeInBytes(sizeCode);
        int totalBytes = elementSize * numItems;
        int totalWords = (totalBytes + 7) / 8;
        Span<ulong> wordSpan = segT.Slice(listStartIndex, totalWords);
        Span<byte> byteSpan = MemoryMarshal.AsBytes(wordSpan);
        Span<T> result = MemoryMarshal.Cast<byte, T>(byteSpan).Slice(0, numItems);
        return result;
    }

    
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private static int SizeInBytes(int sizeCode) => sizeCode switch
    {
        0 => 0, // Void
        1 => 0, // Bit (not byte addressable, must be handled separately)
        2 => 1, // Byte
        3 => 2, // Short
        4 => 4, // Int / float
        5 => 8, // Long / double (non-pointer)
        6 => 8, // Pointer
        7 => throw new InvalidOperationException("Inline composite must be handled separately."),
        _ => throw new ArgumentOutOfRangeException(nameof(sizeCode), $"Invalid size code {sizeCode}")
    };

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private static byte GetElementSizeCode(int sizeInBytes)
    {
        return sizeInBytes switch
        {
            0 => 0, // void
            1 => 2, // byte
            2 => 3, // short
            4 => 4, // int or float
            8 => 5, // long or double
            _ => throw new NotSupportedException($"Unsupported primitive element size: {sizeInBytes}")
        };
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private static void DereferencePointer(
        this Span<ulong> frame,
        SegmentMeta meta,
        int segmentIndex,
        int pointerIndex,
        ulong pointer,
        out int targetSegmentIndex,
        out ulong resolvedPointer,
        out int resolvedPointerIndex)
    {
        if ((pointer & 0b11UL) != 0b10UL) // near pointer
        {
            targetSegmentIndex = segmentIndex;
            resolvedPointer = pointer;
            resolvedPointerIndex = pointerIndex;
            return;
        }
        int landingPadIndex = (int)((pointer >> 3) & 0x1FFFFFFF);
        int landingPadSeg   = (int)(pointer >> 32);
        int baseOfLandingPadSeg = BaseOfSegment(meta, landingPadSeg);
        targetSegmentIndex   = landingPadSeg;
        resolvedPointerIndex = landingPadIndex;
        resolvedPointer      = frame[baseOfLandingPadSeg + landingPadIndex];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static int UnpackPointerOffset(ulong pointer)
    {
        return (int)(((long)(pointer << 32)) >> 34);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static int BaseOfSegment(SegmentMeta meta, int segIndex)
    {
        int baseIndex = 0;
        for (int i = 0; i < segIndex; i++)
            baseIndex += meta.GetWordCount(i);
        return baseIndex;
    }
    
}
