# Lusid.Sdk.Model.DiaryEntry

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Href** | **string** | The specific Uniform Resource Identifier (URI) for this resource at the requested effective and asAt datetime. | [optional] 
**AborId** | [**ResourceId**](ResourceId.md) |  | [optional] 
**DiaryEntryCode** | **string** | The code of the diary entry. | [optional] 
**Type** | **string** | The type of the diary entry. | 
**Name** | **string** | The name of the diary entry. | [optional] 
**Status** | **string** | The status of the diary entry. Defaults to &#39;Undefined&#39;. | 
**EffectiveAt** | **DateTimeOffset** | The effective time of the diary entry. | 
**QueryAsAt** | **DateTimeOffset** | The query time of the diary entry. Defaults to latest. | [optional] 
**PreviousEntryTime** | **DateTimeOffset** | The entry time of the previous diary entry. | [optional] 
**Properties** | [**Dictionary&lt;string, Property&gt;**](Property.md) | A set of properties for the diary entry. | [optional] 
**Version** | [**Version**](Version.md) |  | [optional] 
**Links** | [**List&lt;Link&gt;**](Link.md) | Collection of links. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

