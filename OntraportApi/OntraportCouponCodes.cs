namespace HanumanInstitute.OntraportApi;

/// <summary>
/// Provides Ontraport API support for CouponCode objects.
/// </summary>
public class OntraportCouponCodes : OntraportBaseRead<ApiCouponCode>, IOntraportCouponCodes
{
    public OntraportCouponCodes(OntraportHttpClient apiRequest) :
        base(apiRequest, "CouponCode", "CouponCodes")
    {
    }

}
