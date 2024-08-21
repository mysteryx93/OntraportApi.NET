using HanumanInstitute.OntraportApi.Models;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportCouponProductsTests(ITestOutputHelper output) : 
    OntraportBaseReadTests<OntraportCouponProducts, ApiCouponProduct>(output, 3);
