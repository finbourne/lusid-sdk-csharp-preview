# Lusid.Sdk.Model.TransitionEvent
A generic event with event consequences modeled as transitions.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstrumentEventType** | **string** | The Type of Event. The available values are: TransitionEvent, InternalEvent, CouponEvent, OpenEvent, CloseEvent | 
**AnnouncementDate** | **DateTimeOffset** | The announcement date of the corporate action | [optional] 
**ExDate** | **DateTimeOffset** | The ex date of the corporate action | [optional] 
**RecordDate** | **DateTimeOffset** | The record date of the corporate action | [optional] 
**PaymentDate** | **DateTimeOffset** | The payment date of the corporate action | [optional] 
**Transitions** | [**List&lt;CorporateActionTransitionRequest&gt;**](CorporateActionTransitionRequest.md) | The transitions that result from this corporate action | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

