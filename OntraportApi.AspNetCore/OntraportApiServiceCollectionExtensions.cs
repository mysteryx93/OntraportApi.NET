using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using EmergenceGuardian.OntraportApi;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace - MS guidelines say put DI registration in this NS
namespace Microsoft.Extensions.DependencyInjection
{
    public static class OntraportApiServiceCollectionExtensions
    {
        /// <summary>
        /// Registers OntraportApi classes into the IoC container. If options is null, only IWebRequestService will be registered.
        /// </summary>
        /// <param name="services">The IoC services container.</param>
        /// <param name="options">The OntraportApi configuration with API keys.</param>
        public static IServiceCollection AddOntraportApi(this IServiceCollection services, IOptions<OntraportConfig> options)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.TryAdd(ServiceDescriptor.Transient<IWebRequestService, WebRequestService>());

            if (options != null)
            {
                services.TryAdd(ServiceDescriptor.Transient<IOntraportRequestHelper, OntraportRequestHelper>());
                services.TryAdd(ServiceDescriptor.Singleton<OntraportConfig>((x) => options.Value));
                services.TryAdd(ServiceDescriptor.Transient<IOntraportCampaignBuilderItems, OntraportCampaignBuilderItems>());
                services.TryAdd(ServiceDescriptor.Transient<IOntraportCompanies, OntraportCompanies>());
                services.TryAdd(ServiceDescriptor.Transient<IOntraportContacts, OntraportContacts>());
                services.TryAdd(ServiceDescriptor.Transient<IOntraportCoupons, OntraportCoupons>());
                services.TryAdd(ServiceDescriptor.Transient<IOntraportCouponCodes, OntraportCouponCodes>());
                services.TryAdd(ServiceDescriptor.Transient<IOntraportCouponProducts, OntraportCouponProducts>());
                services.TryAdd(ServiceDescriptor.Transient<IOntraportCreditCards, OntraportCreditCards>());
                services.TryAdd(ServiceDescriptor.Transient<IOntraportCustomObjects, OntraportCustomObjects>());
                services.TryAdd(ServiceDescriptor.Transient<IOntraportDeals, OntraportDeals>());
                services.TryAdd(ServiceDescriptor.Transient<IOntraportForms, OntraportForms>());
                services.TryAdd(ServiceDescriptor.Transient<IOntraportLandingPages, OntraportLandingPages>());
                services.TryAdd(ServiceDescriptor.Transient<IOntraportMessages, OntraportMessages>());
                services.TryAdd(ServiceDescriptor.Transient<IOntraportObjects, OntraportObjects>());
                services.TryAdd(ServiceDescriptor.Transient<IOntraportOffers, OntraportOffers>());
                services.TryAdd(ServiceDescriptor.Transient<IOntraportProducts, OntraportProducts>());
                services.TryAdd(ServiceDescriptor.Transient<IOntraportRules, OntraportRules>());
                services.TryAdd(ServiceDescriptor.Transient<IOntraportTasks, OntraportTasks>());
                services.TryAdd(ServiceDescriptor.Transient<IOntraportTransactions, OntraportTransactions>());
                services.TryAdd(ServiceDescriptor.Transient<IOntraportWebhooks, OntraportWebhooks>());
            }

            return services;
        }
    }
}
