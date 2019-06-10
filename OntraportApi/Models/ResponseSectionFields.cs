using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EmergenceGuardian.OntraportApi.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ResponseSectionFields
    {
        public int Id {get;set;}
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<List<ApiFieldInfo>> Fields { get; set; }
    }
}
