# Lusid.Sdk.Model.Bond
IL Bond Instrument; Lusid-ibor internal representation of a Bond instrument

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstrumentType** | **string** | The available values are: QuotedSecurity, InterestRateSwap, FxForward, Future, ExoticInstrument, FxOption, CreditDefaultSwap, InterestRateSwaption, Bond, EquityOption, FixedLeg, FloatingLeg, BespokeCashFlowsLeg, Unknown, TermDeposit, ContractForDifference, EquitySwap, CashPerpetual, CapFloor, CashSettled, CdsIndex, Basket, FundingLeg, CrossCurrencySwap, FxSwap, ForwardRateAgreement, SimpleInstrument, Repo, Equity, ExchangeTradedOption | 
**StartDate** | **DateTimeOffset** | The start date of the instrument. This is normally synonymous with the trade-date. If settle days &#x3D; 0 then this is the initial accrual date of the bond. | 
**MaturityDate** | **DateTimeOffset** | The final maturity date of the instrument. This means the last date on which the instruments makes a payment of any amount.              For the avoidance of doubt, that is not necessarily prior to its last sensitivity date for the purposes of risk; e.g. instruments such as              Constant Maturity Swaps (CMS) often have sensitivities to rates beyond their last payment date | 
**DomCcy** | **string** | The domestic currency of the instrument. | 
**FlowConventions** | [**FlowConventions**](FlowConventions.md) |  | 
**Principal** | **decimal** | The face-value or principal for the bond at outset.              This might be reduced through its lifetime in the event of amortization or similar. | 
**CouponRate** | **decimal** | simple coupon rate. | 
**Identifiers** | **Dictionary&lt;string, string&gt;** | external market codes and identifiers for the bond, e.g. ISIN. | [optional] 
**ExDividendDays** | **int?** | The number of days before the next coupon payment for which the bond goes ex-dividend. | [optional] 
**InitialCouponDate** | **DateTimeOffset?** | The initial coupon date is in fact the previous coupon pay date in the bond schedule. This date specifies the start of the coupon period in which the ex-dividend date lies. | [optional] 
**FirstCouponPayDate** | **DateTimeOffset?** | The date that the first coupon of the bond is paid. This is required for bonds that have a long first coupon or short first coupon. The first coupon pay date is used  as an anchor to compare with the start date and determine if this is a long/short coupon period. | [optional] 
**CalculationType** | **string** | The calculation type applied to the bond coupon amount. This is required for bonds that have a particular type of computing the period coupon, such as simple compounding,  irregular coupons etc.  The default CalculationType is &#x60;Standard&#x60;, which returns a coupon amount equal to Principal * Coupon Rate / Coupon Frequency. Coupon Frequency is 12M / Payment Frequency.  Payment Frequency can be 1M, 3M, 6M, 12M etc. So Coupon Frequency can be 12, 4, 2, 1 respectively.  Supported string (enumeration) values are: [Standard, DayCountCoupon, NoCalculationFloater, BrazilFixedCoupon]. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

