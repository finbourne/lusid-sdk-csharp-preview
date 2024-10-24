# Lusid.Sdk.Model.FxForwardsDependency
Indicates a dependency on an FxForwardCurve.  Identical to Fx dependencies in the meaning of domestic and foreign currencies, but describes a *set* of fx rates.  These rates are quoted rates for fx forwards, which can be used to interpolate the forward rate at a specific time in the future.  In the case of pips, the absolute rates can be expressed as rate = spotFx + pips / pipsPerUnit

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**DependencyType** | **string** | The available values are: OpaqueDependency, CashDependency, DiscountingDependency, EquityCurveDependency, EquityVolDependency, FxDependency, FxForwardsDependency, FxVolDependency, IndexProjectionDependency, IrVolDependency, QuoteDependency, Vendor | 
**DomesticCurrency** | **string** | DomesticCurrency is the first currency in a currency pair quote e.g. eur-gbp, eur is the domestic currency. | 
**ForeignCurrency** | **string** | ForeignCurrency is the second currency in a currency pair quote e.g. eur-gbp, gbp is the foreign currency. | 
**CurveType** | **string** | Used to describe the format in which the curve is expressed  e.g. FxFwdCurve (general term to describe any representation), TenorFxFwdCurve, PipsFxFwdCurve. | 
**Date** | **DateTimeOffset** | The effectiveDate of the entity that this is a dependency for.  Unless there is an obvious date this should be, like for a historic reset, then this is the valuation date. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

