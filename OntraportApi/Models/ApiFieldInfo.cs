using System;
using EmergenceGuardian.OntraportApi.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// Contains information about an Ontraport field.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ApiFieldInfo
    {
        public int? Id { get; set; }

        public string Alias { get; set; }

        public string Field { get; set; }

        public string Type { get; set; }

        [JsonConverter(typeof(JsonConverterIntBool))]
        public bool Required { get; set; }

        [JsonConverter(typeof(JsonConverterIntBool))]
        public bool Unique { get; set; }

        [JsonConverter(typeof(JsonConverterIntBool))]
        public bool Editable { get; set; }

        [JsonConverter(typeof(JsonConverterIntBool))]
        public bool Deletable { get; set; }

        public string Options { get; set; }

        public override string ToString() => $"\"{Alias}\", \"{Type}\"";
    }
}
