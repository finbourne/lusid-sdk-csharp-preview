using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lusid.Sdk.Api;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using NUnit.Framework;

namespace Lusid.Sdk.Utilities
{
    public abstract class DemoInstrumentBase: TutorialBase
    {
        internal abstract void CreateMarketData(string scope, ModelSelection.ModelEnum model, LusidInstrument instrument);
        
        internal abstract LusidInstrument CreateInstrument();

        internal abstract void GetAndValidateCashFlows(LusidInstrument instrument, string scope, string portfolioCode, string recipeCode, string instrumentID);

        internal void DemoValuation(ModelSelection.ModelEnum model, bool inLineValuation)
        {
            var scope = Guid.NewGuid().ToString();

            LusidInstrument instrument = CreateInstrument();
            
            CreateMarketData(scope, model, instrument);

            string recipeCode = CreateRecipe(scope, model);
            
            Valuation(scope, model, inLineValuation, instrument, recipeCode);
        }

        internal void DemoCashFlows(ModelSelection.ModelEnum model)
        {
            // CREATE CDS
            LusidInstrument instrument = CreateInstrument();
            var scope = Guid.NewGuid().ToString();

            CreateMarketData(scope, model, instrument);
            
            var (instrumentID, portfolioCode) = CreatePortfolioAndInstrument(scope, instrument);

            var recipeCode = Guid.NewGuid().ToString();
            // Upsert recipe - this is the configuration used in pricing 
            var recipeReq = TestDataUtilities.BuildRecipeRequest(recipeCode, scope, model);
            var response = _recipeApi.UpsertConfigurationRecipe(recipeReq);
            Assert.That(response.Value, Is.Not.Null);

            GetAndValidateCashFlows(instrument, scope, portfolioCode, recipeCode, instrumentID);

        }
        
        internal string CreateRecipe(string scope, ModelSelection.ModelEnum model)
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
        /// <returns></returns>
        internal (string, string) CreatePortfolioAndInstrument(string scope, LusidInstrument instrument)
        {
            var portfolioRequest = TestDataUtilities.BuildTransactionPortfolioRequest( TestDataUtilities.EffectiveAt);
            var portfolio = _transactionPortfoliosApi.CreatePortfolio(scope, portfolioRequest);
            Assert.That(portfolio?.Id.Code, Is.EqualTo(portfolioRequest.Code));

            var instrumentID = instrument.InstrumentType+Guid.NewGuid().ToString();
            List<(LusidInstrument, string)> instrumentsIds = new List<(LusidInstrument, string)>(){(instrument, instrumentID)};
                
            var definitions = TestDataUtilities.BuildInstrumentUpsertRequest(instrumentsIds);
            var upsertResponse = _instrumentsApi.UpsertInstruments(definitions); 
            
            ValidateInstrumentResponse(upsertResponse);
            
            var luids = upsertResponse.Values
                .Select(inst => inst.Value.LusidInstrumentId)
                .ToList();

            // ADD instruments to the portfolio via their LusidInstrumentId
            var transactionRequest = TestDataUtilities.BuildTransactionRequest(luids, scope, portfolioRequest.Code, TestDataUtilities.EffectiveAt);
            _transactionPortfoliosApi.UpsertTransactions(scope, portfolioRequest.Code, transactionRequest);

            return (instrumentID, portfolioRequest.Code);
        }
        
        
        /// <summary>
        /// Perform a valuation of a given instrument. Valuation will either be inline (without portfolio and transaction) or through a portfolio and transaction.
        /// It is assumed that the required market data for the model has already been upserted in the same scope.
        /// </summary>
        internal void Valuation(string scope, ModelSelection.ModelEnum model, bool inLineValuation, LusidInstrument instrument, string recipeCode)
        { 

            // CALL valuation and check the PVs makes sense.
            var result = new ListAggregationResponse();
            if (inLineValuation)
            {
                var valuation = TestDataUtilities.InLineValuationRequest(instrument, scope, model, TestDataUtilities.EffectiveAt, recipeCode);
                result = _aggregationApi.GetValuationOfWeightedInstruments(valuation);
            }
            else
            {
                var (instrumentID, portfolioCode) = CreatePortfolioAndInstrument(scope, instrument);
                var valuation = TestDataUtilities.ValuationRequest(instrument, scope, model, TestDataUtilities.EffectiveAt, recipeCode, portfolioCode);
                result = _aggregationApi.GetValuation(valuation);
                _portfoliosApi.DeletePortfolio(scope, portfolioCode);
            }

            Assert.That(result, Is.Not.Null);

            foreach (var r in result.Data)
            {
                var pv = (double) r[TestDataUtilities.HoldingPvKey];
                Assert.That(pv, Is.Not.EqualTo(0).Within(1e-5));
                Assert.That(pv, Is.GreaterThanOrEqualTo(0));
            }
            _recipeApi.DeleteConfigurationRecipe(scope, recipeCode);
        }
    }
}
