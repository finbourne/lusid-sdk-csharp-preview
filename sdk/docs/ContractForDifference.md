
# Lusid.Sdk.Model.ContractForDifference

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstrumentType** | **string** | The available values are: QuotedSecurity, InterestRateSwap, FxForward, Future, ExoticInstrument, FxOption, CreditDefaultSwap, InterestRateSwaption, Bond, EquityOption, FixedLeg, FloatingLeg, BespokeCashflowLeg, Unknown, TermDeposit, ContractForDifference, EquitySwap, CashPerpetual, CashSettled, CdsIndex, Basket | 
**StartDate** | **DateTimeOffset?** | The start date of the CFD. | 
**MaturityDate** | **DateTimeOffset?** | The final maturity date of the instrument. This means the last date on which the instruments makes a payment of any amount.  For the avoidance of doubt, that is not necessarily prior to its last sensitivity date for the purposes of risk; e.g. instruments such as  Constant Maturity Swaps (CMS) often have sensitivities to rates beyond their last payment date | 
**Code** | **string** | The code of the underlying. | 
**ContractSize** | **decimal?** | With an OTC we have the problem of multiple ways of booking a quantity.  e.g.  If buying a swap do you have a holding of size 1 of 100,000,000 notional swap or a holding of 100,000,000 size of 1 notional swap, or any combination that multiplies to 10^8.  When you get for a price for a &#39;unit swap&#39; what do you mean? The definition must be consistent across all quotes. This includes bonds which have a face value and  fx-forwards which often trade in standard contract sizes. When we look up a price, and there are no units, we are assuming it is a price for a contract size of 1.  The logical effect of this is that  instrument clean price &#x3D; contract size * quoted unit price  holding clean price    &#x3D; holding quantity * instrument clean price &#x3D; holding quantity * contract size * quoted unit price  In calculating accrued interest the same should hold.  NB: The real problem is that people store \&quot;prices\&quot; without complete units. Everything should really be \&quot;x ccy for n units\&quot;. Where the n is implicit the above has to hold. | 
**PayCcy** | **string** | The currency that this CFD pays out, this can be different to the UnderlyingCcy. | 
**ReferenceRate** | **decimal?** | The reference rate of the CFD, this can be set to 0 but not negative values. | 
**Type** | **string** | The type of CFD.  Supported string (enumeration) values are: [Cash, Futures]. | 
**UnderlyingCcy** | **string** | The currency of the underlying | 
**UnderlyingIdentifier** | **string** | external market codes and identifiers for the CFD, e.g. RIC.  Supported string (enumeration) values are: [LusidInstrumentId, Isin, Sedol, Cusip, ClientInternal, Figi, RIC, QuotePermId]. | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

