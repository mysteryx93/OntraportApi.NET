using System;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class OntraportCampaignItemBuildersTests : OntraportBaseReadTests<OntraportCampaignBuilderItems, ApiCampaignBuilderItem>
    {
        public OntraportCampaignItemBuildersTests(ITestOutputHelper output) :
            base(output, 1)
        {
        }
    }
}
