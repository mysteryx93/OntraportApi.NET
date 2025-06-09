using System.Text.Json;

namespace HanumanInstitute.OntraportApi.Converters;

/// <summary>
/// Converts a "0" or "1" field into a boolean property.
/// </summary>
public class JsonConverterIntBoolNullable : JsonConverterBase<bool?>
{
    public override bool? Parse(string? value)
    {
        // Different forms may use either a binary integer or boolean value for deleted field.
        int? valueInt = null;
        if (value == "true" || value == "True")
        {
            valueInt = 1;
        }
        else if (value == "false" || value == "False")
        {
            valueInt = 0;
        }
        else if (!IsNullValue(value) && value != "null")
        {
            valueInt = value?.Convert<int?>();
        }
        return valueInt.HasValue ? valueInt == 1 : (bool?)null;
    }

    public override string Format(bool? value) =>
        value.HasValue ? (value == true ? "1" : "0") : "";
}
