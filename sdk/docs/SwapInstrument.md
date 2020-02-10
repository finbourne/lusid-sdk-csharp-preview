
# Lusid.Sdk.Model.SwapInstrument

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**StartDate** | **DateTimeOffset?** | Starting date of the swap | 
**MaturityDate** | **DateTimeOffset?** | Maturity date of the swap | 
**Legs** | [**List&lt;InstrumentLeg&gt;**](InstrumentLeg.md) | True if the swap is amortizing | 
**Notional** | **decimal?** | The notional. | 
**IsAmortizing** | **bool?** | True if the swap is amortizing | 
**NotionalExchangeType** | **string** | True notional exchange type. | 
**InstrumentType** | **string** | Instrument type, must be property for JSON. | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

