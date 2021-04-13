# Lusid.Sdk.Model.Allocation
An Allocation of a certain quantity of a specific instrument against an originating  Order.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | [**ResourceId**](ResourceId.md) |  | 
**AllocatedOrderId** | [**ResourceId**](ResourceId.md) |  | 
**PortfolioId** | [**ResourceId**](ResourceId.md) |  | 
**Quantity** | **int** | The quantity of given instrument allocated. | 
**InstrumentIdentifiers** | **Dictionary&lt;string, string&gt;** | The instrument allocated. | 
**Version** | [**Version**](Version.md) |  | [optional] 
**Properties** | [**Dictionary&lt;string, PerpetualProperty&gt;**](PerpetualProperty.md) | Client-defined properties associated with this allocation. | [optional] 
**LusidInstrumentId** | **string** | The LUSID instrument id for the instrument allocated. | 
**Links** | [**List&lt;Link&gt;**](Link.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

