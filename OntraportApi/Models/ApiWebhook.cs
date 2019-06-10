using System;
using EmergenceGuardian.OntraportApi.Converters;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// You can use webhooks subscriptions to receive notifications about events occurring within your Ontraport account.
    /// </summary>
    public class ApiWebhook : ApiObject
    {
        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the user who controls the webhook object. This field must contain a value for a webhook object to be saved properly.
        /// </summary>
        public ApiPropertyInt Owner => _owner ?? (_owner = new ApiPropertyInt(this, "owner"));
        private ApiPropertyInt _owner;
        /// <summary>
        /// Gets or sets the ID of the user who controls the webhook object. This field must contain a value for a webhook object to be saved properly.
        /// </summary>
        public int OwnerValue { get => Owner.Value; set => Owner.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the event triggering the webhook.
        /// </summary>
        public ApiPropertyString Event => _event ?? (_event = new ApiPropertyString(this, "event"));
        private ApiPropertyString _event;
        /// <summary>
        /// Gets or sets the event triggering the webhook.
        /// </summary>
        public string EventValue { get => Event.Value; set => Event.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set additional json-formatted data regarding the format of the payload.
        /// </summary>
        public ApiPropertyString Content => _content ?? (_content = new ApiPropertyString(this, "data"));
        private ApiPropertyString _content;
        /// <summary>
        /// Gets or sets additional json-formatted data regarding the format of the payload.
        /// </summary>
        public string ContentValue { get => Content.Value; set => Content.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the URL the payload should be sent to.
        /// </summary>
        public ApiPropertyString Url => _url ?? (_url = new ApiPropertyString(this, "url"));
        private ApiPropertyString _url;
        /// <summary>
        /// Gets or sets the URL the payload should be sent to.
        /// </summary>
        public string UrlValue { get => Url.Value; set => Url.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the last HTTP response code.
        /// </summary>
        public ApiPropertyString LastResponseCode => _lastResponseCode ?? (_lastResponseCode = new ApiPropertyString(this, "last_code"));
        private ApiPropertyString _lastResponseCode;
        /// <summary>
        /// Gets or sets the last HTTP response code.
        /// </summary>
        public string LastResponseCodeValue { get => LastResponseCode.Value; set => LastResponseCode.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date and time of the last webhook, measured in seconds from the Unix Epoch.
        /// </summary>
        public ApiPropertyDateTime DateLastHook => _dateLastHook ?? (_dateLastHook = new ApiPropertyDateTime(this, "last_hook"));
        private ApiPropertyDateTime _dateLastHook;
        /// <summary>
        /// Gets or sets the date and time of the last webhook, measured in seconds from the Unix Epoch.
        /// </summary>
        public DateTimeOffset DateLastHookValue { get => DateLastHook.Value; set => DateLastHook.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the form-encoded contents of the last payload.
        /// </summary>
        public ApiPropertyString LastPayload => _lastPayload ?? (_lastPayload = new ApiPropertyString(this, "last_payload"));
        private ApiPropertyString _lastPayload;
        /// <summary>
        /// Gets or sets the form-encoded contents of the last payload.
        /// </summary>
        public string LastPayloadValue { get => LastPayload.Value; set => LastPayload.Value = value; }

    }
}
