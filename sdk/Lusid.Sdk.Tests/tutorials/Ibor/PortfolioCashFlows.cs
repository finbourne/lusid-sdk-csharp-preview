using System;
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
    public class PortfolioCashFlows: TutorialBase
    {
        
        private static readonly string ValuationDateKey = "Analytic/default/ValuationDate";
        private static readonly string ValuationPv = "Valuation/PV/Amount";
        private static readonly string ValuationCcy = "Valuation/PV/Ccy";
        private static readonly string Luid = "Instrument/default/LusidInstrumentId";
        private static readonly string InstrumentName = "Instrument/default/Name";
        private static readonly string InstrumentTag = "Analytic/default/InstrumentTag";
        
        private static readonly List<AggregateSpec> ValuationSpec = new List<AggregateSpec>
        {
            new AggregateSpec(ValuationDateKey, AggregateSpec.OpEnum.Value),
            new AggregateSpec(ValuationPv, AggregateSpec.OpEnum.Value),
            new AggregateSpec(ValuationCcy, AggregateSpec.OpEnum.Value),
            new AggregateSpec(InstrumentName, AggregateSpec.OpEnum.Value),
            new AggregateSpec(InstrumentTag, AggregateSpec.OpEnum.Value),
            new AggregateSpec(Luid, AggregateSpec.OpEnum.Value)
        };

        internal DateTimeOffset _effectiveAt;
        internal string _portfolioCode;
        internal string _portfolioScope;
        [SetUp]
        public void SetUp()
        {
            _portfolioScope = TestDataUtilities.TutorialScope;
            _effectiveAt = new DateTimeOffset(2020, 2, 23, 0, 0, 0, TimeSpan.Zero);
            var portfolioRequest = TestDataUtilities.BuildTransactionPortfolioRequest();
            var portfolio = _transactionPortfoliosApi.CreatePortfolio(_portfolioScope, portfolioRequest);
            _portfolioCode = portfolioRequest.Code;

            Assert.That(portfolio?.Id.Code, Is.EqualTo(_portfolioCode));
        }

        [TearDown]
        public void TearDown()
        {
            _portfoliosApi.DeletePortfolio(_portfolioScope, _portfolioCode); 
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ExamplePortfolioCashFlowsForFxForwards(bool isNdf)
        {
            // CREATE portfolio
            //var portfolioScope = Guid.NewGuid().ToString();
            //var portfolioId = _testDataUtilities.CreateTransactionPortfolio(portfolioScope);
            // CREATE Fx Forward
            var fxForward = InstrumentExamples.CreateExampleFxForward(isNdf) as FxForward;
        
            // UPSERT Fx Forward to portfolio and populating stores with required market data
            AddInstrumentsTransactionPortfolioAndPopulateRequiredMarketData(
                _portfolioScope, 
                _portfolioCode,
                _effectiveAt,
                _effectiveAt,
                new List<LusidInstrument>(){fxForward});

            // CREATE and upsert CTVoM recipe specifying discount pricing model
            var modelRecipeCode = "CTVoMRecipe";
            CreateAndUpsertRecipe(modelRecipeCode, _portfolioScope, ModelSelection.ModelEnum.ConstantTimeValueOfMoney);

            // CALL api to get cashflows at maturity
            var maturity = fxForward.MaturityDate;
            var cashFlowsAtMaturity = _transactionPortfoliosApi.GetPortfolioCashFlows(
                _portfolioScope,
                _portfolioCode,
                _effectiveAt,
                maturity.AddMilliseconds(-1),
                maturity.AddMilliseconds(1),
                null,
                null,
                _portfolioScope,
                modelRecipeCode
                );
            
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
                    (fxForward.MaturityDate, -fxForward.FgnAmount, fxForward.FgnCcy),
                };
            Assert.That(cashFlows, Is.EquivalentTo(expectedCashFlows)); 
            
            _recipeApi.DeleteConfigurationRecipe(_portfolioScope, modelRecipeCode);
        }
        
        [Test]
        public void ExampleUpsertablePortfolioCashFlowsForBonds()
        {
            // CREATE portfolio
            //var portfolioScope = Guid.NewGuid().ToString();
            //var portfolioId = _testDataUtilities.CreateTransactionPortfolio(portfolioScope);

            // CREATE bond
            var bond = InstrumentExamples.CreateExampleBond() as Bond;
        
            // UPSERT bond to portfolio and populating stores with required market data
            AddInstrumentsTransactionPortfolioAndPopulateRequiredMarketData(
                _portfolioScope, 
                _portfolioCode,
                _effectiveAt,
                _effectiveAt,
                new List<LusidInstrument>(){bond});
            
            // CALL api to get upsertable cashflows at maturity            
            var maturity = bond.MaturityDate;
            var cashFlows = _transactionPortfoliosApi.GetUpsertablePortfolioCashFlows(
                _portfolioScope,
                _portfolioCode,
                maturity.AddMilliseconds(-1),
                maturity.AddMilliseconds(-1),
                maturity.AddMilliseconds(1));

            // CHECK correct number of cashflow at bond maturity: There are 2 cash flows corresponding to the last coupon amount and the principal.
            var expectedNumber = 2;
            Assert.That(cashFlows.Values.Count, Is.EqualTo(expectedNumber));
            
            // CHECK correct currency and amount of cashflows
            var currencyAndAmounts = cashFlows.Values.Select(t => t.TotalConsideration).ToList();
            var matchingCurrency = currencyAndAmounts.All(t => t.Currency == bond.DomCcy);
            var amountsPositive = currencyAndAmounts.All(t => t.Amount > 0);
            Assert.That(matchingCurrency, Is.True);
            Assert.That(amountsPositive, Is.True);
            
            // GIVEN the cashflow transactions, we create from them transaction requests and upsert them.
            var upsertCashFlowTransactions = PopulateCashFlowTransactionWithUniqueIds(cashFlows.Values, bond.DomCcy);
            _transactionPortfoliosApi.UpsertTransactions(_portfolioScope, _portfolioCode, MapToCashFlowTransactionRequest(upsertCashFlowTransactions));

            var expectedPortfolioTransactions = _transactionPortfoliosApi.GetTransactions(
                    _portfolioScope, 
                    _portfolioCode, 
                    maturity.AddMilliseconds(-1), 
                    maturity.AddMilliseconds(1), 
                    DateTimeOffset.Now)
                .Values;
            
            foreach (var transaction in upsertCashFlowTransactions)
            {
                var getExpectedTransactions = expectedPortfolioTransactions.FirstOrDefault(t => t.TransactionId == transaction.TransactionId);
                
                Assert.That(getExpectedTransactions, Is.Not.Null);
                Assert.That(getExpectedTransactions.InstrumentUid, Is.EqualTo($"CCY_USD"));
                Assert.That(getExpectedTransactions.TransactionCurrency, Is.EqualTo(transaction.TransactionCurrency));
                Assert.That(getExpectedTransactions.Type, Is.EqualTo(transaction.Type));
                Assert.That(getExpectedTransactions.Units, Is.EqualTo(transaction.Units));
            }

        }
        
        [TestCase(true)]
        [TestCase(false)]
        public void ExampleUpsertablePortfolioCashFlowsForFxForwards(bool isNdf)
        {
            // CREATE portfolio
            //var portfolioScope = Guid.NewGuid().ToString();
            //var portfolioId = _testDataUtilities.CreateTransactionPortfolio(portfolioScope);

            // CREATE Fx Forward
            var fxForward = InstrumentExamples.CreateExampleFxForward(isNdf) as FxForward;
        
            // UPSERT Fx Forward to portfolio and populating stores with required market data
            AddInstrumentsTransactionPortfolioAndPopulateRequiredMarketData(
                _portfolioScope, 
                _portfolioCode,
                _effectiveAt,
                _effectiveAt,
                new List<LusidInstrument>(){fxForward});

            // CREATE and upsert CTVoM recipe specifying discount pricing model
            var modelRecipeCode = "CTVoMRecipe";
            CreateAndUpsertRecipe(modelRecipeCode, _portfolioScope, ModelSelection.ModelEnum.ConstantTimeValueOfMoney);

            // CALL api to get upsertable cashflows at maturity            
            var maturity = fxForward.MaturityDate;
            var cashFlows = _transactionPortfoliosApi.GetUpsertablePortfolioCashFlows(
                _portfolioScope,
                _portfolioCode,
                _effectiveAt,
                maturity.AddMilliseconds(-1),
                maturity.AddMilliseconds(1),
                null,
                null,
                _portfolioScope,
                modelRecipeCode);

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
            
            // GIVEN the cashflow transactions, we create from them transaction requests and upsert them.
            var upsertCashFlowTransactions = PopulateCashFlowTransactionWithUniqueIds(cashFlows.Values, fxForward.DomCcy);
            _transactionPortfoliosApi.UpsertTransactions(_portfolioScope, _portfolioCode, MapToCashFlowTransactionRequest(upsertCashFlowTransactions));

            _recipeApi.DeleteConfigurationRecipe(_portfolioScope, modelRecipeCode);
        }
        
        [Test]
        public void LifeCycleManagementForFxForward()
        {
            // CREATE portfolio
            //var portfolioScope = Guid.NewGuid().ToString();
            // var portfolioId = _testDataUtilities.CreateTransactionPortfolio(portfolioScope);

            // CREATE FX Forward
            var fxForward = (FxForward) InstrumentExamples.CreateExampleFxForward(isNdf: false);
            
            // CREATE wide enough window to pick up all cashflows for the FX Forward
            var windowStart = fxForward.StartDate.AddMonths(-1);
            var windowEnd = fxForward.MaturityDate.AddMonths(1);
        
            // UPSERT FX Forward to portfolio and populating stores with required market data - use a constant FX rate USD/JPY = 150.
            var effectiveAt = windowStart;
            AddInstrumentsTransactionPortfolioAndPopulateRequiredMarketData(
                _portfolioScope, 
                _portfolioCode,
                windowStart,
                windowEnd,
                new List<LusidInstrument>(){fxForward},
                useConstantFxRate: true);

            // CREATE and upsert CTVoM recipe specifying discount pricing model
            var modelRecipeCode = "CTVoMRecipe";
            CreateAndUpsertRecipe(
                modelRecipeCode,
                _portfolioScope,
                ModelSelection.ModelEnum.ConstantTimeValueOfMoney,
                windowValuationOnInstrumentStartEnd: true);

            // GET all upsertable cashflows (transactions) for the FX Forward
            var allFxFwdCashFlows = _transactionPortfoliosApi.GetUpsertablePortfolioCashFlows(
                _portfolioScope,
                _portfolioCode,
                effectiveAt,
                windowStart,
                windowEnd,
                null,
                null,
                _portfolioScope,
                modelRecipeCode)
                .Values;

            // There are exactly two cashflows associated to FX forward (one in each currency) both at maturity.
            Assert.That(allFxFwdCashFlows.Count, Is.EqualTo(2));
            Assert.That(allFxFwdCashFlows.First().TotalConsideration.Currency, Is.EqualTo("USD"));
            Assert.That(allFxFwdCashFlows.Last().TotalConsideration.Currency, Is.EqualTo("JPY"));
            Assert.That(allFxFwdCashFlows.Select(c => c.TransactionDate).Distinct().Count(), Is.EqualTo(1));
            var cashFlowDate = allFxFwdCashFlows.First().TransactionDate;
            
            // CREATE valuation schedule 2 days before, day of and 2 days after the cashflows. 
            var valuationSchedule = new ValuationSchedule(
                effectiveAt: cashFlowDate.AddDays(2).ToString("o"),
                effectiveFrom: cashFlowDate.AddDays(-2).ToString("o"));
            
            // CREATE valuation request for this FX Forward portfolio,
            // where the valuation schedule covers before, at and after the expiration of the FX Forward. 
            var valuationRequest = new ValuationRequest(
                new ResourceId(_portfolioScope, modelRecipeCode),
                portfolioEntityIds: new List<PortfolioEntityId> {new PortfolioEntityId(_portfolioScope, _portfolioCode)},
                valuationSchedule: valuationSchedule,
                metrics: ValuationSpec,
                groupBy:  null,
                sort:  null,
                asAt: null,
                reportCurrency: "USD");
            
            // CALL GetValuation before upserting back the cashflows. We check that when the FX Forward has expired, the PV is zero.
            var valuationBeforeAndAfterExpirationOfFxForward = _aggregationApi.GetValuation(valuationRequest).Data;
            foreach (var valuationResult in valuationBeforeAndAfterExpirationOfFxForward)
            {
                var date = (DateTime) valuationResult[ValuationDateKey];
                var fxForwardPv = (double) valuationResult[ValuationPv];
                if (date < fxForward.MaturityDate)
                {
                    Assert.That(fxForwardPv, Is.Not.EqualTo(0).Within(1e-12));
                }
                else
                {
                    Assert.That(fxForwardPv, Is.EqualTo(0).Within(1e-12));
                }
            }

            // UPSERT the cashflows back into LUSID. We first populate the cashflow transactions with unique IDs.
            var upsertCashFlowTransactions = PopulateCashFlowTransactionWithUniqueIds(allFxFwdCashFlows, fxForward.DomCcy);
            _transactionPortfoliosApi.UpsertTransactions(_portfolioScope, _portfolioCode, MapToCashFlowTransactionRequest(upsertCashFlowTransactions));
            
            // HAVING upserted cashflow into lusid, we call GetValuation again.
            var valuationAfterUpsertingCashFlows = _aggregationApi.GetValuation(valuationRequest).Data;
            
            // ASSERT portfolio PV is constant across time by grouping the valuation result by date.
            // (constant because we upserted the cashflows back in with ConstantTimeValueOfMoney model and the FX rate is constant)
            // That is, we are checking instrument PV + cashflow PV = constant both before and after maturity  
            var resultsGroupedByDate = valuationAfterUpsertingCashFlows
                .GroupBy(d => (DateTime) d[ValuationDateKey]);
            
            // CONVERT and AGGREGATE all results to USD
            var pvsInUsd = resultsGroupedByDate
                .Select(pvGroup => pvGroup.Sum(record =>
                {
                    var fxRate = ((string) record[ValuationCcy]).Equals("JPY") ? 1m/150 : 1;
                    return Convert.ToDecimal(record[ValuationPv]) * fxRate;
                }));

            // ASSERT portfolio PV is constant over time within a tolerance
            var uniquePvsAcrossDates = pvsInUsd
                .Select(pv => Math.Round(pv, 12))
                .Distinct()
                .ToList();
            Assert.That(uniquePvsAcrossDates.Count, Is.EqualTo(1));
            
            // CLEAN up.
            _recipeApi.DeleteConfigurationRecipe(_portfolioScope, modelRecipeCode);
        }
        
        [Test]
        public void LifeCycleManagementForCashSettledEquityOption()
        {
            // CREATE portfolio
            //var portfolioScope = Guid.NewGuid().ToString();
            // var portfolioId = _testDataUtilities.CreateTransactionPortfolio(portfolioScope);

            // CREATE EquityOption
            var equityOption = (EquityOption) InstrumentExamples.CreateExampleEquityOption(isCashSettled: true);
            
            // CREATE wide enough window to pick up all cashflows associated to the EquityOption
            var windowStart = equityOption.StartDate.AddMonths(-1);
            var windowEnd = equityOption.OptionSettlementDate.AddMonths(1);
        
            // UPSERT EquityOption to portfolio and populating stores with required market data.
            var effectiveAt = equityOption.OptionSettlementDate;
            AddInstrumentsTransactionPortfolioAndPopulateRequiredMarketData(
                _portfolioScope, 
                _portfolioCode,
                windowStart,
                windowEnd,
                new List<LusidInstrument>(){equityOption});

            // CREATE and upsert CTVoM recipe specifying constant time value of money pricing model
            var modelRecipeCode = "CTVoMRecipe";
            CreateAndUpsertRecipe(
                modelRecipeCode,
                _portfolioScope,
                ModelSelection.ModelEnum.ConstantTimeValueOfMoney,
                windowValuationOnInstrumentStartEnd: true);

            // GET all upsertable cashflows (transactions) for the EquityOption
            var allEquityOptionCashFlows = _transactionPortfoliosApi.GetUpsertablePortfolioCashFlows(
                    _portfolioScope,
                    _portfolioCode,
                effectiveAt,
                windowStart,
                windowEnd,
                null,
                null,
                _portfolioScope,
                modelRecipeCode)
                .Values;

            // We expect exactly one cashflow associated to a cash settled EquityOption and it occurs at expiry.
            Assert.That(allEquityOptionCashFlows.Count, Is.EqualTo(1));
            Assert.That(allEquityOptionCashFlows.Last().TotalConsideration.Currency, Is.EqualTo("USD"));
            var cashFlowDate = allEquityOptionCashFlows.First().TransactionDate;
            
            // CREATE valuation schedule 2 days before, day of and 2 days after the cashflows. 
            var valuationSchedule = new ValuationSchedule(
                effectiveAt: cashFlowDate.AddDays(2).ToString("o"),
                effectiveFrom: cashFlowDate.AddDays(-2).ToString("o"));
            
            // CREATE valuation request for this portfolio consisting of the EquityOption,
            // where the valuation schedule covers before, at and after the expiration of the EquityOption. 
            var valuationRequest = new ValuationRequest(
                new ResourceId(_portfolioScope, modelRecipeCode),
                portfolioEntityIds: new List<PortfolioEntityId> {new PortfolioEntityId(_portfolioScope, _portfolioCode)},
                valuationSchedule: valuationSchedule,
                metrics: ValuationSpec,
                groupBy:  null,
                sort:  null,
                asAt: null,
                reportCurrency: "USD");
            
            // CALL GetValuation before upserting back the cashflows. We check
            // (1) there is no cash holdings in the portfolio prior to expiration
            // (2) that when the EquityOption has expired, the PV is zero.
            var valuationBeforeAndAfterExpirationEquityOption = _aggregationApi.GetValuation(valuationRequest).Data;
            var doesNotContainAnyCashBeforeExpiration = valuationBeforeAndAfterExpirationEquityOption
                .Select(d => (string) d[Luid])
                .All(luid => luid != $"CCY_{equityOption.DomCcy}");
            Assert.That(doesNotContainAnyCashBeforeExpiration, Is.True);
            foreach (var valuationResult in valuationBeforeAndAfterExpirationEquityOption)
            {
                var date = (DateTime) valuationResult[ValuationDateKey];
                var equityOptionPv = (double) valuationResult[ValuationPv];
                if (date < equityOption.OptionSettlementDate)
                {
                    Assert.That(equityOptionPv, Is.Not.EqualTo(0).Within(1e-12));
                }
                else
                {
                    Assert.That(equityOptionPv, Is.EqualTo(0).Within(1e-12));
                }
            }

            // UPSERT the cashflows back into LUSID. We first populate the cashflow transactions with unique IDs.
            var upsertCashFlowTransactions = PopulateCashFlowTransactionWithUniqueIds(allEquityOptionCashFlows, equityOption.DomCcy);
            var temp = _transactionPortfoliosApi.UpsertTransactions(_portfolioScope, _portfolioCode, MapToCashFlowTransactionRequest(upsertCashFlowTransactions));
            
            // HAVING upserted cashflow into lusid, we call GetValuation again.
            var valuationAfterUpsertingCashFlows = _aggregationApi.GetValuation(valuationRequest).Data;

            // ASSERT that we have some cash in the portfolio
            var containsCashAfterUpsertion = valuationAfterUpsertingCashFlows
                .Select(d => (string) d[Luid])
                .Any(luid => luid != $"CCY_{equityOption.DomCcy}");
            Assert.That(containsCashAfterUpsertion, Is.True);

            // ASSERT portfolio PV is constant across time  (since we upsert the cashflows back in) by grouping the valuation result by date.
            // That is instrument pv + cashflow = constant = option payoff
            var resultsGroupedByDate = valuationAfterUpsertingCashFlows
                .GroupBy(d => (DateTime) d[ValuationDateKey]);

            // ASSERT portfolio PV is constant over time
            var uniquePvsAcrossDates = resultsGroupedByDate
                .Select(pvGroup => pvGroup.Sum(record => (double) record[ValuationPv]))
                .Distinct()
                .ToList();
            Assert.That(uniquePvsAcrossDates.Count, Is.EqualTo(1));
    
            // CLEAN up.
            _recipeApi.DeleteConfigurationRecipe(_portfolioScope, modelRecipeCode);
        }
        
        // This method maps a list of Transactions to a list of TransactionRequests so that they can be upserted back into LUSID.
        private static List<TransactionRequest> MapToCashFlowTransactionRequest(IEnumerable<Transaction> transactions)
        {
            return transactions.Select(transaction => new TransactionRequest(
                transaction.TransactionId,
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
        
        // Given a transaction, this method creates a TransactionRequest so that it can be upserted back into LUSID.
        // InstrumentUid is additionally added to identify where the cashflow came from. The transaction ID needs to
        // be unique.
        private static IEnumerable<Transaction> PopulateCashFlowTransactionWithUniqueIds(IEnumerable<Transaction> transactions, string cashFlowCurrency)
        {
            foreach (var transaction in transactions)
            {
                transaction.InstrumentIdentifiers.Add("Instrument/default/Currency", cashFlowCurrency);
            }
            
            return transactions.Select((transaction , i) => new Transaction(
                transaction.TransactionId + $"{i}",
                transaction.Type,
                transaction.InstrumentIdentifiers,
                transaction.InstrumentUid,
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
            );
        }

       
    }
}
