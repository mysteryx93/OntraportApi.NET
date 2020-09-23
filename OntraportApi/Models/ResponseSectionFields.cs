using System;
using System.Collections.Generic;

namespace HanumanInstitute.OntraportApi.Models
{
    public class ResponseSectionFields
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<List<ApiFieldInfo>> Fields { get; set; } = new List<List<ApiFieldInfo>>();
    }
}
