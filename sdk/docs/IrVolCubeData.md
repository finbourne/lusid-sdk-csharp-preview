# Lusid.Sdk.Model.IrVolCubeData
Market Data required to build a volatility cube for swaption pricing,  represented by a list of instruments and corresponding market quotes

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**MarketDataType** | **string** | The available values are: DiscountFactorCurveData, EquityVolSurfaceData, FxVolSurfaceData, IrVolCubeData, OpaqueMarketData, YieldCurveData | 
**BaseDate** | **DateTimeOffset** | Base date of the cube - this is the start date of the swaptions on the cube. | 
**Instruments** | [**List&lt;LusidInstrument&gt;**](LusidInstrument.md) | Retrieve the set of instruments that define the cube. | 
**Quotes** | [**List&lt;MarketQuote&gt;**](MarketQuote.md) | Access the set of quotes that define the cube. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

