
# Lusid.Sdk.Model.FxOption

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstrumentType** | **string** | The available values are: QuotedSecurity, InterestRateSwap, FxForward, Future, Exotic, FxOption, CreditDefaultSwap, InterestRateSwaption, Bond, EquityOption, FixedRateLeg, FloatingRateLeg, BespokeCashflowLeg, Unknown | 
**StartDate** | **DateTimeOffset?** | The start date of the option. | 
**OptionMaturityDate** | **DateTimeOffset?** | The maturity date of the option. | 
**OptionSettlementDate** | **DateTimeOffset?** | The settlement date of the option. | 
**IsDeliveryNotCash** | **bool?** | True of the option is settled in cash false if delivery. | 
**IsCallNotPut** | **bool?** | True if the option is a call, false if the option is a put. | 
**Strike** | **decimal?** | The strike of the option. | 
**DomCcy** | **string** | The domestic currency of the FX. | 
**FgnCcy** | **string** | The foreign currency of the FX. | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

