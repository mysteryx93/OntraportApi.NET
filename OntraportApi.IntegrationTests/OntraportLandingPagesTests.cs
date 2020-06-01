using System;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests
{
    public class OntraportLandingPagesTests : OntraportBaseReadTests<OntraportLandingPages, ApiLandingPage>
    {
        public OntraportLandingPagesTests(ITestOutputHelper output) :
            base(output, 1)
        {
        }


    }
}
