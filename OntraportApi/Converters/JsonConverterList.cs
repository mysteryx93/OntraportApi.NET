﻿using System.Globalization;

namespace HanumanInstitute.OntraportApi.Converters;

/// <summary>
/// Converts an */* delimited list into a managed list.
/// </summary>
public class JsonConverterList : JsonConverterBase<IList<long>>
{
    public const string Separator = "*/*";

    public override IList<long> Parse(string? value)
    {
        return (value ?? string.Empty)
            .Split([Separator], StringSplitOptions.RemoveEmptyEntries)
            .Select(x => long.Parse(x, CultureInfo.InvariantCulture))
            .ToList();
    }

    public override string? Format(IList<long> value)
    {
        if (value?.Any() == true)
        {
            return Separator + string.Join(Separator, value.Select(x => x.ToStringInvariant())) + Separator;
        }
        return Separator + Separator;
    }
}
