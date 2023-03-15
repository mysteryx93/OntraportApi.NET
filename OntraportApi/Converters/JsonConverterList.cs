using System.Globalization;

namespace HanumanInstitute.OntraportApi.Converters;

/// <summary>
/// Converts an */* delimited list into a managed list.
/// </summary>
public class JsonConverterList : JsonConverterBase<IList<int>>
{
    public const string Separator = "*/*";

    public override IList<int> Parse(string? value)
    {
        return (value ?? string.Empty)
            .Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x, CultureInfo.InvariantCulture))
            .ToList();
    }

    public override string? Format(IList<int> value)
    {
        if (value?.Any() == true)
        {
            return Separator + string.Join(Separator, value.Select(x => x.ToStringInvariant())) + Separator;
        }
        return Separator + Separator;
    }
}
