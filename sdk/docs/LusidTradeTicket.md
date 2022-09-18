# Lusid.Sdk.Model.LusidTradeTicket
A LUSID Trade Ticket comprising an instrument, a transaction, and a counterparty.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**TransactionId** | **string** |  | 
**TransactionType** | **string** |  | 
**Source** | **string** |  | [optional] 
**TransactionDate** | **string** |  | 
**SettlementDate** | **string** |  | 
**TotalConsideration** | [**CurrencyAndAmount**](CurrencyAndAmount.md) |  | 
**Units** | **decimal** |  | 
**InstrumentIdentifiers** | **Dictionary&lt;string, string&gt;** |  | 
**InstrumentScope** | **string** |  | [optional] 
**InstrumentName** | **string** |  | [optional] 
**InstrumentDefinition** | [**LusidInstrument**](LusidInstrument.md) |  | [optional] 
**CounterpartyAgreementId** | [**ResourceId**](ResourceId.md) |  | [optional] 
**InstrumentProperties** | [**List&lt;Property&gt;**](Property.md) |  | [optional] 
**TransactionProperties** | [**List&lt;Property&gt;**](Property.md) |  | [optional] 
**TradeTicketType** | **string** | The available values are: LusidTradeTicket, ExternalTradeTicket | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

