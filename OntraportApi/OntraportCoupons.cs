using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Newtonsoft.Json.Linq;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for CouponCode objects.
    /// </summary>
    public class OntraportCoupons : OntraportBaseDelete<ApiCoupon>, IOntraportCoupons
    {
        public OntraportCoupons(OntraportHttpClient apiRequest) :
            base(apiRequest, "Coupon", "Coupons", "name")
        {
        }

    }
}
