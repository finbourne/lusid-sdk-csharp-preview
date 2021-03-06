
# Lusid.Sdk.Model.CdsInstrument

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstrumentType** | **string** | The available values are: QuotedSecurity, InterestRateSwap, FxForward, Future, Exotic, FxOption, CreditDefaultSwap, InterestRateSwaption, Bond, EquityOption, FixedRateLeg, FloatingRateLeg, BespokeCashflowLeg, Unknown | 
**Ticker** | **string** | A ticker to uniquely specify then entity against which the cds is written | 
**FlowConventions** | [**CdsFlowConventions**](CdsFlowConventions.md) |  | 
**CouponRate** | **decimal?** | The coupon rate paid on each payment date of the premium leg as a fraction of 100 percent, e.g. \&quot;0.05\&quot; meaning 500 basis points or 5%.  For a standard corporate CDS (North American) this must be either 100bps or 500bps. | 
**ProtectionDetailSpecification** | [**CdsProtectionDetailSpecification**](CdsProtectionDetailSpecification.md) |  | 
**StartDate** | **DateTimeOffset?** | Starting date of the credit default swap | 
**MaturityDate** | **DateTimeOffset?** | Maturity date of the credit default swap | 
**DomCcy** | **string** | Domestic currency of the credit default swap | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

