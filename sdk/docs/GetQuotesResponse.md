
# Lusid.Sdk.Model.GetQuotesResponse

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Href** | **string** |  | [optional] 
**Values** | [**Dictionary&lt;string, Quote&gt;**](Quote.md) | The collection of requested quote series with their latest values | [optional] 
**NotFound** | [**Dictionary&lt;string, ErrorDetail&gt;**](ErrorDetail.md) | If any quotes could not be retrieved, they will be listed in &#39;NotFound&#39;, along  with a reason why. | [optional] 
**Failed** | [**Dictionary&lt;string, ErrorDetail&gt;**](ErrorDetail.md) | If any quotes could not be requested, due to errors in the structure of the   QuoteSeriesId, they will be listed in &#39;Failed&#39;, along with the reason(s) why. | [optional] 
**Links** | [**List&lt;Link&gt;**](Link.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

