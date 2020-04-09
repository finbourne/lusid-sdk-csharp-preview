
# Lusid.Sdk.Model.SwaptionAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**StartDate** | **DateTimeOffset?** |  | 
**IsPayerNotReceiver** | **bool?** | True if on exercise the holder of the option enters the swap paying fixed, false if floating. | 
**IsDeliveryNotCash** | **bool?** | True of the option is settled in cash false if by delivery of the swap. | 
**Swap** | [**LusidInstrument**](LusidInstrument.md) |  | 
**InstrumentType** | **string** | Instrument type, must be property for JSON. | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

