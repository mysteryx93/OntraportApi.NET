namespace HanumanInstitute.OntraportApi.Converters;

/// <summary>
/// Converts an enumeration stored as long.
/// </summary>
public class ApiPropertyList : ApiPropertyBase<IList<long>, IList<long>>
{
    /// <summary>
    /// Initializes a new instance of the ApiProperty class for specified ApiObject host and field key.
    /// </summary>
    /// <param name="host">The ApiObject containing the data.</param>
    /// <param name="key">The field key represented by this property.</param>
    /// <param name="lowerCase">Whether to format Enum values as lowercase.</param>
    public ApiPropertyList(ApiObject host, string key) :
        base(host, key, new JsonConverterList())
    { }

    /// <summary>
    /// Marks the list as changed. Changes to the list are not automatically tracked.
    /// </summary>
    public void Changed() => Set(Value!);
}
