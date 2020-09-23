using System;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests
{
    public class OntraportCustomObjectsTests : OntraportBaseReadTests<OntraportCustomObjects, ApiCustomObject>
    {
        public OntraportCustomObjectsTests(ITestOutputHelper output) :
            base(output, 10001)
        {
        }

        [Fact]
        public async Task SelectAsync_ByName_ReturnsData()
        {
            using var c = CreateContext();

            var result = await c.Ontra.SelectAsync("Recordings");

            Assert.NotEmpty(result.Data);
        }
    }
}
