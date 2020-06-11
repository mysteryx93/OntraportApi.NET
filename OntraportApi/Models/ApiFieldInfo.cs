using System;
using HanumanInstitute.OntraportApi.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HanumanInstitute.OntraportApi.Models
{
    /// <summary>
    /// Contains information about an Ontraport field.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ApiFieldInfo
    {
        public int? Id { get; set; }

        public string? Alias { get; set; } = string.Empty;

        public string? Field { get; set; } = string.Empty;

        public string? Type { get; set; } = string.Empty;

        [JsonConverter(typeof(JsonConverterIntBool))]
        public bool Required { get; set; }

        [JsonConverter(typeof(JsonConverterIntBool))]
        public bool Unique { get; set; }

        [JsonConverter(typeof(JsonConverterIntBool))]
        public bool Editable { get; set; }

        [JsonConverter(typeof(JsonConverterIntBool))]
        public bool Deletable { get; set; }

        public string? Options { get; set; } = string.Empty;

        public override string ToString() => $"\"{Alias}\", \"{Type}\"";
    }
}
