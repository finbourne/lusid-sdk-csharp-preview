using System;
using System.Collections.Generic;
using Lusid.Sdk.Api;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using Lusid.Sdk.Utilities;
using LusidFeatures;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.tutorials.Ibor
{
    [TestFixture]
    public class CutLabels
    {
        private ILusidApiFactory _apiFactory;
        private InstrumentLoader _instrumentLoader;
        private ITransactionPortfoliosApi _transactionPortfoliosApi;
        private TestDataUtilities _testDataUtilities;
        private IList<string> _instrumentIds;

        private readonly DateTime _currentDate = DateTime.Now.Date;

        [OneTimeSetUp]
        public void SetUp()
        {
            _apiFactory = TestLusidApiFactoryBuilder.CreateApiFactory("secrets.json");

            _instrumentLoader = new InstrumentLoader(_apiFactory);
            _instrumentIds = _instrumentLoader.LoadInstruments();

            _transactionPortfoliosApi = _apiFactory.Api<ITransactionPortfoliosApi>();
            _testDataUtilities = new TestDataUtilities(_transactionPortfoliosApi);
        }

        [LusidFeature("F32")]
        [Test]
        public void Cut_Labels()
        {
            // Create storage for cut labels
            var code = new Dictionary<string, string>();

            // Create cut labels for different time zones
            Create_Cut_Label(hours: 9, minutes: 0, displayName: "LondonOpen", description: "London Opening Time, 9am in UK",
                             timeZone: "GB", codeDict: code);
            Create_Cut_Label(hours: 17, minutes: 0, displayName: "LondonClose", description: "London Closing Time, 5pm in UK",
                             timeZone: "GB", codeDict: code);
            Create_Cut_Label(hours: 9, minutes: 0, displayName: "SingaporeOpen", description: "", timeZone: "Singapore",
                             codeDict: code);
            Create_Cut_Label(hours: 17, minutes: 0, displayName: "SingaporeClose", description: "", timeZone: "Singapore",
                             codeDict: code);
            Create_Cut_Label(hours: 9, minutes: 0, displayName: "NYOpen", description: "", timeZone: "America/New_York",
                             codeDict: code);
            Create_Cut_Label(hours: 17, minutes: 0, displayName: "NYClose", description: "", timeZone: "America/New_York",
                             codeDict: code);

            // Create portfolio
            var scope = "cut_labels_demo";
            var portfolioCode = _testDataUtilities.CreateTransactionPortfolio(scope);

            // Get the instrument identifiers
            var instrument1 = _instrumentIds[0];
            var instrument2 = _instrumentIds[1];
            var instrument3 = _instrumentIds[2];

            var currency = "GBP";

            // set a currency LUID, as the call to GetHoldings returns the LUID not the identifier we are about to create
            var currencyLuid = $"CCY_{currency}";

            // Set initial holdings for each instrument from LondonOpen 5 days ago 
            var fiveDaysAgo = _currentDate.AddDays(-5);
            var initialHoldingsCutLabel = Cut_Label_Formatter(fiveDaysAgo, code["LondonOpen"]);
            var initialHoldings = new List<AdjustHoldingRequest> {
                // cash balance
                _testDataUtilities.BuildCashFundsInAdjustHoldingsRequest(
                    currency: currency,
                    units: (decimal)100000.0
                ),

                // instrument 1
                _testDataUtilities.BuildAdjustHoldingsRequst(
                    instrumentId: instrument1,
                    units: (decimal)100.0,
                    price: (decimal)101.0,
                    currency: currency,
                    tradeDate: null
                ),

                // instrument 2
                _testDataUtilities.BuildAdjustHoldingsRequst(
                    instrumentId: instrument2,
                    units: (decimal)100.0,
                    price: (decimal)102.0,
                    currency: currency,
                    tradeDate: null
                ),

                // instrument 3
                _testDataUtilities.BuildAdjustHoldingsRequst(
                    instrumentId: instrument1,
                    units: (decimal)100.0,
                    price: (decimal)99.0,
                    currency: currency,
                    tradeDate: null
                )
            };

            // add initial holdings to our portfolio from LondonOpen 5 days ago
            _transactionPortfoliosApi.SetHoldings(scope, portfolioCode, initialHoldingsCutLabel, initialHoldings);

            // Check initial holdings
            // get holdings at LondonOpen today, before transactions occur
            var getHoldingsCutLabel = Cut_Label_Formatter(_currentDate, code["LondonOpen"]);
            var holdings = _transactionPortfoliosApi.GetHoldings(
                scope: scope,
                code: portfolioCode,
                effectiveAt: getHoldingsCutLabel
            );

            // check that holdings are as expected before transactions occur for each instrument
            holdings.Values.Sort((h1, h2) => String.Compare(h1.InstrumentUid, h2.InstrumentUid, StringComparison.Ordinal));
            Assert.That(holdings.Values.Count, Is.EqualTo(4));
            _testDataUtilities.AssertCashHoldings(
                holdings: holdings,
                index: 0,
                instrumentId: currencyLuid,
                units: (decimal)100000.0
            );

            _testDataUtilities.AssertHoldings(
                holdings: holdings,
                index: 1,
                instrumentId: instrument1,
                units: (decimal)100.0,
                costAmount: (decimal)10100.0
            );

            _testDataUtilities.AssertHoldings(
                holdings: holdings,
                index: 2,
                instrumentId: instrument2,
                units: (decimal)100.0,
                costAmount: (decimal)10200.0
            );

            _testDataUtilities.AssertHoldings(
                holdings: holdings,
                index: 3,
                instrumentId: instrument3,
                units: (decimal)100.0,
                costAmount: (decimal)9900.0
            );

            // Add transactions at different times in different time zones during the day with cut labels
            var transaction1CutLabel = Cut_Label_Formatter(_currentDate, code["LondonOpen"]);
            var transaction2CutLabel = Cut_Label_Formatter(_currentDate, code["SingaporeClose"]);
            var transaction3CutLabel = Cut_Label_Formatter(_currentDate, code["NYOpen"]);
            var transaction4CutLabel = Cut_Label_Formatter(_currentDate, code["NYClose"]);
            var transactions = new List<TransactionRequest> {
                // Instrument 1
                _testDataUtilities.BuildTransactionRequest(
                    instrumentId: instrument1,
                    units: (decimal)100.0,
                    price: (decimal)100.0,
                    currency: currency,
                    tradeDate: transaction1CutLabel,
                    transactionType: "Buy"
                ),

                // Instrument 2
                _testDataUtilities.BuildTransactionRequest(
                    instrumentId: instrument2,
                    units: (decimal)100.0,
                    price: (decimal)100.0,
                    currency: currency,
                    tradeDate: transaction2CutLabel,
                    transactionType: "Buy"
                ),

                // Instrument 3
                _testDataUtilities.BuildTransactionRequest(
                    instrumentId: instrument3,
                    units: (decimal)100.0,
                    price: (decimal)100.0,
                    currency: currency,
                    tradeDate: transaction3CutLabel,
                    transactionType: "Buy"
                ),

                // Instrument 1 again
                _testDataUtilities.BuildTransactionRequest(
                    instrumentId: instrument1,
                    units: (decimal)100.0,
                    price: (decimal)100.0,
                    currency: currency,
                    tradeDate: transaction4CutLabel,
                    transactionType: "Buy"
                )
            };

            // Add transactions to the portfolio
            _transactionPortfoliosApi.UpsertTransactions(
                scope: scope,
                code: portfolioCode,
                transactionRequest: transactions
            );

            // Retrieve holdings at LondonClose today (5pm local time)
            // This will mean that the 4th transaction will not be included, demonstrating how cut labels work across time zones
            getHoldingsCutLabel = Cut_Label_Formatter(_currentDate, code["LondonClose"]);
            holdings = _transactionPortfoliosApi.GetHoldings(
                scope: scope,
                code: portfolioCode,
                effectiveAt: getHoldingsCutLabel
            );

            // check that holdings are as expected after transactions for each instrument
            holdings.Values.Sort((h1, h2) => String.Compare(h1.InstrumentUid, h2.InstrumentUid, StringComparison.Ordinal));
            Assert.That(holdings.Values.Count, Is.EqualTo(4));
            _testDataUtilities.AssertCashHoldings(
                holdings: holdings,
                index: 0,
                instrumentId: currencyLuid,
                units: (decimal)70000.0
            );

            _testDataUtilities.AssertHoldings(
                holdings: holdings,
                index: 1,
                instrumentId: instrument1,
                units: (decimal)200.0,
                costAmount: (decimal)20100.0
            );

            _testDataUtilities.AssertHoldings(
                holdings: holdings,
                index: 2,
                instrumentId: instrument2,
                units: (decimal)200.0,
                costAmount: (decimal)20200.0
            );

            _testDataUtilities.AssertHoldings(
                holdings: holdings,
                index: 3,
                instrumentId: instrument3,
                units: (decimal)200.0,
                costAmount: (decimal)19900.0
            );
        }

        private string Cut_Label_Formatter(DateTime date, string cutLabelCode)
        {
            return date.Date.ToString() + "N" + cutLabelCode;
        }

        private void Create_Cut_Label(int hours, int minutes, string displayName, string description, string timeZone, Dictionary<string, string> codeDict)
        {
            // Create the time for the cut label
            var time = new CutLocalTime(hours, minutes);

            // Define the parameters of the cut label in a request
            var request = new CreateCutLabelDefinitionRequest(
                code: displayName + "-" + Guid.NewGuid().ToString(),
                displayName: displayName,
                description: description,
                cutLocalTime: time,
                timeZone: timeZone
            );

            // Add the codes of our cut labels to our dictionary
            codeDict[request.DisplayName] = request.Code;

            // Send the request to LUSID to create the cut label
            var result = _apiFactory.Api<CutLabelDefinitionsApi>().CreateCutLabelDefinition(request);

            // Check that result gives same details as input
            Assert.That(result.DisplayName, Is.EqualTo(displayName));
            Assert.That(result.Description, Is.EqualTo(description));
            Assert.That(result.CutLocalTime, Is.EqualTo(time));
            Assert.That(result.TimeZone, Is.EqualTo(timeZone));
        }
    }
}