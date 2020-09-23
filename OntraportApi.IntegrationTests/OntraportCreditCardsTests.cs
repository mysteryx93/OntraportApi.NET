using System;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests
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
            using var c = CreateContext();

            var result = await c.Ontra.SetDefaultAsync(ValidId);

            Assert.Equal(ValidId, result.Id!.Value);
        }
    }
}
