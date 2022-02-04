# Lusid.Sdk.Model.FxOption
Lusid-ibor internal representation of a plain vanilla FX Option instrument.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstrumentType** | **string** | The available values are: QuotedSecurity, InterestRateSwap, FxForward, Future, ExoticInstrument, FxOption, CreditDefaultSwap, InterestRateSwaption, Bond, EquityOption, FixedLeg, FloatingLeg, BespokeCashFlowsLeg, Unknown, TermDeposit, ContractForDifference, EquitySwap, CashPerpetual, CapFloor, CashSettled, CdsIndex, Basket, FundingLeg, FxSwap, ForwardRateAgreement, SimpleInstrument, Repo, Equity, ExchangeTradedOption | 
**StartDate** | **DateTimeOffset** | The start date of the instrument. This is normally synonymous with the trade-date. | 
**OptionMaturityDate** | **DateTimeOffset** | The maturity date of the option. | 
**OptionSettlementDate** | **DateTimeOffset** | The settlement date of the option. | 
**IsDeliveryNotCash** | **bool** | True if the option is settled in cash, false if delivery. | 
**IsCallNotPut** | **bool** | True if the option is a call, false if the option is a put. | 
**Strike** | **decimal** | The strike of the option. | 
**DomCcy** | **string** | The domestic currency of the instrument. | 
**DomAmount** | **decimal?** | The Amount of DomCcy that will be exchanged if the option is exercised.  This amount should be a positive number, with the Call/Put flag used to indicate direction.  The corresponding amount of FgnCcy that will be exchanged is this amount times the strike.  Note there is no rounding performed on this computed value.  This is an optional field, if not set the option ContractSize will default to 1. | [optional] 
**FgnCcy** | **string** | The foreign currency of the FX. | 
**Premium** | [**Premium**](Premium.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

