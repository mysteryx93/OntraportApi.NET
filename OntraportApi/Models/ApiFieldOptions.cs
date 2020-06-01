using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HanumanInstitute.OntraportApi.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ApiFieldOptions
    {
        public IEnumerable<string>? Add { get; set; }
        public IEnumerable<string>? Remove { get; set; }
        public IEnumerable<string>? Replace { get; set; }
    }
}
