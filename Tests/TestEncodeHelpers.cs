using System.Runtime.CompilerServices;
using SchemaX_CodeGen.Generated.OrderManagerApi;
using System.Text;

namespace SchemaX_CodeGen.Tests
{
    public class TestEncodeHelpers
    {
        public void Run()
        {
            //Test_WriteText_FarPointer();
            //Test_WriteStruct_FarPointer();
            //Test_WriteText_List_FarPointer();
            //Test_WritePrimitive_List_FarPointer();
            Test_WriteStruct_List_FarPointer();
            
        }

        private void Test_WriteText_FarPointer()
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
            
            for (int i = 0; i < textCount; i++)
            {
                var s = EncodeHelpers.ReadText(arena, 0, offset + i);
                Console.WriteLine(s);
            }
        }
        private static void Test_WriteStruct_FarPointer()
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
                var w = new WorkingOrder(arena, cursor.segmentIndex, cursor.structIndex)
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
            
            for (int i = 0; i < sCount; i++)
            {
                var cursor = EncodeHelpers.GetStructCursor(arena, 0, offset + i);
                var w = new WorkingOrder(arena, cursor.segmentIndex, cursor.structIndex);
                Console.WriteLine($"LimitPrice: {w.LimitPrice}  Quantity: {w.Quantity} Side {w.Side} ordid {w.OrdId} clordid {w.ClOrdId} requestid {w.RequestId} timeinforce {w.TimeInForce} unitcontrcnt {w.UnitContractCnt} symbol {w.Symbol}");
            }
        } 
        public  ref struct WorkingOrder
        {
            private readonly SegmentArena arena;
            private readonly Span<ulong> buffer;
            private const int DataWords = 7;
            private const int PointerWords = 1;
            private readonly int offset;
            private readonly int segmentIndex;

            public WorkingOrder(SegmentArena arena, int segmentIndex, int structIndex)
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
        
        private static void Test_WriteStruct_List_FarPointer()
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
            var wos = new List<WorkingOrderMsg>();
            for (var i = 0; i < wCount; i++)
            {
                wos.Add(new WorkingOrderMsg
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
            
            var msgCount = wos.Count;
            for (var i = 0; i < msgCount; i++)
            {
                var cursor = 
                    EncodeHelpers.AllocateList_Struct(arena, segmentIndex, offset + i, msgCount, 7, 1);
                for (int j = 0; j < wCount; j++)
                {
                    var src = wos[j];
                    var elementCursor = EncodeHelpers.GetListElementCursor(arena, cursor.segmentIndex, cursor.tagIndex, j);
                    var w = new WorkingOrder(arena, elementCursor.segmentIndex, elementCursor.elementIndex);
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
            for (var i = 0; i < msgCount; i++)
            {
                for (var j = 0; j < wCount; j++)
                {
                    var cursor = EncodeHelpers.GetStructCursor(arena, segmentIndex, offset + i);
                    var elementCursor = EncodeHelpers.GetListElementCursor(arena, cursor.segmentIndex, cursor.structIndex, j);
                    var w = new WorkingOrder(arena, elementCursor.segmentIndex, elementCursor.elementIndex);
                    Console.WriteLine(
                        $"Get Target price: {w.LimitPrice} qty {w.Quantity} side {w.Side} order {w.OrdId} " +
                        $"clord {w.ClOrdId} request {w.RequestId} sec {w.SecurityId} time {w.TimeInForce} " +
                        $"unit-contract {w.UnitContractCnt} symbol {w.Symbol}");
                }
            }
        }
        

        private struct WorkingOrderMsg
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


        private static void Test_WritePrimitive_List_FarPointer()
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
            var sb = new StringBuilder();
            slot = 0;
            for (var i = 0; i < pointerSectionWords/2; i++)
            {
                sb.Clear();
                sb.Append($"Int values for slot-{slot}: ");
                var intResult = EncodeHelpers.ReadList_Primitive<int>(arena, 0, offset + slot++);
                foreach (var t in intResult) sb.Append($"{t} ");
                sb.AppendLine();
                sb.Append($"Double values for slot-{slot}: ");
                var doubleResult = EncodeHelpers.ReadList_Primitive<double>(arena, 0, offset + slot++);
                foreach (var t in doubleResult) sb.Append($"{t} ");
                sb.AppendLine();
                Console.WriteLine(sb.ToString());
            }
        }

        private static void Test_WriteText_List_FarPointer()
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

            for (var i = 0; i < pointerSectionWords; i++)
            {
                var result = EncodeHelpers.ReadList_Text(arena, 0, offset + i);

                foreach (var text in result)
                {
                    Console.WriteLine($"Read Text List Result {text}");
                }
            }
        }
    }
}
