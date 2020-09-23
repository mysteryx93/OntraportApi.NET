using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using HanumanInstitute.OntraportApi.Converters;

namespace HanumanInstitute.OntraportApi.Models
{
    /// <summary>
    /// Returned as part of GetCollectionInfo response for companies.
    /// </summary>
    public class ResponseCardViewSettings
    {
        public string? ColumnDisplayField { get; set; }
        public string? SortField { get; set; }
        public string? SortDir { get; set; }
        public string? ColorField { get; set; }
        [JsonConverter(typeof(JsonStringCollectionConverter))]
        public ICollection<string> ColorFilter { get; set; } = new List<string>();
        [JsonConverter(typeof(JsonStringCollectionConverter))]
        public ICollection<string> Fields { get; set; } = new List<string>();
        public string? DisplaySize { get; set; }
        public bool? NewSettings { get; set; }
    }
}
