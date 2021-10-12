# Lusid.Sdk.Model.FloatingLeg
representation of a floating rates leg

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstrumentType** | **string** | The available values are: QuotedSecurity, InterestRateSwap, FxForward, Future, ExoticInstrument, FxOption, CreditDefaultSwap, InterestRateSwaption, Bond, EquityOption, FixedLeg, FloatingLeg, BespokeCashFlowsLeg, Unknown, TermDeposit, ContractForDifference, EquitySwap, CashPerpetual, CapFloor, CashSettled, CdsIndex, Basket, FundingLeg, CrossCurrencySwap, FxSwap, ForwardRateAgreement, SimpleInstrument, Repo, Equity | 
**StartDate** | **DateTimeOffset** |  | 
**MaturityDate** | **DateTimeOffset** |  | 
**LegDefinition** | [**LegDefinition**](LegDefinition.md) |  | 
**Notional** | **decimal** | scaling factor to apply to leg quantities. | 
**Overrides** | [**FixedLegAllOfOverrides**](FixedLegAllOfOverrides.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

