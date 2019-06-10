using System;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class OntraportCampaignItemBuildersTests : OntraportBaseReadTests<OntraportCreditCards, ApiCreditCard>
    {
        public OntraportCampaignItemBuildersTests(ITestOutputHelper output) :
            base(output, 1)
        {
        }
    }
}
