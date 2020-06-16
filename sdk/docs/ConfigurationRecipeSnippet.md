
# Lusid.Sdk.Model.ConfigurationRecipeSnippet

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Scope** | **string** | The scope used when updating or inserting the Configuration Recipe snippet | 
**Code** | **string** | User given string name (code) to identify the recipe. | 
**AggregationOptions** | [**AggregationOptions**](AggregationOptions.md) |  | [optional] 
**ModelRules** | [**List&lt;VendorModelRule&gt;**](VendorModelRule.md) | The set of model rules that are available. There may be multiple rules for Vendors, but only one per model-instrument pair.  Which of these preference sets is used depends upon the model choice selection if specified, or failing that the global default model specification  in the options. | [optional] 
**PricingOptions** | [**PricingOptions**](PricingOptions.md) |  | [optional] 
**MarketRules** | [**List&lt;MarketDataKeyRule&gt;**](MarketDataKeyRule.md) | The set of rules that define how to resolve particular use cases. These can be relatively general or specific in nature.  Nominally any number are possible and will be processed in order where applicable. However, there is evidently a potential  for increased computational cost where many rules must be applied to resolve data. Ensuring that portfolios are structured in  such a way as to reduce the number of rules required is therefore sensible. | [optional] 
**MarketOptions** | [**MarketOptions**](MarketOptions.md) |  | [optional] 
**Recipe** | [**ConfigurationRecipe**](ConfigurationRecipe.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

