using System;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests
{
    public class OntraportCouponCodesTests : OntraportBaseReadTests<OntraportCouponCodes, ApiCouponCode>
    {
        public OntraportCouponCodesTests(ITestOutputHelper output) :
            base(output, 1)
        {
        }

    }
}
