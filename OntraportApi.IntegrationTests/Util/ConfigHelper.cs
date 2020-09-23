using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using HanumanInstitute.OntraportApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace HanumanInstitute.OntraportApi.IntegrationTests
{
    [SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "Reviewed: Can't call AddUserSecrets if class is static")]
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "Reviewed: HttpClient needs to be disposed by OntraportPostForms or by the IOC container.")]
    public class ConfigHelper
    {
        public static OntraportHttpClient GetHttpClient(ILogger<OntraportHttpClient> logger = null)
        {
            // var factory = Mock.Of<IHttpClientFactory>(x => x.CreateClient(It.IsAny<string>()) == new HttpClient());
            return new OntraportHttpClient(new HttpClient(), GetConfig(), logger);
        }

        public static IOptions<OntraportConfig> GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<ConfigHelper>();
            var configuration = builder.Build();

            var appId = configuration["OntraportAppId"];
            var apiKey = configuration["OntraportApiKey"];

            if (string.IsNullOrEmpty(appId) || string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException(
@"Ontraport API credentials must be set in your User Secret Manager. Open the command-line tool and navigate to the OntraportApi.IntegrationTests project directory.

Use the following commands to set your keys. (Ask Ontraport for a SandBox account and get your keys in the admin section):
dotnet user-secrets set OntraportAppId ""your-app-id-here""
dotnet user-secrets set OntraportApiKey ""your-api-key-here""");
            }

            var config = new OntraportConfig()
            {
                AppId = appId,
                ApiKey = apiKey
            };
            return Mock.Of<IOptions<OntraportConfig>>(x => x.Value == config);
        }
    }
}
