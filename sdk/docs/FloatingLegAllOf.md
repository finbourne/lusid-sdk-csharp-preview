
# Lusid.Sdk.Model.FloatingLegAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**StartDate** | **DateTimeOffset?** |  | 
**MaturityDate** | **DateTimeOffset?** |  | 
**LegDefinition** | [**LegDefinition**](LegDefinition.md) |  | 
**Notional** | **decimal?** | scaling factor to apply to leg quantities. | 
**Overrides** | [**FixedLegAllOfOverrides**](FixedLegAllOfOverrides.md) |  | [optional] 
**InstrumentType** | **string** | The available values are: QuotedSecurity, InterestRateSwap, FxForward, Future, ExoticInstrument, FxOption, CreditDefaultSwap, InterestRateSwaption, Bond, EquityOption, FixedLeg, FloatingLeg, BespokeCashflowLeg, Unknown, TermDeposit, ContractForDifference, EquitySwap, CashPerpetual, CashSettled, CdsIndex, Basket | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

