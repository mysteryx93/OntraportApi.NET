using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using EmergenceGuardian.OntraportApi;
using Microsoft.Extensions.DependencyInjection;

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
        public static IServiceCollection AddOntraportApi(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddHttpClient<OntraportHttpClient>();
            services.AddHttpClient<IOntraportPostForms, OntraportPostForms>();

            services.TryAddTransient<IOntraportCampaignBuilderItems, OntraportCampaignBuilderItems>();
            services.TryAddTransient<IOntraportCompanies, OntraportCompanies>();
            services.TryAddTransient<IOntraportContacts, OntraportContacts>();
            services.TryAddTransient<IOntraportCoupons, OntraportCoupons>();
            services.TryAddTransient<IOntraportCouponCodes, OntraportCouponCodes>();
            services.TryAddTransient<IOntraportCouponProducts, OntraportCouponProducts>();
            services.TryAddTransient<IOntraportCreditCards, OntraportCreditCards>();
            services.TryAddTransient<IOntraportCustomObjects, OntraportCustomObjects>();
            services.TryAddTransient<IOntraportDeals, OntraportDeals>();
            services.TryAddTransient<IOntraportForms, OntraportForms>();
            services.TryAddTransient<IOntraportLandingPages, OntraportLandingPages>();
            services.TryAddTransient<IOntraportMessages, OntraportMessages>();
            services.TryAddTransient<IOntraportObjects, OntraportObjects>();
            services.TryAddTransient<IOntraportOffers, OntraportOffers>();
            services.TryAddTransient<IOntraportProducts, OntraportProducts>();
            services.TryAddTransient<IOntraportRules, OntraportRules>();
            services.TryAddTransient<IOntraportTasks, OntraportTasks>();
            services.TryAddTransient<IOntraportTransactions, OntraportTransactions>();
            services.TryAddTransient<IOntraportWebhooks, OntraportWebhooks>();

            return services;
        }
    }
}
