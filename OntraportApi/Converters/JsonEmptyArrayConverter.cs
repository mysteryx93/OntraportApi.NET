﻿using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using HanumanInstitute.Validators;

namespace HanumanInstitute.OntraportApi.Converters
{
    /// <summary>
    /// Discards [] values. Ontraport API returns [] instead of {} for empty dictinoaries.
    /// </summary>
    public class JsonEmptyArrayConverter<T> : JsonConverter<T>
    {
        //public override bool CanConvert(Type objectType)
        //{
        //    return true;
        //    //return objectType.IsAssignableFrom(typeof(Dictionary<string, object>));
        //}

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            typeToConvert.CheckNotNull(nameof(typeToConvert));

            if (reader.TokenType == JsonTokenType.StartArray)
            {
                reader.Skip();
                return Activator.CreateInstance<T>();
            }
            return JsonSerializer.Deserialize<T>(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
