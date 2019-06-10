using System;
using System.Collections.Generic;
using EmergenceGuardian.OntraportApi.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EmergenceGuardian.OntraportApi.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ResponseCollectionInfo
    {
        public IEnumerable<string> ListFields { get; set; }
        [JsonConverter(typeof(JsonEmptyArrayToObjectConverter))]
        public Dictionary<string, string> ListFieldSettings { get; set; }
        [JsonConverter(typeof(JsonEmptyArrayToObjectConverter))]
        public ResponseCardViewSettings CardViewSettings { get; set; }
        [JsonConverter(typeof(JsonEmptyArrayToObjectConverter))]
        public int ViewMode { get; set; }
        public int Count { get; set; }
    }
}
