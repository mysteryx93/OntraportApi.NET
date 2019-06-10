using System;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class OntraportProductsTests : OntraportBaseDeleteTests<OntraportProducts, ApiProduct>
    {
        public OntraportProductsTests(ITestOutputHelper output) :
            base(output, 1)
        {
        }


    }
}
