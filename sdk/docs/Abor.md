# Lusid.Sdk.Model.Abor
An Abor entity.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Href** | **string** | The specific Uniform Resource Identifier (URI) for this resource at the requested effective and asAt datetime. | [optional] 
**Id** | [**ResourceId**](ResourceId.md) |  | 
**DisplayName** | **string** | The given name for the Abor. | [optional] 
**Description** | **string** | The description for the Abor. | [optional] 
**PortfolioIds** | [**List&lt;PortfolioEntityId&gt;**](PortfolioEntityId.md) | The list with the portfolio ids which are part of the Abor. For now the only supported value is SinglePortfolio. | 
**AborConfigurationId** | [**ResourceId**](ResourceId.md) |  | [optional] 
**Properties** | [**Dictionary&lt;string, Property&gt;**](Property.md) | Properties to add to the Abor. | [optional] 
**Version** | [**Version**](Version.md) |  | [optional] 
**Links** | [**List&lt;Link&gt;**](Link.md) | Collection of links. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

