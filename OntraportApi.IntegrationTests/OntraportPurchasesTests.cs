using HanumanInstitute.OntraportApi.Models;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportPurchasesTests(ITestOutputHelper output) : OntraportBaseReadTests<OntraportPurchases, ApiPurchase>(output, 1);
