namespace HanumanInstitute.OntraportApi.Converters;

/// <summary>
/// Converts a Unix Epoch seconds field into a DateTimeOffset property.
/// </summary>
public class JsonConverterDateTimeNullable : JsonConverterBase<DateTimeOffset?>
{
    public bool Milliseconds { get; private set; }

    public JsonConverterDateTimeNullable()
    { }

    public JsonConverterDateTimeNullable(bool milliseconds)
    {
        Milliseconds = milliseconds;
    }

    public override string NullString => "0";

    public override DateTimeOffset? Parse(string? value)
    {
        if (!IsNullValue(value))
        {
            var valueLong = value!.Convert<long>();
            return Milliseconds ?
                DateTimeOffset.FromUnixTimeMilliseconds(valueLong) :
                DateTimeOffset.FromUnixTimeSeconds(valueLong);
        }
        return null;
    }

    public override string Format(DateTimeOffset? value) => 
        value != null ? Milliseconds ?
            ((DateTimeOffset)value).ToUnixTimeMilliseconds().ToStringInvariant() :
            ((DateTimeOffset)value).ToUnixTimeSeconds().ToStringInvariant() : "0";
}
