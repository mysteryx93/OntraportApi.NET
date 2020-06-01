using System;
using HanumanInstitute.OntraportApi.Converters;

namespace HanumanInstitute.OntraportApi.Models
{
    /// <summary>
    /// A task object is created when a task is assigned to a contact or other object.
    /// </summary>
    public class ApiTask : ApiObject
    {
        /// <summary>
        /// Returns a ApiProperty object to get or set the user who has control of the task.
        /// </summary>
        public ApiProperty<int> OwnerField => _ownerField ??= new ApiProperty<int>(this, OwnerKey);
        private ApiProperty<int>? _ownerField;
        public const string OwnerKey = "owner";
        /// <summary>
        /// Returns a ApiProperty object to get or set the user who has control of the task.
        /// </summary>
        public int? Owner { get => OwnerField.Value; set => OwnerField.Value = value; }

        /// <summary>
        /// If the task is a step in a sequence, returns a ApiProperty object to get or set the ID of that sequence.
        /// </summary>
        public ApiProperty<int> DripIdField => _dripIdField ??= new ApiProperty<int>(this, DripIdKey);
        private ApiProperty<int>? _dripIdField;
        public const string DripIdKey = "drip_id";
        /// <summary>
        /// If the task is a step in a sequence, gets or sets the ID of that sequence.
        /// </summary>
        public int? DripId { get => DripIdField.Value; set => DripIdField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the contact the task is related to.
        /// </summary>
        public ApiProperty<int> ContactIdField => _contactIdField ??= new ApiProperty<int>(this, ContactIdKey);
        private ApiProperty<int>? _contactIdField;
        public const string ContactIdKey = "contact_id";
        /// <summary>
        /// Gets or sets the ID of the contact the task is related to.
        /// </summary>
        public int? ContactId { get => ContactIdField.Value; set => ContactIdField.Value = value; }

        /// <summary>
        /// If the task is a step in a sequence, returns a ApiProperty object to get or set the order in the sequence of that step.
        /// </summary>
        public ApiProperty<int> StepNumField => _stepNumField ??= new ApiProperty<int>(this, StepNumKey);
        private ApiProperty<int>? _stepNumField;
        public const string StepNumKey = "step_num";
        /// <summary>
        /// If the task is a step in a sequence, gets or sets the order in the sequence of that step.
        /// </summary>
        public int? StepNum { get => StepNumField.Value; set => StepNumField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the product's name.
        /// </summary>
        public ApiPropertyString SubjectField => _subjectField ??= new ApiPropertyString(this, SubjectKey);
        private ApiPropertyString? _subjectField;
        public const string SubjectKey = "subject";
        /// <summary>
        /// Gets or sets the product's name.
        /// </summary>
        public string Subject { get => SubjectField.Value; set => SubjectField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date and time the task was assigned.
        /// </summary>
        public ApiPropertyDateTime DateAssignedField => _dateAssignedField ??= new ApiPropertyDateTime(this, DateAssignedKey);
        private ApiPropertyDateTime? _dateAssignedField;
        public const string DateAssignedKey = "date_assigned";
        /// <summary>
        /// Gets or sets the date and time the task was assigned.
        /// </summary>
        public DateTimeOffset? DateAssigned { get => DateAssignedField.Value; set => DateAssignedField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date and time the task should be completed by.
        /// </summary>
        public ApiPropertyDateTime DateDueField => _dateDueField ??= new ApiPropertyDateTime(this, DateDueKey);
        private ApiPropertyDateTime? _dateDueField;
        public const string DateDueKey = "date_due";
        /// <summary>
        /// Gets or sets the date and time the task should be completed by.
        /// </summary>
        public DateTimeOffset? DateDue { get => DateDueField.Value; set => DateDueField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date and time the task was marked as completed.
        /// </summary>
        public ApiPropertyDateTime DateCompleteField => _dateCompleteField ??= new ApiPropertyDateTime(this, DateCompleteKey);
        private ApiPropertyDateTime? _dateCompleteField;
        public const string DateCompleteKey = "date_complete";
        /// <summary>
        /// Gets or sets the date and time the task was marked as completed.
        /// </summary>
        public DateTimeOffset? DateComplete { get => DateCompleteField.Value; set => DateCompleteField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the task completion status.
        /// </summary>
        public ApiProperty<TaskStatus> StatusField => _statusField ??= new ApiPropertyIntEnum<TaskStatus>(this, StatusKey);
        private ApiProperty<TaskStatus>? _statusField;
        public const string StatusKey = "status";
        /// <summary>
        /// Gets or sets the task completion status.
        /// </summary>
        public TaskStatus? Status { get => StatusField.Value; set => StatusField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the task type.
        /// </summary>
        public ApiProperty<TaskStatus> TypeField => _typeField ??= new ApiPropertyIntEnum<TaskStatus>(this, TypeKey);
        private ApiProperty<TaskStatus>? _typeField;
        public const string TypeKey = "type";
        /// <summary>
        /// Gets or sets the task type.
        /// </summary>
        public TaskStatus? Type { get => TypeField.Value; set => TypeField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the content of the task message.
        /// </summary>
        public ApiPropertyString DetailsField => _detailsField ??= new ApiPropertyString(this, DetailsKey);
        private ApiPropertyString? _detailsField;
        public const string DetailsKey = "details";
        /// <summary>
        /// Gets or sets the content of the task message.
        /// </summary>
        public string Details { get => DetailsField.Value; set => DetailsField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set whether or not the task is accessible.
        /// </summary>
        public ApiPropertyIntBool HiddenField => _hiddenField ??= new ApiPropertyIntBool(this, HiddenKey);
        private ApiPropertyIntBool? _hiddenField;
        public const string HiddenKey = "hidden";
        /// <summary>
        /// Gets or sets whether or not the task is accessible.
        /// </summary>
        public bool? Hidden { get => HiddenField.Value; set => HiddenField.Value = value; }

        /// <summary>
        /// If the task has an outcome, returns a ApiProperty object to get or set the ID of that outcome. Task outcomes are user-defined and stored as a related object.
        /// </summary>
        public ApiProperty<int> CallOutcomeIdField => _callOutcomeIdField ??= new ApiProperty<int>(this, CallOutcomeIdKey);
        private ApiProperty<int>? _callOutcomeIdField;
        public const string CallOutcomeIdKey = "call_outcome_id";
        /// <summary>
        /// If the task has an outcome, gets or sets the ID of that outcome. Task outcomes are user-defined and stored as a related object.
        /// </summary>
        public int? CallOutcomeId { get => CallOutcomeIdField.Value; set => CallOutcomeIdField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the task message. The task message is the generic template the task was created from.
        /// </summary>
        public ApiProperty<int> TaskTemplateIdField => _taskTemplateIdField ??= new ApiProperty<int>(this, TaskTemplateIdKey);
        private ApiProperty<int>? _taskTemplateIdField;
        public const string TaskTemplateIdKey = "item_id";
        /// <summary>
        /// Gets or sets the ID of the task message. The task message is the generic template the task was created from.
        /// </summary>
        public int? TaskTemplateId { get => TaskTemplateIdField.Value; set => TaskTemplateIdField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set a JSON encoded string including information about sent notifications.
        /// </summary>
        public ApiPropertyString NotificationsField => _notificationsField ??= new ApiPropertyString(this, NotificationsKey);
        private ApiPropertyString? _notificationsField;
        public const string NotificationsKey = "notifications";
        /// <summary>
        /// Gets or sets a JSON encoded string including information about sent notifications.
        /// </summary>
        public string Notifications { get => NotificationsField.Value; set => NotificationsField.Value = value; }

        /// <summary>
        /// If the task has rules associated with it, returns a ApiProperty object to get or set the events, conditions and actions of those rules.
        /// </summary>
        public ApiPropertyString RulesField => _rulesField ??= new ApiPropertyString(this, RulesKey);
        private ApiPropertyString? _rulesField;
        public const string RulesKey = "rules";
        /// <summary>
        /// If the task has rules associated with it, gets or sets the events, conditions and actions of those rules.
        /// </summary>
        public string Rules { get => RulesField.Value; set => RulesField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID for the type of object the task is associated with.
        /// </summary>
        public ApiProperty<int> ObjectTypeIdField => _objectTypeIdField ??= new ApiProperty<int>(this, ObjectTypeIdKey);
        private ApiProperty<int>? _objectTypeIdField;
        public const string ObjectTypeIdKey = "object_type_id";
        /// <summary>
        /// Gets or sets the ID for the type of object the task is associated with.
        /// </summary>
        public int? ObjectTypeId { get => ObjectTypeIdField.Value; set => ObjectTypeIdField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the name of the type of object the task is associated with.
        /// </summary>
        public ApiPropertyString ObjectNameField => _objectNameField ??= new ApiPropertyString(this, ObjectNameKey);
        private ApiPropertyString? _objectNameField;
        public const string ObjectNameKey = "object_name";
        /// <summary>
        /// Gets or sets the name of the type of object the task is associated with.
        /// </summary>
        public string ObjectName { get => ObjectNameField.Value; set => ObjectNameField.Value = value; }





        /// <summary>
        /// The task completion status.
        /// </summary>
        public enum TaskStatus
        {
            Pending = 0,
            Complete = 1,
            Cancelled = 2
        }

        /// <summary>
        /// The task type.
        /// </summary>
        public enum TaskType
        {
            Fulfillment = -1,
            Normal = 0
        }
    }
}
