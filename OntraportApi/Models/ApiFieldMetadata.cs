using System;
using System.Collections.Generic;
using EmergenceGuardian.OntraportApi.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// Contains information about an Ontraport field metadata information.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ApiFieldMetadata
    {
        public string Alias { get; set; }

        public string Type { get; set; }

        [JsonConverter(typeof(JsonConverterIntBool))]
        public bool Required { get; set; }

        [JsonConverter(typeof(JsonConverterIntBool))]
        public bool Unique { get; set; }

        [JsonConverter(typeof(JsonConverterIntBool))]
        public bool? Editable { get; set; }

        [JsonConverter(typeof(JsonConverterIntBool))]
        public bool Deletable { get; set; }

        public int? ParentObject { get; set; }

        public Dictionary<string, string> Options { get; set; }

        public override string ToString() => $"\"{Alias}\", \"{Type}\"";
    }
}
