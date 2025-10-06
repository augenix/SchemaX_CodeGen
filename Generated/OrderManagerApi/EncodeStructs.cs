using System.Runtime.CompilerServices;

namespace SchemaX_CodeGen.Generated.OrderManagerApi;
public ref struct OrderRequestNewOrderEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 8;
    private const int PointerWords = 4;

    public OrderRequestNewOrderEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)(buffer[0] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public OrderTimeInForce TimeInForce
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderTimeInForce)(ushort)((buffer[0] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[1]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public uint OrderQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public double StopPx
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[2]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public uint MinQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)(buffer[3] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (buffer[3] & ~0xFFFFFFFFUL) | (ulong)value;
    }

    public uint DisplayQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[3] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (buffer[3] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public UtcTimeStructAccessor ExpireDate => new UtcTimeStructAccessor(arena, segmentIndex, offset + 0);

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[4];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = value;
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[5];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[5] = value;
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[6] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[6] = (buffer[6] & ~0xFFFFFFFFUL) | (ulong)(uint)value;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[6] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[6] = (buffer[6] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[7];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[7] = value;
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 2);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 2, value);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[6] >> 48) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[6] = (buffer[6] & ~(1UL << 48)) | (value ? 1UL << 48 : 0UL);
    }

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 3);


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

public ref struct OrderRequestCancelReplaceEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 9;
    private const int PointerWords = 4;

    public OrderRequestCancelReplaceEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[0];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = value;
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)(buffer[1] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[1] = (buffer[1] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public OrderTimeInForce TimeInForce
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderTimeInForce)(ushort)((buffer[1] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[2]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public uint OrderQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[1] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public double StopPx
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public uint MinQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)(buffer[4] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = (buffer[4] & ~0xFFFFFFFFUL) | (ulong)value;
    }

    public uint DisplayQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[4] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = (buffer[4] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public UtcTimeStructAccessor ExpireDate => new UtcTimeStructAccessor(arena, segmentIndex, offset + 0);

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[5];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[5] = value;
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[6];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[6] = value;
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[7] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[7] = (buffer[7] & ~0xFFFFFFFFUL) | (ulong)(uint)value;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[7] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[7] = (buffer[7] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[8];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[8] = value;
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 2);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 2, value);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[7] >> 48) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[7] = (buffer[7] & ~(1UL << 48)) | (value ? 1UL << 48 : 0UL);
    }

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 3);


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

public ref struct OrderRequestCancelEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 5;
    private const int PointerWords = 3;

    public OrderRequestCancelEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[0];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = value;
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = value;
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = value;
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[3] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (buffer[3] & ~0xFFFFFFFFUL) | (ulong)(uint)value;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[3] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[3] = (buffer[3] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[4];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = value;
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 0, value);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[3] >> 48) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (buffer[3] & ~(1UL << 48)) | (value ? 1UL << 48 : 0UL);
    }

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 2);


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

public ref struct OrderRequestStatusEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 4;
    private const int PointerWords = 3;

    public OrderRequestStatusEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[0];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = value;
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = value;
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = value;
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 0, value);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (buffer[3] & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (buffer[3] & ~1UL ) | (value ? 1UL : 0UL);
    }

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 2);


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

public ref struct OrderRequestMassStatusEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 4;
    private const int PointerWords = 4;

    public OrderRequestMassStatusEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[0];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = value;
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[1] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (buffer[1] & ~0xFFFFFFFFUL) | (ulong)(uint)value;
    }

    public MassActionScopeKind MassStatusType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (MassActionScopeKind)(ushort)((buffer[1] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public MassStatusRequestKind OrdStatusType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (MassStatusRequestKind)(ushort)((buffer[1] >> 48) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFUL << 48)) | ((ulong)(ushort)value << 48);
    }

    public string SecurityGroup
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 0, value);
    }

    public byte MarketSegmentId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)(buffer[2] & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (buffer[2] & ~0xFFUL) | (ulong)value;
    }

    public OrderTimeInForce TimeInForce
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderTimeInForce)(ushort)((buffer[2] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[2] = (buffer[2] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[3];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = value;
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 2);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 2, value);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[2] >> 8) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (buffer[2] & ~(1UL << 8)) | (value ? 1UL << 8 : 0UL);
    }

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 3);


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

public ref struct OrderRequestMassActionEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 5;
    private const int PointerWords = 4;

    public OrderRequestMassActionEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public MassActionScopeKind MassActionScope
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (MassActionScopeKind)(ushort)(buffer[0] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public string SecurityGroup
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 0, value);
    }

    public byte MarketSegmentId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[0] >> 16) & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFUL << 16)) | ((ulong)value << 16);
    }

    public MassStatusRequestKind CancelReqType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (MassStatusRequestKind)(ushort)((buffer[0] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)((buffer[0] >> 48) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 48)) | ((ulong)(ushort)value << 48);
    }

    public OrderTimeInForce TimeInForce
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderTimeInForce)(ushort)(buffer[1] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[1] = (buffer[1] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = value;
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[3];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = value;
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)((buffer[1] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFFFFFUL << 32)) | ((ulong)(uint)value << 32);
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[1] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[4];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = value;
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 2);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 2, value);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 24) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(1UL << 24)) | (value ? 1UL << 24 : 0UL);
    }

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 3);


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

public ref struct OrderRequestPartyDetailsDefinitionEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 3;
    private const int PointerWords = 2;

    public OrderRequestPartyDetailsDefinitionEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[0];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = value;
    }

    public ulong SelfMatchPreventionId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = value;
    }

    public OrderSelfMatchInst SelfMatchPreventionInst
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSelfMatchInst)(ushort)(buffer[2] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[2] = (buffer[2] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public byte NumPartyDetails
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[2] >> 16) & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (buffer[2] & ~(0xFFUL << 16)) | ((ulong)value << 16);
    }

    public ReadOnlySpan<OrderPartyDetailsRole> PartyDetailsRole
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadList_Primitive<OrderPartyDetailsRole>(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteList_Primitive<OrderPartyDetailsRole>(arena, segmentIndex, offset + 0, value);
    }

    public ReadOnlySpan<string> PartyDetailsId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadList_Text(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteList_Text(arena, segmentIndex, offset + 1, value);
    }

}

public ref struct OrderRequestPartyDetailsListEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 2;
    private const int PointerWords = 2;

    public OrderRequestPartyDetailsListEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[0];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = value;
    }

    public bool IsReqAllIds
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (buffer[1] & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (buffer[1] & ~1UL ) | (value ? 1UL : 0UL);
    }

    public string ReqPartyId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 0, value);
    }

    public byte NumPartyIds
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[1] >> 8) & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (buffer[1] & ~(0xFFUL << 8)) | ((ulong)value << 8);
    }

    public ReadOnlySpan<ulong> PartyIds
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadList_Primitive<ulong>(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteList_Primitive<ulong>(arena, segmentIndex, offset + 1, value);
    }

}

public ref struct OrderManagerCommandEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 0;

    public OrderManagerCommandEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public CmdKind Cmd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmdKind)(ushort)(buffer[0] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

}

public ref struct OrderManagerCommandAckAccountEventsEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 1;

    public OrderManagerCommandAckAccountEventsEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public string Account
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 0, value);
    }

    public long AcknowledgementTimestampNs
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (long)buffer[0];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (ulong)value;
    }

}

public ref struct OrderManagerCommandSetRiskLimitEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 0;
    private const int PointerWords = 1;

    public OrderManagerCommandSetRiskLimitEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public RiskAccountingLimitStructAccessor RiskLimit => new RiskAccountingLimitStructAccessor(arena, segmentIndex, offset + 0);


    public ref struct RiskAccountingLimitStructAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RiskAccountingLimitStructAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RiskAccountingLimitEncoder Writer()
        {
            var cursor = EncodeHelpers.AllocateStruct(arena, segmentIndex, pointerIndex, 1, 1);
            return new RiskAccountingLimitEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RiskAccountingLimitEncoder Reader()
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            return new RiskAccountingLimitEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct RiskAccountingLimitEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 1;

    public RiskAccountingLimitEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public string Account
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 0, value);
    }

    public double UnseenPnlLossUb
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[0]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

}

public ref struct OrderManagerCommandLoginEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 3;

    public OrderManagerCommandLoginEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public string UserName
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 0, value);
    }

    public string ConfigName
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }

    public string Password
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 2);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 2, value);
    }

    public int ServerPingIntervalMs
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~0xFFFFFFFFUL) | (ulong)(uint)value;
    }

}

public ref struct OrderManagerCommandPingEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 0;

    public OrderManagerCommandPingEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public long TimestampNs
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (long)buffer[0];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (ulong)value;
    }

}

public ref struct OrderReportBusinessRejectEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 3;
    private const int PointerWords = 7;

    public OrderReportBusinessRejectEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public ushort RejectReason
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)(buffer[0] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~0xFFFFUL) | (ulong)value;
    }

    public ushort RefTagId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[0] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 16)) | ((ulong)value << 16);
    }

    public OrderMsgTypeKind RefMsgType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderMsgTypeKind)(ushort)((buffer[0] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public string RejectDescription
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 0, value);
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = value;
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 2);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 2, value);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 48) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(1UL << 48)) | (value ? 1UL << 48 : 0UL);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = value;
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[0] >> 56) & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFUL << 56)) | ((ulong)value << 56);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 3);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 4);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 6);


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

public ref struct OrderReportExecRptNewOrderEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 10;
    private const int PointerWords = 8;

    public OrderReportExecRptNewOrderEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[0];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = value;
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[1]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public uint OrderQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)(buffer[2] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (buffer[2] & ~0xFFFFFFFFUL) | (ulong)value;
    }

    public double StopPx
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public uint MinQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[2] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (buffer[2] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public uint CumQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)(buffer[4] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = (buffer[4] & ~0xFFFFFFFFUL) | (ulong)value;
    }

    public uint DisplayQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[4] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = (buffer[4] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public UtcTimeStructAccessor ExpireDate => new UtcTimeStructAccessor(arena, segmentIndex, offset + 0);

    public OrderTimeInForce TimeInForce
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderTimeInForce)(ushort)(buffer[5] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[5] = (buffer[5] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)((buffer[5] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[5] = (buffer[5] & ~(0xFFFFFFFFUL << 32)) | ((ulong)(uint)value << 32);
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[5] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[5] = (buffer[5] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)(buffer[6] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[6] = (buffer[6] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[7];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[7] = value;
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[8];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[8] = value;
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 2);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 2, value);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 3);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 3, value);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[6] >> 16) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[6] = (buffer[6] & ~(1UL << 16)) | (value ? 1UL << 16 : 0UL);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[9];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[9] = value;
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[6] >> 24) & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[6] = (buffer[6] & ~(0xFFUL << 24)) | ((ulong)value << 24);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 4);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 7);


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

public ref struct OrderReportExecRptModifyEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 10;
    private const int PointerWords = 8;

    public OrderReportExecRptModifyEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public uint LeavesQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)(buffer[0] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~0xFFFFFFFFUL) | (ulong)value;
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = value;
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[2]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public uint OrderQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public double StopPx
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public uint MinQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)(buffer[4] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = (buffer[4] & ~0xFFFFFFFFUL) | (ulong)value;
    }

    public uint CumQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[4] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = (buffer[4] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public uint DisplayQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)(buffer[5] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[5] = (buffer[5] & ~0xFFFFFFFFUL) | (ulong)value;
    }

    public UtcTimeStructAccessor ExpireDate => new UtcTimeStructAccessor(arena, segmentIndex, offset + 0);

    public OrderTimeInForce TimeInForce
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderTimeInForce)(ushort)((buffer[5] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[5] = (buffer[5] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[6] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[6] = (buffer[6] & ~0xFFFFFFFFUL) | (ulong)(uint)value;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[5] >> 48) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[5] = (buffer[5] & ~(0xFFFFUL << 48)) | ((ulong)(ushort)value << 48);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)((buffer[6] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[6] = (buffer[6] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[7];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[7] = value;
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[8];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[8] = value;
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 2);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 2, value);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 3);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 3, value);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[6] >> 48) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[6] = (buffer[6] & ~(1UL << 48)) | (value ? 1UL << 48 : 0UL);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[9];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[9] = value;
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[6] >> 56) & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[6] = (buffer[6] & ~(0xFFUL << 56)) | ((ulong)value << 56);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 4);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 7);


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

public ref struct OrderReportExecRptCancelEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 10;
    private const int PointerWords = 8;

    public OrderReportExecRptCancelEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public CancelReason CancelReason
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CancelReason)(ushort)(buffer[0] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = value;
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[2]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public uint OrderQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public double StopPx
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public uint MinQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)(buffer[4] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = (buffer[4] & ~0xFFFFFFFFUL) | (ulong)value;
    }

    public uint CumQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[4] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = (buffer[4] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public uint DisplayQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)(buffer[5] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[5] = (buffer[5] & ~0xFFFFFFFFUL) | (ulong)value;
    }

    public UtcTimeStructAccessor ExpireDate => new UtcTimeStructAccessor(arena, segmentIndex, offset + 0);

    public OrderTimeInForce TimeInForce
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderTimeInForce)(ushort)((buffer[0] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)((buffer[5] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[5] = (buffer[5] & ~(0xFFFFFFFFUL << 32)) | ((ulong)(uint)value << 32);
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)(buffer[6] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[6] = (buffer[6] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)((buffer[6] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[6] = (buffer[6] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[7];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[7] = value;
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[8];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[8] = value;
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 2);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 2, value);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 3);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 3, value);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[6] >> 32) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[6] = (buffer[6] & ~(1UL << 32)) | (value ? 1UL << 32 : 0UL);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[9];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[9] = value;
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[6] >> 40) & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[6] = (buffer[6] & ~(0xFFUL << 40)) | ((ulong)value << 40);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 4);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 7);


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

public ref struct OrderReportExecRptStatusEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 12;
    private const int PointerWords = 9;

    public OrderReportExecRptStatusEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public ExecRptStatus OrdStatus
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (ExecRptStatus)(ushort)(buffer[0] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public uint LeavesQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public string RejectDescription
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 0, value);
    }

    public bool IsLastStatusRequested
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 16) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(1UL << 16)) | (value ? 1UL << 16 : 0UL);
    }

    public ulong StatusReqId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = value;
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = value;
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public uint OrderQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)(buffer[4] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = (buffer[4] & ~0xFFFFFFFFUL) | (ulong)value;
    }

    public double StopPx
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[5]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[5] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public uint MinQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[4] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = (buffer[4] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public uint CumQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)(buffer[6] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[6] = (buffer[6] & ~0xFFFFFFFFUL) | (ulong)value;
    }

    public uint DisplayQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[6] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[6] = (buffer[6] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public UtcTimeStructAccessor ExpireDate => new UtcTimeStructAccessor(arena, segmentIndex, offset + 1);

    public OrderTimeInForce TimeInForce
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderTimeInForce)(ushort)(buffer[7] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[7] = (buffer[7] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)((buffer[7] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[7] = (buffer[7] & ~(0xFFFFFFFFUL << 32)) | ((ulong)(uint)value << 32);
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[7] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[7] = (buffer[7] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)(buffer[8] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[8] = (buffer[8] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 2);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 2, value);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[9];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[9] = value;
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[10];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[10] = value;
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 3);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 3, value);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 4);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 4, value);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 17) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(1UL << 17)) | (value ? 1UL << 17 : 0UL);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[11];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[11] = value;
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[0] >> 24) & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFUL << 24)) | ((ulong)value << 24);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 5);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 7);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 8);


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

public ref struct OrderReportExecRptTradeOutrightEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 11;
    private const int PointerWords = 8;

    public OrderReportExecRptTradeOutrightEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public OrderFillStatus FillStatus
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderFillStatus)(ushort)(buffer[0] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public bool IsAggressor
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 16) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(1UL << 16)) | (value ? 1UL << 16 : 0UL);
    }

    public uint LeavesQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = value;
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[2]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public uint OrderQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)(buffer[3] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (buffer[3] & ~0xFFFFFFFFUL) | (ulong)value;
    }

    public uint CumQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[3] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (buffer[3] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public double FillPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[4]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public uint FillQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)(buffer[5] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[5] = (buffer[5] & ~0xFFFFFFFFUL) | (ulong)value;
    }

    public ulong SecurityExecId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[6];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[6] = value;
    }

    public UtcTimeStructAccessor TradeDate => new UtcTimeStructAccessor(arena, segmentIndex, offset + 0);

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)((buffer[5] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[5] = (buffer[5] & ~(0xFFFFFFFFUL << 32)) | ((ulong)(uint)value << 32);
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)(buffer[7] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[7] = (buffer[7] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)((buffer[7] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[7] = (buffer[7] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[8];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[8] = value;
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[9];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[9] = value;
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 2);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 2, value);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 3);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 3, value);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 17) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(1UL << 17)) | (value ? 1UL << 17 : 0UL);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[10];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[10] = value;
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[0] >> 24) & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFUL << 24)) | ((ulong)value << 24);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 4);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 7);


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

public ref struct OrderReportExecRptTradeSpreadEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 11;
    private const int PointerWords = 8;

    public OrderReportExecRptTradeSpreadEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public byte NumLegFills
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)(buffer[0] & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~0xFFUL) | (ulong)value;
    }

    public OrderFillStatus FillStatus
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderFillStatus)(ushort)((buffer[0] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public bool IsAggressor
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 8) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(1UL << 8)) | (value ? 1UL << 8 : 0UL);
    }

    public uint LeavesQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = value;
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[2]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public uint OrderQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)(buffer[3] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (buffer[3] & ~0xFFFFFFFFUL) | (ulong)value;
    }

    public uint CumQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[3] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (buffer[3] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public double FillPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[4]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public uint FillQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)(buffer[5] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[5] = (buffer[5] & ~0xFFFFFFFFUL) | (ulong)value;
    }

    public ulong SecurityExecId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[6];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[6] = value;
    }

    public UtcTimeStructAccessor TradeDate => new UtcTimeStructAccessor(arena, segmentIndex, offset + 0);

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)((buffer[5] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[5] = (buffer[5] & ~(0xFFFFFFFFUL << 32)) | ((ulong)(uint)value << 32);
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)(buffer[7] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[7] = (buffer[7] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)((buffer[7] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[7] = (buffer[7] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[8];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[8] = value;
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[9];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[9] = value;
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 2);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 2, value);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 3);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 3, value);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 9) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(1UL << 9)) | (value ? 1UL << 9 : 0UL);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[10];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[10] = value;
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[7] >> 32) & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[7] = (buffer[7] & ~(0xFFUL << 32)) | ((ulong)value << 32);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 4);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 7);


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

public ref struct OrderReportExecRptTradeSpreadLegEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 8;
    private const int PointerWords = 8;

    public OrderReportExecRptTradeSpreadLegEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public uint CumQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)(buffer[0] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~0xFFFFFFFFUL) | (ulong)value;
    }

    public OrderFillStatus FillStatus
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderFillStatus)(ushort)((buffer[0] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public double FillPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[1]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public uint FillQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)(buffer[2] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (buffer[2] & ~0xFFFFFFFFUL) | (ulong)value;
    }

    public ulong SecurityExecId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[3];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = value;
    }

    public UtcTimeStructAccessor TradeDate => new UtcTimeStructAccessor(arena, segmentIndex, offset + 0);

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)((buffer[2] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (buffer[2] & ~(0xFFFFFFFFUL << 32)) | ((ulong)(uint)value << 32);
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[0] >> 48) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 48)) | ((ulong)(ushort)value << 48);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)(buffer[4] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[4] = (buffer[4] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[5];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[5] = value;
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[6];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[6] = value;
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 2);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 2, value);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 3);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 3, value);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[4] >> 16) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = (buffer[4] & ~(1UL << 16)) | (value ? 1UL << 16 : 0UL);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[7];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[7] = value;
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[4] >> 24) & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = (buffer[4] & ~(0xFFUL << 24)) | ((ulong)value << 24);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 4);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 7);


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

public ref struct OrderReportExecRptEliminationEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 10;
    private const int PointerWords = 8;

    public OrderReportExecRptEliminationEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[0];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = value;
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[1]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public uint OrderQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)(buffer[2] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (buffer[2] & ~0xFFFFFFFFUL) | (ulong)value;
    }

    public double StopPx
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public uint MinQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[2] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (buffer[2] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public uint CumQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)(buffer[4] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = (buffer[4] & ~0xFFFFFFFFUL) | (ulong)value;
    }

    public uint DisplayQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[4] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = (buffer[4] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public UtcTimeStructAccessor ExpireDate => new UtcTimeStructAccessor(arena, segmentIndex, offset + 0);

    public OrderTimeInForce TimeInForce
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderTimeInForce)(ushort)(buffer[5] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[5] = (buffer[5] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)((buffer[5] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[5] = (buffer[5] & ~(0xFFFFFFFFUL << 32)) | ((ulong)(uint)value << 32);
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[5] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[5] = (buffer[5] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)(buffer[6] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[6] = (buffer[6] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[7];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[7] = value;
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[8];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[8] = value;
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 2);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 2, value);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 3);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 3, value);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[6] >> 16) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[6] = (buffer[6] & ~(1UL << 16)) | (value ? 1UL << 16 : 0UL);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[9];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[9] = value;
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[6] >> 24) & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[6] = (buffer[6] & ~(0xFFUL << 24)) | ((ulong)value << 24);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 4);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 7);


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

public ref struct OrderReportExecRptRejectEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 11;
    private const int PointerWords = 9;

    public OrderReportExecRptRejectEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public OrderRejectionKind RejectKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderRejectionKind)(ushort)(buffer[0] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public ushort RejectCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[0] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 16)) | ((ulong)value << 16);
    }

    public string RejectDescription
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 0, value);
    }

    public double RejectingPriceBand
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[1]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = value;
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public uint OrderQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public double StopPx
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[4]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public uint MinQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)(buffer[5] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[5] = (buffer[5] & ~0xFFFFFFFFUL) | (ulong)value;
    }

    public uint CumQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[5] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[5] = (buffer[5] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public uint DisplayQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)(buffer[6] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[6] = (buffer[6] & ~0xFFFFFFFFUL) | (ulong)value;
    }

    public UtcTimeStructAccessor ExpireDate => new UtcTimeStructAccessor(arena, segmentIndex, offset + 1);

    public OrderTimeInForce TimeInForce
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderTimeInForce)(ushort)((buffer[6] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[6] = (buffer[6] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[7] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[7] = (buffer[7] & ~0xFFFFFFFFUL) | (ulong)(uint)value;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[6] >> 48) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[6] = (buffer[6] & ~(0xFFFFUL << 48)) | ((ulong)(ushort)value << 48);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)((buffer[7] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[7] = (buffer[7] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 2);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 2, value);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[8];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[8] = value;
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[9];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[9] = value;
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 3);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 3, value);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 4);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 4, value);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[7] >> 48) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[7] = (buffer[7] & ~(1UL << 48)) | (value ? 1UL << 48 : 0UL);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[10];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[10] = value;
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[7] >> 56) & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[7] = (buffer[7] & ~(0xFFUL << 56)) | ((ulong)value << 56);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 5);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 7);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 8);


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

public ref struct OrderReportExecRptTradeAddendumOutrightEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 7;
    private const int PointerWords = 8;

    public OrderReportExecRptTradeAddendumOutrightEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public AddendumKind AddendumKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (AddendumKind)(ushort)(buffer[0] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public double FillPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[1]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public uint FillQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public ulong SecurityExecId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = value;
    }

    public UtcTimeStructAccessor TradeDate => new UtcTimeStructAccessor(arena, segmentIndex, offset + 0);

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[3] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (buffer[3] & ~0xFFFFFFFFUL) | (ulong)(uint)value;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[0] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)((buffer[3] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[3] = (buffer[3] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[4];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = value;
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[5];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[5] = value;
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 2);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 2, value);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 3);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 3, value);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[3] >> 48) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (buffer[3] & ~(1UL << 48)) | (value ? 1UL << 48 : 0UL);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[6];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[6] = value;
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[3] >> 56) & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (buffer[3] & ~(0xFFUL << 56)) | ((ulong)value << 56);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 4);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 7);


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

public ref struct OrderReportExecRptTradeAddendumSpreadEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 8;
    private const int PointerWords = 8;

    public OrderReportExecRptTradeAddendumSpreadEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public byte NumLegFills
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)(buffer[0] & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~0xFFUL) | (ulong)value;
    }

    public AddendumKind AddendumKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (AddendumKind)(ushort)((buffer[0] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public double FillPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[1]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public uint FillQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public ulong SecurityExecId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = value;
    }

    public UtcTimeStructAccessor TradeDate => new UtcTimeStructAccessor(arena, segmentIndex, offset + 0);

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[3] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (buffer[3] & ~0xFFFFFFFFUL) | (ulong)(uint)value;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[3] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[3] = (buffer[3] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)((buffer[3] >> 48) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[3] = (buffer[3] & ~(0xFFFFUL << 48)) | ((ulong)(ushort)value << 48);
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[4];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = value;
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[5];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[5] = value;
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 2);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 2, value);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 3);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 3, value);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 8) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(1UL << 8)) | (value ? 1UL << 8 : 0UL);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[6];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[6] = value;
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)(buffer[7] & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[7] = (buffer[7] & ~0xFFUL) | (ulong)value;
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 4);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 7);


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

public ref struct OrderReportExecRptTradeAddendumSpreadLegEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 7;
    private const int PointerWords = 8;

    public OrderReportExecRptTradeAddendumSpreadLegEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public AddendumKind AddendumKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (AddendumKind)(ushort)(buffer[0] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public double FillPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[1]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public uint FillQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (uint)((buffer[0] >> 32) & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFFFFFUL << 32)) | ((ulong)value << 32);
    }

    public ulong SecurityExecId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = value;
    }

    public UtcTimeStructAccessor TradeDate => new UtcTimeStructAccessor(arena, segmentIndex, offset + 0);

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[3] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (buffer[3] & ~0xFFFFFFFFUL) | (ulong)(uint)value;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[0] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)((buffer[3] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[3] = (buffer[3] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[4];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = value;
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[5];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[5] = value;
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 2);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 2, value);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 3);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 3, value);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[3] >> 48) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (buffer[3] & ~(1UL << 48)) | (value ? 1UL << 48 : 0UL);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[6];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[6] = value;
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[3] >> 56) & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (buffer[3] & ~(0xFFUL << 56)) | ((ulong)value << 56);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 4);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 7);


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

public ref struct OrderReportOrderCancelRejectEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 5;
    private const int PointerWords = 8;

    public OrderReportOrderCancelRejectEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[0];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = value;
    }

    public OrderRejectionKind RejectKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderRejectionKind)(ushort)(buffer[1] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[1] = (buffer[1] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public ushort RejectCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[1] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFUL << 16)) | ((ulong)value << 16);
    }

    public string RejectDescription
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 0, value);
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = value;
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[3];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = value;
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 2);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 2, value);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 3);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 3, value);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[1] >> 32) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (buffer[1] & ~(1UL << 32)) | (value ? 1UL << 32 : 0UL);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[4];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = value;
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[1] >> 40) & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (buffer[1] & ~(0xFFUL << 40)) | ((ulong)value << 40);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 4);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 7);


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

public ref struct OrderReportOrderCancelModifyRejectEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 6;
    private const int PointerWords = 8;

    public OrderReportOrderCancelModifyRejectEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public double RejectingPriceBand
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[0]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = value;
    }

    public OrderRejectionKind RejectKind
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderRejectionKind)(ushort)(buffer[2] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[2] = (buffer[2] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public ushort RejectCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[2] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (buffer[2] & ~(0xFFFFUL << 16)) | ((ulong)value << 16);
    }

    public string RejectDescription
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 0, value);
    }

    public string ExecReportId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[3];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = value;
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[4];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = value;
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 2);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 2, value);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 3);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 3, value);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[2] >> 32) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (buffer[2] & ~(1UL << 32)) | (value ? 1UL << 32 : 0UL);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[5];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[5] = value;
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[2] >> 40) & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (buffer[2] & ~(0xFFUL << 40)) | ((ulong)value << 40);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 4);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 5);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 6);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 7);


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

public ref struct OrderReportMassActionEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 6;
    private const int PointerWords = 10;

    public OrderReportMassActionEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[0];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = value;
    }

    public ulong MassActionRptId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = value;
    }

    public string SecurityGroup
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 0, value);
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[2] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (buffer[2] & ~0xFFFFFFFFUL) | (ulong)(uint)value;
    }

    public MassActionResponse Response
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (MassActionResponse)(ushort)((buffer[2] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[2] = (buffer[2] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public MassActionScopeKind Scope
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (MassActionScopeKind)(ushort)((buffer[2] >> 48) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[2] = (buffer[2] & ~(0xFFFFUL << 48)) | ((ulong)(ushort)value << 48);
    }

    public byte TotalAffectedOrders
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)(buffer[3] & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (buffer[3] & ~0xFFUL) | (ulong)value;
    }

    public bool IsLastFragment
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[3] >> 8) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (buffer[3] & ~(1UL << 8)) | (value ? 1UL << 8 : 0UL);
    }

    public byte MarketSegmentId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[3] >> 16) & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (buffer[3] & ~(0xFFUL << 16)) | ((ulong)value << 16);
    }

    public MassStatusRequestKind CancelRequestType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (MassStatusRequestKind)(ushort)((buffer[3] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[3] = (buffer[3] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[3] >> 48) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[3] = (buffer[3] & ~(0xFFFFUL << 48)) | ((ulong)(ushort)value << 48);
    }

    public OrderKind OrdType
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderKind)(ushort)(buffer[4] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[4] = (buffer[4] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public OrderTimeInForce TimeInForce
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderTimeInForce)(ushort)((buffer[4] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[4] = (buffer[4] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public byte NumAffectedOrders
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[3] >> 24) & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (buffer[3] & ~(0xFFUL << 24)) | ((ulong)value << 24);
    }

    public ReadOnlySpan<ulong> ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadList_Primitive<ulong>(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteList_Primitive<ulong>(arena, segmentIndex, offset + 1, value);
    }

    public ReadOnlySpan<ulong> OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadList_Primitive<ulong>(arena, segmentIndex, offset + 2);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteList_Primitive<ulong>(arena, segmentIndex, offset + 2, value);
    }

    public ReadOnlySpan<uint> CancelQty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadList_Primitive<uint>(arena, segmentIndex, offset + 3);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteList_Primitive<uint>(arena, segmentIndex, offset + 3, value);
    }

    public string SenderId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 4);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 4, value);
    }

    public string Location
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 5);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 5, value);
    }

    public bool ManualOrderInd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[3] >> 9) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (buffer[3] & ~(1UL << 9)) | (value ? 1UL << 9 : 0UL);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[5];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[5] = value;
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[4] >> 32) & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = (buffer[4] & ~(0xFFUL << 32)) | ((ulong)value << 32);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 6);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 7);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 8);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 9);


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

public ref struct OrderReportPartyDetailsDefinitionEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 3;
    private const int PointerWords = 6;

    public OrderReportPartyDetailsDefinitionEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public ulong SelfMatchPreventionId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[0];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = value;
    }

    public OrderSelfMatchInst SelfMatchPreventionInst
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSelfMatchInst)(ushort)(buffer[1] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[1] = (buffer[1] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public byte NumPartyDetails
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[1] >> 16) & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (buffer[1] & ~(0xFFUL << 16)) | ((ulong)value << 16);
    }

    public ReadOnlySpan<string> PartyDetailsId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadList_Text(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteList_Text(arena, segmentIndex, offset + 0, value);
    }

    public ReadOnlySpan<OrderPartyDetailsRole> PartyDetailsRole
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadList_Primitive<OrderPartyDetailsRole>(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteList_Primitive<OrderPartyDetailsRole>(arena, segmentIndex, offset + 1, value);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = value;
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[1] >> 24) & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = (buffer[1] & ~(0xFFUL << 24)) | ((ulong)value << 24);
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 2);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 3);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 4);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 5);


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

public ref struct OrderReportPartyDetailsListEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 5;
    private const int PointerWords = 6;

    public OrderReportPartyDetailsListEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public RequestResult RequestResult
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (RequestResult)(ushort)(buffer[0] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = value;
    }

    public ulong SelfMatchPreventionId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = value;
    }

    public OrderSelfMatchInst SelfMatchPreventionInst
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSelfMatchInst)(ushort)((buffer[0] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public ushort TotalNumParties
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (ushort)((buffer[0] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 32)) | ((ulong)value << 32);
    }

    public byte NumPartyDetails
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[0] >> 48) & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFUL << 48)) | ((ulong)value << 48);
    }

    public ReadOnlySpan<string> PartyDetailsId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadList_Text(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteList_Text(arena, segmentIndex, offset + 0, value);
    }

    public ReadOnlySpan<OrderPartyDetailsRole> PartyDetailsRole
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadList_Primitive<OrderPartyDetailsRole>(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteList_Primitive<OrderPartyDetailsRole>(arena, segmentIndex, offset + 1, value);
    }

    public bool IsLastFragment
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => ((buffer[0] >> 56) & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(1UL << 56)) | (value ? 1UL << 56 : 0UL);
    }

    public ulong PartyListId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[3];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = value;
    }

    public byte IsAResend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)(buffer[4] & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = (buffer[4] & ~0xFFUL) | (ulong)value;
    }

    public UtcTimeStructAccessor ExchangeTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 2);

    public UtcTimeStructAccessor SendingTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 3);

    public UtcTimeStructAccessor ReceiptTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 4);

    public UtcTimeStructAccessor ExtractTimestamp => new UtcTimeStructAccessor(arena, segmentIndex, offset + 5);


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

public ref struct OrderManagerResponseStatusEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 8;
    private const int PointerWords = 4;

    public OrderManagerResponseStatusEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public long TimestampNs
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (long)buffer[0];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (ulong)value;
    }

    public CmeOrderManagerState LatestState
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeOrderManagerState)(ushort)(buffer[1] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[1] = (buffer[1] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public ulong NumEvents
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = value;
    }

    public ReadOnlySpan<CmeOrderManagerEvent> EventsList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadList_Primitive<CmeOrderManagerEvent>(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteList_Primitive<CmeOrderManagerEvent>(arena, segmentIndex, offset + 0, value);
    }

    public string Account
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 1, value);
    }

    public RiskAccountingState AccountState
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (RiskAccountingState)(ushort)((buffer[1] >> 16) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[1] = (buffer[1] & ~(0xFFFFUL << 16)) | ((ulong)(ushort)value << 16);
    }

    public double AccountPnl
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[3]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public ulong NumWorkingOrd
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[4];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = value;
    }

    public WorkingOrderListAccessor WorkingOrdList => new WorkingOrderListAccessor(arena, segmentIndex, offset + 2);

    public ulong NumOutrightPos
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[5];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[5] = value;
    }

    public OutrightPositionListAccessor OutrightPosList => new OutrightPositionListAccessor(arena, segmentIndex, offset + 3);

    public ulong RemainingAccountStatusMessageCnt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[6];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[6] = value;
    }

    public ulong RemainingStatusMessageCnt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[7];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[7] = value;
    }


    public ref struct WorkingOrderListAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public WorkingOrderListAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Init(int count)
        {
            EncodeHelpers.AllocateList_Struct(arena, segmentIndex, pointerIndex, count, 7, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public WorkingOrderEncoder GetElement(int index)
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            var elementCursor = EncodeHelpers.GetListElementCursor(arena, cursor.segmentIndex, cursor.structIndex, index);
            return new WorkingOrderEncoder(arena, elementCursor.segmentIndex, elementCursor.elementIndex);
        }
    }

    public ref struct OutrightPositionListAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public OutrightPositionListAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Init(int count)
        {
            EncodeHelpers.AllocateList_Struct(arena, segmentIndex, pointerIndex, count, 3, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public OutrightPositionEncoder GetElement(int index)
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            var elementCursor = EncodeHelpers.GetListElementCursor(arena, cursor.segmentIndex, cursor.structIndex, index);
            return new OutrightPositionEncoder(arena, elementCursor.segmentIndex, elementCursor.elementIndex);
        }
    }
}

public ref struct WorkingOrderEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 7;
    private const int PointerWords = 0;

    public WorkingOrderEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[0];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = value;
    }

    public ulong ClOrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = value;
    }

    public ulong OrdId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = value;
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[3] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[3] = (buffer[3] & ~0xFFFFFFFFUL) | (ulong)(uint)value;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[3] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[3] = (buffer[3] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public ulong Quantity
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[4];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[4] = value;
    }

    public double LimitPrice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[5]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[5] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

    public OrderTimeInForce TimeInForce
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderTimeInForce)(ushort)((buffer[3] >> 48) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[3] = (buffer[3] & ~(0xFFFFUL << 48)) | ((ulong)(ushort)value << 48);
    }

    public long UnitContractCnt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (long)buffer[6];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[6] = (ulong)value;
    }

}

public ref struct OutrightPositionEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 3;
    private const int PointerWords = 0;

    public OutrightPositionEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public int SecurityId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (int)(buffer[0] & 0xFFFFFFFFUL);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~0xFFFFFFFFUL) | (ulong)(uint)value;
    }

    public OrderSide Side
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (OrderSide)(ushort)((buffer[0] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public ulong Quantity
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[1];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[1] = value;
    }

    public double Price
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => BitConverter.Int64BitsToDouble((long)buffer[2]);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = (ulong)BitConverter.DoubleToInt64Bits(value);
    }

}

public ref struct OrderManagerResponseRejectEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 3;
    private const int PointerWords = 1;

    public OrderManagerResponseRejectEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public long TimestampNs
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (long)buffer[0];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (ulong)value;
    }

    public CmeOrderManagerState CurrentState
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (CmeOrderManagerState)(ushort)(buffer[1] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[1] = (buffer[1] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public ulong RequestId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => buffer[2];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[2] = value;
    }

    public string RejectDescription
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 0, value);
    }

}

public ref struct OrderManagerResponseSetRiskLimitEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 1;

    public OrderManagerResponseSetRiskLimitEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public RiskAccountingLimitStructAccessor RiskLimit => new RiskAccountingLimitStructAccessor(arena, segmentIndex, offset + 0);

    public bool Success
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (buffer[0] & 1UL) != 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~1UL ) | (value ? 1UL : 0UL);
    }


    public ref struct RiskAccountingLimitStructAccessor
    {
        private readonly SegmentArena arena;
        private readonly int pointerIndex;
        private readonly int segmentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RiskAccountingLimitStructAccessor(SegmentArena arena, int segmentIndex, int pointerIndex)
        {
            this.arena = arena;
            this.pointerIndex = pointerIndex;
            this.segmentIndex = segmentIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RiskAccountingLimitEncoder Writer()
        {
            var cursor = EncodeHelpers.AllocateStruct(arena, segmentIndex, pointerIndex, 1, 1);
            return new RiskAccountingLimitEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RiskAccountingLimitEncoder Reader()
        {
            var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, pointerIndex);
            return new RiskAccountingLimitEncoder(arena, cursor.segmentIndex, cursor.structIndex);
        }
    }
}

public ref struct OrderManagerResponseLoginEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 1;

    public OrderManagerResponseLoginEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public LoginResponse Response
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (LoginResponse)(ushort)(buffer[0] & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~0xFFFFUL) | (ulong)(ushort)value;
    }

    public byte NumMsgwIds
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[0] >> 16) & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFUL << 16)) | ((ulong)value << 16);
    }

    public ReadOnlySpan<byte> MsgwIds
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => EncodeHelpers.ReadList_Primitive<byte>(arena, segmentIndex, offset + 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => EncodeHelpers.WriteList_Primitive<byte>(arena, segmentIndex, offset + 0, value);
    }

    public EnvironmentKind Environment
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (EnvironmentKind)(ushort)((buffer[0] >> 32) & 0xFFFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => buffer[0] = (buffer[0] & ~(0xFFFFUL << 32)) | ((ulong)(ushort)value << 32);
    }

    public byte ClOrdIdPrefix
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (byte)((buffer[0] >> 24) & 0xFF);
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (buffer[0] & ~(0xFFUL << 24)) | ((ulong)value << 24);
    }

}

public ref struct OrderManagerResponsePingEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 0;

    public OrderManagerResponsePingEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public long TimestampNs
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (long)buffer[0];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (ulong)value;
    }

}

public ref struct OrderManagerResponseConnectionClosingEncoder
{
    private readonly SegmentArena arena;
    private readonly Span<ulong> buffer;
    private readonly int offset;
    private readonly int segmentIndex;
    private const int DataWords = 1;
    private const int PointerWords = 0;

    public OrderManagerResponseConnectionClosingEncoder(SegmentArena arena, int segmentIndex, int structIndex)
    {
        this.arena = arena;
        buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
        offset = structIndex + DataWords;
        this.segmentIndex = segmentIndex;
    }

    public long TimestampNs
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => (long)buffer[0];
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (ulong)value;
    }

}

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
        get => (long)buffer[0] ^ -9223372036854775808;
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        set => buffer[0] = (ulong)(value ^ -9223372036854775808);
    }

}

