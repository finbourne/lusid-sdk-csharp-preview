# Lusid.Sdk.Model.ReconciliationLine
In evaluating a left and right hand side holding or valuation set, two data records result. These are then compared based on a set of  rules. This results in either a match or failure to match. If there is a match both left and right will be present, otherwise one will not.  A difference will be present if a match was calculated.  The options used in comparison may result in elision of results where an exact or tolerable match is made.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Left** | [**IDataRecord**](IDataRecord.md) |  | [optional] 
**Right** | [**IDataRecord**](IDataRecord.md) |  | [optional] 
**Difference** | [**IDataRecord**](IDataRecord.md) |  | [optional] 
**ResultComparison** | [**IDataRecord**](IDataRecord.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

