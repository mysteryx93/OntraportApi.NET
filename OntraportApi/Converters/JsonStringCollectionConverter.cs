using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using HanumanInstitute.Validators;

namespace HanumanInstitute.OntraportApi.Converters
{
    /// <summary>
    /// Some empty collections will be returned as "null". Discard those.
    /// </summary>
    public class JsonStringCollectionConverter : JsonConverter<ICollection<string>>
    {
        public override ICollection<string> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            typeToConvert.CheckNotNull(nameof(typeToConvert));

            if (reader.TokenType == JsonTokenType.String && reader.GetString() == "null")
            {
                reader.Skip();
                return new List<string>();
            }
            return JsonSerializer.Deserialize<ICollection<string>>(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, ICollection<string> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
