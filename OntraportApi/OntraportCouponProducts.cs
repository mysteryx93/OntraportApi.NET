using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Newtonsoft.Json.Linq;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for CouponProducts objects.
    /// </summary>
    public class OntraportCouponProducts : OntraportBaseRead<ApiCouponProduct>, IOntraportCouponProducts
    {
        public OntraportCouponProducts(OntraportHttpClient apiRequest) :
            base(apiRequest, "CouponProduct", "CouponProducts")
        {
        }

    }
}
