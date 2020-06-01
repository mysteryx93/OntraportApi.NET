using System;
using System.Collections.Generic;
using HanumanInstitute.OntraportApi.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace HanumanInstitute.OntraportApi.Models
{
    /// <summary>
    /// An Ontraport field for editing queries.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ApiFieldEditor
    {
        public string Field { get; set; } = string.Empty;

        public string Alias { get; set; } = string.Empty;

        [JsonConverter(typeof(StringEnumConverter))]
        public ApiFieldType? Type { get; set; }

        [JsonConverter(typeof(JsonConverterIntBool))]
        public bool? Required { get; set; }

        [JsonConverter(typeof(JsonConverterIntBool))]
        public bool? Unique { get; set; }

        public ApiFieldOptions? Options { get; set; }

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
    }
}
