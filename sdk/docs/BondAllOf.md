# Lusid.Sdk.Model.BondAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**StartDate** | **DateTimeOffset** | The start date of the instrument. This is normally synonymous with the trade-date. | 
**MaturityDate** | **DateTimeOffset** | The final maturity date of the instrument. This means the last date on which the instruments makes a payment of any amount.              For the avoidance of doubt, that is not necessarily prior to its last sensitivity date for the purposes of risk; e.g. instruments such as              Constant Maturity Swaps (CMS) often have sensitivities to rates beyond their last payment date | 
**DomCcy** | **string** | The domestic currency of the instrument. | 
**FlowConventions** | [**FlowConventions**](FlowConventions.md) |  | 
**Principal** | **decimal** | The face-value or principal for the bond at outset.              This might be reduced through its lifetime in the event of amortization or similar. | 
**CouponRate** | **decimal** | simple coupon rate. | 
**Identifiers** | **Dictionary&lt;string, string&gt;** | external market codes and identifiers for the bond, e.g. ISIN. | [optional] 
**ExDividendDays** | **int?** | The number of days before the next coupon payment for which the bond goes ex-dividend. | [optional] 
**InitialCouponDate** | **DateTimeOffset?** | The initial coupon date which specifies the accrual start period for a fixed coupon bond with ex dividend schedule | [optional] 
**InstrumentType** | **string** | The available values are: QuotedSecurity, InterestRateSwap, FxForward, Future, ExoticInstrument, FxOption, CreditDefaultSwap, InterestRateSwaption, Bond, EquityOption, FixedLeg, FloatingLeg, BespokeCashFlowsLeg, Unknown, TermDeposit, ContractForDifference, EquitySwap, CashPerpetual, CapFloor, CashSettled, CdsIndex, Basket, FundingLeg, CrossCurrencySwap, FxSwap, ForwardRateAgreement, SimpleInstrument, Repo, Equity | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

