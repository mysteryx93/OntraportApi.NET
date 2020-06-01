using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HanumanInstitute.OntraportApi.Models
{
    /// <summary>
    /// Represents a response from an Ontraport API call.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ApiResponse<T>
        where T : class
    {
        public int Code { get; set; }
        public T? Data { get; set; }
        public int AccountId { get; set; }
    }
}
