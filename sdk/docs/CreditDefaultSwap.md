
# Lusid.Sdk.Model.CreditDefaultSwap

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstrumentType** | **string** | The available values are: QuotedSecurity, InterestRateSwap, FxForward, Future, ExoticInstrument, FxOption, CreditDefaultSwap, InterestRateSwaption, Bond, EquityOption, FixedLeg, FloatingLeg, BespokeCashFlowsLeg, Unknown, TermDeposit, ContractForDifference, EquitySwap, CashPerpetual, CashSettled, CdsIndex, Basket, FundingLeg, CrossCurrencySwap, FxSwap, ForwardRateAgreement | 
**Ticker** | **string** | A ticker to uniquely specify then entity against which the cds is written | 
**StartDate** | **DateTimeOffset?** | The start date of the instrument. This is normally synonymous with the trade-date. | 
**MaturityDate** | **DateTimeOffset?** | The final maturity date of the instrument. This means the last date on which the instruments makes a payment of any amount.              For the avoidance of doubt, that is not necessarily prior to its last sensitivity date for the purposes of risk; e.g. instruments such as              Constant Maturity Swaps (CMS) often have sensitivities to rates beyond their last payment date | 
**FlowConventions** | [**CdsFlowConventions**](CdsFlowConventions.md) |  | [optional] 
**CouponRate** | **decimal?** | The coupon rate paid on each payment date of the premium leg as a fraction of 100 percent, e.g. \&quot;0.05\&quot; meaning 500 basis points or 5%.              For a standard corporate CDS (North American) this must be either 100bps or 500bps. | 
**ConventionName** | [**FlowConventionName**](FlowConventionName.md) |  | [optional] 
**ProtectionDetailSpecification** | [**CdsProtectionDetailSpecification**](CdsProtectionDetailSpecification.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

