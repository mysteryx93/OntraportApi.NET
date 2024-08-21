using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportWebhookTests(ITestOutputHelper output) : 
    OntraportBaseReadTests<OntraportWebhooks, ApiWebhook>(output, 1)
{
    [Fact]
    public async Task Subscribe_ValidData_ReturnsIdAndUnsubscribe()
    {
        using var c = CreateContext();
        var url = "https://test98676342.32";
        var eventName = "object_create(0)";

        var result = await c.Ontra.SubscribeAsync(url, eventName, null);

        Assert.NotNull(result);
        await c.Ontra.UnsubscribeAsync(result.Id!.Value);
    }
}
