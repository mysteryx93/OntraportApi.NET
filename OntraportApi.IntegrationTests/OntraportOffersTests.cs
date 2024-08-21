using HanumanInstitute.OntraportApi.Models;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportOffersTests(ITestOutputHelper output) : 
    OntraportBaseWriteTests<OntraportOffers, ApiOffer>(output, 1, "NewOffer");
