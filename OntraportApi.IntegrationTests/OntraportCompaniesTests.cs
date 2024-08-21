using HanumanInstitute.OntraportApi.Models;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportCompaniesTests(ITestOutputHelper output)
    : OntraportBaseCustomObjectTests<OntraportCompanies<ApiCompany>, ApiCompany>(output, 1, "abc");
