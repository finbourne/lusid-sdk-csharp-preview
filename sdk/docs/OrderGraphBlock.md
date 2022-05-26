# Lusid.Sdk.Model.OrderGraphBlock

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Block** | [**Block**](Block.md) |  | 
**OrderIds** | [**List&lt;ResourceId&gt;**](ResourceId.md) | Identifiers for all the orders in this block - DEPRECATED: see Ordered. | 
**PlacementIds** | [**List&lt;ResourceId&gt;**](ResourceId.md) | Identifiers of all placements for the block - DEPRECATED: see Placed. | 
**AllocationIds** | [**List&lt;ResourceId&gt;**](ResourceId.md) | Identifiers for all allocations of placements to orders in the block - DEPRECATED: see Allocated. | 
**ExecutionIds** | [**List&lt;ResourceId&gt;**](ResourceId.md) | Identifiers of all executions against placements in the block - DEPRECATED: see Executed. | 
**Ordered** | [**OrderGraphBlockOrderSynopsis**](OrderGraphBlockOrderSynopsis.md) |  | 
**Placed** | [**OrderGraphBlockPlacementSynopsis**](OrderGraphBlockPlacementSynopsis.md) |  | 
**Executed** | [**OrderGraphBlockExecutionSynopsis**](OrderGraphBlockExecutionSynopsis.md) |  | 
**Allocated** | [**OrderGraphBlockAllocationSynopsis**](OrderGraphBlockAllocationSynopsis.md) |  | 
**DerivedState** | **string** | A simple description of the overall state of a block. | 
**DerivedComplianceState** | **string** | The overall compliance state of a block, derived from the block&#39;s orders. Possible values are Pending, Failed, and Passed. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

