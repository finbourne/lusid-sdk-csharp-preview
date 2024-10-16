# Lusid.Sdk.Model.TaxRuleSet

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | [**ResourceId**](ResourceId.md) |  | 
**DisplayName** | **string** | A user-friendly name | 
**Description** | **string** | A description of what this rule set is for | 
**OutputPropertyKey** | **string** | The property key that this rule set will write to | 
**Rules** | [**List&lt;TaxRule&gt;**](TaxRule.md) | The rules of this rule set, which stipulate what rate to apply (i.e. write to the OutputPropertyKey) under certain conditions | 
**Version** | [**Version**](Version.md) |  | [optional] 
**Links** | [**List&lt;Link&gt;**](Link.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

