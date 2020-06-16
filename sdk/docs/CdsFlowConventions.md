
# Lusid.Sdk.Model.CdsFlowConventions

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**RollFrequency** | [**Tenor**](Tenor.md) |  | 
**Currency** | **string** | Currency of the flow convention. | 
**PaymentFrequency** | [**Tenor**](Tenor.md) |  | 
**DayCountConvention** | **string** | The available values are: Actual360, Act360, MoneyMarket, Actual365, Act365, Thirty360, ThirtyU360, Bond, ThirtyE360, EuroBond, ActAct, ActualActual, ActActIsda, Invalid | 
**RollConvention** | **string** | The available values are: NoAdjustment, None, Previous, P, Following, F, ModifiedPrevious, MP, ModifiedFollowing, MF, EndOfMonth, EOM, EndOfMonthPrevious, EOMP, EndOfMonthFollowing, EOMF, Invalid | 
**HolidayCalendars** | **List&lt;string&gt;** | An array of strings denoting holiday calendars that apply to generation and payment. | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

