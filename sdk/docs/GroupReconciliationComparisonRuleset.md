# Lusid.Sdk.Model.GroupReconciliationComparisonRuleset

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | [**ResourceId**](ResourceId.md) |  | 
**DisplayName** | **string** | The name of the ruleset | 
**ReconciliationType** | **string** | The type of reconciliation to perform. \&quot;Holding\&quot; | \&quot;Transaction\&quot; | \&quot;Valuation\&quot; | 
**CoreAttributeRules** | [**List&lt;GroupReconciliationCoreAttributeRule&gt;**](GroupReconciliationCoreAttributeRule.md) | The core comparison rules | 
**AggregateAttributeRules** | [**List&lt;GroupReconciliationAggregateAttributeRule&gt;**](GroupReconciliationAggregateAttributeRule.md) | The aggregate comparison rules | 
**Href** | **string** | The specific Uniform Resource Identifier (URI) for this resource at the requested effective and asAt datetime. | [optional] 
**Version** | [**Version**](Version.md) |  | [optional] 
**Links** | [**List&lt;Link&gt;**](Link.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

