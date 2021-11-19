using System;
using System.Collections.Generic;
using System.Linq;
using Lusid.Sdk.Model;
using Lusid.Sdk.Utilities;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Utilities
{
    public abstract class DemoInstrumentBase: TutorialBase
    {
        internal abstract void CreateAndUpsertMarketDataToLusid(string scope, ModelSelection.ModelEnum model, LusidInstrument instrument);

        internal abstract void GetAndValidatePortfolioCashFlows(LusidInstrument instrument, string scope, string portfolioCode, string recipeCode, string instrumentID);
        
        internal void CallLusidGetPortfolioCashFlowsEndpoint(LusidInstrument instrument, ModelSelection.ModelEnum model)
        {
            var scope = Guid.NewGuid().ToString();

            // CREATE portfolio and book instrument to the portfolio            
            var (instrumentID, portfolioCode) = CreatePortfolioAndInstrument(scope, instrument);

            // UPSERT sufficient market data to get cashflow for the instrument
            CreateAndUpsertMarketDataToLusid(scope, model, instrument);
            
            // UPSERT recipe - this is the configuration used in pricing 
            var recipeCode = Guid.NewGuid().ToString();
            var recipeReq = TestDataUtilities.BuildRecipeRequest(recipeCode, scope, model);
            var response = _recipeApi.UpsertConfigurationRecipe(recipeReq);
            Assert.That(response.Value, Is.Not.Null);

            GetAndValidatePortfolioCashFlows(instrument, scope, portfolioCode, recipeCode, instrumentID);
        }
        
        internal string CreateAndUpsertRecipe(string scope, ModelSelection.ModelEnum model)
        {
            var recipeCode = Guid.NewGuid().ToString();
            var recipeReq = TestDataUtilities.BuildRecipeRequest(recipeCode, scope, model);
            var response = _recipeApi.UpsertConfigurationRecipe(recipeReq);
            Assert.That(response.Value, Is.Not.Null);
            return recipeCode;
        }
        
        /// <summary>
        /// Utility method to create a new portfolio that contains one transaction against the instrument. 
        /// </summary>
        /// <returns>Returns a tuple of instrumentId and portfolio code</returns>
        internal (string, string) CreatePortfolioAndInstrument(string scope, LusidInstrument instrument)
        {
            // CREATE portfolio
            var portfolioRequest = TestDataUtilities.BuildTransactionPortfolioRequest( TestDataUtilities.EffectiveAt);
            var portfolio = _transactionPortfoliosApi.CreatePortfolio(scope, portfolioRequest);
            Assert.That(portfolio?.Id.Code, Is.EqualTo(portfolioRequest.Code));

            // BUILD upsert instrument request
            var instrumentID = instrument.InstrumentType+Guid.NewGuid().ToString();
            var instrumentsIds = new List<(LusidInstrument, string)>{(instrument, instrumentID)};
            var definitions = TestDataUtilities.BuildInstrumentUpsertRequest(instrumentsIds);
            
            // UPSERT the instrument and validate it was successful
            var upsertResponse = _instrumentsApi.UpsertInstruments(definitions);
            ValidateUpsertInstrumentResponse(upsertResponse);
            
            var luids = upsertResponse.Values
                .Select(inst => inst.Value.LusidInstrumentId)
                .ToList();

            // CREATE transaction to book the instrument onto the portfolio via their LusidInstrumentId
            var transactionRequest = TestDataUtilities.BuildTransactionRequest(luids, scope, portfolioRequest.Code, TestDataUtilities.EffectiveAt);
            _transactionPortfoliosApi.UpsertTransactions(scope, portfolioRequest.Code, transactionRequest);

            return (instrumentID, portfolioRequest.Code);
        }
        
        /// <summary>
        /// Perform a valuation of a portfolio consisting of the instrument.
        /// In the below code, we create a portfolio and book the instrument onto the portfolio via a transaction.
        /// </summary>
        internal void CallLusidGetValuationEndpoint(LusidInstrument instrument, ModelSelection.ModelEnum model)
        {
            var scope = Guid.NewGuid().ToString();
            
            // CREATE portfolio and add instrument to the portfolio
            var (instrumentID, portfolioCode) = CreatePortfolioAndInstrument(scope, instrument);

            if (model == ModelSelection.ModelEnum.SimpleStatic)
            {
                // todo-jz: add comment
                var quoteRequest = TestDataUtilities.BuildQuoteRequest(scope, instrumentID, QuoteSeriesId.InstrumentIdTypeEnum.LusidInstrumentId, 100m, "USD", TestDataUtilities.EffectiveAt);
                var upsertResponse = _quotesApi.UpsertQuotes(scope, quoteRequest);
                Assert.That(upsertResponse.Failed.Count, Is.EqualTo(0));
                Assert.That(upsertResponse.Values.Count, Is.EqualTo(quoteRequest.Count));
            }
            else
            {
                // UPSERT market data sufficient to price the instrument depending on the model.
                CreateAndUpsertMarketDataToLusid(scope, model, instrument);
            }

            // CREATE recipe to price the portfolio with
            var recipeCode = CreateAndUpsertRecipe(scope, model);
            
            // CREATE valuation request
            var valuationSchedule = new ValuationSchedule(effectiveAt: TestDataUtilities.EffectiveAt);
            var valuationRequest = new ValuationRequest(
                recipeId: new ResourceId(scope, recipeCode),
                metrics: TestDataUtilities.ValuationSpec,
                valuationSchedule: valuationSchedule,
                sort: new List<OrderBySpec> {new OrderBySpec(TestDataUtilities.ValuationDateKey, OrderBySpec.SortOrderEnum.Ascending)},
                portfolioEntityIds: new List<PortfolioEntityId> {new PortfolioEntityId(scope, portfolioCode)},
                reportCurrency: "USD");

            
            // CALL valuation and assert that the PVs makes sense.
            var result = _aggregationApi.GetValuation(valuationRequest);
            _portfoliosApi.DeletePortfolio(scope, portfolioCode);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data.Count, Is.GreaterThanOrEqualTo(1));

            foreach (var r in result.Data)
            {
                var pv = (double) r[TestDataUtilities.ValuationPvKey];
                Assert.That(pv, Is.Not.EqualTo(0).Within(1e-5));
                Assert.That(pv, Is.GreaterThanOrEqualTo(0));
            }
            _recipeApi.DeleteConfigurationRecipe(scope, recipeCode);
        }
        
        /// <summary>
        /// Perform an inline valuation of a given instrument.
        /// Inline valuation means that we do not need to create a portfolio and book an instrument onto it.
        /// In particular, the instrument is also not persisted into any portfolio nor database, it gets deleted at the end.
        /// This endpoint makes it easy to experiment with pricing with less overhead.
        /// </summary>
        internal void CallLusidInlineValuationEndpoint(LusidInstrument instrument, ModelSelection.ModelEnum model)
        {
            var scope = Guid.NewGuid().ToString();
            
            // CREATE recipe to price the portfolio with
            var recipeCode = CreateAndUpsertRecipe(scope, model);

            // UPSERT market data sufficient to price the instrument
            CreateAndUpsertMarketDataToLusid(scope, model, instrument);

            // CREATE valuation request
            var valuationSchedule = new ValuationSchedule(effectiveAt: TestDataUtilities.EffectiveAt);
            var instruments = new List<WeightedInstrument> {new WeightedInstrument(1, "some-holding-identifier", instrument)}; 
            
            // CONSTRUCT valuation request
            var inlineValuationRequest = new InlineValuationRequest(
                recipeId: new ResourceId(scope, recipeCode),
                metrics: TestDataUtilities.ValuationSpec,
                sort: new List<OrderBySpec> {new OrderBySpec(TestDataUtilities.ValuationDateKey, OrderBySpec.SortOrderEnum.Ascending)},
                valuationSchedule: valuationSchedule,
                instruments: instruments);

            // CALL LUSID's inline GetValuationOfWeightedInstruments endpoint
            var result = _aggregationApi.GetValuationOfWeightedInstruments(inlineValuationRequest);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data.Count, Is.GreaterThanOrEqualTo(1));

            foreach (var r in result.Data)
            {
                var pv = (double) r[TestDataUtilities.ValuationPvKey];
                Assert.That(pv, Is.Not.EqualTo(0).Within(1e-5));
                Assert.That(pv, Is.GreaterThanOrEqualTo(0));
            }
            _recipeApi.DeleteConfigurationRecipe(scope, recipeCode);
        }
    }
}
