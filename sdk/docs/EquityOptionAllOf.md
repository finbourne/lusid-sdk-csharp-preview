
# Lusid.Sdk.Model.EquityOptionAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Code** | **string** | The reset code of the option. | 
**Strike** | **decimal?** | The strike of the option. | 
**OptionMaturityDate** | **DateTimeOffset?** | The maturity date of the option. | 
**OptionSettlementDate** | **DateTimeOffset?** | The settlement date of the option. | 
**StartDate** | **DateTimeOffset?** | The start date of the instrument. This is normally synonymous with the trade-date. | 
**OptionType** | **string** | The available values are: None, Call, Put | 
**DeliveryType** | **string** | The available values are: Cash, Physical | 
**UnderlyingIdentifier** | **string** | The available values are: LusidInstrumentId, Isin, Sedol, Cusip, ClientInternal, Figi, RIC, QuotePermId | 
**DomCcy** | **string** | The domestic currency of the instrument. | 
**InstrumentType** | **string** | The available values are: QuotedSecurity, InterestRateSwap, FxForward, Future, Exotic, FxOption, CreditDefaultSwap, InterestRateSwaption, Bond, EquityOption, FixedRateLeg, FloatingRateLeg, BespokeCashflowLeg, Unknown | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

