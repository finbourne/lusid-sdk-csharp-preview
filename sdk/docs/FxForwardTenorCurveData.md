# Lusid.Sdk.Model.FxForwardTenorCurveData
Contains data (i.e. tenors and rates + metadata) for building fx forward curves (when combined with a date to build on)

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**MarketDataType** | **string** | The available values are: DiscountFactorCurveData, EquityVolSurfaceData, FxVolSurfaceData, IrVolCubeData, OpaqueMarketData, YieldCurveData, FxForwardCurveData, FxForwardPipsCurveData, FxForwardTenorCurveData, FxForwardTenorPipsCurveData, FxForwardCurveByQuoteReference | 
**BaseDate** | **DateTimeOffset** | EffectiveAt date of the quoted rates | 
**DomCcy** | **string** | Domestic currency of the fx forward | 
**FgnCcy** | **string** | Foreign currency of the fx forward | 
**Tenors** | **List&lt;string&gt;** | Tenors for which the forward rates apply | 
**Rates** | **List&lt;decimal&gt;** | Rates provided for the fx forward (price in FgnCcy per unit of DomCcy) | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

