using System;
using HanumanInstitute.OntraportApi.Converters;

namespace HanumanInstitute.OntraportApi.Models
{
    /// <summary>
    /// Represents the coupon product information.
    /// </summary>
    public class ApiCouponProduct : ApiObject
    {
        public ApiProperty<int> CouponIdField => _couponIdField ??= new ApiProperty<int>(this, CouponIdKey);
        private ApiProperty<int>? _couponIdField;
        public const string CouponIdKey = "coupon_id";
        public int? CouponId { get => CouponIdField.Value; set => CouponIdField.Value = value; }

        public ApiProperty<int> ProductIdField => _productIdField ??= new ApiProperty<int>(this, ProductIdKey);
        private ApiProperty<int>? _productIdField;
        public const string ProductIdKey = "product_id";
        public int? ProductId { get => ProductIdField.Value; set => ProductIdField.Value = value; }

        public ApiPropertyString ProductNameField => _productNameField ??= new ApiPropertyString(this, ProductNameKey);
        private ApiPropertyString? _productNameField;
        public const string ProductNameKey = "product_name";
        public string ProductName { get => ProductNameField.Value; set => ProductNameField.Value = value; }
    }
}
