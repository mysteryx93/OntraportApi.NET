using System;
using System.Collections.Generic;
using HanumanInstitute.OntraportApi.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HanumanInstitute.OntraportApi.Models
{
    /// <summary>
    /// Contains information about an Ontraport field metadata information.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ApiFieldMetadata
    {
        public string Alias { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        [JsonConverter(typeof(JsonConverterIntBool))]
        public bool Required { get; set; }

        [JsonConverter(typeof(JsonConverterIntBool))]
        public bool Unique { get; set; }

        [JsonConverter(typeof(JsonConverterIntBool))]
        public bool? Editable { get; set; }

        [JsonConverter(typeof(JsonConverterIntBool))]
        public bool Deletable { get; set; }

        public int? ParentObject { get; set; }

        public IDictionary<string, string> Options { get; private set; } = new Dictionary<string, string>();

        public override string ToString() => $"\"{Alias}\", \"{Type}\"";
    }
}
