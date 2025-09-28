using System;
using System.Runtime.InteropServices;

namespace SchemaX_CodeGen.Generated.DataFeedApi;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 64)]
public struct UtcTimeDts
{
    public long TimeNs;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 256)]
public struct CmeFeedManagerTimestampsDts
{
    public UtcTimeDts Exchange;
    public UtcTimeDts Sending;
    public UtcTimeDts Receipt;
    public UtcTimeDts Extract;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 64)]
public struct CmeFeedPriceLevelDts
{
    public uint OrderCnt;
    public uint Quantity;
    public double Price;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 384)]
public struct CmeFeedUpdateGroupStatusDts
{
    public FixedAscii32 GroupName;
    public int MdpChannelId;
    public ushort InstGroupNum;
    public FixedAscii32 AssetCode;
    public CmeFeedManagerTimestampsDts Timestamp;
    public TradingStatus TradingStatus;
    public HaltReason HaltReason;
    public TradingEvent TradingEvent;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 320)]
public struct CmeFeedUpdateInstStatusDts
{
    public int SecurityId;
    public int MdpChannelId;
    public ushort InstNum;
    public CmeFeedManagerTimestampsDts Timestamp;
    public TradingStatus TradingStatus;
    public HaltReason HaltReason;
    public TradingEvent TradingEvent;
    public bool DailyLimitPriceLbValid;
    public double DailyLimitPriceLb;
    public bool DailyLimitPriceUbValid;
    public double DailyLimitPriceUb;
    public bool MaxPriceVariationValid;
    public double MaxPriceVariation;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 320)]
public struct CmeFeedUpdateIndicativeOpeningDts
{
    public int SecurityId;
    public int MdpChannelId;
    public ushort InstNum;
    public CmeFeedManagerTimestampsDts Timestamp;
    public uint Quantity;
    public double Price;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 320)]
public struct CmeFeedUpdateOpeningPriceDts
{
    public int SecurityId;
    public int MdpChannelId;
    public ushort InstNum;
    public CmeFeedManagerTimestampsDts Timestamp;
    public double Price;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 448)]
public struct CmeFeedUpdateSettlementDts
{
    public int SecurityId;
    public int MdpChannelId;
    public ushort InstNum;
    public CmeFeedManagerTimestampsDts Timestamp;
    public bool PriceValid;
    public double Price;
    public UtcTimeDts PriceTimestamp;
    public bool PreliminaryPriceValid;
    public double PreliminaryPrice;
    public UtcTimeDts PreliminaryPriceTimestamp;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 320)]
public struct CmeFeedUpdateTradeDts
{
    public int SecurityId;
    public int MdpChannelId;
    public ushort InstNum;
    public CmeFeedManagerTimestampsDts Timestamp;
    public BookStatus BookStatus;
    public AggressorSideKind AggressorSideKind;
    public uint OrderCnt;
    public uint Quantity;
    public double Price;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 640)]
public struct CmeFeedUpdateSideDts
{
    public int SecurityId;
    public int MdpChannelId;
    public ushort InstNum;
    public CmeFeedManagerTimestampsDts Timestamp;
    public BookStatus BookStatus;
    public BookSideKind SideKind;
    public BookSideOrdersKind OrdersKind;
    public bool IsLastSideOfBook;
    public CmeFeedPriceLevelDts Levels0;
    public CmeFeedPriceLevelDts Levels1;
    public CmeFeedPriceLevelDts Levels2;
    public CmeFeedPriceLevelDts Levels3;
    public CmeFeedPriceLevelDts Levels4;
    public CmeFeedPriceLevelDts Levels5;
    public CmeFeedPriceLevelDts Levels6;
    public CmeFeedPriceLevelDts Levels7;
    public CmeFeedPriceLevelDts Levels8;
    public CmeFeedPriceLevelDts Levels9;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 320)]
public struct CmeFeedUpdateLastMessageForEventDts
{
    public int MdpChannelId;
    public CmeFeedManagerTimestampsDts Timestamp;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 64)]
public struct CmeFeedUpdateFinishedAllDts
{
    public UtcTimeDts ExtractTimestamp;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 64)]
public struct CmeFeedTradeStatisticsDts
{
    public ushort InstNum;
    public double HighPrice;
    public double LowPrice;
    public double LastPrice;
    public ulong Volume;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 4032)]
public struct CmeFeedInstrumentStateDts
{
    public ushort InstNum;
    public int SecurityId;
    public CmeFeedUpdateInstStatusDts InstStatus;
    public CmeFeedUpdateTradeDts LastTrade;
    public CmeFeedUpdateOpeningPriceDts OpeningPrice;
    public CmeFeedUpdateSettlementDts Settlement;
    public CmeFeedUpdateSideDts BidBook;
    public CmeFeedUpdateSideDts ImpBidBook;
    public CmeFeedUpdateSideDts AskBook;
    public CmeFeedUpdateSideDts ImpAskBook;
    public bool InstStatusValid;
    public bool LastTradeValid;
    public bool OpeningPriceValid;
    public bool SettlementValid;
    public bool BidBookValid;
    public bool ImpBidBookValid;
    public bool AskBookValid;
    public bool ImpAskBookValid;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 64)]
public struct CmeLegDefinitionDts
{
    public int SecurityId;
    public int Ratio;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 896)]
public struct CmeFuturesDefinitionDts
{
    public FixedAscii32 Symbol;
    public int SecurityId;
    public int MarketSegmentGatewayId;
    public int MdpChannelId;
    public FixedAscii32 SecurityGroupCode;
    public CmeAssetKind AssetKind;
    public FixedAscii32 AssetCode;
    public FixedAscii32 CfiCode;
    public CmeSecuritySubtype SecuritySubtype;
    public FixedAscii32 SecuritySubtypeCode;
    public FixedAscii32 MaturityMonthyear;
    public CmeAssetEquivalenceKind EquivalenceKind;
    public CmeAssetKind EquivalentAssetKind;
    public CmePriceValueKind PriceValueKind;
    public double TruePriceOffset;
    public double PriceToCurrency;
    public double MinPriceIncrement;
    public FixedAscii32 CurrencyCode;
    public FixedAscii32 SettleCurrencyCode;
    public FixedAscii32 UnitOfMeasureCode;
    public double UnitOfMeasureQuantity;
    public bool LimitPricesValid;
    public double HighLimitPrice;
    public double LowLimitPrice;
    public bool MaxPriceVariationValid;
    public double MaxPriceVariation;
    public int BookDepth;
    public bool HasImpliedBook;
    public CmeMatchAlgorithm MatchAlgorithm;
    public int MinTradeVolume;
    public int MaxTradeVolume;
    public bool RelativeToPreviousSettlement;
    public UtcTimeDts ActivationTime;
    public UtcTimeDts LastEligibleTradeTime;
    public CmeLegDefinitionDts Legs0;
    public CmeLegDefinitionDts Legs1;
    public CmeLegDefinitionDts Legs2;
    public CmeLegDefinitionDts Legs3;
    public CmeLegDefinitionDts Legs4;
    public CmeLegDefinitionDts Legs5;
    public CmeLegDefinitionDts Legs6;
    public CmeLegDefinitionDts Legs7;
    public CmeLegDefinitionDts Legs8;
    public CmeLegDefinitionDts Legs9;
    public bool IsFeedAvailable;
    public ushort InstNum;
    public ushort GroupNum;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 4544)]
public struct CmeFuturesDefinitionResponseDts
{
    public CmeFuturesDefinitionDts Definitions0;
    public CmeFuturesDefinitionDts Definitions1;
    public CmeFuturesDefinitionDts Definitions2;
    public CmeFuturesDefinitionDts Definitions3;
    public CmeFuturesDefinitionDts Definitions4;
    public CmeFuturesDefinitionDts Definitions5;
    public CmeFuturesDefinitionDts Definitions6;
    public CmeFuturesDefinitionDts Definitions7;
    public CmeFuturesDefinitionDts Definitions8;
    public CmeFuturesDefinitionDts Definitions9;
    public FixedAscii32 Error;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 128)]
public struct CmeFeedRequestSymbolAvailabilityResponseDts
{
    public bool Success;
    public AvailabilityAction Action;
    public ushort InstNum;
    public int SecurityId;
    public FixedAscii32 Symbol;
    public FixedAscii32 Error;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 64)]
public struct CmeFeedClientSubscribeResponseDts
{
    public CmeFeedClientSubscribeResponseKind which;
    public CmeFeedClientSubscribeResult Result;
    public int BadSecurityIdList0;
    public int BadSecurityIdList1;
    public int BadSecurityIdList2;
    public int BadSecurityIdList3;
    public int BadSecurityIdList4;
    public int BadSecurityIdList5;
    public int BadSecurityIdList6;
    public int BadSecurityIdList7;
    public int BadSecurityIdList8;
    public int BadSecurityIdList9;
    public ushort BadInstList0;
    public ushort BadInstList1;
    public ushort BadInstList2;
    public ushort BadInstList3;
    public ushort BadInstList4;
    public ushort BadInstList5;
    public ushort BadInstList6;
    public ushort BadInstList7;
    public ushort BadInstList8;
    public ushort BadInstList9;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 320)]
public struct CmeFuturesDefinitionSpecDts
{
    public CmeAssetKind AssetKind;
    public CmeSecuritySubtype SecuritySubtype;
    public FixedAscii32 SecurityGroupCode;
    public UtcTimeDts ActivationTimeLb;
    public UtcTimeDts ActivationTimeUb;
    public UtcTimeDts LastEligibleTradeTimeLb;
    public UtcTimeDts LastEligibleTradeTimeUb;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 64)]
public struct FeedApiLoginResponseDts
{
    public FeedApiLoginResult Result;
    public FeedApiSetSymbolListResult ListResult;
    public FeedApiEnvironment FeedEnv;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 64)]
public struct FeedApiSetSymbolListResponseDts
{
    public FeedApiSetSymbolListResult ListResult;
}

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 128)]
public struct FeedApiGetSymbolListContentsResponseDts
{
    public FixedAscii32 SymbolList0;
    public FixedAscii32 SymbolList1;
    public FixedAscii32 SymbolList2;
    public FixedAscii32 SymbolList3;
    public FixedAscii32 SymbolList4;
    public FixedAscii32 SymbolList5;
    public FixedAscii32 SymbolList6;
    public FixedAscii32 SymbolList7;
    public FixedAscii32 SymbolList8;
    public FixedAscii32 SymbolList9;
    public int SecurityIdList0;
    public int SecurityIdList1;
    public int SecurityIdList2;
    public int SecurityIdList3;
    public int SecurityIdList4;
    public int SecurityIdList5;
    public int SecurityIdList6;
    public int SecurityIdList7;
    public int SecurityIdList8;
    public int SecurityIdList9;
    public FixedAscii32 ErrorText;
}

