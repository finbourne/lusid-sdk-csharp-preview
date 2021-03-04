
# Lusid.Sdk.Model.EquityOption

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstrumentType** | **string** | The available values are: QuotedSecurity, InterestRateSwap, FxForward, Future, ExoticInstrument, FxOption, CreditDefaultSwap, InterestRateSwaption, Bond, EquityOption, FixedLeg, FloatingLeg, BespokeCashflowLeg, Unknown, TermDeposit, ContractForDifference, EquitySwap, CashPerpetual, CashSettled | 
**StartDate** | **DateTimeOffset?** | The start date of the instrument. This is normally synonymous with the trade-date. | 
**OptionMaturityDate** | **DateTimeOffset?** | The maturity date of the option. | 
**OptionSettlementDate** | **DateTimeOffset?** | The settlement date of the option. | 
**DeliveryType** | **string** | The available values are: Cash, Physical | 
**OptionType** | **string** | The available values are: None, Call, Put | 
**Strike** | **decimal?** | The strike of the option. | 
**DomCcy** | **string** | The domestic currency of the instrument. | 
**UnderlyingIdentifier** | **string** | The available values are: LusidInstrumentId, Isin, Sedol, Cusip, ClientInternal, Figi, RIC, QuotePermId | 
**Code** | **string** | The reset code of the option. | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

