using System;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class OntraportDealsTests : OntraportBaseCustomObjectTests<OntraportDeals, ApiDeal>
    {
        public OntraportDealsTests(ITestOutputHelper output) :
            base(output, 1, "deal1")
        {
        }

    }
}
