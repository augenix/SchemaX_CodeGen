using System.Runtime.CompilerServices;

namespace SchemaX_CodeGen.Generated.DataFeedApi;
public ref struct UtcTimeDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 0;

    public UtcTimeDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public long TimeNs
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (long)buffer[0];
    }

}

public ref struct CmeFeedManagerTimestampsDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 0;
    private const int PointerWords = 4;

    public CmeFeedManagerTimestampsDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public UtcTimeStructAccessor Exchange => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 0);

    public UtcTimeStructAccessor Sending => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 1);

    public UtcTimeStructAccessor Receipt => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 2);

    public UtcTimeStructAccessor Extract => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 3);


    public ref struct UtcTimeStructAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UtcTimeStructAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UtcTimeDecoder Reader()
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            return new UtcTimeDecoder(frame, meta, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct CmeFeedPriceLevelDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 2;
    private const int PointerWords = 0;

    public CmeFeedPriceLevelDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public uint OrderCnt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 0) & 0xFFFF);
    }

    public uint Quantity
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 32) & 0xFFFF);
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[1]);
    }

}

public ref struct CmeFeedUpdateGroupStatusDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 2;
    private const int PointerWords = 3;

    public CmeFeedUpdateGroupStatusDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public string GroupName
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 0);
    }

    public int MdpChannelId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 0) & 0xFFFF;
    }

    public ushort InstGroupNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[0] >> 32) & 0xFFFF);
    }

    public string AssetCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }

    public CmeFeedManagerTimestampsStructAccessor Timestamp => new CmeFeedManagerTimestampsStructAccessor(frame, meta, segmentIndex, offset + 2);

    public TradingStatus TradingStatus
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (TradingStatus)(ushort)((buffer[0] >> 48) & 0xFFFF);
    }

    public HaltReason HaltReason
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HaltReason)(ushort)((buffer[1] >> 0) & 0xFFFF);
    }

    public TradingEvent TradingEvent
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (TradingEvent)(ushort)((buffer[1] >> 16) & 0xFFFF);
    }


    public ref struct CmeFeedManagerTimestampsStructAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsStructAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsDecoder Reader()
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            return new CmeFeedManagerTimestampsDecoder(frame, meta, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct CmeFeedUpdateInstStatusDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 6;
    private const int PointerWords = 1;

    public CmeFeedUpdateInstStatusDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 0) & 0xFFFF;
    }

    public int MdpChannelId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 32) & 0xFFFF;
    }

    public ushort InstNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[1] >> 0) & 0xFFFF);
    }

    public CmeFeedManagerTimestampsStructAccessor Timestamp => new CmeFeedManagerTimestampsStructAccessor(frame, meta, segmentIndex, offset + 0);

    public TradingStatus TradingStatus
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (TradingStatus)(ushort)((buffer[1] >> 16) & 0xFFFF);
    }

    public HaltReason HaltReason
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HaltReason)(ushort)((buffer[1] >> 32) & 0xFFFF);
    }

    public TradingEvent TradingEvent
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (TradingEvent)(ushort)((buffer[1] >> 48) & 0xFFFF);
    }

    public bool DailyLimitPriceLbValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[2] >> 0) & 1UL) != 0;
    }

    public double DailyLimitPriceLb
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
    }

    public bool DailyLimitPriceUbValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[2] >> 1) & 1UL) != 0;
    }

    public double DailyLimitPriceUb
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[4]);
    }

    public bool MaxPriceVariationValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[2] >> 2) & 1UL) != 0;
    }

    public double MaxPriceVariation
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[5]);
    }


    public ref struct CmeFeedManagerTimestampsStructAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsStructAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsDecoder Reader()
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            return new CmeFeedManagerTimestampsDecoder(frame, meta, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct CmeFeedUpdateIndicativeOpeningDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 3;
    private const int PointerWords = 1;

    public CmeFeedUpdateIndicativeOpeningDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 0) & 0xFFFF;
    }

    public int MdpChannelId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 32) & 0xFFFF;
    }

    public ushort InstNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[1] >> 0) & 0xFFFF);
    }

    public CmeFeedManagerTimestampsStructAccessor Timestamp => new CmeFeedManagerTimestampsStructAccessor(frame, meta, segmentIndex, offset + 0);

    public uint Quantity
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[1] >> 32) & 0xFFFF);
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[2]);
    }


    public ref struct CmeFeedManagerTimestampsStructAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsStructAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsDecoder Reader()
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            return new CmeFeedManagerTimestampsDecoder(frame, meta, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct CmeFeedUpdateOpeningPriceDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 3;
    private const int PointerWords = 1;

    public CmeFeedUpdateOpeningPriceDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 0) & 0xFFFF;
    }

    public int MdpChannelId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 32) & 0xFFFF;
    }

    public ushort InstNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[1] >> 0) & 0xFFFF);
    }

    public CmeFeedManagerTimestampsStructAccessor Timestamp => new CmeFeedManagerTimestampsStructAccessor(frame, meta, segmentIndex, offset + 0);

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[2]);
    }


    public ref struct CmeFeedManagerTimestampsStructAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsStructAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsDecoder Reader()
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            return new CmeFeedManagerTimestampsDecoder(frame, meta, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct CmeFeedUpdateSettlementDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 4;
    private const int PointerWords = 3;

    public CmeFeedUpdateSettlementDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 0) & 0xFFFF;
    }

    public int MdpChannelId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 32) & 0xFFFF;
    }

    public ushort InstNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[1] >> 0) & 0xFFFF);
    }

    public CmeFeedManagerTimestampsStructAccessor Timestamp => new CmeFeedManagerTimestampsStructAccessor(frame, meta, segmentIndex, offset + 0);

    public bool PriceValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[1] >> 16) & 1UL) != 0;
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[2]);
    }

    public UtcTimeStructAccessor PriceTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 1);

    public bool PreliminaryPriceValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[1] >> 17) & 1UL) != 0;
    }

    public double PreliminaryPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
    }

    public UtcTimeStructAccessor PreliminaryPriceTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 2);


    public ref struct CmeFeedManagerTimestampsStructAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsStructAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsDecoder Reader()
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            return new CmeFeedManagerTimestampsDecoder(frame, meta, cursor.segmentIndex, cursor.structIndex);
        }
    }

    public ref struct UtcTimeStructAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UtcTimeStructAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UtcTimeDecoder Reader()
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            return new UtcTimeDecoder(frame, meta, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct CmeFeedUpdateTradeDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 4;
    private const int PointerWords = 1;

    public CmeFeedUpdateTradeDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 0) & 0xFFFF;
    }

    public int MdpChannelId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 32) & 0xFFFF;
    }

    public ushort InstNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[1] >> 0) & 0xFFFF);
    }

    public CmeFeedManagerTimestampsStructAccessor Timestamp => new CmeFeedManagerTimestampsStructAccessor(frame, meta, segmentIndex, offset + 0);

    public BookStatus BookStatus
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (BookStatus)(ushort)((buffer[1] >> 16) & 0xFFFF);
    }

    public AggressorSideKind AggressorSideKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (AggressorSideKind)(ushort)((buffer[1] >> 32) & 0xFFFF);
    }

    public uint OrderCnt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[2] >> 0) & 0xFFFF);
    }

    public uint Quantity
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[2] >> 32) & 0xFFFF);
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
    }


    public ref struct CmeFeedManagerTimestampsStructAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsStructAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsDecoder Reader()
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            return new CmeFeedManagerTimestampsDecoder(frame, meta, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct CmeFeedUpdateSideDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 3;
    private const int PointerWords = 2;

    public CmeFeedUpdateSideDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 0) & 0xFFFF;
    }

    public int MdpChannelId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 32) & 0xFFFF;
    }

    public ushort InstNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[1] >> 0) & 0xFFFF);
    }

    public CmeFeedManagerTimestampsStructAccessor Timestamp => new CmeFeedManagerTimestampsStructAccessor(frame, meta, segmentIndex, offset + 0);

    public BookStatus BookStatus
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (BookStatus)(ushort)((buffer[1] >> 16) & 0xFFFF);
    }

    public BookSideKind SideKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (BookSideKind)(ushort)((buffer[1] >> 32) & 0xFFFF);
    }

    public BookSideOrdersKind OrdersKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (BookSideOrdersKind)(ushort)((buffer[1] >> 48) & 0xFFFF);
    }

    public bool IsLastSideOfBook
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[2] >> 0) & 1UL) != 0;
    }

    public CmeFeedPriceLevelListAccessor Levels => new CmeFeedPriceLevelListAccessor(frame, meta, segmentIndex, offset + 1);


    public ref struct CmeFeedManagerTimestampsStructAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsStructAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsDecoder Reader()
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            return new CmeFeedManagerTimestampsDecoder(frame, meta, cursor.segmentIndex, cursor.structIndex);
        }
    }

    public ref struct CmeFeedPriceLevelListAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedPriceLevelListAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedPriceLevelDecoder GetElement(int index)
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            var elementCursor = DecodeHelpers.GetListElementCursor(frame, meta, cursor.segmentIndex, cursor.structIndex, index);
            return new CmeFeedPriceLevelDecoder(frame, meta, elementCursor.segmentIndex, elementCursor.elementIndex);
        }

        public int Count
        {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
                return DecodeHelpers.GetListLength(frame, meta, cursor.segmentIndex, cursor.structIndex);
            }
        }
    }
}

public ref struct CmeFeedUpdateLastMessageForEventDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 1;

    public CmeFeedUpdateLastMessageForEventDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public int MdpChannelId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 0) & 0xFFFF;
    }

    public CmeFeedManagerTimestampsStructAccessor Timestamp => new CmeFeedManagerTimestampsStructAccessor(frame, meta, segmentIndex, offset + 0);


    public ref struct CmeFeedManagerTimestampsStructAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsStructAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedManagerTimestampsDecoder Reader()
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            return new CmeFeedManagerTimestampsDecoder(frame, meta, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct CmeFeedUpdateFinishedAllDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 0;
    private const int PointerWords = 1;

    public CmeFeedUpdateFinishedAllDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 0);


    public ref struct UtcTimeStructAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UtcTimeStructAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UtcTimeDecoder Reader()
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            return new UtcTimeDecoder(frame, meta, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct CmeFeedTradeStatisticsDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 5;
    private const int PointerWords = 0;

    public CmeFeedTradeStatisticsDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public ushort InstNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[0] >> 0) & 0xFFFF);
    }

    public double HighPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[1]);
    }

    public double LowPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[2]);
    }

    public double LastPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
    }

    public ulong Volume
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[4];
    }

}

public ref struct CmeFeedInstrumentStateDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 8;

    public CmeFeedInstrumentStateDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public ushort InstNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[0] >> 0) & 0xFFFF);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 32) & 0xFFFF;
    }

    public CmeFeedUpdateInstStatusStructAccessor InstStatus => new CmeFeedUpdateInstStatusStructAccessor(frame, meta, segmentIndex, offset + 0);

    public CmeFeedUpdateTradeStructAccessor LastTrade => new CmeFeedUpdateTradeStructAccessor(frame, meta, segmentIndex, offset + 1);

    public CmeFeedUpdateOpeningPriceStructAccessor OpeningPrice => new CmeFeedUpdateOpeningPriceStructAccessor(frame, meta, segmentIndex, offset + 2);

    public CmeFeedUpdateSettlementStructAccessor Settlement => new CmeFeedUpdateSettlementStructAccessor(frame, meta, segmentIndex, offset + 3);

    public CmeFeedUpdateSideStructAccessor BidBook => new CmeFeedUpdateSideStructAccessor(frame, meta, segmentIndex, offset + 4);

    public CmeFeedUpdateSideStructAccessor ImpBidBook => new CmeFeedUpdateSideStructAccessor(frame, meta, segmentIndex, offset + 5);

    public CmeFeedUpdateSideStructAccessor AskBook => new CmeFeedUpdateSideStructAccessor(frame, meta, segmentIndex, offset + 6);

    public CmeFeedUpdateSideStructAccessor ImpAskBook => new CmeFeedUpdateSideStructAccessor(frame, meta, segmentIndex, offset + 7);

    public bool InstStatusValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 16) & 1UL) != 0;
    }

    public bool LastTradeValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 17) & 1UL) != 0;
    }

    public bool OpeningPriceValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 18) & 1UL) != 0;
    }

    public bool SettlementValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 19) & 1UL) != 0;
    }

    public bool BidBookValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 20) & 1UL) != 0;
    }

    public bool ImpBidBookValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 21) & 1UL) != 0;
    }

    public bool AskBookValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 22) & 1UL) != 0;
    }

    public bool ImpAskBookValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 23) & 1UL) != 0;
    }


    public ref struct CmeFeedUpdateInstStatusStructAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedUpdateInstStatusStructAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedUpdateInstStatusDecoder Reader()
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            return new CmeFeedUpdateInstStatusDecoder(frame, meta, cursor.segmentIndex, cursor.structIndex);
        }
    }

    public ref struct CmeFeedUpdateTradeStructAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedUpdateTradeStructAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedUpdateTradeDecoder Reader()
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            return new CmeFeedUpdateTradeDecoder(frame, meta, cursor.segmentIndex, cursor.structIndex);
        }
    }

    public ref struct CmeFeedUpdateOpeningPriceStructAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedUpdateOpeningPriceStructAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedUpdateOpeningPriceDecoder Reader()
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            return new CmeFeedUpdateOpeningPriceDecoder(frame, meta, cursor.segmentIndex, cursor.structIndex);
        }
    }

    public ref struct CmeFeedUpdateSettlementStructAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedUpdateSettlementStructAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedUpdateSettlementDecoder Reader()
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            return new CmeFeedUpdateSettlementDecoder(frame, meta, cursor.segmentIndex, cursor.structIndex);
        }
    }

    public ref struct CmeFeedUpdateSideStructAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedUpdateSideStructAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFeedUpdateSideDecoder Reader()
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            return new CmeFeedUpdateSideDecoder(frame, meta, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct CmeLegDefinitionDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 0;

    public CmeLegDefinitionDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 0) & 0xFFFF;
    }

    public int Ratio
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 32) & 0xFFFF;
    }

}

public ref struct CmeFuturesDefinitionDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 13;
    private const int PointerWords = 12;

    public CmeFuturesDefinitionDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public string Symbol
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 0);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 0) & 0xFFFF;
    }

    public int MarketSegmentGatewayId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 32) & 0xFFFF;
    }

    public int MdpChannelId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[1] >> 0) & 0xFFFF;
    }

    public string SecurityGroupCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }

    public CmeAssetKind AssetKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeAssetKind)(ushort)((buffer[1] >> 32) & 0xFFFF);
    }

    public string AssetCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 2);
    }

    public string CfiCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 3);
    }

    public CmeSecuritySubtype SecuritySubtype
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeSecuritySubtype)(ushort)((buffer[1] >> 48) & 0xFFFF);
    }

    public string SecuritySubtypeCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 4);
    }

    public string MaturityMonthyear
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 5);
    }

    public CmeAssetEquivalenceKind EquivalenceKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeAssetEquivalenceKind)(ushort)((buffer[2] >> 0) & 0xFFFF);
    }

    public CmeAssetKind EquivalentAssetKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeAssetKind)(ushort)((buffer[2] >> 16) & 0xFFFF);
    }

    public CmePriceValueKind PriceValueKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmePriceValueKind)(ushort)((buffer[2] >> 32) & 0xFFFF);
    }

    public double TruePriceOffset
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
    }

    public double PriceToCurrency
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[4]);
    }

    public double MinPriceIncrement
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[5]);
    }

    public string CurrencyCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 6);
    }

    public string SettleCurrencyCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 7);
    }

    public string UnitOfMeasureCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 8);
    }

    public double UnitOfMeasureQuantity
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[6]);
    }

    public bool LimitPricesValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[2] >> 48) & 1UL) != 0;
    }

    public double HighLimitPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[7]);
    }

    public double LowLimitPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[8]);
    }

    public bool MaxPriceVariationValid
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[2] >> 49) & 1UL) != 0;
    }

    public double MaxPriceVariation
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[9]);
    }

    public int BookDepth
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[10] >> 0) & 0xFFFF;
    }

    public bool HasImpliedBook
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[2] >> 50) & 1UL) != 0;
    }

    public CmeMatchAlgorithm MatchAlgorithm
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeMatchAlgorithm)(ushort)((buffer[10] >> 32) & 0xFFFF);
    }

    public int MinTradeVolume
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[11] >> 0) & 0xFFFF;
    }

    public int MaxTradeVolume
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[11] >> 32) & 0xFFFF;
    }

    public bool RelativeToPreviousSettlement
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[2] >> 51) & 1UL) != 0;
    }

    public UtcTimeStructAccessor ActivationTime => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 9);

    public UtcTimeStructAccessor LastEligibleTradeTime => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 10);

    public CmeLegDefinitionListAccessor Legs => new CmeLegDefinitionListAccessor(frame, meta, segmentIndex, offset + 11);

    public bool IsFeedAvailable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[2] >> 52) & 1UL) != 0;
    }

    public ushort InstNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[10] >> 48) & 0xFFFF);
    }

    public ushort GroupNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[12] >> 0) & 0xFFFF);
    }


    public ref struct UtcTimeStructAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UtcTimeStructAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UtcTimeDecoder Reader()
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            return new UtcTimeDecoder(frame, meta, cursor.segmentIndex, cursor.structIndex);
        }
    }

    public ref struct CmeLegDefinitionListAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeLegDefinitionListAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeLegDefinitionDecoder GetElement(int index)
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            var elementCursor = DecodeHelpers.GetListElementCursor(frame, meta, cursor.segmentIndex, cursor.structIndex, index);
            return new CmeLegDefinitionDecoder(frame, meta, elementCursor.segmentIndex, elementCursor.elementIndex);
        }

        public int Count
        {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
                return DecodeHelpers.GetListLength(frame, meta, cursor.segmentIndex, cursor.structIndex);
            }
        }
    }
}

public ref struct CmeFuturesDefinitionResponseDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 0;
    private const int PointerWords = 2;

    public CmeFuturesDefinitionResponseDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public CmeFuturesDefinitionListAccessor Definitions => new CmeFuturesDefinitionListAccessor(frame, meta, segmentIndex, offset + 0);

    public string Error
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }


    public ref struct CmeFuturesDefinitionListAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFuturesDefinitionListAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFuturesDefinitionDecoder GetElement(int index)
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            var elementCursor = DecodeHelpers.GetListElementCursor(frame, meta, cursor.segmentIndex, cursor.structIndex, index);
            return new CmeFuturesDefinitionDecoder(frame, meta, elementCursor.segmentIndex, elementCursor.elementIndex);
        }

        public int Count
        {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
                return DecodeHelpers.GetListLength(frame, meta, cursor.segmentIndex, cursor.structIndex);
            }
        }
    }
}

public ref struct CmeFeedRequestSymbolAvailabilityResponseDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 2;
    private const int PointerWords = 2;

    public CmeFeedRequestSymbolAvailabilityResponseDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public bool Success
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 0) & 1UL) != 0;
    }

    public AvailabilityAction Action
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (AvailabilityAction)(ushort)((buffer[0] >> 16) & 0xFFFF);
    }

    public ushort InstNum
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[0] >> 32) & 0xFFFF);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[1] >> 0) & 0xFFFF;
    }

    public string Symbol
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 0);
    }

    public string Error
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }

}

public ref struct CmeFeedClientFirehoseDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 0;

    public CmeFeedClientFirehoseDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public FirehoseAction Action
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (FirehoseAction)(ushort)((buffer[0] >> 0) & 0xFFFF);
    }

}

public ref struct CmeFeedClientSubscribeDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 2;

    public CmeFeedClientSubscribeDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public CmeFeedClientSubscribeKind which
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeFeedClientSubscribeKind)(ushort)((buffer[0] >> 16) & 0xFFFF);
    }

    public SubscriptionAction Action
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (SubscriptionAction)(ushort)((buffer[0] >> 0) & 0xFFFF);
    }

    public ReadOnlySpan<int> SecurityIdList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadList_Primitive<int>(frame, meta, segmentIndex, offset + 0);
    }

    public ReadOnlySpan<ushort> InstList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadList_Primitive<ushort>(frame, meta, segmentIndex, offset + 0);
    }

    public BookSideOrdersKind OrdersKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (BookSideOrdersKind)(ushort)((buffer[0] >> 32) & 0xFFFF);
    }

    public ReadOnlySpan<ushort> DepthList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadList_Primitive<ushort>(frame, meta, segmentIndex, offset + 1);
    }

}

public ref struct CmeFeedClientSubscribeResponseDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 1;

    public CmeFeedClientSubscribeResponseDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public CmeFeedClientSubscribeResponseKind which
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeFeedClientSubscribeResponseKind)(ushort)((buffer[0] >> 16) & 0xFFFF);
    }

    public CmeFeedClientSubscribeResult Result
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeFeedClientSubscribeResult)(ushort)((buffer[0] >> 0) & 0xFFFF);
    }

    public ReadOnlySpan<int> BadSecurityIdList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadList_Primitive<int>(frame, meta, segmentIndex, offset + 0);
    }

    public ReadOnlySpan<ushort> BadInstList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadList_Primitive<ushort>(frame, meta, segmentIndex, offset + 0);
    }

}

public ref struct CmeFuturesDefinitionSpecDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 5;

    public CmeFuturesDefinitionSpecDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public CmeAssetKind AssetKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeAssetKind)(ushort)((buffer[0] >> 0) & 0xFFFF);
    }

    public CmeSecuritySubtype SecuritySubtype
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeSecuritySubtype)(ushort)((buffer[0] >> 16) & 0xFFFF);
    }

    public string SecurityGroupCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 0);
    }

    public UtcTimeStructAccessor ActivationTimeLb => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 1);

    public UtcTimeStructAccessor ActivationTimeUb => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 2);

    public UtcTimeStructAccessor LastEligibleTradeTimeLb => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 3);

    public UtcTimeStructAccessor LastEligibleTradeTimeUb => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 4);


    public ref struct UtcTimeStructAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UtcTimeStructAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UtcTimeDecoder Reader()
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            return new UtcTimeDecoder(frame, meta, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct CmeFuturesDefinitionRequestDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 1;

    public CmeFuturesDefinitionRequestDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public CmeFuturesDefinitionRequestKind which
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeFuturesDefinitionRequestKind)(ushort)((buffer[0] >> 0) & 0xFFFF);
    }

    public CmeFuturesDefinitionSpecListAccessor Specs => new CmeFuturesDefinitionSpecListAccessor(frame, meta, segmentIndex, offset + 0);

    public ReadOnlySpan<string> Symbols
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadList_Text(frame, meta, segmentIndex, offset + 0);
    }

    public bool AvailableOnly
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 16) & 1UL) != 0;
    }


    public ref struct CmeFuturesDefinitionSpecListAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFuturesDefinitionSpecListAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CmeFuturesDefinitionSpecDecoder GetElement(int index)
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            var elementCursor = DecodeHelpers.GetListElementCursor(frame, meta, cursor.segmentIndex, cursor.structIndex, index);
            return new CmeFuturesDefinitionSpecDecoder(frame, meta, elementCursor.segmentIndex, elementCursor.elementIndex);
        }

        public int Count
        {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
                return DecodeHelpers.GetListLength(frame, meta, cursor.segmentIndex, cursor.structIndex);
            }
        }
    }
}

public ref struct CmeFeedRequestSymbolAvailabilityDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 1;

    public CmeFeedRequestSymbolAvailabilityDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public CmeFeedRequestSymbolAvailabilityKind which
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeFeedRequestSymbolAvailabilityKind)(ushort)((buffer[0] >> 16) & 0xFFFF);
    }

    public AvailabilityAction Action
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (AvailabilityAction)(ushort)((buffer[0] >> 0) & 0xFFFF);
    }

    public string Symbol
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 0);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 32) & 0xFFFF;
    }

}

public ref struct FeedApiRejectDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 1;

    public FeedApiRejectDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public FeedApiRejectReason ReasonCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (FeedApiRejectReason)(ushort)((buffer[0] >> 0) & 0xFFFF);
    }

    public string ReasonText
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 0);
    }

}

public ref struct FeedApiLoginDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 0;
    private const int PointerWords = 3;

    public FeedApiLoginDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public string User
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 0);
    }

    public string Password
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }

    public FeedApiSetSymbolListStructAccessor SetSymbolList => new FeedApiSetSymbolListStructAccessor(frame, meta, segmentIndex, offset + 2);


    public ref struct FeedApiSetSymbolListStructAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FeedApiSetSymbolListStructAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FeedApiSetSymbolListDecoder Reader()
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            return new FeedApiSetSymbolListDecoder(frame, meta, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct FeedApiLoginResponseDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 0;

    public FeedApiLoginResponseDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public FeedApiLoginResult Result
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (FeedApiLoginResult)(ushort)((buffer[0] >> 0) & 0xFFFF);
    }

    public FeedApiSetSymbolListResult ListResult
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (FeedApiSetSymbolListResult)(ushort)((buffer[0] >> 16) & 0xFFFF);
    }

    public FeedApiEnvironment FeedEnv
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (FeedApiEnvironment)(ushort)((buffer[0] >> 32) & 0xFFFF);
    }

}

public ref struct FeedApiSetSymbolListDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 1;

    public FeedApiSetSymbolListDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public string ListName
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 0);
    }

    public bool CreateList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 0) & 1UL) != 0;
    }

}

public ref struct FeedApiSetSymbolListResponseDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 0;

    public FeedApiSetSymbolListResponseDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public FeedApiSetSymbolListResult ListResult
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (FeedApiSetSymbolListResult)(ushort)((buffer[0] >> 0) & 0xFFFF);
    }

}

public ref struct FeedApiGetSymbolListContentsDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 0;
    private const int PointerWords = 1;

    public FeedApiGetSymbolListContentsDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public string ListName
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 0);
    }

}

public ref struct FeedApiGetSymbolListContentsResponseDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 0;
    private const int PointerWords = 3;

    public FeedApiGetSymbolListContentsResponseDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public ReadOnlySpan<string> SymbolList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadList_Text(frame, meta, segmentIndex, offset + 0);
    }

    public ReadOnlySpan<int> SecurityIdList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadList_Primitive<int>(frame, meta, segmentIndex, offset + 1);
    }

    public string ErrorText
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 2);
    }

}

