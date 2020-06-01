using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HanumanInstitute.OntraportApi.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ResponseSectionFields
    {
        public int Id {get;set;}
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IList<List<ApiFieldInfo>>? Fields { get; private set; } = new List<List<ApiFieldInfo>>();
    }
}
