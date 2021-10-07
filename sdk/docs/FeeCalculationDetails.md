# Lusid.Sdk.Model.FeeCalculationDetails

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**RuleType** | **string** | Rule Type | 
**RuleInformation** | **string** | Rule Sub Type | 
**AdditionalInformation** | **Dictionary&lt;string, string&gt;** | Other property keys populated for the fee | 
**PropertyKey** | **string** | The property key which uniquely identifies the property. The format for the property key is {domain}/{scope}/{code}, e.g. &#39;Portfolio/Manager/Id&#39;. | 
**Fee** | [**CalculationInfo**](CalculationInfo.md) |  | 
**MaxFee** | [**CalculationInfo**](CalculationInfo.md) |  | [optional] 
**MinFee** | [**CalculationInfo**](CalculationInfo.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

