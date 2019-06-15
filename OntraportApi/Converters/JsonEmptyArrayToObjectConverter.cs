using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi.Converters
{
    /// <summary>
    /// Converts [] into a new object. Ontraport API returns [] instead of {} for empty dictinoaries.
    /// </summary>
    public class JsonEmptyArrayToObjectConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
            //return objectType.IsAssignableFrom(typeof(Dictionary<string, object>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Type == JTokenType.Object)
            {
                return token.ToObject(objectType);
            }
            else if (token.Type == JTokenType.Null)
            {
                return null;
            }
            else if (token.Type == JTokenType.String)
            {
                return token.Value<string>().Convert(objectType);
            }
            else if (token.Type == JTokenType.Array)
            {
                if (!token.HasValues)
                {
                    // Create new object.
                    return Activator.CreateInstance(objectType);
                }
            }
            
            throw new JsonSerializationException($"Object, empty array or null expected at \"{reader.Path}\"");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
