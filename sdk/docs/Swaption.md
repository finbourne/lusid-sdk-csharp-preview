
# Lusid.Sdk.Model.Swaption

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstrumentType** | **string** | Instrument type, must be property for JSON. | 
**StartDate** | **DateTimeOffset?** | The start date of the instrument. This is normally synonymous with the trade-date. | 
**Swap** | [**SwapInstrument**](SwapInstrument.md) |  | 
**PayOrReceiveFixed** | **string** | True if on exercise the holder of the option enters the swap paying fixed, false if floating. | 
**DeliveryMethod** | **string** | How does the option settle | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

