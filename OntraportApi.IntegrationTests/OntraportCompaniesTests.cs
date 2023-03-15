using HanumanInstitute.OntraportApi.Models;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportCompaniesTests : OntraportBaseCustomObjectTests<OntraportCompanies<ApiCompany>, ApiCompany>
{
    public OntraportCompaniesTests(ITestOutputHelper output) :
        base(output, 1, "abc")
    { }

}
