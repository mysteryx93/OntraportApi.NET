using System.Text.Json;

namespace HanumanInstitute.OntraportApi.Converters;

/// <summary>
/// Converts the list of conditions into the JSON format that Ontraport API expects.
/// </summary>
public class ApiSearchConditionListConverter : JsonConverter<List<ApiSearchConditionBase>>
{
    public override List<ApiSearchConditionBase> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    // It must produce Json data in this format.
    // https://api.ontraport.com/doc/#criteria

    //[{
    //  "field":{"field":"email"},
    //  "op":"=",
    //  "value":{"value":""}
    //},
    //"OR",
    //{
    //    "field":{ "field":"email"},
    //  "op":"IS",
    //  "value":"NULL"
    //}]

    //[{
    //    "field":{"field":"id"},
    //    "op":"IN",
    //    "value":{ "list":[{ "value":1},{ "value":2}]}
    //}]

    public override void Write(Utf8JsonWriter writer, List<ApiSearchConditionBase> value, JsonSerializerOptions options)
    {
        writer.CheckNotNull(nameof(writer));
        value.CheckNotNull(nameof(value));

        writer.WriteStartArray();

        var isFirst = true;
        foreach (var item in value)
        {
            // "OR",
            if (!isFirst)
            {
                writer.WriteStringValue(item.AndCond ? "AND" : "OR");
            }
            isFirst = false;

            writer.WriteStartObject();

            // "field":{ "field":"email"},
            writer.WriteStartObject("field");
            // writer.WritePropertyName("field");
            writer.WriteString("field", item.Field);
            writer.WriteEndObject();

            if (item is ApiSearchCondition cond)
            {
                if ((cond.Value == null || "".Equals(cond.Value) || "NULL".EqualsInvariant(cond.Value?.ToString())) && 
                    (cond.Op.EqualsInvariant("=") || cond.Op.EqualsInvariant("IS")))
                {
                    // "op":"IS",
                    // "value":"NULL"
                    writer.WriteString("op", "IS");
                    writer.WriteString("value", "NULL");
                }
                else
                {
                    // "op":"=",
                    // "value":{ "value":"test@test.com"}
                    writer.WriteString("op", cond.Op);

                    // "value":"NULL"
                    writer.WriteStartObject("value");
                    // writer.WriteStartObject("value");
                    writer.WriteString("value", cond.Value?.ToStringInvariant());
                    writer.WriteEndObject();
                }
            }
            else if (item is ApiSearchConditionInList condList)
            {
                // "op":"IN",
                writer.WriteString("op", "IN");

                // "value":{ "list":[{ "value":1},{ "value":2}]}
                writer.WriteStartObject("value");
                // writer.WriteStartObject("list");
                writer.WriteStartArray("list");
                foreach (var listItem in condList.Values)
                {
                    writer.WriteStartObject();
                    writer.WriteString("value", listItem?.ToStringInvariant());
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
                writer.WriteEndObject();
            }

            writer.WriteEndObject();
        }

        writer.WriteEndArray();
    }
}
