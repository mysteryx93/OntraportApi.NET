using HanumanInstitute.OntraportApi.Models;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportCouponCodesTests : OntraportBaseReadTests<OntraportCouponCodes, ApiCouponCode>
{
    public OntraportCouponCodesTests(ITestOutputHelper output) :
        base(output, 1)
    {
    }

}
