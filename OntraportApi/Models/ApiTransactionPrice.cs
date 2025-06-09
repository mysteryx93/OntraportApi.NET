namespace HanumanInstitute.OntraportApi.Models;

/// <summary>
/// Any array of price data should be included with products.
/// </summary>
public class ApiTransactionPrice
{
    /// <summary>
    /// Gets or sets the ID of the pricing item.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// If a payment plan item, gets or sets the number of payments to be made.
    /// </summary>
    [JsonPropertyName("payment_count")]
    public int? PaymentCount { get; set; }

    /// <summary>
    /// Gets or sets the units of time of payments.
    /// </summary>
    [JsonConverter(typeof(JsonConverterStringEnum<TransactionPeriodUnit>))]
    public TransactionPeriodUnit? Unit { get; set; }
}
