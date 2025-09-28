using System;
using System.Runtime.CompilerServices;

namespace SchemaX_CodeGen.Generated.DataFeedApi;

public static class DtsFactory
{
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref UtcTimeDts msg, in UtcTimeDecoder reader)
    {
        msg.TimeNs = reader.TimeNs;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref CmeFeedManagerTimestampsDts msg, in CmeFeedManagerTimestampsDecoder reader)
    {
        var ExchangeStruct = reader.Exchange.Reader();
        FromDecoder(ref msg.Exchange, in ExchangeStruct);
        var SendingStruct = reader.Sending.Reader();
        FromDecoder(ref msg.Sending, in SendingStruct);
        var ReceiptStruct = reader.Receipt.Reader();
        FromDecoder(ref msg.Receipt, in ReceiptStruct);
        var ExtractStruct = reader.Extract.Reader();
        FromDecoder(ref msg.Extract, in ExtractStruct);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref CmeFeedPriceLevelDts msg, in CmeFeedPriceLevelDecoder reader)
    {
        msg.OrderCnt = reader.OrderCnt;
        msg.Quantity = reader.Quantity;
        msg.Price = reader.Price;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref CmeFeedUpdateGroupStatusDts msg, in CmeFeedUpdateGroupStatusDecoder reader)
    {
        msg.GroupName.Set(reader.GroupName);
        msg.MdpChannelId = reader.MdpChannelId;
        msg.InstGroupNum = reader.InstGroupNum;
        msg.AssetCode.Set(reader.AssetCode);
        var TimestampStruct = reader.Timestamp.Reader();
        FromDecoder(ref msg.Timestamp, in TimestampStruct);
        msg.TradingStatus = reader.TradingStatus;
        msg.HaltReason = reader.HaltReason;
        msg.TradingEvent = reader.TradingEvent;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref CmeFeedUpdateInstStatusDts msg, in CmeFeedUpdateInstStatusDecoder reader)
    {
        msg.SecurityId = reader.SecurityId;
        msg.MdpChannelId = reader.MdpChannelId;
        msg.InstNum = reader.InstNum;
        var TimestampStruct = reader.Timestamp.Reader();
        FromDecoder(ref msg.Timestamp, in TimestampStruct);
        msg.TradingStatus = reader.TradingStatus;
        msg.HaltReason = reader.HaltReason;
        msg.TradingEvent = reader.TradingEvent;
        msg.DailyLimitPriceLbValid = reader.DailyLimitPriceLbValid;
        msg.DailyLimitPriceLb = reader.DailyLimitPriceLb;
        msg.DailyLimitPriceUbValid = reader.DailyLimitPriceUbValid;
        msg.DailyLimitPriceUb = reader.DailyLimitPriceUb;
        msg.MaxPriceVariationValid = reader.MaxPriceVariationValid;
        msg.MaxPriceVariation = reader.MaxPriceVariation;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref CmeFeedUpdateIndicativeOpeningDts msg, in CmeFeedUpdateIndicativeOpeningDecoder reader)
    {
        msg.SecurityId = reader.SecurityId;
        msg.MdpChannelId = reader.MdpChannelId;
        msg.InstNum = reader.InstNum;
        var TimestampStruct = reader.Timestamp.Reader();
        FromDecoder(ref msg.Timestamp, in TimestampStruct);
        msg.Quantity = reader.Quantity;
        msg.Price = reader.Price;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref CmeFeedUpdateOpeningPriceDts msg, in CmeFeedUpdateOpeningPriceDecoder reader)
    {
        msg.SecurityId = reader.SecurityId;
        msg.MdpChannelId = reader.MdpChannelId;
        msg.InstNum = reader.InstNum;
        var TimestampStruct = reader.Timestamp.Reader();
        FromDecoder(ref msg.Timestamp, in TimestampStruct);
        msg.Price = reader.Price;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref CmeFeedUpdateSettlementDts msg, in CmeFeedUpdateSettlementDecoder reader)
    {
        msg.SecurityId = reader.SecurityId;
        msg.MdpChannelId = reader.MdpChannelId;
        msg.InstNum = reader.InstNum;
        var TimestampStruct = reader.Timestamp.Reader();
        FromDecoder(ref msg.Timestamp, in TimestampStruct);
        msg.PriceValid = reader.PriceValid;
        msg.Price = reader.Price;
        var PriceTimestampStruct = reader.PriceTimestamp.Reader();
        FromDecoder(ref msg.PriceTimestamp, in PriceTimestampStruct);
        msg.PreliminaryPriceValid = reader.PreliminaryPriceValid;
        msg.PreliminaryPrice = reader.PreliminaryPrice;
        var PreliminaryPriceTimestampStruct = reader.PreliminaryPriceTimestamp.Reader();
        FromDecoder(ref msg.PreliminaryPriceTimestamp, in PreliminaryPriceTimestampStruct);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref CmeFeedUpdateTradeDts msg, in CmeFeedUpdateTradeDecoder reader)
    {
        msg.SecurityId = reader.SecurityId;
        msg.MdpChannelId = reader.MdpChannelId;
        msg.InstNum = reader.InstNum;
        var TimestampStruct = reader.Timestamp.Reader();
        FromDecoder(ref msg.Timestamp, in TimestampStruct);
        msg.BookStatus = reader.BookStatus;
        msg.AggressorSideKind = reader.AggressorSideKind;
        msg.OrderCnt = reader.OrderCnt;
        msg.Quantity = reader.Quantity;
        msg.Price = reader.Price;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref CmeFeedUpdateSideDts msg, in CmeFeedUpdateSideDecoder reader)
    {
        msg.SecurityId = reader.SecurityId;
        msg.MdpChannelId = reader.MdpChannelId;
        msg.InstNum = reader.InstNum;
        var TimestampStruct = reader.Timestamp.Reader();
        FromDecoder(ref msg.Timestamp, in TimestampStruct);
        msg.BookStatus = reader.BookStatus;
        msg.SideKind = reader.SideKind;
        msg.OrdersKind = reader.OrdersKind;
        msg.IsLastSideOfBook = reader.IsLastSideOfBook;
        var LevelsAccessor = reader.Levels;
        switch (LevelsAccessor.Count)
        {
            case 10:
                var e9 = LevelsAccessor.GetElement(9);
                FromDecoder(ref msg.Levels9, in e9);
                goto case 9;
            case 9:
                var e8 = LevelsAccessor.GetElement(8);
                FromDecoder(ref msg.Levels8, in e8);
                goto case 8;
            case 8:
                var e7 = LevelsAccessor.GetElement(7);
                FromDecoder(ref msg.Levels7, in e7);
                goto case 7;
            case 7:
                var e6 = LevelsAccessor.GetElement(6);
                FromDecoder(ref msg.Levels6, in e6);
                goto case 6;
            case 6:
                var e5 = LevelsAccessor.GetElement(5);
                FromDecoder(ref msg.Levels5, in e5);
                goto case 5;
            case 5:
                var e4 = LevelsAccessor.GetElement(4);
                FromDecoder(ref msg.Levels4, in e4);
                goto case 4;
            case 4:
                var e3 = LevelsAccessor.GetElement(3);
                FromDecoder(ref msg.Levels3, in e3);
                goto case 3;
            case 3:
                var e2 = LevelsAccessor.GetElement(2);
                FromDecoder(ref msg.Levels2, in e2);
                goto case 2;
            case 2:
                var e1 = LevelsAccessor.GetElement(1);
                FromDecoder(ref msg.Levels1, in e1);
                goto case 1;
            case 1:
                var e0 = LevelsAccessor.GetElement(0);
                FromDecoder(ref msg.Levels0, in e0);
                goto case 0;
            case 0: break;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref CmeFeedUpdateLastMessageForEventDts msg, in CmeFeedUpdateLastMessageForEventDecoder reader)
    {
        msg.MdpChannelId = reader.MdpChannelId;
        var TimestampStruct = reader.Timestamp.Reader();
        FromDecoder(ref msg.Timestamp, in TimestampStruct);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref CmeFeedUpdateFinishedAllDts msg, in CmeFeedUpdateFinishedAllDecoder reader)
    {
        var ExtractTimestampStruct = reader.ExtractTimestamp.Reader();
        FromDecoder(ref msg.ExtractTimestamp, in ExtractTimestampStruct);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref CmeFeedTradeStatisticsDts msg, in CmeFeedTradeStatisticsDecoder reader)
    {
        msg.InstNum = reader.InstNum;
        msg.HighPrice = reader.HighPrice;
        msg.LowPrice = reader.LowPrice;
        msg.LastPrice = reader.LastPrice;
        msg.Volume = reader.Volume;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref CmeFeedInstrumentStateDts msg, in CmeFeedInstrumentStateDecoder reader)
    {
        msg.InstNum = reader.InstNum;
        msg.SecurityId = reader.SecurityId;
        var InstStatusStruct = reader.InstStatus.Reader();
        FromDecoder(ref msg.InstStatus, in InstStatusStruct);
        var LastTradeStruct = reader.LastTrade.Reader();
        FromDecoder(ref msg.LastTrade, in LastTradeStruct);
        var OpeningPriceStruct = reader.OpeningPrice.Reader();
        FromDecoder(ref msg.OpeningPrice, in OpeningPriceStruct);
        var SettlementStruct = reader.Settlement.Reader();
        FromDecoder(ref msg.Settlement, in SettlementStruct);
        var BidBookStruct = reader.BidBook.Reader();
        FromDecoder(ref msg.BidBook, in BidBookStruct);
        var ImpBidBookStruct = reader.ImpBidBook.Reader();
        FromDecoder(ref msg.ImpBidBook, in ImpBidBookStruct);
        var AskBookStruct = reader.AskBook.Reader();
        FromDecoder(ref msg.AskBook, in AskBookStruct);
        var ImpAskBookStruct = reader.ImpAskBook.Reader();
        FromDecoder(ref msg.ImpAskBook, in ImpAskBookStruct);
        msg.InstStatusValid = reader.InstStatusValid;
        msg.LastTradeValid = reader.LastTradeValid;
        msg.OpeningPriceValid = reader.OpeningPriceValid;
        msg.SettlementValid = reader.SettlementValid;
        msg.BidBookValid = reader.BidBookValid;
        msg.ImpBidBookValid = reader.ImpBidBookValid;
        msg.AskBookValid = reader.AskBookValid;
        msg.ImpAskBookValid = reader.ImpAskBookValid;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref CmeLegDefinitionDts msg, in CmeLegDefinitionDecoder reader)
    {
        msg.SecurityId = reader.SecurityId;
        msg.Ratio = reader.Ratio;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref CmeFuturesDefinitionDts msg, in CmeFuturesDefinitionDecoder reader)
    {
        msg.Symbol.Set(reader.Symbol);
        msg.SecurityId = reader.SecurityId;
        msg.MarketSegmentGatewayId = reader.MarketSegmentGatewayId;
        msg.MdpChannelId = reader.MdpChannelId;
        msg.SecurityGroupCode.Set(reader.SecurityGroupCode);
        msg.AssetKind = reader.AssetKind;
        msg.AssetCode.Set(reader.AssetCode);
        msg.CfiCode.Set(reader.CfiCode);
        msg.SecuritySubtype = reader.SecuritySubtype;
        msg.SecuritySubtypeCode.Set(reader.SecuritySubtypeCode);
        msg.MaturityMonthyear.Set(reader.MaturityMonthyear);
        msg.EquivalenceKind = reader.EquivalenceKind;
        msg.EquivalentAssetKind = reader.EquivalentAssetKind;
        msg.PriceValueKind = reader.PriceValueKind;
        msg.TruePriceOffset = reader.TruePriceOffset;
        msg.PriceToCurrency = reader.PriceToCurrency;
        msg.MinPriceIncrement = reader.MinPriceIncrement;
        msg.CurrencyCode.Set(reader.CurrencyCode);
        msg.SettleCurrencyCode.Set(reader.SettleCurrencyCode);
        msg.UnitOfMeasureCode.Set(reader.UnitOfMeasureCode);
        msg.UnitOfMeasureQuantity = reader.UnitOfMeasureQuantity;
        msg.LimitPricesValid = reader.LimitPricesValid;
        msg.HighLimitPrice = reader.HighLimitPrice;
        msg.LowLimitPrice = reader.LowLimitPrice;
        msg.MaxPriceVariationValid = reader.MaxPriceVariationValid;
        msg.MaxPriceVariation = reader.MaxPriceVariation;
        msg.BookDepth = reader.BookDepth;
        msg.HasImpliedBook = reader.HasImpliedBook;
        msg.MatchAlgorithm = reader.MatchAlgorithm;
        msg.MinTradeVolume = reader.MinTradeVolume;
        msg.MaxTradeVolume = reader.MaxTradeVolume;
        msg.RelativeToPreviousSettlement = reader.RelativeToPreviousSettlement;
        var ActivationTimeStruct = reader.ActivationTime.Reader();
        FromDecoder(ref msg.ActivationTime, in ActivationTimeStruct);
        var LastEligibleTradeTimeStruct = reader.LastEligibleTradeTime.Reader();
        FromDecoder(ref msg.LastEligibleTradeTime, in LastEligibleTradeTimeStruct);
        var LegsAccessor = reader.Legs;
        switch (LegsAccessor.Count)
        {
            case 10:
                var e9 = LegsAccessor.GetElement(9);
                FromDecoder(ref msg.Legs9, in e9);
                goto case 9;
            case 9:
                var e8 = LegsAccessor.GetElement(8);
                FromDecoder(ref msg.Legs8, in e8);
                goto case 8;
            case 8:
                var e7 = LegsAccessor.GetElement(7);
                FromDecoder(ref msg.Legs7, in e7);
                goto case 7;
            case 7:
                var e6 = LegsAccessor.GetElement(6);
                FromDecoder(ref msg.Legs6, in e6);
                goto case 6;
            case 6:
                var e5 = LegsAccessor.GetElement(5);
                FromDecoder(ref msg.Legs5, in e5);
                goto case 5;
            case 5:
                var e4 = LegsAccessor.GetElement(4);
                FromDecoder(ref msg.Legs4, in e4);
                goto case 4;
            case 4:
                var e3 = LegsAccessor.GetElement(3);
                FromDecoder(ref msg.Legs3, in e3);
                goto case 3;
            case 3:
                var e2 = LegsAccessor.GetElement(2);
                FromDecoder(ref msg.Legs2, in e2);
                goto case 2;
            case 2:
                var e1 = LegsAccessor.GetElement(1);
                FromDecoder(ref msg.Legs1, in e1);
                goto case 1;
            case 1:
                var e0 = LegsAccessor.GetElement(0);
                FromDecoder(ref msg.Legs0, in e0);
                goto case 0;
            case 0: break;
        }
        msg.IsFeedAvailable = reader.IsFeedAvailable;
        msg.InstNum = reader.InstNum;
        msg.GroupNum = reader.GroupNum;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref CmeFuturesDefinitionResponseDts msg, in CmeFuturesDefinitionResponseDecoder reader)
    {
        var DefinitionsAccessor = reader.Definitions;
        switch (DefinitionsAccessor.Count)
        {
            case 10:
                var e9 = DefinitionsAccessor.GetElement(9);
                FromDecoder(ref msg.Definitions9, in e9);
                goto case 9;
            case 9:
                var e8 = DefinitionsAccessor.GetElement(8);
                FromDecoder(ref msg.Definitions8, in e8);
                goto case 8;
            case 8:
                var e7 = DefinitionsAccessor.GetElement(7);
                FromDecoder(ref msg.Definitions7, in e7);
                goto case 7;
            case 7:
                var e6 = DefinitionsAccessor.GetElement(6);
                FromDecoder(ref msg.Definitions6, in e6);
                goto case 6;
            case 6:
                var e5 = DefinitionsAccessor.GetElement(5);
                FromDecoder(ref msg.Definitions5, in e5);
                goto case 5;
            case 5:
                var e4 = DefinitionsAccessor.GetElement(4);
                FromDecoder(ref msg.Definitions4, in e4);
                goto case 4;
            case 4:
                var e3 = DefinitionsAccessor.GetElement(3);
                FromDecoder(ref msg.Definitions3, in e3);
                goto case 3;
            case 3:
                var e2 = DefinitionsAccessor.GetElement(2);
                FromDecoder(ref msg.Definitions2, in e2);
                goto case 2;
            case 2:
                var e1 = DefinitionsAccessor.GetElement(1);
                FromDecoder(ref msg.Definitions1, in e1);
                goto case 1;
            case 1:
                var e0 = DefinitionsAccessor.GetElement(0);
                FromDecoder(ref msg.Definitions0, in e0);
                goto case 0;
            case 0: break;
        }
        msg.Error.Set(reader.Error);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref CmeFeedRequestSymbolAvailabilityResponseDts msg, in CmeFeedRequestSymbolAvailabilityResponseDecoder reader)
    {
        msg.Success = reader.Success;
        msg.Action = reader.Action;
        msg.InstNum = reader.InstNum;
        msg.SecurityId = reader.SecurityId;
        msg.Symbol.Set(reader.Symbol);
        msg.Error.Set(reader.Error);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref CmeFeedClientSubscribeResponseDts msg, in CmeFeedClientSubscribeResponseDecoder reader)
    {
        msg.which = reader.which;
        msg.Result = reader.Result;
        var BadSecurityIdListList = reader.BadSecurityIdList;
        switch (BadSecurityIdListList.Length)
        {
            case 10: msg.BadSecurityIdList9 = BadSecurityIdListList[9]; goto case 9;
            case 9: msg.BadSecurityIdList8 = BadSecurityIdListList[8]; goto case 8;
            case 8: msg.BadSecurityIdList7 = BadSecurityIdListList[7]; goto case 7;
            case 7: msg.BadSecurityIdList6 = BadSecurityIdListList[6]; goto case 6;
            case 6: msg.BadSecurityIdList5 = BadSecurityIdListList[5]; goto case 5;
            case 5: msg.BadSecurityIdList4 = BadSecurityIdListList[4]; goto case 4;
            case 4: msg.BadSecurityIdList3 = BadSecurityIdListList[3]; goto case 3;
            case 3: msg.BadSecurityIdList2 = BadSecurityIdListList[2]; goto case 2;
            case 2: msg.BadSecurityIdList1 = BadSecurityIdListList[1]; goto case 1;
            case 1: msg.BadSecurityIdList0 = BadSecurityIdListList[0]; goto case 0;
            case 0: break;
        }
        var BadInstListList = reader.BadInstList;
        switch (BadInstListList.Length)
        {
            case 10: msg.BadInstList9 = BadInstListList[9]; goto case 9;
            case 9: msg.BadInstList8 = BadInstListList[8]; goto case 8;
            case 8: msg.BadInstList7 = BadInstListList[7]; goto case 7;
            case 7: msg.BadInstList6 = BadInstListList[6]; goto case 6;
            case 6: msg.BadInstList5 = BadInstListList[5]; goto case 5;
            case 5: msg.BadInstList4 = BadInstListList[4]; goto case 4;
            case 4: msg.BadInstList3 = BadInstListList[3]; goto case 3;
            case 3: msg.BadInstList2 = BadInstListList[2]; goto case 2;
            case 2: msg.BadInstList1 = BadInstListList[1]; goto case 1;
            case 1: msg.BadInstList0 = BadInstListList[0]; goto case 0;
            case 0: break;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref CmeFuturesDefinitionSpecDts msg, in CmeFuturesDefinitionSpecDecoder reader)
    {
        msg.AssetKind = reader.AssetKind;
        msg.SecuritySubtype = reader.SecuritySubtype;
        msg.SecurityGroupCode.Set(reader.SecurityGroupCode);
        var ActivationTimeLbStruct = reader.ActivationTimeLb.Reader();
        FromDecoder(ref msg.ActivationTimeLb, in ActivationTimeLbStruct);
        var ActivationTimeUbStruct = reader.ActivationTimeUb.Reader();
        FromDecoder(ref msg.ActivationTimeUb, in ActivationTimeUbStruct);
        var LastEligibleTradeTimeLbStruct = reader.LastEligibleTradeTimeLb.Reader();
        FromDecoder(ref msg.LastEligibleTradeTimeLb, in LastEligibleTradeTimeLbStruct);
        var LastEligibleTradeTimeUbStruct = reader.LastEligibleTradeTimeUb.Reader();
        FromDecoder(ref msg.LastEligibleTradeTimeUb, in LastEligibleTradeTimeUbStruct);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref FeedApiLoginResponseDts msg, in FeedApiLoginResponseDecoder reader)
    {
        msg.Result = reader.Result;
        msg.ListResult = reader.ListResult;
        msg.FeedEnv = reader.FeedEnv;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref FeedApiSetSymbolListResponseDts msg, in FeedApiSetSymbolListResponseDecoder reader)
    {
        msg.ListResult = reader.ListResult;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FromDecoder(ref FeedApiGetSymbolListContentsResponseDts msg, in FeedApiGetSymbolListContentsResponseDecoder reader)
    {
        var SymbolListList = reader.SymbolList;
        switch (SymbolListList.Length)
        {
            case 10: msg.SymbolList9.Set(SymbolListList[9]); goto case 9;
            case 9: msg.SymbolList8.Set(SymbolListList[8]); goto case 8;
            case 8: msg.SymbolList7.Set(SymbolListList[7]); goto case 7;
            case 7: msg.SymbolList6.Set(SymbolListList[6]); goto case 6;
            case 6: msg.SymbolList5.Set(SymbolListList[5]); goto case 5;
            case 5: msg.SymbolList4.Set(SymbolListList[4]); goto case 4;
            case 4: msg.SymbolList3.Set(SymbolListList[3]); goto case 3;
            case 3: msg.SymbolList2.Set(SymbolListList[2]); goto case 2;
            case 2: msg.SymbolList1.Set(SymbolListList[1]); goto case 1;
            case 1: msg.SymbolList0.Set(SymbolListList[0]); goto case 0;
            case 0: break;
        }
        var SecurityIdListList = reader.SecurityIdList;
        switch (SecurityIdListList.Length)
        {
            case 10: msg.SecurityIdList9 = SecurityIdListList[9]; goto case 9;
            case 9: msg.SecurityIdList8 = SecurityIdListList[8]; goto case 8;
            case 8: msg.SecurityIdList7 = SecurityIdListList[7]; goto case 7;
            case 7: msg.SecurityIdList6 = SecurityIdListList[6]; goto case 6;
            case 6: msg.SecurityIdList5 = SecurityIdListList[5]; goto case 5;
            case 5: msg.SecurityIdList4 = SecurityIdListList[4]; goto case 4;
            case 4: msg.SecurityIdList3 = SecurityIdListList[3]; goto case 3;
            case 3: msg.SecurityIdList2 = SecurityIdListList[2]; goto case 2;
            case 2: msg.SecurityIdList1 = SecurityIdListList[1]; goto case 1;
            case 1: msg.SecurityIdList0 = SecurityIdListList[0]; goto case 0;
            case 0: break;
        }
        msg.ErrorText.Set(reader.ErrorText);
    }

}
