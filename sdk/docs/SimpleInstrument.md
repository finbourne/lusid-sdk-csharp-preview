
# Lusid.Sdk.Model.SimpleInstrument

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstrumentType** | **string** | The available values are: QuotedSecurity, InterestRateSwap, FxForward, Future, ExoticInstrument, FxOption, CreditDefaultSwap, InterestRateSwaption, Bond, EquityOption, FixedLeg, FloatingLeg, BespokeCashFlowsLeg, Unknown, TermDeposit, ContractForDifference, EquitySwap, CashPerpetual, CashSettled, CdsIndex, Basket, FundingLeg, CrossCurrencySwap, FxSwap, ForwardRateAgreement, SimpleInstrument | 
**MaturityDate** | **DateTimeOffset?** | The final maturity date of the instrument. This means the last date on which the instruments makes a payment of any amount.  For the avoidance of doubt, that is not necessarily prior to its last sensitivity date for the purposes of risk; e.g. instruments such as  Constant Maturity Swaps (CMS) often have sensitivities to rates beyond their last payment date | [optional] 
**DomCcy** | **string** | The domestic currency | 
**AssetClass** | **string** | The available values are: InterestRates, FX, Inflation, Equities, Credit, Commodities, Unknown | 
**FgnCcys** | **List&lt;string&gt;** | The set of foreign currencies, if any (optional) | [optional] 
**SimpleInstrumentType** | **string** | The Instrument type of the simple instrument | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

