using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Castle.Core.Internal;
using Lusid.Sdk.Api;
using Lusid.Sdk.Model;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Utilities
{
    public class TestDataUtilities
    {
        internal static readonly string ExampleMarketDataDirectory = "../../../tutorials/Ibor/ExampleMarketData/";
        public const string TutorialScope = "Testdemo";
        public const string MarketDataScope = "FinbourneMarketData";
        public static string ValuationDateKey = "Analytic/default/ValuationDate";
        public static string InstrumentTag = "Analytic/default/InstrumentTag";
        public static string HoldingPvKey = "Holding/default/PV";
        public static string InstrumentName = "Instrument/default/Name";
        
        public static readonly List<AggregateSpec> valuationSpec = new List<AggregateSpec>
        {
            new AggregateSpec(ValuationDateKey, AggregateSpec.OpEnum.Value),
            new AggregateSpec(InstrumentName, AggregateSpec.OpEnum.Value),
            new AggregateSpec(HoldingPvKey, AggregateSpec.OpEnum.Value),
            new AggregateSpec(InstrumentTag, AggregateSpec.OpEnum.Value)
        };
        //    Specific key used to denote cash in LUSID
        public const string LusidCashIdentifier = "Instrument/default/Currency";
        public const string LusidInstrumentIdentifier = "Instrument/default/LusidInstrumentId";

        internal readonly ITransactionPortfoliosApi _transactionPortfoliosApi;
        internal readonly IInstrumentsApi _instrumentsApi;
        internal readonly IQuotesApi _quotesApi;
        internal readonly IConfigurationRecipeApi _recipeApi;
        internal readonly IComplexMarketDataApi _complexMarketDataApi;
        internal readonly IAggregationApi _aggregationApi;
        internal readonly IPortfoliosApi _portfoliosApi;

        public static DateTimeOffset EffectiveAt = new DateTimeOffset(2020, 1, 2, 0, 0, 0, TimeSpan.Zero);

        public TestDataUtilities()
        {
            var apiFactory = TestLusidApiFactoryBuilder.CreateApiFactory("secrets.json");
            _portfoliosApi = apiFactory.Api<IPortfoliosApi>();
            _transactionPortfoliosApi = apiFactory.Api<ITransactionPortfoliosApi>();
            _instrumentsApi = apiFactory.Api<IInstrumentsApi>();
            _quotesApi = apiFactory.Api<IQuotesApi>();
            _complexMarketDataApi = apiFactory.Api<IComplexMarketDataApi>();
            _recipeApi = apiFactory.Api<IConfigurationRecipeApi>();
            _aggregationApi = apiFactory.Api<IAggregationApi>();
        } 
        public TestDataUtilities(ITransactionPortfoliosApi transactionPortfoliosApi)
        {
            _transactionPortfoliosApi = transactionPortfoliosApi;
        }

        public TestDataUtilities(
            ITransactionPortfoliosApi transactionPortfoliosApi,
            IInstrumentsApi instrumentsApi,
            IQuotesApi quotesApi,
            IComplexMarketDataApi complexMarketDataApi = null,
            IConfigurationRecipeApi recipeApi = null,
            IAggregationApi aggregationApi = null,
            IPortfoliosApi portfoliosApi = null)
        {
            _transactionPortfoliosApi = transactionPortfoliosApi;
            _instrumentsApi = instrumentsApi;
            _quotesApi = quotesApi;
            _complexMarketDataApi = complexMarketDataApi;
            _recipeApi = recipeApi;
            _aggregationApi = aggregationApi;
            _portfoliosApi = portfoliosApi;
        }

        public string CreateTransactionPortfolio(string scope, DateTimeOffset? effectiveAt = null)
        {
            var uuid = Guid.NewGuid().ToString();
            //    Effective date of the portfolio, this is the date the portfolio was created and became live.  All dates/times
            //    must be supplied in UTC
            var effectiveDate = (effectiveAt == null) ? new DateTimeOffset(2018, 1, 1, 0, 0, 0, TimeSpan.Zero) : effectiveAt;

            //    Details of the new portfolio to be created, created here with the minimum set of mandatory fields
            var request = new CreateTransactionPortfolioRequest(
                code: uuid,
                displayName: $"Portfolio-{uuid}",
                baseCurrency: "GBP",
                created: effectiveDate
            );

            //    Create the portfolio in LUSID
            var portfolio = _transactionPortfoliosApi.CreatePortfolio(scope, request);

            Assert.That(portfolio?.Id.Code, Is.EqualTo(request.Code));

            return portfolio.Id.Code;
        }

        public TransactionRequest BuildTransactionRequest(
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

        public TransactionRequest BuildCashFundsInTransactionRequest(
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

        public AdjustHoldingRequest BuildAdjustHoldingsRequst(string instrumentId, decimal units, decimal price, string currency, DateTimeOffset? tradeDate)
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

        public AdjustHoldingRequest BuildCashFundsInAdjustHoldingsRequest(string currency, decimal units)
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

        public PortfolioHolding BuildPortfolioHolding(string currency, string instrumentUid, decimal units, decimal cost)
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

        public PortfolioHolding BuildCashPortfolioHolding(string currency, string currencyLuid, decimal units)
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

        public void AddInstrumentsTransactionPortfolioAndPopulateRequiredMarketData(
            string portfolioScope,
            string portfolioCode,
            DateTimeOffset effectiveFrom,
            DateTimeOffset effectiveAt,
            LusidInstrument instrument,
            string equityIdentifier = null,
            bool useConstantFxRate = false
        )
            => AddInstrumentsTransactionPortfolioAndPopulateRequiredMarketData(
                portfolioScope,
                portfolioCode,
                effectiveFrom,
                effectiveAt,
                new List<LusidInstrument> {instrument},
                equityIdentifier,
                useConstantFxRate);

        /// <summary>
        /// This method adds the instruments to the portfolio and populates required market data for the pricing for examples.
        /// This method contains a several steps:
        ///
        /// 1) We first upsert our instruments by UpsertInstrumentSetAndReturnResponseValues.
        /// Inside this method, it first creates the instruments and upsert them using the InstrumentApi.
        /// Then it returns the upsert response.
        ///
        /// 2) The upsert response contains the LUIDs for the instruments upserted.
        /// Using the LUIDs, we add them to the portfolio by the method AddInstrumentsTransactionToPortfolio.
        /// The effective from argument is to specify when we want the instruments to be effective date from
        ///
        /// 3) To value the instrument in our example set, we populate with relevant market data.
        /// Fx rates (JPY/USD, UDS/JPY) are upserted for Fx-Forward, Fx-Option pricing
        /// Rate Curves are upserted for discounting pricing of Fx-Forward as well as for pricing swaps.
        /// Equity price quote is also upserted if an identifier is supplied.
        /// </summary>
        public void AddInstrumentsTransactionPortfolioAndPopulateRequiredMarketData(
            string portfolioScope,
            string portfolioCode,
            DateTimeOffset effectiveFrom,
            DateTimeOffset effectiveAt,
            List<LusidInstrument> instruments,
            string equityIdentifier = null,
            bool useConstantFxRate = false
        )
        {
            // UPSERT instruments and return the upsert response to attain LusidInstrumentIds
            var upsertResponse = UpsertInstrumentSetAndReturnResponseValues(instruments, equityIdentifier);
            var luids = upsertResponse
                .Select(inst => inst.Value.LusidInstrumentId)
                .ToList();

            // ADD instruments to the portfolio via their LusidInstrumentId
            AddInstrumentsTransactionToPortfolio(luids, portfolioScope, portfolioCode, effectiveFrom);

            // UPSERT fx quotes and rate curves required pricing instruments
            UpsertFxRate(portfolioScope, effectiveFrom, effectiveAt, useConstantFxRate);
            UpsertRateCurves(portfolioScope, effectiveAt);
            UpsertResetQuotes(portfolioScope, effectiveAt.AddDays(-4)); // The effective date for the reset quote should start 2 business days prior the accrual start date. Hence the date is adjusted

            // UPSERT equity quotes, if an equityIdentifier is present
            if (!equityIdentifier.IsNullOrEmpty())
            {
                var luid = upsertResponse[equityIdentifier].LusidInstrumentId;
                UpsertEquityQuote(luid, portfolioScope, effectiveFrom, effectiveAt);
            }

            // For equity options, we upsert the reset price in which the option payoff is computed.
            var equityOptions = instruments
                .Where(inst => inst.InstrumentType == LusidInstrument.InstrumentTypeEnum.EquityOption)
                .Select(eqOpt => (EquityOption) eqOpt);
            foreach (var eqOpt in equityOptions)
            {
                UpsertEquityQuote(eqOpt.Code, portfolioScope, effectiveFrom, effectiveAt, QuoteSeriesId.InstrumentIdTypeEnum.RIC);
            }
        }

        

        private Dictionary<string, InstrumentDefinition> CreateEquityUpsertRequest(string equityIdentifier)
        {
            return new Dictionary<string, InstrumentDefinition>()
                {
                    {equityIdentifier, new InstrumentDefinition(
                        equityIdentifier,
                        new Dictionary<string, InstrumentIdValue>
                            {{"ClientInternal", new InstrumentIdValue(equityIdentifier)}})}
                };
        }

        /// <summary>
        /// Given a list of instruments and the name of an equity (if any), this method upsert these instruments
        /// to LUSID and return their response value.
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, Instrument> UpsertInstrumentSetAndReturnResponseValues(
            List<LusidInstrument> instruments,
            string equityIdentifier = null)
        {
            // CREATE instrument upsert request
            var instrumentUpsertRequest = CreateInstrumentUpsertRequest(instruments);

            // CREATE upsert equity instrument request, if equityIdentifier is provided
            if (!equityIdentifier.IsNullOrEmpty())
            {
                // MERGE into one upsert dictionary of instruments to upsert
                var equityRequest = CreateEquityUpsertRequest(equityIdentifier);
                equityRequest.ToList().ForEach(r => instrumentUpsertRequest.Add(r.Key, r.Value));
            }

            // UPSERT and check the response succeeded with no errors.
            var response = _instrumentsApi.UpsertInstruments(instrumentUpsertRequest);
            Assert.That(response.Failed.Count, Is.EqualTo(0));
            Assert.That(response.Values.Count, Is.EqualTo(instrumentUpsertRequest.Count));
            return response.Values;
        }

        private Dictionary<string, InstrumentDefinition> CreateInstrumentUpsertRequest(List<LusidInstrument> instruments)
        {
            return instruments
                .ToDictionary(
                    instrument => $"upsertIdFor{instrument.InstrumentType}",
                    instrument => new InstrumentDefinition(
                        name: instrument.InstrumentType.ToString(),
                        identifiers: new Dictionary<string, InstrumentIdValue>
                        {
                            ["ClientInternal"] = new InstrumentIdValue(value: instrument.InstrumentType + "_uniqueId")
                        },
                        definition: instrument));
        }

        /// <summary>
        /// This method add instruments to a portfolio (specified by its scope and code),
        /// by creating a transaction request with the instrument's LUID.
        /// </summary>
        public void AddInstrumentsTransactionToPortfolio(
            List<string> luids,
            string scope,
            string portfolioID,
            DateTimeOffset effectiveAt)
        {
            // CREATE instrument transaction request
            var transactionRequests = luids.Select(luid =>
                    BuildTransactionRequest(luid, 1, 0.0m, "USD", effectiveAt, "Buy"))
                .ToList();

            // UPSERT transactions to portfolio
            _transactionPortfoliosApi.UpsertTransactions(scope, portfolioID, transactionRequests);
        }

        
        /// <summary>
        /// This method upserts JPY/USD and USD/JPY fx quotes for the given effectiveAt date
        /// </summary>
        public void UpsertFxRate(string scope, DateTimeOffset effectiveAt) => UpsertFxRate(scope, effectiveAt, effectiveAt);

        /// <summary>
        /// This method upserts JPY/USD and USD/JPY fx quotes for every day in the date range
        /// </summary>
        public void UpsertFxRate(string scope, DateTimeOffset effectiveFrom,  DateTimeOffset effectiveAt, bool useConstantFxRate = false)
        {
            // CREATE fx quotes and inverse fx rate in the desired date range
            var upsertQuoteRequests = new Dictionary<string, UpsertQuoteRequest>();
            var numberOfDaysBetween = (effectiveAt - effectiveFrom).Days;
            for (var days = 0; days != numberOfDaysBetween + 1; ++days)
            {
                var date = effectiveFrom.AddDays(days);
                if (useConstantFxRate)
                {
                    var fxRate = CreateSimpleQuoteUpsertRequest("USD/JPY", QuoteSeriesId.InstrumentIdTypeEnum.CurrencyPair, 150, "USD", date);
                    var inverseFxRate = CreateSimpleQuoteUpsertRequest("JPY/USD", QuoteSeriesId.InstrumentIdTypeEnum.CurrencyPair, 1m / 150, "USD", date);

                    upsertQuoteRequests.Add($"day_{days}_fx_rate", fxRate);
                    upsertQuoteRequests.Add($"day_{days}_inverseFx_rate", inverseFxRate);
                }
                else
                {
                    var fxRate = CreateSimpleQuoteUpsertRequest("USD/JPY", QuoteSeriesId.InstrumentIdTypeEnum.CurrencyPair, (150 + days), "USD", date);
                    var inverseFxRate = CreateSimpleQuoteUpsertRequest("JPY/USD", QuoteSeriesId.InstrumentIdTypeEnum.CurrencyPair, 1m / (150 + days), "USD", date);

                    upsertQuoteRequests.Add($"day_{days}_fx_rate", fxRate);
                    upsertQuoteRequests.Add($"day_{days}_inverseFx_rate", inverseFxRate);
                }
            }

            // CHECK quotes upsert was successful for all the quotes
            var upsertResponse = _quotesApi.UpsertQuotes(scope, upsertQuoteRequests);
            Assert.That(upsertResponse.Failed.Count, Is.EqualTo(0));
            Assert.That(upsertResponse.Values.Count, Is.EqualTo(upsertQuoteRequests.Count));
        }

        /// <summary>
        /// This method upserts the reset quotes for the floating leg of a swap
        /// </summary>
        public void UpsertResetQuotes(string scope, DateTimeOffset effectiveAt)
        {
            // CREATE reset quotes in the desired date range
            var upsertQuoteRequests = new Dictionary<string, UpsertQuoteRequest>();

            var resetQuote = CreateSimpleQuoteUpsertRequest("BP00", QuoteSeriesId.InstrumentIdTypeEnum.RIC, 150, "USD", effectiveAt);
            upsertQuoteRequests.Add($"resetQuote", resetQuote);

            // CHECK quotes upsert was successful for all the quotes
            var upsertResponse = _quotesApi.UpsertQuotes(scope, upsertQuoteRequests);
            Assert.That(upsertResponse.Failed.Count, Is.EqualTo(0));
            Assert.That(upsertResponse.Values.Count, Is.EqualTo(upsertQuoteRequests.Count));
        }

        private void UpsertEquityQuote(
            string instrumentId,
            string scope,
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
                var quote = CreateSimpleQuoteUpsertRequest(instrumentId, instrumentIdType, 100 + days, "USD", date);
                upsertQuoteRequests.Add($"day_{days}_equity_quote", quote);
            }

            // CHECK quotes upsert was successful for all the quotes
            var upsertResponse = _quotesApi.UpsertQuotes(scope, upsertQuoteRequests);
            Assert.That(upsertResponse.Failed.Count, Is.EqualTo(0));
            Assert.That(upsertResponse.Values.Count, Is.EqualTo(upsertQuoteRequests.Count));
        }


        /// <summary>
        /// Helper method to create simple equity or fx quote upsert request
        /// </summary>
        internal static UpsertQuoteRequest CreateSimpleQuoteUpsertRequest(
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
        public void UpsertRateCurves(string scope, DateTimeOffset effectiveAt)
        {
            CreateAndUpsertOisCurve(scope, effectiveAt, "USD");
            CreateAndUpsertOisCurveHighRates(scope, effectiveAt, "JPY");
            CreateAndUpsert6MRateCurve(scope, effectiveAt, "USD"); // this would be necessary for valuation of swaps paying every 6M
        }

        public void CreateAndUpsertOisCurve(string scope, DateTimeOffset effectiveAt, string currency)
        {
            var complexMarketData = CreateDiscountCurve(effectiveAt);
            var complexMarketDataId = new ComplexMarketDataId(
                provider: "Lusid",
                effectiveAt: effectiveAt.ToString("o"),
                marketAsset: $"{currency}/{currency}OIS",
                priceSource: "");
            var upsertRequest = new Dictionary<string, UpsertComplexMarketDataRequest>
                {{"0", new UpsertComplexMarketDataRequest(complexMarketDataId, complexMarketData)}};

            // CHECK upsert was successful
            var upsertResponse = _complexMarketDataApi.UpsertComplexMarketData(scope, upsertRequest);
            Assert.That(upsertResponse.Values.Values, Is.Not.Null);
            Assert.That(upsertResponse.Values.Values.Count, Is.EqualTo(upsertRequest.Count));
        }

        public void CreateAndUpsertOisCurveHighRates(string scope, DateTimeOffset effectiveAt, string currency)
        {
            // different rates as the valuation for some instruments such as fx forwards depend on the difference between the rates curves in two currencies
            var complexMarketData = CreateDiscountCurveHighRates(effectiveAt);
            var complexMarketDataId = new ComplexMarketDataId(
                provider: "Lusid",
                effectiveAt: effectiveAt.ToString("o"),
                marketAsset: $"{currency}/{currency}OIS",
                priceSource: "");
            var upsertRequest = new Dictionary<string, UpsertComplexMarketDataRequest>
                {{"0", new UpsertComplexMarketDataRequest(complexMarketDataId, complexMarketData)}};

            // CHECK upsert was successful
            var upsertResponse = _complexMarketDataApi.UpsertComplexMarketData(scope, upsertRequest);
            Assert.That(upsertResponse.Values.Values, Is.Not.Null);
            Assert.That(upsertResponse.Values.Values.Count, Is.EqualTo(upsertRequest.Count));
        }

        private DiscountFactorCurveData CreateDiscountCurve(DateTimeOffset effectiveAt)
        {
            var discountDates = new List<DateTimeOffset>
                { effectiveAt, effectiveAt.AddMonths(3), effectiveAt.AddMonths(6), effectiveAt.AddMonths(9), effectiveAt.AddMonths(12), effectiveAt.AddYears(5) };
            var rates = new List<decimal> { 1.0m, 0.995026109593975m, 0.990076958773721m, 0.985098445011387m, 0.980144965261876m, 0.9m };
            return new DiscountFactorCurveData(effectiveAt, discountDates, rates, ComplexMarketData.MarketDataTypeEnum.DiscountFactorCurveData);
        }

        private DiscountFactorCurveData CreateDiscountCurveHighRates(DateTimeOffset effectiveAt)
        {
            var discountDates = new List<DateTimeOffset>
                { effectiveAt, effectiveAt.AddMonths(3), effectiveAt.AddMonths(6), effectiveAt.AddMonths(9), effectiveAt.AddMonths(12), effectiveAt.AddYears(5) };
            var rates = new List<decimal> { 1.0m, 0.992548449440757m, 0.985152424487251m, 0.977731146620901m, 0.970365774179742m, 0.85m };
            return new DiscountFactorCurveData(effectiveAt, discountDates, rates, ComplexMarketData.MarketDataTypeEnum.DiscountFactorCurveData);
        }

        public void CreateAndUpsert6MRateCurve(string scope, DateTimeOffset effectiveAt, string currency)
        {
            var complexMarketData = GetRateCurveJsonFromFile("USD6M.json");
            var complexMarketDataId = new ComplexMarketDataId(
                provider: "Lusid",
                effectiveAt: effectiveAt.ToString("o"),
                marketAsset: $"{currency}/6M",
                priceSource: "");

            var upsertRequest = new Dictionary<string, UpsertComplexMarketDataRequest>
                {{"0", new UpsertComplexMarketDataRequest(complexMarketDataId, complexMarketData)}};

            // CHECK upsert was successful
            var upsertResponse = _complexMarketDataApi.UpsertComplexMarketData(scope, upsertRequest);
            Assert.That(upsertResponse.Values.Values, Is.Not.Null);
            Assert.That(upsertResponse.Values.Values.Count, Is.EqualTo(upsertRequest.Count));
        }

        private static ComplexMarketData GetRateCurveJsonFromFile(string filename)
        {
            using var reader = new StreamReader(ExampleMarketDataDirectory + filename);
            var jsonString = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<DiscountFactorCurveData>(jsonString);
        }

        
        public void DeleteItems(string scope, 
            string recipeCode = null, 
            string portfolioCode = null,
            string instrumentId = null
            )
        {

            if (recipeCode != null)
                _recipeApi.DeleteConfigurationRecipe(scope, recipeCode);
            if (instrumentId != null)
                _instrumentsApi.DeleteInstrument("ClientInternal", instrumentId); 
            if (portfolioCode != null)
               _portfoliosApi.DeletePortfolio(scope, portfolioCode); 

        }
        

    }
}
