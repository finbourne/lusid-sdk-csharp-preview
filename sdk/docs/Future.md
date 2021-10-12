# Lusid.Sdk.Model.Future
IL Fx-Forward Instrument; Lusid-ibor internal representation of a Fx Forward instrument                             A future contract, entered into on the start date at an initial reference spot price has zero initial value. It is a committment to buy a certain number of               contracts of a certain size at a date in the future.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstrumentType** | **string** | The available values are: QuotedSecurity, InterestRateSwap, FxForward, Future, ExoticInstrument, FxOption, CreditDefaultSwap, InterestRateSwaption, Bond, EquityOption, FixedLeg, FloatingLeg, BespokeCashFlowsLeg, Unknown, TermDeposit, ContractForDifference, EquitySwap, CashPerpetual, CapFloor, CashSettled, CdsIndex, Basket, FundingLeg, CrossCurrencySwap, FxSwap, ForwardRateAgreement, SimpleInstrument, Repo, Equity | 
**StartDate** | **DateTimeOffset** | The start date of the instrument. This is normally synonymous with the trade-date. | 
**MaturityDate** | **DateTimeOffset** | The final maturity date of the instrument. This means the last date on which the instruments makes a payment of any amount.              For the avoidance of doubt, that is not necessarily prior to its last sensitivity date for the purposes of risk; e.g. instruments such as              Constant Maturity Swaps (CMS) often have sensitivities to rates beyond their last payment date | 
**Identifiers** | **Dictionary&lt;string, string&gt;** | external market codes and identifiers for the bond, e.g. ISIN. | 
**ContractDetails** | [**FuturesContractDetails**](FuturesContractDetails.md) |  | 
**Contracts** | **decimal** | The number of contracts held | [optional] 
**RefSpotPrice** | **decimal** | The reference spot price for the future at which the contract was entered into. | [optional] 
**Underlying** | [**LusidInstrument**](LusidInstrument.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

