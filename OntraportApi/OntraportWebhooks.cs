﻿namespace HanumanInstitute.OntraportApi;

/// <summary>
/// Provides Ontraport API support for Webhook objects.
/// You can use webhooks subscriptions to receive notifications about events occurring within your Ontraport account.
/// </summary>
public class OntraportWebhooks : OntraportBaseRead<ApiWebhook>, IOntraportWebhooks
{
    public OntraportWebhooks(OntraportHttpClient apiRequest) : 
        base(apiRequest, "Webhook", "Webhooks")
    { }

    /// <summary>
    /// Subscribes to a new webhook.
    /// </summary>
    /// <param name="url">The URL to send the payload to.</param>
    /// <param name="eventName">The event to subscribe to.</param>
    /// <param name="data">Additional information about the format of the payload.</param>
    /// <returns>The created WebHook.</returns>
    public async Task<ApiWebhook> SubscribeAsync(string url, string eventName, string? data, CancellationToken cancellationToken = default)
    {
        var query = new Dictionary<string, object?>
            {
                { "url", url },
                { "event", eventName },
            }
            .AddIfHasValue("data", data);

        var json = await ApiRequest.PostJsonAsync(
            "Webhook/subscribe", query, false, cancellationToken).ConfigureAwait(false);
        return await json.RunAndCatchAsync(x => CreateApiObject(json.JsonData())).ConfigureAwait(false);
    }

    /// <summary>
    /// Unsubscribe from a specific webhook by its ID.
    /// </summary>
    /// <param name="webhookId">The ID of the webhook to unsubscribe from. Required.</param>
    public async Task UnsubscribeAsync(long webhookId, CancellationToken cancellationToken = default)
    {
        var query = new Dictionary<string, object?>
        {
            { "id", webhookId }
        };

        await ApiRequest.DeleteAsync<object>(
            "Webhook/unsubscribe", query, true, cancellationToken).ConfigureAwait(false);
    }
}
