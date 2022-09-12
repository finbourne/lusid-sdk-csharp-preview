# Lusid.Sdk.Model.QuoteDependencyAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**MarketIdentifier** | **string** | Type of the code identifying the asset, e.g. ISIN or CUSIP | 
**Code** | **string** | The code identifying the corresponding equity, e.g. US0378331005 if the MarketIdentifier was set to ISIN | 
**Date** | **DateTimeOffset** | The effectiveAt of the quote for the identified entity. | 
**DependencyType** | **string** | The available values are: Opaque, Cash, Discounting, EquityCurve, EquityVol, Fx, FxForwards, FxVol, IndexProjection, IrVol, Quote, Vendor | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

