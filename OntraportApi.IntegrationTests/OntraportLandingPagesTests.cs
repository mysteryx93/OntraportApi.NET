using HanumanInstitute.OntraportApi.Models;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportLandingPagesTests(ITestOutputHelper output) : 
    OntraportBaseReadTests<OntraportLandingPages, ApiLandingPage>(output, 1);
