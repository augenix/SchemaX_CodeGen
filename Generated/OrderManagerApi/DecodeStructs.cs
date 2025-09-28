using System.Runtime.CompilerServices;

namespace SchemaX_CodeGen.Generated.OrderManagerApi;
public ref struct OrderRequestNewOrderDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 8;
    private const int PointerWords = 4;

    public OrderRequestNewOrderDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)((buffer[0] >> 0) & 0xFFFF);
    }

    public OrderTimeInForce TimeInForce
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderTimeInForce)(ushort)((buffer[0] >> 16) & 0xFFFF);
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[1]);
    }

    public uint OrderQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 32) & 0xFFFF);
    }

    public double StopPx
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[2]);
    }

    public uint MinQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[3] >> 0) & 0xFFFF);
    }

    public uint DisplayQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[3] >> 32) & 0xFFFF);
    }

    public UtcTimeStructAccessor ExpireDate => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 0);

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[4];
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[5];
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[6] >> 0) & 0xFFFF;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[6] >> 32) & 0xFFFF);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[7];
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 2);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[6] >> 48) & 1UL) != 0;
    }

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 3);


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

public ref struct OrderRequestCancelReplaceDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 9;
    private const int PointerWords = 4;

    public OrderRequestCancelReplaceDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[0];
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)((buffer[1] >> 0) & 0xFFFF);
    }

    public OrderTimeInForce TimeInForce
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderTimeInForce)(ushort)((buffer[1] >> 16) & 0xFFFF);
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[2]);
    }

    public uint OrderQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[1] >> 32) & 0xFFFF);
    }

    public double StopPx
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
    }

    public uint MinQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[4] >> 0) & 0xFFFF);
    }

    public uint DisplayQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[4] >> 32) & 0xFFFF);
    }

    public UtcTimeStructAccessor ExpireDate => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 0);

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[5];
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[6];
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[7] >> 0) & 0xFFFF;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[7] >> 32) & 0xFFFF);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[8];
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 2);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[7] >> 48) & 1UL) != 0;
    }

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 3);


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

public ref struct OrderRequestCancelDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 5;
    private const int PointerWords = 3;

    public OrderRequestCancelDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[0];
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[3] >> 0) & 0xFFFF;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[3] >> 32) & 0xFFFF);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[4];
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 0);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[3] >> 48) & 1UL) != 0;
    }

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 2);


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

public ref struct OrderRequestStatusDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 4;
    private const int PointerWords = 3;

    public OrderRequestStatusDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[0];
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 0);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[3] >> 0) & 1UL) != 0;
    }

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 2);


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

public ref struct OrderRequestMassStatusDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 4;
    private const int PointerWords = 4;

    public OrderRequestMassStatusDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[0];
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[1] >> 0) & 0xFFFF;
    }

    public MassActionScopeKind MassStatusType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (MassActionScopeKind)(ushort)((buffer[1] >> 32) & 0xFFFF);
    }

    public MassStatusRequestKind OrdStatusType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (MassStatusRequestKind)(ushort)((buffer[1] >> 48) & 0xFFFF);
    }

    public string SecurityGroup
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 0);
    }

    public byte MarketSegmentId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[2] >> 0) & 0xFF);
    }

    public OrderTimeInForce TimeInForce
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderTimeInForce)(ushort)((buffer[2] >> 16) & 0xFFFF);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[3];
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 2);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[2] >> 8) & 1UL) != 0;
    }

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 3);


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

public ref struct OrderRequestMassActionDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 5;
    private const int PointerWords = 4;

    public OrderRequestMassActionDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public MassActionScopeKind MassActionScope
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (MassActionScopeKind)(ushort)((buffer[0] >> 0) & 0xFFFF);
    }

    public string SecurityGroup
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 0);
    }

    public byte MarketSegmentId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[0] >> 16) & 0xFF);
    }

    public MassStatusRequestKind CancelReqType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (MassStatusRequestKind)(ushort)((buffer[0] >> 32) & 0xFFFF);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)((buffer[0] >> 48) & 0xFFFF);
    }

    public OrderTimeInForce TimeInForce
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderTimeInForce)(ushort)((buffer[1] >> 0) & 0xFFFF);
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[3];
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[1] >> 32) & 0xFFFF;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[1] >> 16) & 0xFFFF);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[4];
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 2);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 24) & 1UL) != 0;
    }

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 3);


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

public ref struct OrderRequestPartyDetailsDefinitionDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 3;
    private const int PointerWords = 2;

    public OrderRequestPartyDetailsDefinitionDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[0];
    }

    public ulong SelfMatchPreventionId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
    }

    public OrderSelfMatchInst SelfMatchPreventionInst
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSelfMatchInst)(ushort)((buffer[2] >> 0) & 0xFFFF);
    }

    public byte NumPartyDetails
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[2] >> 16) & 0xFF);
    }

    public ReadOnlySpan<OrderPartyDetailsRole> PartyDetailsRole
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadList_Primitive<OrderPartyDetailsRole>(frame, meta, segmentIndex, offset + 0);
    }

    public ReadOnlySpan<string> PartyDetailsId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadList_Text(frame, meta, segmentIndex, offset + 1);
    }

}

public ref struct OrderRequestPartyDetailsListDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 2;
    private const int PointerWords = 2;

    public OrderRequestPartyDetailsListDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[0];
    }

    public bool IsReqAllIds
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[1] >> 0) & 1UL) != 0;
    }

    public string ReqPartyId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 0);
    }

    public byte NumPartyIds
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[1] >> 8) & 0xFF);
    }

    public ReadOnlySpan<ulong> PartyIds
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadList_Primitive<ulong>(frame, meta, segmentIndex, offset + 1);
    }

}

public ref struct OrderManagerCommandDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 0;

    public OrderManagerCommandDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public CmdKind Cmd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmdKind)(ushort)((buffer[0] >> 0) & 0xFFFF);
    }

}

public ref struct OrderManagerCommandAckAccountEventsDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 1;

    public OrderManagerCommandAckAccountEventsDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public string Account
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 0);
    }

    public long AcknowledgementTimestampNs
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (long)buffer[0];
    }

}

public ref struct OrderManagerCommandSetRiskLimitDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 0;
    private const int PointerWords = 1;

    public OrderManagerCommandSetRiskLimitDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public RiskAccountingLimitStructAccessor RiskLimit => new RiskAccountingLimitStructAccessor(frame, meta, segmentIndex, offset + 0);


    public ref struct RiskAccountingLimitStructAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RiskAccountingLimitStructAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RiskAccountingLimitDecoder Reader()
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            return new RiskAccountingLimitDecoder(frame, meta, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct RiskAccountingLimitDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 1;

    public RiskAccountingLimitDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public string Account
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 0);
    }

    public double UnseenPnlLossUb
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[0]);
    }

}

public ref struct OrderManagerCommandLoginDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 3;

    public OrderManagerCommandLoginDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public string UserName
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 0);
    }

    public string ConfigName
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }

    public string Password
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 2);
    }

    public int ServerPingIntervalMs
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] >> 0) & 0xFFFF;
    }

}

public ref struct OrderManagerCommandPingDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 0;

    public OrderManagerCommandPingDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public long TimestampNs
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (long)buffer[0];
    }

}

public ref struct OrderReportBusinessRejectDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 3;
    private const int PointerWords = 7;

    public OrderReportBusinessRejectDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public ushort RejectReason
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[0] >> 0) & 0xFFFF);
    }

    public ushort RefTagId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[0] >> 16) & 0xFFFF);
    }

    public OrderMsgTypeKind RefMsgType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderMsgTypeKind)(ushort)((buffer[0] >> 32) & 0xFFFF);
    }

    public string RejectDescription
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 0);
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 2);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 48) & 1UL) != 0;
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[0] >> 56) & 0xFF);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 3);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 4);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 6);


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

public ref struct OrderReportExecRptNewOrderDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 10;
    private const int PointerWords = 8;

    public OrderReportExecRptNewOrderDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[0];
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[1]);
    }

    public uint OrderQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[2] >> 0) & 0xFFFF);
    }

    public double StopPx
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
    }

    public uint MinQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[2] >> 32) & 0xFFFF);
    }

    public uint CumQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[4] >> 0) & 0xFFFF);
    }

    public uint DisplayQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[4] >> 32) & 0xFFFF);
    }

    public UtcTimeStructAccessor ExpireDate => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 0);

    public OrderTimeInForce TimeInForce
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderTimeInForce)(ushort)((buffer[5] >> 0) & 0xFFFF);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[5] >> 32) & 0xFFFF;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[5] >> 16) & 0xFFFF);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)((buffer[6] >> 0) & 0xFFFF);
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[7];
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[8];
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 2);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 3);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[6] >> 16) & 1UL) != 0;
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[9];
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[6] >> 24) & 0xFF);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 4);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 7);


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

public ref struct OrderReportExecRptModifyDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 10;
    private const int PointerWords = 8;

    public OrderReportExecRptModifyDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public uint LeavesQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 0) & 0xFFFF);
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[2]);
    }

    public uint OrderQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 32) & 0xFFFF);
    }

    public double StopPx
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
    }

    public uint MinQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[4] >> 0) & 0xFFFF);
    }

    public uint CumQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[4] >> 32) & 0xFFFF);
    }

    public uint DisplayQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[5] >> 0) & 0xFFFF);
    }

    public UtcTimeStructAccessor ExpireDate => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 0);

    public OrderTimeInForce TimeInForce
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderTimeInForce)(ushort)((buffer[5] >> 32) & 0xFFFF);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[6] >> 0) & 0xFFFF;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[5] >> 48) & 0xFFFF);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)((buffer[6] >> 32) & 0xFFFF);
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[7];
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[8];
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 2);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 3);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[6] >> 48) & 1UL) != 0;
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[9];
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[6] >> 56) & 0xFF);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 4);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 7);


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

public ref struct OrderReportExecRptCancelDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 10;
    private const int PointerWords = 8;

    public OrderReportExecRptCancelDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public CancelReason CancelReason
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CancelReason)(ushort)((buffer[0] >> 0) & 0xFFFF);
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[2]);
    }

    public uint OrderQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 32) & 0xFFFF);
    }

    public double StopPx
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
    }

    public uint MinQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[4] >> 0) & 0xFFFF);
    }

    public uint CumQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[4] >> 32) & 0xFFFF);
    }

    public uint DisplayQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[5] >> 0) & 0xFFFF);
    }

    public UtcTimeStructAccessor ExpireDate => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 0);

    public OrderTimeInForce TimeInForce
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderTimeInForce)(ushort)((buffer[0] >> 16) & 0xFFFF);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[5] >> 32) & 0xFFFF;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[6] >> 0) & 0xFFFF);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)((buffer[6] >> 16) & 0xFFFF);
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[7];
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[8];
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 2);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 3);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[6] >> 32) & 1UL) != 0;
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[9];
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[6] >> 40) & 0xFF);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 4);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 7);


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

public ref struct OrderReportExecRptStatusDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 12;
    private const int PointerWords = 9;

    public OrderReportExecRptStatusDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public ExecRptStatus OrdStatus
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (ExecRptStatus)(ushort)((buffer[0] >> 0) & 0xFFFF);
    }

    public uint LeavesQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 32) & 0xFFFF);
    }

    public string RejectDescription
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 0);
    }

    public bool IsLastStatusRequested
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 16) & 1UL) != 0;
    }

    public ulong StatusReqId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
    }

    public uint OrderQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[4] >> 0) & 0xFFFF);
    }

    public double StopPx
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[5]);
    }

    public uint MinQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[4] >> 32) & 0xFFFF);
    }

    public uint CumQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[6] >> 0) & 0xFFFF);
    }

    public uint DisplayQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[6] >> 32) & 0xFFFF);
    }

    public UtcTimeStructAccessor ExpireDate => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 1);

    public OrderTimeInForce TimeInForce
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderTimeInForce)(ushort)((buffer[7] >> 0) & 0xFFFF);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[7] >> 32) & 0xFFFF;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[7] >> 16) & 0xFFFF);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)((buffer[8] >> 0) & 0xFFFF);
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 2);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[9];
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[10];
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 3);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 4);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 17) & 1UL) != 0;
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[11];
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[0] >> 24) & 0xFF);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 5);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 7);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 8);


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

public ref struct OrderReportExecRptTradeOutrightDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 11;
    private const int PointerWords = 8;

    public OrderReportExecRptTradeOutrightDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public OrderFillStatus FillStatus
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderFillStatus)(ushort)((buffer[0] >> 0) & 0xFFFF);
    }

    public bool IsAggressor
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 16) & 1UL) != 0;
    }

    public uint LeavesQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 32) & 0xFFFF);
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[2]);
    }

    public uint OrderQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[3] >> 0) & 0xFFFF);
    }

    public uint CumQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[3] >> 32) & 0xFFFF);
    }

    public double FillPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[4]);
    }

    public uint FillQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[5] >> 0) & 0xFFFF);
    }

    public ulong SecurityExecId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[6];
    }

    public UtcTimeStructAccessor TradeDate => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 0);

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[5] >> 32) & 0xFFFF;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[7] >> 0) & 0xFFFF);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)((buffer[7] >> 16) & 0xFFFF);
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[8];
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[9];
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 2);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 3);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 17) & 1UL) != 0;
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[10];
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[0] >> 24) & 0xFF);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 4);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 7);


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

public ref struct OrderReportExecRptTradeSpreadDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 11;
    private const int PointerWords = 8;

    public OrderReportExecRptTradeSpreadDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public byte NumLegFills
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[0] >> 0) & 0xFF);
    }

    public OrderFillStatus FillStatus
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderFillStatus)(ushort)((buffer[0] >> 16) & 0xFFFF);
    }

    public bool IsAggressor
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 8) & 1UL) != 0;
    }

    public uint LeavesQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 32) & 0xFFFF);
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[2]);
    }

    public uint OrderQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[3] >> 0) & 0xFFFF);
    }

    public uint CumQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[3] >> 32) & 0xFFFF);
    }

    public double FillPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[4]);
    }

    public uint FillQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[5] >> 0) & 0xFFFF);
    }

    public ulong SecurityExecId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[6];
    }

    public UtcTimeStructAccessor TradeDate => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 0);

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[5] >> 32) & 0xFFFF;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[7] >> 0) & 0xFFFF);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)((buffer[7] >> 16) & 0xFFFF);
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[8];
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[9];
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 2);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 3);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 9) & 1UL) != 0;
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[10];
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[7] >> 32) & 0xFF);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 4);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 7);


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

public ref struct OrderReportExecRptTradeSpreadLegDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 8;
    private const int PointerWords = 8;

    public OrderReportExecRptTradeSpreadLegDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public uint CumQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 0) & 0xFFFF);
    }

    public OrderFillStatus FillStatus
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderFillStatus)(ushort)((buffer[0] >> 32) & 0xFFFF);
    }

    public double FillPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[1]);
    }

    public uint FillQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[2] >> 0) & 0xFFFF);
    }

    public ulong SecurityExecId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[3];
    }

    public UtcTimeStructAccessor TradeDate => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 0);

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[2] >> 32) & 0xFFFF;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[0] >> 48) & 0xFFFF);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)((buffer[4] >> 0) & 0xFFFF);
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[5];
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[6];
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 2);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 3);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[4] >> 16) & 1UL) != 0;
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[7];
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[4] >> 24) & 0xFF);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 4);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 7);


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

public ref struct OrderReportExecRptEliminationDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 10;
    private const int PointerWords = 8;

    public OrderReportExecRptEliminationDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[0];
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[1]);
    }

    public uint OrderQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[2] >> 0) & 0xFFFF);
    }

    public double StopPx
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
    }

    public uint MinQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[2] >> 32) & 0xFFFF);
    }

    public uint CumQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[4] >> 0) & 0xFFFF);
    }

    public uint DisplayQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[4] >> 32) & 0xFFFF);
    }

    public UtcTimeStructAccessor ExpireDate => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 0);

    public OrderTimeInForce TimeInForce
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderTimeInForce)(ushort)((buffer[5] >> 0) & 0xFFFF);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[5] >> 32) & 0xFFFF;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[5] >> 16) & 0xFFFF);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)((buffer[6] >> 0) & 0xFFFF);
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[7];
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[8];
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 2);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 3);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[6] >> 16) & 1UL) != 0;
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[9];
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[6] >> 24) & 0xFF);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 4);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 7);


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

public ref struct OrderReportExecRptRejectDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 11;
    private const int PointerWords = 9;

    public OrderReportExecRptRejectDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public OrderRejectionKind RejectKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderRejectionKind)(ushort)((buffer[0] >> 0) & 0xFFFF);
    }

    public ushort RejectCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[0] >> 16) & 0xFFFF);
    }

    public string RejectDescription
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 0);
    }

    public double RejectingPriceBand
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[1]);
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
    }

    public uint OrderQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 32) & 0xFFFF);
    }

    public double StopPx
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[4]);
    }

    public uint MinQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[5] >> 0) & 0xFFFF);
    }

    public uint CumQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[5] >> 32) & 0xFFFF);
    }

    public uint DisplayQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[6] >> 0) & 0xFFFF);
    }

    public UtcTimeStructAccessor ExpireDate => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 1);

    public OrderTimeInForce TimeInForce
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderTimeInForce)(ushort)((buffer[6] >> 32) & 0xFFFF);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[7] >> 0) & 0xFFFF;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[6] >> 48) & 0xFFFF);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)((buffer[7] >> 32) & 0xFFFF);
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 2);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[8];
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[9];
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 3);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 4);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[7] >> 48) & 1UL) != 0;
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[10];
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[7] >> 56) & 0xFF);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 5);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 7);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 8);


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

public ref struct OrderReportExecRptTradeAddendumOutrightDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 7;
    private const int PointerWords = 8;

    public OrderReportExecRptTradeAddendumOutrightDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public AddendumKind AddendumKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (AddendumKind)(ushort)((buffer[0] >> 0) & 0xFFFF);
    }

    public double FillPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[1]);
    }

    public uint FillQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 32) & 0xFFFF);
    }

    public ulong SecurityExecId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
    }

    public UtcTimeStructAccessor TradeDate => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 0);

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[3] >> 0) & 0xFFFF;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[0] >> 16) & 0xFFFF);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)((buffer[3] >> 32) & 0xFFFF);
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[4];
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[5];
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 2);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 3);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[3] >> 48) & 1UL) != 0;
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[6];
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[3] >> 56) & 0xFF);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 4);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 7);


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

public ref struct OrderReportExecRptTradeAddendumSpreadDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 8;
    private const int PointerWords = 8;

    public OrderReportExecRptTradeAddendumSpreadDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public byte NumLegFills
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[0] >> 0) & 0xFF);
    }

    public AddendumKind AddendumKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (AddendumKind)(ushort)((buffer[0] >> 16) & 0xFFFF);
    }

    public double FillPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[1]);
    }

    public uint FillQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 32) & 0xFFFF);
    }

    public ulong SecurityExecId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
    }

    public UtcTimeStructAccessor TradeDate => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 0);

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[3] >> 0) & 0xFFFF;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[3] >> 32) & 0xFFFF);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)((buffer[3] >> 48) & 0xFFFF);
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[4];
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[5];
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 2);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 3);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 8) & 1UL) != 0;
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[6];
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[7] >> 0) & 0xFF);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 4);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 7);


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

public ref struct OrderReportExecRptTradeAddendumSpreadLegDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 7;
    private const int PointerWords = 8;

    public OrderReportExecRptTradeAddendumSpreadLegDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public AddendumKind AddendumKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (AddendumKind)(ushort)((buffer[0] >> 0) & 0xFFFF);
    }

    public double FillPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[1]);
    }

    public uint FillQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 32) & 0xFFFF);
    }

    public ulong SecurityExecId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
    }

    public UtcTimeStructAccessor TradeDate => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 0);

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[3] >> 0) & 0xFFFF;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[0] >> 16) & 0xFFFF);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)((buffer[3] >> 32) & 0xFFFF);
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[4];
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[5];
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 2);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 3);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[3] >> 48) & 1UL) != 0;
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[6];
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[3] >> 56) & 0xFF);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 4);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 7);


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

public ref struct OrderReportOrderCancelRejectDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 5;
    private const int PointerWords = 8;

    public OrderReportOrderCancelRejectDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[0];
    }

    public OrderRejectionKind RejectKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderRejectionKind)(ushort)((buffer[1] >> 0) & 0xFFFF);
    }

    public ushort RejectCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[1] >> 16) & 0xFFFF);
    }

    public string RejectDescription
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 0);
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[3];
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 2);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 3);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[1] >> 32) & 1UL) != 0;
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[4];
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[1] >> 40) & 0xFF);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 4);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 7);


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

public ref struct OrderReportOrderCancelModifyRejectDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 6;
    private const int PointerWords = 8;

    public OrderReportOrderCancelModifyRejectDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public double RejectingPriceBand
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[0]);
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
    }

    public OrderRejectionKind RejectKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderRejectionKind)(ushort)((buffer[2] >> 0) & 0xFFFF);
    }

    public ushort RejectCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[2] >> 16) & 0xFFFF);
    }

    public string RejectDescription
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 0);
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[3];
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[4];
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 2);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 3);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[2] >> 32) & 1UL) != 0;
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[5];
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[2] >> 40) & 0xFF);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 4);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 7);


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

public ref struct OrderReportMassActionDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 6;
    private const int PointerWords = 10;

    public OrderReportMassActionDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[0];
    }

    public ulong MassActionRptId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
    }

    public string SecurityGroup
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 0);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[2] >> 0) & 0xFFFF;
    }

    public MassActionResponse Response
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (MassActionResponse)(ushort)((buffer[2] >> 32) & 0xFFFF);
    }

    public MassActionScopeKind Scope
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (MassActionScopeKind)(ushort)((buffer[2] >> 48) & 0xFFFF);
    }

    public byte TotalAffectedOrders
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[3] >> 0) & 0xFF);
    }

    public bool IsLastFragment
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[3] >> 8) & 1UL) != 0;
    }

    public byte MarketSegmentId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[3] >> 16) & 0xFF);
    }

    public MassStatusRequestKind CancelRequestType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (MassStatusRequestKind)(ushort)((buffer[3] >> 32) & 0xFFFF);
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[3] >> 48) & 0xFFFF);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)((buffer[4] >> 0) & 0xFFFF);
    }

    public OrderTimeInForce TimeInForce
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderTimeInForce)(ushort)((buffer[4] >> 16) & 0xFFFF);
    }

    public byte NumAffectedOrders
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[3] >> 24) & 0xFF);
    }

    public ReadOnlySpan<ulong> ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadList_Primitive<ulong>(frame, meta, segmentIndex, offset + 1);
    }

    public ReadOnlySpan<ulong> OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadList_Primitive<ulong>(frame, meta, segmentIndex, offset + 2);
    }

    public ReadOnlySpan<uint> CancelQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadList_Primitive<uint>(frame, meta, segmentIndex, offset + 3);
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 4);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 5);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[3] >> 9) & 1UL) != 0;
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[5];
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[4] >> 32) & 0xFF);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 6);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 7);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 8);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 9);


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

public ref struct OrderReportPartyDetailsDefinitionDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 3;
    private const int PointerWords = 6;

    public OrderReportPartyDetailsDefinitionDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public ulong SelfMatchPreventionId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[0];
    }

    public OrderSelfMatchInst SelfMatchPreventionInst
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSelfMatchInst)(ushort)((buffer[1] >> 0) & 0xFFFF);
    }

    public byte NumPartyDetails
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[1] >> 16) & 0xFF);
    }

    public ReadOnlySpan<string> PartyDetailsId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadList_Text(frame, meta, segmentIndex, offset + 0);
    }

    public ReadOnlySpan<OrderPartyDetailsRole> PartyDetailsRole
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadList_Primitive<OrderPartyDetailsRole>(frame, meta, segmentIndex, offset + 1);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[1] >> 24) & 0xFF);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 2);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 3);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 4);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 5);


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

public ref struct OrderReportPartyDetailsListDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 5;
    private const int PointerWords = 6;

    public OrderReportPartyDetailsListDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public RequestResult RequestResult
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (RequestResult)(ushort)((buffer[0] >> 0) & 0xFFFF);
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
    }

    public ulong SelfMatchPreventionId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
    }

    public OrderSelfMatchInst SelfMatchPreventionInst
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSelfMatchInst)(ushort)((buffer[0] >> 16) & 0xFFFF);
    }

    public ushort TotalNumParties
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[0] >> 32) & 0xFFFF);
    }

    public byte NumPartyDetails
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[0] >> 48) & 0xFF);
    }

    public ReadOnlySpan<string> PartyDetailsId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadList_Text(frame, meta, segmentIndex, offset + 0);
    }

    public ReadOnlySpan<OrderPartyDetailsRole> PartyDetailsRole
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadList_Primitive<OrderPartyDetailsRole>(frame, meta, segmentIndex, offset + 1);
    }

    public bool IsLastFragment
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 56) & 1UL) != 0;
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[3];
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[4] >> 0) & 0xFF);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 2);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 3);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 4);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(frame, meta, segmentIndex, offset + 5);


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

public ref struct OrderManagerResponseStatusDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 8;
    private const int PointerWords = 4;

    public OrderManagerResponseStatusDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public long TimestampNs
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (long)buffer[0];
    }

    public CmeOrderManagerState LatestState
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeOrderManagerState)(ushort)((buffer[1] >> 0) & 0xFFFF);
    }

    public ulong NumEvents
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
    }

    public ReadOnlySpan<CmeOrderManagerEvent> EventsList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadList_Primitive<CmeOrderManagerEvent>(frame, meta, segmentIndex, offset + 0);
    }

    public string Account
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 1);
    }

    public RiskAccountingState AccountState
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (RiskAccountingState)(ushort)((buffer[1] >> 16) & 0xFFFF);
    }

    public double AccountPnl
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
    }

    public ulong NumWorkingOrd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[4];
    }

    public WorkingOrderListAccessor WorkingOrdList => new WorkingOrderListAccessor(frame, meta, segmentIndex, offset + 2);

    public ulong NumOutrightPos
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[5];
    }

    public OutrightPositionListAccessor OutrightPosList => new OutrightPositionListAccessor(frame, meta, segmentIndex, offset + 3);

    public ulong RemainingAccountStatusMessageCnt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[6];
    }

    public ulong RemainingStatusMessageCnt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[7];
    }


    public ref struct WorkingOrderListAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public WorkingOrderListAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public WorkingOrderDecoder GetElement(int index)
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            var elementCursor = DecodeHelpers.GetListElementCursor(frame, meta, cursor.segmentIndex, cursor.structIndex, index);
            return new WorkingOrderDecoder(frame, meta, elementCursor.segmentIndex, elementCursor.elementIndex);
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

    public ref struct OutrightPositionListAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public OutrightPositionListAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public OutrightPositionDecoder GetElement(int index)
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            var elementCursor = DecodeHelpers.GetListElementCursor(frame, meta, cursor.segmentIndex, cursor.structIndex, index);
            return new OutrightPositionDecoder(frame, meta, elementCursor.segmentIndex, elementCursor.elementIndex);
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

public ref struct WorkingOrderDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 7;
    private const int PointerWords = 0;

    public WorkingOrderDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[0];
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[3] >> 0) & 0xFFFF;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[3] >> 32) & 0xFFFF);
    }

    public ulong Quantity
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[4];
    }

    public double LimitPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[5]);
    }

    public OrderTimeInForce TimeInForce
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderTimeInForce)(ushort)((buffer[3] >> 48) & 0xFFFF);
    }

    public long UnitContractCnt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (long)buffer[6];
    }

}

public ref struct OutrightPositionDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 3;
    private const int PointerWords = 0;

    public OutrightPositionDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
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

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[0] >> 32) & 0xFFFF);
    }

    public ulong Quantity
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[2]);
    }

}

public ref struct OrderManagerResponseRejectDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 3;
    private const int PointerWords = 1;

    public OrderManagerResponseRejectDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public long TimestampNs
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (long)buffer[0];
    }

    public CmeOrderManagerState CurrentState
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeOrderManagerState)(ushort)((buffer[1] >> 0) & 0xFFFF);
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
    }

    public string RejectDescription
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 0);
    }

}

public ref struct OrderManagerResponseSetRiskLimitDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 1;

    public OrderManagerResponseSetRiskLimitDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public RiskAccountingLimitStructAccessor RiskLimit => new RiskAccountingLimitStructAccessor(frame, meta, segmentIndex, offset + 0);

    public bool Success
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 0) & 1UL) != 0;
    }


    public ref struct RiskAccountingLimitStructAccessor
    {
        private readonly Span<ulong> frame;
        private readonly SegmentMeta meta;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RiskAccountingLimitStructAccessor(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int pointerIndex)
        {
            this.frame = frame;
            this.meta = meta;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RiskAccountingLimitDecoder Reader()
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, pointerIndex);
            return new RiskAccountingLimitDecoder(frame, meta, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct OrderManagerResponseLoginDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 1;

    public OrderManagerResponseLoginDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public LoginResponse Response
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (LoginResponse)(ushort)((buffer[0] >> 0) & 0xFFFF);
    }

    public byte NumMsgwIds
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[0] >> 16) & 0xFF);
    }

    public ReadOnlySpan<byte> MsgwIds
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadList_Primitive<byte>(frame, meta, segmentIndex, offset + 0);
    }

    public EnvironmentKind Environment
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (EnvironmentKind)(ushort)((buffer[0] >> 32) & 0xFFFF);
    }

    public byte ClOrdIdPrefix
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[0] >> 24) & 0xFF);
    }

}

public ref struct OrderManagerResponsePingDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 0;

    public OrderManagerResponsePingDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public long TimestampNs
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (long)buffer[0];
    }

}

public ref struct OrderManagerResponseConnectionClosingDecoder
{
    private readonly Span<ulong> frame;
    private readonly SegmentMeta meta;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 0;

    public OrderManagerResponseConnectionClosingDecoder(Span<ulong> frame, SegmentMeta meta, int segmentIndex, int structIndex)
    {
        this.frame = frame;
        this.meta = meta;
        this.segmentIndex = segmentIndex;
        offset = structIndex + DataWords;
        structIndex += segmentIndex > 0 ? meta.GetWordCount(segmentIndex - 1) : 0;
        buffer = frame.Slice(structIndex, DataWords + PointerWords);
    }

    public long TimestampNs
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (long)buffer[0];
    }

}

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

