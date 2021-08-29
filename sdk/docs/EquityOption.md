# Lusid.Sdk.Model.EquityOption
Lusid-ibor internal representation of a plain vanilla equity option instrument.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstrumentType** | **string** | The available values are: QuotedSecurity, InterestRateSwap, FxForward, Future, ExoticInstrument, FxOption, CreditDefaultSwap, InterestRateSwaption, Bond, EquityOption, FixedLeg, FloatingLeg, BespokeCashFlowsLeg, Unknown, TermDeposit, ContractForDifference, EquitySwap, CashPerpetual, CashSettled, CdsIndex, Basket, FundingLeg, CrossCurrencySwap, FxSwap, ForwardRateAgreement, SimpleInstrument, Repo | 
**StartDate** | **DateTimeOffset** | The start date of the instrument. This is normally synonymous with the trade-date. | 
**OptionMaturityDate** | **DateTimeOffset** | The maturity date of the option. | 
**OptionSettlementDate** | **DateTimeOffset** | The settlement date of the option. | 
**DeliveryType** | **string** | The available values are: Cash, Physical | 
**OptionType** | **string** | The available values are: None, Call, Put | 
**Strike** | **decimal** | The strike of the option. | 
**DomCcy** | **string** | The domestic currency of the instrument. | 
**UnderlyingIdentifier** | **string** | The available values are: LusidInstrumentId, Isin, Sedol, Cusip, ClientInternal, Figi, RIC, QuotePermId, REDCode, BBGId, ICECode | 
**Code** | **string** | The identifying code for the equity underlying, e.g. &#39;IBM.N&#39;. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

