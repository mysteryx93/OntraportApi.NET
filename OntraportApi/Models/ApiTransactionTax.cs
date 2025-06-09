namespace HanumanInstitute.OntraportApi.Models;

/// <summary>
/// Any array of price data should be included with products.
/// </summary>
public class ApiTransactionTax
{
    /// <summary>
    /// Gets or sets the ID of the existing tax object to apply to the offer.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the rate at which the offer should be taxed.
    /// </summary>
    public float? Rate { get; set; }

    /// <summary>
    /// Gets or sets the name of the tax to be applied.
    /// </summary>
    public string? Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets whether or not shipping charges should be taxed.
    /// </summary>
    public bool? TaxShipping { get; set; }

    /// <summary>
    /// Gets or sets the total amount of the applied taxes.
    /// </summary>
    public decimal? TaxTotal { get; set; }

    /// <summary>
    /// Gets or sets the ID of the related form, if any.
    /// </summary>
    [JsonPropertyName("form_id")]
    public long? FormId { get; set; }
}
