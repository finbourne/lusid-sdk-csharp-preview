
# Lusid.Sdk.Model.ContractForDifference

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstrumentType** | **string** | The available values are: QuotedSecurity, InterestRateSwap, FxForward, Future, ExoticInstrument, FxOption, CreditDefaultSwap, InterestRateSwaption, Bond, EquityOption, FixedLeg, FloatingLeg, BespokeCashflowLeg, Unknown, TermDeposit, ContractForDifference | 
**StartDate** | **DateTimeOffset?** | The start date of the CFD. | 
**Code** | **string** | The code of the underlying. | 
**PayCcy** | **string** | The currency that this CFD pays out, this can be different to the UnderlyingCcy. | 
**ReferenceDate** | **DateTimeOffset?** | The reference date of the CFD. | 
**ReferenceRate** | **decimal?** | The reference rate of the CFD. | 
**UnderlyingCcy** | **string** | The currency of the underlying | 
**UnderlyingIdentifier** | **string** | external market codes and identifiers for the CFD, e.g. RIC.  Supported string (enumeration) values are: [LusidInstrumentId, Isin, Sedol, Cusip, ClientInternal, Figi, RIC, QuotePermId]. | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

