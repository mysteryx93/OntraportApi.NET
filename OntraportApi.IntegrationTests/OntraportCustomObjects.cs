using System;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
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
            var api = SetupApi();

            var result = await api.SelectAsync("Recordings");

            Assert.NotEmpty(result.Data);
        }
    }
}
