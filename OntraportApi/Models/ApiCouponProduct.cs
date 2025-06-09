namespace HanumanInstitute.OntraportApi.Models;

/// <summary>
/// Represents the coupon product information.
/// </summary>
public class ApiCouponProduct : ApiObject
{
    public ApiProperty<long> CouponIdField => _couponIdField ??= new ApiProperty<long>(this, CouponIdKey);
    private ApiProperty<long>? _couponIdField;
    public const string CouponIdKey = "coupon_id";
    public long? CouponId { get => CouponIdField.Value; set => CouponIdField.Value = value; }

    public ApiProperty<long> ProductIdField => _productIdField ??= new ApiProperty<long>(this, ProductIdKey);
    private ApiProperty<long>? _productIdField;
    public const string ProductIdKey = "product_id";
    public long? ProductId { get => ProductIdField.Value; set => ProductIdField.Value = value; }

    public ApiPropertyString ProductNameField => _productNameField ??= new ApiPropertyString(this, ProductNameKey);
    private ApiPropertyString? _productNameField;
    public const string ProductNameKey = "product_name";
    public string? ProductName { get => ProductNameField.Value; set => ProductNameField.Value = value; }
}
