using System;
using HanumanInstitute.OntraportApi.Models;

namespace HanumanInstitute.OntraportApi
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
