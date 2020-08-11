
# Lusid.Sdk.Model.FlowConventions

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Scope** | **string** | The scope used when updating or inserting the convention. | [optional] 
**Code** | **string** | The code of the convention. | [optional] 
**Currency** | **string** | Currency of the flow convention. | 
**PaymentFrequency** | **string** | When generating a multiperiod flow, or when the maturity of the flow is not given but the start date is,  the tenor is the time-step from the anchor-date to the nominal maturity of the flow prior to any adjustment. | 
**DayCountConvention** | **string** | The available values are: Actual360, Act360, MoneyMarket, Actual365, Act365, Thirty360, ThirtyU360, Bond, ThirtyE360, EuroBond, ActAct, ActualActual, ActActIsda, ActActIsma, ActActIcma, Invalid | 
**RollConvention** | **string** | The available values are: NoAdjustment, None, Previous, P, Following, F, ModifiedPrevious, MP, ModifiedFollowing, MF, EndOfMonth, EOM, EndOfMonthPrevious, EOMP, EndOfMonthFollowing, EOMF, Invalid | 
**HolidayCalendars** | **List&lt;string&gt;** | An array of strings denoting holiday calendars that apply to generation and payment. | 
**SettleDays** | **int?** | Number of Good Business Days between the trade date and the effective or settlement date of the instrument. | 
**ResetDays** | **int?** | The number of Good Business Days between determination and payment of reset. | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

