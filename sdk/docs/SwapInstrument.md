# Lusid.Sdk.Model.SwapInstrument
IL Swap Instrument; Lusid-ibor internal representation of a swap instrument                A swap is the exchange of two sets of cashflows, occurring at one or more dates in one or more currencies.  These may include a notional exchange at the start and, or, maturity of the trade. Depending upon the choice of  payment currency, payment frequency and so on they can be used to match sets of future obligations
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**StartDate** | **DateTimeOffset** | Starting date of the swap | 
**MaturityDate** | **DateTimeOffset** | Maturity date of the swap | 
**Legs** | [**List&lt;InstrumentLeg&gt;**](InstrumentLeg.md) | True if the swap is amortizing | 
**Notional** | **decimal** | The notional. | 
**IsAmortizing** | **bool** | True if the swap is amortizing | 
**NotionalExchangeType** | **string** | True notional exchange type. | 
**InstrumentType** | **string** | Instrument type, must be property for JSON. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

