# Lusid.Sdk.Model.FxOptionAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**StartDate** | **DateTimeOffset** | The start date of the instrument. This is normally synonymous with the trade-date. | 
**OptionMaturityDate** | **DateTimeOffset** | The maturity date of the option. | 
**OptionSettlementDate** | **DateTimeOffset** | The settlement date of the option. | 
**IsDeliveryNotCash** | **bool** | True of the option is settled in cash false if delivery. | 
**IsCallNotPut** | **bool** | True if the option is a call, false if the option is a put. | 
**Strike** | **decimal** | The strike of the option. | 
**DomCcy** | **string** | The domestic currency of the instrument. | 
**FgnCcy** | **string** | The foreign currency of the FX. | 
**Premium** | [**Premium**](Premium.md) |  | [optional] 
**InstrumentType** | **string** | The available values are: QuotedSecurity, InterestRateSwap, FxForward, Future, ExoticInstrument, FxOption, CreditDefaultSwap, InterestRateSwaption, Bond, EquityOption, FixedLeg, FloatingLeg, BespokeCashFlowsLeg, Unknown, TermDeposit, ContractForDifference, EquitySwap, CashPerpetual, CashSettled, CdsIndex, Basket, FundingLeg, CrossCurrencySwap, FxSwap, ForwardRateAgreement, SimpleInstrument | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

