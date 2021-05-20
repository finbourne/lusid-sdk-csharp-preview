# Lusid.Sdk.Model.IndexConvention
A set of conventions that describe the conventions for calculation of payments made on rates interbank lending and similar.  Based on ISDA 2006 conventions and similar documentation. Please see the knowledge base for further documentation.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**FixingReference** | **string** | The reference rate name for fixings | 
**PublicationDayLag** | **int** | Number of days between spot and publication of the rate. | 
**PaymentTenor** | **string** | The tenor of the payment. For an OIS index this is always 1 day. For other indices, e.g. LIBOR it will have a variable tenor typically between 1 day and 1 year. | 
**DayCountConvention** | **string** | when calculating the fraction of a year between two dates, what convention is used to represent the number of days in a year              and difference between them. | 
**Currency** | **string** | Currency of the index convention. | 
**Scope** | **string** | The scope used when updating or inserting the convention. | [optional] 
**Code** | **string** | The code of the convention. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

