
# Lusid.Sdk.Model.MarketOptions

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**DefaultSupplier** | **string** | The available values are: DataScope, Lusid, Isda, Client, Edi, TraderMade, FactSet | [optional] 
**DefaultInstrumentCodeType** | **string** | The available values are: LusidInstrumentId, Figi, RIC, QuotePermId, Isin, CurrencyPair | [optional] 
**DefaultScope** | **string** | For default rules, which scope should data be searched for in | [optional] 
**AttemptToInferMissingFx** | **bool?** | if true will calculate a missing Fx pair (e.g. THBJPY) from the inverse JPYTHB or from standardised pairs against USD, e.g. THBUSD and JPYUSD | [optional] 
**ManifestLevelOfDetail** | **string** | The available values are: None, Full | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

