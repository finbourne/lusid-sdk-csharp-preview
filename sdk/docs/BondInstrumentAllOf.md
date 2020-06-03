
# Lusid.Sdk.Model.BondInstrumentAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**StartDate** | **DateTimeOffset?** |  | 
**MaturityDate** | **DateTimeOffset?** |  | 
**DomCcy** | **string** |  | 
**CouponRate** | **decimal?** | simple coupon rate. | 
**Principal** | **decimal?** | The face-value or principal for the bond at outset.              This might be reduced through its lifetime in the event of amortization or similar. | 
**FlowConventions** | [**FlowConventions**](FlowConventions.md) |  | 
**Identifiers** | **Dictionary&lt;string, string&gt;** | set of market identifiers along with their types, e.g. ISIN, CUSIP, SEDOL. | [optional] 
**InstrumentType** | **string** | Instrument type, must be property for JSON. | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

