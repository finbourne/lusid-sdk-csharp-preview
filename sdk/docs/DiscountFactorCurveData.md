# Lusid.Sdk.Model.DiscountFactorCurveData
A curve containing discount factors and dates to which they apply

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**MarketDataType** | **string** | The available values are: DiscountFactorCurveData, EquityVolSurfaceData, FxVolSurfaceData, IrVolCubeData, OpaqueMarketData, YieldCurveData, FxForwardCurveData, FxForwardPipsCurveData, FxForwardTenorCurveData, FxForwardTenorPipsCurveData, FxForwardCurveByQuoteReference, CreditSpreadCurveData | 
**BaseDate** | **DateTimeOffset** | BaseDate for the Curve | 
**Dates** | **List&lt;DateTimeOffset&gt;** | Dates for which the discount factors apply | 
**DiscountFactors** | **List&lt;decimal&gt;** | Discount factors to be applied to cashflow on the specified dates | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

