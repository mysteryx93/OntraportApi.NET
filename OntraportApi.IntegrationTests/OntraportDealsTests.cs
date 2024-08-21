using HanumanInstitute.OntraportApi.Models;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportDealsTests(ITestOutputHelper output) : 
    OntraportBaseCustomObjectTests<OntraportDeals<ApiDeal>, ApiDeal>(output, 1, "deal1");
