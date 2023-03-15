using HanumanInstitute.OntraportApi.Models;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportOffersTests : OntraportBaseWriteTests<OntraportOffers, ApiOffer>
{
    public OntraportOffersTests(ITestOutputHelper output) :
        base(output, 1, "NewOffer")
    {
    }


}
