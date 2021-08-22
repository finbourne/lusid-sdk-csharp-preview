# Lusid.Sdk.Model.OpaqueMarketData
A representation of an un-built piece of complex market data, to allow for passing through  to the vendor library for building.  The market data will usually be in some standard form such as XML or Json, representing a curve or surface.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**MarketDataType** | **string** | The available values are: DiscountFactorCurveData, EquityVolSurfaceData, FxVolSurfaceData, IrVolCubeData, OpaqueMarketData, YieldCurveData | 
**Document** | **string** | The document as a string. | 
**Format** | **string** | What format is the document stored in, e.g. Xml.  Supported string (enumeration) values are: [Unknown, Xml, Json, Csv]. | 
**Name** | **string** | Internal name of document. This is not used for search, it is simply a designator that helps identify the document  and could be anything (filename, ftp address or similar) | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

