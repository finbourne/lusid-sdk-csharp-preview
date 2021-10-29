using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using NUnit.Framework;

namespace Lusid.Sdk.Tests.Tutorials.Instruments
{
    public class DemoInstrument: TestDataUtilities
    {
        
        private static ComplexMarketData GetSpreadCurveJsonFromFile(string filename)
        {
            using var reader = new StreamReader(ExampleMarketDataDirectory + filename);
            var jsonString = reader.ReadToEnd();

            var cdsCurve = new OpaqueMarketData(
                jsonString,
                "Json",
                "CDS curve",
                ComplexMarketData.MarketDataTypeEnum.OpaqueMarketData
            );
            return cdsCurve;
        }

        public void UpsertCdsSpreadCurves(string scope, DateTimeOffset effectiveAt, string ticker, string ccy, CdsProtectionDetailSpecification.SeniorityEnum seniority, CdsProtectionDetailSpecification.RestructuringTypeEnum restructType)
        {
            var marketDataId = new ComplexMarketDataId
            (
                provider: "Lusid",
                effectiveAt: effectiveAt.ToString("o"),
                marketAsset: $"{ticker}/{ccy}/{seniority}/{restructType}",
                priceSource: "",
                lineage: ""
            );

            var marketData = GetSpreadCurveJsonFromFile("XYZCorp.json");
            var request = new UpsertComplexMarketDataRequest(marketDataId, marketData);

            _complexMarketDataApi.UpsertComplexMarketData(scope, new Dictionary<string, UpsertComplexMarketDataRequest>(){{"Request", request}});
        }

        public void CreateAndUpsertSimpleQuote(string scope, string id, QuoteSeriesId.InstrumentIdTypeEnum instrumentIdType, decimal price, string ccy, DateTimeOffset effectiveAt)
        {
            var quoteRequest = CreateSimpleQuoteUpsertRequest(id, instrumentIdType, price, ccy, effectiveAt);
            var upsertRequests = new Dictionary<string, UpsertQuoteRequest> {{"req1", quoteRequest}};

            // CHECK quotes upsert was successful for all the quotes
            var upsertResponse = _quotesApi.UpsertQuotes(scope, upsertRequests);
            Assert.That(upsertResponse.Failed.Count, Is.EqualTo(0));
            Assert.That(upsertResponse.Values.Count, Is.EqualTo(upsertRequests.Count));
        }

        public ComplexMarketData CreateVolSurfaceData(
            DateTimeOffset effectiveAt,
            List<LusidInstrument> instruments,
            List<MarketQuote> quotes,
            ComplexMarketData.MarketDataTypeEnum type)
        {
            ComplexMarketData temp = new ComplexMarketData();
            if(type == ComplexMarketData.MarketDataTypeEnum.EquityVolSurfaceData)
                temp = new EquityVolSurfaceData(effectiveAt, instruments, quotes, ComplexMarketData.MarketDataTypeEnum.EquityVolSurfaceData);
            if(type == ComplexMarketData.MarketDataTypeEnum.FxVolSurfaceData)
                temp =  new FxVolSurfaceData(effectiveAt, instruments, quotes,
                   ComplexMarketData.MarketDataTypeEnum.FxVolSurfaceData);

            return temp;

        }

        public string GetMarketAsset(LusidInstrument option, MarketQuote.QuoteTypeEnum volType)
        {
            string temp = "";
            if (option.InstrumentType == LusidInstrument.InstrumentTypeEnum.EquityOption)
            {
                EquityOption eoption = (EquityOption) option;
                temp =  $"{eoption.Code}/{eoption.DomCcy}/" + (volType == MarketQuote.QuoteTypeEnum.NormalVol ? "N" : "LN"); 
            }

            if (option.InstrumentType == LusidInstrument.InstrumentTypeEnum.FxOption)
            {
                FxOption fxoption = (FxOption) option;
               temp = $"{fxoption.DomCcy}/{fxoption.FgnCcy}/" + (volType == MarketQuote.QuoteTypeEnum.NormalVol ? "N" : "LN");
            }

            return temp;

        }

        /// <summary>
        /// One-point vol surface for a given option - thus the surface is constant.
        /// </summary>
        public void CreateAndUpsertConstantVolSurface(string scope, DateTimeOffset effectiveAt, LusidInstrument option, ModelSelection.ModelEnum model, decimal vol = 0.2m)
        {
            ComplexMarketData.MarketDataTypeEnum type = ComplexMarketData.MarketDataTypeEnum.OpaqueMarketData;
            if (option.InstrumentType == LusidInstrument.InstrumentTypeEnum.EquityOption)
                type = ComplexMarketData.MarketDataTypeEnum.EquityVolSurfaceData;
            if (option.InstrumentType == LusidInstrument.InstrumentTypeEnum.FxOption)
                type = ComplexMarketData.MarketDataTypeEnum.FxVolSurfaceData; 
            
            var instruments = new List<LusidInstrument> {option};
            var volType = model == ModelSelection.ModelEnum.Bachelier ? MarketQuote.QuoteTypeEnum.NormalVol : MarketQuote.QuoteTypeEnum.LogNormalVol;
            var quotes = new List<MarketQuote> {new MarketQuote(volType, vol)};
            var complexMarketData = CreateVolSurfaceData(effectiveAt, instruments, quotes, type);

            var marketAsset = GetMarketAsset(option, volType);

            var complexMarketDataId = new ComplexMarketDataId(
                provider: "Lusid",
                effectiveAt: effectiveAt.ToString("o"),
                marketAsset: marketAsset);
            
            var upsertRequest = new Dictionary<string, UpsertComplexMarketDataRequest>
                {{"0", new UpsertComplexMarketDataRequest(complexMarketDataId, complexMarketData)}};

            var upsertResponse = _complexMarketDataApi.UpsertComplexMarketData(scope, upsertRequest);
            Assert.That(upsertResponse.Values.Values, Is.Not.Null);
            Assert.That(upsertResponse.Values.Values.Count, Is.EqualTo(upsertRequest.Count));
        }

        /// <summary>
        /// Helper to upsert a given LusidInstrument and ensure that the process is successful
        /// </summary>
        public UpsertInstrumentsResponse UpsertOtcInstrumentToLusid(LusidInstrument instrument, string idUniqueToInstrument)
        {
            // PACKAGE instrument for upsert
            var instrumentDefinition = new InstrumentDefinition(
                name: "DemoInstrument",
                identifiers: new Dictionary<string, InstrumentIdValue>
                {
                    ["ClientInternal"] = new InstrumentIdValue(value: idUniqueToInstrument)
                },
                definition: instrument
            );

            // put instrument into Lusid
            var response = _instrumentsApi.UpsertInstruments(new Dictionary<string, InstrumentDefinition>
            {
                [idUniqueToInstrument] = instrumentDefinition
            });

            // Check the response succeeded and has no errors.
            Assert.That(response.Failed.Count, Is.EqualTo(0));
            Assert.That(response.Values.Count, Is.EqualTo(1));
            return response;
        }

        public string CreatePortfolioAndTransaction(string scope, LusidInstrument instrument, string instrumentID, DateTimeOffset effectiveAt)
        {
            // Create new portfolio
            var portfolioCode = CreateTransactionPortfolio(scope);
            // UPSERT instruments to Lusid and return the upsert response to attain LusidInstrumentIds
            var upsertResponse = UpsertOtcInstrumentToLusid(instrument, instrumentID);
                
            var luids = upsertResponse.Values
                .Select(inst => inst.Value.LusidInstrumentId)
                .ToList();

            // ADD instruments to the portfolio via their LusidInstrumentId
            AddInstrumentsTransactionToPortfolio(luids, scope, portfolioCode, effectiveAt);

            return portfolioCode;
        }

        /// <summary>
        /// Helper to query the definition of an instrument stored in Lusid
        /// </summary>
        public LusidInstrument QueryOtcInstrumentFromLusid(string idUniqueToInstrument)
        {
            var response = _instrumentsApi.GetInstruments("ClientInternal",
                new List<string>
                {
                    idUniqueToInstrument
                });

            // Check the response succeeded and has no errors.
            Assert.That(response.Failed.Count, Is.EqualTo(0));
            Assert.That(response.Values.Count, Is.EqualTo(1));

            Assert.That(response.Values.First().Key, Is.EqualTo(idUniqueToInstrument));
            return response.Values.First().Value.InstrumentDefinition;
        }

        public ResourceListOfInstrumentCashFlow GetPortfolioCashFlows(
            string scope, 
            string code, 
            DateTimeOrCutLabel effectiveAt, 
            DateTimeOrCutLabel windowStart, 
            DateTimeOrCutLabel windowEnd, 
            DateTimeOffset? asAt, 
            string filter, 
            string recipeIdScope, 
            string recipeIdCode
        )
        {
            return  _transactionPortfoliosApi.GetPortfolioCashFlows(
                scope,
                code,
                effectiveAt, windowStart, windowEnd,
                null,
                null,
                recipeIdScope,
                recipeIdCode);
        }

        /// <summary>
        /// Simple wrapper to upsert a recipe to Lusid and ensure that the process is successful
        /// </summary>
        public void UpsertRecipe(string recipeCode, string scope, ModelSelection.ModelEnum model)
        {
            var pricingOptions = new PricingOptions(new ModelSelection(ModelSelection.LibraryEnum.Lusid, model));
            var recipe = new ConfigurationRecipe(
                scope,
                recipeCode,
                market: new MarketContext(
                    marketRules: new List<MarketDataKeyRule>{}, 
                    options: new MarketOptions(defaultSupplier: "Lusid", defaultScope: scope, defaultInstrumentCodeType: "RIC")),
                pricing: new PricingContext(options: pricingOptions),
                description: $"Recipe for {model} pricing");
            
            var upsertRecipeRequest = new UpsertRecipeRequest(recipe);
            var response = _recipeApi.UpsertConfigurationRecipe(upsertRecipeRequest);
            Assert.That(response.Value, Is.Not.Null);
        }

        /// <summary>
        /// Helper function to perform valuation of instrument. Can either perform inline valuation or valuation through a portfolio.
        /// If it is through a portfolio then a new portfolio and transaction against the instrument is created which is deleted at the end. 
        /// </summary>
        public ListAggregationResponse Valuation(LusidInstrument instrument,  string scope, ModelSelection.ModelEnum model, DateTimeOffset effectiveAt, bool inLineVal = false)
        {
            var recipeCode = Guid.NewGuid().ToString();
            // Upsert recipe - this is the configuration used in pricing 
            UpsertRecipe(recipeCode, scope, model);
            
            // CREATE valuation request
            var valuationSchedule = new ValuationSchedule(effectiveAt: effectiveAt);
            
            if (!inLineVal)
            {
                var instrumentID = Guid.NewGuid().ToString(); 

                var portfolioCode = CreatePortfolioAndTransaction(scope, instrument, instrumentID, effectiveAt);
                
                var valuationRequest = new ValuationRequest(
                    recipeId: new ResourceId(scope, recipeCode),
                    metrics: TestDataUtilities.valuationSpec,
                    valuationSchedule: valuationSchedule,
                    sort: new List<OrderBySpec> {new OrderBySpec(TestDataUtilities.ValuationDateKey, OrderBySpec.SortOrderEnum.Ascending)},
                    portfolioEntityIds: new List<PortfolioEntityId> {new PortfolioEntityId(scope, portfolioCode)},
                    reportCurrency: "USD");
            
                var result = _aggregationApi.GetValuation(valuationRequest);
                
                DeleteItems(scope, recipeCode, portfolioCode, instrumentID);
                return result;

            }
 
            var instruments = new List<WeightedInstrument> {new WeightedInstrument(1, "some-holding-identifier", instrument)}; 
            
            // CONSTRUCT and PERFORM valuation request
            var inlineValuationRequest = new InlineValuationRequest(
                recipeId: new ResourceId(scope, recipeCode),
                metrics: TestDataUtilities.valuationSpec,
                sort: new List<OrderBySpec> {new OrderBySpec(TestDataUtilities.ValuationDateKey, OrderBySpec.SortOrderEnum.Ascending)},
                valuationSchedule: valuationSchedule,
                instruments: instruments);
            
            var inlineResult = _aggregationApi.GetValuationOfWeightedInstruments(inlineValuationRequest);
            DeleteItems(scope, recipeCode);
            return inlineResult;

        }
    }
}
