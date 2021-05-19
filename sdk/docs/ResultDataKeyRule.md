# Lusid.Sdk.Model.ResultDataKeyRule
A rule that describes how we resolve (unit) result data.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ResourceKey** | **string** | The result data key that identifies the address pattern that this is a rule for | 
**Supplier** | **string** | the result resource supplier (where the data comes from) | 
**DataScope** | **string** | which is the scope in which the data should be found | 
**DocumentCode** | **string** | document code that defines which document is desired | 
**QuoteInterval** | **string** | Shorthand for the time interval used to select result data. | [optional] 
**AsAt** | **DateTimeOffset?** | The AsAt predicate specification. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

