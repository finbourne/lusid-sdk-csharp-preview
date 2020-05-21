
# Lusid.Sdk.Model.SwaptionAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**StartDate** | **DateTimeOffset?** | The start date of the instrument. This is normally synonymous with the trade-date. | 
**Swap** | [**SwapInstrument**](SwapInstrument.md) |  | 
**PayOrReceiveFixed** | **string** | True if on exercise the holder of the option enters the swap paying fixed, false if floating. | 
**DeliveryMethod** | **string** | How does the option settle | 
**InstrumentType** | **string** | Instrument type, must be property for JSON. | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

