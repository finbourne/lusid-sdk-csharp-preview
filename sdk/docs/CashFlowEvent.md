# Lusid.Sdk.Model.CashFlowEvent
Definition of a CashFlow event.  This is an event that describes the occurence of a cashflow and associated information.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstrumentEventType** | **string** | The Type of Event. The available values are: TransitionEvent, InformationalEvent, OpenEvent, CloseEvent, StockSplitEvent, BondDefaultEvent, CashDividendEvent, AmortisationEvent, CashFlowEvent, ExerciseEvent, ResetEvent | 
**Amount** | **decimal?** | The quantity (amount) that will be paid, if known. This value will be negative if it is paid, and positive  if it is received. | [optional] 
**Currency** | **string** | The payment currency of the cash flow. | 
**EventType** | **string** | What type of internal event does this represent; coupon, principal, premium etc. | [readonly] 
**EventStatus** | **string** | What is the event status, is it a known (ie historic) or unknown (ie projected) event? | 
**PaymentDate** | **DateTimeOffset** | The date on which the cashflow is scheduled to be paid into the recipient&#39;s bank account. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

