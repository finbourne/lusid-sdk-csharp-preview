
# Lusid.Sdk.Model.IndexConvention

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**FixingReference** | **string** | The reference rate name for fixings | 
**PublicationDayLag** | **int?** | Number of days between spot and publication of the rate. | 
**PaymentTenor** | **string** | The tenor of the payment. For an OIS index this is always 1 day. For other indices, e.g. LIBOR it will have a variable tenor typically between 1 day and 1 year. | 
**DayCountConvention** | **string** | The available values are: Actual360, Act360, MoneyMarket, Actual365, Act365, Thirty360, ThirtyU360, Bond, ThirtyE360, EuroBond, ActAct, ActualActual, ActActIsda, ActActIsma, ActActIcma, Invalid | 
**Currency** | **string** | Currency of the index convention. | 
**Scope** | **string** | The scope used when updating or inserting the convention. | [optional] 
**Code** | **string** | The code of the convention. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

