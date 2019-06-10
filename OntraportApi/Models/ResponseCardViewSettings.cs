using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// Returned as part of GetCollectionInfo response for companies.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ResponseCardViewSettings
    {
        public string ColumnDisplayField { get; set; }
        public string SortField { get; set; }
        public string SortDir { get; set; }
        public string ColorField { get; set; }
        public IEnumerable<string> ColorFilter { get; set; }
        public IEnumerable<string> Fields { get; set; }
        public string DisplaySize { get; set; }
        public bool NewSettings { get; set; }
    }
}
