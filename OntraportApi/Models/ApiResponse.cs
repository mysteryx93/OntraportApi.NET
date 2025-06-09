namespace HanumanInstitute.OntraportApi.Models;

/// <summary>
/// Represents a response from an Ontraport API call.
/// </summary>
public class ApiResponse<T>
    where T : class?
{
    public int Code { get; set; }
    public T Data { get; set; } = default!;
    [JsonPropertyName("account_id")]
    public long AccountId { get; set; }
}
