using System.Text.Json;

namespace HanumanInstitute.OntraportApi;

public static class OntraportSerializerOptions
{
    /// <summary>
    /// Returns the default settings to serialize and deserialize Ontraport Json data.
    /// </summary>
    public static JsonSerializerOptions Default => s_default ??= SetupDefault();
    private static JsonSerializerOptions? s_default;
    private static JsonSerializerOptions SetupDefault()
    {
        var result = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            IgnoreNullValues = true
        };
        result.Converters.Add(new ApiSearchConditionListConverter());
        result.Converters.Add(new JsonConverterIntBool());
        result.Converters.Add(new JsonConverterDateTime());
        result.Converters.Add(new JsonConverterBase<string>());
        result.Converters.Add(new JsonConverterBase<int>());
        result.Converters.Add(new JsonConverterBase<int?>());
        result.Converters.Add(new JsonConverterBase<short>());
        result.Converters.Add(new JsonConverterBase<short?>());
        result.Converters.Add(new JsonConverterBase<long>());
        result.Converters.Add(new JsonConverterBase<long?>());
        result.Converters.Add(new JsonConverterBase<float>());
        result.Converters.Add(new JsonConverterBase<float?>());
        result.Converters.Add(new JsonConverterBase<double>());
        result.Converters.Add(new JsonConverterBase<double?>());
        return result;
    }
}
