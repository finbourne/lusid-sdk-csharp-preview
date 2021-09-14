# Lusid.Sdk.Model.CustomEntityResponse

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Href** | **string** | The specific Uniform Resource Identifier (URI) for this resource at the requested effective and asAt datetime. | [optional] 
**EntityType** | **string** | The EntityType to be used when relations are created to the CustomEntity | 
**CustomEntityId** | **string** | A unique identifier for the CustomEntity | 
**Version** | [**Version**](Version.md) |  | 
**DisplayName** | **string** | The display name of the CustomEntity | 
**Description** | **string** | The description of the CustomEntity | [optional] 
**Identifiers** | [**List&lt;CustomEntityIdResponse&gt;**](CustomEntityIdResponse.md) | A collection of CustomEntityIdentifiers that can identify the CustomEntity | 
**Fields** | [**List&lt;CustomEntityField&gt;**](CustomEntityField.md) | A collection of CustomEntityFields that decorate the CustomEntity | 
**EffectiveRange** | [**DateRange**](DateRange.md) |  | 
**AsAtRange** | [**DateRange**](DateRange.md) |  | 
**Links** | [**List&lt;Link&gt;**](Link.md) | Collection of links. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

