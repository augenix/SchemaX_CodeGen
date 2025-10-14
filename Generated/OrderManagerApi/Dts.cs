using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace SchemaX_CodeGen.Generated.OrderManagerApi;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 40)]
public struct RiskAccountingLimitDts
{
    public double UnseenPnlLossUb;
    public FixedAscii32 Account;

    static RiskAccountingLimitDts()
    {
        int sz = Unsafe.SizeOf<RiskAccountingLimitDts>();
        if ((sz & 7) != 0) throw new System.Exception($"RiskAccountingLimitDts not 8B aligned: 8");
        if (sz != 40) throw new System.Exception($"RiskAccountingLimitDts size mismatch: 8 != 40");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 160)]
public struct OrderReportBusinessRejectDts
{
    public ushort RejectReason;
    public ushort RefTagId;
    public bool ManualOrderInd;
    public byte IsAResend;
    public OrderMsgTypeKind RefMsgType;
    public ulong RequestId;
    public ulong PartyListId;
    public long ExchangeTimestampNs;
    public long SendingTimestampNs;
    public long ReceiptTimestampNs;
    public long ExtractTimestampNs;
    public FixedAscii32 RejectDescription;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;

    static OrderReportBusinessRejectDts()
    {
        int sz = Unsafe.SizeOf<OrderReportBusinessRejectDts>();
        if ((sz & 7) != 0) throw new System.Exception($"OrderReportBusinessRejectDts not 8B aligned: 8");
        if (sz != 160) throw new System.Exception($"OrderReportBusinessRejectDts size mismatch: 8 != 160");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 224)]
public struct OrderReportExecRptNewOrderDts
{
    public bool ManualOrderInd;
    public byte IsAResend;
    public uint OrderQty;
    public uint MinQty;
    public uint CumQty;
    public uint DisplayQty;
    public int SecurityId;
    public OrderKind OrdType;
    public ulong RequestId;
    public double Price;
    public double StopPx;
    public long ExpireDateNs;
    public OrderTimeInForce TimeInForce;
    public ulong ClOrdId;
    public ulong OrdId;
    public ulong PartyListId;
    public long ExchangeTimestampNs;
    public long SendingTimestampNs;
    public long ReceiptTimestampNs;
    public long ExtractTimestampNs;
    public OrderSide Side;
    public FixedAscii32 ExecReportId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;

    static OrderReportExecRptNewOrderDts()
    {
        int sz = Unsafe.SizeOf<OrderReportExecRptNewOrderDts>();
        if ((sz & 7) != 0) throw new System.Exception($"OrderReportExecRptNewOrderDts not 8B aligned: 8");
        if (sz != 224) throw new System.Exception($"OrderReportExecRptNewOrderDts size mismatch: 8 != 224");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 224)]
public struct OrderReportExecRptModifyDts
{
    public bool ManualOrderInd;
    public byte IsAResend;
    public uint LeavesQty;
    public uint OrderQty;
    public uint MinQty;
    public uint CumQty;
    public uint DisplayQty;
    public int SecurityId;
    public OrderKind OrdType;
    public ulong RequestId;
    public double Price;
    public double StopPx;
    public long ExpireDateNs;
    public OrderTimeInForce TimeInForce;
    public ulong ClOrdId;
    public ulong OrdId;
    public ulong PartyListId;
    public long ExchangeTimestampNs;
    public long SendingTimestampNs;
    public long ReceiptTimestampNs;
    public long ExtractTimestampNs;
    public OrderSide Side;
    public FixedAscii32 ExecReportId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;

    static OrderReportExecRptModifyDts()
    {
        int sz = Unsafe.SizeOf<OrderReportExecRptModifyDts>();
        if ((sz & 7) != 0) throw new System.Exception($"OrderReportExecRptModifyDts not 8B aligned: 8");
        if (sz != 224) throw new System.Exception($"OrderReportExecRptModifyDts size mismatch: 8 != 224");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 224)]
public struct OrderReportExecRptCancelDts
{
    public bool ManualOrderInd;
    public byte IsAResend;
    public uint OrderQty;
    public uint MinQty;
    public uint CumQty;
    public uint DisplayQty;
    public int SecurityId;
    public OrderKind OrdType;
    public ulong RequestId;
    public double Price;
    public double StopPx;
    public long ExpireDateNs;
    public OrderTimeInForce TimeInForce;
    public ulong ClOrdId;
    public ulong OrdId;
    public ulong PartyListId;
    public long ExchangeTimestampNs;
    public long SendingTimestampNs;
    public long ReceiptTimestampNs;
    public long ExtractTimestampNs;
    public CancelReason CancelReason;
    public OrderSide Side;
    public FixedAscii32 ExecReportId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;

    static OrderReportExecRptCancelDts()
    {
        int sz = Unsafe.SizeOf<OrderReportExecRptCancelDts>();
        if ((sz & 7) != 0) throw new System.Exception($"OrderReportExecRptCancelDts not 8B aligned: 8");
        if (sz != 224) throw new System.Exception($"OrderReportExecRptCancelDts size mismatch: 8 != 224");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 272)]
public struct OrderReportExecRptStatusDts
{
    public bool IsLastStatusRequested;
    public bool ManualOrderInd;
    public byte IsAResend;
    public ExecRptStatus OrdStatus;
    public uint LeavesQty;
    public uint OrderQty;
    public uint MinQty;
    public uint CumQty;
    public uint DisplayQty;
    public int SecurityId;
    public OrderKind OrdType;
    public ulong StatusReqId;
    public ulong RequestId;
    public double Price;
    public double StopPx;
    public long ExpireDateNs;
    public OrderTimeInForce TimeInForce;
    public ulong ClOrdId;
    public ulong OrdId;
    public ulong PartyListId;
    public long ExchangeTimestampNs;
    public long SendingTimestampNs;
    public long ReceiptTimestampNs;
    public long ExtractTimestampNs;
    public FixedAscii32 RejectDescription;
    public OrderSide Side;
    public FixedAscii32 ExecReportId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;

    static OrderReportExecRptStatusDts()
    {
        int sz = Unsafe.SizeOf<OrderReportExecRptStatusDts>();
        if ((sz & 7) != 0) throw new System.Exception($"OrderReportExecRptStatusDts not 8B aligned: 8");
        if (sz != 272) throw new System.Exception($"OrderReportExecRptStatusDts size mismatch: 8 != 272");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 232)]
public struct OrderReportExecRptTradeOutrightDts
{
    public bool IsAggressor;
    public bool ManualOrderInd;
    public byte IsAResend;
    public OrderFillStatus FillStatus;
    public uint LeavesQty;
    public uint OrderQty;
    public uint CumQty;
    public uint FillQty;
    public int SecurityId;
    public OrderKind OrdType;
    public ulong RequestId;
    public double Price;
    public double FillPrice;
    public ulong SecurityExecId;
    public long TradeDateNs;
    public ulong ClOrdId;
    public ulong OrdId;
    public ulong PartyListId;
    public long ExchangeTimestampNs;
    public long SendingTimestampNs;
    public long ReceiptTimestampNs;
    public long ExtractTimestampNs;
    public OrderSide Side;
    public FixedAscii32 ExecReportId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;

    static OrderReportExecRptTradeOutrightDts()
    {
        int sz = Unsafe.SizeOf<OrderReportExecRptTradeOutrightDts>();
        if ((sz & 7) != 0) throw new System.Exception($"OrderReportExecRptTradeOutrightDts not 8B aligned: 8");
        if (sz != 232) throw new System.Exception($"OrderReportExecRptTradeOutrightDts size mismatch: 8 != 232");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 232)]
public struct OrderReportExecRptTradeSpreadDts
{
    public byte NumLegFills;
    public bool IsAggressor;
    public bool ManualOrderInd;
    public byte IsAResend;
    public OrderFillStatus FillStatus;
    public uint LeavesQty;
    public uint OrderQty;
    public uint CumQty;
    public uint FillQty;
    public int SecurityId;
    public OrderKind OrdType;
    public ulong RequestId;
    public double Price;
    public double FillPrice;
    public ulong SecurityExecId;
    public long TradeDateNs;
    public ulong ClOrdId;
    public ulong OrdId;
    public ulong PartyListId;
    public long ExchangeTimestampNs;
    public long SendingTimestampNs;
    public long ReceiptTimestampNs;
    public long ExtractTimestampNs;
    public OrderSide Side;
    public FixedAscii32 ExecReportId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;

    static OrderReportExecRptTradeSpreadDts()
    {
        int sz = Unsafe.SizeOf<OrderReportExecRptTradeSpreadDts>();
        if ((sz & 7) != 0) throw new System.Exception($"OrderReportExecRptTradeSpreadDts not 8B aligned: 8");
        if (sz != 232) throw new System.Exception($"OrderReportExecRptTradeSpreadDts size mismatch: 8 != 232");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 208)]
public struct OrderReportExecRptTradeSpreadLegDts
{
    public bool ManualOrderInd;
    public byte IsAResend;
    public uint CumQty;
    public OrderFillStatus FillStatus;
    public uint FillQty;
    public int SecurityId;
    public OrderKind OrdType;
    public double FillPrice;
    public ulong SecurityExecId;
    public long TradeDateNs;
    public ulong ClOrdId;
    public ulong OrdId;
    public ulong PartyListId;
    public long ExchangeTimestampNs;
    public long SendingTimestampNs;
    public long ReceiptTimestampNs;
    public long ExtractTimestampNs;
    public OrderSide Side;
    public FixedAscii32 ExecReportId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;

    static OrderReportExecRptTradeSpreadLegDts()
    {
        int sz = Unsafe.SizeOf<OrderReportExecRptTradeSpreadLegDts>();
        if ((sz & 7) != 0) throw new System.Exception($"OrderReportExecRptTradeSpreadLegDts not 8B aligned: 8");
        if (sz != 208) throw new System.Exception($"OrderReportExecRptTradeSpreadLegDts size mismatch: 8 != 208");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 224)]
public struct OrderReportExecRptEliminationDts
{
    public bool ManualOrderInd;
    public byte IsAResend;
    public uint OrderQty;
    public uint MinQty;
    public uint CumQty;
    public uint DisplayQty;
    public int SecurityId;
    public OrderKind OrdType;
    public ulong RequestId;
    public double Price;
    public double StopPx;
    public long ExpireDateNs;
    public OrderTimeInForce TimeInForce;
    public ulong ClOrdId;
    public ulong OrdId;
    public ulong PartyListId;
    public long ExchangeTimestampNs;
    public long SendingTimestampNs;
    public long ReceiptTimestampNs;
    public long ExtractTimestampNs;
    public OrderSide Side;
    public FixedAscii32 ExecReportId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;

    static OrderReportExecRptEliminationDts()
    {
        int sz = Unsafe.SizeOf<OrderReportExecRptEliminationDts>();
        if ((sz & 7) != 0) throw new System.Exception($"OrderReportExecRptEliminationDts not 8B aligned: 8");
        if (sz != 224) throw new System.Exception($"OrderReportExecRptEliminationDts size mismatch: 8 != 224");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 264)]
public struct OrderReportExecRptRejectDts
{
    public ushort RejectCode;
    public bool ManualOrderInd;
    public byte IsAResend;
    public OrderRejectionKind RejectKind;
    public uint OrderQty;
    public uint MinQty;
    public uint CumQty;
    public uint DisplayQty;
    public int SecurityId;
    public OrderKind OrdType;
    public double RejectingPriceBand;
    public ulong RequestId;
    public double Price;
    public double StopPx;
    public long ExpireDateNs;
    public OrderTimeInForce TimeInForce;
    public ulong ClOrdId;
    public ulong OrdId;
    public ulong PartyListId;
    public long ExchangeTimestampNs;
    public long SendingTimestampNs;
    public long ReceiptTimestampNs;
    public long ExtractTimestampNs;
    public FixedAscii32 RejectDescription;
    public OrderSide Side;
    public FixedAscii32 ExecReportId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;

    static OrderReportExecRptRejectDts()
    {
        int sz = Unsafe.SizeOf<OrderReportExecRptRejectDts>();
        if ((sz & 7) != 0) throw new System.Exception($"OrderReportExecRptRejectDts not 8B aligned: 8");
        if (sz != 264) throw new System.Exception($"OrderReportExecRptRejectDts size mismatch: 8 != 264");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 200)]
public struct OrderReportExecRptTradeAddendumOutrightDts
{
    public bool ManualOrderInd;
    public byte IsAResend;
    public AddendumKind AddendumKind;
    public uint FillQty;
    public int SecurityId;
    public OrderKind OrdType;
    public double FillPrice;
    public ulong SecurityExecId;
    public long TradeDateNs;
    public ulong ClOrdId;
    public ulong OrdId;
    public ulong PartyListId;
    public long ExchangeTimestampNs;
    public long SendingTimestampNs;
    public long ReceiptTimestampNs;
    public long ExtractTimestampNs;
    public OrderSide Side;
    public FixedAscii32 ExecReportId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;

    static OrderReportExecRptTradeAddendumOutrightDts()
    {
        int sz = Unsafe.SizeOf<OrderReportExecRptTradeAddendumOutrightDts>();
        if ((sz & 7) != 0) throw new System.Exception($"OrderReportExecRptTradeAddendumOutrightDts not 8B aligned: 8");
        if (sz != 200) throw new System.Exception($"OrderReportExecRptTradeAddendumOutrightDts size mismatch: 8 != 200");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 200)]
public struct OrderReportExecRptTradeAddendumSpreadDts
{
    public byte NumLegFills;
    public bool ManualOrderInd;
    public byte IsAResend;
    public AddendumKind AddendumKind;
    public uint FillQty;
    public int SecurityId;
    public OrderKind OrdType;
    public double FillPrice;
    public ulong SecurityExecId;
    public long TradeDateNs;
    public ulong ClOrdId;
    public ulong OrdId;
    public ulong PartyListId;
    public long ExchangeTimestampNs;
    public long SendingTimestampNs;
    public long ReceiptTimestampNs;
    public long ExtractTimestampNs;
    public OrderSide Side;
    public FixedAscii32 ExecReportId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;

    static OrderReportExecRptTradeAddendumSpreadDts()
    {
        int sz = Unsafe.SizeOf<OrderReportExecRptTradeAddendumSpreadDts>();
        if ((sz & 7) != 0) throw new System.Exception($"OrderReportExecRptTradeAddendumSpreadDts not 8B aligned: 8");
        if (sz != 200) throw new System.Exception($"OrderReportExecRptTradeAddendumSpreadDts size mismatch: 8 != 200");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 200)]
public struct OrderReportExecRptTradeAddendumSpreadLegDts
{
    public bool ManualOrderInd;
    public byte IsAResend;
    public AddendumKind AddendumKind;
    public uint FillQty;
    public int SecurityId;
    public OrderKind OrdType;
    public double FillPrice;
    public ulong SecurityExecId;
    public long TradeDateNs;
    public ulong ClOrdId;
    public ulong OrdId;
    public ulong PartyListId;
    public long ExchangeTimestampNs;
    public long SendingTimestampNs;
    public long ReceiptTimestampNs;
    public long ExtractTimestampNs;
    public OrderSide Side;
    public FixedAscii32 ExecReportId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;

    static OrderReportExecRptTradeAddendumSpreadLegDts()
    {
        int sz = Unsafe.SizeOf<OrderReportExecRptTradeAddendumSpreadLegDts>();
        if ((sz & 7) != 0) throw new System.Exception($"OrderReportExecRptTradeAddendumSpreadLegDts not 8B aligned: 8");
        if (sz != 200) throw new System.Exception($"OrderReportExecRptTradeAddendumSpreadLegDts size mismatch: 8 != 200");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 200)]
public struct OrderReportOrderCancelRejectDts
{
    public ushort RejectCode;
    public bool ManualOrderInd;
    public byte IsAResend;
    public OrderRejectionKind RejectKind;
    public ulong RequestId;
    public ulong ClOrdId;
    public ulong OrdId;
    public ulong PartyListId;
    public long ExchangeTimestampNs;
    public long SendingTimestampNs;
    public long ReceiptTimestampNs;
    public long ExtractTimestampNs;
    public FixedAscii32 RejectDescription;
    public FixedAscii32 ExecReportId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;

    static OrderReportOrderCancelRejectDts()
    {
        int sz = Unsafe.SizeOf<OrderReportOrderCancelRejectDts>();
        if ((sz & 7) != 0) throw new System.Exception($"OrderReportOrderCancelRejectDts not 8B aligned: 8");
        if (sz != 200) throw new System.Exception($"OrderReportOrderCancelRejectDts size mismatch: 8 != 200");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 208)]
public struct OrderReportOrderCancelModifyRejectDts
{
    public ushort RejectCode;
    public bool ManualOrderInd;
    public byte IsAResend;
    public OrderRejectionKind RejectKind;
    public double RejectingPriceBand;
    public ulong RequestId;
    public ulong ClOrdId;
    public ulong OrdId;
    public ulong PartyListId;
    public long ExchangeTimestampNs;
    public long SendingTimestampNs;
    public long ReceiptTimestampNs;
    public long ExtractTimestampNs;
    public FixedAscii32 RejectDescription;
    public FixedAscii32 ExecReportId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;

    static OrderReportOrderCancelModifyRejectDts()
    {
        int sz = Unsafe.SizeOf<OrderReportOrderCancelModifyRejectDts>();
        if ((sz & 7) != 0) throw new System.Exception($"OrderReportOrderCancelModifyRejectDts not 8B aligned: 8");
        if (sz != 208) throw new System.Exception($"OrderReportOrderCancelModifyRejectDts size mismatch: 8 != 208");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 392)]
public struct OrderReportMassActionDts
{
    public byte TotalAffectedOrders;
    public bool IsLastFragment;
    public byte MarketSegmentId;
    public byte NumAffectedOrders;
    public bool ManualOrderInd;
    public byte IsAResend;
    public int SecurityId;
    public MassActionScopeKind Scope;
    public MassStatusRequestKind CancelRequestType;
    public OrderKind OrdType;
    public ulong RequestId;
    public ulong MassActionRptId;
    public OrderTimeInForce TimeInForce;
    public ulong PartyListId;
    public long ExchangeTimestampNs;
    public long SendingTimestampNs;
    public long ReceiptTimestampNs;
    public long ExtractTimestampNs;
    public FixedAscii32 SecurityGroup;
    public MassActionResponse Response;
    public OrderSide Side;
    public ulong ClOrdId0;
    public ulong ClOrdId1;
    public ulong ClOrdId2;
    public ulong ClOrdId3;
    public ulong ClOrdId4;
    public ulong ClOrdId5;
    public ulong ClOrdId6;
    public ulong ClOrdId7;
    public ulong ClOrdId8;
    public ulong ClOrdId9;
    public ulong OrdId0;
    public ulong OrdId1;
    public ulong OrdId2;
    public ulong OrdId3;
    public ulong OrdId4;
    public ulong OrdId5;
    public ulong OrdId6;
    public ulong OrdId7;
    public ulong OrdId8;
    public ulong OrdId9;
    public uint CancelQty0;
    public uint CancelQty1;
    public uint CancelQty2;
    public uint CancelQty3;
    public uint CancelQty4;
    public uint CancelQty5;
    public uint CancelQty6;
    public uint CancelQty7;
    public uint CancelQty8;
    public uint CancelQty9;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;

    static OrderReportMassActionDts()
    {
        int sz = Unsafe.SizeOf<OrderReportMassActionDts>();
        if ((sz & 7) != 0) throw new System.Exception($"OrderReportMassActionDts not 8B aligned: 8");
        if (sz != 392) throw new System.Exception($"OrderReportMassActionDts size mismatch: 8 != 392");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 416)]
public struct OrderReportPartyDetailsDefinitionDts
{
    public byte NumPartyDetails;
    public byte IsAResend;
    public ulong SelfMatchPreventionId;
    public ulong PartyListId;
    public long ExchangeTimestampNs;
    public long SendingTimestampNs;
    public long ReceiptTimestampNs;
    public long ExtractTimestampNs;
    public OrderSelfMatchInst SelfMatchPreventionInst;
    public FixedAscii32 PartyDetailsId0;
    public FixedAscii32 PartyDetailsId1;
    public FixedAscii32 PartyDetailsId2;
    public FixedAscii32 PartyDetailsId3;
    public FixedAscii32 PartyDetailsId4;
    public FixedAscii32 PartyDetailsId5;
    public FixedAscii32 PartyDetailsId6;
    public FixedAscii32 PartyDetailsId7;
    public FixedAscii32 PartyDetailsId8;
    public FixedAscii32 PartyDetailsId9;
    public OrderPartyDetailsRole PartyDetailsRole0;
    public OrderPartyDetailsRole PartyDetailsRole1;
    public OrderPartyDetailsRole PartyDetailsRole2;
    public OrderPartyDetailsRole PartyDetailsRole3;
    public OrderPartyDetailsRole PartyDetailsRole4;
    public OrderPartyDetailsRole PartyDetailsRole5;
    public OrderPartyDetailsRole PartyDetailsRole6;
    public OrderPartyDetailsRole PartyDetailsRole7;
    public OrderPartyDetailsRole PartyDetailsRole8;
    public OrderPartyDetailsRole PartyDetailsRole9;

    static OrderReportPartyDetailsDefinitionDts()
    {
        int sz = Unsafe.SizeOf<OrderReportPartyDetailsDefinitionDts>();
        if ((sz & 7) != 0) throw new System.Exception($"OrderReportPartyDetailsDefinitionDts not 8B aligned: 8");
        if (sz != 416) throw new System.Exception($"OrderReportPartyDetailsDefinitionDts size mismatch: 8 != 416");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 432)]
public struct OrderReportPartyDetailsListDts
{
    public ushort TotalNumParties;
    public byte NumPartyDetails;
    public bool IsLastFragment;
    public byte IsAResend;
    public ulong RequestId;
    public ulong SelfMatchPreventionId;
    public ulong PartyListId;
    public long ExchangeTimestampNs;
    public long SendingTimestampNs;
    public long ReceiptTimestampNs;
    public long ExtractTimestampNs;
    public RequestResult RequestResult;
    public OrderSelfMatchInst SelfMatchPreventionInst;
    public FixedAscii32 PartyDetailsId0;
    public FixedAscii32 PartyDetailsId1;
    public FixedAscii32 PartyDetailsId2;
    public FixedAscii32 PartyDetailsId3;
    public FixedAscii32 PartyDetailsId4;
    public FixedAscii32 PartyDetailsId5;
    public FixedAscii32 PartyDetailsId6;
    public FixedAscii32 PartyDetailsId7;
    public FixedAscii32 PartyDetailsId8;
    public FixedAscii32 PartyDetailsId9;
    public OrderPartyDetailsRole PartyDetailsRole0;
    public OrderPartyDetailsRole PartyDetailsRole1;
    public OrderPartyDetailsRole PartyDetailsRole2;
    public OrderPartyDetailsRole PartyDetailsRole3;
    public OrderPartyDetailsRole PartyDetailsRole4;
    public OrderPartyDetailsRole PartyDetailsRole5;
    public OrderPartyDetailsRole PartyDetailsRole6;
    public OrderPartyDetailsRole PartyDetailsRole7;
    public OrderPartyDetailsRole PartyDetailsRole8;
    public OrderPartyDetailsRole PartyDetailsRole9;

    static OrderReportPartyDetailsListDts()
    {
        int sz = Unsafe.SizeOf<OrderReportPartyDetailsListDts>();
        if ((sz & 7) != 0) throw new System.Exception($"OrderReportPartyDetailsListDts not 8B aligned: 8");
        if (sz != 432) throw new System.Exception($"OrderReportPartyDetailsListDts size mismatch: 8 != 432");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1016)]
public struct OrderManagerResponseStatusDts
{
    public long TimestampNs;
    public ulong NumEvents;
    public double AccountPnl;
    public ulong NumWorkingOrd;
    public ulong NumOutrightPos;
    public ulong RemainingAccountStatusMessageCnt;
    public ulong RemainingStatusMessageCnt;
    public CmeOrderManagerState LatestState;
    public CmeOrderManagerEvent EventsList0;
    public CmeOrderManagerEvent EventsList1;
    public CmeOrderManagerEvent EventsList2;
    public CmeOrderManagerEvent EventsList3;
    public CmeOrderManagerEvent EventsList4;
    public CmeOrderManagerEvent EventsList5;
    public CmeOrderManagerEvent EventsList6;
    public CmeOrderManagerEvent EventsList7;
    public CmeOrderManagerEvent EventsList8;
    public CmeOrderManagerEvent EventsList9;
    public FixedAscii32 Account;
    public RiskAccountingState AccountState;
    public WorkingOrderDts WorkingOrdList0;
    public WorkingOrderDts WorkingOrdList1;
    public WorkingOrderDts WorkingOrdList2;
    public WorkingOrderDts WorkingOrdList3;
    public WorkingOrderDts WorkingOrdList4;
    public WorkingOrderDts WorkingOrdList5;
    public WorkingOrderDts WorkingOrdList6;
    public WorkingOrderDts WorkingOrdList7;
    public WorkingOrderDts WorkingOrdList8;
    public WorkingOrderDts WorkingOrdList9;
    public OutrightPositionDts OutrightPosList0;
    public OutrightPositionDts OutrightPosList1;
    public OutrightPositionDts OutrightPosList2;
    public OutrightPositionDts OutrightPosList3;
    public OutrightPositionDts OutrightPosList4;
    public OutrightPositionDts OutrightPosList5;
    public OutrightPositionDts OutrightPosList6;
    public OutrightPositionDts OutrightPosList7;
    public OutrightPositionDts OutrightPosList8;
    public OutrightPositionDts OutrightPosList9;

    static OrderManagerResponseStatusDts()
    {
        int sz = Unsafe.SizeOf<OrderManagerResponseStatusDts>();
        if ((sz & 7) != 0) throw new System.Exception($"OrderManagerResponseStatusDts not 8B aligned: 8");
        if (sz != 1016) throw new System.Exception($"OrderManagerResponseStatusDts size mismatch: 8 != 1016");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 64)]
public struct WorkingOrderDts
{
    public int SecurityId;
    public ulong RequestId;
    public ulong ClOrdId;
    public ulong OrdId;
    public ulong Quantity;
    public double LimitPrice;
    public OrderTimeInForce TimeInForce;
    public long UnitContractCnt;
    public OrderSide Side;

    static WorkingOrderDts()
    {
        int sz = Unsafe.SizeOf<WorkingOrderDts>();
        if ((sz & 7) != 0) throw new System.Exception($"WorkingOrderDts not 8B aligned: 8");
        if (sz != 64) throw new System.Exception($"WorkingOrderDts size mismatch: 8 != 64");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 24)]
public struct OutrightPositionDts
{
    public int SecurityId;
    public ulong Quantity;
    public double Price;
    public OrderSide Side;

    static OutrightPositionDts()
    {
        int sz = Unsafe.SizeOf<OutrightPositionDts>();
        if ((sz & 7) != 0) throw new System.Exception($"OutrightPositionDts not 8B aligned: 8");
        if (sz != 24) throw new System.Exception($"OutrightPositionDts size mismatch: 8 != 24");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 56)]
public struct OrderManagerResponseRejectDts
{
    public long TimestampNs;
    public ulong RequestId;
    public CmeOrderManagerState CurrentState;
    public FixedAscii32 RejectDescription;

    static OrderManagerResponseRejectDts()
    {
        int sz = Unsafe.SizeOf<OrderManagerResponseRejectDts>();
        if ((sz & 7) != 0) throw new System.Exception($"OrderManagerResponseRejectDts not 8B aligned: 8");
        if (sz != 56) throw new System.Exception($"OrderManagerResponseRejectDts size mismatch: 8 != 56");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 48)]
public struct OrderManagerResponseSetRiskLimitDts
{
    public bool Success;
    public RiskAccountingLimitDts RiskLimit;

    static OrderManagerResponseSetRiskLimitDts()
    {
        int sz = Unsafe.SizeOf<OrderManagerResponseSetRiskLimitDts>();
        if ((sz & 7) != 0) throw new System.Exception($"OrderManagerResponseSetRiskLimitDts not 8B aligned: 8");
        if (sz != 48) throw new System.Exception($"OrderManagerResponseSetRiskLimitDts size mismatch: 8 != 48");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 24)]
public struct OrderManagerResponseLoginDts
{
    public byte NumMsgwIds;
    public byte ClOrdIdPrefix;
    public EnvironmentKind Environment;
    public LoginResponse Response;
    public byte MsgwIds0;
    public byte MsgwIds1;
    public byte MsgwIds2;
    public byte MsgwIds3;
    public byte MsgwIds4;
    public byte MsgwIds5;
    public byte MsgwIds6;
    public byte MsgwIds7;
    public byte MsgwIds8;
    public byte MsgwIds9;

    static OrderManagerResponseLoginDts()
    {
        int sz = Unsafe.SizeOf<OrderManagerResponseLoginDts>();
        if ((sz & 7) != 0) throw new System.Exception($"OrderManagerResponseLoginDts not 8B aligned: 8");
        if (sz != 24) throw new System.Exception($"OrderManagerResponseLoginDts size mismatch: 8 != 24");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
public struct OrderManagerResponsePingDts
{
    public long TimestampNs;

    static OrderManagerResponsePingDts()
    {
        int sz = Unsafe.SizeOf<OrderManagerResponsePingDts>();
        if ((sz & 7) != 0) throw new System.Exception($"OrderManagerResponsePingDts not 8B aligned: 8");
        if (sz != 8) throw new System.Exception($"OrderManagerResponsePingDts size mismatch: 8 != 8");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
public struct OrderManagerResponseConnectionClosingDts
{
    public long TimestampNs;

    static OrderManagerResponseConnectionClosingDts()
    {
        int sz = Unsafe.SizeOf<OrderManagerResponseConnectionClosingDts>();
        if ((sz & 7) != 0) throw new System.Exception($"OrderManagerResponseConnectionClosingDts not 8B aligned: 8");
        if (sz != 8) throw new System.Exception($"OrderManagerResponseConnectionClosingDts size mismatch: 8 != 8");
    }
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
public struct UtcTimeDts
{
    public long TimeNs;

    static UtcTimeDts()
    {
        int sz = Unsafe.SizeOf<UtcTimeDts>();
        if ((sz & 7) != 0) throw new System.Exception($"UtcTimeDts not 8B aligned: 8");
        if (sz != 8) throw new System.Exception($"UtcTimeDts size mismatch: 8 != 8");
    }
}

