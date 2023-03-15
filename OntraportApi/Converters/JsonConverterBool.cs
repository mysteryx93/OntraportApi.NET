using System.Diagnostics.CodeAnalysis;

namespace HanumanInstitute.OntraportApi.Converters;

/// <summary>
/// Converts a "true" or "false" field into a boolean property.
/// </summary>
public class JsonConverterBool : JsonConverterBase<bool?>
{
    public override string Format(bool? value) => 
        value.HasValue ? (value == true ? "true" : "false") : "";

    [return: MaybeNull]
    public override bool? Parse(string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return null;
        }
        return (string.Compare(value, "true", StringComparison.InvariantCultureIgnoreCase) == 0 || 
                string.Compare(value, "1", StringComparison.InvariantCultureIgnoreCase) == 0);
    }
}
