using System;
using System.Text.Json.Serialization;

namespace HanumanInstitute.OntraportApi.Models
{
    /// <summary>
    /// Contains the data sent back from a manual transaction request.
    /// </summary>
    public class ApiTransactionResult
    {
        [JsonPropertyName("result_code")]
        public int ResultCode { get; set; }
        [JsonPropertyName("transaction_id")]
        public int TransactionId { get; set; }
        [JsonPropertyName("external_txn")]
        public string? ExternalTxn { get; set; } = string.Empty;
        public string? Message { get; set; } = string.Empty;
        [JsonPropertyName("invoice_id")]
        public int InvoiceId { get; set; }
    }
}
