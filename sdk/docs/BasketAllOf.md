
# Lusid.Sdk.Model.BasketAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**BasketName** | [**BasketIdentifier**](BasketIdentifier.md) |  | 
**BasketType** | **string** | What contents does the basket have. The validation will check that the instrument types contained match those expected.  Supported string (enumeration) values are: [Bonds, Credits, Equities, EquitySwap, Unknown]. | 
**WeightedInstruments** | [**WeightedInstruments**](WeightedInstruments.md) |  | 
**InstrumentType** | **string** | The available values are: QuotedSecurity, InterestRateSwap, FxForward, Future, ExoticInstrument, FxOption, CreditDefaultSwap, InterestRateSwaption, Bond, EquityOption, FixedLeg, FloatingLeg, BespokeCashflowLeg, Unknown, TermDeposit, ContractForDifference, EquitySwap, CashPerpetual, CashSettled, CdsIndex, Basket | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

