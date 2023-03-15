namespace HanumanInstitute.OntraportApi.Models;

/// <summary>
/// An Ontraport field for editing queries.
/// </summary>
public class ApiFieldEditor
{
    public string? Field { get; set; } = string.Empty;

    public string? Alias { get; set; } = string.Empty;

    [JsonConverter(typeof(JsonConverterStringEnum<ApiFieldType>))]
    public ApiFieldType? Type { get; set; }

    public bool? Required { get; set; }

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
