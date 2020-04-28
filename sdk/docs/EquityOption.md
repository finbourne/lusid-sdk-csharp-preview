
# Lusid.Sdk.Model.EquityOption

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstrumentType** | **string** | Instrument type, must be property for JSON. | 
**Code** | **string** | The reset code of the option. | 
**StartDate** | **DateTimeOffset?** | The start date of the option. | 
**OptionMaturityDate** | **DateTimeOffset?** | The maturity date of the option. | 
**OptionSettlementDate** | **DateTimeOffset?** | The settlement date of the option. | 
**IsDeliveryNotCash** | **bool?** | True of the option is settled in cash false if delivery. | 
**IsCallNotPut** | **bool?** | True if the option is a call, false if the option is a put. | 
**Strike** | **decimal?** | The strike of the option. | 
**DomCcy** | **string** | The domestic currency. | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

