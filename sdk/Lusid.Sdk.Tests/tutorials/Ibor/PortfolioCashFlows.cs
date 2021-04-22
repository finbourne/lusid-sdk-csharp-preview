﻿using System;
using System.Collections.Generic;
using System.Linq;
using Lusid.Sdk.Api;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using Lusid.Sdk.Utilities;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.tutorials.Ibor
{
    [TestFixture]
    public class PortfolioCashFlows
    {
        private ILusidApiFactory _apiFactory;
        private TestDataUtilities _testDataUtilities;
        private ITransactionPortfoliosApi _transactionPortfoliosApi;
        private IPortfoliosApi _portfoliosApi;

        [OneTimeSetUp]
        public void SetUp()
        {
            _apiFactory = LusidApiFactoryBuilder.Build("secrets.json"); ;
            _transactionPortfoliosApi = _apiFactory.Api<ITransactionPortfoliosApi>();
            _portfoliosApi = _apiFactory.Api<IPortfoliosApi>();
            _testDataUtilities = new TestDataUtilities(
                _apiFactory.Api<ITransactionPortfoliosApi>(),
                _apiFactory.Api<IInstrumentsApi>(),
                _apiFactory.Api<IQuotesApi>(),
                _apiFactory.Api<IStructuredMarketDataApi>());
        }
        
        [Test]
        public void ExamplePortfolioCashFlowsForBonds()
        {
            // CREATE portfolio
            var portfolioScope = Guid.NewGuid().ToString();
            var portfolioId = _testDataUtilities.CreateTransactionPortfolio(portfolioScope);

            // CREATE bond
            var bond = InstrumentExamples.CreateExampleBond() as Bond;
        
            // UPSERT bond to portfolio and populating stores with required market data
            var effectiveAt = new DateTimeOffset(2020, 2, 23, 0, 0, 0, TimeSpan.Zero);
            _testDataUtilities.AddInstrumentsTransactionPortfolioAndPopulateRequiredMarketData(
                portfolioScope, 
                portfolioId,
                effectiveAt,
                effectiveAt,
                bond);
            
            // CALL api to get cashflows at maturity
            var maturity = bond.MaturityDate.Value;
            var cashFlowsAtMaturity = _transactionPortfoliosApi.GetPortfolioCashFlows(
                portfolioScope,
                portfolioId,
                maturity.AddMilliseconds(-1),
                maturity.AddMilliseconds(1));
            
            // CHECK correct number of cashflow at maturity
            var expectedNumber = 2;
            Assert.That(cashFlowsAtMaturity.Values.Count, Is.EqualTo(expectedNumber));
            
            var cashFlows = cashFlowsAtMaturity.Values.Select(cf => cf)
                .Select(cf => (cf.PaymentDate, cf.Amount, cf.Currency))
                .ToList();
            
            // Check that expected cash flows at maturity are not 0
            var allCashFlowsPositive = cashFlows.All(cf => cf.Amount > 0);
            Assert.That(allCashFlowsPositive, Is.True);
            
            _portfoliosApi.DeletePortfolio(portfolioScope, portfolioId);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ExamplePortfolioCashFlowsForFxForwards(bool isNdf)
        {
            // CREATE portfolio
            var portfolioScope = Guid.NewGuid().ToString();
            var portfolioId = _testDataUtilities.CreateTransactionPortfolio(portfolioScope);

            // CREATE Fx Forward
            var fxForward = InstrumentExamples.CreateExampleFxForward(isNdf) as FxForward;
        
            // UPSERT Fx Forward to portfolio and populating stores with required market data
            var effectiveAt = new DateTimeOffset(2020, 2, 23, 0, 0, 0, TimeSpan.Zero);
            _testDataUtilities.AddInstrumentsTransactionPortfolioAndPopulateRequiredMarketData(
                portfolioScope, 
                portfolioId,
                effectiveAt,
                effectiveAt,
                fxForward);
            
            // CALL api to get cashflows at maturity
            var maturity = fxForward.MaturityDate.Value;
            var cashFlowsAtMaturity = _transactionPortfoliosApi.GetPortfolioCashFlows(
                portfolioScope,
                portfolioId,
                maturity.AddMilliseconds(-1),
                maturity.AddMilliseconds(1));
            
            // CHECK correct number of cashflow at maturity
            var expectedNumber = isNdf ? 1 : 2;
            Assert.That(cashFlowsAtMaturity.Values.Count, Is.EqualTo(expectedNumber));
            
            var cashFlows = cashFlowsAtMaturity.Values.Select(cf => cf)
                .Select(cf => (cf.PaymentDate, cf.Amount, cf.Currency))
                .ToList();

            var expectedCashFlows = isNdf
                ? new List<(DateTimeOffset? PaymentDate, decimal? Amount, string Currency)>
                {
                    (fxForward.MaturityDate, fxForward.DomAmount, fxForward.DomCcy)
                }
                : new List<(DateTimeOffset? PaymentDate, decimal? Amount, string Currency)> 
                {
                    (fxForward.MaturityDate, fxForward.DomAmount, fxForward.DomCcy),
                    (fxForward.MaturityDate, fxForward.FgnAmount, fxForward.FgnCcy),
                };
            Assert.That(cashFlows, Is.EquivalentTo(expectedCashFlows)); 
            
            _portfoliosApi.DeletePortfolio(portfolioScope, portfolioId);
        }
        
        [Test]
        public void ExampleUpsertablePortfolioCashFlowsFoBonds()
        {
            // CREATE portfolio
            var portfolioScope = Guid.NewGuid().ToString();
            var portfolioId = _testDataUtilities.CreateTransactionPortfolio(portfolioScope);

            // CREATE bond
            var bond = InstrumentExamples.CreateExampleBond() as Bond;
        
            // UPSERT bond to portfolio and populating stores with required market data
            var effectiveAt = new DateTimeOffset(2020, 2, 23, 0, 0, 0, TimeSpan.Zero);
            _testDataUtilities.AddInstrumentsTransactionPortfolioAndPopulateRequiredMarketData(
                portfolioScope, 
                portfolioId,
                effectiveAt,
                effectiveAt,
                bond);
            
            // CALL api to get upsertable cashflows at maturity            
            var maturity = bond.MaturityDate.Value;
            var cashFlows = _transactionPortfoliosApi.GetUpsertablePortfolioCashFlows(
                portfolioScope,
                portfolioId,
                maturity.AddMilliseconds(-1),
                maturity.AddMilliseconds(1));

            // CHECK correct number of cashflow at maturity
            var expectedNumber = 2;
            Assert.That(cashFlows.Values.Count, Is.EqualTo(expectedNumber));
            
            // CHECK correct currency and amount of cashflows
            var currencyAndAmounts = cashFlows.Values.Select(t => t.TotalConsideration).ToList();
            var currency = currencyAndAmounts.All(t => t.Currency == bond.DomCcy);
            var amountsPositive = currencyAndAmounts.All(t => t.Amount > 0);
            Assert.That(currency, Is.True);
            Assert.That(amountsPositive, Is.True);
            
            // Given the cashflow transactions, we create from them transaction requests and upsert them.
            var upsertCashFlowTransactions = cashFlows.Values;
            _transactionPortfoliosApi.UpsertTransactions(portfolioScope, portfolioId, CreateCashFlowTransactionRequest(upsertCashFlowTransactions));

            _portfoliosApi.DeletePortfolio(portfolioScope, portfolioId);
        }
        
        [TestCase(true)]
        [TestCase(false)]
        public void ExampleUpsertablePortfolioCashFlowsForFxForwards(bool isNdf)
        {
            // CREATE portfolio
            var portfolioScope = Guid.NewGuid().ToString();
            var portfolioId = _testDataUtilities.CreateTransactionPortfolio(portfolioScope);

            // CREATE Fx Forward
            var fxForward = InstrumentExamples.CreateExampleFxForward(isNdf) as FxForward;
        
            // UPSERT Fx Forward to portfolio and populating stores with required market data
            var effectiveAt = new DateTimeOffset(2020, 2, 23, 0, 0, 0, TimeSpan.Zero);
            _testDataUtilities.AddInstrumentsTransactionPortfolioAndPopulateRequiredMarketData(
                portfolioScope, 
                portfolioId,
                effectiveAt,
                effectiveAt,
                fxForward);
            
            // CALL api to get upsertable cashflows at maturity            
            var maturity = fxForward.MaturityDate.Value;
            var cashFlows = _transactionPortfoliosApi.GetUpsertablePortfolioCashFlows(
                portfolioScope,
                portfolioId,
                maturity.AddMilliseconds(-1),
                maturity.AddMilliseconds(1));

            // CHECK correct number of cashflow at maturity
            var expectedNumber = isNdf ? 1 : 2;
            Assert.That(cashFlows.Values.Count, Is.EqualTo(expectedNumber));
            var currencyAndAmounts = cashFlows.Values.Select(t => t.TotalConsideration).ToList();

            var expectedCashFlows = isNdf
                ? new List<CurrencyAndAmount>
                    {
                        new CurrencyAndAmount(fxForward.DomAmount, fxForward.DomCcy)
                    }
                : new List<CurrencyAndAmount> 
                    {
                        new CurrencyAndAmount(fxForward.DomAmount, fxForward.DomCcy),
                        new CurrencyAndAmount(fxForward.FgnAmount, fxForward.FgnCcy)
                    };

            Assert.That(currencyAndAmounts, Is.EquivalentTo(expectedCashFlows)); 
            
            // Given the cashflow transactions, we create from them transaction requests and upsert them.
            var upsertCashFlowTransactions = cashFlows.Values;
            _transactionPortfoliosApi.UpsertTransactions(portfolioScope, portfolioId, CreateCashFlowTransactionRequest(upsertCashFlowTransactions));

            _portfoliosApi.DeletePortfolio(portfolioScope, portfolioId);
        }
        
        // Given a transaction, this method creates a TransactionRequest so that it can be upserted back into LUSID.
        // InstrumentUid is additionally added to identify where the cashflow came from.
        private static List<TransactionRequest> CreateCashFlowTransactionRequest(IEnumerable<Transaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                transaction.InstrumentIdentifiers.Add("Instrument/default/ClientInternal", transaction.InstrumentUid);
            }
            
            return transactions.Select((transaction , i) => new TransactionRequest(
                transaction.TransactionId + $"{i}",
                transaction.Type,
                transaction.InstrumentIdentifiers,
                transaction.TransactionDate,
                transaction.SettlementDate,
                transaction.Units,
                transaction.TransactionPrice,
                transaction.TotalConsideration,
                transaction.ExchangeRate,
                transaction.TransactionCurrency,
                transaction.Properties,
                transaction.CounterpartyId,
                transaction.Source)
            ).ToList();
        }
    }
}
