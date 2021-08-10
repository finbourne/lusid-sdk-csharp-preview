
# Lusid.Sdk.Model.EquitySwap

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstrumentType** | **string** | The available values are: QuotedSecurity, InterestRateSwap, FxForward, Future, ExoticInstrument, FxOption, CreditDefaultSwap, InterestRateSwaption, Bond, EquityOption, FixedLeg, FloatingLeg, BespokeCashFlowsLeg, Unknown, TermDeposit, ContractForDifference, EquitySwap, CashPerpetual, CashSettled, CdsIndex, Basket, FundingLeg, CrossCurrencySwap, FxSwap, ForwardRateAgreement, SimpleInstrument, Repo | 
**StartDate** | **DateTimeOffset?** | The start date of the EquitySwap | 
**MaturityDate** | **DateTimeOffset?** | The maturity date of the EquitySwap. | 
**Code** | **string** | The code of the underlying. | 
**EquityFlowConventions** | [**FlowConventions**](FlowConventions.md) |  | 
**FundingLeg** | [**InstrumentLeg**](InstrumentLeg.md) |  | 
**IncludeDividends** | **bool?** | Dividend inclusion flag, if true dividends are included in the equity leg (total return). | 
**InitialPrice** | **decimal?** | The initial equity price of the Equity Swap. | 
**NotionalReset** | **bool?** | Notional reset flag, if true the notional of the funding leg is reset at the start of every  coupon to match the value of the equity leg (equity price at start of coupon times quantity) | 
**Quantity** | **decimal?** | The quantity or number of shares in the Equity Swap. | 
**UnderlyingIdentifier** | **string** | external market codes and identifiers for the EquitySwap, e.g. RIC.  Supported string (enumeration) values are: [LusidInstrumentId, Isin, Sedol, Cusip, ClientInternal, Figi, RIC, QuotePermId, REDCode, BBGId, ICECode]. | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

