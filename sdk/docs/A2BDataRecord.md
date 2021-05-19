# Lusid.Sdk.Model.A2BDataRecord
A2B Record - shows values on, and changes between two dates: A and B

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstrumentUid** | **string** | The unqiue Lusid Instrument Id (LUID) of the instrument that the holding is in. | [optional] 
**SubHoldingKeys** | [**Dictionary&lt;string, PerpetualProperty&gt;**](PerpetualProperty.md) | The sub-holding properties which identify the holding. Each property will be from the &#39;Transaction&#39; domain. These are configured when a transaction portfolio is created. | [optional] 
**Currency** | **string** | The holding currency. | [optional] 
**TransactionId** | **string** | The unique identifier for the transaction. | [optional] 
**Start** | [**A2BCategory**](A2BCategory.md) |  | [optional] 
**Flows** | [**A2BCategory**](A2BCategory.md) |  | [optional] 
**Gains** | [**A2BCategory**](A2BCategory.md) |  | [optional] 
**Carry** | [**A2BCategory**](A2BCategory.md) |  | [optional] 
**End** | [**A2BCategory**](A2BCategory.md) |  | [optional] 
**Properties** | [**Dictionary&lt;string, Property&gt;**](Property.md) | The properties which have been requested to be decorated onto the holding. These will be from the &#39;Instrument&#39; domain. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

