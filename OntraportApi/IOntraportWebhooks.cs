using System;
using System.Threading;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;

namespace HanumanInstitute.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for Webhook objects.
    /// You can use webhooks subscriptions to receive notifications about events occurring within your Ontraport account.
    /// </summary>
    public interface IOntraportWebhooks : IOntraportBaseRead<ApiWebhook>
    {
        /// <summary>
        /// Subscribes to a new webhook.
        /// </summary>
        /// <param name="url">The URL to send the payload to.</param>
        /// <param name="eventName">The event to subscribe to.</param>
        /// <param name="data">Additional information about the format of the payload.</param>
        /// <returns>The created WebHook.</returns>
        Task<ApiWebhook> SubscribeAsync(string url, string eventName, string data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Unsubscribe from a specific webhook by its ID.
        /// </summary>
        /// <param name="webhookId">The ID of the webhook to unsubscribe from. Required.</param>
        Task UnsubscribeAsync(int webhookId, CancellationToken cancellationToken = default);
    }
}
