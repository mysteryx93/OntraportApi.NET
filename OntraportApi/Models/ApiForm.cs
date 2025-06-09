namespace HanumanInstitute.OntraportApi.Models;

/// <summary>
/// Forms are used to simply and easily gather information from your contacts.
/// </summary>
public class ApiForm : ApiObject
{
    public ApiForm() : base("form_id")
    { }

    /// <summary>
    /// Returns a ApiProperty object to get or set an arbitrary name for the form.
    /// </summary>
    public ApiPropertyString FormNameField => _formNameField ??= new ApiPropertyString(this, FormNameKey);
    private ApiPropertyString? _formNameField;
    public const string FormNameKey = "formname";
    /// <summary>
    /// Gets or sets an arbitrary name for the form.
    /// </summary>
    public string? FormName { get => FormNameField.Value; set => FormNameField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the type of form.
    /// </summary>
    public ApiProperty<FormType> TypeField => _typeField ??= new ApiPropertyIntEnum<FormType>(this, TypeKey);
    private ApiProperty<FormType>? _typeField;
    public const string TypeKey = "type";
    /// <summary>
    /// Gets or sets the type of form.
    /// </summary>
    public FormType? Type { get => TypeField.Value; set => TypeField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the tags a contact should be added to upon form fillout.
    /// </summary>
    public ApiPropertyString TagsField => _tagsField ??= new ApiPropertyString(this, TagsKey);
    private ApiPropertyString? _tagsField;
    public const string TagsKey = "tags";
    /// <summary>
    /// Gets or sets the tags a contact should be added to upon form fillout.
    /// </summary>
    public string? Tags { get => TagsField.Value; set => TagsField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the sequences a contact should be added to upon form fillout.
    /// </summary>
    public ApiPropertyString SequencesField => _sequencesField ??= new ApiPropertyString(this, SequencesKey);
    private ApiPropertyString? _sequencesField;
    public const string SequencesKey = "sequences";
    /// <summary>
    /// Gets or sets the sequences a contact should be added to upon form fillout.
    /// </summary>
    public string? Sequences { get => SequencesField.Value; set => SequencesField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the URL for the thank you page the user is redirected to upon form fillout.
    /// </summary>
    public ApiPropertyString RedirectUrlField => _redirectUrlField ??= new ApiPropertyString(this, RedirectUrlKey);
    private ApiPropertyString? _redirectUrlField;
    public const string RedirectUrlKey = "redirect";
    /// <summary>
    /// Gets or sets the URL for the thank you page the user is redirected to upon form fillout.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1056:Uri properties should not be strings", Justification = "Reviewed: we only work with raw Ontraport data")]
    public string? RedirectUrl { get => RedirectUrlField.Value; set => RedirectUrlField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the user controlling the form.
    /// </summary>
    public ApiProperty<int> OwnerField => _ownerField ??= new ApiProperty<int>(this, OwnerKey);
    private ApiProperty<int>? _ownerField;
    public const string OwnerKey = "owner";
    /// <summary>
    /// Gets or sets the ID of the user controlling the form.
    /// </summary>
    public int? Owner { get => OwnerField.Value; set => OwnerField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set whether or not the form includes a Captcha.
    /// </summary>
    public ApiPropertyIntBool HasCatchaField => _hasCaptchaField ??= new ApiPropertyIntBool(this, HasCatchaKey);
    private ApiPropertyIntBool? _hasCaptchaField;
    public const string HasCatchaKey = "captcha";
    /// <summary>
    /// Gets or sets whether or not the form includes a Captcha.
    /// </summary>
    public bool? HasCatcha { get => HasCatchaField.Value; set => HasCatchaField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the email address to send notififications when the form is filled out.
    /// </summary>
    public ApiPropertyString NotificationEmailField => _notificationEmailField ??= new ApiPropertyString(this, NotificationEmailKey);
    private ApiPropertyString? _notificationEmailField;
    public const string NotificationEmailKey = "notif";
    /// <summary>
    /// Gets or sets the email address to send notififications when the form is filled out.
    /// </summary>
    public string? NotificationEmail { get => NotificationEmailField.Value; set => NotificationEmailField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the number of times the form has been filled out.
    /// </summary>
    public ApiProperty<int> FilloutsField => _filloutsField ??= new ApiProperty<int>(this, FilloutsKey);
    private ApiProperty<int>? _filloutsField;
    public const string FilloutsKey = "fillouts";
    /// <summary>
    /// Gets or sets the number of times the form has been filled out.
    /// </summary>
    public int? Fillouts { get => FilloutsField.Value; set => FilloutsField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the JSON-encoded form data.
    /// </summary>
    public ApiPropertyString JsonRawDataField => _jsonRawDataField ??= new ApiPropertyString(this, JsonRawDataKey);
    private ApiPropertyString? _jsonRawDataField;
    public const string JsonRawDataKey = "json_raw_object";
    /// <summary>
    /// Gets or sets the JSON-encoded form data.
    /// </summary>
    public string? JsonRawData { get => JsonRawDataField.Value; set => JsonRawDataField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set whether or not the form has been deleted.
    /// </summary>
    public ApiPropertyIntBool DeletedField => _deletedField ??= new ApiPropertyIntBool(this, DeletedKey);
    private ApiPropertyIntBool? _deletedField;
    public const string DeletedKey = "deleted";
    /// <summary>
    /// Gets or sets whether or not the form has been deleted.
    /// </summary>
    public bool? Deleted { get => DeletedField.Value; set => DeletedField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the object type associated with the form.
    /// </summary>
    public ApiProperty<long> ObjectTypeIdField => _objectTypeIdField ??= new ApiProperty<long>(this, ObjectTypeIdKey);
    private ApiProperty<long>? _objectTypeIdField;
    public const string ObjectTypeIdKey = "object_type_id";
    /// <summary>
    /// Gets or sets the ID of the object type associated with the form.
    /// </summary>
    public long? ObjectTypeId { get => ObjectTypeIdField.Value; set => ObjectTypeIdField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set whether or not the form has a responsive layout.
    /// </summary>
    public ApiPropertyIntBool ResponsiveLayoutField => _responsiveLayoutField ??= new ApiPropertyIntBool(this, ResponsiveLayoutKey);
    private ApiPropertyIntBool? _responsiveLayoutField;
    public const string ResponsiveLayoutKey = "responsive";
    /// <summary>
    /// Gets or sets whether or not the form has a responsive layout.
    /// </summary>
    public bool? ResponsiveLayout { get => ResponsiveLayoutField.Value; set => ResponsiveLayoutField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the number of times the form has been visited.
    /// </summary>
    public ApiProperty<int> VisitsField => _visitsField ??= new ApiProperty<int>(this, VisitsKey);
    private ApiProperty<int>? _visitsField;
    public const string VisitsKey = "visits";
    /// <summary>
    /// Gets or sets the number of times the form has been visited.
    /// </summary>
    public int? Visits { get => VisitsField.Value; set => VisitsField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the number of times unique visitors have visited the form.
    /// </summary>
    public ApiProperty<int> UniqueVisitsField => _uniqueVisitsField ??= new ApiProperty<int>(this, UniqueVisitsKey);
    private ApiProperty<int>? _uniqueVisitsField;
    public const string UniqueVisitsKey = "unique_visits";
    /// <summary>
    /// Gets or sets the number of times unique visitors have visited the form.
    /// </summary>
    public int? UniqueVisits { get => UniqueVisitsField.Value; set => UniqueVisitsField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the date and time the form was created. Note that this field will not contain data for any forms created prior to November 7, 2017.
    /// </summary>
    public ApiPropertyDateTime DateCreatedField => _dateCreatedField ??= new ApiPropertyDateTime(this, DateCreatedKey);
    private ApiPropertyDateTime? _dateCreatedField;
    public const string DateCreatedKey = "date";
    /// <summary>
    /// Gets or sets the date and time the form was created. Note that this field will not contain data for any forms created prior to November 7, 2017.
    /// </summary>
    public DateTimeOffset? DateCreated { get => DateCreatedField.Value; set => DateCreatedField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the date and time the form was last modified.
    /// </summary>
    public ApiPropertyDateTime DateModifiedField => _dateModifiedField ??= new ApiPropertyDateTime(this, DateModifiedKey);
    private ApiPropertyDateTime? _dateModifiedField;
    public const string DateModifiedKey = "dlm";
    /// <summary>
    /// Gets or sets the date and time the form was last modified.
    /// </summary>
    public DateTimeOffset? DateModified { get => DateModifiedField.Value; set => DateModifiedField.Value = value; }

    public ApiPropertyString CampaignsField => _campaignsField ??= new ApiPropertyString(this, CampaignsKey);
    private ApiPropertyString? _campaignsField;
    public const string CampaignsKey = "campaigns";
    public string? Campaigns { get => CampaignsField.Value; set => CampaignsField.Value = value; }

    public ApiProperty<int> UniqueFilloutsField => _uniqueFilloutsField ??= new ApiProperty<int>(this, UniqueFilloutsKey);
    private ApiProperty<int>? _uniqueFilloutsField;
    public const string UniqueFilloutsKey = "unique_fillouts";
    public int? UniqueFillouts { get => UniqueFilloutsField.Value; set => UniqueFilloutsField.Value = value; }

    public ApiProperty<decimal> RevenueField => _revenueField ??= new ApiProperty<decimal>(this, RevenueKey);
    private ApiProperty<decimal>? _revenueField;
    public const string RevenueKey = "revenue";
    public decimal? Revenue { get => RevenueField.Value; set => RevenueField.Value = value; }

    public ApiProperty<int> UniqueConvertField => _uniqueConvertField ??= new ApiProperty<int>(this, UniqueConvertKey);
    private ApiProperty<int>? _uniqueConvertField;
    public const string UniqueConvertKey = "unique_convert";
    public int? UniqueConvert { get => UniqueConvertField.Value; set => UniqueConvertField.Value = value; }


    /// <summary>
    /// The type of form.
    /// </summary>
    public enum FormType
    {
        SmartForm = 10,
        ONTRAform = 11
    }
}
