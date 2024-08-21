using System.Text.Json;

namespace HanumanInstitute.OntraportApi.Models;

public class ResponseSuccessList
{
    public ResponseSuccessList()
    {
    }

    /// <summary>
    /// Initializes a new instance of ResponseSuccessList and parses the data from a JSON parser.
    /// </summary>
    /// <param name="json"></param>
    public ResponseSuccessList(JsonElement json)
    {
        Check.NotNull(json);
        if (json.TryGetProperty("data", out var jsonData))
        {
            // Discard [], see JsonEmptyArrayConverter
            if (jsonData.TryGetProperty("success", out var jsonSuccess) && jsonSuccess.ValueKind != JsonValueKind.Array)
            {
                Success = jsonSuccess.ToObject<Dictionary<string, string>>();
            }
            if (jsonData.TryGetProperty("error", out var jsonError) && jsonError.ValueKind != JsonValueKind.Array)
            {
                Error = jsonError.ToObject<Dictionary<string, string>>();
            }
        }
    }

    public IDictionary<string, string> Success { get; private set; } = new Dictionary<string, string>();
    public IDictionary<string, string> Error { get; private set; } = new Dictionary<string, string>();
}
