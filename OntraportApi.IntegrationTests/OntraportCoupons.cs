using System;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class OntraportCouponsTests : OntraportBaseDeleteTests<OntraportCoupons, ApiCoupon>
    {
        public OntraportCouponsTests(ITestOutputHelper output) :
            base(output, 2)
        {
        }

    }
}
