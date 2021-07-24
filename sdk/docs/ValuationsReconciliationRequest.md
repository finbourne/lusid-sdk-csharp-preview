
# Lusid.Sdk.Model.ValuationsReconciliationRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Left** | [**ValuationRequest**](ValuationRequest.md) |  | 
**Right** | [**ValuationRequest**](ValuationRequest.md) |  | 
**LeftToRightMapping** | [**List&lt;ReconciliationLeftRightAddressKeyPair&gt;**](ReconciliationLeftRightAddressKeyPair.md) | The mapping from property keys requested by left aggregation to property keys on right hand side | [optional] 
**PreserveKeys** | **List&lt;string&gt;** | List of keys to preserve (from rhs) in the diff. Used in conjunction with filtering/grouping | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

