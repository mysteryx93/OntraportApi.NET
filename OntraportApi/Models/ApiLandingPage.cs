namespace HanumanInstitute.OntraportApi.Models;

/// <summary>
/// Landing page objects contain the data for one-off web pages a prospect can land on after clicking on an online marketing call-to-action.
/// </summary>
public class ApiLandingPage : ApiObject
{
    /// <summary>
    /// Returns a ApiProperty object to get or set the hosted URL's ID.
    /// </summary>
    public ApiProperty<long> UriIdField => _uriIdField ??= new ApiProperty<long>(this, UrlIdKey);
    private ApiProperty<long>? _uriIdField;
    public const string UrlIdKey = "uri_id";
    /// <summary>
    /// Gets or sets the hosted URL's ID.
    /// </summary>
    public long? UriId { get => UriIdField.Value; set => UriIdField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the JSON encoded data containing the entire structure of the landing page.
    /// </summary>
    public ApiPropertyString ResourceField => _resourceField ??= new ApiPropertyString(this, ResourceKey);
    private ApiPropertyString? _resourceField;
    public const string ResourceKey = "resource";
    /// <summary>
    /// Gets or sets the JSON encoded data containing the entire structure of the landing page.
    /// </summary>
    public string? Resource { get => ResourceField.Value; set => ResourceField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the landing page's design type.
    /// </summary>
    public ApiProperty<PageDesignType> DesignTypeField => _designTypeField ??= new ApiPropertyIntEnum<PageDesignType>(this, DesignTypeKey);
    private ApiProperty<PageDesignType>? _designTypeField;
    public const string DesignTypeKey = "design_type";
    /// <summary>
    /// Gets or sets the landing page's design type.
    /// </summary>
    public PageDesignType? DesignType { get => DesignTypeField.Value; set => DesignTypeField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the landing page's name.
    /// </summary>
    public ApiPropertyString NameField => _nameField ??= new ApiPropertyString(this, NameKey);
    private ApiPropertyString? _nameField;
    public const string NameKey = "name";
    /// <summary>
    /// Gets or sets the landing page's name.
    /// </summary>
    public string? Name { get => NameField.Value; set => NameField.Value = value; }

    /// <summary>
    /// If using split testing, returns a ApiProperty object to get or set the ID of the next split test in line for rotation.
    /// </summary>
    public ApiProperty<int> RotationField => _rotationField ??= new ApiProperty<int>(this, RotationKey);
    private ApiProperty<int>? _rotationField;
    public const string RotationKey = "rotation";
    /// <summary>
    /// If using split testing, gets or sets the ID of the next split test in line for rotation.
    /// </summary>
    public int? Rotation { get => RotationField.Value; set => RotationField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the last time the landing page was manually saved.
    /// </summary>
    public ApiPropertyDateTime LastSaveTimeField => _lastSaveTimeField ??= new ApiPropertyDateTime(this, LastSaveTimeKey);
    private ApiPropertyDateTime? _lastSaveTimeField;
    public const string LastSaveTimeKey = "last_save";
    /// <summary>
    /// Gets or sets the last time the landing page was manually saved.
    /// </summary>
    public DateTimeOffset? LastSaveTime { get => LastSaveTimeField.Value; set => LastSaveTimeField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the last time the landing page was automatically saved.
    /// </summary>
    public ApiPropertyDateTime LastAutoSaveTimeField => _lastAutoSaveTimeField ??= new ApiPropertyDateTime(this, LastAutoSaveTimeKey);
    private ApiPropertyDateTime? _lastAutoSaveTimeField;
    public const string LastAutoSaveTimeKey = "last_auto";
    /// <summary>
    /// Gets or sets the last time the landing page was automatically saved.
    /// </summary>
    public DateTimeOffset? LastAutoSaveTime { get => LastAutoSaveTimeField.Value; set => LastAutoSaveTimeField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the content of the last autosave.
    /// </summary>
    public ApiPropertyString AutoSaveContentField => _autoSaveContentField ??= new ApiPropertyString(this, AutoSaveContentKey);
    private ApiPropertyString? _autoSaveContentField;
    public const string AutoSaveContentKey = "autosave";
    /// <summary>
    /// Gets or sets the content of the last autosave.
    /// </summary>
    public string? AutoSaveContent { get => AutoSaveContentField.Value; set => AutoSaveContentField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set count of visits for split test A.
    /// </summary>
    public ApiProperty<int> Visits0Field => _visits0Field ??= new ApiProperty<int>(this, Visits0Key);
    private ApiProperty<int>? _visits0Field;
    public const string Visits0Key = "visits_0";
    /// <summary>
    /// Gets or sets count of visits for split test A.
    /// </summary>
    public int? Visits0 { get => Visits0Field.Value; set => Visits0Field.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the count of visits for split test B.
    /// </summary>
    public ApiProperty<int> Visits1Field => _visits1Field ??= new ApiProperty<int>(this, Visits1Key);
    private ApiProperty<int>? _visits1Field;
    public const string Visits1Key = "visits_1";
    /// <summary>
    /// Gets or sets the count of visits for split test B.
    /// </summary>
    public int? Visits1 { get => Visits1Field.Value; set => Visits1Field.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the count of visits for split test C.
    /// </summary>
    public ApiProperty<int> Visits2Field => _visits2Field ??= new ApiProperty<int>(this, Visits2Key);
    private ApiProperty<int>? _visits2Field;
    public const string Visits2Key = "visits_2";
    /// <summary>
    /// Gets or sets the count of visits for split test C.
    /// </summary>
    public int? Visits2 { get => Visits2Field.Value; set => Visits2Field.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the count of visits for split test D.
    /// </summary>
    public ApiProperty<int> Visits3Field => _visits3Field ??= new ApiProperty<int>(this, Visits3Key);
    private ApiProperty<int>? _visits3Field;
    public const string Visits3Key = "visits_3";
    /// <summary>
    /// Gets or sets the count of visits for split test D.
    /// </summary>
    public int? Visits3 { get => Visits3Field.Value; set => Visits3Field.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the URL where the landing page is hosted.
    /// </summary>
    public ApiPropertyString DomainField => _domainField ??= new ApiPropertyString(this, DomainKey);
    private ApiPropertyString? _domainField;
    public const string DomainKey = "domain";
    /// <summary>
    /// Gets or sets the URL where the landing page is hosted.
    /// </summary>
    public string? Domain { get => DomainField.Value; set => DomainField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set whether or not ssl certification is enabled.
    /// </summary>
    public ApiPropertyIntBool SslEnabledField => _sslEnabledField ??= new ApiPropertyIntBool(this, SslEnabledKey);
    private ApiPropertyIntBool? _sslEnabledField;
    public const string SslEnabledKey = "ssl_enabled";
    /// <summary>
    /// Gets or sets whether or not ssl certification is enabled.
    /// </summary>
    public bool? SslEnabled { get => SslEnabledField.Value; set => SslEnabledField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the date the landing page was created.
    /// </summary>
    public ApiPropertyDateTime DateCreatedField => _dateCreatedField ??= new ApiPropertyDateTime(this, DateCreatedKey);
    private ApiPropertyDateTime? _dateCreatedField;
    public const string DateCreatedKey = "date";
    /// <summary>
    /// Gets or sets the date the landing page was created.
    /// </summary>
    public DateTimeOffset? DateCreated { get => DateCreatedField.Value; set => DateCreatedField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the data and time the landing page was last modified.
    /// </summary>
    public ApiPropertyDateTime DateLastModifiedField => _dateLastModifiedField ??= new ApiPropertyDateTime(this, DateLastModifiedKey);
    private ApiPropertyDateTime? _dateLastModifiedField;
    public const string DateLastModifiedKey = "dlm";
    /// <summary>
    /// Gets or sets the data and time the landing page was last modified.
    /// </summary>
    public DateTimeOffset? DateLastModified { get => DateLastModifiedField.Value; set => DateLastModifiedField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the count of unique visits for split test A.
    /// </summary>
    public ApiProperty<int> UniqueVisits0Field => _uniqueVisits0Field ??= new ApiProperty<int>(this, UniqueVisits0Key);
    private ApiProperty<int>? _uniqueVisits0Field;
    public const string UniqueVisits0Key = "unique_visits_0";
    /// <summary>
    /// Gets or sets the count of unique visits for split test A.
    /// </summary>
    public int? UniqueVisits0 { get => UniqueVisits0Field.Value; set => UniqueVisits0Field.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the count of unique visits for split test B.
    /// </summary>
    public ApiProperty<int> UniqueVisits1Field => _uniqueVisits1 ??= new ApiProperty<int>(this, UniqueVisits1Key);
    private ApiProperty<int>? _uniqueVisits1;
    public const string UniqueVisits1Key = "unique_visits_1";
    /// <summary>
    /// Gets or sets the count of unique visits for split test B.
    /// </summary>
    public int? UniqueVisits1 { get => UniqueVisits1Field.Value; set => UniqueVisits1Field.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the count of unique visits for split test C.
    /// </summary>
    public ApiProperty<int> UniqueVisits2Field => _uniqueVisits2Field ??= new ApiProperty<int>(this, UniqueVisits2Key);
    private ApiProperty<int>? _uniqueVisits2Field;
    public const string UniqueVisits2Key = "unique_visits_2";
    /// <summary>
    /// Gets or sets the count of unique visits for split test C.
    /// </summary>
    public int? UniqueVisits2 { get => UniqueVisits2Field.Value; set => UniqueVisits2Field.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the count of unique visits for split test D.
    /// </summary>
    public ApiProperty<int> UniqueVisits3Field => _uniqueVisits3Field ??= new ApiProperty<int>(this, UniqueVisits3Key);
    private ApiProperty<int>? _uniqueVisits3Field;
    public const string UniqueVisits3Key = "unique_visits_3";
    /// <summary>
    /// Gets or sets the count of unique visits for split test D.
    /// </summary>
    public int? UniqueVisits3 { get => UniqueVisits3Field.Value; set => UniqueVisits3Field.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the count of converts for split test A.
    /// </summary>
    public ApiProperty<int> Convert0Field => _convert0Field ??= new ApiProperty<int>(this, Convert0Key);
    private ApiProperty<int>? _convert0Field;
    public const string Convert0Key = "convert_0";
    /// <summary>
    /// Gets or sets the count of converts for split test A.
    /// </summary>
    public int? Convert0 { get => Convert0Field.Value; set => Convert0Field.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the count of converts for split test B.
    /// </summary>
    public ApiProperty<int> Convert1Field => _convert1Field ??= new ApiProperty<int>(this, Convert1Key);
    private ApiProperty<int>? _convert1Field;
    public const string Convert1Key = "convert_1";
    /// <summary>
    /// Gets or sets the count of converts for split test B.
    /// </summary>
    public int? Convert1 { get => Convert1Field.Value; set => Convert1Field.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the count of converts for split test C.
    /// </summary>
    public ApiProperty<int> Convert2Field => _convert2Field ??= new ApiProperty<int>(this, Convert2Key);
    private ApiProperty<int>? _convert2Field;
    public const string Convert2Key = "convert_2";
    /// <summary>
    /// Gets or sets the count of converts for split test C.
    /// </summary>
    public int? Convert2 { get => Convert2Field.Value; set => Convert2Field.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the count of converts for split test D.
    /// </summary>
    public ApiProperty<int> Convert3Field => _convert3Field ??= new ApiProperty<int>(this, Convert3Key);
    private ApiProperty<int>? _convert3Field;
    public const string Convert3Key = "convert_3";
    /// <summary>
    /// Gets or sets the count of converts for split test D.
    /// </summary>
    public int? Convert3 { get => Convert3Field.Value; set => Convert3Field.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the count of unique convert for split test A.
    /// </summary>
    public ApiProperty<int> UniqueConvert0Field => _uniqueConvert0Field ??= new ApiProperty<int>(this, UniqueConvert0Key);
    private ApiProperty<int>? _uniqueConvert0Field;
    public const string UniqueConvert0Key = "unique_convert_0";
    /// <summary>
    /// Gets or sets the count of unique convert for split test A.
    /// </summary>
    public int? UniqueConvert0 { get => UniqueConvert0Field.Value; set => UniqueConvert0Field.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the count of unique convert for split test B.
    /// </summary>
    public ApiProperty<int> UniqueConvert1Field => _uniqueConvert1Field ??= new ApiProperty<int>(this, UniqueConvert1Key);
    private ApiProperty<int>? _uniqueConvert1Field;
    public const string UniqueConvert1Key = "unique_convert_1";
    /// <summary>
    /// Gets or sets the count of unique convert for split test B.
    /// </summary>
    public int? UniqueConvert1 { get => UniqueConvert1Field.Value; set => UniqueConvert1Field.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the count of unique convert for split test C.
    /// </summary>
    public ApiProperty<int> UniqueConvert2Field => _uniqueConvert2Field ??= new ApiProperty<int>(this, UniqueConvert2Key);
    private ApiProperty<int>? _uniqueConvert2Field;
    public const string UniqueConvert2Key = "unique_convert_2";
    /// <summary>
    /// Gets or sets the count of unique convert for split test C.
    /// </summary>
    public int? UniqueConvert2 { get => UniqueConvert2Field.Value; set => UniqueConvert2Field.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the count of unique convert for split test D.
    /// </summary>
    public ApiProperty<int> UniqueConvert3Field => _uniqueConvert3Field ??= new ApiProperty<int>(this, UniqueConvert3Key);
    private ApiProperty<int>? _uniqueConvert3Field;
    public const string UniqueConvert3Key = "unique_convert_3";
    /// <summary>
    /// Gets or sets the count of unique convert for split test D.
    /// </summary>
    public int? UniqueConvert3 { get => UniqueConvert3Field.Value; set => UniqueConvert3Field.Value = value; }

    public ApiPropertyString SeoSettingsField => _seoSettingsField ??= new ApiPropertyString(this, SeoSettingsKey);
    private ApiPropertyString? _seoSettingsField;
    public const string SeoSettingsKey = "seo_settings";
    public string? SeoSettings { get => SeoSettingsField.Value; set => SeoSettingsField.Value = value; }





    /// <summary>
    /// The landing page's design type.
    /// </summary>
    public enum PageDesignType
    {
        Html = 0,
        CodeMode = 1,
        Redirect = 2,
        OntraPages = 3
    }
}
