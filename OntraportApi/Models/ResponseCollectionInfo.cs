using System;
using System.Collections.Generic;
using HanumanInstitute.OntraportApi.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HanumanInstitute.OntraportApi.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ResponseCollectionInfo
    {
        public List<string>? ListFields { get; private set; } = new List<string>();
        [JsonConverter(typeof(JsonEmptyArrayToObjectConverter))]
        public Dictionary<string, string> ListFieldSettings { get; private set; } = new Dictionary<string, string>();
        [JsonConverter(typeof(JsonEmptyArrayToObjectConverter))]
        public ResponseCardViewSettings? CardViewSettings { get; set; }
        [JsonConverter(typeof(JsonEmptyArrayToObjectConverter))]
        public int ViewMode { get; set; }
        public int Count { get; set; }
    }
}
