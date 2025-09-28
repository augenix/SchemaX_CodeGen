using System.Runtime.CompilerServices;

namespace SchemaX_CodeGen.Generated.DataFeedApi;
public ref struct UtcTimeEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 0;

    public UtcTimeEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public long TimeNs
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (long)buffer[0];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (ulong)value;
    }

}

public ref struct CmeFeedManagerTimestampsEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 0;
    private const int PointerWords = 4;

    public CmeFeedManagerTimestampsEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public UtcTimeStructAccessor Exchange => new UtcTimeStructAccessor(arena, segmentIndex, offset + 0);

    public UtcTimeStructAccessor Sending => new UtcTimeStructAccessor(arena, segmentIndex, offset + 1);

    public UtcTimeStructAccessor Receipt => new UtcTimeStructAccessor(arena, segmentIndex, offset + 2);

    public UtcTimeStructAccessor Extract => new UtcTimeStructAccessor(arena, segmentIndex, offset + 3);


    public ref struct UtcTimeStructAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UtcTimeStructAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UtcTimeEncoder Writer()
        {
            var cursor = EncodeHelpers.AllocateStruct(arena, segmentIndex, pointerIndex, 1, 0);
            return new UtcTimeEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UtcTimeEncoder Reader()
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            return new UtcTimeEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct CmeFeedPriceLevelEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 2;
    private const int PointerWords = 0;

    public CmeFeedPriceLevelEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public uint OrderCnt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 0) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 0)) | ((ulong)value << 0);
    }

    public uint Quantity
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[1]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

}

public ref struct CmeFeedUpdateGroupStatusEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 2;
    private const int PointerWords = 3;

    public CmeFeedUpdateGroupStatusEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public string GroupName
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 0, value);
    }

    public int MdpChannelId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 0) & 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 0)) | ((ulong)(uint)value << 0);
    }

    public ushort InstGroupNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[0] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public string AssetCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }

    public CmeFeedManagerTimestampsStructAccessor Timestamp => new CmeFeedManagerTimestampsStructAccessor(arena, segmentIndex, offset + 2);

    public TradingStatus TradingStatus
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (TradingStatus)(ushort)((buffer[0] >> 48) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 48)) | ((ulong)(ushort)value << 48);
    }

    public HaltReason HaltReason
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HaltReason)(ushort)((buffer[1] >> 0) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFUL << 0)) | ((ulong)(ushort)value << 0);
    }

    public TradingEvent TradingEvent
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (TradingEvent)(ushort)((buffer[1] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }


    public ref struct CmeFeedManagerTimestampsStructAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsStructAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsEncoder Writer()
        {
            var cursor = EncodeHelpers.AllocateStruct(arena, segmentIndex, pointerIndex, 0, 4);
            return new CmeFeedManagerTimestampsEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsEncoder Reader()
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            return new CmeFeedManagerTimestampsEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct CmeFeedUpdateInstStatusEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 6;
    private const int PointerWords = 1;

    public CmeFeedUpdateInstStatusEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 0) & 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 0)) | ((ulong)(uint)value << 0);
    }

    public int MdpChannelId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 32) & 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 32)) | ((ulong)(uint)value << 32);
    }

    public ushort InstNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[1] >> 0) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFFFFFUL << 0)) | ((ulong)value << 0);
    }

    public CmeFeedManagerTimestampsStructAccessor Timestamp => new CmeFeedManagerTimestampsStructAccessor(arena, segmentIndex, offset + 0);

    public TradingStatus TradingStatus
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (TradingStatus)(ushort)((buffer[1] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public HaltReason HaltReason
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HaltReason)(ushort)((buffer[1] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public TradingEvent TradingEvent
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (TradingEvent)(ushort)((buffer[1] >> 48) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFUL << 48)) | ((ulong)(ushort)value << 48);
    }

    public bool DailyLimitPriceLbValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[2] >> 0) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (buffer[2] & ~(1UL << 0)) | (value ? 1UL << 0 : 0UL);
    }

    public double DailyLimitPriceLb
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public bool DailyLimitPriceUbValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[2] >> 1) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (buffer[2] & ~(1UL << 1)) | (value ? 1UL << 1 : 0UL);
    }

    public double DailyLimitPriceUb
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[4]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public bool MaxPriceVariationValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[2] >> 2) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (buffer[2] & ~(1UL << 2)) | (value ? 1UL << 2 : 0UL);
    }

    public double MaxPriceVariation
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[5]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[5] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }


    public ref struct CmeFeedManagerTimestampsStructAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsStructAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsEncoder Writer()
        {
            var cursor = EncodeHelpers.AllocateStruct(arena, segmentIndex, pointerIndex, 0, 4);
            return new CmeFeedManagerTimestampsEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsEncoder Reader()
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            return new CmeFeedManagerTimestampsEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct CmeFeedUpdateIndicativeOpeningEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 3;
    private const int PointerWords = 1;

    public CmeFeedUpdateIndicativeOpeningEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 0) & 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 0)) | ((ulong)(uint)value << 0);
    }

    public int MdpChannelId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 32) & 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 32)) | ((ulong)(uint)value << 32);
    }

    public ushort InstNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[1] >> 0) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFFFFFUL << 0)) | ((ulong)value << 0);
    }

    public CmeFeedManagerTimestampsStructAccessor Timestamp => new CmeFeedManagerTimestampsStructAccessor(arena, segmentIndex, offset + 0);

    public uint Quantity
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[1] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[2]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }


    public ref struct CmeFeedManagerTimestampsStructAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsStructAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsEncoder Writer()
        {
            var cursor = EncodeHelpers.AllocateStruct(arena, segmentIndex, pointerIndex, 0, 4);
            return new CmeFeedManagerTimestampsEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsEncoder Reader()
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            return new CmeFeedManagerTimestampsEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct CmeFeedUpdateOpeningPriceEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 3;
    private const int PointerWords = 1;

    public CmeFeedUpdateOpeningPriceEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 0) & 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 0)) | ((ulong)(uint)value << 0);
    }

    public int MdpChannelId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 32) & 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 32)) | ((ulong)(uint)value << 32);
    }

    public ushort InstNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[1] >> 0) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFFFFFUL << 0)) | ((ulong)value << 0);
    }

    public CmeFeedManagerTimestampsStructAccessor Timestamp => new CmeFeedManagerTimestampsStructAccessor(arena, segmentIndex, offset + 0);

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[2]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }


    public ref struct CmeFeedManagerTimestampsStructAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsStructAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsEncoder Writer()
        {
            var cursor = EncodeHelpers.AllocateStruct(arena, segmentIndex, pointerIndex, 0, 4);
            return new CmeFeedManagerTimestampsEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsEncoder Reader()
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            return new CmeFeedManagerTimestampsEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct CmeFeedUpdateSettlementEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 4;
    private const int PointerWords = 3;

    public CmeFeedUpdateSettlementEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 0) & 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 0)) | ((ulong)(uint)value << 0);
    }

    public int MdpChannelId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 32) & 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 32)) | ((ulong)(uint)value << 32);
    }

    public ushort InstNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[1] >> 0) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFFFFFUL << 0)) | ((ulong)value << 0);
    }

    public CmeFeedManagerTimestampsStructAccessor Timestamp => new CmeFeedManagerTimestampsStructAccessor(arena, segmentIndex, offset + 0);

    public bool PriceValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[1] >> 16) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (buffer[1] & ~(1UL << 16)) | (value ? 1UL << 16 : 0UL);
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[2]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public UtcTimeStructAccessor PriceTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 1);

    public bool PreliminaryPriceValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[1] >> 17) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (buffer[1] & ~(1UL << 17)) | (value ? 1UL << 17 : 0UL);
    }

    public double PreliminaryPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public UtcTimeStructAccessor PreliminaryPriceTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 2);


    public ref struct CmeFeedManagerTimestampsStructAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsStructAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsEncoder Writer()
        {
            var cursor = EncodeHelpers.AllocateStruct(arena, segmentIndex, pointerIndex, 0, 4);
            return new CmeFeedManagerTimestampsEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsEncoder Reader()
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            return new CmeFeedManagerTimestampsEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }
    }

    public ref struct UtcTimeStructAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UtcTimeStructAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UtcTimeEncoder Writer()
        {
            var cursor = EncodeHelpers.AllocateStruct(arena, segmentIndex, pointerIndex, 1, 0);
            return new UtcTimeEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UtcTimeEncoder Reader()
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            return new UtcTimeEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct CmeFeedUpdateTradeEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 4;
    private const int PointerWords = 1;

    public CmeFeedUpdateTradeEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 0) & 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 0)) | ((ulong)(uint)value << 0);
    }

    public int MdpChannelId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 32) & 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 32)) | ((ulong)(uint)value << 32);
    }

    public ushort InstNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[1] >> 0) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFFFFFUL << 0)) | ((ulong)value << 0);
    }

    public CmeFeedManagerTimestampsStructAccessor Timestamp => new CmeFeedManagerTimestampsStructAccessor(arena, segmentIndex, offset + 0);

    public BookStatus BookStatus
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (BookStatus)(ushort)((buffer[1] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public AggressorSideKind AggressorSideKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (AggressorSideKind)(ushort)((buffer[1] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public uint OrderCnt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[2] >> 0) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (buffer[2] & ~(0xFFFFFFFFUL << 0)) | ((ulong)value << 0);
    }

    public uint Quantity
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[2] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (buffer[2] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }


    public ref struct CmeFeedManagerTimestampsStructAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsStructAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsEncoder Writer()
        {
            var cursor = EncodeHelpers.AllocateStruct(arena, segmentIndex, pointerIndex, 0, 4);
            return new CmeFeedManagerTimestampsEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsEncoder Reader()
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            return new CmeFeedManagerTimestampsEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct CmeFeedUpdateSideEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 3;
    private const int PointerWords = 2;

    public CmeFeedUpdateSideEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 0) & 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 0)) | ((ulong)(uint)value << 0);
    }

    public int MdpChannelId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 32) & 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 32)) | ((ulong)(uint)value << 32);
    }

    public ushort InstNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[1] >> 0) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFFFFFUL << 0)) | ((ulong)value << 0);
    }

    public CmeFeedManagerTimestampsStructAccessor Timestamp => new CmeFeedManagerTimestampsStructAccessor(arena, segmentIndex, offset + 0);

    public BookStatus BookStatus
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (BookStatus)(ushort)((buffer[1] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public BookSideKind SideKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (BookSideKind)(ushort)((buffer[1] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public BookSideOrdersKind OrdersKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (BookSideOrdersKind)(ushort)((buffer[1] >> 48) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFUL << 48)) | ((ulong)(ushort)value << 48);
    }

    public bool IsLastSideOfBook
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[2] >> 0) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (buffer[2] & ~(1UL << 0)) | (value ? 1UL << 0 : 0UL);
    }

    public CmeFeedPriceLevelListAccessor Levels => new CmeFeedPriceLevelListAccessor(arena, segmentIndex, offset + 1);


    public ref struct CmeFeedManagerTimestampsStructAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsStructAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsEncoder Writer()
        {
            var cursor = EncodeHelpers.AllocateStruct(arena, segmentIndex, pointerIndex, 0, 4);
            return new CmeFeedManagerTimestampsEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsEncoder Reader()
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            return new CmeFeedManagerTimestampsEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }
    }

    public ref struct CmeFeedPriceLevelListAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedPriceLevelListAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Init(int count)
        {
            EncodeHelpers.AllocateList_Struct(arena, segmentIndex, pointerIndex, count, 2, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedPriceLevelEncoder GetElement(int index)
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            var elementCursor = EncodeHelpers.GetListElementCursor(arena, cursor.segmentIndex, cursor.structIndex, index);
            return new CmeFeedPriceLevelEncoder(arena, elementCursor.segmentIndex, elementCursor.elementIndex);
        }
    }
}

public ref struct CmeFeedUpdateLastMessageForEventEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 1;

    public CmeFeedUpdateLastMessageForEventEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public int MdpChannelId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 0) & 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 0)) | ((ulong)(uint)value << 0);
    }

    public CmeFeedManagerTimestampsStructAccessor Timestamp => new CmeFeedManagerTimestampsStructAccessor(arena, segmentIndex, offset + 0);


    public ref struct CmeFeedManagerTimestampsStructAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsStructAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsEncoder Writer()
        {
            var cursor = EncodeHelpers.AllocateStruct(arena, segmentIndex, pointerIndex, 0, 4);
            return new CmeFeedManagerTimestampsEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsEncoder Reader()
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            return new CmeFeedManagerTimestampsEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct CmeFeedUpdateFinishedAllEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 0;
    private const int PointerWords = 1;

    public CmeFeedUpdateFinishedAllEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 0);


    public ref struct UtcTimeStructAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UtcTimeStructAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UtcTimeEncoder Writer()
        {
            var cursor = EncodeHelpers.AllocateStruct(arena, segmentIndex, pointerIndex, 1, 0);
            return new UtcTimeEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UtcTimeEncoder Reader()
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            return new UtcTimeEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct CmeFeedTradeStatisticsEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 5;
    private const int PointerWords = 0;

    public CmeFeedTradeStatisticsEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public ushort InstNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[0] >> 0) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 0)) | ((ulong)value << 0);
    }

    public double HighPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[1]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public double LowPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[2]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public double LastPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public ulong Volume
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[4];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = value;
    }

}

public ref struct CmeFeedInstrumentStateEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 8;

    public CmeFeedInstrumentStateEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public ushort InstNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[0] >> 0) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 0)) | ((ulong)value << 0);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 32) & 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 32)) | ((ulong)(uint)value << 32);
    }

    public CmeFeedUpdateInstStatusStructAccessor InstStatus => new CmeFeedUpdateInstStatusStructAccessor(arena, segmentIndex, offset + 0);

    public CmeFeedUpdateTradeStructAccessor LastTrade => new CmeFeedUpdateTradeStructAccessor(arena, segmentIndex, offset + 1);

    public CmeFeedUpdateOpeningPriceStructAccessor OpeningPrice => new CmeFeedUpdateOpeningPriceStructAccessor(arena, segmentIndex, offset + 2);

    public CmeFeedUpdateSettlementStructAccessor Settlement => new CmeFeedUpdateSettlementStructAccessor(arena, segmentIndex, offset + 3);

    public CmeFeedUpdateSideStructAccessor BidBook => new CmeFeedUpdateSideStructAccessor(arena, segmentIndex, offset + 4);

    public CmeFeedUpdateSideStructAccessor ImpBidBook => new CmeFeedUpdateSideStructAccessor(arena, segmentIndex, offset + 5);

    public CmeFeedUpdateSideStructAccessor AskBook => new CmeFeedUpdateSideStructAccessor(arena, segmentIndex, offset + 6);

    public CmeFeedUpdateSideStructAccessor ImpAskBook => new CmeFeedUpdateSideStructAccessor(arena, segmentIndex, offset + 7);

    public bool InstStatusValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 16) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(1UL << 16)) | (value ? 1UL << 16 : 0UL);
    }

    public bool LastTradeValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 17) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(1UL << 17)) | (value ? 1UL << 17 : 0UL);
    }

    public bool OpeningPriceValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 18) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(1UL << 18)) | (value ? 1UL << 18 : 0UL);
    }

    public bool SettlementValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 19) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(1UL << 19)) | (value ? 1UL << 19 : 0UL);
    }

    public bool BidBookValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 20) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(1UL << 20)) | (value ? 1UL << 20 : 0UL);
    }

    public bool ImpBidBookValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 21) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(1UL << 21)) | (value ? 1UL << 21 : 0UL);
    }

    public bool AskBookValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 22) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(1UL << 22)) | (value ? 1UL << 22 : 0UL);
    }

    public bool ImpAskBookValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 23) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(1UL << 23)) | (value ? 1UL << 23 : 0UL);
    }


    public ref struct CmeFeedUpdateInstStatusStructAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedUpdateInstStatusStructAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedUpdateInstStatusEncoder Writer()
        {
            var cursor = EncodeHelpers.AllocateStruct(arena, segmentIndex, pointerIndex, 6, 1);
            return new CmeFeedUpdateInstStatusEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedUpdateInstStatusEncoder Reader()
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            return new CmeFeedUpdateInstStatusEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }
    }

    public ref struct CmeFeedUpdateTradeStructAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedUpdateTradeStructAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedUpdateTradeEncoder Writer()
        {
            var cursor = EncodeHelpers.AllocateStruct(arena, segmentIndex, pointerIndex, 4, 1);
            return new CmeFeedUpdateTradeEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedUpdateTradeEncoder Reader()
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            return new CmeFeedUpdateTradeEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }
    }

    public ref struct CmeFeedUpdateOpeningPriceStructAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedUpdateOpeningPriceStructAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedUpdateOpeningPriceEncoder Writer()
        {
            var cursor = EncodeHelpers.AllocateStruct(arena, segmentIndex, pointerIndex, 3, 1);
            return new CmeFeedUpdateOpeningPriceEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedUpdateOpeningPriceEncoder Reader()
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            return new CmeFeedUpdateOpeningPriceEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }
    }

    public ref struct CmeFeedUpdateSettlementStructAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedUpdateSettlementStructAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedUpdateSettlementEncoder Writer()
        {
            var cursor = EncodeHelpers.AllocateStruct(arena, segmentIndex, pointerIndex, 4, 3);
            return new CmeFeedUpdateSettlementEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedUpdateSettlementEncoder Reader()
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            return new CmeFeedUpdateSettlementEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }
    }

    public ref struct CmeFeedUpdateSideStructAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedUpdateSideStructAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedUpdateSideEncoder Writer()
        {
            var cursor = EncodeHelpers.AllocateStruct(arena, segmentIndex, pointerIndex, 3, 2);
            return new CmeFeedUpdateSideEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedUpdateSideEncoder Reader()
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            return new CmeFeedUpdateSideEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct CmeLegDefinitionEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 0;

    public CmeLegDefinitionEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 0) & 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 0)) | ((ulong)(uint)value << 0);
    }

    public int Ratio
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 32) & 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 32)) | ((ulong)(uint)value << 32);
    }

}

public ref struct CmeFuturesDefinitionEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 13;
    private const int PointerWords = 12;

    public CmeFuturesDefinitionEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public string Symbol
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 0, value);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 0) & 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 0)) | ((ulong)(uint)value << 0);
    }

    public int MarketSegmentGatewayId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 32) & 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 32)) | ((ulong)(uint)value << 32);
    }

    public int MdpChannelId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[1] >> 0) & 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFFFFFUL << 0)) | ((ulong)(uint)value << 0);
    }

    public string SecurityGroupCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }

    public CmeAssetKind AssetKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeAssetKind)(ushort)((buffer[1] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public string AssetCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 2);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 2, value);
    }

    public string CfiCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 3);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 3, value);
    }

    public CmeSecuritySubtype SecuritySubtype
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeSecuritySubtype)(ushort)((buffer[1] >> 48) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFUL << 48)) | ((ulong)(ushort)value << 48);
    }

    public string SecuritySubtypeCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 4);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 4, value);
    }

    public string MaturityMonthyear
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 5);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 5, value);
    }

    public CmeAssetEquivalenceKind EquivalenceKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeAssetEquivalenceKind)(ushort)((buffer[2] >> 0) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[2] = (buffer[2] & ~(0xFFFFUL << 0)) | ((ulong)(ushort)value << 0);
    }

    public CmeAssetKind EquivalentAssetKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeAssetKind)(ushort)((buffer[2] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[2] = (buffer[2] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public CmePriceValueKind PriceValueKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmePriceValueKind)(ushort)((buffer[2] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[2] = (buffer[2] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public double TruePriceOffset
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public double PriceToCurrency
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[4]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public double MinPriceIncrement
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[5]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[5] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public string CurrencyCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 6);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 6, value);
    }

    public string SettleCurrencyCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 7);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 7, value);
    }

    public string UnitOfMeasureCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 8);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 8, value);
    }

    public double UnitOfMeasureQuantity
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[6]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[6] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public bool LimitPricesValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[2] >> 48) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (buffer[2] & ~(1UL << 48)) | (value ? 1UL << 48 : 0UL);
    }

    public double HighLimitPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[7]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[7] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public double LowLimitPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[8]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[8] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public bool MaxPriceVariationValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[2] >> 49) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (buffer[2] & ~(1UL << 49)) | (value ? 1UL << 49 : 0UL);
    }

    public double MaxPriceVariation
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[9]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[9] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public int BookDepth
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[10] >> 0) & 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[10] = (buffer[10] & ~(0xFFFFFFFFUL << 0)) | ((ulong)(uint)value << 0);
    }

    public bool HasImpliedBook
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[2] >> 50) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (buffer[2] & ~(1UL << 50)) | (value ? 1UL << 50 : 0UL);
    }

    public CmeMatchAlgorithm MatchAlgorithm
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeMatchAlgorithm)(ushort)((buffer[10] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[10] = (buffer[10] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public int MinTradeVolume
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[11] >> 0) & 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[11] = (buffer[11] & ~(0xFFFFFFFFUL << 0)) | ((ulong)(uint)value << 0);
    }

    public int MaxTradeVolume
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[11] >> 32) & 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[11] = (buffer[11] & ~(0xFFFFFFFFUL << 32)) | ((ulong)(uint)value << 32);
    }

    public bool RelativeToPreviousSettlement
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[2] >> 51) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (buffer[2] & ~(1UL << 51)) | (value ? 1UL << 51 : 0UL);
    }

    public UtcTimeStructAccessor ActivationTime => new UtcTimeStructAccessor(arena, segmentIndex, offset + 9);

    public UtcTimeStructAccessor LastEligibleTradeTime => new UtcTimeStructAccessor(arena, segmentIndex, offset + 10);

    public CmeLegDefinitionListAccessor Legs => new CmeLegDefinitionListAccessor(arena, segmentIndex, offset + 11);

    public bool IsFeedAvailable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[2] >> 52) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (buffer[2] & ~(1UL << 52)) | (value ? 1UL << 52 : 0UL);
    }

    public ushort InstNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[10] >> 48) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[10] = (buffer[10] & ~(0xFFFFFFFFUL << 48)) | ((ulong)value << 48);
    }

    public ushort GroupNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[12] >> 0) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[12] = (buffer[12] & ~(0xFFFFFFFFUL << 0)) | ((ulong)value << 0);
    }


    public ref struct UtcTimeStructAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UtcTimeStructAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UtcTimeEncoder Writer()
        {
            var cursor = EncodeHelpers.AllocateStruct(arena, segmentIndex, pointerIndex, 1, 0);
            return new UtcTimeEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UtcTimeEncoder Reader()
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            return new UtcTimeEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }
    }

    public ref struct CmeLegDefinitionListAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeLegDefinitionListAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Init(int count)
        {
            EncodeHelpers.AllocateList_Struct(arena, segmentIndex, pointerIndex, count, 1, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeLegDefinitionEncoder GetElement(int index)
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            var elementCursor = EncodeHelpers.GetListElementCursor(arena, cursor.segmentIndex, cursor.structIndex, index);
            return new CmeLegDefinitionEncoder(arena, elementCursor.segmentIndex, elementCursor.elementIndex);
        }
    }
}

public ref struct CmeFuturesDefinitionResponseEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 0;
    private const int PointerWords = 2;

    public CmeFuturesDefinitionResponseEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public CmeFuturesDefinitionListAccessor Definitions => new CmeFuturesDefinitionListAccessor(arena, segmentIndex, offset + 0);

    public string Error
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }


    public ref struct CmeFuturesDefinitionListAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFuturesDefinitionListAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Init(int count)
        {
            EncodeHelpers.AllocateList_Struct(arena, segmentIndex, pointerIndex, count, 13, 12);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFuturesDefinitionEncoder GetElement(int index)
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            var elementCursor = EncodeHelpers.GetListElementCursor(arena, cursor.segmentIndex, cursor.structIndex, index);
            return new CmeFuturesDefinitionEncoder(arena, elementCursor.segmentIndex, elementCursor.elementIndex);
        }
    }
}

public ref struct CmeFeedRequestSymbolAvailabilityResponseEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 2;
    private const int PointerWords = 2;

    public CmeFeedRequestSymbolAvailabilityResponseEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public bool Success
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 0) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(1UL << 0)) | (value ? 1UL << 0 : 0UL);
    }

    public AvailabilityAction Action
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (AvailabilityAction)(ushort)((buffer[0] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public ushort InstNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[0] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[1] >> 0) & 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFFFFFUL << 0)) | ((ulong)(uint)value << 0);
    }

    public string Symbol
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 0, value);
    }

    public string Error
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }

}

public ref struct CmeFeedClientFirehoseEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 0;

    public CmeFeedClientFirehoseEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public FirehoseAction Action
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (FirehoseAction)(ushort)((buffer[0] >> 0) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 0)) | ((ulong)(ushort)value << 0);
    }

}

public ref struct CmeFeedClientSubscribeEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 2;

    public CmeFeedClientSubscribeEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public CmeFeedClientSubscribeKind which
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeFeedClientSubscribeKind)(ushort)((buffer[0] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public SubscriptionAction Action
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (SubscriptionAction)(ushort)((buffer[0] >> 0) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 0)) | ((ulong)(ushort)value << 0);
    }

    public ReadOnlySpan<int> SecurityIdList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadList_Primitive<int>(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteList_Primitive<int>(arena, segmentIndex, offset + 0, value);
    }

    public ReadOnlySpan<ushort> InstList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadList_Primitive<ushort>(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteList_Primitive<ushort>(arena, segmentIndex, offset + 0, value);
    }

    public BookSideOrdersKind OrdersKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (BookSideOrdersKind)(ushort)((buffer[0] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public ReadOnlySpan<ushort> DepthList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadList_Primitive<ushort>(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteList_Primitive<ushort>(arena, segmentIndex, offset + 1, value);
    }

}

public ref struct CmeFeedClientSubscribeResponseEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 1;

    public CmeFeedClientSubscribeResponseEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public CmeFeedClientSubscribeResponseKind which
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeFeedClientSubscribeResponseKind)(ushort)((buffer[0] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public CmeFeedClientSubscribeResult Result
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeFeedClientSubscribeResult)(ushort)((buffer[0] >> 0) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 0)) | ((ulong)(ushort)value << 0);
    }

    public ReadOnlySpan<int> BadSecurityIdList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadList_Primitive<int>(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteList_Primitive<int>(arena, segmentIndex, offset + 0, value);
    }

    public ReadOnlySpan<ushort> BadInstList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadList_Primitive<ushort>(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteList_Primitive<ushort>(arena, segmentIndex, offset + 0, value);
    }

}

public ref struct CmeFuturesDefinitionSpecEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 5;

    public CmeFuturesDefinitionSpecEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public CmeAssetKind AssetKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeAssetKind)(ushort)((buffer[0] >> 0) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 0)) | ((ulong)(ushort)value << 0);
    }

    public CmeSecuritySubtype SecuritySubtype
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeSecuritySubtype)(ushort)((buffer[0] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public string SecurityGroupCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 0, value);
    }

    public UtcTimeStructAccessor ActivationTimeLb => new UtcTimeStructAccessor(arena, segmentIndex, offset + 1);

    public UtcTimeStructAccessor ActivationTimeUb => new UtcTimeStructAccessor(arena, segmentIndex, offset + 2);

    public UtcTimeStructAccessor LastEligibleTradeTimeLb => new UtcTimeStructAccessor(arena, segmentIndex, offset + 3);

    public UtcTimeStructAccessor LastEligibleTradeTimeUb => new UtcTimeStructAccessor(arena, segmentIndex, offset + 4);


    public ref struct UtcTimeStructAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UtcTimeStructAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UtcTimeEncoder Writer()
        {
            var cursor = EncodeHelpers.AllocateStruct(arena, segmentIndex, pointerIndex, 1, 0);
            return new UtcTimeEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UtcTimeEncoder Reader()
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            return new UtcTimeEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct CmeFuturesDefinitionRequestEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 1;

    public CmeFuturesDefinitionRequestEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public CmeFuturesDefinitionRequestKind which
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeFuturesDefinitionRequestKind)(ushort)((buffer[0] >> 0) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 0)) | ((ulong)(ushort)value << 0);
    }

    public CmeFuturesDefinitionSpecListAccessor Specs => new CmeFuturesDefinitionSpecListAccessor(arena, segmentIndex, offset + 0);

    public ReadOnlySpan<string> Symbols
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadList_Text(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteList_Text(arena, segmentIndex, offset + 0, value);
    }

    public bool AvailableOnly
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 16) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(1UL << 16)) | (value ? 1UL << 16 : 0UL);
    }


    public ref struct CmeFuturesDefinitionSpecListAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFuturesDefinitionSpecListAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Init(int count)
        {
            EncodeHelpers.AllocateList_Struct(arena, segmentIndex, pointerIndex, count, 1, 5);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFuturesDefinitionSpecEncoder GetElement(int index)
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            var elementCursor = EncodeHelpers.GetListElementCursor(arena, cursor.segmentIndex, cursor.structIndex, index);
            return new CmeFuturesDefinitionSpecEncoder(arena, elementCursor.segmentIndex, elementCursor.elementIndex);
        }
    }
}

public ref struct CmeFeedRequestSymbolAvailabilityEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 1;

    public CmeFeedRequestSymbolAvailabilityEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public CmeFeedRequestSymbolAvailabilityKind which
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeFeedRequestSymbolAvailabilityKind)(ushort)((buffer[0] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public AvailabilityAction Action
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (AvailabilityAction)(ushort)((buffer[0] >> 0) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 0)) | ((ulong)(ushort)value << 0);
    }

    public string Symbol
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 0, value);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 32) & 0xFFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 32)) | ((ulong)(uint)value << 32);
    }

}

public ref struct FeedApiRejectEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 1;

    public FeedApiRejectEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public FeedApiRejectReason ReasonCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (FeedApiRejectReason)(ushort)((buffer[0] >> 0) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 0)) | ((ulong)(ushort)value << 0);
    }

    public string ReasonText
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 0, value);
    }

}

public ref struct FeedApiLoginEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 0;
    private const int PointerWords = 3;

    public FeedApiLoginEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public string User
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 0, value);
    }

    public string Password
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }

    public FeedApiSetSymbolListStructAccessor SetSymbolList => new FeedApiSetSymbolListStructAccessor(arena, segmentIndex, offset + 2);


    public ref struct FeedApiSetSymbolListStructAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FeedApiSetSymbolListStructAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FeedApiSetSymbolListEncoder Writer()
        {
            var cursor = EncodeHelpers.AllocateStruct(arena, segmentIndex, pointerIndex, 1, 1);
            return new FeedApiSetSymbolListEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FeedApiSetSymbolListEncoder Reader()
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            return new FeedApiSetSymbolListEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct FeedApiLoginResponseEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 0;

    public FeedApiLoginResponseEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public FeedApiLoginResult Result
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (FeedApiLoginResult)(ushort)((buffer[0] >> 0) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 0)) | ((ulong)(ushort)value << 0);
    }

    public FeedApiSetSymbolListResult ListResult
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (FeedApiSetSymbolListResult)(ushort)((buffer[0] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public FeedApiEnvironment FeedEnv
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (FeedApiEnvironment)(ushort)((buffer[0] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

}

public ref struct FeedApiSetSymbolListEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 1;

    public FeedApiSetSymbolListEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public string ListName
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 0, value);
    }

    public bool CreateList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 0) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(1UL << 0)) | (value ? 1UL << 0 : 0UL);
    }

}

public ref struct FeedApiSetSymbolListResponseEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 0;

    public FeedApiSetSymbolListResponseEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public FeedApiSetSymbolListResult ListResult
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (FeedApiSetSymbolListResult)(ushort)((buffer[0] >> 0) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 0)) | ((ulong)(ushort)value << 0);
    }

}

public ref struct FeedApiGetSymbolListContentsEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 0;
    private const int PointerWords = 1;

    public FeedApiGetSymbolListContentsEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public string ListName
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 0, value);
    }

}

public ref struct FeedApiGetSymbolListContentsResponseEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 0;
    private const int PointerWords = 3;

    public FeedApiGetSymbolListContentsResponseEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public ReadOnlySpan<string> SymbolList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadList_Text(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteList_Text(arena, segmentIndex, offset + 0, value);
    }

    public ReadOnlySpan<int> SecurityIdList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadList_Primitive<int>(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteList_Primitive<int>(arena, segmentIndex, offset + 1, value);
    }

    public string ErrorText
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 2);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 2, value);
    }

}

