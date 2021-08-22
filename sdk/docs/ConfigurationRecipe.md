
# Lusid.Sdk.Model.ConfigurationRecipe

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Scope** | **string** | The scope used when updating or inserting the Configuration Recipe. | 
**Code** | **string** | User given string name (code) to identify the recipe. | 
**Market** | [**MarketContext**](MarketContext.md) |  | [optional] 
**Pricing** | [**PricingContext**](PricingContext.md) |  | [optional] 
**Aggregation** | [**AggregationContext**](AggregationContext.md) |  | [optional] 
**InheritedRecipes** | [**List&lt;ResourceId&gt;**](ResourceId.md) | A list of parent recipes (scope,code) that can be used to share functionality between recipes. For instance one might use common recipes to set up  pricing for individual asset classes, e.g. rates or credit, and then combine them into a single recipe to be used by an exotics desk in conjunction with  some overrides that it requires for models or other pricing options. | [optional] 
**Description** | **string** | User can assign a description to understand more humanly the recipe. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

