using System;
using EmergenceGuardian.OntraportApi.Converters;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// Represents the coupon product information.
    /// </summary>
    public class ApiCouponProduct : ApiObject
    {
        public ApiProperty<int> CouponId => _couponId ?? (_couponId = new ApiProperty<int>(this, "coupon_id"));
        private ApiProperty<int> _couponId;
        public int CouponIdValue { get => CouponId.Value; set => CouponId.Value = value; }

        public ApiProperty<int> ProductId => _productId ?? (_productId = new ApiProperty<int>(this, "product_id"));
        private ApiProperty<int> _productId;
        public int ProductIdValue { get => ProductId.Value; set => ProductId.Value = value; }

        public ApiPropertyString ProductName => _productName ?? (_productName = new ApiPropertyString(this, "product_name"));
        private ApiPropertyString _productName;
        public string ProductNameValue { get => ProductName.Value; set => ProductName.Value = value; }

    }
}
