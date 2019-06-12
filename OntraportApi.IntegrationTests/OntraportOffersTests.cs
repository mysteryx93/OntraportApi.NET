using System;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class OntraportOffersTests : OntraportBaseWriteTests<OntraportOffers, ApiOffer>
    {
        public OntraportOffersTests(ITestOutputHelper output) :
            base(output, 1, null)
        {
        }


    }
}
