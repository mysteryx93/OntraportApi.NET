using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EmergenceGuardian.OntraportApi.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ResponseMetadata
    {
        public string Name { get; set; }
        public IDictionary<string, ApiFieldMetadata> Fields { get; set; }
    }
}
