using System;
using System.Collections.Generic;

namespace HanumanInstitute.OntraportApi.Models
{
    public class ApiFieldOptions
    {
        public IEnumerable<string>? Add { get; set; }
        public IEnumerable<string>? Remove { get; set; }
        public IEnumerable<string>? Replace { get; set; }
    }
}
