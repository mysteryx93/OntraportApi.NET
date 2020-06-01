using System;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests
{
    public class OntraportCouponProductsTests : OntraportBaseReadTests<OntraportCouponProducts, ApiCouponProduct>
    {
        public OntraportCouponProductsTests(ITestOutputHelper output) :
            base(output, 3)
        {
        }

    }
}
