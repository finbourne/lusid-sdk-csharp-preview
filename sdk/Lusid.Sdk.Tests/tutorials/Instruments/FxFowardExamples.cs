using System;
using System.Collections.Generic;
using System.Linq;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.tutorials.Ibor;
using Lusid.Sdk.Tests.Utilities;
using LusidFeatures;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Tutorials.Instruments
{
    [TestFixture]
    public class FxFowardExamples: DemoInstrumentBase
    {
        internal override void CreateAndUpsertMarketDataToLusid(string scope, ModelSelection.ModelEnum model, LusidInstrument instrument)
        {
            // POPULATE with required market data for valuation of the instruments
            var upsertFxRateRequestReq = TestDataUtilities.BuildFxRateRequest(scope, TestDataUtilities.EffectiveAt);
            var upsertQuoteResponse = _quotesApi.UpsertQuotes(scope, upsertFxRateRequestReq);
            ValidateQuoteUpsert(upsertQuoteResponse, upsertFxRateRequestReq.Count);

            if (model == ModelSelection.ModelEnum.Discounting)
            {
                var upsertComplexMarketDataRequest =  TestDataUtilities.BuildRateCurvesRequests(TestDataUtilities.EffectiveAt);
                var upsertComplexMarketDataResponse = _complexMarketDataApi.UpsertComplexMarketData(scope, upsertComplexMarketDataRequest);
                ValidateComplexMarketDataUpsert(upsertComplexMarketDataResponse, upsertComplexMarketDataRequest.Count);
            }
        }

        internal override void GetAndValidatePortfolioCashFlows(LusidInstrument instrument, string scope, string portfolioCode, string recipeCode, string instrumentID)
        {
            var fxForward = (FxForward) instrument;
            var cashflows = _transactionPortfoliosApi.GetPortfolioCashFlows(
                scope: scope,
                code: portfolioCode,
                effectiveAt: TestDataUtilities.EffectiveAt,
                windowStart: new DateTimeOrCutLabel(new DateTimeOffset(2000, 01, 01, 01, 0, 0, 0, TimeSpan.Zero)),
                windowEnd: new DateTimeOrCutLabel(new DateTimeOffset(2050, 01, 01, 01, 0, 0, 0, TimeSpan.Zero)),
                asAt:null,
                filter:null,
                recipeIdScope: scope,
                recipeIdCode: recipeCode).Values;
            
            Assert.That(cashflows.Count, Is.EqualTo(fxForward.IsNdf ? 1 : 2)); // deliverable FxForward has 2 cashflows while non-delivered has 1.
            
            _instrumentsApi.DeleteInstrument("ClientInternal", instrumentID);
            _portfoliosApi.DeletePortfolio(scope, portfolioCode);
        }

        [LusidFeature("F22-1")]
        [Test]
        public void FxForwardCreationAndUpsertionExample()
        {
            // CREATE an FxForward instrument (that can then be upserted into LUSID)
            var fxForward = (FxForward) InstrumentExamples.CreateExampleFxForward();

            // ASSERT that it was created
            Assert.That(fxForward, Is.Not.Null);
            
            // CAN NOW UPSERT TO LUSID
            var uniqueId = fxForward.InstrumentType+Guid.NewGuid().ToString(); 
            var instrumentsIds = new List<(LusidInstrument, string)>{(fxForward, uniqueId)};
            var definitions = TestDataUtilities.BuildInstrumentUpsertRequest(instrumentsIds);
            
            UpsertInstrumentsResponse upsertResponse = _instrumentsApi.UpsertInstruments(definitions);
            ValidateUpsertInstrumentResponse(upsertResponse);

            // CAN NOW QUERY FROM LUSID
            GetInstrumentsResponse getResponse = _instrumentsApi.GetInstruments("ClientInternal", new List<string> { uniqueId });
            ValidateInstrumentResponse(getResponse ,uniqueId);
            
            // CHECK contents
            var retrieved = getResponse.Values.First().Value.InstrumentDefinition;
            Assert.That(retrieved.InstrumentType == LusidInstrument.InstrumentTypeEnum.FxForward);
            var retrFxFwd = retrieved as FxForward;
            Assert.That(retrFxFwd, Is.Not.Null);
            Assert.That(retrFxFwd.DomAmount, Is.EqualTo(fxForward.DomAmount));
            Assert.That(retrFxFwd.FgnAmount, Is.EqualTo(fxForward.FgnAmount));
            Assert.That(retrFxFwd.DomCcy, Is.EqualTo(fxForward.DomCcy));
            Assert.That(retrFxFwd.FgnCcy, Is.EqualTo(fxForward.FgnCcy));
            
            // DELETE instrument 
            _instrumentsApi.DeleteInstrument("ClientInternal", uniqueId); 
        }
        
        [TestCase(ModelSelection.ModelEnum.ConstantTimeValueOfMoney)]
        [TestCase(ModelSelection.ModelEnum.Discounting)]
        public void FxForwardValuationExample(ModelSelection.ModelEnum model)
        {
            var fxForward = InstrumentExamples.CreateExampleFxForward();
            CallLusidGetValuationEndpoint(fxForward, model);
        }
        
        [TestCase(ModelSelection.ModelEnum.ConstantTimeValueOfMoney)]
        [TestCase(ModelSelection.ModelEnum.Discounting)]
        public void FxForwardInlineValuationExample(ModelSelection.ModelEnum model)
        {
            var fxForward = InstrumentExamples.CreateExampleFxForward();
            CallLusidInlineValuationEndpoint(fxForward, model);
        }
        
        [TestCase(ModelSelection.ModelEnum.ConstantTimeValueOfMoney)]
        [TestCase(ModelSelection.ModelEnum.Discounting)]
        public void FxForwardPortfolioCashFlowsExample(ModelSelection.ModelEnum model)
        {
            var fxForward = InstrumentExamples.CreateExampleFxForward();
            CallLusidGetPortfolioCashFlowsEndpoint(fxForward, model);
        }
        
        [Test]
        public void LifeCycleManagementForFxForward()
        {
            // CREATE FX Forward
            var fxForward = (FxForward) InstrumentExamples.CreateExampleFxForward(isNdf: false);
            
            // CREATE wide enough window to pick up all cashflows for the FX Forward
            var windowStart = fxForward.StartDate.AddMonths(-1);
            var windowEnd = fxForward.MaturityDate.AddMonths(1);
            
            // CREATE portfolio and add instrument to the portfolio
            var scope = Guid.NewGuid().ToString();
            var (instrumentID, portfolioCode) = CreatePortfolioAndInstrument(scope, fxForward);
        
            // UPSERT FX Forward to portfolio and populating stores with required market data - use a constant FX rate USD/JPY = 150.
            var effectiveAt = windowStart;
            AddInstrumentsTransactionPortfolioAndPopulateRequiredMarketData(
                scope, 
                portfolioCode,
                windowStart,
                windowEnd,
                new List<LusidInstrument>(){fxForward},
                useConstantFxRate: true);

            // CREATE and upsert CTVoM recipe specifying discount pricing model
            var modelRecipeCode = "CTVoMRecipe";
            CreateAndUpsertRecipe(
                modelRecipeCode,
                scope,
                ModelSelection.ModelEnum.ConstantTimeValueOfMoney,
                windowValuationOnInstrumentStartEnd: true);

            // GET all upsertable cashflows (transactions) for the FX Forward
            var allFxFwdCashFlows = _transactionPortfoliosApi.GetUpsertablePortfolioCashFlows(
                    scope,
                    portfolioCode,
                effectiveAt,
                windowStart,
                windowEnd,
                null,
                null,
                scope,
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
                new ResourceId(scope, modelRecipeCode),
                portfolioEntityIds: new List<PortfolioEntityId> {new PortfolioEntityId(scope, portfolioCode)},
                valuationSchedule: valuationSchedule,
                metrics: TestDataUtilities.ValuationSpec,
                groupBy:  null,
                sort:  null,
                asAt: null,
                reportCurrency: "USD");
            
            // CALL GetValuation before upserting back the cashflows. We check that when the FX Forward has expired, the PV is zero.
            var valuationBeforeAndAfterExpirationOfFxForward = _aggregationApi.GetValuation(valuationRequest).Data;
            foreach (var valuationResult in valuationBeforeAndAfterExpirationOfFxForward)
            {
                var date = (DateTime) valuationResult[TestDataUtilities.ValuationDateKey];
                var fxForwardPv = (double) valuationResult[TestDataUtilities.ValuationPv];
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
            var upsertCashFlowTransactions = PortfolioCashFlows.PopulateCashFlowTransactionWithUniqueIds(allFxFwdCashFlows, fxForward.DomCcy);
            _transactionPortfoliosApi.UpsertTransactions(scope, portfolioCode, PortfolioCashFlows.MapToCashFlowTransactionRequest(upsertCashFlowTransactions));
            
            // HAVING upserted cashflow into lusid, we call GetValuation again.
            var valuationAfterUpsertingCashFlows = _aggregationApi.GetValuation(valuationRequest).Data;
            
            // ASSERT portfolio PV is constant across time by grouping the valuation result by date.
            // (constant because we upserted the cashflows back in with ConstantTimeValueOfMoney model and the FX rate is constant)
            // That is, we are checking instrument PV + cashflow PV = constant both before and after maturity  
            var resultsGroupedByDate = valuationAfterUpsertingCashFlows
                .GroupBy(d => (DateTime) d[TestDataUtilities.ValuationDateKey]);
            
            // CONVERT and AGGREGATE all results to USD
            var pvsInUsd = resultsGroupedByDate
                .Select(pvGroup => pvGroup.Sum(record =>
                {
                    var fxRate = ((string) record["Valuation/PV/Ccy"]).Equals("JPY") ? 1m/150 : 1;
                    return Convert.ToDecimal(record[TestDataUtilities.ValuationPv]) * fxRate;
                }));

            // ASSERT portfolio PV is constant over time within a tolerance
            var uniquePvsAcrossDates = pvsInUsd
                .Select(pv => Math.Round(pv, 12))
                .Distinct()
                .ToList();
            Assert.That(uniquePvsAcrossDates.Count, Is.EqualTo(1));
            
            // CLEAN up.
            _recipeApi.DeleteConfigurationRecipe(scope, modelRecipeCode);
        }
    }
}
