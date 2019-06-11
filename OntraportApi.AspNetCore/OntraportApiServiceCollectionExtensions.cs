using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using EmergenceGuardian.OntraportApi;

// ReSharper disable once CheckNamespace - MS guidelines say put DI registration in this NS
namespace Microsoft.Extensions.DependencyInjection
{
    public static class OntraportApiServiceCollectionExtensions
    {
        public static IServiceCollection AddOntraportApi(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.TryAdd(ServiceDescriptor.Singleton<IOntraportCampaignBuilderItems, OntraportCampaignBuilderItems>());
            services.TryAdd(ServiceDescriptor.Singleton<IOntraportCompanies, OntraportCompanies>());
            services.TryAdd(ServiceDescriptor.Singleton<IOntraportContacts, OntraportContacts>());
            services.TryAdd(ServiceDescriptor.Singleton<IOntraportCoupons, OntraportCoupons>());
            services.TryAdd(ServiceDescriptor.Singleton<IOntraportCouponCodes, OntraportCouponCodes>());
            services.TryAdd(ServiceDescriptor.Singleton<IOntraportCouponProducts, OntraportCouponProducts>());
            services.TryAdd(ServiceDescriptor.Singleton<IOntraportCreditCards, OntraportCreditCards>());
            services.TryAdd(ServiceDescriptor.Singleton<IOntraportCustomObjects, OntraportCustomObjects>());
            services.TryAdd(ServiceDescriptor.Singleton<IOntraportDeals, OntraportDeals>());
            services.TryAdd(ServiceDescriptor.Singleton<IOntraportForms, OntraportForms>());
            services.TryAdd(ServiceDescriptor.Singleton<IOntraportLandingPages, OntraportLandingPages>());
            services.TryAdd(ServiceDescriptor.Singleton<IOntraportMessages, OntraportMessages>());
            services.TryAdd(ServiceDescriptor.Singleton<IOntraportObjects, OntraportObjects>());
            services.TryAdd(ServiceDescriptor.Singleton<IOntraportOffers, OntraportOffers>());
            services.TryAdd(ServiceDescriptor.Singleton<IOntraportProducts, OntraportProducts>());
            services.TryAdd(ServiceDescriptor.Singleton<IOntraportRules, OntraportRules>());
            services.TryAdd(ServiceDescriptor.Singleton<IOntraportTasks, OntraportTasks>());
            services.TryAdd(ServiceDescriptor.Singleton<IOntraportTransactions, OntraportTransactions>());
            services.TryAdd(ServiceDescriptor.Singleton<IOntraportWebhooks, OntraportWebhooks>());
            services.TryAdd(ServiceDescriptor.Singleton<IWebRequestService, WebRequestService>());
            services.TryAdd(ServiceDescriptor.Singleton<IOntraportRequestHelper, OntraportRequestHelper>());

            return services;
        }
    }
}
