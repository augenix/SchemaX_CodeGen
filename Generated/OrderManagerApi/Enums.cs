namespace SchemaX_CodeGen.Generated.OrderManagerApi;

public enum OrderKind : ushort
{
    invalid,
    marketWithProtection,
    limit,
    stopWithProtection,
    stopLimit,
    marketWithLeftoverAsLimit,
}


public enum OrderTimeInForce : ushort
{
    invalid,
    day,
    gtc,
    gtd,
    fak,
}


public enum OrderSide : ushort
{
    invalid,
    buy,
    sell,
}


public enum MassActionScopeKind : ushort
{
    invalid,
    instrument,
    all,
    marketSegment,
    productGroup,
}


public enum MassStatusRequestKind : ushort
{
    invalid,
    operatorId,
    account,
    all,
}


public enum OrderSelfMatchInst : ushort
{
    invalid,
    newest,
    oldest,
}


public enum OrderPartyDetailsRole : ushort
{
    invalid,
    takeUpFirm,
    takeUpAccount,
    executingFirm,
    @operator,
    customerAccount,
    internalOnlyIlinkId,
}


public enum CmdKind : ushort
{
    invalid,
    noCommand,
    shutdown,
    run,
    pause,
    kill,
    reqStatus,
}


public enum OrderMsgTypeKind : ushort
{
    invalid,
    newOrder,
    orderCancelReplace,
    orderCancel,
    quoteCancel,
    orderStatus,
    massAction,
    massStatus,
    partyDetailsDef,
    partyDetailsList,
    sequence,
}


public enum CancelReason : ushort
{
    invalid,
    exchange,
    cancelledNotBest,
    cancelOnDisconnect,
    restingSelfMatch,
    cmeGlobexCreditControls,
    cmeOne,
    riskManagementAPI,
    aggressingSelfMatch,
    minQtyViolation,
    cancelRFCOrder,
    contractExpiration,
    systemCancel,
}


public enum ExecRptStatus : ushort
{
    invalid,
    @new,
    partialFill,
    completeFill,
    cancelled,
    replaced,
    eliminated,
    rejected,
    undefined,
}


public enum OrderFillStatus : ushort
{
    invalid,
    completeFill,
    partialFill,
}


public enum OrderRejectionKind : ushort
{
    invalid,
    marketNotOpen,
    priceBand,
    invalidOrderParameter,
    partyDetails,
    other,
    orderManagerState,
}


public enum AddendumKind : ushort
{
    invalid,
    cancel,
    correction,
}


public enum MassActionResponse : ushort
{
    invalid,
    rejected,
    accepted,
}


public enum RequestResult : ushort
{
    invalid,
    validRequest,
    noMatchingData,
    notAuthorized,
    dataTempUnavailable,
}


public enum CmeOrderManagerState : ushort
{
    invalid,
    starting,
    paused,
    running,
    error,
    killed,
    failed,
    shutdown,
}


public enum CmeOrderManagerEvent : ushort
{
    invalid,
    runRejectedOnIlinkDisconnect,
    runRejectedOnRisk,
    runRejectedOnOperatorId,
    orderErrorPaused,
    ilinkDisconnectPaused,
    riskPaused,
    orderChange,
    accountStateChange,
    fill,
    orderCanceled,
    cancelFailed,
    ilinkFailed,
    loginFailedUserName,
    loginFailedConfigName,
}


public enum RiskAccountingState : ushort
{
    invalid,
    awaitingInit,
    running,
    riskPaused,
    failed,
}


public enum LoginResponse : ushort
{
    invalid,
    success,
    failedUnknownUser,
    failedBadPassword,
    failedConfigName,
    failedConfigPermissions,
    failedPingInterval,
    failedPriorLogin,
    failedOther,
    enumEnd,
}


public enum EnvironmentKind : ushort
{
    invalid,
    production,
    newRelease,
    simulation,
    simulationAccelerated,
    enumEnd,
}


public enum OrderManagerRequestClassKind : ushort
{
    orderRequestNewOrder,
    orderRequestCancelReplace,
    orderRequestCancel,
    orderRequestStatus,
    orderRequestMassStatus,
    orderRequestMassAction,
    orderRequestPartyDetailsDefinition,
    orderRequestPartyDetailsList,
    orderManagerCommand,
    orderManagerCommandAckAccountEvents,
    orderManagerCommandSetRiskLimit,
    orderManagerCommandLogin,
    orderManagerCommandPing,
}


public enum OrderManagerResponseClassKind : ushort
{
    orderReportBusinessReject,
    orderReportExecRptNewOrder,
    orderReportExecRptModify,
    orderReportExecRptCancel,
    orderReportExecRptStatus,
    orderReportExecRptTradeOutright,
    orderReportExecRptTradeSpread,
    orderReportExecRptTradeSpreadLeg,
    orderReportExecRptElimination,
    orderReportExecRptReject,
    orderReportExecRptTradeAddendumOutright,
    orderReportExecRptTradeAddendumSpread,
    orderReportExecRptTradeAddendumSpreadLeg,
    orderReportOrderCancelReject,
    orderReportOrderCancelModifyReject,
    orderReportMassAction,
    orderReportPartyDetailsDefinition,
    orderReportPartyDetailsList,
    orderManagerResponseStatus,
    orderManagerResponseReject,
    orderManagerResponseSetRiskLimit,
    orderManagerResponseLogin,
    orderManagerResponsePing,
    orderManagerResponseConnectionClosing,
}


public enum OrderManagerRequestUnionKind : ushort
{
    No = 0,
    Cr = 1,
    C = 2,
    S = 3,
    Ms = 4,
    Ma = 5,
    Pdd = 6,
    Pdl = 7,
    Cmd = 8,
    Aae = 9,
    Srl = 10,
    L = 11,
    P = 12,
    undefined = 65535,
}


public enum OrderManagerResponseUnionKind : ushort
{
    Br = 0,
    No = 1,
    M = 2,
    C = 3,
    S = 4,
    To = 5,
    Ts = 6,
    Tsl = 7,
    E = 8,
    R = 9,
    Tao = 10,
    Tas = 11,
    Tasl = 12,
    Cr = 13,
    Cmr = 14,
    Ma = 15,
    Pdd = 16,
    Pdl = 17,
    Mrs = 18,
    Mrr = 19,
    Srl = 20,
    L = 21,
    P = 22,
    Cc = 23,
    undefined = 65535,
}


