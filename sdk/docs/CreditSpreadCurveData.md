# Lusid.Sdk.Model.CreditSpreadCurveData
A credit spread curve matching tenors against par spread quotes

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**MarketDataType** | **string** | The available values are: DiscountFactorCurveData, EquityVolSurfaceData, FxVolSurfaceData, IrVolCubeData, OpaqueMarketData, YieldCurveData, FxForwardCurveData, FxForwardPipsCurveData, FxForwardTenorCurveData, FxForwardTenorPipsCurveData, FxForwardCurveByQuoteReference, CreditSpreadCurveData | 
**BaseDate** | **DateTimeOffset** | EffectiveAt date of the quoted rates | 
**DomCcy** | **string** | Domestic currency of the curve | 
**Tenors** | **List&lt;string&gt;** | The tenors for which the rates apply | 
**Spreads** | **List&lt;decimal&gt;** | Par spread quotes corresponding to the tenors. | 
**RecoveryRate** | **decimal** | The recovery rate in default. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

