
# Lusid.Sdk.Model.UpdateDataTypeRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**TypeValueRange** | **string** | The available values are: Open, Closed | 
**DisplayName** | **string** |  | 
**Description** | **string** |  | 
**ValueType** | **string** | The available values are: String, Int, Decimal, DateTime, Boolean, Map, List, PropertyArray, Percentage, BenchmarkType, Code, Id, Uri, ArrayOfIds, ArrayOfTransactionAliases, ArrayofTransactionMovements, ArrayofUnits, StringArray, CurrencyAndAmount, TradePrice, UnitCreation, Currency, UserId, MetricValue, QuoteId, QuoteSeriesId, ResourceId, ResultValue, CutLocalTime, DateOrCutLabel, Transition, StructuredData, StructuredDataId, ConfigurationRecipe, ConfigurationRecipeSnippet, StructuredResultDataId, StructuredResultData, DataMapping, LusidInstrument, WeightedInstrument, Tenor, CdsProtectionDetailSpecification, FlowConventions, CdsFlowConventions, Conventions, LegDefinition, IndexConvention, FuturesContractDetails, OrderId, Order, Quote, WeekendMask, DateAttributes, CashFlowLeg, InstrumentDefinitionFormat | 
**AcceptableValues** | **List&lt;string&gt;** |  | [optional] 
**UnitSchema** | **string** | The available values are: NoUnits, Basic, Iso4217Currency | [optional] 
**AcceptableUnits** | [**List&lt;CreateUnitDefinition&gt;**](CreateUnitDefinition.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

