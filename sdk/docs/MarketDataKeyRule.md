
# Lusid.Sdk.Model.MarketDataKeyRule

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Key** | **string** | The market data key pattern which this is a rule for. A dot separated string (A.B.C.D.*) | 
**Supplier** | **string** | The market data supplier (where the data comes from) | 
**DataScope** | **string** | The scope in which the data should be found when using this rule. | 
**QuoteType** | **string** | The available values are: Price, Spread, Rate, LogNormalVol, NormalVol, ParSpread, IsdaSpread, Upfront | 
**Field** | **string** | The conceptual qualification for the field, such as bid, mid, or ask.   The field must be one of a defined set for the given supplier, in the same way as it  is for the Finbourne.WebApi.Interface.Dto.Quotes.QuoteSeriesId | 
**QuoteInterval** | **string** | Shorthand for the time interval used to select market data. | [optional] 
**AsAt** | **DateTimeOffset?** | The AsAt predicate specification. | [optional] 
**PriceSource** | **string** | The source of the quote. For a given provider/supplier of market data there may be an additional qualifier, e.g. the exchange or bank that provided the quote | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

