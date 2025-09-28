namespace SchemaX_CodeGen.Generated.DataFeedApi;

public enum BookSideKind : ushort
{
    invalid,
    unknown,
    bid,
    ask,
}


public enum BookSideOrdersKind : ushort
{
    invalid,
    direct,
    implied,
    combined,
    both,
}


public enum AggressorSideKind : ushort
{
    invalid,
    none,
    buy,
    sell,
}


public enum TradingStatus : ushort
{
    preOpen,
    halted,
    paused,
    regular,
    closed,
    fast,
    quotationOnly,
    openingDelay,
    marketOnCloseImbalanceSell,
    noMarketImbalance,
    noMarketOnCloseImbalance,
    noOpenNoResume,
    iTSPreOpening,
    newPriceIndication,
    tradeDisseminationTime,
    notTradedOnThisMarket,
    priceIndication,
    tradingRangeIndication,
    marketImbalanceBuy,
    marketImbalanceSell,
    marketOnCloseImbalanceBuy,
    invalid,
    preCross,
    cross,
    noCancel,
    closing,
    postClose,
    openingAuction,
    openingRotation,
    openingAuctionFreeze,
    intradayAuction,
    intradayAuctionFreeze,
    circuitBreakerAuction,
    circuitBreakerAuctionFreeze,
    closingAuction,
    closingAuctionFreeze,
    expired,
    preClose,
    suspended,
    shortSaleRestriction,
    limitUpLimitDown,
    implicationDisabled,
    closingPriceCrossing,
    endOfPostClose,
    notAvailableForTrading,
    noChange,
    outOfSession,
    acceptingOrderInput,
    notAcceptingOrderInput,
    tradingHaltAcceptingOrderInput,
    tradingHaltNotAcceptingOrderInput,
    releaseOfTradingHalt,
    releaseOfItayose,
    releaseOfTradingSuspension,
    nonFirmQuote,
    shortSaleRestrictionContinued,
    shortSaleRestrictionDeactivated,
    bidSideTradingSuspended,
    askSideTradingSuspended,
    startOfAuction,
    endOfAuction,
    iPOAuction,
    iPOAuctionFreeze,
    offBookReporting,
    noReferencePrice,
    volatilityInterruption,
    marketOrderImbalanceExtension,
    priceMonitoringExtension,
    tradingAtLast,
    orderCancel,
    availableOnTradingPlatform,
    tradeAtClose,
    frozen,
    opaAuction,
    tradingStop,
    frozenForContinuousAuction,
    endOfRegularTrading,
    nonOpening,
    liquidityProviderBidOnly,
    unreliable,
    recovered,
    unknown,
}


public enum HaltReason : ushort
{
    suspendedBySurveillance,
    trading,
    instrumentAuthorization,
    returnToNormalState,
    newsDissemination,
    orderImbalance,
    limitUpLimitDown,
    newsPending,
    equipmentChangeOver,
    subPennyTrading,
    marketWideCircuitBreakerLevel1,
    marketWideCircuitBreakerLevel2,
    marketWideCircuitBreakerLevel3,
    groupSchedule,
    marketEvent,
    instrumentActivation,
    instrumentExpiration,
    recoveryInProcess,
    noOpenNoResume,
    operationalHalt,
    reasonNotAvailable,
    iPONotYetTrading,
    iPODeferred,
    iPOOrderAcceptancePeriod,
    iPOPreLaunchPeriod,
    notApplicable,
    additionalInformationRequested,
    regulatoryConcern,
    mergerEffective,
    etfComponentPricesNotAvailable,
    corporateAction,
    newSecurityOffering,
    intradayIndicativeValueNotAvailable,
    unknown,
}


public enum TradingEvent : ushort
{
    tradingHalt,
    tradingResumption,
    quotationResumption,
    resumeOpen,
    endOfTradingSession,
    pauseInTrading,
    symbolClear,
    volatilityTradingPause,
    noEvent,
    noCancel,
    changeOfTradingSessionResetStatistics,
    impliedMatchingOn,
    impliedMatchingOff,
    lULDPriceBand,
    startOfAuction,
    endOfAuction,
    unknown,
}


public enum BookStatus : ushort
{
    complete,
    incomplete,
    recovery,
    replay,
    unknown,
}


public enum CmeFeedManagerUpdateKind : ushort
{
    GroupStatus = 0,
    InstStatus = 1,
    IndicativeOpening = 2,
    OpeningPrice = 3,
    Settlement = 4,
    Trade = 5,
    Side = 6,
    LastMessageForEvent = 7,
    FinishedAll = 8,
    Firehose = 9,
    Subscribe = 10,
    SubscribeResp = 11,
    InstState = 12,
    DefinitionResp = 13,
    DefinitionReq = 14,
    SymbolAvailReq = 15,
    SymbolAvailResp = 16,
    FeedApiLogin = 17,
    FeedApiLoginResp = 18,
    FeedApiReject = 19,
    FeedApiSetSymbolList = 20,
    FeedApiSetSymbolListResp = 21,
    FeedApiGetSymbolListContents = 22,
    FeedApiGetSymbolListContentsResp = 23,
    undefined = 65535,
}


public enum AvailabilityAction : ushort
{
    @add,
    @remove,
}


public enum FirehoseAction : ushort
{
    unsubscribe,
    subscribe,
}


public enum SubscriptionAction : ushort
{
    unsubscribe,
    subscribe,
    subscribeAndGetState,
}


public enum CmeFeedClientSubscribeKind : ushort
{
    SecurityIdList = 0,
    InstList = 1,
    undefined = 65535,
}


public enum CmeFeedClientSubscribeResult : ushort
{
    success,
    failedOrdersKind,
    failedBadSecurityId,
    failedBadInstNum,
    failedDepthValue,
    invalid,
}


public enum CmeFeedClientSubscribeResponseKind : ushort
{
    BadSecurityIdList = 0,
    BadInstList = 1,
    undefined = 65535,
}


public enum CmeFuturesDefinitionRequestKind : ushort
{
    Specs = 0,
    Symbols = 1,
    undefined = 65535,
}


public enum CmeFeedRequestSymbolAvailabilityKind : ushort
{
    Symbol = 0,
    SecurityId = 1,
    undefined = 65535,
}


public enum FeedApiLoginResult : ushort
{
    success,
    failedUnknownUser,
    failedBadPassword,
    invalid,
}


public enum FeedApiSetSymbolListResult : ushort
{
    success,
    failedListNoPermission,
    failedListNotFound,
    failedAddListNoPermission,
    failedInvalidListNameFormat,
    invalid,
}


public enum FeedApiEnvironment : ushort
{
    invalid,
    production,
    newRelease,
    simulation,
    simulationAccelerated,
}


public enum FeedApiRejectReason : ushort
{
    notLoggedIn,
    noSymbolListSet,
}


public enum CmeAssetEquivalenceKind : ushort
{
    invalid,
    none,
    isSubOf,
    isTasTo,
}


public enum CmePriceValueKind : ushort
{
    invalid,
    direct,
    settlementRelative,
    tas,
}


public enum CmeAssetKind : ushort
{
    invalid,
    none,
    corn,
    cornMini,
    cornTas,
    wheat,
    wheatMini,
    wheatTas,
    kcWheat,
    kcWheatMini,
    kcWheatTas,
    oat,
    roughRice,
    soybean,
    soybeanMini,
    soybeanTas,
    soybeanMeal,
    soybeanMealTas,
    soybeanOil,
    soybeanOilTas,
    soybeanCrush,
    feederCattle,
    leanHog,
    liveCattle,
    lumber,
    brentCrudeOilLastDay,
    brentCrudeOilLastDayTas,
    lightSweetCrudeOil,
    lightSweetCrudeOilTas,
    lightSweetCrudeMini,
    lightSweetCrudeMicro,
    nyHarborUlsd,
    nyHarborUlsdTas,
    rbobGasoline,
    rbobGasolineTas,
    henryHubNatGas,
    henryHubNatGasPenUlt,
    eminiNatGas,
    microNatGas,
    henryHubNatGasLastDay,
    eurodollar,
    fedFunds,
    sofr1Month,
    sofr3Month,
    sofr3VsEurodollarSed,
    sofr3VsEurodollarSep,
    bSBY,
    us2Yr,
    us3Yr,
    us5Yr,
    us10Yr,
    usUltra10Yr,
    us20Yr,
    usUltraBond,
    usBond,
    us2YrVsUsUltraBond,
    us2YrVsUs10Yr,
    us2YrVsUsUltra10Yr,
    us2YrVsUsBond,
    us2YrVsUs3Yr,
    us2YrVsUs5YrRatioA,
    us2YrVsUs5YrRatioB,
    us2YrVsUs5YrRatioC,
    us3YrVsUsUltraBond,
    us3YrVsUs10Yr,
    us3YrVsUsUltra10Yr,
    us3YrVsUsBond,
    us3YrVsUs5Yr,
    us5YrVsUsUltraBond,
    us5YrVsUs10YrRatioA,
    us5YrVsUs10YrRatioB,
    us5YrVsUs10YrRatioC,
    us5YrVsUsUltra10Yr,
    us5YrVsUsBond,
    us5YrVsUs20YrRatioA,
    us5YrVsUs20YrRatioB,
    us10YrVsUsBondRatioA,
    us10YrVsUsBondRatioB,
    us10YrVsUsBondRatioC,
    us10YrVsUs20YrRatioA,
    us10YrVsUs20YrRatioB,
    us10YrVsUsUltraBondRatioA,
    us10YrVsUsUltraBondRatioB,
    us10YrVsUsUltra10YrRatioA,
    us10YrVsUsUltra10YrRatioB,
    usUltra10YrVsUsBond,
    usUltra10YrVsUs20YrRatioA,
    usUltra10YrVsUs20YrRatioB,
    usUltra10YrVsUsUltraBond,
    usBondVsUs20YrRatioA,
    usBondVsUs20YrRatioB,
    usBondVsUsUltraBondRatioA,
    usBondVsUsUltraBondRatioB,
    us20YrVsUsUltraBondRatioA,
    us20YrVsUsUltraBondRatioB,
    macSwap5YrUsd,
    macSwap10YrUsd,
    macSwap5YrUsdVsMacSwap10YrUsd,
    micro2YrYield,
    micro5YrYield,
    micro10YrYield,
    micro30YrYield,
    eminiNasdaq100,
    microEminiNasdaq100,
    eminiRussell1000,
    eminiRussell1000Growth,
    eminiRussell1000Value,
    eminiRussell2000,
    microEminiRussell2000,
    eminiSp500,
    microEminiSp500,
    eminiSpMidCap400,
    sp500,
    sp500AnnualDividend,
    dowJonesUSRealEstate,
    eminiDjia,
    microEminiDjia,
    nikkei225Usd,
    communicationServicesSector,
    consumerDiscretionarySector,
    consumerStaplesSector,
    energySector,
    financialSector,
    healthCareSector,
    industrialSector,
    materialsSector,
    realEstateSector,
    technologySector,
    utilitiesSector,
    ftseEmerging,
    bitcoin,
    microBitcoin,
    ether,
    microEther,
    audInUsd,
    gbpInUsd,
    cadInUsd,
    eurInUsd,
    jpyInUsd,
    mxnInUsd,
    chfInUsd,
    nokInUsd,
    nzdInUsd,
    sekInUsd,
    brlInUsd,
    inrInUsd,
    krwInUsd,
    plnInUsd,
    rubInUsd,
    zarInUsd,
    eminiEurInUsd,
    eminiJpyInUsd,
    emicroAudInUsd,
    emicroGbpInUsd,
    emicroCadInUsd,
    emicroEurInUsd,
    emicroJpyInUsd,
    emicroChfInUsd,
    emicroInrInUsd,
    gold,
    copper,
    silver,
    palladium,
    platinum,
    shanghaiGold,
    usMwHotRolledCoilSteel,
    aluminum,
    eminiGold,
    eminiCopper,
    eminiSilver,
    microGold,
    microSilver,
}


public enum CmeSecuritySubtype : ushort
{
    invalid,
    outright,
    bundle,
    bundleSpread,
    butterfly,
    standardCalendarSpread,
    equityCalendarSpread,
    foreignExchangeCalendarSpread,
    calendar,
    condor,
    crackOneOne,
    doubleButterfly,
    tasCalendarSpread,
    interCommodity,
    monthPack,
    pack,
    packButterfly,
    psPackSpread,
    reducedTick,
    fsStrip,
    saStrip,
    balanacedStripSpread,
    unbalancedStrip,
    energyIntercommodityStrip,
    interestRateIntercommoditySpread,
    intercommoditySpread,
    commoditiesIntercommoditySpread,
    bmdFuturesStrip,
    invoiceSwapSpread,
    invoiceSwapCalendarSpread,
    invoiceSwapSwitchSpread,
    treasuryTailSpread,
    henryHubIntercommodity,
    energyFuturesIntercommoditySpread,
    reducedTickIntercommoditySpread,
    interExchangeReducedTickRatioSpread,
    cmeFxLinkNoninverted,
    cmeFxLinkInverted,
    averagedPriceBundle,
}


public enum CmeMatchAlgorithm : ushort
{
    invalid,
    fifo,
    configurable,
    prorata,
    allocation,
    fifoWithLmm,
    thresholdProrata,
    fifoWithTopAndLmm,
    thresholdProrataWithLmm,
    eurodollarOptions,
}


