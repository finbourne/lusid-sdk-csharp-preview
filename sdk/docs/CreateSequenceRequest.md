# Lusid.Sdk.Model.CreateSequenceRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Code** | **string** | The code of the sequence definition to create | 
**Increment** | **long?** | The value to increment between each value in the sequence | [optional] 
**MinValue** | **long?** | The minimum value of the sequence | [optional] 
**MaxValue** | **long?** | The maximum value of the sequence | [optional] 
**Start** | **long?** | The start value of the sequence | [optional] 
**Cycle** | **bool** | Indicates if the sequence would start from minimun value once it reaches maximum value. If set to false, a failure would return if the sequence reaches maximum value. Default to false. | [optional] 
**Pattern** | **string** | The pattern to be used to generate next values in the sequence. Default to null. Please provide a null value until further notice. | [optional] 
**Links** | [**List&lt;Link&gt;**](Link.md) | Collection of links. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

