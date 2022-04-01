using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lusid.Sdk.Api;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;
using Lusid.Sdk.Tests.Utilities;
using Lusid.Sdk.Utilities;


namespace Lusid.Sdk.Tests.tutorials.Ibor
{
    public class StructuredResultStore : TutorialBase
    {
        [Test]   
        public void CalculatePvForBondOfAccruedOverriden()
        {
            // Setting up basic parameters
            string scope = "scope-" + Guid.NewGuid();;
            string resultType = "UnitResult/Analytic";
            string documentId = "document-1";
            DataMapKey dataMapKey = new DataMapKey("1.0.0", "test-code");
            DateTimeOffset effectiveAt = new DateTimeOffset(2022, 01, 19, 0, 0, 0, 0, TimeSpan.Zero);
            
            // Create portfolio
            var portfolioRequest = TestDataUtilities.BuildTransactionPortfolioRequest(effectiveAt);
            var portfolio = _transactionPortfoliosApi.CreatePortfolio(scope, portfolioRequest);
            string portfolioCode = portfolio.Id.Code;
            
            // Create and upsert an Instrument
            DateTimeOffset startDate = new DateTimeOffset(2019, 01, 15, 0, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset maturityDate = new DateTimeOffset(2023, 01, 15, 0, 0, 0, 0, TimeSpan.Zero);
            var bond = new Bond(
                startDate: startDate,
                maturityDate: maturityDate,
                domCcy: "GBP",
                principal: 100m,
                couponRate: 0.06m,
                flowConventions: new FlowConventions(
                    currency: "GBP",
                    paymentFrequency: "6M",
                    rollConvention: "MF",
                    dayCountConvention: "Act365",
                    paymentCalendars: new List<string>(),
                    resetCalendars: new List<string>(),
                    settleDays: 2,
                    resetDays: 2),
                identifiers: new Dictionary<string, string>(),
                instrumentType: LusidInstrument.InstrumentTypeEnum.Bond
            );
            var instrumentsIds = new List<(LusidInstrument, string)>
            {
                (bond, bond.InstrumentType + Guid.NewGuid().ToString())
            };
            var definitions = TestDataUtilities.BuildInstrumentUpsertRequest(instrumentsIds);
            var upsertResponse = _instrumentsApi.UpsertInstruments(definitions);

            // Create transaction to book the instrument onto the portfolio via their LusidInstrumentId
            List<string> luids = upsertResponse.Values
                .Select(inst => inst.Value.LusidInstrumentId)
                .ToList();
            var transactionRequest = TestDataUtilities.BuildTransactionRequest(luids, effectiveAt);
            _transactionPortfoliosApi.UpsertTransactions(scope, portfolioCode, transactionRequest);
            
            // Create a Data Map
            DataMapping dataMapping = new DataMapping(new List<DataDefinition>
            {
                new DataDefinition("UnitResult/LusidInstrumentId", "LusidInstrumentId", "string", "Unique"),
                new DataDefinition("UnitResult/Accrual", dataType: "Result0D", keyType: "CompositeLeaf"),
                new DataDefinition("UnitResult/Accrual/Amount", "Accrual", "decimal", "Leaf"),
                new DataDefinition("UnitResult/Accrual/Ccy", "AccrualCcy", "string", "Leaf"),
                new DataDefinition("UnitResult/ClientCustomValue", "ClientVal", "decimal", "Leaf"),
            });
            var request = new CreateDataMapRequest(dataMapKey, dataMapping);
            _structuredResultDataApi.CreateDataMap(scope,
                new Dictionary<string, CreateDataMapRequest> {{"some-key", request}});
            
            // Upsert Document
            string document = $"LusidInstrumentId, Accrual, AccrualCcy, ClientVal\n{luids.First()}, 0.0123456, GBP, 1.7320508"; // Note the LusidInstrumentId matches that of the previously upserted instrument.
            StructuredResultData structuredResultData = new StructuredResultData("csv", "1.0.0", documentId, document, dataMapKey);
            
            StructuredResultDataId structResultDataId = new StructuredResultDataId("Client", documentId, effectiveAt, resultType);
            var upsertDataRequest = new UpsertStructuredResultDataRequest(structResultDataId, structuredResultData);
            
            _structuredResultDataApi.UpsertStructuredResultData(scope, new Dictionary<string, UpsertStructuredResultDataRequest>{{documentId, upsertDataRequest}});
            
            // Create result data key rule specifying 
            string resourceKey = "UnitResult/*";
            var resultDataKeyRule = new ResultDataKeyRule("Client", scope, documentId, resourceKey: resourceKey, documentResultType: resultType, resultKeyRuleType: ResultKeyRule.ResultKeyRuleTypeEnum.ResultDataKeyRule);

            // Create and upsert a recipe with the result data key rule
            var pricingContext = new PricingContext(modelRules: new List<VendorModelRule>
                {new VendorModelRule(VendorModelRule.SupplierEnum.Lusid, "ConstantTimeValueOfMoney","Bond")}, resultDataRules: new List<ResultKeyRule>{resultDataKeyRule} );
            var configurationRecipe = new ConfigurationRecipe(scope, portfolioCode, new MarketContext(), pricingContext);
            var upsertRecipeRequest = new UpsertRecipeRequest(configurationRecipe, null);
            _recipeApi.UpsertConfigurationRecipe(upsertRecipeRequest);
            
            
            
            // Create a valuation request requesting for:
            // - Lusid instrument id
            // - Accrual as is held in UnitResults (one from the document)
            // - Pv that was valued based on the overriden accrual
            // - The scaled accrual.
            // - Client Custom value that gets carried on.
            var valuationRequest = new ValuationRequest(
                recipeId: new ResourceId(scope, portfolioCode),
                metrics: new List<AggregateSpec>
                {
                    new AggregateSpec(TestDataUtilities.Luid, AggregateSpec.OpEnum.Value),
                    new AggregateSpec("UnitResult/Accrual", AggregateSpec.OpEnum.Value),
                    new AggregateSpec(TestDataUtilities.ValuationPv, AggregateSpec.OpEnum.Value),
                    new AggregateSpec("Holding/default/Accrual", AggregateSpec.OpEnum.Value),
                    new AggregateSpec("UnitResult/ClientCustomValue", AggregateSpec.OpEnum.Value),
                },
                portfolioEntityIds: new List<PortfolioEntityId> { new PortfolioEntityId(scope, portfolioCode) },
                valuationSchedule: new ValuationSchedule(effectiveAt: effectiveAt));
    
            // Perform valuation and obtain results
            var results = _apiFactory.Api<IAggregationApi>().GetValuation(valuationRequest);
            
            // Verify the results are as expected 
            Assert.That(results.Data[0]["Instrument/default/LusidInstrumentId"], Is.EqualTo(luids.First()));
            Assert.That(results.Data[0]["UnitResult/Accrual"], Is.EqualTo(0.0123456));
            Assert.That(results.Data[0]["Valuation/PV/Amount"], Is.EqualTo(107.23456));
            Assert.That(results.Data[0]["Holding/default/Accrual"], Is.EqualTo(1.23456));
            Assert.That(results.Data[0]["UnitResult/ClientCustomValue"], Is.EqualTo(1.7320508));
        }

        [Test]
        public void GetValuationPortfolioUnitResultKeys()
        {
            // Setting up basic parameters   
            string documentId = "document-1";
            string documentScope = "document-scope-" + Guid.NewGuid();
            string resultType = "UnitResult/Grouped";
            DataMapKey dataMapKey = new DataMapKey("1.0.0", "test-code");
            DateTimeOffset effectiveAt = new DateTimeOffset(2022, 01, 19, 0, 0, 0, 0, TimeSpan.Zero);

            
            string scope1 = "scope-" + Guid.NewGuid();
            string portfolioCode1 = "pf-1";
            string scope2 = "scope-" + Guid.NewGuid();
            string portfolioCode2 = "pf-2";
            
            
            // Create portfolios
            var portfolioRequest1 = new CreateTransactionPortfolioRequest(
                code: portfolioCode1,
                displayName: $"Portfolio-{portfolioCode1}",
                baseCurrency: "USD",
                created: effectiveAt
            );
            _transactionPortfoliosApi.CreatePortfolio(scope1, portfolioRequest1);
            
            var portfolioRequest2 = new CreateTransactionPortfolioRequest(
                code: portfolioCode2,
                displayName: $"Portfolio-{portfolioCode2}",
                baseCurrency: "USD",
                created: effectiveAt
            );
            _transactionPortfoliosApi.CreatePortfolio(scope2, portfolioRequest2);

            // CREATE And UPSERT an instrument
            string instrumentName1 = "AClientName1";
            string instrumentName2 = "AClientName2";
            string clientInstId1 = "clientInstId1";
            string clientInstId2 = "clientInstId2";
            
            var instruments = new Dictionary<string, InstrumentDefinition>
            {
                {
                    "an-inst1", new InstrumentDefinition(instrumentName1,
                        new Dictionary<string, InstrumentIdValue>
                        {{
                            "ClientInternal", new InstrumentIdValue(clientInstId1)
                        }}
                    )
                },
                {
                    "an-inst2", new InstrumentDefinition(instrumentName2,
                        new Dictionary<string, InstrumentIdValue>
                        {{
                            "ClientInternal", new InstrumentIdValue(clientInstId2)
                        }}
                    )
                },
            };
            var upsertResponse = _instrumentsApi.UpsertInstruments(instruments);
            
            // Create transaction to book the instrument onto the portfolio via their LusidInstrumentId
            List<string> luids = upsertResponse.Values
                .Select(inst => inst.Value.LusidInstrumentId)
                .ToList();
            
            var transactionRequest1 = new List<TransactionRequest>
            {
                TestDataUtilities.BuildTransactionRequest(luids[0], 1000, 1m, "USD", effectiveAt, "Buy"),
            };
            _transactionPortfoliosApi.UpsertTransactions(scope1, portfolioCode1, transactionRequest1);

            
            var transactionRequest2 = new List<TransactionRequest>
            {
                TestDataUtilities.BuildTransactionRequest(luids[1], 1000, 10m, "USD", effectiveAt, "Buy")
            };
            _transactionPortfoliosApi.UpsertTransactions(scope2, portfolioCode2, transactionRequest2);

            var document = $"pfscope,pfcode,retYtD,another-key\n" +
                           $"{scope1},{portfolioCode1},0.123456,\"test1\"\n" +
                           $"{scope2},{portfolioCode2},1,\"test2\"";

            DataMapping dataMapping = new DataMapping(new List<DataDefinition>
                    {
                        new DataDefinition("UnitResult/PortfolioScope", "pfscope", "string", "PartOfUnique"),
                        new DataDefinition("UnitResult/PortfolioCode", "pfcode", "string", "PartOfUnique"),
                        new DataDefinition("UnitResult/Portfolio/Returns/YtD", "retYtD", "decimal", "Leaf"),
                        new DataDefinition("UnitResult/Portfolio/SomeUserKey", "another-key", "string", "Leaf"),
                    });
          
            var request = new CreateDataMapRequest(dataMapKey, dataMapping);
            _structuredResultDataApi.CreateDataMap(documentScope,new Dictionary<string, CreateDataMapRequest> {{"some-key", request}});

            // Upserting the document 
            StructuredResultData structuredResultData = new StructuredResultData("csv", "1.0.0", documentId, document, dataMapKey);
            StructuredResultDataId structResultDataId = new StructuredResultDataId("Client", documentId, effectiveAt, resultType);
            var upsertDataRequest = new UpsertStructuredResultDataRequest(structResultDataId, structuredResultData);
            _structuredResultDataApi.UpsertStructuredResultData(documentScope, new Dictionary<string, UpsertStructuredResultDataRequest>{{documentId, upsertDataRequest}});
            
            // Create result data key rule specifying 
            string resourceKey = "UnitResult/Portfolio/*";
            var resultDataKeyRule = new ResultDataKeyRule("Client", documentScope, documentId, resourceKey: resourceKey, documentResultType: resultType, resultKeyRuleType: ResultKeyRule.ResultKeyRuleTypeEnum.ResultDataKeyRule);

            // Create and upsert a recipe with the result data key rule
            var pricingOptions = new PricingOptions {AllowAnyInstrumentsWithSecUidToPriceOffLookup = false, AllowPartiallySuccessfulEvaluation = true};
            var pricingContext = new PricingContext(null, null, pricingOptions, new List<ResultKeyRule>{resultDataKeyRule} );
            var configurationRecipe = new ConfigurationRecipe(documentScope, "recipe", new MarketContext(), pricingContext);
            var upsertRecipeRequest = new UpsertRecipeRequest(configurationRecipe, null);
            _recipeApi.UpsertConfigurationRecipe(upsertRecipeRequest);
            
            // Creating a valuation request, in which we request portfolio id, YtD, and some user key.
            var valuationRequest = new ValuationRequest(
                recipeId: new ResourceId(documentScope, "recipe"),
                metrics: new List<AggregateSpec>
                {
                    new AggregateSpec("Portfolio/default/Id", AggregateSpec.OpEnum.Value),
                    new AggregateSpec("UnitResult/Portfolio/Returns/YtD", AggregateSpec.OpEnum.Value),
                    new AggregateSpec("UnitResult/Portfolio/SomeUserKey", AggregateSpec.OpEnum.Value),
                },
                portfolioEntityIds: new List<PortfolioEntityId>
                {
                    new PortfolioEntityId(scope1, portfolioCode1),
                    new PortfolioEntityId(scope2, portfolioCode2)
                },
                valuationSchedule: new ValuationSchedule(effectiveAt: effectiveAt),
                sort: new List<OrderBySpec>
            {
                new OrderBySpec("UnitResult/Portfolio/SomeUserKey", OrderBySpec.SortOrderEnum.Ascending)
            });
    
            // Perform valuation and obtain results
            var results = _apiFactory.Api<IAggregationApi>().GetValuation(valuationRequest);
            
            // Verify the results are as expected 
            Assert.That(results.Data[0]["Portfolio/default/Id"], Is.EqualTo(portfolioCode1));
            Assert.That(results.Data[0]["UnitResult/Portfolio/Returns/YtD"], Is.EqualTo(0.123456));
            Assert.That(results.Data[0]["UnitResult/Portfolio/SomeUserKey"], Is.EqualTo("test1"));
            Assert.That(results.Data[0], Is.EqualTo(results.Data[1]));
            
            Assert.That(results.Data[2]["Portfolio/default/Id"], Is.EqualTo(portfolioCode2));
            Assert.That(results.Data[2]["UnitResult/Portfolio/Returns/YtD"], Is.EqualTo(1));
            Assert.That(results.Data[2]["UnitResult/Portfolio/SomeUserKey"], Is.EqualTo("test2"));
            Assert.That(results.Data[2], Is.EqualTo(results.Data[3]));
        }
        
        [Test]
        public void GetValuationHoldingUnitResultKeys()
        {
            // Setting up basic parameters
            string documentId = "document-1";
            string documentScope = "document-scope-" + Guid.NewGuid();
            string resultType = "UnitResult/Holding";
            DataMapKey dataMapKey = new DataMapKey("1.0.30", "test-code");
            DateTimeOffset effectiveAt = new DateTimeOffset(2022, 01, 19, 0, 0, 0, 0, TimeSpan.Zero);
            
            var dataTypeId = new ResourceId("system", "string");
            string scope1 = "scope1-" + Guid.NewGuid();
            string scope2 = "scope2-" + Guid.NewGuid();

            
            // Creating property definitions
            var propertyDefinition1 = new CreatePropertyDefinitionRequest(
                domain: CreatePropertyDefinitionRequest.DomainEnum.Transaction,
                scope: scope1,
                code: "Strategy",
                valueRequired: true,
                displayName: "Strategy",
                dataTypeId: dataTypeId,
                lifeTime: CreatePropertyDefinitionRequest.LifeTimeEnum.Perpetual);
            _propertyDefinitionsApi.CreatePropertyDefinition(propertyDefinition1);
            
            var propertyDefinition2 = new CreatePropertyDefinitionRequest(
                domain: CreatePropertyDefinitionRequest.DomainEnum.Transaction,
                scope: scope2,
                code: "Country",
                valueRequired: true,
                displayName: "Country",
                dataTypeId: dataTypeId,
                lifeTime: CreatePropertyDefinitionRequest.LifeTimeEnum.Perpetual);
            _propertyDefinitionsApi.CreatePropertyDefinition(propertyDefinition2);
            
            // Create portfolios
            string portfolioCode1 = "pf1-" + Guid.NewGuid().ToString();
            var portfolioRequest1 = new CreateTransactionPortfolioRequest(
                code: portfolioCode1,
                displayName: $"Portfolio-{portfolioCode1}",
                baseCurrency: "USD",
                subHoldingKeys: new List<string>
                {
                    $"Transaction/{scope1}/Strategy",
                    $"Transaction/{scope2}/Country"
                },
                created: effectiveAt
            );
            var portfolio1 = _transactionPortfoliosApi.CreatePortfolio(scope1, portfolioRequest1);
            
            string portfolioCode2 = "pf2-" + Guid.NewGuid().ToString();
            var portfolioRequest2 = new CreateTransactionPortfolioRequest(
                code: portfolioCode2,
                displayName: $"Portfolio-{portfolioCode2}",
                baseCurrency: "USD",
                subHoldingKeys: new List<string>
                {
                    $"Transaction/{scope1}/Strategy",
                    $"Transaction/{scope2}/Country"
                },
                created: effectiveAt
            );
            var portfolio2 = _transactionPortfoliosApi.CreatePortfolio(scope1, portfolioRequest2);
            
            // Create and upsert an instrument
            var instrumentName1 = "AClientName1";
            var clientInstId1 = "clientInstId1";
            var instruments = new Dictionary<string, InstrumentDefinition>
            {
                {
                    "an-inst1", new InstrumentDefinition(instrumentName1,
                        new Dictionary<string, InstrumentIdValue>
                        {{
                            "ClientInternal", new InstrumentIdValue(clientInstId1)
                        }}
                    )
                }
            };
            var upsertResponse = _instrumentsApi.UpsertInstruments(instruments);
            
            // Create transaction to book the instrument onto the portfolio via their LusidInstrumentId
            List<string> luids = upsertResponse.Values
                .Select(inst => inst.Value.LusidInstrumentId)
                .ToList();
            
            
            
            // CREATE and UPSERT transactions on the instrument
            // 2 tranasction in pf1 (Strategy1 and Strategy2) => 4 holdings
            // 1 transaction in pf2 (Strategy1) => 2 holdings
            var transactionRequest1 = new List<TransactionRequest>
            {
                new TransactionRequest(
                    transactionId: Guid.NewGuid().ToString(),
                    type: "Buy",
                    instrumentIdentifiers: new Dictionary<string, string>
                    {
                        ["Instrument/default/LusidInstrumentId"] = luids[0]
                    },
                    transactionDate: effectiveAt,
                    settlementDate: effectiveAt,
                    units: 1000,
                    transactionPrice: new TransactionPrice(1, TransactionPrice.TypeEnum.Price),
                    totalConsideration: new CurrencyAndAmount(1*1000, "USD"),
                    properties: new Dictionary<string, PerpetualProperty>
                    {
                        {$"Transaction/{scope1}/Strategy", new PerpetualProperty($"Transaction/{scope1}/Strategy", new PropertyValue("Strategy1"))},
                        {$"Transaction/{scope2}/Country", new PerpetualProperty($"Transaction/{scope2}/Country", new PropertyValue("England"))}
                    },
                    source: "Broker"),
                new TransactionRequest(
                    transactionId: Guid.NewGuid().ToString(),
                    type: "Buy",
                    instrumentIdentifiers: new Dictionary<string, string>
                    {
                        ["Instrument/default/LusidInstrumentId"] = luids[0]
                    },
                    transactionDate: effectiveAt,
                    settlementDate: effectiveAt,
                    units: 1000,
                    transactionPrice: new TransactionPrice(1, TransactionPrice.TypeEnum.Price),
                    totalConsideration: new CurrencyAndAmount(10000, "USD"),
                    properties: new Dictionary<string, PerpetualProperty>
                    {
                        {$"Transaction/{scope1}/Strategy", new PerpetualProperty($"Transaction/{scope1}/Strategy", new PropertyValue("Strategy2"))},
                        {$"Transaction/{scope2}/Country", new PerpetualProperty($"Transaction/{scope2}/Country", null)}
                    },
                    source: "Broker")
            };
            _transactionPortfoliosApi.UpsertTransactions(scope1, portfolioCode1, transactionRequest1);

            
            var transactionRequest2 = new List<TransactionRequest>
            {
                new TransactionRequest(
                    transactionId: Guid.NewGuid().ToString(),
                    type: "Buy",
                    instrumentIdentifiers: new Dictionary<string, string>
                    {
                        ["Instrument/default/LusidInstrumentId"] = luids[0]
                    },
                    transactionDate: effectiveAt,
                    settlementDate: effectiveAt,
                    units: 1000,
                    transactionPrice: new TransactionPrice(1, TransactionPrice.TypeEnum.Price),
                    totalConsideration: new CurrencyAndAmount(10*1000, "USD"),
                    properties: new Dictionary<string, PerpetualProperty>
                    {
                        {$"Transaction/{scope1}/Strategy", new PerpetualProperty($"Transaction/{scope1}/Strategy", new PropertyValue("Strategy1"))},
                    },
                    source: "Broker")
            };
            _transactionPortfoliosApi.UpsertTransactions(scope1, portfolioCode2, transactionRequest2);


            // Create document which has properties filled in.
            var document = $"luid,holdingccy,pfscope,pfid,strat,country,retYtD,another-key\n" +
                           $"{luids[0]},USD,{scope1},{portfolioCode1},Strategy1,England,0.123456,\"test1\"\n" +
                           $"{luids[0]},USD,{scope1},{portfolioCode1},Strategy2,,1,\"test2\"\n" +
                           $"CCY_USD,USD,{scope1},{portfolioCode1},Strategy1,England,10,\"test_ccy1\"\n" +
                           $"CCY_USD,USD,{scope1},{portfolioCode1},Strategy2,,100,\"test_ccy2\"\n";

            // Create and upsert a data mapping
            DataMapping dataMapping = new DataMapping(new List<DataDefinition>
            {
                new DataDefinition("UnitResult/Instrument/default/LusidInstrumentId", "luid", "string",
                    "PartOfUnique"),
                new DataDefinition("UnitResult/Holding/default/Currency", "holdingccy", "string", "PartOfUnique"),
                new DataDefinition("UnitResult/Portfolio/Id", "pfid", "string", "PartOfUnique"),
                new DataDefinition("UnitResult/Portfolio/Scope", "pfscope", "string", "PartOfUnique"),
                new DataDefinition($"UnitResult/Transaction/{scope1}/Strategy", "strat", "string", "PartOfUnique"),
                new DataDefinition($"UnitResult/Transaction/{scope2}/Country", "country", "string", "PartOfUnique"),
                new DataDefinition("UnitResult/Returns/YtD", "retYtD", "decimal", "Leaf"),
                new DataDefinition("UnitResult/SomeUserKey", "another-key", "string", "Leaf"),
            });
            var request = new CreateDataMapRequest(dataMapKey, dataMapping);
            _structuredResultDataApi.CreateDataMap(documentScope,
                new Dictionary<string, CreateDataMapRequest> {{"some-key", request}});

            StructuredResultData structuredResultData = new StructuredResultData("csv", "1.0.0", documentId, document, dataMapKey);
            StructuredResultDataId structResultDataId = new StructuredResultDataId("Client", documentId, effectiveAt, resultType);
            var upsertDataRequest = new UpsertStructuredResultDataRequest(structResultDataId, structuredResultData);
            _structuredResultDataApi.UpsertStructuredResultData(documentScope, new Dictionary<string, UpsertStructuredResultDataRequest>{{documentId, upsertDataRequest}});
            
            // Create result data key rule specifying 
            string resourceKey = "UnitResult/*";
            var resultDataKeyRule = new ResultDataKeyRule("Client", documentScope, documentId, resourceKey: resourceKey, documentResultType: resultType, resultKeyRuleType: ResultKeyRule.ResultKeyRuleTypeEnum.ResultDataKeyRule, quoteInterval: "1D");

            // Create and upsert a recipe with the result data key rule
            var pricingOptions = new PricingOptions {AllowAnyInstrumentsWithSecUidToPriceOffLookup = false, AllowPartiallySuccessfulEvaluation = true};
            var pricingContext = new PricingContext(null, null, pricingOptions, new List<ResultKeyRule>{resultDataKeyRule} );
            var configurationRecipe = new ConfigurationRecipe(documentScope, "recipe", new MarketContext(), pricingContext);
            var upsertRecipeRequest = new UpsertRecipeRequest(configurationRecipe, null);
            _recipeApi.UpsertConfigurationRecipe(upsertRecipeRequest);
            
            // Create a valuation request, sorting by portfolio id 
            var valuationRequest = new ValuationRequest(
                recipeId: new ResourceId(documentScope, "recipe"),
                metrics: new List<AggregateSpec>
                {
                    new AggregateSpec(TestDataUtilities.Luid, AggregateSpec.OpEnum.Value),
                    new AggregateSpec("Portfolio/Id", AggregateSpec.OpEnum.Value),
                    new AggregateSpec("Portfolio/Scope", AggregateSpec.OpEnum.Value),
                    new AggregateSpec($"Transaction/{scope1}/Strategy", AggregateSpec.OpEnum.Value),
                    new AggregateSpec($"Transaction/{scope2}/Country", AggregateSpec.OpEnum.Value),
                    new AggregateSpec("UnitResult/Returns/YtD", AggregateSpec.OpEnum.Value),
                    new AggregateSpec("UnitResult/SomeUserKey", AggregateSpec.OpEnum.Value),
                },
                portfolioEntityIds: new List<PortfolioEntityId>
                {
                    new PortfolioEntityId(scope1, portfolioCode1),
                    new PortfolioEntityId(scope1, portfolioCode2)
                },
                valuationSchedule: new ValuationSchedule(effectiveAt: effectiveAt),
                sort: new List<OrderBySpec>
                {
                    new OrderBySpec("Portfolio/Id", OrderBySpec.SortOrderEnum.Ascending)
                }
            );
    
            // Perform valuation and obtain results
            var results = _apiFactory.Api<IAggregationApi>().GetValuation(valuationRequest);

            
            // Checking the results are as expected.
            Assert.That(results.Data[0]["UnitResult/Returns/YtD"], Is.EqualTo(0.123456m));
            Assert.That(results.Data[1]["UnitResult/Returns/YtD"], Is.EqualTo(1m));
            Assert.That(results.Data[2]["UnitResult/Returns/YtD"], Is.EqualTo(10m));
            Assert.That(results.Data[3]["UnitResult/Returns/YtD"], Is.EqualTo(100m));
            Assert.That(results.Data[4]["UnitResult/Returns/YtD"], Is.EqualTo(null));
            Assert.That(results.Data[5]["UnitResult/Returns/YtD"], Is.EqualTo(null));
            Assert.That(results.Data[0]["UnitResult/SomeUserKey"], Is.EqualTo("test1"));
            Assert.That(results.Data[1]["UnitResult/SomeUserKey"], Is.EqualTo("test2"));
            Assert.That(results.Data[2]["UnitResult/SomeUserKey"], Is.EqualTo("test_ccy1"));
            Assert.That(results.Data[3]["UnitResult/SomeUserKey"], Is.EqualTo("test_ccy2"));
            Assert.That(results.Data[4]["UnitResult/SomeUserKey"], Is.EqualTo(null));
            Assert.That(results.Data[5]["UnitResult/SomeUserKey"], Is.EqualTo(null));
        }

        [Test]
        public void TestFindOrCalculate_PortfolioResult()
        {
            // Setting up basic parameters
            string documentId = "document-1";
            string documentScope = "document-scope-" + Guid.NewGuid();
            string resultType = "UnitResult/Portfolio";
            DataMapKey dataMapKey = new DataMapKey("1.0.0", "test-code");
            DateTimeOffset effectiveAt = new DateTimeOffset(2022, 01, 19, 0, 0, 0, 0, TimeSpan.Zero);

            // Create portfolios
            string scope = "scope-" + Guid.NewGuid();
            string portfolioCode = "pf";
            var portfolioRequest = new CreateTransactionPortfolioRequest(
                code: portfolioCode,
                displayName: $"Portfolio-{portfolioCode}",
                baseCurrency: "USD",
                created: effectiveAt
            );
            _transactionPortfoliosApi.CreatePortfolio(scope, portfolioRequest);
            

            // CREATE And UPSERT an instrument
            string instrumentName1 = "AClientName1";
            string instrumentName2 = "AClientName2";
            string clientInstId1 = "clientInstId1";
            string clientInstId2 = "clientInstId2";
            
            var instruments = new Dictionary<string, InstrumentDefinition>
            {
                {
                    "an-inst1", new InstrumentDefinition(instrumentName1,
                        new Dictionary<string, InstrumentIdValue>
                        {{
                            "ClientInternal", new InstrumentIdValue(clientInstId1)
                        }}
                    )
                },
                {
                    "an-inst2", new InstrumentDefinition(instrumentName2,
                        new Dictionary<string, InstrumentIdValue>
                        {{
                            "ClientInternal", new InstrumentIdValue(clientInstId2)
                        }}
                    )
                },
            };
            var upsertResponse = _instrumentsApi.UpsertInstruments(instruments);
            
            
            
            // Create transaction to book the instrument onto the portfolio via their LusidInstrumentId
            List<string> luids = upsertResponse.Values
                .Select(inst => inst.Value.LusidInstrumentId)
                .ToList();
            
            var transactionRequest1 = new List<TransactionRequest>
            {
                TestDataUtilities.BuildTransactionRequest(luids[0], 1000, 1m, "USD", effectiveAt, "Buy"),
            };
            _transactionPortfoliosApi.UpsertTransactions(scope, portfolioCode, transactionRequest1);

            
            var transactionRequest2 = new List<TransactionRequest>
            {
                TestDataUtilities.BuildTransactionRequest(luids[1], 1000, 10m, "USD", effectiveAt, "Buy")
            };
            _transactionPortfoliosApi.UpsertTransactions(scope, portfolioCode, transactionRequest2);
            
            
            var quoteRequest1 = TestDataUtilities.BuildQuoteRequest(
                luids[0],
                QuoteSeriesId.InstrumentIdTypeEnum.LusidInstrumentId,
                123m,
                "USD",
                TestDataUtilities.EffectiveAt);
            _quotesApi.UpsertQuotes(scope, quoteRequest1);

            var quoteRequest2 = TestDataUtilities.BuildQuoteRequest(
                luids[1],
                QuoteSeriesId.InstrumentIdTypeEnum.LusidInstrumentId,
                123m,
                "USD",
                TestDataUtilities.EffectiveAt);
            _quotesApi.UpsertQuotes(scope, quoteRequest2);

            
            // GENERATE and UPSERT a csv portfolio result
            // NB: the result does _not_ match the portfolio contents, this is to demonstrate/validate that entire calculation is elided
            string document = $"LusidInstrumentId,holding-ccy,pv,pv-ccy,some-user-defined-data\n" +
                              $"LUID_TEST0000,USD,100.0,USD,\"foo\"\n" +
                              $"LUID_TEST0001,USD,101.0,ZAR,\"bar\"";
            
            
            
            DataMapping dataMapping = new DataMapping(new List<DataDefinition>
            {
                new DataDefinition("Instrument/default/LusidInstrumentId", "LusidInstrumentId", "string",
                    "PartOfUnique"),
                new DataDefinition("Holding/default/Currency", "holding-ccy", "string", "PartOfUnique"),
                new DataDefinition("Valuation/PV", null, "Result0D", "CompositeLeaf"),
                new DataDefinition("Valuation/PV/Amount", "pv", "decimal", "Leaf"),
                new DataDefinition("Valuation/PV/Ccy", "pv-ccy", "string", "Leaf"),
                new DataDefinition("UnitResult/SomeUserData", "some-user-defined-data", "string", "Leaf"),
            });
            var request = new CreateDataMapRequest(dataMapKey, dataMapping);
            _structuredResultDataApi.CreateDataMap(documentScope,
                new Dictionary<string, CreateDataMapRequest> {{"some-key", request}});

            StructuredResultData structuredResultData = new StructuredResultData("csv", "1.0.0", documentId, document, dataMapKey);
            StructuredResultDataId structResultDataId = new StructuredResultDataId("Client", documentId, effectiveAt, resultType);
            var upsertDataRequest = new UpsertStructuredResultDataRequest(structResultDataId, structuredResultData);
            _structuredResultDataApi.UpsertStructuredResultData(documentScope, new Dictionary<string, UpsertStructuredResultDataRequest>{{documentId, upsertDataRequest}});
            
            // Create result data key rule specifying 
            var resultDataKeyRule = new PortfolioResultDataKeyRule("Client", documentScope, documentId,  portfolioCode : portfolioCode, portfolioScope : scope, resultKeyRuleType: ResultKeyRule.ResultKeyRuleTypeEnum.PortfolioResultDataKeyRule);

            // Create and upsert a recipe with the result data key rule
            var pricingOptions = new PricingOptions {AllowAnyInstrumentsWithSecUidToPriceOffLookup = false, AllowPartiallySuccessfulEvaluation = true};
            var pricingContext = new PricingContext(null, null, pricingOptions, new List<ResultKeyRule>{resultDataKeyRule} );
            var configurationRecipe = new ConfigurationRecipe(documentScope, "recipe", new MarketContext(), pricingContext);
            var upsertRecipeRequest = new UpsertRecipeRequest(configurationRecipe, null);
            _recipeApi.UpsertConfigurationRecipe(upsertRecipeRequest);
            
            var valuationRequest = new ValuationRequest(
                recipeId: new ResourceId(documentScope, "recipe"),
                metrics: new List<AggregateSpec>
                {
                    new AggregateSpec(TestDataUtilities.Luid, AggregateSpec.OpEnum.Value),
                    new AggregateSpec("Valuation/PV", AggregateSpec.OpEnum.Value),
                    new AggregateSpec("UnitResult/SomeUserData", AggregateSpec.OpEnum.Value)
                },
                portfolioEntityIds: new List<PortfolioEntityId>
                {
                    new PortfolioEntityId(scope, portfolioCode),
                },
                valuationSchedule: new ValuationSchedule(effectiveAt: effectiveAt));
    
            // Perform valuation and obtain results
            var results = _apiFactory.Api<IAggregationApi>().GetValuation(valuationRequest);
            
            Assert.That(results.Data[0]["Instrument/default/LusidInstrumentId"], Is.EqualTo("LUID_TEST0000"));
            Assert.That(results.Data[0]["Valuation/PV"], Is.EqualTo(100m));
            Assert.That(results.Data[0]["UnitResult/SomeUserData"], Is.EqualTo("foo"));
            Assert.That(results.Data[1]["Instrument/default/LusidInstrumentId"], Is.EqualTo("LUID_TEST0001"));
            Assert.That(results.Data[1]["Valuation/PV"], Is.EqualTo(101m));
            Assert.That(results.Data[1]["UnitResult/SomeUserData"], Is.EqualTo("bar"));
        }

        [Test]
        public void VirtualDocument_Compose_OverSeveralUpserts()
        {
            // Setting up basic parameters
            string scope = "scope-" + Guid.NewGuid();;
            string resultType = "UnitResult/Custom";
            string documentId = "document-1";
            DataMapKey dataMapKey1 = new DataMapKey("1.0.0", "datamap-1");
            DataMapKey dataMapKey2 = new DataMapKey("1.0.0", "datamap-2");
            DateTimeOffset effectiveAt = new DateTimeOffset(2022, 01, 19, 0, 0, 0, 0, TimeSpan.Zero);
            
            // Create a Data Map
            DataMapping dataMapping1 = new DataMapping(new List<DataDefinition>
            {
                new DataDefinition("UnitResult/Id1", "id1", "string", "PartOfUnique"),
                new DataDefinition("UnitResult/Id2", "id2", "string", "PartOfUnique"),
                new DataDefinition("UnitResult/Val1", "val1", "string", "Leaf"),
            });
            var request1 = new CreateDataMapRequest(dataMapKey1, dataMapping1);
            _structuredResultDataApi.CreateDataMap(scope, new Dictionary<string, CreateDataMapRequest> {{"some-key1", request1}});
            
            DataMapping dataMapping2 = new DataMapping(new List<DataDefinition>
            {
                new DataDefinition("UnitResult/Id1", "id1", "string", "PartOfUnique"),
                new DataDefinition("UnitResult/Id2", "id2", "string", "PartOfUnique"),
                new DataDefinition("UnitResult/Val2", "val2", "string", "Leaf"),
            });
            var request2 = new CreateDataMapRequest(dataMapKey2, dataMapping2);
            _structuredResultDataApi.CreateDataMap(scope, new Dictionary<string, CreateDataMapRequest> {{"some-key2", request2}});
            
            // UPSERT several documents with the same document key
            // document 1:
            //      id1, id2, val1
            //      a,   b,   val_ab
            //      a,   c,   val_ac
            // document 2:
            //      id1, id2, val1
            //      a,   d,   val_ad
            // document 3:
            //      id1, id2, val2
            //      a,   d,   val2_ad
            //
            // The expected virtual document should then look like:
            //      id1, id2, val1,   val2
            //      a,   b,   val_ab
            //      a,   c,   val_ac
            //      a,   d,   val_ad, val2_ad
            // Upsert Documents
            StructuredResultDataId structResultDataId = new StructuredResultDataId("Client", documentId, effectiveAt, resultType);
            
            string document1 = "id1,id2,val1\na,b,val_ab\na,c,val_ac";
            StructuredResultData structuredResultData1 = new StructuredResultData("csv", "1.0.0", documentId, document1, dataMapKey1);
            var upsertDataRequest1 = new UpsertStructuredResultDataRequest(structResultDataId, structuredResultData1);
            _structuredResultDataApi.UpsertStructuredResultData(scope, new Dictionary<string, UpsertStructuredResultDataRequest>{{documentId, upsertDataRequest1}});

            string document2 = "id1,id2,val1\na,d,val_ad";
            StructuredResultData structuredResultData2 = new StructuredResultData("csv", "1.0.0", documentId, document2, dataMapKey1);
            var upsertDataRequest2 = new UpsertStructuredResultDataRequest(structResultDataId, structuredResultData2);
            _structuredResultDataApi.UpsertStructuredResultData(scope, new Dictionary<string, UpsertStructuredResultDataRequest>{{documentId, upsertDataRequest2}});
            
            string document3 = "id1,id2,val2\na,d,val2_ad";
            StructuredResultData structuredResultData3 = new StructuredResultData("csv", "1.0.0", documentId, document3, dataMapKey2);
            var upsertDataRequest3 = new UpsertStructuredResultDataRequest(structResultDataId, structuredResultData3);
            _structuredResultDataApi.UpsertStructuredResultData(scope, new Dictionary<string, UpsertStructuredResultDataRequest>{{documentId, upsertDataRequest3}});

            var doc = _structuredResultDataApi.GetStructuredResultData(scope,
                new Dictionary<string, StructuredResultDataId>() {{"test", structResultDataId}});
            var result = _structuredResultDataApi.GetVirtualDocument(scope, new Dictionary<string, StructuredResultDataId>{{"Client", structResultDataId}}, effectiveAt);
            
            
        }
    }
}