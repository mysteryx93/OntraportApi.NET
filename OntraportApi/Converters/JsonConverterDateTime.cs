namespace HanumanInstitute.OntraportApi.Converters;

/// <summary>
/// Converts a Unix Epoch seconds field into a DateTimeOffset property.
/// </summary>
public class JsonConverterDateTime : JsonConverterBase<DateTimeOffset>
{
    public bool Milliseconds { get; private set; }

    public JsonConverterDateTime()
    { }

    public JsonConverterDateTime(bool milliseconds)
    {
        Milliseconds = milliseconds;
    }

    public override string NullString => "0";

    public override DateTimeOffset Parse(string? value)
    {
        if (!IsNullValue(value))
        {
            var valueLong = value!.Convert<long>();
            return Milliseconds ?
                DateTimeOffset.FromUnixTimeMilliseconds(valueLong) :
                DateTimeOffset.FromUnixTimeSeconds(valueLong);
        }
        return DateTimeOffset.MinValue;
    }

    public override string Format(DateTimeOffset value) => 
        Milliseconds ?
            value.ToUnixTimeMilliseconds().ToStringInvariant() :
            value.ToUnixTimeSeconds().ToStringInvariant();
}
