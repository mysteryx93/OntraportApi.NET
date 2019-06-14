using System;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class OntraportCompaniesTests : OntraportBaseCustomObjectTests<OntraportCompanies, ApiCompany>
    {
        public OntraportCompaniesTests(ITestOutputHelper output) :
            base(output, 1, "abc")
        { }

    }
}
