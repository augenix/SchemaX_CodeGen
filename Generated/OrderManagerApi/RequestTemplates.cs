using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace SchemaX_CodeGen.Generated.OrderManagerApi;

public sealed class OrderRequestNewOrderTemplate
{
    private readonly SegmentArena arena;

    private const ulong Root = 0x0001000100000000UL;
    private const int UnionTag = 0;
    private const int DataWords = 8;
    private const int PointerWords = 4;
    private const int BaseSegment = 0;
    private const int BaseIndex = 1;

    public OrderRequestNewOrderTemplate()
    {
        arena = new SegmentArena();
        arena.IncrementWordCount(0, 1);
        EncodeHelpers.AllocateStruct(arena, BaseSegment, 0, DataWords, PointerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public OrderRequestNewOrderEncoder Populate()
    {
        return new OrderRequestNewOrderEncoder(arena, BaseSegment, BaseIndex);
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

public sealed class OrderRequestCancelReplaceTemplate
{
    private readonly SegmentArena arena;

    private const ulong Root = 0x0001000100000000UL;
    private const int UnionTag = 1;
    private const int DataWords = 9;
    private const int PointerWords = 4;
    private const int BaseSegment = 0;
    private const int BaseIndex = 1;

    public OrderRequestCancelReplaceTemplate()
    {
        arena = new SegmentArena();
        arena.IncrementWordCount(0, 1);
        EncodeHelpers.AllocateStruct(arena, BaseSegment, 0, DataWords, PointerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public OrderRequestCancelReplaceEncoder Populate()
    {
        return new OrderRequestCancelReplaceEncoder(arena, BaseSegment, BaseIndex);
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

public sealed class OrderRequestCancelTemplate
{
    private readonly SegmentArena arena;

    private const ulong Root = 0x0001000100000000UL;
    private const int UnionTag = 2;
    private const int DataWords = 5;
    private const int PointerWords = 3;
    private const int BaseSegment = 0;
    private const int BaseIndex = 1;

    public OrderRequestCancelTemplate()
    {
        arena = new SegmentArena();
        arena.IncrementWordCount(0, 1);
        EncodeHelpers.AllocateStruct(arena, BaseSegment, 0, DataWords, PointerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public OrderRequestCancelEncoder Populate()
    {
        return new OrderRequestCancelEncoder(arena, BaseSegment, BaseIndex);
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

public sealed class OrderRequestStatusTemplate
{
    private readonly SegmentArena arena;

    private const ulong Root = 0x0001000100000000UL;
    private const int UnionTag = 3;
    private const int DataWords = 4;
    private const int PointerWords = 3;
    private const int BaseSegment = 0;
    private const int BaseIndex = 1;

    public OrderRequestStatusTemplate()
    {
        arena = new SegmentArena();
        arena.IncrementWordCount(0, 1);
        EncodeHelpers.AllocateStruct(arena, BaseSegment, 0, DataWords, PointerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public OrderRequestStatusEncoder Populate()
    {
        return new OrderRequestStatusEncoder(arena, BaseSegment, BaseIndex);
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

public sealed class OrderRequestMassStatusTemplate
{
    private readonly SegmentArena arena;

    private const ulong Root = 0x0001000100000000UL;
    private const int UnionTag = 4;
    private const int DataWords = 4;
    private const int PointerWords = 4;
    private const int BaseSegment = 0;
    private const int BaseIndex = 1;

    public OrderRequestMassStatusTemplate()
    {
        arena = new SegmentArena();
        arena.IncrementWordCount(0, 1);
        EncodeHelpers.AllocateStruct(arena, BaseSegment, 0, DataWords, PointerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public OrderRequestMassStatusEncoder Populate()
    {
        return new OrderRequestMassStatusEncoder(arena, BaseSegment, BaseIndex);
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

public sealed class OrderRequestMassActionTemplate
{
    private readonly SegmentArena arena;

    private const ulong Root = 0x0001000100000000UL;
    private const int UnionTag = 5;
    private const int DataWords = 5;
    private const int PointerWords = 4;
    private const int BaseSegment = 0;
    private const int BaseIndex = 1;

    public OrderRequestMassActionTemplate()
    {
        arena = new SegmentArena();
        arena.IncrementWordCount(0, 1);
        EncodeHelpers.AllocateStruct(arena, BaseSegment, 0, DataWords, PointerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public OrderRequestMassActionEncoder Populate()
    {
        return new OrderRequestMassActionEncoder(arena, BaseSegment, BaseIndex);
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

public sealed class OrderRequestPartyDetailsDefinitionTemplate
{
    private readonly SegmentArena arena;

    private const ulong Root = 0x0001000100000000UL;
    private const int UnionTag = 6;
    private const int DataWords = 3;
    private const int PointerWords = 2;
    private const int BaseSegment = 0;
    private const int BaseIndex = 1;

    public OrderRequestPartyDetailsDefinitionTemplate()
    {
        arena = new SegmentArena();
        arena.IncrementWordCount(0, 1);
        EncodeHelpers.AllocateStruct(arena, BaseSegment, 0, DataWords, PointerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public OrderRequestPartyDetailsDefinitionEncoder Populate()
    {
        return new OrderRequestPartyDetailsDefinitionEncoder(arena, BaseSegment, BaseIndex);
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

public sealed class OrderRequestPartyDetailsListTemplate
{
    private readonly SegmentArena arena;

    private const ulong Root = 0x0001000100000000UL;
    private const int UnionTag = 7;
    private const int DataWords = 2;
    private const int PointerWords = 2;
    private const int BaseSegment = 0;
    private const int BaseIndex = 1;

    public OrderRequestPartyDetailsListTemplate()
    {
        arena = new SegmentArena();
        arena.IncrementWordCount(0, 1);
        EncodeHelpers.AllocateStruct(arena, BaseSegment, 0, DataWords, PointerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public OrderRequestPartyDetailsListEncoder Populate()
    {
        return new OrderRequestPartyDetailsListEncoder(arena, BaseSegment, BaseIndex);
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

public sealed class OrderManagerCommandTemplate
{
    private readonly SegmentArena arena;

    private const ulong Root = 0x0001000100000000UL;
    private const int UnionTag = 8;
    private const int DataWords = 1;
    private const int PointerWords = 0;
    private const int BaseSegment = 0;
    private const int BaseIndex = 1;

    public OrderManagerCommandTemplate()
    {
        arena = new SegmentArena();
        arena.IncrementWordCount(0, 1);
        EncodeHelpers.AllocateStruct(arena, BaseSegment, 0, DataWords, PointerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public OrderManagerCommandEncoder Populate()
    {
        return new OrderManagerCommandEncoder(arena, BaseSegment, BaseIndex);
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

public sealed class OrderManagerCommandAckAccountEventsTemplate
{
    private readonly SegmentArena arena;

    private const ulong Root = 0x0001000100000000UL;
    private const int UnionTag = 9;
    private const int DataWords = 1;
    private const int PointerWords = 1;
    private const int BaseSegment = 0;
    private const int BaseIndex = 1;

    public OrderManagerCommandAckAccountEventsTemplate()
    {
        arena = new SegmentArena();
        arena.IncrementWordCount(0, 1);
        EncodeHelpers.AllocateStruct(arena, BaseSegment, 0, DataWords, PointerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public OrderManagerCommandAckAccountEventsEncoder Populate()
    {
        return new OrderManagerCommandAckAccountEventsEncoder(arena, BaseSegment, BaseIndex);
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

public sealed class OrderManagerCommandSetRiskLimitTemplate
{
    private readonly SegmentArena arena;

    private const ulong Root = 0x0001000100000000UL;
    private const int UnionTag = 10;
    private const int DataWords = 0;
    private const int PointerWords = 1;
    private const int BaseSegment = 0;
    private const int BaseIndex = 1;

    public OrderManagerCommandSetRiskLimitTemplate()
    {
        arena = new SegmentArena();
        arena.IncrementWordCount(0, 1);
        EncodeHelpers.AllocateStruct(arena, BaseSegment, 0, DataWords, PointerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public OrderManagerCommandSetRiskLimitEncoder Populate()
    {
        return new OrderManagerCommandSetRiskLimitEncoder(arena, BaseSegment, BaseIndex);
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

public sealed class OrderManagerCommandLoginTemplate
{
    private readonly SegmentArena arena;

    private const ulong Root = 0x0001000100000000UL;
    private const int UnionTag = 11;
    private const int DataWords = 1;
    private const int PointerWords = 3;
    private const int BaseSegment = 0;
    private const int BaseIndex = 1;

    public OrderManagerCommandLoginTemplate()
    {
        arena = new SegmentArena();
        arena.IncrementWordCount(0, 1);
        EncodeHelpers.AllocateStruct(arena, BaseSegment, 0, DataWords, PointerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public OrderManagerCommandLoginEncoder Populate()
    {
        return new OrderManagerCommandLoginEncoder(arena, BaseSegment, BaseIndex);
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

public sealed class OrderManagerCommandPingTemplate
{
    private readonly SegmentArena arena;

    private const ulong Root = 0x0001000100000000UL;
    private const int UnionTag = 12;
    private const int DataWords = 1;
    private const int PointerWords = 0;
    private const int BaseSegment = 0;
    private const int BaseIndex = 1;

    public OrderManagerCommandPingTemplate()
    {
        arena = new SegmentArena();
        arena.IncrementWordCount(0, 1);
        EncodeHelpers.AllocateStruct(arena, BaseSegment, 0, DataWords, PointerWords);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public OrderManagerCommandPingEncoder Populate()
    {
        return new OrderManagerCommandPingEncoder(arena, BaseSegment, BaseIndex);
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

