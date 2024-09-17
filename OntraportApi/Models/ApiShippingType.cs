namespace HanumanInstitute.OntraportApi.Models;

public class ApiShippingType : ApiObject
{
    /// <summary>
    /// Returns a ApiProperty object to get or set the shipping type's name.
    /// </summary>
    public ApiPropertyString NameField => _nameField ??= new ApiPropertyString(this, NameKey);
    private ApiPropertyString? _nameField;
    public const string NameKey = "name";
    /// <summary>
    /// Gets or sets the shipping type's name.
    /// </summary>
    public string? Name { get => NameField.Value; set => NameField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the shipping type's price.
    /// </summary>
    public ApiProperty<decimal> PriceField => _priceField ??= new ApiProperty<decimal>(this, PriceKey);
    private ApiProperty<decimal>? _priceField;
    public const string PriceKey = "price";
    /// <summary>
    /// Gets or sets the shipping type's price.
    /// </summary>
    public decimal? Price { get => PriceField.Value; set => PriceField.Value = value; }
}
