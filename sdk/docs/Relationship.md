# Lusid.Sdk.Model.Relationship
Representation of a Relationship between a requested entity with the stated entity as RelatedEntityId

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Version** | [**Version**](Version.md) |  | [optional] 
**RelationshipDefinitionId** | [**ResourceId**](ResourceId.md) |  | 
**RelatedEntity** | [**RelatedEntity**](RelatedEntity.md) |  | 
**TraversalDirection** | **string** | Direction of relationship betwen the requested entity and related entity. This can be &#39;In&#39; or &#39;Out&#39;. Read more about relationships traversal direction in LUSID Knowledge Base here https://support.lusid.com/relationships. | 
**TraversalDescription** | **string** | Description of the relationship based on relationship&#39;s traversal direction. If &#39;TraversalDirection&#39; is &#39;Out&#39;, this description would be &#39;OutwardDescription&#39; from the associated relationship definition. If &#39;TraversalDirection&#39; is &#39;In&#39;, this description would be &#39;InwardDescription&#39; from the associated relationship definition. | 
**EffectiveFrom** | **DateTimeOffset** | The effective datetime from which the relationship is valid. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

