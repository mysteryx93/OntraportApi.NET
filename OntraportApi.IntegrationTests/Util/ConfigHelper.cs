using System;
using Microsoft.Extensions.Configuration;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class ConfigHelper
    {
        public ApiConfig GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<ConfigHelper>();
            var Configuration = builder.Build();

            var AppId = Configuration["OntraportAppId"];
            var ApiKey = Configuration["OntraportApiKey"];

            if (string.IsNullOrEmpty(AppId) || string.IsNullOrEmpty(ApiKey))
            {
                throw new ArgumentException(
@"Ontraport API credentials must be set in your User Secret Manager. Open the command-line tool and navigate to the OntraportApi.IntegrationTests project directory.

Use the following commands to set your keys. (Ask Ontraport for a SandBox account and get your keys in the admin section):
dotnet user-secrets set OntraportAppId ""your-app-id-here""
dotnet user-secrets set OntraportApiKey ""your-api-key-here""");
            }

            return new ApiConfig()
            {
                AppId = AppId,
                ApiKey = ApiKey
            };
        }
    }
}
