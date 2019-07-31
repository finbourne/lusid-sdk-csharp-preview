
# Lusid.Sdk.Model.AnnulQuotesResponse

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Href** | **string** |  | [optional] 
**Values** | **Dictionary&lt;string, DateTimeOffset?&gt;** | The collection of quotes requested to be annulled with the asAt time   at which they were annulled | [optional] 
**Failed** | [**Dictionary&lt;string, ErrorDetail&gt;**](ErrorDetail.md) | If any quotes could not be annulled, they will be listed in &#39;Failed&#39;, along  with a reason why. | [optional] 
**Links** | [**List&lt;Link&gt;**](Link.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

