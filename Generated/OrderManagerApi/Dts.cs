using System;
using System.Runtime.InteropServices;

namespace SchemaX_CodeGen.Generated.OrderManagerApi;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 64)]
public struct RiskAccountingLimitDts
{
    public FixedAscii32 Account;
    public double UnseenPnlLossUb;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 384)]
public struct OrderReportBusinessRejectDts
{
    public ushort RejectReason;
    public ushort RefTagId;
    public OrderMsgTypeKind RefMsgType;
    public FixedAscii32 RejectDescription;
    public ulong RequestId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;
    public bool ManualOrderInd;
    public ulong PartyListId;
    public byte IsAResend;
    public UtcTimeDts ExchangeTimestamp;
    public UtcTimeDts SendingTimestamp;
    public UtcTimeDts ReceiptTimestamp;
    public UtcTimeDts ExtractTimestamp;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 512)]
public struct OrderReportExecRptNewOrderDts
{
    public ulong RequestId;
    public double Price;
    public uint OrderQty;
    public double StopPx;
    public uint MinQty;
    public uint CumQty;
    public uint DisplayQty;
    public UtcTimeDts ExpireDate;
    public OrderTimeInForce TimeInForce;
    public int SecurityId;
    public OrderSide Side;
    public OrderKind OrdType;
    public FixedAscii32 ExecReportId;
    public ulong ClOrdId;
    public ulong OrdId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;
    public bool ManualOrderInd;
    public ulong PartyListId;
    public byte IsAResend;
    public UtcTimeDts ExchangeTimestamp;
    public UtcTimeDts SendingTimestamp;
    public UtcTimeDts ReceiptTimestamp;
    public UtcTimeDts ExtractTimestamp;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 576)]
public struct OrderReportExecRptModifyDts
{
    public uint LeavesQty;
    public ulong RequestId;
    public double Price;
    public uint OrderQty;
    public double StopPx;
    public uint MinQty;
    public uint CumQty;
    public uint DisplayQty;
    public UtcTimeDts ExpireDate;
    public OrderTimeInForce TimeInForce;
    public int SecurityId;
    public OrderSide Side;
    public OrderKind OrdType;
    public FixedAscii32 ExecReportId;
    public ulong ClOrdId;
    public ulong OrdId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;
    public bool ManualOrderInd;
    public ulong PartyListId;
    public byte IsAResend;
    public UtcTimeDts ExchangeTimestamp;
    public UtcTimeDts SendingTimestamp;
    public UtcTimeDts ReceiptTimestamp;
    public UtcTimeDts ExtractTimestamp;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 576)]
public struct OrderReportExecRptCancelDts
{
    public CancelReason CancelReason;
    public ulong RequestId;
    public double Price;
    public uint OrderQty;
    public double StopPx;
    public uint MinQty;
    public uint CumQty;
    public uint DisplayQty;
    public UtcTimeDts ExpireDate;
    public OrderTimeInForce TimeInForce;
    public int SecurityId;
    public OrderSide Side;
    public OrderKind OrdType;
    public FixedAscii32 ExecReportId;
    public ulong ClOrdId;
    public ulong OrdId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;
    public bool ManualOrderInd;
    public ulong PartyListId;
    public byte IsAResend;
    public UtcTimeDts ExchangeTimestamp;
    public UtcTimeDts SendingTimestamp;
    public UtcTimeDts ReceiptTimestamp;
    public UtcTimeDts ExtractTimestamp;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 576)]
public struct OrderReportExecRptStatusDts
{
    public ExecRptStatus OrdStatus;
    public uint LeavesQty;
    public FixedAscii32 RejectDescription;
    public bool IsLastStatusRequested;
    public ulong StatusReqId;
    public ulong RequestId;
    public double Price;
    public uint OrderQty;
    public double StopPx;
    public uint MinQty;
    public uint CumQty;
    public uint DisplayQty;
    public UtcTimeDts ExpireDate;
    public OrderTimeInForce TimeInForce;
    public int SecurityId;
    public OrderSide Side;
    public OrderKind OrdType;
    public FixedAscii32 ExecReportId;
    public ulong ClOrdId;
    public ulong OrdId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;
    public bool ManualOrderInd;
    public ulong PartyListId;
    public byte IsAResend;
    public UtcTimeDts ExchangeTimestamp;
    public UtcTimeDts SendingTimestamp;
    public UtcTimeDts ReceiptTimestamp;
    public UtcTimeDts ExtractTimestamp;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 576)]
public struct OrderReportExecRptTradeOutrightDts
{
    public OrderFillStatus FillStatus;
    public bool IsAggressor;
    public uint LeavesQty;
    public ulong RequestId;
    public double Price;
    public uint OrderQty;
    public uint CumQty;
    public double FillPrice;
    public uint FillQty;
    public ulong SecurityExecId;
    public UtcTimeDts TradeDate;
    public int SecurityId;
    public OrderSide Side;
    public OrderKind OrdType;
    public FixedAscii32 ExecReportId;
    public ulong ClOrdId;
    public ulong OrdId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;
    public bool ManualOrderInd;
    public ulong PartyListId;
    public byte IsAResend;
    public UtcTimeDts ExchangeTimestamp;
    public UtcTimeDts SendingTimestamp;
    public UtcTimeDts ReceiptTimestamp;
    public UtcTimeDts ExtractTimestamp;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 576)]
public struct OrderReportExecRptTradeSpreadDts
{
    public byte NumLegFills;
    public OrderFillStatus FillStatus;
    public bool IsAggressor;
    public uint LeavesQty;
    public ulong RequestId;
    public double Price;
    public uint OrderQty;
    public uint CumQty;
    public double FillPrice;
    public uint FillQty;
    public ulong SecurityExecId;
    public UtcTimeDts TradeDate;
    public int SecurityId;
    public OrderSide Side;
    public OrderKind OrdType;
    public FixedAscii32 ExecReportId;
    public ulong ClOrdId;
    public ulong OrdId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;
    public bool ManualOrderInd;
    public ulong PartyListId;
    public byte IsAResend;
    public UtcTimeDts ExchangeTimestamp;
    public UtcTimeDts SendingTimestamp;
    public UtcTimeDts ReceiptTimestamp;
    public UtcTimeDts ExtractTimestamp;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 512)]
public struct OrderReportExecRptTradeSpreadLegDts
{
    public uint CumQty;
    public OrderFillStatus FillStatus;
    public double FillPrice;
    public uint FillQty;
    public ulong SecurityExecId;
    public UtcTimeDts TradeDate;
    public int SecurityId;
    public OrderSide Side;
    public OrderKind OrdType;
    public FixedAscii32 ExecReportId;
    public ulong ClOrdId;
    public ulong OrdId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;
    public bool ManualOrderInd;
    public ulong PartyListId;
    public byte IsAResend;
    public UtcTimeDts ExchangeTimestamp;
    public UtcTimeDts SendingTimestamp;
    public UtcTimeDts ReceiptTimestamp;
    public UtcTimeDts ExtractTimestamp;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 512)]
public struct OrderReportExecRptEliminationDts
{
    public ulong RequestId;
    public double Price;
    public uint OrderQty;
    public double StopPx;
    public uint MinQty;
    public uint CumQty;
    public uint DisplayQty;
    public UtcTimeDts ExpireDate;
    public OrderTimeInForce TimeInForce;
    public int SecurityId;
    public OrderSide Side;
    public OrderKind OrdType;
    public FixedAscii32 ExecReportId;
    public ulong ClOrdId;
    public ulong OrdId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;
    public bool ManualOrderInd;
    public ulong PartyListId;
    public byte IsAResend;
    public UtcTimeDts ExchangeTimestamp;
    public UtcTimeDts SendingTimestamp;
    public UtcTimeDts ReceiptTimestamp;
    public UtcTimeDts ExtractTimestamp;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 576)]
public struct OrderReportExecRptRejectDts
{
    public OrderRejectionKind RejectKind;
    public ushort RejectCode;
    public FixedAscii32 RejectDescription;
    public double RejectingPriceBand;
    public ulong RequestId;
    public double Price;
    public uint OrderQty;
    public double StopPx;
    public uint MinQty;
    public uint CumQty;
    public uint DisplayQty;
    public UtcTimeDts ExpireDate;
    public OrderTimeInForce TimeInForce;
    public int SecurityId;
    public OrderSide Side;
    public OrderKind OrdType;
    public FixedAscii32 ExecReportId;
    public ulong ClOrdId;
    public ulong OrdId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;
    public bool ManualOrderInd;
    public ulong PartyListId;
    public byte IsAResend;
    public UtcTimeDts ExchangeTimestamp;
    public UtcTimeDts SendingTimestamp;
    public UtcTimeDts ReceiptTimestamp;
    public UtcTimeDts ExtractTimestamp;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 512)]
public struct OrderReportExecRptTradeAddendumOutrightDts
{
    public AddendumKind AddendumKind;
    public double FillPrice;
    public uint FillQty;
    public ulong SecurityExecId;
    public UtcTimeDts TradeDate;
    public int SecurityId;
    public OrderSide Side;
    public OrderKind OrdType;
    public FixedAscii32 ExecReportId;
    public ulong ClOrdId;
    public ulong OrdId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;
    public bool ManualOrderInd;
    public ulong PartyListId;
    public byte IsAResend;
    public UtcTimeDts ExchangeTimestamp;
    public UtcTimeDts SendingTimestamp;
    public UtcTimeDts ReceiptTimestamp;
    public UtcTimeDts ExtractTimestamp;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 512)]
public struct OrderReportExecRptTradeAddendumSpreadDts
{
    public byte NumLegFills;
    public AddendumKind AddendumKind;
    public double FillPrice;
    public uint FillQty;
    public ulong SecurityExecId;
    public UtcTimeDts TradeDate;
    public int SecurityId;
    public OrderSide Side;
    public OrderKind OrdType;
    public FixedAscii32 ExecReportId;
    public ulong ClOrdId;
    public ulong OrdId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;
    public bool ManualOrderInd;
    public ulong PartyListId;
    public byte IsAResend;
    public UtcTimeDts ExchangeTimestamp;
    public UtcTimeDts SendingTimestamp;
    public UtcTimeDts ReceiptTimestamp;
    public UtcTimeDts ExtractTimestamp;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 512)]
public struct OrderReportExecRptTradeAddendumSpreadLegDts
{
    public AddendumKind AddendumKind;
    public double FillPrice;
    public uint FillQty;
    public ulong SecurityExecId;
    public UtcTimeDts TradeDate;
    public int SecurityId;
    public OrderSide Side;
    public OrderKind OrdType;
    public FixedAscii32 ExecReportId;
    public ulong ClOrdId;
    public ulong OrdId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;
    public bool ManualOrderInd;
    public ulong PartyListId;
    public byte IsAResend;
    public UtcTimeDts ExchangeTimestamp;
    public UtcTimeDts SendingTimestamp;
    public UtcTimeDts ReceiptTimestamp;
    public UtcTimeDts ExtractTimestamp;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 448)]
public struct OrderReportOrderCancelRejectDts
{
    public ulong RequestId;
    public OrderRejectionKind RejectKind;
    public ushort RejectCode;
    public FixedAscii32 RejectDescription;
    public FixedAscii32 ExecReportId;
    public ulong ClOrdId;
    public ulong OrdId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;
    public bool ManualOrderInd;
    public ulong PartyListId;
    public byte IsAResend;
    public UtcTimeDts ExchangeTimestamp;
    public UtcTimeDts SendingTimestamp;
    public UtcTimeDts ReceiptTimestamp;
    public UtcTimeDts ExtractTimestamp;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 448)]
public struct OrderReportOrderCancelModifyRejectDts
{
    public double RejectingPriceBand;
    public ulong RequestId;
    public OrderRejectionKind RejectKind;
    public ushort RejectCode;
    public FixedAscii32 RejectDescription;
    public FixedAscii32 ExecReportId;
    public ulong ClOrdId;
    public ulong OrdId;
    public FixedAscii32 SenderId;
    public FixedAscii32 Location;
    public bool ManualOrderInd;
    public ulong PartyListId;
    public byte IsAResend;
    public UtcTimeDts ExchangeTimestamp;
    public UtcTimeDts SendingTimestamp;
    public UtcTimeDts ReceiptTimestamp;
    public UtcTimeDts ExtractTimestamp;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 512)]
public struct OrderReportMassActionDts
{
    public ulong RequestId;
    public ulong MassActionRptId;
    public FixedAscii32 SecurityGroup;
    public int SecurityId;
    public MassActionResponse Response;
    public MassActionScopeKind Scope;
    public byte TotalAffectedOrders;
    public bool IsLastFragment;
    public byte MarketSegmentId;
    public MassStatusRequestKind CancelRequestType;
    public OrderSide Side;
    public OrderKind OrdType;
    public OrderTimeInForce TimeInForce;
    public byte NumAffectedOrders;
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
    public bool ManualOrderInd;
    public ulong PartyListId;
    public byte IsAResend;
    public UtcTimeDts ExchangeTimestamp;
    public UtcTimeDts SendingTimestamp;
    public UtcTimeDts ReceiptTimestamp;
    public UtcTimeDts ExtractTimestamp;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 384)]
public struct OrderReportPartyDetailsDefinitionDts
{
    public ulong SelfMatchPreventionId;
    public OrderSelfMatchInst SelfMatchPreventionInst;
    public byte NumPartyDetails;
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
    public ulong PartyListId;
    public byte IsAResend;
    public UtcTimeDts ExchangeTimestamp;
    public UtcTimeDts SendingTimestamp;
    public UtcTimeDts ReceiptTimestamp;
    public UtcTimeDts ExtractTimestamp;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 384)]
public struct OrderReportPartyDetailsListDts
{
    public RequestResult RequestResult;
    public ulong RequestId;
    public ulong SelfMatchPreventionId;
    public OrderSelfMatchInst SelfMatchPreventionInst;
    public ushort TotalNumParties;
    public byte NumPartyDetails;
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
    public bool IsLastFragment;
    public ulong PartyListId;
    public byte IsAResend;
    public UtcTimeDts ExchangeTimestamp;
    public UtcTimeDts SendingTimestamp;
    public UtcTimeDts ReceiptTimestamp;
    public UtcTimeDts ExtractTimestamp;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1088)]
public struct OrderManagerResponseStatusDts
{
    public long TimestampNs;
    public CmeOrderManagerState LatestState;
    public ulong NumEvents;
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
    public double AccountPnl;
    public ulong NumWorkingOrd;
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
    public ulong NumOutrightPos;
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
    public ulong RemainingAccountStatusMessageCnt;
    public ulong RemainingStatusMessageCnt;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 128)]
public struct WorkingOrderDts
{
    public ulong RequestId;
    public ulong ClOrdId;
    public ulong OrdId;
    public int SecurityId;
    public OrderSide Side;
    public ulong Quantity;
    public double LimitPrice;
    public OrderTimeInForce TimeInForce;
    public long UnitContractCnt;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 64)]
public struct OutrightPositionDts
{
    public int SecurityId;
    public OrderSide Side;
    public ulong Quantity;
    public double Price;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 64)]
public struct OrderManagerResponseRejectDts
{
    public long TimestampNs;
    public CmeOrderManagerState CurrentState;
    public ulong RequestId;
    public FixedAscii32 RejectDescription;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 128)]
public struct OrderManagerResponseSetRiskLimitDts
{
    public RiskAccountingLimitDts RiskLimit;
    public bool Success;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 64)]
public struct OrderManagerResponseLoginDts
{
    public LoginResponse Response;
    public byte NumMsgwIds;
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
    public EnvironmentKind Environment;
    public byte ClOrdIdPrefix;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 64)]
public struct OrderManagerResponsePingDts
{
    public long TimestampNs;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 64)]
public struct OrderManagerResponseConnectionClosingDts
{
    public long TimestampNs;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 64)]
public struct UtcTimeDts
{
    public long TimeNs;
}

