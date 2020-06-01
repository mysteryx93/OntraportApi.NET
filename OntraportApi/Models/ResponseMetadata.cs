using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HanumanInstitute.OntraportApi.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ResponseMetadata
    {
        public string Name { get; set; } = string.Empty;
        public IDictionary<string, ApiFieldMetadata> Fields { get; private set; } = new Dictionary<string, ApiFieldMetadata>();
    }
}
