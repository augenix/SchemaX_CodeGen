using System.Runtime.CompilerServices;
using SchemaX_CodeGen.Generated.OrderManagerApi;

namespace SchemaX_CodeGen.Tests;

public class TestRequestTemplates()
{
    // //private readonly OrderRequestNewOrderTemplate buyLimit = new();
    // public void Run()
    // {
    //     PrePopulateOrderRequestTemplate(1);
    //     HotPopulateOrderRequestTemplate(1);
    //     ViewOrderRequestTemplate();
    //     ViewOrderRequestFrame();
    // }
    //
    // [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    // private void PrePopulateOrderRequestTemplate(int count)
    // {
    //     for (var i = 0; i < count; i++)
    //     {
    //         var msg = buyLimit.Populate();
    //         msg.RequestId = 12345;
    //         msg.ClOrdId = 12345;
    //         msg.SenderId = "Augenix";
    //         msg.PartyListId = 12152016;
    //         msg.Location = "USA";
    //         msg.SecurityId = 12345;
    //         msg.DisplayQty = 1;
    //         msg.MinQty = 1;
    //         msg.Side = OrderSide.buy;
    //         msg.OrdType = OrderKind.limit;
    //         var w = msg.ExpireDate.Writer();
    //         w.TimeNs = 1111;
    //     } 
    // }
    //
    // [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    // private void HotPopulateOrderRequestTemplate(int count)
    // {
    //     for (var i = 0; i < count; i++)
    //     {
    //         var msg = buyLimit.Populate();
    //         msg.OrderQty = 1;
    //         msg.Price = 1000.00;
    //         var w  = msg.ExtractTimestamp.Writer();
    //         w.TimeNs = 2222;
    //     } 
    // }
    // [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    // private void ViewOrderRequestTemplate()
    // {
    //     // var msg = buyLimit.Populate();
    //     // Console.WriteLine($"New Order Request: " +
    //     //                   $"{msg.RequestId}, " +
    //     //                   $"{msg.ClOrdId}, " +
    //     //                   $"{msg.SenderId}, " +
    //     //                   $"{msg.PartyListId}, " +
    //     //                   $"{msg.Location}, " +
    //     //                   $"{msg.SecurityId}, " +
    //     //                   $"{msg.DisplayQty}, " +
    //     //                   $"{msg.MinQty}, " +
    //     //                   $"{msg.Side}," +
    //     //                   $"{msg.OrdType}," +
    //     //                   $"{msg.ExpireDate.Reader().TimeNs}, " +
    //     //                   $"{msg.ExtractTimestamp.Reader().TimeNs} "); 
    // }
    //
    // private void ViewOrderRequestFrame()
    // {
    //     var frame = buyLimit.GetArenaAsSpan;
    //     FrameInspector.DumpFrame(frame);
    // }
}