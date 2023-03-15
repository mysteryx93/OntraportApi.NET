using HanumanInstitute.OntraportApi.Models;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportCouponsTests : OntraportBaseDeleteTests<OntraportCoupons, ApiCoupon>
{
    public OntraportCouponsTests(ITestOutputHelper output) :
        base(output, 2, "GroupCoupon1")
    {
    }

}
