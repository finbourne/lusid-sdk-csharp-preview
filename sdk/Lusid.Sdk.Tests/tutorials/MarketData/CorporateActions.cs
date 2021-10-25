using System;
using System.Collections.Generic;
using System.Linq;
using Lusid.Sdk.Api;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using Lusid.Sdk.Utilities;
using LusidFeatures;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Tutorials.MarketData
{
    [TestFixture]
    public class CorporateActions
    {
        private TestDataUtilities _testDataUtilities;
        private ILusidApiFactory _apiFactory;
        private ICorporateActionSourcesApi _corporateActionSourcesApi;
        private ITransactionPortfoliosApi _transactionPortfoliosApi;
        private IList<string> _instrumentIds;
        private const string CorpActionTestSource = "corp_action_test_source";

        [OneTimeSetUp]
        public void SetUp()
        {
            _apiFactory = TestLusidApiFactoryBuilder.CreateApiFactory("secrets.json");

            _transactionPortfoliosApi = _apiFactory.Api<ITransactionPortfoliosApi>();
            _testDataUtilities = new TestDataUtilities(_transactionPortfoliosApi);
            _corporateActionSourcesApi = _apiFactory.Api<ICorporateActionSourcesApi>();

            var instrumentsLoader = new InstrumentLoader(_apiFactory);
            _instrumentIds = instrumentsLoader.LoadInstruments().OrderBy(x => x).ToList();

            // Create Corporate Action Source
            var sources = _corporateActionSourcesApi.ListCorporateActionSources();
            if (!sources.Values.Select(i => i.Id.Code).Contains(CorpActionTestSource))
            {
                _corporateActionSourcesApi.CreateCorporateActionSource(
                    new CreateCorporateActionSourceRequest(
                        TestDataUtilities.TutorialScope,
                        CorpActionTestSource,
                        "Test Source",
                        "Corporate Actions source used for automated testing"
                        )
                    );
            }
        }
        
        [LusidFeature("F12-6")]
        [Test]
        public void List_Corporate_Action_Sources()
        {
            var sources = _corporateActionSourcesApi.ListCorporateActionSources();

            foreach (var source in sources.Values)
            {
                Console.WriteLine($"{source.Id.Scope}\t:\t{source.Id.Code}");
            }
        }

        [Test, Ignore("Not implemented")]
        public void List_Corporate_Actions_For_One_Day()
        {
            var result = _corporateActionSourcesApi.GetCorporateActions(
                scope: "UK_High_Growth_Equities_Fund_a4fb",
                code: "UK_High_Growth_Equities_Fund_base_fund_corporate_action_source"
            );

        }

        [LusidFeature("F12-2")]
        [Test]
        public void Load_Dividend_Payment()
        {
            var startDate = new DateTimeOffset(2021, 9, 1, 0, 0, 0, TimeSpan.Zero);
            var announcementDate = new DateTimeOffset(2021, 09, 6, 0, 0, 0, TimeSpan.Zero);
            var exDate = new DateTimeOffset(2021, 09, 20, 0, 0, 0, TimeSpan.Zero);
            var recordDate = new DateTimeOffset(2021, 09, 21, 0, 0, 0, TimeSpan.Zero);
            var paymentDate = new DateTimeOffset(2021, 10, 5, 0, 0, 0, TimeSpan.Zero);

            var preExDate = new DateTimeOffset(2021, 09, 15, 0, 0, 0, TimeSpan.Zero);
            var prePaymentDate = new DateTimeOffset(2021, 10, 4, 0, 0, 0, TimeSpan.Zero);
            var postPaymentDate = new DateTimeOffset(2021, 10, 12, 0, 0, 0, TimeSpan.Zero);

            var uuid = Guid.NewGuid().ToString();

            var portfolioCode = $"id-{uuid}";
            var transactions = new List<TransactionRequest>();

            var currencyLuid = "CCY_GBP";

            // Create the portfolio
            var request = new CreateTransactionPortfolioRequest(
                code: portfolioCode,
                displayName: $"Portfolio-{uuid}",
                baseCurrency: "GBP",
                created: startDate,
                corporateActionSourceId: new ResourceId(
                    scope: TestDataUtilities.TutorialScope,
                    code: CorpActionTestSource
                    )
            );
            _transactionPortfoliosApi.CreatePortfolio(TestDataUtilities.TutorialScope, request);

            // Add starting cash position
            transactions.Add(_testDataUtilities.BuildCashFundsInTransactionRequest(2960000, "GBP", startDate));

            // Add an equity position
            transactions.Add(_testDataUtilities.BuildTransactionRequest(_instrumentIds[0], 132000, 5, "GBP", startDate, "StockIn"));

            _apiFactory.Api<ITransactionPortfoliosApi>().UpsertTransactions(TestDataUtilities.TutorialScope, portfolioCode, transactions);

            // Upsert Corporate Action
            var identifierMappingInput = new Dictionary<string, string>();
            identifierMappingInput.Add("Instrument/default/LusidInstrumentId", _instrumentIds[0]);

            var identifierMappingOutput = new Dictionary<string, string>();
            identifierMappingOutput.Add("Instrument/default/Currency", "GBP");

            var stockSplitCorpActionRequest = new UpsertCorporateActionRequest(
                TestDataUtilities.TutorialScope,
                "Dividend Payment",
                announcementDate,
                exDate,
                recordDate,
                paymentDate,
                new List<CorporateActionTransitionRequest>()
                {
                    new CorporateActionTransitionRequest()
                    {
                        InputTransition = new CorporateActionTransitionComponentRequest (identifierMappingInput,1,0),
                        OutputTransitions = new List<CorporateActionTransitionComponentRequest>()
                        {
                            new CorporateActionTransitionComponentRequest(identifierMappingOutput,(decimal)0.5,0)
                        }
                    }
                });

            _corporateActionSourcesApi.BatchUpsertCorporateActions(TestDataUtilities.TutorialScope, CorpActionTestSource, new List<UpsertCorporateActionRequest>() { stockSplitCorpActionRequest });

            //
            // fetch holdings pre ex-dividend date
            //
            var holdingsResultPreExDate = _transactionPortfoliosApi.GetHoldings(TestDataUtilities.TutorialScope, portfolioCode, effectiveAt: preExDate);
            var holdingsPreExDate = holdingsResultPreExDate.Values.OrderBy(h => h.InstrumentUid).ToList();

            // check for 2 holdings records
            Assert.That(holdingsPreExDate.Count(), Is.EqualTo(2));

            // check cash balance hasn't changed
            Assert.That(holdingsPreExDate[0].InstrumentUid, Is.EqualTo(currencyLuid));
            Assert.That(holdingsPreExDate[0].Units, Is.EqualTo(2960000));
            Assert.That(holdingsPreExDate[0].HoldingType, Is.EqualTo("B"));

            //  check stock quantity hasn't changed
            Assert.That(holdingsPreExDate[1].InstrumentUid, Is.EqualTo(_instrumentIds[0]));
            Assert.That(holdingsPreExDate[1].Units, Is.EqualTo(132000));


            //
            // fetch holdings after the ex-dividend date but before the payment date
            //
            var holdingsResultPostExDate = _transactionPortfoliosApi.GetHoldings(TestDataUtilities.TutorialScope, portfolioCode, effectiveAt: prePaymentDate);
            var holdingsPostExDate = holdingsResultPostExDate.Values.OrderBy(h => h.InstrumentUid).ToList();

            // check for 3 holdings records (will include an accrued amount seperately)
            Assert.That(holdingsPostExDate.Count(), Is.EqualTo(3));

            //  check we still have a 'Cash Balance' holding type in the amount of 2960000
            Assert.That(holdingsPostExDate[0].InstrumentUid, Is.EqualTo(currencyLuid));
            Assert.That(holdingsPostExDate[0].Units, Is.EqualTo(2960000));
            Assert.That(holdingsPostExDate[0].HoldingType, Is.EqualTo("B"));

            //  check we have a 'Cash Accrual' in the amount of 66000
            Assert.That(holdingsPostExDate[1].InstrumentUid, Is.EqualTo(currencyLuid));
            Assert.That(holdingsPostExDate[1].Units, Is.EqualTo(66000));
            Assert.That(holdingsPostExDate[1].HoldingType, Is.EqualTo("A"));

            //  check stock quantity hasn't changed
            Assert.That(holdingsPostExDate[2].InstrumentUid, Is.EqualTo(_instrumentIds[0]));
            Assert.That(holdingsPostExDate[2].Units, Is.EqualTo(132000));


            //
            // fetch holdings after the the payment date
            //
            var holdingsResultPostPayDate = _transactionPortfoliosApi.GetHoldings(TestDataUtilities.TutorialScope, portfolioCode, effectiveAt: postPaymentDate);
            var holdingsPostPayDate = holdingsResultPostPayDate.Values.OrderBy(h => h.InstrumentUid).ToList();

            // check for 2 holdings records (accrued amount now realized)
            Assert.That(holdingsPostPayDate.Count(), Is.EqualTo(2));

            //  check cash balance has increased by the dividend amount
            Assert.That(holdingsPostPayDate[0].InstrumentUid, Is.EqualTo(currencyLuid));
            Assert.That(holdingsPostPayDate[0].Units, Is.EqualTo(3026000));
            Assert.That(holdingsPostPayDate[0].HoldingType, Is.EqualTo("B"));

            //  check stock quantity hasn't changed
            Assert.That(holdingsPostPayDate[1].InstrumentUid, Is.EqualTo(_instrumentIds[0]));
            Assert.That(holdingsPostPayDate[1].Units, Is.EqualTo(132000));
        }

        [LusidFeature("F12-3")]
        [Test]
        public void Load_Stock_Split()
        {
            var startDate = new DateTimeOffset(2021, 9, 1, 0, 0, 0, TimeSpan.Zero);
            var announcementDate = new DateTimeOffset(2021, 09, 4, 0, 0, 0, TimeSpan.Zero);
            var exDate = new DateTimeOffset(2021, 09, 6, 0, 0, 0, TimeSpan.Zero);
            var recordDate = new DateTimeOffset(2021, 09, 20, 0, 0, 0, TimeSpan.Zero);
            var paymentDate = new DateTimeOffset(2021, 09, 22, 0, 0, 0, TimeSpan.Zero);

            var postSplitDate = new DateTimeOffset(2021, 9, 24, 0, 0, 0, TimeSpan.Zero);

            var uuid = Guid.NewGuid().ToString();

            var portfolioCode = $"id-{uuid}";
            var transactions = new List<TransactionRequest>();

            var currencyLuid = "CCY_GBP";

            // Create the portfolio
            var request = new CreateTransactionPortfolioRequest(
                code: portfolioCode,
                displayName: $"Portfolio-{uuid}",
                baseCurrency: "GBP",
                created: startDate,
                corporateActionSourceId: new ResourceId(
                    scope: TestDataUtilities.TutorialScope,
                    code: CorpActionTestSource
                    )
            );
            _transactionPortfoliosApi.CreatePortfolio(TestDataUtilities.TutorialScope, request);

            // Add starting cash position
            transactions.Add(_testDataUtilities.BuildCashFundsInTransactionRequest(2960000, "GBP", startDate));

            // Add an equity position
            transactions.Add(_testDataUtilities.BuildTransactionRequest(_instrumentIds[0], 132000, 5, "GBP", startDate, "StockIn"));

            _apiFactory.Api<ITransactionPortfoliosApi>().UpsertTransactions(TestDataUtilities.TutorialScope, portfolioCode, transactions);

            // Upsert Corporate Action   
            var identifierMapping = new Dictionary<string, string>();
            identifierMapping.Add("Instrument/default/LusidInstrumentId", _instrumentIds[0]);

            var stockSplitCorpActionRequest = new UpsertCorporateActionRequest(
                TestDataUtilities.TutorialScope,
                "Stock Split",
                announcementDate,
                exDate,
                recordDate,
                paymentDate,
                new List<CorporateActionTransitionRequest>()
                {
                    new CorporateActionTransitionRequest()
                    {
                        InputTransition = new CorporateActionTransitionComponentRequest (identifierMapping,1,1),
                        OutputTransitions = new List<CorporateActionTransitionComponentRequest>()
                        {
                            new CorporateActionTransitionComponentRequest(identifierMapping,2,1)
                        }
                    }
                });

            _corporateActionSourcesApi.BatchUpsertCorporateActions(TestDataUtilities.TutorialScope, CorpActionTestSource, new List<UpsertCorporateActionRequest>() { stockSplitCorpActionRequest });

            //
            // fetch holdings pre ex-dividend date
            //
            var holdingsResultPreExDate = _transactionPortfoliosApi.GetHoldings(TestDataUtilities.TutorialScope, portfolioCode, effectiveAt: announcementDate);
            var holdingsPreExDate = holdingsResultPreExDate.Values.OrderBy(h => h.InstrumentUid).ToList();

            //  check cash balance hasn't changed
            Assert.That(holdingsPreExDate[0].InstrumentUid, Is.EqualTo(currencyLuid));
            Assert.That(holdingsPreExDate[0].Units, Is.EqualTo(2960000));
            Assert.That(holdingsPreExDate[0].HoldingType, Is.EqualTo("B"));

            //  check stock quantity hasn't changed
            Assert.That(holdingsPreExDate[1].InstrumentUid, Is.EqualTo(_instrumentIds[0]));
            Assert.That(holdingsPreExDate[1].Units, Is.EqualTo(132000));
            Assert.That(holdingsPreExDate[1].SettledUnits, Is.EqualTo(132000));


            //
            // fetch holdings post ex-dividend date but pre pay date
            //
            var holdingsResultPostExDate = _transactionPortfoliosApi.GetHoldings(TestDataUtilities.TutorialScope, portfolioCode, effectiveAt: recordDate);
            var holdingsPostExDate = holdingsResultPostExDate.Values.OrderBy(h => h.InstrumentUid).ToList();

            //  check cash balance hasn't changed
            Assert.That(holdingsPostExDate[0].InstrumentUid, Is.EqualTo(currencyLuid));
            Assert.That(holdingsPostExDate[0].Units, Is.EqualTo(2960000));
            Assert.That(holdingsPostExDate[0].HoldingType, Is.EqualTo("B"));

            //  check stock quantity has doubled for unsettled units
            Assert.That(holdingsPostExDate[1].InstrumentUid, Is.EqualTo(_instrumentIds[0]));
            Assert.That(holdingsPostExDate[1].Units, Is.EqualTo(264000));
            Assert.That(holdingsPostExDate[1].SettledUnits, Is.EqualTo(132000));


            //
            // fetch holdings post pay date
            //
            var holdingsResultPostPayDate = _transactionPortfoliosApi.GetHoldings(TestDataUtilities.TutorialScope, portfolioCode, effectiveAt: postSplitDate);
            var holdingsPostPayDate = holdingsResultPostPayDate.Values.OrderBy(h => h.InstrumentUid).ToList();

            //  check cash balance hasn't changed
            Assert.That(holdingsPostPayDate[0].InstrumentUid, Is.EqualTo(currencyLuid));
            Assert.That(holdingsPostPayDate[0].Units, Is.EqualTo(2960000));
            Assert.That(holdingsPostPayDate[0].HoldingType, Is.EqualTo("B"));

            //  check stock quantity has doubled for settled and unseltted units
            Assert.That(holdingsPostPayDate[1].InstrumentUid, Is.EqualTo(_instrumentIds[0]));
            Assert.That(holdingsPostPayDate[1].Units, Is.EqualTo(264000));
            Assert.That(holdingsPostPayDate[1].SettledUnits, Is.EqualTo(264000));
        }
    }
}