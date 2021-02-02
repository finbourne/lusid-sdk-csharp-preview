
# Lusid.Sdk.Model.ContractForDifference

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstrumentType** | **string** | The available values are: QuotedSecurity, InterestRateSwap, FxForward, Future, ExoticInstrument, FxOption, CreditDefaultSwap, InterestRateSwaption, Bond, EquityOption, FixedLeg, FloatingLeg, BespokeCashflowLeg, Unknown, TermDeposit, ContractForDifference, EquitySwap | 
**StartDate** | **DateTimeOffset?** | The start date of the CFD. | 
**MaturityDate** | **DateTimeOffset?** | The final maturity date of the instrument. This means the last date on which the instruments makes a payment of any amount.  For the avoidance of doubt, that is not necessarily prior to its last sensitivity date for the purposes of risk; e.g. instruments such as  Constant Maturity Swaps (CMS) often have sensitivities to rates beyond their last payment date | 
**Code** | **string** | The code of the underlying. | 
**PayCcy** | **string** | The currency that this CFD pays out, this can be different to the UnderlyingCcy. | 
**ReferenceRate** | **decimal?** | The reference rate of the CFD, this can be set to 0 but not negative values. | 
**UnderlyingCcy** | **string** | The currency of the underlying | 
**UnderlyingIdentifier** | **string** | external market codes and identifiers for the CFD, e.g. RIC.  Supported string (enumeration) values are: [LusidInstrumentId, Isin, Sedol, Cusip, ClientInternal, Figi, RIC, QuotePermId]. | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

