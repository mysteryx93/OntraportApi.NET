using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HanumanInstitute.OntraportApi.Models
{
    /// <summary>
    /// Contains the data sent back from a manual transaction request.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ApiTransactionResult
    {
        public int ResultCode { get; set; }
        public int TransactionId { get; set; }
        public string ExternalTxn { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public int InvoiceId { get; set; }
    }
}
