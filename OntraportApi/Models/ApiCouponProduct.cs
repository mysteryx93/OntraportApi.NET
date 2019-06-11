using System;
using EmergenceGuardian.OntraportApi.Converters;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// Represents the coupon product information.
    /// </summary>
    public class ApiCouponProduct : ApiObject
    {
        public ApiPropertyInt CouponId => _couponId ?? (_couponId = new ApiPropertyInt(this, "coupon_id"));
        private ApiPropertyInt _couponId;
        public int CouponIdValue { get => CouponId.Value; set => CouponId.Value = value; }

        public ApiPropertyInt ProductId => _productId ?? (_productId = new ApiPropertyInt(this, "product_id"));
        private ApiPropertyInt _productId;
        public int ProductIdValue { get => ProductId.Value; set => ProductId.Value = value; }

        public ApiPropertyString ProductName => _productName ?? (_productName = new ApiPropertyString(this, "product_name"));
        private ApiPropertyString _productName;
        public string ProductNameValue { get => ProductName.Value; set => ProductName.Value = value; }

    }
}
