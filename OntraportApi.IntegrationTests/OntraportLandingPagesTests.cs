using System;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class OntraportLandingPagesTests : OntraportBaseReadTests<OntraportLandingPages, ApiLandingPage>
    {
        public OntraportLandingPagesTests(ITestOutputHelper output) :
            base(output, 1)
        {
        }


    }
}
