using HanumanInstitute.OntraportApi.Models;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportMessagesTests : OntraportBaseWriteTests<OntraportMessages, ApiMessage>
{
    public OntraportMessagesTests(ITestOutputHelper output) :
        base(output, 2, "Message1")
    {
    }

}
