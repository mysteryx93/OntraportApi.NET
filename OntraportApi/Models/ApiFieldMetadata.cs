using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HanumanInstitute.OntraportApi.Models
{
    /// <summary>
    /// Contains information about an Ontraport field metadata information.
    /// </summary>
    public class ApiFieldMetadata
    {
        public string? Alias { get; set; } = string.Empty;

        public string? Type { get; set; } = string.Empty;

        public bool? Required { get; set; }

        public bool? Unique { get; set; }

        public bool? Editable { get; set; }

        public bool? Deletable { get; set; }

        [JsonPropertyName("parent_object")]
        public int? ParentObject { get; set; }

        public IDictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

        public override string ToString() => $"\"{Alias}\", \"{Type}\"";
    }
}
