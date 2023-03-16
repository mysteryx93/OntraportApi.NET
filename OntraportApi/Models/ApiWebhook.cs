namespace HanumanInstitute.OntraportApi.Models;

/// <summary>
/// You can use webhooks subscriptions to receive notifications about events occurring within your Ontraport account.
/// </summary>
public class ApiWebhook : ApiObject
{
    /// <summary>
    /// Returns a ApiProperty object to get or set the event triggering the webhook.
    /// </summary>
    public ApiPropertyString EventField => _eventField ??= new ApiPropertyString(this, EventKey);
    private ApiPropertyString? _eventField;
    public const string EventKey = "event";
    /// <summary>
    /// Gets or sets the event triggering the webhook.
    /// </summary>
    public string? EventValue { get => EventField.Value; set => EventField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set additional json-formatted data regarding the format of the payload.
    /// </summary>
    public ApiPropertyString ContentField => _contentField ??= new ApiPropertyString(this, ContentKey);
    private ApiPropertyString? _contentField;
    public const string ContentKey = "data";
    /// <summary>
    /// Gets or sets additional json-formatted data regarding the format of the payload.
    /// </summary>
    public string? ContentValue { get => ContentField.Value; set => ContentField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the URL the payload should be sent to.
    /// </summary>
    public ApiPropertyString UrlField => _urlField ??= new ApiPropertyString(this, UrlKey);
    private ApiPropertyString? _urlField;
    public const string UrlKey = "url";
    /// <summary>
    /// Gets or sets the URL the payload should be sent to.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1056:Uri properties should not be strings", Justification = "Required: editorconfig ignore isn't taking effect somehow")]
    public string? UrlValue { get => UrlField.Value; set => UrlField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the last HTTP response code.
    /// </summary>
    public ApiPropertyString LastResponseCodeField => _lastResponseCodeField ??= new ApiPropertyString(this, LastResponseCodeKey);
    private ApiPropertyString? _lastResponseCodeField;
    public const string LastResponseCodeKey = "last_code";
    /// <summary>
    /// Gets or sets the last HTTP response code.
    /// </summary>
    public string? LastResponseCodeValue { get => LastResponseCodeField.Value; set => LastResponseCodeField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the date and time of the last webhook, measured in seconds from the Unix Epoch.
    /// </summary>
    public ApiPropertyDateTime DateLastHookField => _dateLastHookField ??= new ApiPropertyDateTime(this, DateLastHookKey);
    private ApiPropertyDateTime? _dateLastHookField;
    public const string DateLastHookKey = "last_hook";
    /// <summary>
    /// Gets or sets the date and time of the last webhook, measured in seconds from the Unix Epoch.
    /// </summary>
    public DateTimeOffset? DateLastHookValue { get => DateLastHookField.Value; set => DateLastHookField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the form-encoded contents of the last payload.
    /// </summary>
    public ApiPropertyString LastPayloadField => _lastPayloadField ??= new ApiPropertyString(this, LastPayloadKey);
    private ApiPropertyString? _lastPayloadField;
    public const string LastPayloadKey = "last_payload";
    /// <summary>
    /// Gets or sets the form-encoded contents of the last payload.
    /// </summary>
    public string? LastPayloadValue { get => LastPayloadField.Value; set => LastPayloadField.Value = value; }

}
