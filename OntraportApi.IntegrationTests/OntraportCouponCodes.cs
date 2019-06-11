using System;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class OntraportCouponCodesTests : OntraportBaseReadTests<OntraportCouponCodes, ApiCouponCode>
    {
        public OntraportCouponCodesTests(ITestOutputHelper output) :
            base(output, 1)
        {
        }

    }
}
