# Lusid.Sdk.Model.OrderGraphPlacement

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Placement** | [**Placement**](Placement.md) |  | 
**BlockId** | [**ResourceId**](ResourceId.md) |  | 
**OrderIds** | [**List&lt;ResourceId&gt;**](ResourceId.md) | Identifiers for all orders in the block - DEPRECATED: see Ordered. | 
**AllocationIds** | [**List&lt;ResourceId&gt;**](ResourceId.md) | Identifiers for all allocations relating to this placement - DEPRECATED: see Allocated. | 
**ExecutionIds** | [**List&lt;ResourceId&gt;**](ResourceId.md) | Identifiers of all executions against this placement - DEPRECATED: see Executed. | 
**Ordered** | [**OrderGraphPlacementOrderSynopsis**](OrderGraphPlacementOrderSynopsis.md) |  | 
**Placed** | [**OrderGraphPlacementPlacementSynopsis**](OrderGraphPlacementPlacementSynopsis.md) |  | 
**Executed** | [**OrderGraphPlacementExecutionSynopsis**](OrderGraphPlacementExecutionSynopsis.md) |  | 
**Allocated** | [**OrderGraphPlacementAllocationSynopsis**](OrderGraphPlacementAllocationSynopsis.md) |  | 
**DerivedState** | **string** | A simple description of the overall state of a placement. | 
**CalculatedAveragePrice** | **decimal?** | Average price realised on executions for a given placement | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

