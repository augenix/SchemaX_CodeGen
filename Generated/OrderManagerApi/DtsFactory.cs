using System;
using System.Runtime.CompilerServices;

namespace SchemaX_CodeGen.Generated.OrderManagerApi;

public static class DtsFactory
{
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref RiskAccountingLimitDts msg, in RiskAccountingLimitDecoder reader)
    {
        msg.Account.Set(reader.Account);
        msg.UnseenPnlLossUb = reader.UnseenPnlLossUb;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref OrderReportBusinessRejectDts msg, in OrderReportBusinessRejectDecoder reader)
    {
        msg.RejectReason = reader.RejectReason;
        msg.RefTagId = reader.RefTagId;
        msg.RefMsgType = reader.RefMsgType;
        msg.RejectDescription.Set(reader.RejectDescription);
        msg.RequestId = reader.RequestId;
        msg.SenderId.Set(reader.SenderId);
        msg.Location.Set(reader.Location);
        msg.ManualOrderInd = reader.ManualOrderInd;
        msg.PartyListId = reader.PartyListId;
        msg.IsAResend = reader.IsAResend;
        var ExchangeTimestampStruct = reader.ExchangeTimestamp.Reader();
        FromDecoder(ref msg.ExchangeTimestamp, in ExchangeTimestampStruct);
        var SendingTimestampStruct = reader.SendingTimestamp.Reader();
        FromDecoder(ref msg.SendingTimestamp, in SendingTimestampStruct);
        var ReceiptTimestampStruct = reader.ReceiptTimestamp.Reader();
        FromDecoder(ref msg.ReceiptTimestamp, in ReceiptTimestampStruct);
        var ExtractTimestampStruct = reader.ExtractTimestamp.Reader();
        FromDecoder(ref msg.ExtractTimestamp, in ExtractTimestampStruct);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref OrderReportExecRptNewOrderDts msg, in OrderReportExecRptNewOrderDecoder reader)
    {
        msg.RequestId = reader.RequestId;
        msg.Price = reader.Price;
        msg.OrderQty = reader.OrderQty;
        msg.StopPx = reader.StopPx;
        msg.MinQty = reader.MinQty;
        msg.CumQty = reader.CumQty;
        msg.DisplayQty = reader.DisplayQty;
        var ExpireDateStruct = reader.ExpireDate.Reader();
        FromDecoder(ref msg.ExpireDate, in ExpireDateStruct);
        msg.TimeInForce = reader.TimeInForce;
        msg.SecurityId = reader.SecurityId;
        msg.Side = reader.Side;
        msg.OrdType = reader.OrdType;
        msg.ExecReportId.Set(reader.ExecReportId);
        msg.ClOrdId = reader.ClOrdId;
        msg.OrdId = reader.OrdId;
        msg.SenderId.Set(reader.SenderId);
        msg.Location.Set(reader.Location);
        msg.ManualOrderInd = reader.ManualOrderInd;
        msg.PartyListId = reader.PartyListId;
        msg.IsAResend = reader.IsAResend;
        var ExchangeTimestampStruct = reader.ExchangeTimestamp.Reader();
        FromDecoder(ref msg.ExchangeTimestamp, in ExchangeTimestampStruct);
        var SendingTimestampStruct = reader.SendingTimestamp.Reader();
        FromDecoder(ref msg.SendingTimestamp, in SendingTimestampStruct);
        var ReceiptTimestampStruct = reader.ReceiptTimestamp.Reader();
        FromDecoder(ref msg.ReceiptTimestamp, in ReceiptTimestampStruct);
        var ExtractTimestampStruct = reader.ExtractTimestamp.Reader();
        FromDecoder(ref msg.ExtractTimestamp, in ExtractTimestampStruct);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref OrderReportExecRptModifyDts msg, in OrderReportExecRptModifyDecoder reader)
    {
        msg.LeavesQty = reader.LeavesQty;
        msg.RequestId = reader.RequestId;
        msg.Price = reader.Price;
        msg.OrderQty = reader.OrderQty;
        msg.StopPx = reader.StopPx;
        msg.MinQty = reader.MinQty;
        msg.CumQty = reader.CumQty;
        msg.DisplayQty = reader.DisplayQty;
        var ExpireDateStruct = reader.ExpireDate.Reader();
        FromDecoder(ref msg.ExpireDate, in ExpireDateStruct);
        msg.TimeInForce = reader.TimeInForce;
        msg.SecurityId = reader.SecurityId;
        msg.Side = reader.Side;
        msg.OrdType = reader.OrdType;
        msg.ExecReportId.Set(reader.ExecReportId);
        msg.ClOrdId = reader.ClOrdId;
        msg.OrdId = reader.OrdId;
        msg.SenderId.Set(reader.SenderId);
        msg.Location.Set(reader.Location);
        msg.ManualOrderInd = reader.ManualOrderInd;
        msg.PartyListId = reader.PartyListId;
        msg.IsAResend = reader.IsAResend;
        var ExchangeTimestampStruct = reader.ExchangeTimestamp.Reader();
        FromDecoder(ref msg.ExchangeTimestamp, in ExchangeTimestampStruct);
        var SendingTimestampStruct = reader.SendingTimestamp.Reader();
        FromDecoder(ref msg.SendingTimestamp, in SendingTimestampStruct);
        var ReceiptTimestampStruct = reader.ReceiptTimestamp.Reader();
        FromDecoder(ref msg.ReceiptTimestamp, in ReceiptTimestampStruct);
        var ExtractTimestampStruct = reader.ExtractTimestamp.Reader();
        FromDecoder(ref msg.ExtractTimestamp, in ExtractTimestampStruct);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref OrderReportExecRptCancelDts msg, in OrderReportExecRptCancelDecoder reader)
    {
        msg.CancelReason = reader.CancelReason;
        msg.RequestId = reader.RequestId;
        msg.Price = reader.Price;
        msg.OrderQty = reader.OrderQty;
        msg.StopPx = reader.StopPx;
        msg.MinQty = reader.MinQty;
        msg.CumQty = reader.CumQty;
        msg.DisplayQty = reader.DisplayQty;
        var ExpireDateStruct = reader.ExpireDate.Reader();
        FromDecoder(ref msg.ExpireDate, in ExpireDateStruct);
        msg.TimeInForce = reader.TimeInForce;
        msg.SecurityId = reader.SecurityId;
        msg.Side = reader.Side;
        msg.OrdType = reader.OrdType;
        msg.ExecReportId.Set(reader.ExecReportId);
        msg.ClOrdId = reader.ClOrdId;
        msg.OrdId = reader.OrdId;
        msg.SenderId.Set(reader.SenderId);
        msg.Location.Set(reader.Location);
        msg.ManualOrderInd = reader.ManualOrderInd;
        msg.PartyListId = reader.PartyListId;
        msg.IsAResend = reader.IsAResend;
        var ExchangeTimestampStruct = reader.ExchangeTimestamp.Reader();
        FromDecoder(ref msg.ExchangeTimestamp, in ExchangeTimestampStruct);
        var SendingTimestampStruct = reader.SendingTimestamp.Reader();
        FromDecoder(ref msg.SendingTimestamp, in SendingTimestampStruct);
        var ReceiptTimestampStruct = reader.ReceiptTimestamp.Reader();
        FromDecoder(ref msg.ReceiptTimestamp, in ReceiptTimestampStruct);
        var ExtractTimestampStruct = reader.ExtractTimestamp.Reader();
        FromDecoder(ref msg.ExtractTimestamp, in ExtractTimestampStruct);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref OrderReportExecRptStatusDts msg, in OrderReportExecRptStatusDecoder reader)
    {
        msg.OrdStatus = reader.OrdStatus;
        msg.LeavesQty = reader.LeavesQty;
        msg.RejectDescription.Set(reader.RejectDescription);
        msg.IsLastStatusRequested = reader.IsLastStatusRequested;
        msg.StatusReqId = reader.StatusReqId;
        msg.RequestId = reader.RequestId;
        msg.Price = reader.Price;
        msg.OrderQty = reader.OrderQty;
        msg.StopPx = reader.StopPx;
        msg.MinQty = reader.MinQty;
        msg.CumQty = reader.CumQty;
        msg.DisplayQty = reader.DisplayQty;
        var ExpireDateStruct = reader.ExpireDate.Reader();
        FromDecoder(ref msg.ExpireDate, in ExpireDateStruct);
        msg.TimeInForce = reader.TimeInForce;
        msg.SecurityId = reader.SecurityId;
        msg.Side = reader.Side;
        msg.OrdType = reader.OrdType;
        msg.ExecReportId.Set(reader.ExecReportId);
        msg.ClOrdId = reader.ClOrdId;
        msg.OrdId = reader.OrdId;
        msg.SenderId.Set(reader.SenderId);
        msg.Location.Set(reader.Location);
        msg.ManualOrderInd = reader.ManualOrderInd;
        msg.PartyListId = reader.PartyListId;
        msg.IsAResend = reader.IsAResend;
        var ExchangeTimestampStruct = reader.ExchangeTimestamp.Reader();
        FromDecoder(ref msg.ExchangeTimestamp, in ExchangeTimestampStruct);
        var SendingTimestampStruct = reader.SendingTimestamp.Reader();
        FromDecoder(ref msg.SendingTimestamp, in SendingTimestampStruct);
        var ReceiptTimestampStruct = reader.ReceiptTimestamp.Reader();
        FromDecoder(ref msg.ReceiptTimestamp, in ReceiptTimestampStruct);
        var ExtractTimestampStruct = reader.ExtractTimestamp.Reader();
        FromDecoder(ref msg.ExtractTimestamp, in ExtractTimestampStruct);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref OrderReportExecRptTradeOutrightDts msg, in OrderReportExecRptTradeOutrightDecoder reader)
    {
        msg.FillStatus = reader.FillStatus;
        msg.IsAggressor = reader.IsAggressor;
        msg.LeavesQty = reader.LeavesQty;
        msg.RequestId = reader.RequestId;
        msg.Price = reader.Price;
        msg.OrderQty = reader.OrderQty;
        msg.CumQty = reader.CumQty;
        msg.FillPrice = reader.FillPrice;
        msg.FillQty = reader.FillQty;
        msg.SecurityExecId = reader.SecurityExecId;
        var TradeDateStruct = reader.TradeDate.Reader();
        FromDecoder(ref msg.TradeDate, in TradeDateStruct);
        msg.SecurityId = reader.SecurityId;
        msg.Side = reader.Side;
        msg.OrdType = reader.OrdType;
        msg.ExecReportId.Set(reader.ExecReportId);
        msg.ClOrdId = reader.ClOrdId;
        msg.OrdId = reader.OrdId;
        msg.SenderId.Set(reader.SenderId);
        msg.Location.Set(reader.Location);
        msg.ManualOrderInd = reader.ManualOrderInd;
        msg.PartyListId = reader.PartyListId;
        msg.IsAResend = reader.IsAResend;
        var ExchangeTimestampStruct = reader.ExchangeTimestamp.Reader();
        FromDecoder(ref msg.ExchangeTimestamp, in ExchangeTimestampStruct);
        var SendingTimestampStruct = reader.SendingTimestamp.Reader();
        FromDecoder(ref msg.SendingTimestamp, in SendingTimestampStruct);
        var ReceiptTimestampStruct = reader.ReceiptTimestamp.Reader();
        FromDecoder(ref msg.ReceiptTimestamp, in ReceiptTimestampStruct);
        var ExtractTimestampStruct = reader.ExtractTimestamp.Reader();
        FromDecoder(ref msg.ExtractTimestamp, in ExtractTimestampStruct);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref OrderReportExecRptTradeSpreadDts msg, in OrderReportExecRptTradeSpreadDecoder reader)
    {
        msg.NumLegFills = reader.NumLegFills;
        msg.FillStatus = reader.FillStatus;
        msg.IsAggressor = reader.IsAggressor;
        msg.LeavesQty = reader.LeavesQty;
        msg.RequestId = reader.RequestId;
        msg.Price = reader.Price;
        msg.OrderQty = reader.OrderQty;
        msg.CumQty = reader.CumQty;
        msg.FillPrice = reader.FillPrice;
        msg.FillQty = reader.FillQty;
        msg.SecurityExecId = reader.SecurityExecId;
        var TradeDateStruct = reader.TradeDate.Reader();
        FromDecoder(ref msg.TradeDate, in TradeDateStruct);
        msg.SecurityId = reader.SecurityId;
        msg.Side = reader.Side;
        msg.OrdType = reader.OrdType;
        msg.ExecReportId.Set(reader.ExecReportId);
        msg.ClOrdId = reader.ClOrdId;
        msg.OrdId = reader.OrdId;
        msg.SenderId.Set(reader.SenderId);
        msg.Location.Set(reader.Location);
        msg.ManualOrderInd = reader.ManualOrderInd;
        msg.PartyListId = reader.PartyListId;
        msg.IsAResend = reader.IsAResend;
        var ExchangeTimestampStruct = reader.ExchangeTimestamp.Reader();
        FromDecoder(ref msg.ExchangeTimestamp, in ExchangeTimestampStruct);
        var SendingTimestampStruct = reader.SendingTimestamp.Reader();
        FromDecoder(ref msg.SendingTimestamp, in SendingTimestampStruct);
        var ReceiptTimestampStruct = reader.ReceiptTimestamp.Reader();
        FromDecoder(ref msg.ReceiptTimestamp, in ReceiptTimestampStruct);
        var ExtractTimestampStruct = reader.ExtractTimestamp.Reader();
        FromDecoder(ref msg.ExtractTimestamp, in ExtractTimestampStruct);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref OrderReportExecRptTradeSpreadLegDts msg, in OrderReportExecRptTradeSpreadLegDecoder reader)
    {
        msg.CumQty = reader.CumQty;
        msg.FillStatus = reader.FillStatus;
        msg.FillPrice = reader.FillPrice;
        msg.FillQty = reader.FillQty;
        msg.SecurityExecId = reader.SecurityExecId;
        var TradeDateStruct = reader.TradeDate.Reader();
        FromDecoder(ref msg.TradeDate, in TradeDateStruct);
        msg.SecurityId = reader.SecurityId;
        msg.Side = reader.Side;
        msg.OrdType = reader.OrdType;
        msg.ExecReportId.Set(reader.ExecReportId);
        msg.ClOrdId = reader.ClOrdId;
        msg.OrdId = reader.OrdId;
        msg.SenderId.Set(reader.SenderId);
        msg.Location.Set(reader.Location);
        msg.ManualOrderInd = reader.ManualOrderInd;
        msg.PartyListId = reader.PartyListId;
        msg.IsAResend = reader.IsAResend;
        var ExchangeTimestampStruct = reader.ExchangeTimestamp.Reader();
        FromDecoder(ref msg.ExchangeTimestamp, in ExchangeTimestampStruct);
        var SendingTimestampStruct = reader.SendingTimestamp.Reader();
        FromDecoder(ref msg.SendingTimestamp, in SendingTimestampStruct);
        var ReceiptTimestampStruct = reader.ReceiptTimestamp.Reader();
        FromDecoder(ref msg.ReceiptTimestamp, in ReceiptTimestampStruct);
        var ExtractTimestampStruct = reader.ExtractTimestamp.Reader();
        FromDecoder(ref msg.ExtractTimestamp, in ExtractTimestampStruct);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref OrderReportExecRptEliminationDts msg, in OrderReportExecRptEliminationDecoder reader)
    {
        msg.RequestId = reader.RequestId;
        msg.Price = reader.Price;
        msg.OrderQty = reader.OrderQty;
        msg.StopPx = reader.StopPx;
        msg.MinQty = reader.MinQty;
        msg.CumQty = reader.CumQty;
        msg.DisplayQty = reader.DisplayQty;
        var ExpireDateStruct = reader.ExpireDate.Reader();
        FromDecoder(ref msg.ExpireDate, in ExpireDateStruct);
        msg.TimeInForce = reader.TimeInForce;
        msg.SecurityId = reader.SecurityId;
        msg.Side = reader.Side;
        msg.OrdType = reader.OrdType;
        msg.ExecReportId.Set(reader.ExecReportId);
        msg.ClOrdId = reader.ClOrdId;
        msg.OrdId = reader.OrdId;
        msg.SenderId.Set(reader.SenderId);
        msg.Location.Set(reader.Location);
        msg.ManualOrderInd = reader.ManualOrderInd;
        msg.PartyListId = reader.PartyListId;
        msg.IsAResend = reader.IsAResend;
        var ExchangeTimestampStruct = reader.ExchangeTimestamp.Reader();
        FromDecoder(ref msg.ExchangeTimestamp, in ExchangeTimestampStruct);
        var SendingTimestampStruct = reader.SendingTimestamp.Reader();
        FromDecoder(ref msg.SendingTimestamp, in SendingTimestampStruct);
        var ReceiptTimestampStruct = reader.ReceiptTimestamp.Reader();
        FromDecoder(ref msg.ReceiptTimestamp, in ReceiptTimestampStruct);
        var ExtractTimestampStruct = reader.ExtractTimestamp.Reader();
        FromDecoder(ref msg.ExtractTimestamp, in ExtractTimestampStruct);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref OrderReportExecRptRejectDts msg, in OrderReportExecRptRejectDecoder reader)
    {
        msg.RejectKind = reader.RejectKind;
        msg.RejectCode = reader.RejectCode;
        msg.RejectDescription.Set(reader.RejectDescription);
        msg.RejectingPriceBand = reader.RejectingPriceBand;
        msg.RequestId = reader.RequestId;
        msg.Price = reader.Price;
        msg.OrderQty = reader.OrderQty;
        msg.StopPx = reader.StopPx;
        msg.MinQty = reader.MinQty;
        msg.CumQty = reader.CumQty;
        msg.DisplayQty = reader.DisplayQty;
        var ExpireDateStruct = reader.ExpireDate.Reader();
        FromDecoder(ref msg.ExpireDate, in ExpireDateStruct);
        msg.TimeInForce = reader.TimeInForce;
        msg.SecurityId = reader.SecurityId;
        msg.Side = reader.Side;
        msg.OrdType = reader.OrdType;
        msg.ExecReportId.Set(reader.ExecReportId);
        msg.ClOrdId = reader.ClOrdId;
        msg.OrdId = reader.OrdId;
        msg.SenderId.Set(reader.SenderId);
        msg.Location.Set(reader.Location);
        msg.ManualOrderInd = reader.ManualOrderInd;
        msg.PartyListId = reader.PartyListId;
        msg.IsAResend = reader.IsAResend;
        var ExchangeTimestampStruct = reader.ExchangeTimestamp.Reader();
        FromDecoder(ref msg.ExchangeTimestamp, in ExchangeTimestampStruct);
        var SendingTimestampStruct = reader.SendingTimestamp.Reader();
        FromDecoder(ref msg.SendingTimestamp, in SendingTimestampStruct);
        var ReceiptTimestampStruct = reader.ReceiptTimestamp.Reader();
        FromDecoder(ref msg.ReceiptTimestamp, in ReceiptTimestampStruct);
        var ExtractTimestampStruct = reader.ExtractTimestamp.Reader();
        FromDecoder(ref msg.ExtractTimestamp, in ExtractTimestampStruct);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref OrderReportExecRptTradeAddendumOutrightDts msg, in OrderReportExecRptTradeAddendumOutrightDecoder reader)
    {
        msg.AddendumKind = reader.AddendumKind;
        msg.FillPrice = reader.FillPrice;
        msg.FillQty = reader.FillQty;
        msg.SecurityExecId = reader.SecurityExecId;
        var TradeDateStruct = reader.TradeDate.Reader();
        FromDecoder(ref msg.TradeDate, in TradeDateStruct);
        msg.SecurityId = reader.SecurityId;
        msg.Side = reader.Side;
        msg.OrdType = reader.OrdType;
        msg.ExecReportId.Set(reader.ExecReportId);
        msg.ClOrdId = reader.ClOrdId;
        msg.OrdId = reader.OrdId;
        msg.SenderId.Set(reader.SenderId);
        msg.Location.Set(reader.Location);
        msg.ManualOrderInd = reader.ManualOrderInd;
        msg.PartyListId = reader.PartyListId;
        msg.IsAResend = reader.IsAResend;
        var ExchangeTimestampStruct = reader.ExchangeTimestamp.Reader();
        FromDecoder(ref msg.ExchangeTimestamp, in ExchangeTimestampStruct);
        var SendingTimestampStruct = reader.SendingTimestamp.Reader();
        FromDecoder(ref msg.SendingTimestamp, in SendingTimestampStruct);
        var ReceiptTimestampStruct = reader.ReceiptTimestamp.Reader();
        FromDecoder(ref msg.ReceiptTimestamp, in ReceiptTimestampStruct);
        var ExtractTimestampStruct = reader.ExtractTimestamp.Reader();
        FromDecoder(ref msg.ExtractTimestamp, in ExtractTimestampStruct);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref OrderReportExecRptTradeAddendumSpreadDts msg, in OrderReportExecRptTradeAddendumSpreadDecoder reader)
    {
        msg.NumLegFills = reader.NumLegFills;
        msg.AddendumKind = reader.AddendumKind;
        msg.FillPrice = reader.FillPrice;
        msg.FillQty = reader.FillQty;
        msg.SecurityExecId = reader.SecurityExecId;
        var TradeDateStruct = reader.TradeDate.Reader();
        FromDecoder(ref msg.TradeDate, in TradeDateStruct);
        msg.SecurityId = reader.SecurityId;
        msg.Side = reader.Side;
        msg.OrdType = reader.OrdType;
        msg.ExecReportId.Set(reader.ExecReportId);
        msg.ClOrdId = reader.ClOrdId;
        msg.OrdId = reader.OrdId;
        msg.SenderId.Set(reader.SenderId);
        msg.Location.Set(reader.Location);
        msg.ManualOrderInd = reader.ManualOrderInd;
        msg.PartyListId = reader.PartyListId;
        msg.IsAResend = reader.IsAResend;
        var ExchangeTimestampStruct = reader.ExchangeTimestamp.Reader();
        FromDecoder(ref msg.ExchangeTimestamp, in ExchangeTimestampStruct);
        var SendingTimestampStruct = reader.SendingTimestamp.Reader();
        FromDecoder(ref msg.SendingTimestamp, in SendingTimestampStruct);
        var ReceiptTimestampStruct = reader.ReceiptTimestamp.Reader();
        FromDecoder(ref msg.ReceiptTimestamp, in ReceiptTimestampStruct);
        var ExtractTimestampStruct = reader.ExtractTimestamp.Reader();
        FromDecoder(ref msg.ExtractTimestamp, in ExtractTimestampStruct);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref OrderReportExecRptTradeAddendumSpreadLegDts msg, in OrderReportExecRptTradeAddendumSpreadLegDecoder reader)
    {
        msg.AddendumKind = reader.AddendumKind;
        msg.FillPrice = reader.FillPrice;
        msg.FillQty = reader.FillQty;
        msg.SecurityExecId = reader.SecurityExecId;
        var TradeDateStruct = reader.TradeDate.Reader();
        FromDecoder(ref msg.TradeDate, in TradeDateStruct);
        msg.SecurityId = reader.SecurityId;
        msg.Side = reader.Side;
        msg.OrdType = reader.OrdType;
        msg.ExecReportId.Set(reader.ExecReportId);
        msg.ClOrdId = reader.ClOrdId;
        msg.OrdId = reader.OrdId;
        msg.SenderId.Set(reader.SenderId);
        msg.Location.Set(reader.Location);
        msg.ManualOrderInd = reader.ManualOrderInd;
        msg.PartyListId = reader.PartyListId;
        msg.IsAResend = reader.IsAResend;
        var ExchangeTimestampStruct = reader.ExchangeTimestamp.Reader();
        FromDecoder(ref msg.ExchangeTimestamp, in ExchangeTimestampStruct);
        var SendingTimestampStruct = reader.SendingTimestamp.Reader();
        FromDecoder(ref msg.SendingTimestamp, in SendingTimestampStruct);
        var ReceiptTimestampStruct = reader.ReceiptTimestamp.Reader();
        FromDecoder(ref msg.ReceiptTimestamp, in ReceiptTimestampStruct);
        var ExtractTimestampStruct = reader.ExtractTimestamp.Reader();
        FromDecoder(ref msg.ExtractTimestamp, in ExtractTimestampStruct);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref OrderReportOrderCancelRejectDts msg, in OrderReportOrderCancelRejectDecoder reader)
    {
        msg.RequestId = reader.RequestId;
        msg.RejectKind = reader.RejectKind;
        msg.RejectCode = reader.RejectCode;
        msg.RejectDescription.Set(reader.RejectDescription);
        msg.ExecReportId.Set(reader.ExecReportId);
        msg.ClOrdId = reader.ClOrdId;
        msg.OrdId = reader.OrdId;
        msg.SenderId.Set(reader.SenderId);
        msg.Location.Set(reader.Location);
        msg.ManualOrderInd = reader.ManualOrderInd;
        msg.PartyListId = reader.PartyListId;
        msg.IsAResend = reader.IsAResend;
        var ExchangeTimestampStruct = reader.ExchangeTimestamp.Reader();
        FromDecoder(ref msg.ExchangeTimestamp, in ExchangeTimestampStruct);
        var SendingTimestampStruct = reader.SendingTimestamp.Reader();
        FromDecoder(ref msg.SendingTimestamp, in SendingTimestampStruct);
        var ReceiptTimestampStruct = reader.ReceiptTimestamp.Reader();
        FromDecoder(ref msg.ReceiptTimestamp, in ReceiptTimestampStruct);
        var ExtractTimestampStruct = reader.ExtractTimestamp.Reader();
        FromDecoder(ref msg.ExtractTimestamp, in ExtractTimestampStruct);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref OrderReportOrderCancelModifyRejectDts msg, in OrderReportOrderCancelModifyRejectDecoder reader)
    {
        msg.RejectingPriceBand = reader.RejectingPriceBand;
        msg.RequestId = reader.RequestId;
        msg.RejectKind = reader.RejectKind;
        msg.RejectCode = reader.RejectCode;
        msg.RejectDescription.Set(reader.RejectDescription);
        msg.ExecReportId.Set(reader.ExecReportId);
        msg.ClOrdId = reader.ClOrdId;
        msg.OrdId = reader.OrdId;
        msg.SenderId.Set(reader.SenderId);
        msg.Location.Set(reader.Location);
        msg.ManualOrderInd = reader.ManualOrderInd;
        msg.PartyListId = reader.PartyListId;
        msg.IsAResend = reader.IsAResend;
        var ExchangeTimestampStruct = reader.ExchangeTimestamp.Reader();
        FromDecoder(ref msg.ExchangeTimestamp, in ExchangeTimestampStruct);
        var SendingTimestampStruct = reader.SendingTimestamp.Reader();
        FromDecoder(ref msg.SendingTimestamp, in SendingTimestampStruct);
        var ReceiptTimestampStruct = reader.ReceiptTimestamp.Reader();
        FromDecoder(ref msg.ReceiptTimestamp, in ReceiptTimestampStruct);
        var ExtractTimestampStruct = reader.ExtractTimestamp.Reader();
        FromDecoder(ref msg.ExtractTimestamp, in ExtractTimestampStruct);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref OrderReportMassActionDts msg, in OrderReportMassActionDecoder reader)
    {
        msg.RequestId = reader.RequestId;
        msg.MassActionRptId = reader.MassActionRptId;
        msg.SecurityGroup.Set(reader.SecurityGroup);
        msg.SecurityId = reader.SecurityId;
        msg.Response = reader.Response;
        msg.Scope = reader.Scope;
        msg.TotalAffectedOrders = reader.TotalAffectedOrders;
        msg.IsLastFragment = reader.IsLastFragment;
        msg.MarketSegmentId = reader.MarketSegmentId;
        msg.CancelRequestType = reader.CancelRequestType;
        msg.Side = reader.Side;
        msg.OrdType = reader.OrdType;
        msg.TimeInForce = reader.TimeInForce;
        msg.NumAffectedOrders = reader.NumAffectedOrders;
        var ClOrdIdList = reader.ClOrdId;
        switch (ClOrdIdList.Length)
        {
            case 10: msg.ClOrdId9 = ClOrdIdList[9]; goto case 9;
            case 9: msg.ClOrdId8 = ClOrdIdList[8]; goto case 8;
            case 8: msg.ClOrdId7 = ClOrdIdList[7]; goto case 7;
            case 7: msg.ClOrdId6 = ClOrdIdList[6]; goto case 6;
            case 6: msg.ClOrdId5 = ClOrdIdList[5]; goto case 5;
            case 5: msg.ClOrdId4 = ClOrdIdList[4]; goto case 4;
            case 4: msg.ClOrdId3 = ClOrdIdList[3]; goto case 3;
            case 3: msg.ClOrdId2 = ClOrdIdList[2]; goto case 2;
            case 2: msg.ClOrdId1 = ClOrdIdList[1]; goto case 1;
            case 1: msg.ClOrdId0 = ClOrdIdList[0]; goto case 0;
            case 0: break;
        }
        var OrdIdList = reader.OrdId;
        switch (OrdIdList.Length)
        {
            case 10: msg.OrdId9 = OrdIdList[9]; goto case 9;
            case 9: msg.OrdId8 = OrdIdList[8]; goto case 8;
            case 8: msg.OrdId7 = OrdIdList[7]; goto case 7;
            case 7: msg.OrdId6 = OrdIdList[6]; goto case 6;
            case 6: msg.OrdId5 = OrdIdList[5]; goto case 5;
            case 5: msg.OrdId4 = OrdIdList[4]; goto case 4;
            case 4: msg.OrdId3 = OrdIdList[3]; goto case 3;
            case 3: msg.OrdId2 = OrdIdList[2]; goto case 2;
            case 2: msg.OrdId1 = OrdIdList[1]; goto case 1;
            case 1: msg.OrdId0 = OrdIdList[0]; goto case 0;
            case 0: break;
        }
        var CancelQtyList = reader.CancelQty;
        switch (CancelQtyList.Length)
        {
            case 10: msg.CancelQty9 = CancelQtyList[9]; goto case 9;
            case 9: msg.CancelQty8 = CancelQtyList[8]; goto case 8;
            case 8: msg.CancelQty7 = CancelQtyList[7]; goto case 7;
            case 7: msg.CancelQty6 = CancelQtyList[6]; goto case 6;
            case 6: msg.CancelQty5 = CancelQtyList[5]; goto case 5;
            case 5: msg.CancelQty4 = CancelQtyList[4]; goto case 4;
            case 4: msg.CancelQty3 = CancelQtyList[3]; goto case 3;
            case 3: msg.CancelQty2 = CancelQtyList[2]; goto case 2;
            case 2: msg.CancelQty1 = CancelQtyList[1]; goto case 1;
            case 1: msg.CancelQty0 = CancelQtyList[0]; goto case 0;
            case 0: break;
        }
        msg.SenderId.Set(reader.SenderId);
        msg.Location.Set(reader.Location);
        msg.ManualOrderInd = reader.ManualOrderInd;
        msg.PartyListId = reader.PartyListId;
        msg.IsAResend = reader.IsAResend;
        var ExchangeTimestampStruct = reader.ExchangeTimestamp.Reader();
        FromDecoder(ref msg.ExchangeTimestamp, in ExchangeTimestampStruct);
        var SendingTimestampStruct = reader.SendingTimestamp.Reader();
        FromDecoder(ref msg.SendingTimestamp, in SendingTimestampStruct);
        var ReceiptTimestampStruct = reader.ReceiptTimestamp.Reader();
        FromDecoder(ref msg.ReceiptTimestamp, in ReceiptTimestampStruct);
        var ExtractTimestampStruct = reader.ExtractTimestamp.Reader();
        FromDecoder(ref msg.ExtractTimestamp, in ExtractTimestampStruct);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref OrderReportPartyDetailsDefinitionDts msg, in OrderReportPartyDetailsDefinitionDecoder reader)
    {
        msg.SelfMatchPreventionId = reader.SelfMatchPreventionId;
        msg.SelfMatchPreventionInst = reader.SelfMatchPreventionInst;
        msg.NumPartyDetails = reader.NumPartyDetails;
        var PartyDetailsIdList = reader.PartyDetailsId;
        switch (PartyDetailsIdList.Length)
        {
            case 10: msg.PartyDetailsId9.Set(PartyDetailsIdList[9]); goto case 9;
            case 9: msg.PartyDetailsId8.Set(PartyDetailsIdList[8]); goto case 8;
            case 8: msg.PartyDetailsId7.Set(PartyDetailsIdList[7]); goto case 7;
            case 7: msg.PartyDetailsId6.Set(PartyDetailsIdList[6]); goto case 6;
            case 6: msg.PartyDetailsId5.Set(PartyDetailsIdList[5]); goto case 5;
            case 5: msg.PartyDetailsId4.Set(PartyDetailsIdList[4]); goto case 4;
            case 4: msg.PartyDetailsId3.Set(PartyDetailsIdList[3]); goto case 3;
            case 3: msg.PartyDetailsId2.Set(PartyDetailsIdList[2]); goto case 2;
            case 2: msg.PartyDetailsId1.Set(PartyDetailsIdList[1]); goto case 1;
            case 1: msg.PartyDetailsId0.Set(PartyDetailsIdList[0]); goto case 0;
            case 0: break;
        }
        var PartyDetailsRoleList = reader.PartyDetailsRole;
        switch (PartyDetailsRoleList.Length)
        {
            case 10: msg.PartyDetailsRole9 = PartyDetailsRoleList[9]; goto case 9;
            case 9: msg.PartyDetailsRole8 = PartyDetailsRoleList[8]; goto case 8;
            case 8: msg.PartyDetailsRole7 = PartyDetailsRoleList[7]; goto case 7;
            case 7: msg.PartyDetailsRole6 = PartyDetailsRoleList[6]; goto case 6;
            case 6: msg.PartyDetailsRole5 = PartyDetailsRoleList[5]; goto case 5;
            case 5: msg.PartyDetailsRole4 = PartyDetailsRoleList[4]; goto case 4;
            case 4: msg.PartyDetailsRole3 = PartyDetailsRoleList[3]; goto case 3;
            case 3: msg.PartyDetailsRole2 = PartyDetailsRoleList[2]; goto case 2;
            case 2: msg.PartyDetailsRole1 = PartyDetailsRoleList[1]; goto case 1;
            case 1: msg.PartyDetailsRole0 = PartyDetailsRoleList[0]; goto case 0;
            case 0: break;
        }
        msg.PartyListId = reader.PartyListId;
        msg.IsAResend = reader.IsAResend;
        var ExchangeTimestampStruct = reader.ExchangeTimestamp.Reader();
        FromDecoder(ref msg.ExchangeTimestamp, in ExchangeTimestampStruct);
        var SendingTimestampStruct = reader.SendingTimestamp.Reader();
        FromDecoder(ref msg.SendingTimestamp, in SendingTimestampStruct);
        var ReceiptTimestampStruct = reader.ReceiptTimestamp.Reader();
        FromDecoder(ref msg.ReceiptTimestamp, in ReceiptTimestampStruct);
        var ExtractTimestampStruct = reader.ExtractTimestamp.Reader();
        FromDecoder(ref msg.ExtractTimestamp, in ExtractTimestampStruct);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref OrderReportPartyDetailsListDts msg, in OrderReportPartyDetailsListDecoder reader)
    {
        msg.RequestResult = reader.RequestResult;
        msg.RequestId = reader.RequestId;
        msg.SelfMatchPreventionId = reader.SelfMatchPreventionId;
        msg.SelfMatchPreventionInst = reader.SelfMatchPreventionInst;
        msg.TotalNumParties = reader.TotalNumParties;
        msg.NumPartyDetails = reader.NumPartyDetails;
        var PartyDetailsIdList = reader.PartyDetailsId;
        switch (PartyDetailsIdList.Length)
        {
            case 10: msg.PartyDetailsId9.Set(PartyDetailsIdList[9]); goto case 9;
            case 9: msg.PartyDetailsId8.Set(PartyDetailsIdList[8]); goto case 8;
            case 8: msg.PartyDetailsId7.Set(PartyDetailsIdList[7]); goto case 7;
            case 7: msg.PartyDetailsId6.Set(PartyDetailsIdList[6]); goto case 6;
            case 6: msg.PartyDetailsId5.Set(PartyDetailsIdList[5]); goto case 5;
            case 5: msg.PartyDetailsId4.Set(PartyDetailsIdList[4]); goto case 4;
            case 4: msg.PartyDetailsId3.Set(PartyDetailsIdList[3]); goto case 3;
            case 3: msg.PartyDetailsId2.Set(PartyDetailsIdList[2]); goto case 2;
            case 2: msg.PartyDetailsId1.Set(PartyDetailsIdList[1]); goto case 1;
            case 1: msg.PartyDetailsId0.Set(PartyDetailsIdList[0]); goto case 0;
            case 0: break;
        }
        var PartyDetailsRoleList = reader.PartyDetailsRole;
        switch (PartyDetailsRoleList.Length)
        {
            case 10: msg.PartyDetailsRole9 = PartyDetailsRoleList[9]; goto case 9;
            case 9: msg.PartyDetailsRole8 = PartyDetailsRoleList[8]; goto case 8;
            case 8: msg.PartyDetailsRole7 = PartyDetailsRoleList[7]; goto case 7;
            case 7: msg.PartyDetailsRole6 = PartyDetailsRoleList[6]; goto case 6;
            case 6: msg.PartyDetailsRole5 = PartyDetailsRoleList[5]; goto case 5;
            case 5: msg.PartyDetailsRole4 = PartyDetailsRoleList[4]; goto case 4;
            case 4: msg.PartyDetailsRole3 = PartyDetailsRoleList[3]; goto case 3;
            case 3: msg.PartyDetailsRole2 = PartyDetailsRoleList[2]; goto case 2;
            case 2: msg.PartyDetailsRole1 = PartyDetailsRoleList[1]; goto case 1;
            case 1: msg.PartyDetailsRole0 = PartyDetailsRoleList[0]; goto case 0;
            case 0: break;
        }
        msg.IsLastFragment = reader.IsLastFragment;
        msg.PartyListId = reader.PartyListId;
        msg.IsAResend = reader.IsAResend;
        var ExchangeTimestampStruct = reader.ExchangeTimestamp.Reader();
        FromDecoder(ref msg.ExchangeTimestamp, in ExchangeTimestampStruct);
        var SendingTimestampStruct = reader.SendingTimestamp.Reader();
        FromDecoder(ref msg.SendingTimestamp, in SendingTimestampStruct);
        var ReceiptTimestampStruct = reader.ReceiptTimestamp.Reader();
        FromDecoder(ref msg.ReceiptTimestamp, in ReceiptTimestampStruct);
        var ExtractTimestampStruct = reader.ExtractTimestamp.Reader();
        FromDecoder(ref msg.ExtractTimestamp, in ExtractTimestampStruct);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref OrderManagerResponseStatusDts msg, in OrderManagerResponseStatusDecoder reader)
    {
        msg.TimestampNs = reader.TimestampNs;
        msg.LatestState = reader.LatestState;
        msg.NumEvents = reader.NumEvents;
        var EventsListList = reader.EventsList;
        switch (EventsListList.Length)
        {
            case 10: msg.EventsList9 = EventsListList[9]; goto case 9;
            case 9: msg.EventsList8 = EventsListList[8]; goto case 8;
            case 8: msg.EventsList7 = EventsListList[7]; goto case 7;
            case 7: msg.EventsList6 = EventsListList[6]; goto case 6;
            case 6: msg.EventsList5 = EventsListList[5]; goto case 5;
            case 5: msg.EventsList4 = EventsListList[4]; goto case 4;
            case 4: msg.EventsList3 = EventsListList[3]; goto case 3;
            case 3: msg.EventsList2 = EventsListList[2]; goto case 2;
            case 2: msg.EventsList1 = EventsListList[1]; goto case 1;
            case 1: msg.EventsList0 = EventsListList[0]; goto case 0;
            case 0: break;
        }
        msg.Account.Set(reader.Account);
        msg.AccountState = reader.AccountState;
        msg.AccountPnl = reader.AccountPnl;
        msg.NumWorkingOrd = reader.NumWorkingOrd;
        var WorkingOrdListAccessor = reader.WorkingOrdList;
        switch (WorkingOrdListAccessor.Count)
        {
            case 10:
                var e9 = WorkingOrdListAccessor.GetElement(9);
                FromDecoder(ref msg.WorkingOrdList9, in e9);
                goto case 9;
            case 9:
                var e8 = WorkingOrdListAccessor.GetElement(8);
                FromDecoder(ref msg.WorkingOrdList8, in e8);
                goto case 8;
            case 8:
                var e7 = WorkingOrdListAccessor.GetElement(7);
                FromDecoder(ref msg.WorkingOrdList7, in e7);
                goto case 7;
            case 7:
                var e6 = WorkingOrdListAccessor.GetElement(6);
                FromDecoder(ref msg.WorkingOrdList6, in e6);
                goto case 6;
            case 6:
                var e5 = WorkingOrdListAccessor.GetElement(5);
                FromDecoder(ref msg.WorkingOrdList5, in e5);
                goto case 5;
            case 5:
                var e4 = WorkingOrdListAccessor.GetElement(4);
                FromDecoder(ref msg.WorkingOrdList4, in e4);
                goto case 4;
            case 4:
                var e3 = WorkingOrdListAccessor.GetElement(3);
                FromDecoder(ref msg.WorkingOrdList3, in e3);
                goto case 3;
            case 3:
                var e2 = WorkingOrdListAccessor.GetElement(2);
                FromDecoder(ref msg.WorkingOrdList2, in e2);
                goto case 2;
            case 2:
                var e1 = WorkingOrdListAccessor.GetElement(1);
                FromDecoder(ref msg.WorkingOrdList1, in e1);
                goto case 1;
            case 1:
                var e0 = WorkingOrdListAccessor.GetElement(0);
                FromDecoder(ref msg.WorkingOrdList0, in e0);
                goto case 0;
            case 0: break;
        }
        msg.NumOutrightPos = reader.NumOutrightPos;
        var OutrightPosListAccessor = reader.OutrightPosList;
        switch (OutrightPosListAccessor.Count)
        {
            case 10:
                var e9 = OutrightPosListAccessor.GetElement(9);
                FromDecoder(ref msg.OutrightPosList9, in e9);
                goto case 9;
            case 9:
                var e8 = OutrightPosListAccessor.GetElement(8);
                FromDecoder(ref msg.OutrightPosList8, in e8);
                goto case 8;
            case 8:
                var e7 = OutrightPosListAccessor.GetElement(7);
                FromDecoder(ref msg.OutrightPosList7, in e7);
                goto case 7;
            case 7:
                var e6 = OutrightPosListAccessor.GetElement(6);
                FromDecoder(ref msg.OutrightPosList6, in e6);
                goto case 6;
            case 6:
                var e5 = OutrightPosListAccessor.GetElement(5);
                FromDecoder(ref msg.OutrightPosList5, in e5);
                goto case 5;
            case 5:
                var e4 = OutrightPosListAccessor.GetElement(4);
                FromDecoder(ref msg.OutrightPosList4, in e4);
                goto case 4;
            case 4:
                var e3 = OutrightPosListAccessor.GetElement(3);
                FromDecoder(ref msg.OutrightPosList3, in e3);
                goto case 3;
            case 3:
                var e2 = OutrightPosListAccessor.GetElement(2);
                FromDecoder(ref msg.OutrightPosList2, in e2);
                goto case 2;
            case 2:
                var e1 = OutrightPosListAccessor.GetElement(1);
                FromDecoder(ref msg.OutrightPosList1, in e1);
                goto case 1;
            case 1:
                var e0 = OutrightPosListAccessor.GetElement(0);
                FromDecoder(ref msg.OutrightPosList0, in e0);
                goto case 0;
            case 0: break;
        }
        msg.RemainingAccountStatusMessageCnt = reader.RemainingAccountStatusMessageCnt;
        msg.RemainingStatusMessageCnt = reader.RemainingStatusMessageCnt;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref WorkingOrderDts msg, in WorkingOrderDecoder reader)
    {
        msg.RequestId = reader.RequestId;
        msg.ClOrdId = reader.ClOrdId;
        msg.OrdId = reader.OrdId;
        msg.SecurityId = reader.SecurityId;
        msg.Side = reader.Side;
        msg.Quantity = reader.Quantity;
        msg.LimitPrice = reader.LimitPrice;
        msg.TimeInForce = reader.TimeInForce;
        msg.UnitContractCnt = reader.UnitContractCnt;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref OutrightPositionDts msg, in OutrightPositionDecoder reader)
    {
        msg.SecurityId = reader.SecurityId;
        msg.Side = reader.Side;
        msg.Quantity = reader.Quantity;
        msg.Price = reader.Price;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref OrderManagerResponseRejectDts msg, in OrderManagerResponseRejectDecoder reader)
    {
        msg.TimestampNs = reader.TimestampNs;
        msg.CurrentState = reader.CurrentState;
        msg.RequestId = reader.RequestId;
        msg.RejectDescription.Set(reader.RejectDescription);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref OrderManagerResponseSetRiskLimitDts msg, in OrderManagerResponseSetRiskLimitDecoder reader)
    {
        var RiskLimitStruct = reader.RiskLimit.Reader();
        FromDecoder(ref msg.RiskLimit, in RiskLimitStruct);
        msg.Success = reader.Success;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref OrderManagerResponseLoginDts msg, in OrderManagerResponseLoginDecoder reader)
    {
        msg.Response = reader.Response;
        msg.NumMsgwIds = reader.NumMsgwIds;
        var MsgwIdsList = reader.MsgwIds;
        switch (MsgwIdsList.Length)
        {
            case 10: msg.MsgwIds9 = MsgwIdsList[9]; goto case 9;
            case 9: msg.MsgwIds8 = MsgwIdsList[8]; goto case 8;
            case 8: msg.MsgwIds7 = MsgwIdsList[7]; goto case 7;
            case 7: msg.MsgwIds6 = MsgwIdsList[6]; goto case 6;
            case 6: msg.MsgwIds5 = MsgwIdsList[5]; goto case 5;
            case 5: msg.MsgwIds4 = MsgwIdsList[4]; goto case 4;
            case 4: msg.MsgwIds3 = MsgwIdsList[3]; goto case 3;
            case 3: msg.MsgwIds2 = MsgwIdsList[2]; goto case 2;
            case 2: msg.MsgwIds1 = MsgwIdsList[1]; goto case 1;
            case 1: msg.MsgwIds0 = MsgwIdsList[0]; goto case 0;
            case 0: break;
        }
        msg.Environment = reader.Environment;
        msg.ClOrdIdPrefix = reader.ClOrdIdPrefix;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref OrderManagerResponsePingDts msg, in OrderManagerResponsePingDecoder reader)
    {
        msg.TimestampNs = reader.TimestampNs;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref OrderManagerResponseConnectionClosingDts msg, in OrderManagerResponseConnectionClosingDecoder reader)
    {
        msg.TimestampNs = reader.TimestampNs;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref UtcTimeDts msg, in UtcTimeDecoder reader)
    {
        msg.TimeNs = reader.TimeNs;
    }

}
