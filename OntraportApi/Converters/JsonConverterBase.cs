using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace HanumanInstitute.OntraportApi.Converters;

/// <summary>
/// Provides a simple way to convert between Ontraport API data and .NET types. Simply override Parse and Format.
/// This class has a dual purpose. It is used as attributes on properties to serialize, and it is used by ApiProperty.
/// </summary>
/// <typeparam name="TNull">The .NET nullable type to parse the data into.</typeparam>
public class JsonConverterBase<TNull> : JsonConverter<TNull>
{
    public override TNull Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        //return Parse(JsonSerializer.Deserialize<TNull>(ref reader, options)?.ToStringInvariant())!;
        var value = reader.GetValue<TNull>()?.ToStringInvariant();
        return Parse(value)!;
    }

    public override void Write(Utf8JsonWriter writer, TNull value, JsonSerializerOptions options) =>
        writer?.WriteStringValue(Format(value));

    //#pragma warning disable CS8764 // Nullability of return type doesn't match overridden member (possibly because of nullability attributes).
    //#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
    //        [return: MaybeNull]
    //        public override TNull Read(Utf8JsonReader reader, Type objectType, TNull existingValue, bool hasExistingValue, JsonSerializer serializer) =>
    //            Parse(reader?.Value?.ToStringInvariant());

    //        public override void Write(Utf8JsonWriter writer, TNull value, JsonSerializer serializer) =>
    //            writer?.WriteValue(Format(value));
    //#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
    //#pragma warning restore CS8764 // Nullability of return type doesn't match overridden member (possibly because of nullability attributes).

    /// <summary>
    /// Return whether specific value is to be considered null.
    /// </summary>
    public bool IsNullValue([NotNullWhen(false)] string? value) => value == null || value == NullString;

    /// <summary>
    /// Returns the string that represents a null value.
    /// </summary>
    public virtual string? NullString => "";

    /// <summary>
    /// When overriden in a derived class, parses Ontraport API data into data type T.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    /// <returns>The parsed value.</returns>
    [return: MaybeNull]
    public virtual TNull Parse(string? value) => value != null ? value.Convert<TNull>() : default;

    /// <summary>
    /// When overriden in a derived class, formats data of type T into Ontraport API format.
    /// </summary>
    /// <param name="value">The value to format.</param>
    /// <returns>The formatted value, usually a string or int.</returns>
    public virtual string? Format(TNull value) => value?.ToStringInvariant();

    /// <summary>
    /// Creates a null object if P is nullable, otherwise throws a NullReferenceException.
    /// </summary>
    /// <typeparam name="P">The type to set to null.</typeparam>
    //protected P CreateNull<P>(string jsonPath)
    //{
    //    if (typeof(P) == typeof(Nullable<T>))
    //    {
    //        return default(P);
    //    }
    //    else
    //    {
    //        var message = jsonPath != null ? $"Unexpected null value at '{jsonPath}'." : null;
    //        throw new NullReferenceException(message);
    //    }
    //}
}
