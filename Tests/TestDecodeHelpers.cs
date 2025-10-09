using System.Runtime.CompilerServices;
using System.Text;
using SchemaX_CodeGen.Generated.OrderManagerApi;

namespace SchemaX_CodeGen.Tests;

public class TestDecodeHelpers
{
    public void Run()
    {
        //TestOrderRequestNewOrder();
        //Test_ReadText();
        //Test_ReadStruct();
        //Test_ReadList_Text();
        //Test_ReadList_Primitive();
        Test_ReadList_Struct();

    }
    
    private static void Test_ReadStruct()
    {
        var arena = new SegmentArena();
        var seg0 = arena.GetSegment(0);
        var dataSectionWords = 120;
        var pointerSectionWords = 8;
        var root = 0UL;
        root |= (ulong)((long)pointerSectionWords << 48);
        root |= (ulong)((long)dataSectionWords << 32);
        seg0[0] = root;
        arena.IncrementWordCount(0, 1);
        var baseIndex = arena.GetWordCount(0);
        var offset = baseIndex + dataSectionWords;
        arena.IncrementWordCount(0, dataSectionWords + pointerSectionWords);
        int sCount = 5;
        for (int i = 0; i < sCount; i++)
        {
            var cursor = EncodeHelpers.AllocateStruct(arena, 0, offset + i, 7, 1);
            var w = new WorkingOrderEncoder(arena, cursor.segmentIndex, cursor.structIndex)
            {
                LimitPrice = 1000,
                Quantity = 1,
                Side = OrderSide.buy,
                OrdId = 123456789,
                ClOrdId = 123456789,
                RequestId = 123456789,
                SecurityId = 12345,
                TimeInForce = OrderTimeInForce.day,
                UnitContractCnt = 1,
                Symbol = "ESM5"
            };
        }
        
        FrameInspector.DumpSegments(arena);

        var frame = arena.GetAllSegments;
        var meta = new SegmentMeta
        {
            SegmentCount = arena.SegmentCount,
            TotalWords = arena.TotalWords,
        };
        for (var i = 0; i < meta.SegmentCount; i++)
        {
            meta.SetWordCount(i, arena.GetWordCount(i));
        }
        
        for (int i = 0; i < sCount; i++)
        {
            var cursor = DecodeHelpers.GetStructCursor(frame, meta, 0, offset + i);
            var w = new WorkingOrderDecoder(frame, meta, cursor.segmentIndex, cursor.structIndex);
            Console.WriteLine($"LimitPrice: {w.LimitPrice}  Quantity: {w.Quantity} Side {w.Side} ordid {w.OrdId} clordid {w.ClOrdId} requestid {w.RequestId} timeinforce {w.TimeInForce} unitcontrcnt {w.UnitContractCnt} symbol {w.Symbol}");
        }
    } 
    public  ref struct WorkingOrderEncoder
    {
        private readonly SegmentArena arena;
        private readonly Span<ulong> buffer;
        private const int DataWords = 7;
        private const int PointerWords = 1;
        private readonly int offset;
        private readonly int segmentIndex;

        public WorkingOrderEncoder(SegmentArena arena, int segmentIndex, int structIndex)
        {
            this.arena = arena;
            buffer = arena.GetSegment(segmentIndex).Slice(structIndex, DataWords + PointerWords);
            this.segmentIndex = segmentIndex;
            offset = structIndex + DataWords;
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
            get => (int)(buffer[3] >> 0);
            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            set => buffer[3] = (buffer[3] & ~(0xFFFFFFFFUL << 0)) | ((ulong)(uint)value << 0);
        }

        public OrderSide Side
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            get => (OrderSide)(ushort)((buffer[3] >> 32) & 0xFFFF);
            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
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
            get => (double)buffer[5];
            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            set => buffer[5] = (ulong)value;
        }

        public OrderTimeInForce TimeInForce
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            get => (OrderTimeInForce)(ushort)((buffer[3] >> 48) & 0xFFFF);
            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            set => buffer[3] = (buffer[3] & ~(0xFFFFUL << 48)) | ((ulong)(ushort)value << 48);
        }

        public long UnitContractCnt
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            get => (long)buffer[6];
            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            set => buffer[6] = (ulong)value;
        }

        public string Symbol
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            get => EncodeHelpers.ReadText(arena, segmentIndex, offset + 0);
            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            set => EncodeHelpers.WriteText(arena, segmentIndex, offset + 0, value);
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
    private const int PointerWords = 1;

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
        get => (int)(buffer[3] >> 0);
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
        get => (double)buffer[5];
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
    public string Symbol
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DecodeHelpers.ReadText(frame, meta, segmentIndex, offset + 0);
    }

}
        
    private static void Test_ReadList_Struct()
    {
        var arena = new SegmentArena();
        var seg0 = arena.GetSegment(0);
        var dataSectionWords = 100;
        var pointerSectionWords = 5;
        var root = 0UL;
        root |= (ulong)((long)pointerSectionWords << 48);
        root |= (ulong)((long)dataSectionWords << 32);
        seg0[0] = root;
        arena.IncrementWordCount(0, 1);
        var baseIndex = arena.GetWordCount(0);
        var segmentIndex = 0;
        var offset = baseIndex + dataSectionWords;
        arena.IncrementWordCount(0, dataSectionWords + pointerSectionWords);
        var wCount = 5;
        var wos = new List<WorkingOrder>();
        for (var i = 0; i < wCount; i++)
        {
            wos.Add(new WorkingOrder
            {
                LimitPrice = 1000,
                Quantity = 1,
                Side = OrderSide.buy,
                OrdId = 123456789,
                ClOrdId = 123456789,
                RequestId = 123456789,
                SecurityId = 12345,
                TimeInForce = OrderTimeInForce.day,
                UnitContractCnt = 1, 
                Symbol = "ESM5",
            });
        }

        var msgCount = 5;
        for (var i = 0; i < msgCount; i++)
        {
            var cursor = 
                EncodeHelpers.AllocateList_Struct(arena, segmentIndex, offset + i, msgCount, 7, 1);
            for (int j = 0; j < wCount; j++)
            {
                var src = wos[j];
                var elementCursor = EncodeHelpers.GetListElementCursor(arena, cursor.segmentIndex, cursor.tagIndex, j);
                var w = new WorkingOrderEncoder(arena, elementCursor.segmentIndex, elementCursor.elementIndex);
                w.LimitPrice = src.LimitPrice;
                w.Quantity = src.Quantity;
                w.Side = src.Side;
                w.OrdId = src.OrdId;
                w.ClOrdId = src.ClOrdId;
                w.RequestId = src.RequestId;
                w.SecurityId = src.SecurityId;
                w.TimeInForce = src.TimeInForce;
                w.UnitContractCnt = src.UnitContractCnt;
                w.Symbol = src.Symbol;
            }
        }
        FrameInspector.DumpSegments(arena);
        var frame = arena.GetAllSegments;
        var meta = new SegmentMeta
        {
            SegmentCount = arena.SegmentCount,
        };
        for (var i = 0; i < meta.SegmentCount; i++)
        {
            meta.SetWordCount(i, arena.GetWordCount(i));
            meta.TotalWords += arena.GetWordCount(i);
        }

        
        for (var i = 0; i < msgCount; i++)
        {
            for (var j = 0; j < wCount; j++)
            {
                var cursor = DecodeHelpers.GetStructCursor(frame, meta, segmentIndex, offset + i);
                Console.WriteLine($"struct cursor segment index {cursor.segmentIndex} struct index {cursor.structIndex}");
                var length = DecodeHelpers.GetListLength(frame, meta, cursor.segmentIndex, cursor.structIndex);
                var elementCursor = DecodeHelpers.GetListElementCursor(frame, meta, cursor.segmentIndex, cursor.structIndex, j);
                var w = new WorkingOrderEncoder(arena, elementCursor.segmentIndex, elementCursor.elementIndex);
                Console.WriteLine($"List Length {length}");
                // Console.WriteLine(
                //     $"Get Target price: {w.LimitPrice} qty {w.Quantity} side {w.Side} order {w.OrdId} " +
                //     $"clord {w.ClOrdId} request {w.RequestId} sec {w.SecurityId} time {w.TimeInForce} " +
                //     $"unit-contract {w.UnitContractCnt} symbol {w.Symbol}");
            }
        }
    }
    

    private struct WorkingOrder
    {
        public double LimitPrice;
        public uint Quantity;
        public OrderSide Side;
        public ulong OrdId;
        public ulong ClOrdId;
        public ulong RequestId;
        public int SecurityId;
        public OrderTimeInForce TimeInForce;
        public int UnitContractCnt;
        public string Symbol;
    }

    
    // private void TestOrderRequestNewOrder()
    // {
    //     var buyLimit = new OrderRequestNewOrderTemplate();
    //     var msg = buyLimit.Prepopulate();
    //     msg.RequestId = 12345;
    //     msg.ClOrdId = 12345;
    //     msg.SenderId = "Augenix";
    //     msg.PartyListId = 12152016;
    //     msg.Location = "USA";
    //     msg.SecurityId = 12345;
    //     msg.DisplayQty = 1;
    //     msg.MinQty = 1;
    //     msg.Side = OrderSide.buy;
    //     msg.OrdType = OrderKind.limit;
    //     msg.TimeInForce = OrderTimeInForce.day;
    //     var w = msg.ExpireDate.Writer();
    //     w.TimeNs = 1111;
    //     var msg2 = buyLimit.Populate();
    //     msg2.OrderQty = 1;
    //     msg2.Price = 1000.00;
    //     w  = msg2.ExtractTimestamp.Writer();
    //     w.TimeNs = 2222;

    //     var arenaMeta = buyLimit.Meta;
    //     arenaMeta.IncrementWordCount(0, 2);
    //     var frame = buyLimit.GetArenaAsSpan.Slice(7, arenaMeta.TotalWords);
    //     var meta = new SegmentMeta
    //     {
    //         SegmentCount = arenaMeta.SegmentCount,
    //     };
    //
    //     for (var i = 0; i < meta.SegmentCount; i++)
    //     {
    //         meta.SetWordCount(i, arenaMeta.GetWordCount(i));
    //         meta.TotalWords += arenaMeta.GetWordCount(i);
    //     }
    //     
    //     FrameInspector.DumpFrame(frame);
    //     Console.WriteLine($"total words: {meta.TotalWords}");
    //     
    //     var decode = new OrderRequestNewOrderDecoder(frame, meta, 0, 3);
    //     //Console.WriteLine($"New Order Decoder Type: price {decode.Price} qty {decode.OrderQty} type {decode.OrdType} TIF: {decode.TimeInForce} ");
    //     Console.WriteLine($"New Order Decoder " +
    //                       $"{decode.Price}, " +
    //                       $"{decode.OrderQty}, " +
    //                       $"{decode.SecurityId}, " +
    //                       $"{decode.DisplayQty}, " +
    //                       $"{decode.OrdType}, " +
    //                       $"{decode.Side}, " +
    //                       $"{decode.Location}, " +
    //                       $"{decode.SenderId} " +
    //                       $"{decode.PartyListId}, " +
    //                       $"{decode.ExpireDate.Reader().TimeNs}, " +
    //                       $"{decode.ExtractTimestamp.Reader().TimeNs}");
    //     
    //     var msg3 = buyLimit.Populate();
    //     msg3.OrderQty = 10;
    //     msg3.Price = 2000.00;
    //     var w1  = msg3.ExtractTimestamp.Writer();
    //     w1.TimeNs = 3333;
    //     var frame1 = buyLimit.GetArenaAsSpan.Slice(7, arenaMeta.TotalWords);
    //     meta = new SegmentMeta
    //     {
    //         SegmentCount = arenaMeta.SegmentCount,
    //     };
    //
    //     for (var i = 0; i < meta.SegmentCount; i++)
    //     {
    //         meta.SetWordCount(i, arenaMeta.GetWordCount(i));
    //         meta.TotalWords += arenaMeta.GetWordCount(i);
    //     }
    //     
    //     FrameInspector.DumpFrame(frame1);
    //     Console.WriteLine($"total words: {meta.TotalWords}");
    //     
    //     var decode1 = new OrderRequestNewOrderDecoder(frame1, meta, 0, 3);
    //     Console.WriteLine($"New Order Decoder " +
    //                       $"{decode1.Price}, " +
    //                       $"{decode1.OrderQty}, " +
    //                       $"{decode1.SecurityId}, " +
    //                       $"{decode1.DisplayQty}, " +
    //                       $"{decode1.OrdType}, " +
    //                       $"{decode1.Side}, " +
    //                       $"{decode1.Location}, " +
    //                       $"{decode1.SenderId} " +
    //                       $"{decode1.PartyListId}, " +
    //                       $"{decode1.ExpireDate.Reader().TimeNs}, " +
    //                       $"{decode1.ExtractTimestamp.Reader().TimeNs}");
    // }

    private void Test_ReadText()
    {
        var arena = new SegmentArena();
        var seg0 = arena.GetSegment(0);
        var dataSectionWords = 100;
        var pointerSectionWords = 20;
        var root = 0UL;
        root |= (ulong)((long)pointerSectionWords << 48);
        root |= (ulong)((long)dataSectionWords << 32);
        seg0[0] = root;
        arena.IncrementWordCount(0, 1);
        var baseIndex = arena.GetWordCount(0);
        var offset = baseIndex + dataSectionWords;
        arena.IncrementWordCount(0, dataSectionWords + pointerSectionWords);
        var textCount = pointerSectionWords;
        for (var i = 0; i < textCount; i++)
        {
            EncodeHelpers.WriteText(arena, 0, offset + i, "Hello World");
        }
        
        FrameInspector.DumpSegments(arena);
        
        var frame = arena.GetAllSegments;
        var meta = new SegmentMeta
        {
            SegmentCount = arena.SegmentCount,
            TotalWords = arena.TotalWords,
        };
        for (var i = 0; i < meta.SegmentCount; i++)
        {
            meta.SetWordCount(i, arena.GetWordCount(i));
        }
        
        for (int i = 0; i < textCount; i++)
        {
            try
            {
                var s = DecodeHelpers.ReadText(frame, meta, 0, offset + i);
                Console.WriteLine($"Read Text: {s}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message} Name: {ex.GetType().Name} StackTrace: {ex.StackTrace}");
            }

        }
    }
    
    private static void Test_ReadList_Text()
    {
        var arena = new SegmentArena();
        var seg0 = arena.GetSegment(0);
        var dataSectionWords = 100;
        var pointerSectionWords = 5;
        var root = 0UL;
        root |= (ulong)((long)pointerSectionWords << 48);
        root |= (ulong)((long)dataSectionWords << 32);
        seg0[0] = root;
        arena.IncrementWordCount(0,1);
        var baseIndex = arena.GetWordCount(0);
        var offset = baseIndex + dataSectionWords;
        arena.IncrementWordCount(0, dataSectionWords + pointerSectionWords);

        string[] textList =
            ["Test Message 111", "Test Message 222", "Test Message 333", "Test Message 444", "Test Message 555"];

        for (var i = 0; i < pointerSectionWords; i++)
        {
            EncodeHelpers.WriteList_Text(arena, 0, offset + i,textList);
        }
            
        FrameInspector.DumpSegments(arena);
        
        var frame = arena.GetAllSegments;
        var meta = new SegmentMeta
        {
            SegmentCount = arena.SegmentCount,
            TotalWords = arena.TotalWords,
        };
        
        for (var i = 0; i < meta.SegmentCount; i++)
        {
            meta.SetWordCount(i, arena.GetWordCount(i));
        }

        for (var i = 0; i < pointerSectionWords; i++)
        {
            var result = DecodeHelpers.ReadList_Text(frame, meta, 0, offset + i);

            foreach (var text in result)
            {
                Console.WriteLine($"Read Text List Result {text}");
            }
        }
    }
    
    private static void Test_ReadList_Primitive()
    {
        var arena = new SegmentArena();
        var seg0 = arena.GetSegment(0);
        var dataSectionWords = 100;
        var pointerSectionWords = 6;
        var root = 0UL;
        root |= (ulong)((long)pointerSectionWords << 48);
        root |= (ulong)((long)dataSectionWords << 32);
        seg0[0] = root;
        arena.IncrementWordCount(0, 1);
        var baseIndex = arena.GetWordCount(0);
        var offset = baseIndex + dataSectionWords;
        arena.IncrementWordCount(0, dataSectionWords + pointerSectionWords);
        int[] intList = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        double[] doubleList = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        var slot = 0;
        for (var i = 0; i < pointerSectionWords/2; i++)
        {
            EncodeHelpers.WriteList_Primitive<int>(arena, 0, offset + slot++, intList);
            EncodeHelpers.WriteList_Primitive<double>(arena, 0, offset + slot++, doubleList);
        }
        FrameInspector.DumpSegments(arena);
        var frame = arena.GetAllSegments;
        var meta = new SegmentMeta
        {
            SegmentCount = arena.SegmentCount,
            TotalWords = arena.TotalWords,
        };
        for (var i = 0; i < meta.SegmentCount; i++)
        {
            meta.SetWordCount(i, arena.GetWordCount(i));
        }
        var sb = new StringBuilder();
        slot = 0;
        for (var i = 0; i < pointerSectionWords/2; i++)
        {
            sb.Clear();
            sb.Append($"Int values for slot-{slot}: ");
            var intResult = DecodeHelpers.ReadList_Primitive<int>(frame, meta, 0, offset + slot++);
            foreach (var t in intResult) sb.Append($"{t} ");
            sb.AppendLine();
            sb.Append($"Double values for slot-{slot}: ");
            var doubleResult = DecodeHelpers.ReadList_Primitive<double>(frame, meta, 0, offset + slot++);
            foreach (var t in doubleResult) sb.Append($"{t} ");
            sb.AppendLine();
            Console.WriteLine(sb.ToString());
        }
    }
}
