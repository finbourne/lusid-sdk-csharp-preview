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
        
        internal abstract LusidInstrument CreateExampleInstrument();

        internal abstract void GetAndValidatePortfolioCashFlows(LusidInstrument instrument, string scope, string portfolioCode, string recipeCode, string instrumentID);
        
        internal void CallLusidGetPortfolioCashFlowsEndpoint(ModelSelection.ModelEnum model)
        {
            // CREATE demo instrument
            LusidInstrument instrument = CreateExampleInstrument();
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

        internal void CallLusidValuationEndpoint(ModelSelection.ModelEnum model, bool inLineValuation)
        {
            var scope = Guid.NewGuid().ToString();

            LusidInstrument instrument = CreateExampleInstrument();
            
            CreateAndUpsertMarketDataToLusid(scope, model, instrument);

            string recipeCode = CreateAndUpsertRecipe(scope, model);
            
            CallLusidValuationEndpoint(scope, inLineValuation, instrument, recipeCode);
        }
        
        /// <summary>
        /// Perform a valuation of a given instrument. Valuation will either be inline (without portfolio and transaction) or through a portfolio and transaction.
        /// It is assumed that the required market data for the model has already been upserted in the same scope.
        /// </summary>
        internal void CallLusidValuationEndpoint(string scope, bool inLineValuation, LusidInstrument instrument, string recipeCode)
        { 
            // CALL valuation and check the PVs makes sense.
            var result = new ListAggregationResponse();
            if (inLineValuation)
            {
                var valuation = TestDataUtilities.CreateInLineValuationRequest(instrument, scope, TestDataUtilities.EffectiveAt, recipeCode);
                result = _aggregationApi.GetValuationOfWeightedInstruments(valuation);
            }
            else
            {
                var (instrumentID, portfolioCode) = CreatePortfolioAndInstrument(scope, instrument);
                var valuation = TestDataUtilities.CreateValuationRequest(scope, TestDataUtilities.EffectiveAt, recipeCode, portfolioCode);
                result = _aggregationApi.GetValuation(valuation);
                _portfoliosApi.DeletePortfolio(scope, portfolioCode);
            }

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
