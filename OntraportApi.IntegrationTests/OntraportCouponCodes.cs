using HanumanInstitute.OntraportApi.Models;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportCouponCodesTests(ITestOutputHelper output) : 
    OntraportBaseReadTests<OntraportCouponCodes, ApiCouponCode>(output, 1);
