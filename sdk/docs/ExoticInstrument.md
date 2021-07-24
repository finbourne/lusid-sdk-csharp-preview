
# Lusid.Sdk.Model.ExoticInstrument

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstrumentType** | **string** | The available values are: QuotedSecurity, InterestRateSwap, FxForward, Future, ExoticInstrument, FxOption, CreditDefaultSwap, InterestRateSwaption, Bond, EquityOption, FixedLeg, FloatingLeg, BespokeCashFlowsLeg, Unknown, TermDeposit, ContractForDifference, EquitySwap, CashPerpetual, CashSettled, CdsIndex, Basket, FundingLeg, CrossCurrencySwap, FxSwap, ForwardRateAgreement, SimpleInstrument | 
**InstrumentFormat** | [**InstrumentDefinitionFormat**](InstrumentDefinitionFormat.md) |  | 
**Content** | **string** | The original document received into the system. This format could potentially be anything though is most likely to be either Json or Xml. In the case where no other              interface is supported it is possible to fall back onto this.              For example, a trade from an external client system. This may be recognized internally by Lusid or simply passed through to another vendor system. | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

