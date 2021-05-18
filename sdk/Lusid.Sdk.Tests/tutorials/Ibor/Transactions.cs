using System;
using System.Collections.Generic;
using System.Linq;
using Lusid.Sdk.Api;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using Lusid.Sdk.Utilities;
using LusidFeatures;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Tutorials.Ibor
{
    [TestFixture]
    public class Transactions
    {
        private IInstrumentsApi _instrumentsApi;
        private ITransactionPortfoliosApi _transactionPortfoliosApi;
        private IList<string> _instrumentIds;
        
        private TestDataUtilities _testDataUtilities;

        [OneTimeSetUp]
        public void SetUp()
        {
            var apiFactory = TestLusidApiFactoryBuilder.CreateApiFactory("secret.json");

            _instrumentsApi = apiFactory.Api<IInstrumentsApi>();
            _transactionPortfoliosApi = apiFactory.Api<ITransactionPortfoliosApi>();
            
            var instrumentLoader = new InstrumentLoader(apiFactory);
            _instrumentIds = instrumentLoader.LoadInstruments();
            _testDataUtilities = new TestDataUtilities(apiFactory.Api<ITransactionPortfoliosApi>());
        }
        
        [LusidFeature("F17")]
        [Test]
        public void Load_Listed_Instrument_Transaction()
        {
            var effectiveDate = new DateTimeOffset(2018, 1, 1, 0, 0, 0, TimeSpan.Zero);
            
            //    create the portfolio
            var portfolioCode = _testDataUtilities.CreateTransactionPortfolio(TestDataUtilities.TutorialScope);
            
            //    create the transaction request
            var transaction = new TransactionRequest(
                
                //    unique transaction id
                transactionId: Guid.NewGuid().ToString(),
                
                //    instruments must already exist in LUSID and have a valid LUSID instrument id
                instrumentIdentifiers: new Dictionary<string, string>
                {
                    [TestDataUtilities.LusidInstrumentIdentifier] = _instrumentIds[0]
                },
                
                type: "Buy",
                totalConsideration: new CurrencyAndAmount(1230, "GBP"),
                transactionDate: effectiveDate,
                settlementDate: effectiveDate,
                units: 100,
                transactionPrice: new TransactionPrice(12.3M),
                source: "Custodian");
            
            //    add the transaction
            _transactionPortfoliosApi.UpsertTransactions(TestDataUtilities.TutorialScope, portfolioCode, new List<TransactionRequest> {transaction});
            
            //    get the transaction
            var transactions = _transactionPortfoliosApi.GetTransactions(TestDataUtilities.TutorialScope, portfolioCode);
            
            Assert.That(transactions.Values, Has.Count.EqualTo(1));
            Assert.That(transactions.Values[0].TransactionId, Is.EqualTo(transaction.TransactionId));
        }
        
        [LusidFeature("F18")]
        [Test]
        public void Load_Cash_Transaction()
        {
            var effectiveDate = new DateTimeOffset(2018, 1, 1, 0, 0, 0, TimeSpan.Zero);
            
            //    create the portfolio
            var portfolioCode = _testDataUtilities.CreateTransactionPortfolio(TestDataUtilities.TutorialScope);
            
            //    create the transaction request
            var transaction = new TransactionRequest(
                
                //    unique transaction id
                transactionId: Guid.NewGuid().ToString(),
                
                //    instruments must already exist in LUSID and have a valid LUSID instrument id
                instrumentIdentifiers: new Dictionary<string, string>
                {
                    [TestDataUtilities.LusidCashIdentifier] = "GBP"
                },
                
                type: "FundsIn",
                totalConsideration: new CurrencyAndAmount(0.0M, "GBP"),
                transactionPrice: new TransactionPrice(0.0M),
                transactionDate: effectiveDate,
                settlementDate: effectiveDate,
                units: 100,
                source: "Custodian");
            
            //    add the transaction
            _transactionPortfoliosApi.UpsertTransactions(TestDataUtilities.TutorialScope, portfolioCode, new List<TransactionRequest> {transaction});
            
            //    get the transaction
            var transactions = _transactionPortfoliosApi.GetTransactions(TestDataUtilities.TutorialScope, portfolioCode);
            
            Assert.That(transactions.Values, Has.Count.EqualTo(1));
            Assert.That(transactions.Values[0].TransactionId, Is.EqualTo(transaction.TransactionId));
        }
        [LusidFeature("F19")]
        [Test]
        public void Load_Otc_Instrument_Transaction()
        {
            var effectiveDate = new DateTimeOffset(2018, 1, 1, 0, 0, 0, TimeSpan.Zero);
            
            //    create the portfolio
            var portfolioCode = _testDataUtilities.CreateTransactionPortfolio(TestDataUtilities.TutorialScope);
            
            //    swap definition, this is uploaded in a client custom format
            var swapDefinition = new InstrumentDefinition(
                name: "10mm 5Y Fixed",
                identifiers: new Dictionary<string, InstrumentIdValue>
                {
                    ["ClientInternal"] = new InstrumentIdValue(value: "SW-1")
                },
                definition: new ExoticInstrument(
                    instrumentFormat: new InstrumentDefinitionFormat("CustomSource", "CustomFormat", "0.1.2"),
                    content: "<customFormat>the definition of the swap uploaded in custom Xml or Json format. One would expect that it should contain the full custom swap detail.</customFormat>",
                    instrumentType: LusidInstrument.InstrumentTypeEnum.ExoticInstrument
                ));
            
            //    create the swap
            var createSwapResponse = _instrumentsApi.UpsertInstruments(new Dictionary<string, InstrumentDefinition>
            {
                ["correlationId"] = swapDefinition
            });

            var swapId = createSwapResponse.Values.Values.Select(i => i.LusidInstrumentId).FirstOrDefault();
            
            //    create the transaction request
            var transaction = new TransactionRequest(
                
                //    unique transaction id
                transactionId: Guid.NewGuid().ToString(),
                
                //    instruments must already exist in LUSID and have a valid LUSID instrument id
                instrumentIdentifiers: new Dictionary<string, string>
                {
                    [TestDataUtilities.LusidInstrumentIdentifier] = swapId
                },
                
                type: "Buy",
                totalConsideration: new CurrencyAndAmount(0.0M, "GBP"),
                transactionPrice: new TransactionPrice(0.0M),
                transactionDate: effectiveDate,
                settlementDate: effectiveDate,
                units: 1,
                source: "Custodian");
            
            //    add the transaction
            _transactionPortfoliosApi.UpsertTransactions(TestDataUtilities.TutorialScope, portfolioCode, new List<TransactionRequest> {transaction});
            
            //    get the transaction
            var transactions = _transactionPortfoliosApi.GetTransactions(TestDataUtilities.TutorialScope, portfolioCode);
            
            Assert.That(transactions.Values, Has.Count.EqualTo(1));
            Assert.That(transactions.Values[0].TransactionId, Is.EqualTo(transaction.TransactionId));
            Assert.That(transactions.Values[0].InstrumentUid, Is.EqualTo(swapId));
        }
        
        [LusidFeature("F31")]
        [Test]
        public void Cancel_Transactions()
        {
            var effectiveDate = new DateTimeOffset(2018, 1, 1, 0, 0, 0, TimeSpan.Zero);
            
            //    create the portfolio
            var portfolioCode = _testDataUtilities.CreateTransactionPortfolio(TestDataUtilities.TutorialScope);
            
            //    create the transaction requests
            var transactionRequests = new[]
            {
                new TransactionRequest(

                    //    unique transaction id
                    transactionId: Guid.NewGuid().ToString(),

                    //    instruments must already exist in LUSID and have a valid LUSID instrument id
                    instrumentIdentifiers: new Dictionary<string, string>
                    {
                        [TestDataUtilities.LusidInstrumentIdentifier] = _instrumentIds[0]
                    },

                    type: "Buy",
                    totalConsideration: new CurrencyAndAmount(1230, "GBP"),
                    transactionDate: effectiveDate,
                    settlementDate: effectiveDate,
                    units: 100,
                    transactionPrice: new TransactionPrice(12.3M),
                    source: "Custodian"),
                new TransactionRequest(

                    //    unique transaction id
                    transactionId: Guid.NewGuid().ToString(),

                    //    instruments must already exist in LUSID and have a valid LUSID instrument id
                    instrumentIdentifiers: new Dictionary<string, string>
                    {
                        [TestDataUtilities.LusidInstrumentIdentifier] = _instrumentIds[0]
                    },

                    type: "Sell",
                    totalConsideration: new CurrencyAndAmount(45, "GBP"),
                    transactionDate: effectiveDate,
                    settlementDate: effectiveDate,
                    units: 50,
                    transactionPrice: new TransactionPrice(20.4M),
                    source: "Custodian")
            };

            //    add the transactions
            _transactionPortfoliosApi.UpsertTransactions(TestDataUtilities.TutorialScope, portfolioCode, transactionRequests.ToList());
            
            //    get the transactions
            var transactions = _transactionPortfoliosApi.GetTransactions(TestDataUtilities.TutorialScope, portfolioCode);
            
            Assert.That(transactions.Values, Has.Count.EqualTo(2));
            Assert.That(transactions.Values.Select(t => t.TransactionId), Is.EquivalentTo(transactionRequests.Select(t => t.TransactionId)));

            //    cancel the transactions
            _transactionPortfoliosApi.CancelTransactions(TestDataUtilities.TutorialScope, portfolioCode, transactions.Values.Select(t => t.TransactionId).ToList());

            //    verify the portfolio is now empty
            var noTransactions = _transactionPortfoliosApi.GetTransactions(TestDataUtilities.TutorialScope, portfolioCode);

            Assert.That(noTransactions.Values, Is.Empty);
        }
    }
}