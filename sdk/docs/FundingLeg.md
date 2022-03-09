# Lusid.Sdk.Model.FundingLeg
IL FundingLeg Instrument; Lusid-ibor internal representation of a funding leg with variable notional.  This instrument is a hybrid between a single leg swap and a bank account, in that the notional is not fixed but  can be changed over it's life. The use case for this is to represent the funding leg of a basket of instruments  (e.g. equities) where the contents of the basket can change over time.  The actual notional history is stored in the FundingLegHistory object (implements IHistory) and this can be updated  externally or in some circumstances automatically by LUSID.  The main analytic calculated for this instrument is Accrual rather than PV.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstrumentType** | **string** | The available values are: QuotedSecurity, InterestRateSwap, FxForward, Future, ExoticInstrument, FxOption, CreditDefaultSwap, InterestRateSwaption, Bond, EquityOption, FixedLeg, FloatingLeg, BespokeCashFlowsLeg, Unknown, TermDeposit, ContractForDifference, EquitySwap, CashPerpetual, CapFloor, CashSettled, CdsIndex, Basket, FundingLeg, FxSwap, ForwardRateAgreement, SimpleInstrument, Repo, Equity, ExchangeTradedOption, ReferenceInstrument | 
**StartDate** | **DateTimeOffset** | The start date of the instrument. This is normally synonymous with the trade-date. | 
**MaturityDate** | **DateTimeOffset** | The final maturity date of the instrument. This means the last date on which the instruments makes a payment of any amount.  For the avoidance of doubt, that is not necessarily prior to its last sensitivity date for the purposes of risk; e.g. instruments such as  Constant Maturity Swaps (CMS) often have sensitivities to rates beyond their last payment date. | 
**LegDefinition** | [**LegDefinition**](LegDefinition.md) |  | 
**Notional** | **decimal** | Scaling factor to apply to leg quantities. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

