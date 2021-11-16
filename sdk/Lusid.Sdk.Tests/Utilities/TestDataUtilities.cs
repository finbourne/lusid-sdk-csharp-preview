using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lusid.Sdk.Model;
using Newtonsoft.Json;

namespace Lusid.Sdk.Tests.Utilities
{
    public static class TestDataUtilities
    {
        internal static readonly string ExampleMarketDataDirectory = "../../../tutorials/Ibor/ExampleMarketData/";
        public const string TutorialScope = "Testdemo";
        public const string MarketDataScope = "FinbourneMarketData";
        public static string ValuationDateKey = "Analytic/default/ValuationDate";
        public static string InstrumentTag = "Analytic/default/InstrumentTag";
        public static string ValuationPvKey = "Valuation/PV/Amount";
        public static string InstrumentName = "Instrument/default/Name";
        
        public static readonly List<AggregateSpec> ValuationSpec = new List<AggregateSpec>
        {
            new AggregateSpec(ValuationDateKey, AggregateSpec.OpEnum.Value),
            new AggregateSpec(InstrumentName, AggregateSpec.OpEnum.Value),
            new AggregateSpec(ValuationPvKey, AggregateSpec.OpEnum.Value),
            new AggregateSpec(InstrumentTag, AggregateSpec.OpEnum.Value)
        };
        //    Specific key used to denote cash in LUSID
        public const string LusidCashIdentifier = "Instrument/default/Currency";
        public const string LusidInstrumentIdentifier = "Instrument/default/LusidInstrumentId";

        public static DateTimeOffset EffectiveAt = new DateTimeOffset(2020, 1, 2, 0, 0, 0, TimeSpan.Zero);

        /// <summary>
        /// Helper method to construct CreateTransactionPortfolioRequest to be used in ITransactionPortfoliosApi
        /// </summary>
        public static CreateTransactionPortfolioRequest BuildTransactionPortfolioRequest(DateTimeOffset? effectiveAt = null)
        {
            var portfolioCode = Guid.NewGuid().ToString();
            //    Effective date of the portfolio, this is the date the portfolio was created and became live.  All dates/times
            //    must be supplied in UTC
            var effectiveDate = effectiveAt  ?? new DateTimeOffset(2018, 1, 1, 0, 0, 0, TimeSpan.Zero);

            //    Details of the new portfolio to be created, created here with the minimum set of mandatory fields
            var request = new CreateTransactionPortfolioRequest(
                code: portfolioCode,
                displayName: $"Portfolio-{portfolioCode}",
                baseCurrency: "GBP",
                created: effectiveDate
            );
            return request;
        }

        /// <summary>
        /// Helper method to construct TransactionReqeust to be used in ITransactionPortfoliosApi to build transaction
        /// </summary>
        public static TransactionRequest BuildTransactionRequest(
            string instrumentId,
            decimal units,
            decimal price,
            string currency,
            DateTimeOrCutLabel tradeDate,
            string transactionType)
        {
            return new TransactionRequest(
                transactionId: Guid.NewGuid().ToString(),
                type: transactionType,
                instrumentIdentifiers: new Dictionary<string, string>
                {
                    [LusidInstrumentIdentifier] = instrumentId
                },
                transactionDate: tradeDate,
                settlementDate: tradeDate,
                units: units,
                transactionPrice: new TransactionPrice(price, TransactionPrice.TypeEnum.Price),
                totalConsideration: new CurrencyAndAmount(price*units, currency),
                source: "Broker");
        }

        /// <summary>
        /// Helper method to create Cash Fund transaction request to be used in ITransactionPortfoliosApi 
        /// </summary>
        public static TransactionRequest BuildCashFundsInTransactionRequest(
            decimal units,
            string currency,
            DateTimeOffset tradeDate)
        {
            return new TransactionRequest(
                transactionId: Guid.NewGuid().ToString(),

                //    Set the transaction type to denote cash being added to the portfolio
                type: "FundsIn",
                instrumentIdentifiers: new Dictionary<string, string>
                {
                    [LusidCashIdentifier] = currency
                },
                transactionDate: tradeDate,
                settlementDate: tradeDate,
                units: units,
                totalConsideration: new CurrencyAndAmount(0, "GBP"),
                transactionPrice: new TransactionPrice(0.0M),
                source: "Client");
        }

        public static AdjustHoldingRequest BuildAdjustHoldingsRequst(string instrumentId, decimal units, decimal price, string currency, DateTimeOffset? tradeDate)
        {
            return new AdjustHoldingRequest(
                instrumentIdentifiers: new Dictionary<string, string>
                {
                    [LusidInstrumentIdentifier] = instrumentId
                },
                taxLots: new List<TargetTaxLotRequest>
                {
                    new TargetTaxLotRequest(
                        units: units,
                        price: price,
                        cost: new CurrencyAndAmount(
                            amount: price * units,
                            currency: currency
                        ),
                        portfolioCost: price * units,
                        purchaseDate: tradeDate,
                        settlementDate: tradeDate
                    )
                }
           );
        }

        public static AdjustHoldingRequest BuildCashFundsInAdjustHoldingsRequest(string currency, decimal units)
        {
            return new AdjustHoldingRequest(
                instrumentIdentifiers: new Dictionary<string, string>
                {
                    [LusidCashIdentifier] = currency
                },
                taxLots: new List<TargetTaxLotRequest>
                {
                    new TargetTaxLotRequest(
                        units: units,
                        price: null,
                        cost: null,
                        portfolioCost: null,
                        purchaseDate: null,
                        settlementDate: null
                    )
                }
            );
        }

        public static PortfolioHolding BuildPortfolioHolding(string currency, string instrumentUid, decimal units, decimal cost)
        {
            return new PortfolioHolding(
                    cost: new CurrencyAndAmount(cost, currency),
                    costPortfolioCcy: new CurrencyAndAmount(cost, currency),
                    currency: currency,
                    instrumentUid: instrumentUid,
                    holdingType: "P",
                    units: units,
                    settledUnits: units
                );
        }

        public static PortfolioHolding BuildCashPortfolioHolding(string currency, string currencyLuid, decimal units)
        {
            return new PortfolioHolding(
                    cost: new CurrencyAndAmount(0, currency),
                    costPortfolioCcy: new CurrencyAndAmount(0, currency),
                    currency: currency,
                    instrumentUid: currencyLuid,
                    holdingType: "B",
                    units: units,
                    settledUnits: units
                );
        }

        /// <summary>
        /// Helper to upsert a given LusidInstrument 
        /// </summary>
        public static Dictionary<string, InstrumentDefinition> BuildInstrumentUpsertRequest(List<(LusidInstrument, string)> instruments)
        {
            return instruments
                .ToDictionary(
                    instrument => $"upsertIdFor{instrument.Item1.InstrumentType}",
                    instrument => new InstrumentDefinition(
                        name: instrument.Item1.InstrumentType.ToString(),
                        identifiers: new Dictionary<string, InstrumentIdValue>
                        {
                            ["ClientInternal"] = new InstrumentIdValue(value: instrument.Item2)
                        },
                        definition: instrument.Item1));
        }

        /// <summary>
        /// This method add instruments to a portfolio (specified by its scope and code),
        /// by creating a transaction request with the instrument's LUID.
        /// </summary>
        public static List<TransactionRequest> BuildTransactionRequest(
            List<string> luids,
            string scope,
            string portfolioCode,
            DateTimeOffset effectiveAt)
        {
            // CREATE instrument transaction request
            var transactionRequests = luids.Select(luid =>
                    BuildTransactionRequest(luid, 1, 0.0m, "USD", effectiveAt, "Buy"))
                .ToList();
            return transactionRequests;
        }
        
        /// <summary>
        /// This method upserts JPY/USD and USD/JPY fx quotes for the given effectiveAt date
        /// </summary>
        public static Dictionary<string, UpsertQuoteRequest> BuildFxRateRequest(string scope, DateTimeOffset effectiveAt) => BuildFxRateRequest(scope, effectiveAt, effectiveAt);

        /// <summary>
        /// This method upserts JPY/USD and USD/JPY fx quotes for every day in the date range
        /// </summary>
        public static Dictionary<string, UpsertQuoteRequest> BuildFxRateRequest(string scope, DateTimeOffset effectiveFrom,  DateTimeOffset effectiveAt, bool useConstantFxRate = false)
        {
            // CREATE fx quotes and inverse fx rate in the desired date range
            var upsertQuoteRequests = new Dictionary<string, UpsertQuoteRequest>();
            var numberOfDaysBetween = (effectiveAt - effectiveFrom).Days;
            for (var days = 0; days != numberOfDaysBetween + 1; ++days)
            {
                var date = effectiveFrom.AddDays(days);
                if (useConstantFxRate)
                {
                    var fxRate = BuildSimpleQuoteUpsertRequest("USD/JPY", QuoteSeriesId.InstrumentIdTypeEnum.CurrencyPair, 150, "USD", date);
                    var inverseFxRate = BuildSimpleQuoteUpsertRequest("JPY/USD", QuoteSeriesId.InstrumentIdTypeEnum.CurrencyPair, 1m / 150, "USD", date);

                    upsertQuoteRequests.Add($"day_{days}_fx_rate", fxRate);
                    upsertQuoteRequests.Add($"day_{days}_inverseFx_rate", inverseFxRate);
                }
                else
                {
                    var fxRate = BuildSimpleQuoteUpsertRequest("USD/JPY", QuoteSeriesId.InstrumentIdTypeEnum.CurrencyPair, (150 + days), "USD", date);
                    var inverseFxRate = BuildSimpleQuoteUpsertRequest("JPY/USD", QuoteSeriesId.InstrumentIdTypeEnum.CurrencyPair, 1m / (150 + days), "USD", date);

                    upsertQuoteRequests.Add($"day_{days}_fx_rate", fxRate);
                    upsertQuoteRequests.Add($"day_{days}_inverseFx_rate", inverseFxRate);
                }
            }

            return upsertQuoteRequests;
        }

        /// <summary>
        /// This method upserts the reset quotes for the floating leg of a swap
        /// </summary>
        public static Dictionary<string, UpsertQuoteRequest> BuildResetQuotesRequest(string scope, DateTimeOffset effectiveAt)
        {
            // CREATE reset quotes in the desired date range
            var upsertQuoteRequests = new Dictionary<string, UpsertQuoteRequest>();

            var resetQuote = BuildSimpleQuoteUpsertRequest("BP00", QuoteSeriesId.InstrumentIdTypeEnum.RIC, 150, "USD", effectiveAt);
            upsertQuoteRequests.Add($"resetQuote", resetQuote);

            return upsertQuoteRequests;
        }

        /// <summary>
        /// Helper method to construct equity quote request to be used in IQuotesApi 
        /// </summary>
        public static Dictionary<string, UpsertQuoteRequest> BuildEquityQuoteRequest(
            string instrumentId,
            DateTimeOffset effectiveFrom,
            DateTimeOffset effectiveAt,
            QuoteSeriesId.InstrumentIdTypeEnum instrumentIdType = QuoteSeriesId.InstrumentIdTypeEnum.LusidInstrumentId)
        {
            // CREATE equity quotes for the desired date range
            var upsertQuoteRequests = new Dictionary<string, UpsertQuoteRequest>();
            var numberOfDaysBetween = (effectiveAt - effectiveFrom).Days;

            for (var days = 0; days != numberOfDaysBetween + 1; ++days)
            {
                var date = effectiveFrom.AddDays(days);
                var quote = BuildSimpleQuoteUpsertRequest(instrumentId, instrumentIdType,100 + days, "USD", date, "mid", "Lusid", null);
                upsertQuoteRequests.Add($"day_{days}_equity_quote", quote);
            }

            return upsertQuoteRequests;
        }


        /// <summary>
        /// Helper method to create simple equity or fx quote upsert request
        /// </summary>
        internal static UpsertQuoteRequest BuildSimpleQuoteUpsertRequest(
            string id,
            QuoteSeriesId.InstrumentIdTypeEnum instrumentIdType,
            decimal price,
            string ccy,
            DateTimeOffset effectiveAt,
            string quoteField = "mid",
            string supplier = "Lusid",
            string priceSource = null
        )
            => new UpsertQuoteRequest(
                new QuoteId(
                    new QuoteSeriesId(supplier, priceSource, id, instrumentIdType, QuoteSeriesId.QuoteTypeEnum.Price,
                        quoteField),
                    effectiveAt
                ),
                new MetricValue(price, ccy));

        /// <summary>
        /// This method upserts the 3 rate curves:
        /// JPY/JPYOIS and USD/USDOIS are used for discounting pricing models
        /// USD 6M rate is used for pricing interest rate swap
        /// </summary>
        public static Dictionary<string, UpsertComplexMarketDataRequest> BuildRateCurvesRequests(DateTimeOffset effectiveAt)
        {
            var curveRequests = new[]
            {
                BuildOisCurveRequest(effectiveAt, "USD"),
                BuildOisCurveHighRatesRequest(effectiveAt, "JPY"),
                Build6MRateCurveRequest(effectiveAt, "USD") // this would be necessary for valuation of swaps paying every 6M
            };

            // ENUMERATE the request
            var upsertComplexMarketDataRequests = curveRequests
                .Select((idx, upsertRequest) => (idx, upsertRequest))
                .ToDictionary(tuple => tuple.idx.ToString(), tuple => tuple.idx);
            return upsertComplexMarketDataRequests;
        }

        /// <summary>
        /// Helper method to construct complex market data request for OIS interest rate curve to be used in IComplexMarketDataApi
        /// </summary>
        public static UpsertComplexMarketDataRequest BuildOisCurveRequest(DateTimeOffset effectiveAt, string currency)
        {
            var complexMarketData = CreateDiscountCurve(effectiveAt);
            var complexMarketDataId = new ComplexMarketDataId(
                provider: "Lusid",
                effectiveAt: effectiveAt.ToString("o"),
                marketAsset: $"{currency}/{currency}OIS",
                priceSource: "");
            var upsertRequest = new UpsertComplexMarketDataRequest(complexMarketDataId, complexMarketData);
            return upsertRequest;
        }

        /// <summary>
        /// Helper method to construct complex market data request for OIS interest rate curve to be used in IComplexMarketDataApi
        /// </summary>
        public static UpsertComplexMarketDataRequest BuildOisCurveHighRatesRequest(DateTimeOffset effectiveAt, string currency)
        {
            // different rates as the valuation for some instruments such as fx forwards depend on the difference between the rates curves in two currencies
            var complexMarketData = CreateDiscountCurveHighRates(effectiveAt);
            var complexMarketDataId = new ComplexMarketDataId(
                provider: "Lusid",
                effectiveAt: effectiveAt.ToString("o"),
                marketAsset: $"{currency}/{currency}OIS",
                priceSource: "");
            var upsertRequest = new UpsertComplexMarketDataRequest(complexMarketDataId, complexMarketData);
            return upsertRequest;
        }

        private static DiscountFactorCurveData CreateDiscountCurve(DateTimeOffset effectiveAt)
        {
            var discountDates = new List<DateTimeOffset>
                { effectiveAt, effectiveAt.AddMonths(3), effectiveAt.AddMonths(6), effectiveAt.AddMonths(9), effectiveAt.AddMonths(12), effectiveAt.AddYears(5) };
            var rates = new List<decimal> { 1.0m, 0.995026109593975m, 0.990076958773721m, 0.985098445011387m, 0.980144965261876m, 0.9m };
            return new DiscountFactorCurveData(effectiveAt, discountDates, rates, ComplexMarketData.MarketDataTypeEnum.DiscountFactorCurveData);
        }

        private static DiscountFactorCurveData CreateDiscountCurveHighRates(DateTimeOffset effectiveAt)
        {
            var discountDates = new List<DateTimeOffset>
                { effectiveAt, effectiveAt.AddMonths(3), effectiveAt.AddMonths(6), effectiveAt.AddMonths(9), effectiveAt.AddMonths(12), effectiveAt.AddYears(5) };
            var rates = new List<decimal> { 1.0m, 0.992548449440757m, 0.985152424487251m, 0.977731146620901m, 0.970365774179742m, 0.85m };
            return new DiscountFactorCurveData(effectiveAt, discountDates, rates, ComplexMarketData.MarketDataTypeEnum.DiscountFactorCurveData);
        }

        /// <summary>
        /// Helper method to construct complex market data request for interest rate curve to be used in IComplexMarketDataApi
        /// </summary>
        public static UpsertComplexMarketDataRequest Build6MRateCurveRequest(DateTimeOffset effectiveAt, string currency)
        {
            var complexMarketData = GetRateCurveJsonFromFile("USD6M.json");
            var complexMarketDataId = new ComplexMarketDataId(
                provider: "Lusid",
                effectiveAt: effectiveAt.ToString("o"),
                marketAsset: $"{currency}/6M",
                priceSource: "");

            var upsertRequest = new UpsertComplexMarketDataRequest(complexMarketDataId, complexMarketData);
            return upsertRequest;
        }

        private static ComplexMarketData GetRateCurveJsonFromFile(string filename)
        {
            using var reader = new StreamReader(ExampleMarketDataDirectory + filename);
            var jsonString = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<DiscountFactorCurveData>(jsonString);
        }
        
        private static ComplexMarketData GetSpreadCurveJsonFromFile(string filename)
        {
            using var reader = new StreamReader(ExampleMarketDataDirectory + filename);
            var jsonString = reader.ReadToEnd();

            var cdsCurve = new OpaqueMarketData(
                jsonString,
                "Json",
                "CDS curve",
                ComplexMarketData.MarketDataTypeEnum.OpaqueMarketData
            );
            return cdsCurve;
        }

        public static UpsertComplexMarketDataRequest BuildCdsSpreadCurvesRequest(DateTimeOffset effectiveAt, string ticker, string ccy, CdsProtectionDetailSpecification.SeniorityEnum seniority, CdsProtectionDetailSpecification.RestructuringTypeEnum restructType)
        {
            var marketDataId = new ComplexMarketDataId
            (
                provider: "Lusid",
                effectiveAt: effectiveAt.ToString("o"),
                marketAsset: $"{ticker}/{ccy}/{seniority}/{restructType}",
                priceSource: "",
                lineage: ""
            );

            var marketData = GetSpreadCurveJsonFromFile("XYZCorp.json");
            var request = new UpsertComplexMarketDataRequest(marketDataId, marketData);
            return request;
        }

        public static Dictionary<string, UpsertQuoteRequest> BuildQuoteRequest(string scope, string id, QuoteSeriesId.InstrumentIdTypeEnum instrumentIdType, decimal price, string ccy, DateTimeOffset effectiveAt)
        {
            var quoteRequest = BuildSimpleQuoteUpsertRequest(id, instrumentIdType, price, ccy, effectiveAt);
            var upsertRequests = new Dictionary<string, UpsertQuoteRequest> {{"req1", quoteRequest}};
            return upsertRequests; 
        }

        public static ComplexMarketData CreateVolSurfaceData(
            DateTimeOffset effectiveAt,
            List<LusidInstrument> instruments,
            List<MarketQuote> quotes,
            ComplexMarketData.MarketDataTypeEnum type)
        {
            ComplexMarketData volData = new ComplexMarketData();
            if(type == ComplexMarketData.MarketDataTypeEnum.EquityVolSurfaceData)
                volData = new EquityVolSurfaceData(effectiveAt, instruments, quotes, ComplexMarketData.MarketDataTypeEnum.EquityVolSurfaceData);
            if(type == ComplexMarketData.MarketDataTypeEnum.FxVolSurfaceData)
                volData =  new FxVolSurfaceData(effectiveAt, instruments, quotes,
                   ComplexMarketData.MarketDataTypeEnum.FxVolSurfaceData);

            return volData;

        }

        public static string GetMarketAsset(LusidInstrument option, MarketQuote.QuoteTypeEnum volType)
        {
            string marketAsset = "";
            if (option.InstrumentType == LusidInstrument.InstrumentTypeEnum.EquityOption)
            {
                EquityOption eoption = (EquityOption) option;
                marketAsset =  $"{eoption.Code}/{eoption.DomCcy}/" + (volType == MarketQuote.QuoteTypeEnum.NormalVol ? "N" : "LN"); 
            }

            if (option.InstrumentType == LusidInstrument.InstrumentTypeEnum.FxOption)
            {
                FxOption fxoption = (FxOption) option;
                marketAsset = $"{fxoption.DomCcy}/{fxoption.FgnCcy}/" + (volType == MarketQuote.QuoteTypeEnum.NormalVol ? "N" : "LN");
            }

            return marketAsset;

        }

        /// <summary>
        /// One-point vol surface for a given option - thus the surface is constant.
        /// </summary>
        public static UpsertComplexMarketDataRequest ConstantVolSurfaceRequest(DateTimeOffset effectiveAt, LusidInstrument option, ModelSelection.ModelEnum model, decimal vol = 0.2m)
        {
            ComplexMarketData.MarketDataTypeEnum type = ComplexMarketData.MarketDataTypeEnum.OpaqueMarketData;
            if (option.InstrumentType == LusidInstrument.InstrumentTypeEnum.EquityOption)
                type = ComplexMarketData.MarketDataTypeEnum.EquityVolSurfaceData;
            if (option.InstrumentType == LusidInstrument.InstrumentTypeEnum.FxOption)
                type = ComplexMarketData.MarketDataTypeEnum.FxVolSurfaceData; 
            
            var instruments = new List<LusidInstrument> {option};
            var volType = model == ModelSelection.ModelEnum.Bachelier ? MarketQuote.QuoteTypeEnum.NormalVol : MarketQuote.QuoteTypeEnum.LogNormalVol;
            var quotes = new List<MarketQuote> {new MarketQuote(volType, vol)};
            var complexMarketData = CreateVolSurfaceData(effectiveAt, instruments, quotes, type);

            var marketAsset = GetMarketAsset(option, volType);

            var complexMarketDataId = new ComplexMarketDataId(
                provider: "Lusid",
                effectiveAt: effectiveAt.ToString("o"),
                marketAsset: marketAsset);

            var upsertRequest = new UpsertComplexMarketDataRequest(complexMarketDataId, complexMarketData);
            return upsertRequest;
        }

        /// <summary>
        /// Simple wrapper to upsert a recipe to Lusid and ensure that the process is successful
        /// </summary>
        public static UpsertRecipeRequest BuildRecipeRequest(string recipeCode, string scope, ModelSelection.ModelEnum model)
        {
            var pricingOptions = new PricingOptions(new ModelSelection(ModelSelection.LibraryEnum.Lusid, model));
            var resetRule = new MarketDataKeyRule(
                key: "Equity.RIC.*",
                supplier: "Lusid",
                scope,
                MarketDataKeyRule.QuoteTypeEnum.Price,
                field: "mid",
                quoteInterval: "1Y");
            // We use long quote intervals here because we are happy to use old market data,
            // as pricing is not a concern in the cash flow demos this is used in.
            var creditRule = new MarketDataKeyRule(
                key: "Credit.*.*.*.*",
                supplier: "Lusid",
                scope,
                MarketDataKeyRule.QuoteTypeEnum.Spread,
                field: "mid",
                quoteInterval: "10Y");
            var ratesRule = new MarketDataKeyRule(
                key: "Rates.*.*",
                supplier: "Lusid",
                scope,
                MarketDataKeyRule.QuoteTypeEnum.Price,
                field: "mid",
                quoteInterval: "10Y");
            
            var recipe = new ConfigurationRecipe(
                scope,
                recipeCode,
                market: new MarketContext(
                    marketRules: new List<MarketDataKeyRule>{resetRule, creditRule, ratesRule},
                    options: new MarketOptions(defaultSupplier: "Lusid", defaultScope: scope, defaultInstrumentCodeType: "RIC")),
                pricing: new PricingContext(options: pricingOptions),
                description: $"Recipe for {model} pricing");
            
            var upsertRecipeRequest = new UpsertRecipeRequest(recipe);
            return upsertRecipeRequest;
        }

        /// <summary>
        /// Helper function to perform valuation of instrument. Can either perform inline valuation or valuation through a portfolio.
        /// If it is through a portfolio then a new portfolio and transaction against the instrument is created which is deleted at the end. 
        /// </summary>
        public static ValuationRequest ValuationRequest(LusidInstrument instrument,  string scope, ModelSelection.ModelEnum model, DateTimeOffset effectiveAt, string recipeCode, string portfolioCode)
        {
           
            // CREATE valuation request
            var valuationSchedule = new ValuationSchedule(effectiveAt: effectiveAt);
            
            var valuationRequest = new ValuationRequest(
                recipeId: new ResourceId(scope, recipeCode),
                metrics: TestDataUtilities.ValuationSpec,
                valuationSchedule: valuationSchedule,
                sort: new List<OrderBySpec> {new OrderBySpec(TestDataUtilities.ValuationDateKey, OrderBySpec.SortOrderEnum.Ascending)},
                portfolioEntityIds: new List<PortfolioEntityId> {new PortfolioEntityId(scope, portfolioCode)},
                reportCurrency: "USD");

            return valuationRequest;
        }
        
         /// <summary>
        /// Helper function to perform valuation of instrument. Can either perform inline valuation or valuation through a portfolio.
        /// If it is through a portfolio then a new portfolio and transaction against the instrument is created which is deleted at the end. 
        /// </summary>
        public static InlineValuationRequest InLineValuationRequest(LusidInstrument instrument,  string scope, ModelSelection.ModelEnum model, DateTimeOffset effectiveAt, string recipeCode)
        {
            
            // CREATE valuation request
            var valuationSchedule = new ValuationSchedule(effectiveAt: effectiveAt);
            
            var instruments = new List<WeightedInstrument> {new WeightedInstrument(1, "some-holding-identifier", instrument)}; 
            
            // CONSTRUCT and PERFORM valuation request
            var inlineValuationRequest = new InlineValuationRequest(
                recipeId: new ResourceId(scope, recipeCode),
                metrics: TestDataUtilities.ValuationSpec,
                sort: new List<OrderBySpec> {new OrderBySpec(TestDataUtilities.ValuationDateKey, OrderBySpec.SortOrderEnum.Ascending)},
                valuationSchedule: valuationSchedule,
                instruments: instruments);

            return inlineValuationRequest;
        }
    }
}
