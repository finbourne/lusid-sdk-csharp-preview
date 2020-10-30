using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Castle.Core.Internal;
using Lusid.Sdk.Api;
using Lusid.Sdk.Model;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Utilities
{
    public class TestDataUtilities
    {
        private static readonly string ExampleMarketDataDirectory = "../../../tutorials/Ibor/ExampleMarketData/";
        public const string TutorialScope = "Testdemo";
        public const string MarketDataScope = "FinbourneMarketData";
        
        //    Specific key used to denote cash in LUSID
        public const string LusidCashIdentifier = "Instrument/default/Currency";
        public const string LusidInstrumentIdentifier = "Instrument/default/LusidInstrumentId";
        
        private readonly ITransactionPortfoliosApi _transactionPortfoliosApi;
        private readonly IInstrumentsApi _instrumentsApi;
        private readonly IQuotesApi _quotesApi;
        private readonly IStructuredMarketDataApi _structuredMarketDataApi;

        public TestDataUtilities(ITransactionPortfoliosApi transactionPortfoliosApi)
        {
            _transactionPortfoliosApi = transactionPortfoliosApi;
        }

        public TestDataUtilities(
            ITransactionPortfoliosApi transactionPortfoliosApi,
            IInstrumentsApi instrumentsApi,
            IQuotesApi quotesApi,
            IStructuredMarketDataApi structuredMarketDataApi)
        {
            _transactionPortfoliosApi = transactionPortfoliosApi;
            _instrumentsApi = instrumentsApi;
            _quotesApi = quotesApi;
            _structuredMarketDataApi = structuredMarketDataApi;
        }

        public string CreateTransactionPortfolio(string scope)
        {
            var uuid = Guid.NewGuid().ToString();
            
            //    Effective date of the portfolio, this is the date the portfolio was created and became live.  All dates/times
            //    must be supplied in UTC
            var effectiveDate = new DateTimeOffset(2018, 1, 1, 0, 0, 0, TimeSpan.Zero);
            
            //    Details of the new portfolio to be created, created here with the minimum set of mandatory fields
            var request = new CreateTransactionPortfolioRequest(
                code: $"id-{uuid}",
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
            decimal? units, 
            decimal? price,
            string currency,
            DateTimeOffset tradeDate, 
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
            decimal? units,
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
        
        public void AddInstrumentsTransactionPortfolioAndPopulateRequiredMarketData(
            string portfolioScope,
            string portfolioCode,
            DateTimeOffset effectiveFrom,
            DateTimeOffset effectiveAt,
            LusidInstrument instrument,
            string equityIdentifier = null
        )
            => AddInstrumentsTransactionPortfolioAndPopulateRequiredMarketData(
                portfolioScope,
                portfolioCode,
                effectiveFrom,
                effectiveAt,
                new List<LusidInstrument> {instrument},
                equityIdentifier);

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
            string equityIdentifier = null
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
            UpsertFxRate(portfolioScope, effectiveFrom, effectiveAt);
            UpsertRateCurves(portfolioScope, effectiveAt);

            // UPSERT equity quotes, if an equityIdentifier is present
            if (!equityIdentifier.IsNullOrEmpty())
            {
                var luid = upsertResponse[equityIdentifier].LusidInstrumentId;
                UpsertEquityQuote(luid, portfolioScope, effectiveFrom, effectiveAt);
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
        private void AddInstrumentsTransactionToPortfolio(
            List<string> luids,
            string portfolioScope,
            string portfolioCode,
            DateTimeOffset effectiveAt)
        {
            // CREATE instrument transaction request
            var transactionRequests = luids.Select(luid => 
                    BuildTransactionRequest(luid, 1, null, "USD", effectiveAt, "StockIn"))
                .ToList();
            
            // UPSERT instruments to portfolio
            _transactionPortfoliosApi.UpsertTransactions(portfolioScope, portfolioCode, transactionRequests);
        }

        /// <summary>
        /// This method upserts JPY/USD and USD/JPY fx quotes for the given effectiveAt date
        /// </summary>
        public void UpsertFxRate(string scope, DateTimeOffset effectiveAt) => UpsertFxRate(scope, effectiveAt, effectiveAt);
        
        /// <summary>
        /// This method upserts JPY/USD and USD/JPY fx quotes for every day in the date range
        /// </summary>
        public void UpsertFxRate(string scope, DateTimeOffset effectiveFrom,  DateTimeOffset effectiveAt)
        {
            // CREATE fx quotes and inverse fx rate in the desired date range
            var upsertQuoteRequests = new Dictionary<string, UpsertQuoteRequest>();
            var numberOfDaysBetween = (effectiveAt - effectiveFrom).Days;
            for (var days = 0; days != numberOfDaysBetween + 1; ++days)
            {
                var date = effectiveFrom.AddDays(days);
                var fxRate = CreateSimpleQuoteUpsertRequest("USD/JPY", QuoteSeriesId.InstrumentIdTypeEnum.CurrencyPair, (150 + days), "USD", date);
                var inverseFxRate = CreateSimpleQuoteUpsertRequest("JPY/USD", QuoteSeriesId.InstrumentIdTypeEnum.CurrencyPair, 1m / (150 + days), "USD", date);
                
                upsertQuoteRequests.Add($"day_{days}_fx_rate", fxRate);
                upsertQuoteRequests.Add($"day_{days}_inverseFx_rate", inverseFxRate);
            }
            
            // CHECK quotes upsert was successful for all the quotes
            var upsertResponse = _quotesApi.UpsertQuotes(scope, upsertQuoteRequests);
            Assert.That(upsertResponse.Failed.Count, Is.EqualTo(0));
            Assert.That(upsertResponse.Values.Count, Is.EqualTo(upsertQuoteRequests.Count));
        }

        private void UpsertEquityQuote(string luid, string scope, DateTimeOffset effectiveFrom,  DateTimeOffset effectiveAt)
        {
            // CREATE equity quotes for the desired date range
            var upsertQuoteRequests = new Dictionary<string, UpsertQuoteRequest>();
            var numberOfDaysBetween = (effectiveAt - effectiveFrom).Days;
            
            for (var days = 0; days != numberOfDaysBetween + 1; ++days)
            {
                var date = effectiveFrom.AddDays(days);
                var quote = CreateSimpleQuoteUpsertRequest(luid, QuoteSeriesId.InstrumentIdTypeEnum.LusidInstrumentId, 100 + days, "USD", date);
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
        private static UpsertQuoteRequest CreateSimpleQuoteUpsertRequest(
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
        /// This method upserts the 3 rate curves from file required: 
        /// JPY/JPYOIS and USD/USDOIS are used for discounting pricing models
        /// USD 6M rate is used for pricing interest rate swap
        /// </summary>
        public void UpsertRateCurves(string scope, DateTimeOffset effectiveAt)
        {
            // CREATE dictionary of upsert requests, rates are structured market data
            var upsertRequest = new Dictionary<string, UpsertStructuredMarketDataRequest>
            {
                {$"usd_6m_rate", CreateUpsertUsdRateCurve(effectiveAt)},
                {$"usd_ois", CreateUpsertOisCurve(effectiveAt, "USD")},
                {$"jpy_ois", CreateUpsertOisCurve(effectiveAt, "JPY")}
            };

            // CHECK upsert was successful
            var upsertResponse = _structuredMarketDataApi.UpsertStructuredMarketData(scope, upsertRequest);
            Assert.That(upsertResponse.Values.Values, Is.Not.Null);
            Assert.That(upsertResponse.Values.Values.Count, Is.EqualTo(upsertRequest.Count));
        }
        
        private UpsertStructuredMarketDataRequest CreateUpsertOisCurve(DateTimeOffset effectiveAt, string currency)
        {
            var json = GetRateCurveJsonFromFile($"{currency}OIS.json");
            var structuredMarketId = new StructuredMarketDataId(
                provider: "Lusid",
                effectiveAt: effectiveAt.ToString("o"),
                marketAsset: $"{currency}/{currency}OIS",
                marketElementType: "ZeroCurve",
                priceSource: "");
            var structuredMarketData = new StructuredMarketData(
                name: $"{currency}OIS_json_file",
                documentFormat: "json",
                version: "1.0",
                document: json);

            return new UpsertStructuredMarketDataRequest(structuredMarketId, structuredMarketData);
        }

        private UpsertStructuredMarketDataRequest CreateUpsertUsdRateCurve(DateTimeOffset effectiveAt)
        {
            var json = GetRateCurveJsonFromFile("USD6M.json");
            var structuredMarketId = new StructuredMarketDataId(
                provider: "Lusid",
                effectiveAt: effectiveAt.ToString("o"),
                marketAsset: "USD/6M",
                marketElementType: "ZeroCurve",
                priceSource: "");
            var structuredMarketData = new StructuredMarketData(
                name: $"USD_6m_json",
                documentFormat: "json",
                version: "1.0",
                document: json);

            return new UpsertStructuredMarketDataRequest(structuredMarketId, structuredMarketData);
        }
        
        private static string GetRateCurveJsonFromFile(string filename)
        {
            using var reader = new StreamReader(ExampleMarketDataDirectory + filename);
            return reader.ReadToEnd();
        }
    }
}