using System;
using EmergenceGuardian.OntraportApi.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// Contains the data sent back from a manual transaction request.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ApiTransactionResult
    {
        public int ResultCode { get; set; }
        public int TransactionId { get; set; }
        public string ExternalTxn { get; set; }
        public string Message { get; set; }
        public int InvoiceId { get; set; }
    }
}
