using System;
using HanumanInstitute.OntraportApi.Models;

namespace HanumanInstitute.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for CouponCode objects.
    /// </summary>
    public class OntraportCoupons : OntraportBaseDelete<ApiCoupon>, IOntraportCoupons
    {
        public OntraportCoupons(OntraportHttpClient apiRequest) :
            base(apiRequest, "Coupon", "Coupons", ApiCoupon.NameKey)
        {
        }

    }
}
