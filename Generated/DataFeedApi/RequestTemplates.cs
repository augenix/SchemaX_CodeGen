using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace SchemaX_CodeGen.Generated.DataFeedApi;

public sealed class CmeFeedClientFirehoseTemplate
{
    private readonly SegmentArena arena;

    private const ulong Root = 0x0001000100000000UL;
    private const int UnionTag = 0;
    private const int DataWords = 1;
    private const int PointerWords = 0;
    private const int BaseSegment = 0;
    private const int BaseIndex = 1;

    public CmeFeedClientFirehoseTemplate()
    {
        arena = new SegmentArena();
        arena.IncrementWordCount(0, 1);
        EncodeHelpers.AllocateStruct(arena, BaseSegment, 0, DataWords, PointerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public CmeFeedClientFirehoseEncoder Populate()
    {
        return new CmeFeedClientFirehoseEncoder(arena, BaseSegment, BaseIndex);
    }

    public ArenaMeta Meta => arena.Meta;

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public Span<ulong> GetWireFrame()
    {
        var buf = arena.Buffer;
        var segCount = arena.SegmentCount;
        var headerWords = 3 + (segCount - 1 + 1) / 2;
        var start = arena.ReservedWords - headerWords;
        arena.IncrementWordCount(0, 2);
        buf[start] = ((ulong)(arena.GetWordCount(0)) << 32) | (uint)(segCount - 1);

        var w = start + 1;
        for (int i = 1; i < segCount; i += 2)
            buf[w++] = (ulong)arena.GetWordCount(i + 1) << 32 | (uint) arena.GetWordCount(i);
        buf[w++] = Root;
        buf[w] = UnionTag;
        return buf.AsSpan(start, arena.GetWordCount(0) + headerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Send(Socket socket)
    {
        var buf = arena.Buffer;
        var segCount = arena.SegmentCount;
        var headerWords = 3 + (segCount - 1 + 1) / 2;
        var start = arena.ReservedWords - headerWords;
        arena.IncrementWordCount(0, 2);
        buf[start] = ((ulong)(arena.GetWordCount(0)) << 32) | (uint)(segCount - 1);

        var w = start + 1;
        for (int i = 1; i < segCount; i += 2)
            buf[w++] = (ulong)arena.GetWordCount(i + 1) << 32 | (uint) arena.GetWordCount(i);
        buf[w++] = Root;
        buf[w] = UnionTag;

        int seg0Words = arena.GetWordCount(0);
        int totalSeg0Words = 1 + seg0Words;
        ReadOnlySpan<byte> seg0Bytes = MemoryMarshal.AsBytes(arena.GetArenaAsSpan.Slice(start, totalSeg0Words));
        int sent = 0;
        while (sent < seg0Bytes.Length)
            sent += socket.Send(seg0Bytes.Slice(sent));
        for (int i = 1; i < segCount; i++)
        {
            int sent2 = 0;
            int words = arena.GetWordCount(i);
            if (words == 0) continue;
            ReadOnlySpan<byte> segBytes = MemoryMarshal.AsBytes(arena.GetSegment(i).Slice(0, words));
            while (sent2 < segBytes.Length)
                sent2 += socket.Send(segBytes.Slice(sent2));
        }
    }
}

public sealed class CmeFeedClientSubscribeTemplate
{
    private readonly SegmentArena arena;

    private const ulong Root = 0x0001000100000000UL;
    private const int UnionTag = 0;
    private const int DataWords = 1;
    private const int PointerWords = 2;
    private const int BaseSegment = 0;
    private const int BaseIndex = 1;

    public CmeFeedClientSubscribeTemplate()
    {
        arena = new SegmentArena();
        arena.IncrementWordCount(0, 1);
        EncodeHelpers.AllocateStruct(arena, BaseSegment, 0, DataWords, PointerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public CmeFeedClientSubscribeEncoder Populate()
    {
        return new CmeFeedClientSubscribeEncoder(arena, BaseSegment, BaseIndex);
    }

    public ArenaMeta Meta => arena.Meta;

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public Span<ulong> GetWireFrame()
    {
        var buf = arena.Buffer;
        var segCount = arena.SegmentCount;
        var headerWords = 3 + (segCount - 1 + 1) / 2;
        var start = arena.ReservedWords - headerWords;
        arena.IncrementWordCount(0, 2);
        buf[start] = ((ulong)(arena.GetWordCount(0)) << 32) | (uint)(segCount - 1);

        var w = start + 1;
        for (int i = 1; i < segCount; i += 2)
            buf[w++] = (ulong)arena.GetWordCount(i + 1) << 32 | (uint) arena.GetWordCount(i);
        buf[w++] = Root;
        buf[w] = UnionTag;
        return buf.AsSpan(start, arena.GetWordCount(0) + headerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Send(Socket socket)
    {
        var buf = arena.Buffer;
        var segCount = arena.SegmentCount;
        var headerWords = 3 + (segCount - 1 + 1) / 2;
        var start = arena.ReservedWords - headerWords;
        arena.IncrementWordCount(0, 2);
        buf[start] = ((ulong)(arena.GetWordCount(0)) << 32) | (uint)(segCount - 1);

        var w = start + 1;
        for (int i = 1; i < segCount; i += 2)
            buf[w++] = (ulong)arena.GetWordCount(i + 1) << 32 | (uint) arena.GetWordCount(i);
        buf[w++] = Root;
        buf[w] = UnionTag;

        int seg0Words = arena.GetWordCount(0);
        int totalSeg0Words = 1 + seg0Words;
        ReadOnlySpan<byte> seg0Bytes = MemoryMarshal.AsBytes(arena.GetArenaAsSpan.Slice(start, totalSeg0Words));
        int sent = 0;
        while (sent < seg0Bytes.Length)
            sent += socket.Send(seg0Bytes.Slice(sent));
        for (int i = 1; i < segCount; i++)
        {
            int sent2 = 0;
            int words = arena.GetWordCount(i);
            if (words == 0) continue;
            ReadOnlySpan<byte> segBytes = MemoryMarshal.AsBytes(arena.GetSegment(i).Slice(0, words));
            while (sent2 < segBytes.Length)
                sent2 += socket.Send(segBytes.Slice(sent2));
        }
    }
}

public sealed class CmeFuturesDefinitionRequestTemplate
{
    private readonly SegmentArena arena;

    private const ulong Root = 0x0001000100000000UL;
    private const int UnionTag = 0;
    private const int DataWords = 1;
    private const int PointerWords = 1;
    private const int BaseSegment = 0;
    private const int BaseIndex = 1;

    public CmeFuturesDefinitionRequestTemplate()
    {
        arena = new SegmentArena();
        arena.IncrementWordCount(0, 1);
        EncodeHelpers.AllocateStruct(arena, BaseSegment, 0, DataWords, PointerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public CmeFuturesDefinitionRequestEncoder Populate()
    {
        return new CmeFuturesDefinitionRequestEncoder(arena, BaseSegment, BaseIndex);
    }

    public ArenaMeta Meta => arena.Meta;

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public Span<ulong> GetWireFrame()
    {
        var buf = arena.Buffer;
        var segCount = arena.SegmentCount;
        var headerWords = 3 + (segCount - 1 + 1) / 2;
        var start = arena.ReservedWords - headerWords;
        arena.IncrementWordCount(0, 2);
        buf[start] = ((ulong)(arena.GetWordCount(0)) << 32) | (uint)(segCount - 1);

        var w = start + 1;
        for (int i = 1; i < segCount; i += 2)
            buf[w++] = (ulong)arena.GetWordCount(i + 1) << 32 | (uint) arena.GetWordCount(i);
        buf[w++] = Root;
        buf[w] = UnionTag;
        return buf.AsSpan(start, arena.GetWordCount(0) + headerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Send(Socket socket)
    {
        var buf = arena.Buffer;
        var segCount = arena.SegmentCount;
        var headerWords = 3 + (segCount - 1 + 1) / 2;
        var start = arena.ReservedWords - headerWords;
        arena.IncrementWordCount(0, 2);
        buf[start] = ((ulong)(arena.GetWordCount(0)) << 32) | (uint)(segCount - 1);

        var w = start + 1;
        for (int i = 1; i < segCount; i += 2)
            buf[w++] = (ulong)arena.GetWordCount(i + 1) << 32 | (uint) arena.GetWordCount(i);
        buf[w++] = Root;
        buf[w] = UnionTag;

        int seg0Words = arena.GetWordCount(0);
        int totalSeg0Words = 1 + seg0Words;
        ReadOnlySpan<byte> seg0Bytes = MemoryMarshal.AsBytes(arena.GetArenaAsSpan.Slice(start, totalSeg0Words));
        int sent = 0;
        while (sent < seg0Bytes.Length)
            sent += socket.Send(seg0Bytes.Slice(sent));
        for (int i = 1; i < segCount; i++)
        {
            int sent2 = 0;
            int words = arena.GetWordCount(i);
            if (words == 0) continue;
            ReadOnlySpan<byte> segBytes = MemoryMarshal.AsBytes(arena.GetSegment(i).Slice(0, words));
            while (sent2 < segBytes.Length)
                sent2 += socket.Send(segBytes.Slice(sent2));
        }
    }
}

public sealed class CmeFeedRequestSymbolAvailabilityTemplate
{
    private readonly SegmentArena arena;

    private const ulong Root = 0x0001000100000000UL;
    private const int UnionTag = 0;
    private const int DataWords = 1;
    private const int PointerWords = 1;
    private const int BaseSegment = 0;
    private const int BaseIndex = 1;

    public CmeFeedRequestSymbolAvailabilityTemplate()
    {
        arena = new SegmentArena();
        arena.IncrementWordCount(0, 1);
        EncodeHelpers.AllocateStruct(arena, BaseSegment, 0, DataWords, PointerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public CmeFeedRequestSymbolAvailabilityEncoder Populate()
    {
        return new CmeFeedRequestSymbolAvailabilityEncoder(arena, BaseSegment, BaseIndex);
    }

    public ArenaMeta Meta => arena.Meta;

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public Span<ulong> GetWireFrame()
    {
        var buf = arena.Buffer;
        var segCount = arena.SegmentCount;
        var headerWords = 3 + (segCount - 1 + 1) / 2;
        var start = arena.ReservedWords - headerWords;
        arena.IncrementWordCount(0, 2);
        buf[start] = ((ulong)(arena.GetWordCount(0)) << 32) | (uint)(segCount - 1);

        var w = start + 1;
        for (int i = 1; i < segCount; i += 2)
            buf[w++] = (ulong)arena.GetWordCount(i + 1) << 32 | (uint) arena.GetWordCount(i);
        buf[w++] = Root;
        buf[w] = UnionTag;
        return buf.AsSpan(start, arena.GetWordCount(0) + headerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Send(Socket socket)
    {
        var buf = arena.Buffer;
        var segCount = arena.SegmentCount;
        var headerWords = 3 + (segCount - 1 + 1) / 2;
        var start = arena.ReservedWords - headerWords;
        arena.IncrementWordCount(0, 2);
        buf[start] = ((ulong)(arena.GetWordCount(0)) << 32) | (uint)(segCount - 1);

        var w = start + 1;
        for (int i = 1; i < segCount; i += 2)
            buf[w++] = (ulong)arena.GetWordCount(i + 1) << 32 | (uint) arena.GetWordCount(i);
        buf[w++] = Root;
        buf[w] = UnionTag;

        int seg0Words = arena.GetWordCount(0);
        int totalSeg0Words = 1 + seg0Words;
        ReadOnlySpan<byte> seg0Bytes = MemoryMarshal.AsBytes(arena.GetArenaAsSpan.Slice(start, totalSeg0Words));
        int sent = 0;
        while (sent < seg0Bytes.Length)
            sent += socket.Send(seg0Bytes.Slice(sent));
        for (int i = 1; i < segCount; i++)
        {
            int sent2 = 0;
            int words = arena.GetWordCount(i);
            if (words == 0) continue;
            ReadOnlySpan<byte> segBytes = MemoryMarshal.AsBytes(arena.GetSegment(i).Slice(0, words));
            while (sent2 < segBytes.Length)
                sent2 += socket.Send(segBytes.Slice(sent2));
        }
    }
}

public sealed class FeedApiLoginTemplate
{
    private readonly SegmentArena arena;

    private const ulong Root = 0x0001000100000000UL;
    private const int UnionTag = 0;
    private const int DataWords = 0;
    private const int PointerWords = 3;
    private const int BaseSegment = 0;
    private const int BaseIndex = 1;

    public FeedApiLoginTemplate()
    {
        arena = new SegmentArena();
        arena.IncrementWordCount(0, 1);
        EncodeHelpers.AllocateStruct(arena, BaseSegment, 0, DataWords, PointerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public FeedApiLoginEncoder Populate()
    {
        return new FeedApiLoginEncoder(arena, BaseSegment, BaseIndex);
    }

    public ArenaMeta Meta => arena.Meta;

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public Span<ulong> GetWireFrame()
    {
        var buf = arena.Buffer;
        var segCount = arena.SegmentCount;
        var headerWords = 3 + (segCount - 1 + 1) / 2;
        var start = arena.ReservedWords - headerWords;
        arena.IncrementWordCount(0, 2);
        buf[start] = ((ulong)(arena.GetWordCount(0)) << 32) | (uint)(segCount - 1);

        var w = start + 1;
        for (int i = 1; i < segCount; i += 2)
            buf[w++] = (ulong)arena.GetWordCount(i + 1) << 32 | (uint) arena.GetWordCount(i);
        buf[w++] = Root;
        buf[w] = UnionTag;
        return buf.AsSpan(start, arena.GetWordCount(0) + headerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Send(Socket socket)
    {
        var buf = arena.Buffer;
        var segCount = arena.SegmentCount;
        var headerWords = 3 + (segCount - 1 + 1) / 2;
        var start = arena.ReservedWords - headerWords;
        arena.IncrementWordCount(0, 2);
        buf[start] = ((ulong)(arena.GetWordCount(0)) << 32) | (uint)(segCount - 1);

        var w = start + 1;
        for (int i = 1; i < segCount; i += 2)
            buf[w++] = (ulong)arena.GetWordCount(i + 1) << 32 | (uint) arena.GetWordCount(i);
        buf[w++] = Root;
        buf[w] = UnionTag;

        int seg0Words = arena.GetWordCount(0);
        int totalSeg0Words = 1 + seg0Words;
        ReadOnlySpan<byte> seg0Bytes = MemoryMarshal.AsBytes(arena.GetArenaAsSpan.Slice(start, totalSeg0Words));
        int sent = 0;
        while (sent < seg0Bytes.Length)
            sent += socket.Send(seg0Bytes.Slice(sent));
        for (int i = 1; i < segCount; i++)
        {
            int sent2 = 0;
            int words = arena.GetWordCount(i);
            if (words == 0) continue;
            ReadOnlySpan<byte> segBytes = MemoryMarshal.AsBytes(arena.GetSegment(i).Slice(0, words));
            while (sent2 < segBytes.Length)
                sent2 += socket.Send(segBytes.Slice(sent2));
        }
    }
}

public sealed class FeedApiSetSymbolListTemplate
{
    private readonly SegmentArena arena;

    private const ulong Root = 0x0001000100000000UL;
    private const int UnionTag = 0;
    private const int DataWords = 1;
    private const int PointerWords = 1;
    private const int BaseSegment = 0;
    private const int BaseIndex = 1;

    public FeedApiSetSymbolListTemplate()
    {
        arena = new SegmentArena();
        arena.IncrementWordCount(0, 1);
        EncodeHelpers.AllocateStruct(arena, BaseSegment, 0, DataWords, PointerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public FeedApiSetSymbolListEncoder Populate()
    {
        return new FeedApiSetSymbolListEncoder(arena, BaseSegment, BaseIndex);
    }

    public ArenaMeta Meta => arena.Meta;

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public Span<ulong> GetWireFrame()
    {
        var buf = arena.Buffer;
        var segCount = arena.SegmentCount;
        var headerWords = 3 + (segCount - 1 + 1) / 2;
        var start = arena.ReservedWords - headerWords;
        arena.IncrementWordCount(0, 2);
        buf[start] = ((ulong)(arena.GetWordCount(0)) << 32) | (uint)(segCount - 1);

        var w = start + 1;
        for (int i = 1; i < segCount; i += 2)
            buf[w++] = (ulong)arena.GetWordCount(i + 1) << 32 | (uint) arena.GetWordCount(i);
        buf[w++] = Root;
        buf[w] = UnionTag;
        return buf.AsSpan(start, arena.GetWordCount(0) + headerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Send(Socket socket)
    {
        var buf = arena.Buffer;
        var segCount = arena.SegmentCount;
        var headerWords = 3 + (segCount - 1 + 1) / 2;
        var start = arena.ReservedWords - headerWords;
        arena.IncrementWordCount(0, 2);
        buf[start] = ((ulong)(arena.GetWordCount(0)) << 32) | (uint)(segCount - 1);

        var w = start + 1;
        for (int i = 1; i < segCount; i += 2)
            buf[w++] = (ulong)arena.GetWordCount(i + 1) << 32 | (uint) arena.GetWordCount(i);
        buf[w++] = Root;
        buf[w] = UnionTag;

        int seg0Words = arena.GetWordCount(0);
        int totalSeg0Words = 1 + seg0Words;
        ReadOnlySpan<byte> seg0Bytes = MemoryMarshal.AsBytes(arena.GetArenaAsSpan.Slice(start, totalSeg0Words));
        int sent = 0;
        while (sent < seg0Bytes.Length)
            sent += socket.Send(seg0Bytes.Slice(sent));
        for (int i = 1; i < segCount; i++)
        {
            int sent2 = 0;
            int words = arena.GetWordCount(i);
            if (words == 0) continue;
            ReadOnlySpan<byte> segBytes = MemoryMarshal.AsBytes(arena.GetSegment(i).Slice(0, words));
            while (sent2 < segBytes.Length)
                sent2 += socket.Send(segBytes.Slice(sent2));
        }
    }
}

public sealed class FeedApiGetSymbolListContentsTemplate
{
    private readonly SegmentArena arena;

    private const ulong Root = 0x0001000100000000UL;
    private const int UnionTag = 0;
    private const int DataWords = 0;
    private const int PointerWords = 1;
    private const int BaseSegment = 0;
    private const int BaseIndex = 1;

    public FeedApiGetSymbolListContentsTemplate()
    {
        arena = new SegmentArena();
        arena.IncrementWordCount(0, 1);
        EncodeHelpers.AllocateStruct(arena, BaseSegment, 0, DataWords, PointerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public FeedApiGetSymbolListContentsEncoder Populate()
    {
        return new FeedApiGetSymbolListContentsEncoder(arena, BaseSegment, BaseIndex);
    }

    public ArenaMeta Meta => arena.Meta;

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public Span<ulong> GetWireFrame()
    {
        var buf = arena.Buffer;
        var segCount = arena.SegmentCount;
        var headerWords = 3 + (segCount - 1 + 1) / 2;
        var start = arena.ReservedWords - headerWords;
        arena.IncrementWordCount(0, 2);
        buf[start] = ((ulong)(arena.GetWordCount(0)) << 32) | (uint)(segCount - 1);

        var w = start + 1;
        for (int i = 1; i < segCount; i += 2)
            buf[w++] = (ulong)arena.GetWordCount(i + 1) << 32 | (uint) arena.GetWordCount(i);
        buf[w++] = Root;
        buf[w] = UnionTag;
        return buf.AsSpan(start, arena.GetWordCount(0) + headerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Send(Socket socket)
    {
        var buf = arena.Buffer;
        var segCount = arena.SegmentCount;
        var headerWords = 3 + (segCount - 1 + 1) / 2;
        var start = arena.ReservedWords - headerWords;
        arena.IncrementWordCount(0, 2);
        buf[start] = ((ulong)(arena.GetWordCount(0)) << 32) | (uint)(segCount - 1);

        var w = start + 1;
        for (int i = 1; i < segCount; i += 2)
            buf[w++] = (ulong)arena.GetWordCount(i + 1) << 32 | (uint) arena.GetWordCount(i);
        buf[w++] = Root;
        buf[w] = UnionTag;

        int seg0Words = arena.GetWordCount(0);
        int totalSeg0Words = 1 + seg0Words;
        ReadOnlySpan<byte> seg0Bytes = MemoryMarshal.AsBytes(arena.GetArenaAsSpan.Slice(start, totalSeg0Words));
        int sent = 0;
        while (sent < seg0Bytes.Length)
            sent += socket.Send(seg0Bytes.Slice(sent));
        for (int i = 1; i < segCount; i++)
        {
            int sent2 = 0;
            int words = arena.GetWordCount(i);
            if (words == 0) continue;
            ReadOnlySpan<byte> segBytes = MemoryMarshal.AsBytes(arena.GetSegment(i).Slice(0, words));
            while (sent2 < segBytes.Length)
                sent2 += socket.Send(segBytes.Slice(sent2));
        }
    }
}

