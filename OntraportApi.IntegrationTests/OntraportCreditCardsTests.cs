using System;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class OntraportCreditCardsTests : OntraportBaseReadTests<OntraportCreditCards, ApiCreditCard>
    {
        public OntraportCreditCardsTests(ITestOutputHelper output) :
            base(output, -1)
        {
        }

        [Fact]
        public async Task SetDefaultAsync_ValidId_ReturnsObjectWithId()
        {
            var api = SetupApi();

            var result = await api.SetDefaultAsync(ValidId);

            Assert.Equal(ValidId, result.Id.Value);
        }
    }
}
