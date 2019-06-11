using System;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class OntraportCouponProductsTests : OntraportBaseReadTests<OntraportCouponProducts, ApiCouponProduct>
    {
        public OntraportCouponProductsTests(ITestOutputHelper output) :
            base(output, 3)
        {
        }

    }
}
