using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// Represents a response from an Ontraport API call.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ApiResponse<T>
    {
        public int Code { get; set; }
        public T Data { get; set; }
        public int AccountId { get; set; }
    }
}