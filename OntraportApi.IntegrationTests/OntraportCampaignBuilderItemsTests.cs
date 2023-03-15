using HanumanInstitute.OntraportApi.Models;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportCampaignItemBuildersTests : OntraportBaseReadTests<OntraportCampaignBuilderItems, ApiCampaignBuilderItem>
{
    public OntraportCampaignItemBuildersTests(ITestOutputHelper output) :
        base(output, 1)
    {
    }
}
