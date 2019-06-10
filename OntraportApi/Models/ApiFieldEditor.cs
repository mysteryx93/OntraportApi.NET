using System;
using System.Collections.Generic;
using EmergenceGuardian.OntraportApi.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// An Ontraport field for editing queries.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ApiFieldEditor
    {
        public string Field { get; set; }

        public string Alias { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ApiFieldType? Type { get; set; }

        [JsonConverter(typeof(JsonConverterIntBool))]
        public bool? Required { get; set; }

        [JsonConverter(typeof(JsonConverterIntBool))]
        public bool? Unique { get; set; }

        public ApiFieldOptions Options { get; set; }

        public ApiFieldEditor ListAdd(IEnumerable<string> listValues)
        {
            Options = new ApiFieldOptions()
            {
                Add = listValues
            };
            return this;
        }

        public ApiFieldEditor ListRemove(IEnumerable<string> listValues)
        {
            Options = new ApiFieldOptions()
            {
                Remove = listValues
            };
            return this;
        }

        public ApiFieldEditor ListReplace(IEnumerable<string> listValues)
        {
            Options = new ApiFieldOptions()
            {
                Replace = listValues
            };
            return this;
        }

        [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
        public class ApiFieldOptions
        {
            public IEnumerable<string> Add { get; set; }
            public IEnumerable<string> Remove { get; set; }
            public IEnumerable<string> Replace { get; set; }
        }
    }
}
