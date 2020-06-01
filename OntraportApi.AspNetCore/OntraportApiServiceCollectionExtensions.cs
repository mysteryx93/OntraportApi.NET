using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using HanumanInstitute.OntraportApi;
using HanumanInstitute.OntraportApi.Models;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace - MS guidelines say put DI registration in this NS
namespace Microsoft.Extensions.DependencyInjection
{
    public static class OntraportApiServiceCollectionExtensions
    {
        /// <summary>
        /// Registers OntraportApi classes into the IoC container.
        /// </summary>
        /// <param name="services">The IoC services container.</param>
        public static IServiceCollection AddOntraportApi(this IServiceCollection services) =>
            AddOntraportApi(services, null);

        /// <summary>
        /// Registers OntraportApi classes into the IoC container.
        /// </summary>
        /// <param name="services">The IoC services container.</param>
        /// <param name="additionalHttpConfig">Additional configuration to be applied to HttpClient connections.</param>
        public static IServiceCollection AddOntraportApi(this IServiceCollection services, Action<IHttpClientBuilder> additionalHttpConfig)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var ontraClient = services.AddHttpClient<OntraportHttpClient>();
            var formsClient = services.AddHttpClient<IOntraportPostForms, OntraportPostForms>();
            if (additionalHttpConfig != null)
            {
                additionalHttpConfig(ontraClient);
                additionalHttpConfig(formsClient);
            }

            services.TryAddTransient<IOntraportCampaignBuilderItems, OntraportCampaignBuilderItems>();
            services.TryAddTransient<IOntraportCompanies<ApiCompany>, OntraportCompanies<ApiCompany>>();
            services.TryAddTransient<IOntraportContacts<ApiContact>, OntraportContacts<ApiContact>>();
            services.TryAddTransient<IOntraportCoupons, OntraportCoupons>();
            services.TryAddTransient<IOntraportCouponCodes, OntraportCouponCodes>();
            services.TryAddTransient<IOntraportCouponProducts, OntraportCouponProducts>();
            services.TryAddTransient<IOntraportCreditCards, OntraportCreditCards>();
            services.TryAddTransient<IOntraportCustomObjects, OntraportCustomObjects>();
            services.TryAddTransient<IOntraportDeals<ApiDeal>, OntraportDeals<ApiDeal>>();
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

        /// <summary>
        /// Registers only OntraportApi classes to post forms, without adding the API.
        /// </summary>
        /// <param name="services">The IoC services container.</param>
        public static IServiceCollection AddOntraportPostForms(this IServiceCollection services) =>
            AddOntraportPostForms(services, null);

        /// <summary>
        /// Registers only OntraportApi classes to post forms, without adding the API.
        /// </summary>
        /// <param name="services">The IoC services container.</param>
        /// <param name="additionalHttpConfig">Additional configuration to be applied to HttpClient connections.</param>
        public static IServiceCollection AddOntraportPostForms(this IServiceCollection services, Action<IHttpClientBuilder> additionalHttpConfig)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var ontraClient = services.AddHttpClient<OntraportHttpClient>();
            var formsClient = services.AddHttpClient<IOntraportPostForms, OntraportPostForms>();
            additionalHttpConfig?.Invoke(formsClient);

            return services;
        }
    }
}
