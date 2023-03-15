namespace HanumanInstitute.OntraportApi.Models;

/// <summary>
/// These objects contain data on your CampaignBuilder campaigns, such as names, IDs, and current status. In this section, "campaign" refers to automated marketing campaigns.
/// </summary>
public class ApiCampaignBuilderItem : ApiObject
{
    /// <summary>
    /// Returns a ApiProperty object to get or set the campaign name.
    /// </summary>
    public ApiPropertyString NameField => _nameField ??= new ApiPropertyString(this, NameKey);
    private ApiPropertyString? _nameField;
    public const string NameKey = "name";
    /// <summary>
    /// Gets or sets the campaign name.
    /// </summary>
    public string? Name { get => NameField.Value; set => NameField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the date the campaign was created.
    /// </summary>
    public ApiPropertyDateTime DateCreatedField => _dateField ??= new ApiPropertyDateTime(this, DateCreatedKey);
    private ApiPropertyDateTime? _dateField;
    public const string DateCreatedKey = "date";
    /// <summary>
    /// Returns a ApiProperty object to get or set the date the campaign was created.
    /// </summary>
    public DateTimeOffset? DateCreated { get => DateCreatedField.Value; set => DateCreatedField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the date the campaign was last modified.
    /// </summary>
    public ApiPropertyDateTime DateLastModifiedField => _dateLastModifiedField ??= new ApiPropertyDateTime(this, DateLastModifiedKey);
    private ApiPropertyDateTime? _dateLastModifiedField;
    public const string DateLastModifiedKey = "dlm";
    /// <summary>
    /// Returns a ApiProperty object to get or set the date the campaign was last modified.
    /// </summary>
    public DateTimeOffset? DateLastModified { get => DateLastModifiedField.Value; set => DateLastModifiedField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the object type the campaign relates to.
    /// </summary>
    public ApiProperty<int> ObjectTypeIdField => _objectTypeIdField ??= new ApiProperty<int>(this, ObjectTypeIdKey);
    private ApiProperty<int>? _objectTypeIdField;
    public const string ObjectTypeIdKey = "object_type_id";
    /// <summary>
    /// Gets or sets the ID of the object type the campaign relates to.
    /// </summary>
    public int? ObjectTypeId { get => ObjectTypeIdField.Value; set => ObjectTypeIdField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set whether or not the campaign is paused.
    /// </summary>
    public ApiPropertyIntBool PauseField => _pauseField ??= new ApiPropertyIntBool(this, PauseKey);
    private ApiPropertyIntBool? _pauseField;
    public const string PauseKey = "pause";
    /// <summary>
    /// Gets or sets whether or not the campaign is paused.
    /// </summary>
    public bool? Pause { get => PauseField.Value; set => PauseField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set whether or not the campaign has been deleted.
    /// </summary>
    public ApiPropertyBool DeletedField => _deletedField ??= new ApiPropertyBool(this, DeletedKey);
    private ApiPropertyBool? _deletedField;
    public const string DeletedKey = "deleted";
    /// <summary>
    /// Gets or sets whether or not the campaign has been deleted.
    /// </summary>
    public bool? Deleted { get => DeletedField.Value; set => DeletedField.Value = value; }

}
