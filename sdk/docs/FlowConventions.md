
# Lusid.Sdk.Model.FlowConventions

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Currency** | **string** | Currency of the flow convention. | 
**PaymentFrequency** | [**Tenor**](Tenor.md) |  | 
**DayCountConvention** | **string** | when calculating the fraction of a year between two dates, what convention is used to represent the number of days in a year  and difference between them. | 
**RollConvention** | **string** | when generating a set of dates, what convention should be used for adjusting dates that coincide with a non-business day. | 
**HolidayCalendars** | **List&lt;string&gt;** | An array of strings denoting holiday calendars that apply to generation and payment. | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

