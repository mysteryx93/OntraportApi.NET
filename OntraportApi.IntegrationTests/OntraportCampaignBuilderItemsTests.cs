using HanumanInstitute.OntraportApi.Models;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportCampaignItemBuildersTests(ITestOutputHelper output)
    : OntraportBaseReadTests<OntraportCampaignBuilderItems, ApiCampaignBuilderItem>(output, 1);
