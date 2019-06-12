using System;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class OntraportMessagesTests : OntraportBaseWriteTests<OntraportMessages, ApiMessage>
    {
        public OntraportMessagesTests(ITestOutputHelper output) :
            base(output, 2, "Message1")
        {
        }

    }
}
