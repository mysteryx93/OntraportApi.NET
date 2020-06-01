using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HanumanInstitute.OntraportApi.Models
{
    /// <summary>
    /// Returned as part of GetCollectionInfo response for companies.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ResponseCardViewSettings
    {
        public string ColumnDisplayField { get; set; } = string.Empty;
        public string SortField { get; set; } = string.Empty;
        public string SortDir { get; set; } = string.Empty;
        public string ColorField { get; set; } = string.Empty;
        public IEnumerable<string>? ColorFilter { get; set; }
        public IEnumerable<string>? Fields { get; set; }
        public string DisplaySize { get; set; } = string.Empty;
        public bool NewSettings { get; set; }
    }
}
