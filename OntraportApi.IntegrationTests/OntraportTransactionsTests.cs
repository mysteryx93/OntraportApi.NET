using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests
{
    public class OntraportTransactionsTests : OntraportBaseReadTests<OntraportTransactions, ApiTransaction>
    {
        public OntraportTransactionsTests(ITestOutputHelper output) :
            base(output, 1)
        {
        }

        [Fact]
        public async Task LogTransaction_Order_LoggedProperly()
        {
            var api = SetupApi();
            var apiObj = SetupObjectsApi();
            var contactId = await apiObj.GetObjectIdByEmailAsync(ApiObjectType.Contact, "a@test.com");
            var offer = new ApiTransactionOffer()
                .AddProduct(1, 2, 100);

            var result = await api.LogTransactionAsync(contactId.Value, offer);

            Assert.NotEqual(0, result);
        }

    }
}
