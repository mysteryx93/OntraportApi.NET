using System;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportShippingTypesTests : OntraportBaseDeleteTests<OntraportCoupons, ApiCoupon>
{
    public OntraportShippingTypesTests(ITestOutputHelper output) :
        base(output, 1, "shippingType1")
    {
    }
}
