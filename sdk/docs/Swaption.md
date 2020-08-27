
# Lusid.Sdk.Model.Swaption

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstrumentType** | **string** | The available values are: QuotedSecurity, InterestRateSwap, FxForward, Future, Exotic, FxOption, CreditDefaultSwap, InterestRateSwaption, Bond, EquityOption, FixedRateLeg, FloatingRateLeg, BespokeCashflowLeg, Unknown | 
**StartDate** | **DateTimeOffset?** | The start date of the instrument. This is normally synonymous with the trade-date. | 
**Swap** | [**SwapInstrument**](SwapInstrument.md) |  | 
**PayOrReceiveFixed** | **string** | The available values are: NotDefined, Pay, Receive | 
**DeliveryMethod** | **string** | The available values are: Cash, Physical | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

