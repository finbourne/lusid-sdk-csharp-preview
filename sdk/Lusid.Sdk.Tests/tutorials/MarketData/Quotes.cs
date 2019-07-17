using System;
using System.Collections.Generic;
using System.Linq;
using Lusid.Sdk.Api;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using Lusid.Sdk.Utilities;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Tutorials.MarketData
{
    [TestFixture]
    public class Quotes
    {
        private IQuotesApi _quotesApi;

        [OneTimeSetUp]
        public void SetUp()
        {
            var apiFactory = LusidApiFactoryBuilder.Build("secrets.json");
            _quotesApi = apiFactory.Api<IQuotesApi>();
        }

        [Test]
        public void Add_Quote()
        {
            var request = new UpsertQuoteRequest(
                quoteId: new QuoteId(
                    provider: "DataScope",
                    instrumentId: "BBG000B9XRY4",
                    instrumentIdType: QuoteId.InstrumentIdTypeEnum.Figi,
                    quoteType: QuoteId.QuoteTypeEnum.Price,
                    priceSide: QuoteId.PriceSideEnum.Mid
                ),
                metricValue: new MetricValue(
                    value: 199.23,
                    unit: "USD"
                ),
                effectiveAt: new DateTimeOffset(2019, 4, 15, 0, 0, 0, TimeSpan.Zero),
                lineage: "InternalSystem"
            );

            _quotesApi.UpsertQuotes(TestDataUtilities.TutorialScope, new List<UpsertQuoteRequest> {request});
        }

        [Test]
        public void Get_Quote_For_Instrument_For_Single_Day()
        {
            var quoteId = new QuoteId(
                provider: "DataScope",
                instrumentId: "BBG000B9XRY4",
                instrumentIdType: QuoteId.InstrumentIdTypeEnum.Figi,
                quoteType: QuoteId.QuoteTypeEnum.Price,
                priceSide: QuoteId.PriceSideEnum.Mid
            );
            var effectiveDate = new DateTimeOffset(2019, 4, 15, 0, 0, 0, TimeSpan.Zero);
            
            //  Get the close quote for AAPL on 15-Apr-19
            var quoteResponse = _quotesApi.GetQuotes(
                TestDataUtilities.TutorialScope,
                effectiveAt: effectiveDate,
                quoteIds: new List<QuoteId> {quoteId}
            );
            
            Assert.That(quoteResponse.Found.Count, Is.EqualTo(1));

            Quote quote = quoteResponse.Found[0];
            
            Assert.That(quote.MetricValue.Value, Is.EqualTo(199.23));
        }

        [Test]
        public void Get_Timeseries_Quotes()
        {
            var startDate = new DateTimeOffset(2019, 4, 15, 0, 0, 0, TimeSpan.Zero);
            var dateRange = Enumerable.Range(0, 30).Select(offset => startDate.AddDays(offset));
            
            var quoteId = new QuoteId(
                provider: "DataScope",
                instrumentId: "BBG000B9XRY4",
                instrumentIdType: QuoteId.InstrumentIdTypeEnum.Figi,
                quoteType: QuoteId.QuoteTypeEnum.Price,
                priceSide: QuoteId.PriceSideEnum.Mid
            );

            //    Get the quotes for each day in the date range
            var quoteResponses = dateRange
                .Select(d =>
                    _quotesApi.GetQuotes(
                        TestDataUtilities.TutorialScope,
                        effectiveAt: d,
                        quoteIds:
                        new List<QuoteId> {quoteId}
                    )
                )
                .SelectMany(q => q.Found)
                .ToList();
            
            Assert.That(quoteResponses, Has.Count.EqualTo(30));
        }

    }
}


