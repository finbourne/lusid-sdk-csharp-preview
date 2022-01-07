# Lusid.Sdk.Model.CapFloor
Interest rate Cap, Floor or Collar  Derivative instrument on an underlying interest rate index.  Cap Type: Buyer will receive payments at the end of each period when floating rate is above the CapStrike level.  Floor Type: Buyer will receive payments at the end of each period when floating rate is below the FloorStrike level.  Collar Type: Strategy of buying one Cap and selling one Floor where FloorStrike is less than CapStrike.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstrumentType** | **string** | The available values are: QuotedSecurity, InterestRateSwap, FxForward, Future, ExoticInstrument, FxOption, CreditDefaultSwap, InterestRateSwaption, Bond, EquityOption, FixedLeg, FloatingLeg, BespokeCashFlowsLeg, Unknown, TermDeposit, ContractForDifference, EquitySwap, CashPerpetual, CapFloor, CashSettled, CdsIndex, Basket, FundingLeg, CrossCurrencySwap, FxSwap, ForwardRateAgreement, SimpleInstrument, Repo, Equity, ExchangeTradedOption | 
**CapFloorType** | **string** | Determine if it&#39;s CAP, FLOOR, or COLLAR.  Supported string (enumeration) values are: [Cap, Floor, Collar]. | 
**CapStrike** | **decimal** | Strike rate of the Cap. | 
**FloorStrike** | **decimal** | Strike rate of the Floor. | 
**IncludeFirstCaplet** | **bool** | Include first caplet flag. | 
**UnderlyingFloatingLeg** | [**FloatingLeg**](FloatingLeg.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

