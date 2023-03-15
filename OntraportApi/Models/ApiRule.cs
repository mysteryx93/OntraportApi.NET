namespace HanumanInstitute.OntraportApi.Models;

/// <summary>
/// Rules are set to perform a user-specified “Action” when a certain "Event" occurs, which is also defined in the category of “Triggers”, 
/// and such criteria in triggering a rule to act can be further detailed out through user-specified “Conditions”.
/// </summary>
public class ApiRule : ApiObject
{
    /// <summary>
    /// If the rule is a step in a sequence, returns a ApiProperty object to get or set the ID of that sequence.
    /// </summary>
    public ApiProperty<int> DripIdField => _dripIdField ??= new ApiProperty<int>(this, DripIdKey);
    private ApiProperty<int>? _dripIdField;
    public const string DripIdKey = "drip_id";
    /// <summary>
    /// If the rule is a step in a sequence, gets or sets the ID of that sequence.
    /// </summary>
    public int? DripId { get => DripIdField.Value; set => DripIdField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the events that trigger rule execution.
    /// </summary>
    public ApiPropertyString EventsField => _eventsField ??= new ApiPropertyString(this, EventsKey);
    private ApiPropertyString? _eventsField;
    public const string EventsKey = "events";
    /// <summary>
    /// Gets or sets the events that trigger rule execution.
    /// </summary>
    public string? Events { get => EventsField.Value; set => EventsField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the criteria that must be met for the rule to act after it is triggered.
    /// </summary>
    public ApiPropertyString ConditionsField => _conditionsField ??= new ApiPropertyString(this, ConditionsKey);
    private ApiPropertyString? _conditionsField;
    public const string ConditionsKey = "conditions";
    /// <summary>
    /// Gets or sets the criteria that must be met for the rule to act after it is triggered.
    /// </summary>
    public string? Conditions { get => ConditionsField.Value; set => ConditionsField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the action to perform when rule is triggered.
    /// </summary>
    public ApiPropertyString ActionsField => _actionsField ??= new ApiPropertyString(this, ActionsKey);
    private ApiPropertyString? _actionsField;
    public const string ActionsKey = "actions";
    /// <summary>
    /// Gets or sets the action to perform when rule is triggered.
    /// </summary>
    public string? Actions { get => ActionsField.Value; set => ActionsField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the name of the rule.
    /// </summary>
    public ApiPropertyString NameField => _nameField ??= new ApiPropertyString(this, NameKey);
    private ApiPropertyString? _nameField;
    public const string NameKey = "name";
    /// <summary>
    /// Gets or sets the name of the rule.
    /// </summary>
    public string? Name { get => NameField.Value; set => NameField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set whether or not the rule is paused.
    /// </summary>
    public ApiPropertyIntBool PausedField => _pauseField ??= new ApiPropertyIntBool(this, PausedKey);
    private ApiPropertyIntBool? _pauseField;
    public const string PausedKey = "pause";
    /// <summary>
    /// Gets or sets whether or not the rule is paused.
    /// </summary>
    public bool? Paused { get => PausedField.Value; set => PausedField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the last time the rule was triggered.
    /// </summary>
    public ApiPropertyIntBool DateLastActionField => _dateLastActionField ??= new ApiPropertyIntBool(this, DateLastActionKey);
    private ApiPropertyIntBool? _dateLastActionField;
    public const string DateLastActionKey = "last_action";
    /// <summary>
    /// Gets or sets the last time the rule was triggered.
    /// </summary>
    public bool? DateLastAction { get => DateLastActionField.Value; set => DateLastActionField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the ID for the type of object the rule is associated with.
    /// </summary>
    public ApiProperty<int> ObjectTypeIdField => _objectTypeIdField ??= new ApiProperty<int>(this, ObjectTypeIdKey);
    private ApiProperty<int>? _objectTypeIdField;
    public const string ObjectTypeIdKey = "object_type_id";
    /// <summary>
    /// Gets or sets the ID for the type of object the rule is associated with.
    /// </summary>
    public int? ObjectTypeId { get => ObjectTypeIdField.Value; set => ObjectTypeIdField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the date the rule was added.
    /// </summary>
    public ApiPropertyDateTime DateAddedField => _dateAddedField ??= new ApiPropertyDateTime(this, DateAddedKey);
    private ApiPropertyDateTime? _dateAddedField;
    public const string DateAddedKey = "date";
    /// <summary>
    /// Gets or sets the date the rule was added.
    /// </summary>
    public DateTimeOffset? DateAdded { get => DateAddedField.Value; set => DateAddedField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the date the rule was last modified.
    /// </summary>
    public ApiPropertyDateTime DateLastModifiedField => _dateLastModifiedField ??= new ApiPropertyDateTime(this, DateLastModifiedKey);
    private ApiPropertyDateTime? _dateLastModifiedField;
    public const string DateLastModifiedKey = "dlm";
    /// <summary>
    /// Gets or sets the date the rule was last modified.
    /// </summary>
    public DateTimeOffset? DateLastModified { get => DateLastModifiedField.Value; set => DateLastModifiedField.Value = value; }

}
