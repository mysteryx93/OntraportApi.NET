namespace HanumanInstitute.OntraportApi.Models;

/// <summary>
/// An array of shipping data can be included with an offer where shipping is applicable.
/// </summary>
public class ApiTransactionShipping
{
    /// <summary>
    /// Gets or sets the ID of the shipping method being applied to the offer. This must be an existing shipping method.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the shipping method being used.
    /// </summary>
    public string? Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the cost of charges incurred for this shipping method.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the ID of the related form, if any.
    /// </summary>
    [JsonPropertyName("form_id")]
    public int? FormId { get; set; }
}
