# Lusid.Sdk.Model.TradeTicket
A Trade Ticket comprising of an instrument, a transaction and a counterparty.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**TransactionId** | **string** | The unique identifier of the transaction. | 
**Type** | **string** | The type of the transaction, for example &#39;Buy&#39; or &#39;Sell&#39;. The transaction type must have been pre-configured using the System Configuration API. If not, this operation will succeed but you are not able to calculate holdings for the portfolio that include this transaction. | 
**Source** | **string** | The source of the transaction. This is used to look up the appropriate transaction group set in the transaction type configuration. | [optional] 
**TransactionDate** | [**DateTimeOrCutLabel**](DateTimeOrCutLabel.md) | The date of the transaction. | 
**SettlementDate** | [**DateTimeOrCutLabel**](DateTimeOrCutLabel.md) | The settlement date of the transaction. | 
**TotalConsideration** | [**CurrencyAndAmount**](CurrencyAndAmount.md) |  | 
**Units** | **decimal** | The number of units of the transacted instrument. | 
**InstrumentIdentifiers** | **Dictionary&lt;string, string&gt;** | The set of identifiers that can be used to identify the instrument. | 
**InstrumentScope** | **string** | The scope in which the instrument lies. | [optional] 
**InstrumentName** | **string** | The name of the instrument. | [optional] 
**InstrumentDefinition** | [**LusidInstrument**](LusidInstrument.md) |  | [optional] 
**CounterpartyAgreementId** | [**ResourceId**](ResourceId.md) |  | [optional] 
**InstrumentProperties** | [**List&lt;Property&gt;**](Property.md) | The set of instrument properties wanted on the instrument from the trade ticket. | [optional] 
**TransactionProperties** | [**List&lt;Property&gt;**](Property.md) | The set of transaction properties wanted on the transaction from the trade ticket. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

