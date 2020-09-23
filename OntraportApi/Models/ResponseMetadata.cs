using System;
using System.Collections.Generic;

namespace HanumanInstitute.OntraportApi.Models
{
    public class ResponseMetadata
    {
        public string? Name { get; set; }
        public IDictionary<string, ApiFieldMetadata> Fields { get; set; } = new Dictionary<string, ApiFieldMetadata>();
    }
}
