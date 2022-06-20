# Lusid.Sdk.Model.ReferenceInstrument
An abstract class to hold a reference to another (already loaded) instrument (e.g. a lookthrough to a portfolio) be expanded later

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**InstrumentType** | **string** | The available values are: QuotedSecurity, InterestRateSwap, FxForward, Future, ExoticInstrument, FxOption, CreditDefaultSwap, InterestRateSwaption, Bond, EquityOption, FixedLeg, FloatingLeg, BespokeCashFlowsLeg, Unknown, TermDeposit, ContractForDifference, EquitySwap, CashPerpetual, CapFloor, CashSettled, CdsIndex, Basket, FundingLeg, FxSwap, ForwardRateAgreement, SimpleInstrument, Repo, Equity, ExchangeTradedOption, ReferenceInstrument, ComplexBond | 
**InstrumentId** | **string** | The Identifier code | 
**InstrumentIdType** | **string** | the type of the instrument id e.g. LusidInstrument Id | 
**Scope** | **string** | (optional) Scope for the instrument | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

