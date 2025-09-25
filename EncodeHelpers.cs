using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace SchemaX_CodeGen;

public static class EncodeHelpers
{
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (int segmentIndex, int structIndex) AllocateStruct(
        SegmentArena arena,
        int segmentIndex,
        int pointerIndex,
        int targetDataWords,
        int targetPointerWords)
    {
        var targetSegment = arena.SegmentCount - 1;
        var segT = arena.GetSegment(targetSegment);
        var totalWords = targetDataWords + targetPointerWords;
        int structIndex = arena.GetWordCount(targetSegment);
        int offset;

        if (targetSegment == segmentIndex)
        {
            offset = structIndex - pointerIndex - 1;
            segT[pointerIndex] = BuildStructPointer(offset, targetDataWords, targetPointerWords);
            arena.IncrementWordCount(targetSegment, totalWords);
            if (arena.GetWordCount(targetSegment) >= arena.TargetSegmentSize) arena.AllocateSegment(1);
            return (targetSegment, structIndex);
        }
        
        int landingPadIndex = structIndex + totalWords;
        arena.GetSegment(segmentIndex)[pointerIndex] = BuildFarPointer(landingPadIndex, targetSegment);
        offset = structIndex - landingPadIndex - 1;
        segT[landingPadIndex] = BuildStructPointer(offset, targetDataWords, targetPointerWords);
        arena.IncrementWordCount(targetSegment, totalWords + 1);
        if (arena.GetWordCount(targetSegment) >= arena.TargetSegmentSize) arena.AllocateSegment(targetSegment + 1);
        return (targetSegment, structIndex);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (int segmentIndex, int structIndex) GetStructCursor(SegmentArena arena, int segmentIndex,
        int pointerIndex)
    {
        ulong pointer = arena.GetSegment(segmentIndex)[pointerIndex];
        arena.DereferencePointer(segmentIndex, pointerIndex, pointer, out int targetSegmentIndex,
            out ulong resolvedPointer, out int resolvedPointerIndex);
        int offset = UnpackPointerOffset(resolvedPointer);
        int structIndex = resolvedPointerIndex + offset + 1;
        return (targetSegmentIndex, structIndex);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (int segmentIndex, int tagIndex) AllocateList_Struct(
        SegmentArena arena,
        int segmentIndex,
        int pointerIndex,
        int count,
        int targetDataWords,
        int targetPointerWords)
    {
        var targetSegment = arena.SegmentCount - 1;
        var segR = arena.GetSegment(segmentIndex);
        var wordCount = count * (targetDataWords + targetPointerWords);
        int tagIndex = arena.GetWordCount(targetSegment);
        int offset;

        if (targetSegment == segmentIndex)
        {
            offset = tagIndex - pointerIndex - 1;
            segR[pointerIndex] = BuildListPointer(offset, 7, wordCount);
            segR[tagIndex] = BuildStructPointer(count, targetDataWords, targetPointerWords);
            arena.IncrementWordCount(targetSegment, wordCount + 1);
            if (arena.GetWordCount(targetSegment) >= arena.TargetSegmentSize) arena.AllocateSegment(targetSegment + 1);
            return (targetSegment, tagIndex);
        }

        var segT = arena.GetSegment(targetSegment);
        segT[tagIndex] = BuildStructPointer(count, targetDataWords, targetPointerWords);
        var landingPadIndex = tagIndex + wordCount + 1;
        segR[pointerIndex] = BuildFarPointer(landingPadIndex, targetSegment);
        offset = tagIndex - landingPadIndex - 1;
        segT[landingPadIndex] = BuildListPointer(offset, 7, wordCount);
        arena.IncrementWordCount(targetSegment, wordCount + 2);
        if (arena.GetWordCount(targetSegment) >= arena.TargetSegmentSize) arena.AllocateSegment(targetSegment + 1);
        return (targetSegment, tagIndex);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (int segmentIndex, int elementIndex) GetListElementCursor(
        SegmentArena arena,
        int segmentIndex,
        int tagIndex,
        int index)
    {
        var tagWord = arena.GetSegment(segmentIndex)[tagIndex];
        int dataWords = (int)(tagWord >> 32 & 0xFFFFUL);
        int pointerWords = (int)(tagWord >> 48 & 0xFFFFUL);
        int stride = dataWords + pointerWords;
        int elementIndex = 1 + tagIndex + index * stride;
        return (segmentIndex, elementIndex);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void WriteText(SegmentArena arena, int segmentIndex, int pointerIndex, string value)
    {
        var segR = arena.GetSegment(segmentIndex);
        var targetSegment = arena.SegmentCount - 1;
        int byteCount = Encoding.UTF8.GetByteCount(value) + 1;
        int wordCount = (byteCount + 7) / 8;
        int payloadIndex = arena.GetWordCount(targetSegment);
        Span<byte> payload;

        if (targetSegment == segmentIndex)
        {
            payload = MemoryMarshal.AsBytes(segR.Slice(payloadIndex, wordCount));
            WriteUtf8StringWithNull(value, payload);
            int offset = payloadIndex - pointerIndex - 1;
            segR[pointerIndex] = BuildListPointer(offset, 2, byteCount);
            arena.IncrementWordCount(segmentIndex, wordCount);
            if (arena.GetWordCount(segmentIndex) >= arena.TargetSegmentSize) arena.AllocateSegment(segmentIndex + 1);
            return;
        }

        Span<ulong> segT = arena.GetSegment(targetSegment);
        payload = MemoryMarshal.AsBytes(segT.Slice(payloadIndex, wordCount));
        WriteUtf8StringWithNull(value, payload);
        int landingPadIndex = payloadIndex + wordCount;
        int tagOffset = payloadIndex - landingPadIndex - 1;
        segT[landingPadIndex] = BuildListPointer(tagOffset, 2, byteCount);
        segR[pointerIndex] = BuildFarPointer(landingPadIndex, targetSegment);
        arena.IncrementWordCount(targetSegment, wordCount + 1);
        if (arena.GetWordCount(targetSegment) >= arena.TargetSegmentSize) arena.AllocateSegment(targetSegment + 1);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static string ReadText(SegmentArena arena, int segmentIndex, int pointerIndex)
    {
        var pointer = arena.GetSegment(segmentIndex)[pointerIndex];
        arena.DereferencePointer(segmentIndex, pointerIndex, pointer, out int targetSegment, out ulong resolvedPointer,
            out int resolvedPointerIndex);

        if (resolvedPointer == 0) return string.Empty;

        int offset = UnpackPointerOffset(resolvedPointer);
        int byteLength = (int)((resolvedPointer >> 35) & 0x1FFFFFFFUL);
        var structIndex = resolvedPointerIndex + offset + 1;
        Span<ulong> segT = arena.GetSegment(targetSegment);
        Span<byte> bytes = MemoryMarshal.AsBytes(segT.Slice(structIndex));
        ReadOnlySpan<byte> slice = bytes.Slice(0, byteLength - 1);
        return Encoding.UTF8.GetString(slice);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void WriteList_Text(SegmentArena arena, int segmentIndex, int pointerIndex,
        ReadOnlySpan<string> items)
    {
        int numItems = items.Length;
        int listOffset;

        if (numItems == 0)
        {
            arena.GetSegment(segmentIndex)[pointerIndex] = 0;
            return;
        }

        Span<int> byteCounts = stackalloc int[numItems];
        for (var i = 0; i < numItems; i++)
        {
            byteCounts[i] = Encoding.UTF8.GetByteCount(items[i]) + 1; // +1 for null terminator
        }

        var targetSegment = arena.SegmentCount - 1;
        var segT = arena.GetSegment(targetSegment);
        var listStartIndex = arena.GetWordCount(targetSegment);
        arena.IncrementWordCount(targetSegment, numItems);
        for (int i = 0; i < items.Length; i++)
        {
            string str = items[i];
            var payloadIndex = arena.GetWordCount(targetSegment);
            var listPointerIndex = listStartIndex + i;
            var pointerOffset = payloadIndex - listPointerIndex - 1;
            int byteCount = byteCounts[i];
            var payloadLength = (byteCount + 7) / 8;
            segT[listPointerIndex] = BuildListPointer(pointerOffset, 2, byteCount);
            Span<byte> target = MemoryMarshal.AsBytes(segT.Slice(payloadIndex, payloadLength));
            Encoding.UTF8.GetBytes(str, target);
            target[byteCount - 1] = 0;
            arena.IncrementWordCount(targetSegment, payloadLength);
        }

        if (targetSegment == segmentIndex)
        {
            listOffset = listStartIndex - pointerIndex - 1;
            arena.GetSegment(segmentIndex)[pointerIndex] = BuildListPointer(listOffset, 6, items.Length);
            if (arena.GetWordCount(targetSegment) >= arena.TargetSegmentSize) arena.AllocateSegment(targetSegment + 1);
            return;
        }

        var landingPadIndex = arena.GetWordCount(targetSegment);
        listOffset = listStartIndex - landingPadIndex - 1;
        segT[landingPadIndex] = BuildListPointer(listOffset, 6, items.Length);
        arena.GetSegment(segmentIndex)[pointerIndex] = BuildFarPointer(landingPadIndex, targetSegment);
        arena.IncrementWordCount(targetSegment, 1);
        if (arena.GetWordCount(targetSegment) >= arena.TargetSegmentSize) arena.AllocateSegment(targetSegment + 1);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ReadOnlySpan<string> ReadList_Text(SegmentArena arena, int segmentIndex, int pointerIndex)
    {
        var pointer = arena.GetSegment(segmentIndex)[pointerIndex];
        arena.DereferencePointer(segmentIndex, pointerIndex, pointer, out int targetSegment, out ulong resolvedPointer,
            out int resolvedPointerIndex);
        if (resolvedPointer == 0) return ReadOnlySpan<string>.Empty;
        if ((resolvedPointer & 0b11UL) != 1) throw new InvalidOperationException("Pointer is not a list pointer.");
        int offset = UnpackPointerOffset(resolvedPointer);
        int elementSize = (int)((resolvedPointer >> 32) & 0b111UL);
        int numItems = (int)((resolvedPointer >> 35) & 0x1FFFFFFFUL);
        if (elementSize != 6) throw new InvalidOperationException("Expected pointer list (element size = 6)");

        string[] results = new string[numItems];
        var seg = arena.GetSegment(targetSegment);

        var listPointerIndex = resolvedPointerIndex + offset + 1;

        for (int i = 0; i < numItems; i++)
        {
            ulong strPtr = seg[listPointerIndex + i];

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

            Span<byte> byteSpan = MemoryMarshal.AsBytes(seg.Slice(payloadWordIndex, wordCount));
            results[i] = Encoding.UTF8.GetString(byteSpan.Slice(0, byteCount));
        }

        return new ReadOnlySpan<string>(results);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static unsafe void WriteList_Primitive<T>(
        SegmentArena arena,
        int segmentIndex,
        int pointerIndex,
        ReadOnlySpan<T> items)
        where T : unmanaged
    {
        int count = items.Length;
        int elementSizeBytes = Unsafe.SizeOf<T>();
        int totalBytes = count * elementSizeBytes;
        int totalWords = (totalBytes + 7) / 8;
        byte sizeCode = GetElementSizeCode(elementSizeBytes);
        int targetSegment = arena.SegmentCount - 1;
        var segT = arena.GetSegment(targetSegment);
        var listPointerIndex = arena.GetWordCount(targetSegment);
        int offset;
        Span<byte> dstBytes = MemoryMarshal.Cast<ulong, byte>(segT.Slice(listPointerIndex, totalWords));
        ReadOnlySpan<byte> srcBytes = MemoryMarshal.AsBytes(items);
        srcBytes.CopyTo(dstBytes);

        if (targetSegment == segmentIndex)
        {
            offset = listPointerIndex - pointerIndex - 1;
            segT[pointerIndex] = BuildListPointer(offset, sizeCode, count);
            arena.IncrementWordCount(targetSegment, totalWords);
            if (arena.GetWordCount(targetSegment) >= arena.TargetSegmentSize) arena.AllocateSegment(targetSegment + 1);
            return;
        }

        var landingPadIndex = listPointerIndex + totalWords;
        arena.GetSegment(segmentIndex)[pointerIndex] = BuildFarPointer(landingPadIndex, targetSegment);
        offset = listPointerIndex - landingPadIndex - 1;
        segT[landingPadIndex] = BuildListPointer(offset, sizeCode, count);
        arena.IncrementWordCount(targetSegment, totalWords + 1);
        if (arena.GetWordCount(targetSegment) >= arena.TargetSegmentSize) arena.AllocateSegment(targetSegment + 1);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ReadOnlySpan<T> ReadList_Primitive<T>(SegmentArena arena, int segmentIndex, int pointerIndex)
        where T : unmanaged
    {
        ulong pointer = arena.GetSegment(segmentIndex)[pointerIndex];
        arena.DereferencePointer(segmentIndex, pointerIndex, pointer, out int targetSegment, out ulong resolvedPointer,
            out int resolvedPointerIndex);

        if (resolvedPointer == 0)
            return ReadOnlySpan<T>.Empty;
        if ((resolvedPointer & 0b11UL) != 1)
            throw new InvalidOperationException("Pointer is not a list pointer.");

        int offset = UnpackPointerOffset(resolvedPointer);
        int sizeCode = (int)((resolvedPointer >> 32) & 0b111UL);
        int numItems = (int)((resolvedPointer >> 35) & 0x1FFFFFFFUL);
        int elementSize = SizeInBytes(sizeCode);
        var segT = arena.GetSegment(targetSegment);
        int listStartIndex = resolvedPointerIndex + offset + 1;
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
        this SegmentArena arena,
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
        targetSegmentIndex = (int)(pointer >> 32);
        Span<ulong> target = arena.GetSegment(targetSegmentIndex);
        resolvedPointerIndex = landingPadIndex;
        resolvedPointer = target[landingPadIndex];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static int UnpackPointerOffset(ulong pointer)
    {
        return (int)(((long)(pointer << 32)) >> 34);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int WriteUtf8StringWithNull(string value, Span<byte> destination)
    {
        int byteCount = Encoding.UTF8.GetBytes(value, destination);
        destination[byteCount] = 0;
        return byteCount + 1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong BuildStructPointer(int offsetWords, int dataWords, int pointerWords)
    {
        return 0UL
               | ((ulong)offsetWords & 0x3FFFFFFFUL) << 2
               | ((ulong)dataWords & 0xFFFFUL) << 32
               | ((ulong)pointerWords & 0xFFFFUL) << 48;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ulong BuildListPointer(int offsetWords, int sizeCode, int byteCount)
    {
        return 1UL // kind = list
               | ((ulong)offsetWords & 0x3FFFFFFFUL) << 2
               | ((ulong)sizeCode << 32) // element size = byte
               | ((ulong)byteCount & 0x1FFFFFFFUL) << 35;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ulong BuildFarPointer(int landingPadWordIndex, int targetSegment)
    {
        return 2UL
               | ((ulong)landingPadWordIndex << 3)
               | ((ulong)targetSegment << 32);
    }
}
