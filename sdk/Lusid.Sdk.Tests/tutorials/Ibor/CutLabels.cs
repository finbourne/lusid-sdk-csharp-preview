﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        private ICutLabelDefinitionsApi _cutLabelDefinitionsApi;
        private ITransactionPortfoliosApi _transactionPortfoliosApi;
        private IPortfoliosApi _portfoliosApi;
        private TestDataUtilities _testDataUtilities;
        private IList<string> _instrumentIds;
        private string _portfolioCode;

        private readonly DateTime _currentDate = DateTime.Now.Date;

        private const string TutorialScope = "cut_labels_demo";
        private const string CutLabelTutorialSuffix = "_Demo_Only";

        private const string Currency = "GBP";

        [OneTimeSetUp]
        public void SetUp()
        {
            _apiFactory = TestLusidApiFactoryBuilder.CreateApiFactory("secrets.json");

            _instrumentLoader = new InstrumentLoader(_apiFactory);
            _instrumentIds = _instrumentLoader.LoadInstruments();

            _cutLabelDefinitionsApi = _apiFactory.Api<CutLabelDefinitionsApi>();
            _transactionPortfoliosApi = _apiFactory.Api<ITransactionPortfoliosApi>();
            _portfoliosApi = _apiFactory.Api<IPortfoliosApi>();
            _testDataUtilities = new TestDataUtilities(_transactionPortfoliosApi);

            // Create portfolio for the demo
            _portfolioCode = _testDataUtilities.CreateTransactionPortfolio(TutorialScope);

            // Clear up old labels from previous demos
            ClearCutLabels();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            // Clean up the demo portfolio
            _portfoliosApi.DeletePortfolio(TutorialScope, _portfolioCode);

            // Clear up labels created by the demo
            ClearCutLabels();
        }

        [LusidFeature("F32")]
        [Test]
        public void Cut_Labels()
        {
            // Create storage for cut labels
            var code = new Dictionary<string, string>();

            // Create cut labels for different time zones
            CreateCutLabel(hours: 9, minutes: 0, displayName: "LDNOpen", description: "London Opening Time, 9am in UK",
                             timeZone: "GB", codeDict: code);
            CreateCutLabel(hours: 17, minutes: 0, displayName: "LDNClose", description: "London Closing Time, 5pm in UK",
                             timeZone: "GB", codeDict: code);
            CreateCutLabel(hours: 9, minutes: 0, displayName: "SGPOpen", description: "Singapore Opening Time, 2am in UK",
                            timeZone: "Singapore", codeDict: code);
            CreateCutLabel(hours: 17, minutes: 0, displayName: "SGPClose", description: "Singapore Closing Time, 10am in UK",
                            timeZone: "Singapore", codeDict: code);
            CreateCutLabel(hours: 9, minutes: 0, displayName: "NYOpen", description: "New York Opening Time, 2pm in UK",
                            timeZone: "America/New_York", codeDict: code);
            CreateCutLabel(hours: 17, minutes: 0, displayName: "NYClose", description: "New York Closing Time, 10pm in UK",
                            timeZone: "America/New_York", codeDict: code);

            // Get the instrument identifiers
            var instrument1 = _instrumentIds[0];
            var instrument2 = _instrumentIds[1];
            var instrument3 = _instrumentIds[2];

            // set a currency LUID, as the call to GetHoldings returns the LUID not the identifier we are about to create
            var currencyLuid = $"CCY_{Currency}";

            // Set initial holdings for each instrument from LDNOpen 5 days ago 
            var fiveDaysAgo = _currentDate.AddDays(-5);
            var LdnOpenHoldingsCutLabel = CutLabelFormatter(fiveDaysAgo, code["LDNOpen"]);
            var LdnOpenHoldings = new List<AdjustHoldingRequest> {
                // cash balance
                _testDataUtilities.BuildCashFundsInAdjustHoldingsRequest(
                    currency: Currency,
                    units: (decimal)100000.0
                ),

                // instrument 1
                _testDataUtilities.BuildAdjustHoldingsRequst(
                    instrumentId: instrument1,
                    units: (decimal)100.0,
                    price: (decimal)101.0,
                    currency: Currency,
                    tradeDate: null
                ),

                // instrument 2
                _testDataUtilities.BuildAdjustHoldingsRequst(
                    instrumentId: instrument2,
                    units: (decimal)100.0,
                    price: (decimal)102.0,
                    currency: Currency,
                    tradeDate: null
                ),

                // instrument 3
                _testDataUtilities.BuildAdjustHoldingsRequst(
                    instrumentId: instrument3,
                    units: (decimal)100.0,
                    price: (decimal)99.0,
                    currency: Currency,
                    tradeDate: null
                )
            };

            // add initial holdings to our portfolio from LDNOpen 5 days ago
            _transactionPortfoliosApi.SetHoldings(TutorialScope, _portfolioCode, LdnOpenHoldingsCutLabel, LdnOpenHoldings);

            var expectedLdnOpenCashHoldings = _testDataUtilities.BuildCashPortfolioHolding(Currency, currencyLuid, (decimal)100000.0);
            var expectedLdnOpenInstrument1Holdings = _testDataUtilities.BuildPortfolioHolding(Currency, instrument1, (decimal)100.0, (decimal)10100.0);
            var expectedLdnOpenInstrument2Holdings = _testDataUtilities.BuildPortfolioHolding(Currency, instrument2, (decimal)100.0, (decimal)10200.0);
            var expectedLdnOpenInstrument3Holdings = _testDataUtilities.BuildPortfolioHolding(Currency, instrument3, (decimal)100.0, (decimal)9900.0);

            // Retrieve holdings at LDNOpen today (9am local time)
            var getHoldingsCutLabel = CutLabelFormatter(_currentDate, code["LDNOpen"]);
            AssertHoldingsAtCutLabel(
                getHoldingsCutLabel,
                new List<PortfolioHolding>
                {
                    expectedLdnOpenCashHoldings,
                    expectedLdnOpenInstrument1Holdings,
                    expectedLdnOpenInstrument2Holdings,
                    expectedLdnOpenInstrument3Holdings
                }
            );

            // Add transactions at different times in different time zones during the day with cut labels
            var transaction1CutLabel = CutLabelFormatter(_currentDate, code["LDNOpen"]);
            var transaction2CutLabel = CutLabelFormatter(_currentDate, code["SGPClose"]);
            var transaction3CutLabel = CutLabelFormatter(_currentDate, code["NYOpen"]);
            var transaction4CutLabel = CutLabelFormatter(_currentDate, code["NYClose"]);
            var transactions = new List<TransactionRequest> {
                // Instrument 1
                _testDataUtilities.BuildTransactionRequest(
                    instrumentId: instrument1,
                    units: (decimal)100.0,
                    price: (decimal)100.0,
                    currency: Currency,
                    tradeDate: transaction1CutLabel,
                    transactionType: "Buy"
                ),

                // Instrument 2
                _testDataUtilities.BuildTransactionRequest(
                    instrumentId: instrument2,
                    units: (decimal)100.0,
                    price: (decimal)100.0,
                    currency: Currency,
                    tradeDate: transaction2CutLabel,
                    transactionType: "Buy"
                ),

                // Instrument 3
                _testDataUtilities.BuildTransactionRequest(
                    instrumentId: instrument3,
                    units: (decimal)100.0,
                    price: (decimal)100.0,
                    currency: Currency,
                    tradeDate: transaction3CutLabel,
                    transactionType: "Buy"
                ),

                // Instrument 1 again
                _testDataUtilities.BuildTransactionRequest(
                    instrumentId: instrument1,
                    units: (decimal)100.0,
                    price: (decimal)100.0,
                    currency: Currency,
                    tradeDate: transaction4CutLabel,
                    transactionType: "Buy"
                )
            };

            // Add transactions to the portfolio
            _transactionPortfoliosApi.UpsertTransactions(
                scope: TutorialScope,
                code: _portfolioCode,
                transactionRequest: transactions
            );

            var expectedLdnCloseCashHoldings = _testDataUtilities.BuildCashPortfolioHolding(Currency, currencyLuid, (decimal)70000.0);
            var expectedLdnCloseInstrument1Holdings = _testDataUtilities.BuildPortfolioHolding(Currency, instrument1, (decimal)200.0, (decimal)20100.0);
            var expectedLdnCloseInstrument2Holdings = _testDataUtilities.BuildPortfolioHolding(Currency, instrument2, (decimal)200.0, (decimal)20200.0);
            var expectedLdnCloseInstrument3Holdings = _testDataUtilities.BuildPortfolioHolding(Currency, instrument3, (decimal)200.0, (decimal)19900.0);

            // Retrieve holdings at LDNOpen today now that we have added a transaction (9am local time)
            getHoldingsCutLabel = CutLabelFormatter(_currentDate, code["LDNOpen"]);
            AssertHoldingsAtCutLabel(
                getHoldingsCutLabel,
                new List<PortfolioHolding>
                {
                    _testDataUtilities.BuildCashPortfolioHolding(Currency, currencyLuid, (decimal)90000.0),
                    expectedLdnCloseInstrument1Holdings,
                    expectedLdnOpenInstrument2Holdings,
                    expectedLdnOpenInstrument3Holdings,
                }
            );

            // Retrieve holdings at SGPClose today (10am local time)
            getHoldingsCutLabel = CutLabelFormatter(_currentDate, code["SGPClose"]);
            AssertHoldingsAtCutLabel(
                getHoldingsCutLabel,
                new List<PortfolioHolding>
                {
                    _testDataUtilities.BuildCashPortfolioHolding(Currency, currencyLuid, (decimal)80000.0),
                    expectedLdnCloseInstrument1Holdings,
                    expectedLdnCloseInstrument2Holdings,
                    expectedLdnOpenInstrument3Holdings,
                }
            );

            // Retrieve holdings at NYOpen today (2pm local time)
            getHoldingsCutLabel = CutLabelFormatter(_currentDate, code["NYOpen"]);
            AssertHoldingsAtCutLabel(
                getHoldingsCutLabel,
                new List<PortfolioHolding>
                {
                    expectedLdnCloseCashHoldings,
                    expectedLdnCloseInstrument1Holdings,
                    expectedLdnCloseInstrument2Holdings,
                    expectedLdnCloseInstrument3Holdings,
                }
            );

            // Retrieve holdings at LDNClose today (5pm local time)
            // This will mean that the 4th transaction will not be included, demonstrating how cut labels work across time zones
            getHoldingsCutLabel = CutLabelFormatter(_currentDate, code["LDNClose"]);
            AssertHoldingsAtCutLabel(
                getHoldingsCutLabel,
                new List<PortfolioHolding>
                {
                    expectedLdnCloseCashHoldings,
                    expectedLdnCloseInstrument1Holdings,
                    expectedLdnCloseInstrument2Holdings,
                    expectedLdnCloseInstrument3Holdings,
                }
            );
        }

        private void AssertHoldingsAtCutLabel(
           string getHoldingsCutLabel,
           List<PortfolioHolding> expectedHoldings)
        {
            // check that holdings are as expected after transactions for each instrument
            var holdings = _transactionPortfoliosApi.GetHoldings(
                scope: TutorialScope,
                code: _portfolioCode,
                effectiveAt: getHoldingsCutLabel
            );

            // check that holdings are as expected after transactions for each instrument
            holdings.Values.Sort((h1, h2) => string.Compare(h1.InstrumentUid, h2.InstrumentUid, StringComparison.Ordinal));
            expectedHoldings.Sort((h1, h2) => string.Compare(h1.InstrumentUid, h2.InstrumentUid, StringComparison.Ordinal));

            Assert.That(holdings.Values.Count, Is.EqualTo(expectedHoldings.Count));

            for (var index = 0; index < holdings.Values.Count; index++)
            {
                Assert.That(holdings.Values[index].Cost.Amount, Is.EqualTo(expectedHoldings[index].Cost.Amount));
                Assert.That(holdings.Values[index].Cost.Currency, Is.EqualTo(expectedHoldings[index].Cost.Currency));
                Assert.That(holdings.Values[index].Currency, Is.EqualTo(expectedHoldings[index].Currency));
                Assert.That(holdings.Values[index].HoldingType, Is.EqualTo(expectedHoldings[index].HoldingType));
                Assert.That(holdings.Values[index].InstrumentUid, Is.EqualTo(expectedHoldings[index].InstrumentUid));
                Assert.That(holdings.Values[index].SettledUnits, Is.EqualTo(expectedHoldings[index].SettledUnits));
                Assert.That(holdings.Values[index].Units, Is.EqualTo(expectedHoldings[index].Units));
            }
        }

        private void CreateCutLabel(int hours, int minutes, string displayName, string description, string timeZone, Dictionary<string, string> codeDict)
        {
            // Create the time for the cut label
            var time = new CutLocalTime(hours, minutes);

            // Define the parameters of the cut label in a request
            var request = new CreateCutLabelDefinitionRequest(
                code: displayName + CutLabelTutorialSuffix,
                displayName: displayName,
                description: description,
                cutLocalTime: time,
                timeZone: timeZone
            );

            // Add the codes of our cut labels to our dictionary
            codeDict[request.DisplayName] = request.Code;

            // Send the request to LUSID to create the cut label, if it doesn't already
            var result = _cutLabelDefinitionsApi.CreateCutLabelDefinition(request);

            // Check that result gives same details as input
            Assert.That(result.DisplayName, Is.EqualTo(displayName));
            Assert.That(result.Description, Is.EqualTo(description));
            Assert.That(result.CutLocalTime, Is.EqualTo(time));
            Assert.That(result.TimeZone, Is.EqualTo(timeZone));
        }

        private void ClearCutLabels()
        {
            var demoLabels = _cutLabelDefinitionsApi.ListCutLabelDefinitions().Values
                .Where(x => x.Code.EndsWith(CutLabelTutorialSuffix));

            foreach (var label in demoLabels)
            {
                _cutLabelDefinitionsApi.DeleteCutLabelDefinition(label.Code);
            }
        }

        private string CutLabelFormatter(DateTime date, string cutLabelCode)
        {
            return $"{date:yyyy-MM-dd}N{cutLabelCode}";
        }
    }
}