
# Lusid.Sdk.Model.DataMapping

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**DataFieldNameMappings** | [**Dictionary&lt;string, DataDefinition&gt;**](DataDefinition.md) | A map from LUSID item keys to data definitions that define the names, types and degree of uniqueness of data provided to LUSID in structured data stores. | [optional] 
**Version** | **string** | The version of the mappings. It is possible that a client will wish to update mappings over time. The version identifies the MAJOR.MINOR.PATCH version  of the mappings that the client assigns it. | [optional] 
**Code** | **string** | A unique name to semantically identify the mapping set. | [optional] 
**Links** | [**List&lt;Link&gt;**](Link.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

