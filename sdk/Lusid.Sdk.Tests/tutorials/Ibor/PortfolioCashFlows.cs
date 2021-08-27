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
    public class PortfolioCashFlows
    {
        private ILusidApiFactory _apiFactory;
        private TestDataUtilities _testDataUtilities;
        private ITransactionPortfoliosApi _transactionPortfoliosApi;
        private IPortfoliosApi _portfoliosApi;
        private IConfigurationRecipeApi _recipeApi;
        private IAggregationApi _aggregationApi;
        
        private static readonly string ValuationDateKey = "Analytic/default/ValuationDate";
        private static readonly string ValuationPv = "Valuation/PV/Amount";
        private static readonly string InstrumentName = "Instrument/default/Name";
        private static readonly string InstrumentTag = "Analytic/default/InstrumentTag";
        
        private static readonly List<AggregateSpec> ValuationSpec = new List<AggregateSpec>
        {
            new AggregateSpec(ValuationDateKey, AggregateSpec.OpEnum.Value),
            new AggregateSpec(ValuationPv, AggregateSpec.OpEnum.Value),
            new AggregateSpec(InstrumentName, AggregateSpec.OpEnum.Value),
            new AggregateSpec(InstrumentTag, AggregateSpec.OpEnum.Value)
        };

        [OneTimeSetUp]
        public void SetUp()
        {
            _apiFactory = TestLusidApiFactoryBuilder.CreateApiFactory("secrets.json");
            _transactionPortfoliosApi = _apiFactory.Api<ITransactionPortfoliosApi>();
            _portfoliosApi = _apiFactory.Api<IPortfoliosApi>();
            _recipeApi = _apiFactory.Api<IConfigurationRecipeApi>();
            _aggregationApi = _apiFactory.Api<IAggregationApi>();
            _testDataUtilities = new TestDataUtilities(
                _apiFactory.Api<ITransactionPortfoliosApi>(),
                _apiFactory.Api<IInstrumentsApi>(),
                _apiFactory.Api<IQuotesApi>(),
                _apiFactory.Api<IComplexMarketDataApi>());
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
            var maturity = bond.MaturityDate;
            var cashFlowsAtMaturity = _transactionPortfoliosApi.GetPortfolioCashFlows(
                portfolioScope,
                portfolioId,
                maturity.AddMilliseconds(-1),
                maturity.AddMilliseconds(-1),
                maturity.AddMilliseconds(1));
            
            // CHECK correct number of cashflow at bond maturity: There are 2 cash flows corresponding to the last coupon amount and the principal.
            var expectedNumber = 2;
            Assert.That(cashFlowsAtMaturity.Values.Count, Is.EqualTo(expectedNumber));
            
            var cashFlows = cashFlowsAtMaturity.Values.Select(cf => cf)
                .Select(cf => (cf.PaymentDate, cf.Amount, cf.Currency))
                .ToList();
            
            // CHECK that expected cash flows at maturity are not 0.
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

            // CREATE and upsert CTVoM recipe specifying discount pricing model
            var modelRecipeCode = "CTVoMRecipe";
            CreateAndUpsertRecipe(modelRecipeCode, portfolioScope, ModelSelection.ModelEnum.ConstantTimeValueOfMoney);

            // CALL api to get cashflows at maturity
            var maturity = fxForward.MaturityDate;
            var cashFlowsAtMaturity = _transactionPortfoliosApi.GetPortfolioCashFlows(
                portfolioScope,
                portfolioId,
                effectiveAt,
                maturity.AddMilliseconds(-1),
                maturity.AddMilliseconds(1),
                null,
                null,
                portfolioScope,
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
                    (fxForward.MaturityDate, fxForward.FgnAmount, fxForward.FgnCcy),
                };
            Assert.That(cashFlows, Is.EquivalentTo(expectedCashFlows)); 
            
            _portfoliosApi.DeletePortfolio(portfolioScope, portfolioId);
            _recipeApi.DeleteConfigurationRecipe(portfolioScope, modelRecipeCode);
        }
        
        [Test]
        public void ExampleUpsertablePortfolioCashFlowsForBonds()
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
            var maturity = bond.MaturityDate;
            var cashFlows = _transactionPortfoliosApi.GetUpsertablePortfolioCashFlows(
                portfolioScope,
                portfolioId,
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
            _transactionPortfoliosApi.UpsertTransactions(portfolioScope, portfolioId, MapToCashFlowTransactionRequest(upsertCashFlowTransactions));

            var expectedPortfolioTransactions = _transactionPortfoliosApi.GetTransactions(
                    portfolioScope, 
                    portfolioId, 
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

            // CREATE and upsert CTVoM recipe specifying discount pricing model
            var modelRecipeCode = "CTVoMRecipe";
            CreateAndUpsertRecipe(modelRecipeCode, portfolioScope, ModelSelection.ModelEnum.ConstantTimeValueOfMoney);

            // CALL api to get upsertable cashflows at maturity            
            var maturity = fxForward.MaturityDate;
            var cashFlows = _transactionPortfoliosApi.GetUpsertablePortfolioCashFlows(
                portfolioScope,
                portfolioId,
                effectiveAt,
                maturity.AddMilliseconds(-1),
                maturity.AddMilliseconds(1),
                null,
                null,
                portfolioScope,
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
            _transactionPortfoliosApi.UpsertTransactions(portfolioScope, portfolioId, MapToCashFlowTransactionRequest(upsertCashFlowTransactions));

            _portfoliosApi.DeletePortfolio(portfolioScope, portfolioId);
            _recipeApi.DeleteConfigurationRecipe(portfolioScope, modelRecipeCode);
        }
        
        [Test]
        public void LifeCycleManagementForFxForward()
        {
            // CREATE portfolio
            var portfolioScope = Guid.NewGuid().ToString();
            var portfolioId = _testDataUtilities.CreateTransactionPortfolio(portfolioScope);

            // CREATE FX Forward
            var fxForward = InstrumentExamples.CreateExampleFxForward(isNdf: false) as FxForward;
            
            // CREATE wide enough window to pick up all cashflows for the FX Forward
            var windowStart = fxForward?.StartDate.Value.AddMonths(-1);
            var windowEnd = fxForward?.MaturityDate.Value.AddMonths(1);
        
            // UPSERT FX Forward to portfolio and populating stores with required market data
            var effectiveAt = windowStart.Value;
            _testDataUtilities.AddInstrumentsTransactionPortfolioAndPopulateRequiredMarketData(
                portfolioScope, 
                portfolioId,
                windowStart.Value,
                windowEnd.Value,
                fxForward);

            // CREATE and upsert CTVoM recipe specifying discount pricing model
            var modelRecipeCode = "CTVoMRecipe";
            CreateAndUpsertRecipe(
                modelRecipeCode,
                portfolioScope,
                ModelSelection.ModelEnum.ConstantTimeValueOfMoney,
                windowValuationOnInstrumentStartEnd: true);

            // GET all upsertable cashflows for the FX Forward
            var allFxFwdCashFlows = _transactionPortfoliosApi.GetUpsertablePortfolioCashFlows(
                portfolioScope,
                portfolioId,
                effectiveAt,
                windowStart,
                windowEnd,
                null,
                null,
                portfolioScope,
                modelRecipeCode)
                .Values;

            // There are exactly two cashflows associated to FX forward (one in each currency) both at maturity.
            Assert.That(allFxFwdCashFlows.Count, Is.EqualTo(2));
            Assert.That(allFxFwdCashFlows.Select(c => c.TransactionDate.Value).Distinct().Count(), Is.EqualTo(1));
            var cashFlowDate = allFxFwdCashFlows.First().TransactionDate.Value;
            
            // CREATE valuation schedule 2 days before, day of and 2 days after cashflow amount. 
            var valuationSchedule = new ValuationSchedule(
                effectiveAt: cashFlowDate.AddDays(2).ToString("o"),
                effectiveFrom: cashFlowDate.AddDays(-2).ToString("o"));
            
            // CREATE valuation request for this FX Forward portfolio.
            var valuationRequest = new ValuationRequest(
                new ResourceId(portfolioScope, modelRecipeCode),
                portfolioEntityIds: new List<PortfolioEntityId> {new PortfolioEntityId(portfolioScope, portfolioId)},
                valuationSchedule: valuationSchedule,
                metrics: ValuationSpec,
                groupBy:  null,
                sort:  null,
                asAt: null,
                reportCurrency: "USD");
            
            // CALL GetValuation and check that when the FX Forward has matured, the PV is zero.
            var valuationBeforeAndAfterExpirationOfFxForward = _aggregationApi.GetValuation(valuationRequest).Data;
            foreach (var valuationResult in valuationBeforeAndAfterExpirationOfFxForward)
            {
                var date = (DateTimeOffset) valuationResult[ValuationDateKey];
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
            _transactionPortfoliosApi.UpsertTransactions(portfolioScope, portfolioId, MapToCashFlowTransactionRequest(upsertCashFlowTransactions));
            
            // CALL GetValuation after upserting cashflow into lusid
            // There are 5 evaluation dates = 2 days before maturity, at maturity and 2 days after. 
            // So 5 evaluation dates/entries for instrument.
            // At maturity and the 2 days after (so 3 days), there is one cash holding per currency so 6.
            // Hence we expect 11 data records.
            var valuationAfterUpsertingCashFlows = _aggregationApi.GetValuation(valuationRequest).Data;
            Assert.That(valuationAfterUpsertingCashFlows.Count(), Is.EqualTo(11));
            
            // ASSERT portfolio PV is constant across time (since we upsert the cashflows back in with ConstantTimeValueOfMoney model)
            // That is, we are checking instrument pv + cashflow pv = constant both before and after maturity  
            var resultsGroupedByDate = valuationAfterUpsertingCashFlows
                .GroupBy(d => (DateTimeOffset) d[ValuationDateKey]);
            var uniquePvsAcrossDates = resultsGroupedByDate 
                .Select(pvGroup => pvGroup.Sum(record => (decimal) record[ValuationPv]))
                .Distinct()
                .ToList();
            Assert.That(uniquePvsAcrossDates.Count, Is.EqualTo(1));
            
            // CLEAN up.
            _portfoliosApi.DeletePortfolio(portfolioScope, portfolioId);
            _recipeApi.DeleteConfigurationRecipe(portfolioScope, modelRecipeCode);
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

        private void CreateAndUpsertRecipe(string code, string scope, ModelSelection.ModelEnum model, bool windowValuationOnInstrumentStartEnd = false)
        {
            // CREATE recipe for pricing
            var pricingOptions = new PricingOptions(new ModelSelection(ModelSelection.LibraryEnum.Lusid, model));
            pricingOptions.WindowValuationOnInstrumentStartEnd = windowValuationOnInstrumentStartEnd;
            var recipe = new ConfigurationRecipe(
                scope,
                code,
                market: new MarketContext(options: new MarketOptions(defaultScope: scope)),
                pricing: new PricingContext(options: pricingOptions),
                description: $"Recipe for {model} pricing");

            UpsertRecipe(recipe);
        }

        private void UpsertRecipe(ConfigurationRecipe recipe)
        {
            // UPSERT recipe and check upsert was successful
            var upsertRecipeRequest = new UpsertRecipeRequest(recipe);
            var response = _recipeApi.UpsertConfigurationRecipe(upsertRecipeRequest);
            Assert.That(response.Value, Is.Not.Null);
        }
    }
}
