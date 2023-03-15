using HanumanInstitute.OntraportApi.Models;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportLandingPagesTests : OntraportBaseReadTests<OntraportLandingPages, ApiLandingPage>
{
    public OntraportLandingPagesTests(ITestOutputHelper output) :
        base(output, 1)
    {
    }


}
