using System;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class OntraportTransactionsTests : OntraportBaseReadTests<OntraportTransactions, ApiTransaction>
    {
        public OntraportTransactionsTests(ITestOutputHelper output) :
            base(output, 1)
        {
        }


    }
}
