# Lusid.Sdk.Model.FilterInstrumentEvents
Instrument event query structure. The fields in the body act in and AND-wise fashion  for any instrument event query endpoint.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstrumentEventIds** | **List&lt;string&gt;** | The set of instrument events ids. | [optional] 
**CorporateActionSourceIds** | [**List&lt;ResourceId&gt;**](ResourceId.md) | The corporate action sources in which to search for events. | [optional] 
**LusidInstrumentIds** | **List&lt;string&gt;** | The lusid identifers for instruments on which the events apply. | [optional] 
**InstrumentScopes** | **List&lt;string&gt;** | The set of scopes in which the instruments of interest belong. | [optional] 
**InstrumentEventTypes** | **List&lt;string&gt;** | The subset of instrument event types. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

