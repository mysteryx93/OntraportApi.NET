using HanumanInstitute.OntraportApi.Models;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportCouponsTests(ITestOutputHelper output) : 
    OntraportBaseDeleteTests<OntraportCoupons, ApiCoupon>(output, 2, "GroupCoupon1");
