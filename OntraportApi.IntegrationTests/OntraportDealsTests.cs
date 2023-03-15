using HanumanInstitute.OntraportApi.Models;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportDealsTests : OntraportBaseCustomObjectTests<OntraportDeals<ApiDeal>, ApiDeal>
{
    public OntraportDealsTests(ITestOutputHelper output) :
        base(output, 1, "deal1")
    {
    }

}
