using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Globalization;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi.Converters
{
    /// <summary>
    /// Provides a simple way to convert between Ontraport API data and .NET types. Simply override Parse and Format.
    /// This class has a dual purpose. It is used as attributes on properties to serialize, and it is used by ApiProperty.
    /// </summary>
    /// <typeparam name="T">The .NET type to parse the data into.</typeparam>
    public class JsonConverterBase<T> : JsonConverter<Nullable<T>>
        where T : struct
    {
        public override Nullable<T> ReadJson(JsonReader reader, Type objectType, Nullable<T> existingValue, bool hasExistingValue, JsonSerializer serializer) =>
            Parse<Nullable<T>>(reader.Value?.ToString(), reader.Path);

        public override void WriteJson(JsonWriter writer, Nullable<T> value, JsonSerializer serializer) =>
            writer.WriteValue(Format(value));

        /// <summary>
        /// Returns a string considered as null value for this type.
        /// </summary>
        public virtual string NullString => null;

        /// <summary>
        /// When overriden in a derived class, parses Ontraport API data into data type T.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <returns>The parsed value.</returns>
        public virtual P Parse<P>(string value, string jsonPath = null) => value != null ? value.Convert<P>() : CreateNull<P>(jsonPath);

        /// <summary>
        /// When overriden in a derived class, formats data of type T into Ontraport API format.
        /// </summary>
        /// <param name="value">The value to format.</param>
        /// <returns>The formatted value, usually a string or int.</returns>
        public virtual object Format(Nullable<T> value) => value?.ToString();

        /// <summary>
        /// Creates a null object if P is nullable, otherwise throws a NullReferenceException.
        /// </summary>
        /// <typeparam name="P">The type to set to null.</typeparam>
        protected P CreateNull<P>(string jsonPath)
        {
            if (typeof(P) == typeof(Nullable<T>))
            {
                return default(P);
            }
            else
            {
                var message = jsonPath != null ? $"Unexpected null value at '{jsonPath}'." : null;
                throw new NullReferenceException(message);
            }
        }
    }
}
