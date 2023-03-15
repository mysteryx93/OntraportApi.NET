namespace HanumanInstitute.OntraportApi.Converters;

/// <summary>
/// Converts an enumeration stored as int.
/// </summary>
public class ApiPropertyIntEnum<T> : ApiProperty<T>
    where T : struct
{
    /// <summary>
    /// Initializes a new instance of the ApiProperty class for specified ApiObject host and field key.
    /// </summary>
    /// <param name="host">The ApiObject containing the data.</param>
    /// <param name="key">The field key represented by this property.</param>
    /// <param name="lowerCase">Whether to format Enum values as lowercase.</param>
    public ApiPropertyIntEnum(ApiObject host, string key) : 
        base(host, key, new JsonConverterIntEnum<T>())
    { }
}
