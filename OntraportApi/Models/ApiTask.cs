using System;
using EmergenceGuardian.OntraportApi.Converters;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// A task object is created when a task is assigned to a contact or other object.
    /// </summary>
    public class ApiTask : ApiObject
    {
        /// <summary>
        /// Returns a ApiProperty object to get or set the user who has control of the task.
        /// </summary>
        public ApiPropertyInt Owner => _owner ?? (_owner = new ApiPropertyInt(this, "owner"));
        private ApiPropertyInt _owner;
        /// <summary>
        /// Returns a ApiProperty object to get or set the user who has control of the task.
        /// </summary>
        public int OwnerValue { get => Owner.Value; set => Owner.Value = value; }

        /// <summary>
        /// If the task is a step in a sequence, returns a ApiProperty object to get or set the ID of that sequence.
        /// </summary>
        public ApiPropertyInt DripId => _dripId ?? (_dripId = new ApiPropertyInt(this, "drip_id"));
        private ApiPropertyInt _dripId;
        /// <summary>
        /// If the task is a step in a sequence, gets or sets the ID of that sequence.
        /// </summary>
        public int DripIdValue { get => DripId.Value; set => DripId.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the contact the task is related to.
        /// </summary>
        public ApiPropertyInt ContactId => _contactId ?? (_contactId = new ApiPropertyInt(this, "contact_id"));
        private ApiPropertyInt _contactId;
        /// <summary>
        /// Gets or sets the ID of the contact the task is related to.
        /// </summary>
        public int ContactIdValue { get => ContactId.Value; set => ContactId.Value = value; }

        /// <summary>
        /// If the task is a step in a sequence, returns a ApiProperty object to get or set the order in the sequence of that step.
        /// </summary>
        public ApiPropertyInt StepNum => _stepNum ?? (_stepNum = new ApiPropertyInt(this, "step_num"));
        private ApiPropertyInt _stepNum;
        /// <summary>
        /// If the task is a step in a sequence, gets or sets the order in the sequence of that step.
        /// </summary>
        public int StepNumValue { get => StepNum.Value; set => StepNum.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the product's name.
        /// </summary>
        public ApiPropertyString Subject => _subject ?? (_subject = new ApiPropertyString(this, "subject"));
        private ApiPropertyString _subject;
        /// <summary>
        /// Gets or sets the product's name.
        /// </summary>
        public string SubjectValue { get => Subject.Value; set => Subject.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date and time the task was assigned.
        /// </summary>
        public ApiPropertyDateTime DateAssigned => _dateAssigned ?? (_dateAssigned = new ApiPropertyDateTime(this, "date_assigned"));
        private ApiPropertyDateTime _dateAssigned;
        /// <summary>
        /// Gets or sets the date and time the task was assigned.
        /// </summary>
        public DateTimeOffset DateAssignedValue { get => DateAssigned.Value; set => DateAssigned.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date and time the task should be completed by.
        /// </summary>
        public ApiPropertyDateTime DateDue => _dateDue ?? (_dateDue = new ApiPropertyDateTime(this, "date_due"));
        private ApiPropertyDateTime _dateDue;
        /// <summary>
        /// Gets or sets the date and time the task should be completed by.
        /// </summary>
        public DateTimeOffset DateDueValue { get => DateDue.Value; set => DateDue.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date and time the task was marked as completed.
        /// </summary>
        public ApiPropertyDateTime DateComplete => _dateComplete ?? (_dateComplete = new ApiPropertyDateTime(this, "date_complete"));
        private ApiPropertyDateTime _dateComplete;
        /// <summary>
        /// Gets or sets the date and time the task was marked as completed.
        /// </summary>
        public DateTimeOffset DateCompleteValue { get => DateComplete.Value; set => DateComplete.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the task completion status.
        /// </summary>
        public ApiProperty<TaskStatus> Status => _status ?? (_status = new ApiPropertyIntEnum<TaskStatus>(this, "status"));
        private ApiProperty<TaskStatus> _status;
        /// <summary>
        /// Gets or sets the task completion status.
        /// </summary>
        public TaskStatus StatusValue { get => Status.Value; set => Status.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the task type.
        /// </summary>
        public ApiProperty<TaskStatus> Type => _type ?? (_type = new ApiPropertyIntEnum<TaskStatus>(this, "type"));
        private ApiProperty<TaskStatus> _type;
        /// <summary>
        /// Gets or sets the task type.
        /// </summary>
        public TaskStatus TypeValue { get => Type.Value; set => Type.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the content of the task message.
        /// </summary>
        public ApiPropertyString Details => _details ?? (_details = new ApiPropertyString(this, "details"));
        private ApiPropertyString _details;
        /// <summary>
        /// Gets or sets the content of the task message.
        /// </summary>
        public string DetailsValue { get => Details.Value; set => Details.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set whether or not the task is accessible.
        /// </summary>
        public ApiPropertyIntBool Hidden => _hidden ?? (_hidden = new ApiPropertyIntBool(this, "hidden"));
        private ApiPropertyIntBool _hidden;
        /// <summary>
        /// Gets or sets whether or not the task is accessible.
        /// </summary>
        public bool HiddenValue { get => Hidden.Value; set => Hidden.Value = value; }

        /// <summary>
        /// If the task has an outcome, returns a ApiProperty object to get or set the ID of that outcome. Task outcomes are user-defined and stored as a related object.
        /// </summary>
        public ApiPropertyInt CallOutcomeId => _callOutcomeId ?? (_callOutcomeId = new ApiPropertyInt(this, "call_outcome_id"));
        private ApiPropertyInt _callOutcomeId;
        /// <summary>
        /// If the task has an outcome, gets or sets the ID of that outcome. Task outcomes are user-defined and stored as a related object.
        /// </summary>
        public int CallOutcomeIdValue { get => CallOutcomeId.Value; set => CallOutcomeId.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the task message. The task message is the generic template the task was created from.
        /// </summary>
        public ApiPropertyInt TaskTemplateId => _taskTemplateId ?? (_taskTemplateId = new ApiPropertyInt(this, "item_id"));
        private ApiPropertyInt _taskTemplateId;
        /// <summary>
        /// Gets or sets the ID of the task message. The task message is the generic template the task was created from.
        /// </summary>
        public int TaskTemplateIdValue { get => TaskTemplateId.Value; set => TaskTemplateId.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set a JSON encoded string including information about sent notifications.
        /// </summary>
        public ApiPropertyString Notifications => _notifications ?? (_notifications = new ApiPropertyString(this, "notifications"));
        private ApiPropertyString _notifications;
        /// <summary>
        /// Gets or sets a JSON encoded string including information about sent notifications.
        /// </summary>
        public string NotificationsValue { get => Notifications.Value; set => Notifications.Value = value; }

        /// <summary>
        /// If the task has rules associated with it, returns a ApiProperty object to get or set the events, conditions and actions of those rules.
        /// </summary>
        public ApiPropertyString Rules => _rules ?? (_rules = new ApiPropertyString(this, "rules"));
        private ApiPropertyString _rules;
        /// <summary>
        /// If the task has rules associated with it, gets or sets the events, conditions and actions of those rules.
        /// </summary>
        public string RulesValue { get => Rules.Value; set => Rules.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID for the type of object the task is associated with.
        /// </summary>
        public ApiPropertyInt ObjectTypeId => _objectTypeId ?? (_objectTypeId = new ApiPropertyInt(this, "object_type_id"));
        private ApiPropertyInt _objectTypeId;
        /// <summary>
        /// Gets or sets the ID for the type of object the task is associated with.
        /// </summary>
        public int ObjectTypeIdValue { get => ObjectTypeId.Value; set => ObjectTypeId.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the name of the type of object the task is associated with.
        /// </summary>
        public ApiPropertyString ObjectName => _objectName ?? (_objectName = new ApiPropertyString(this, "object_name"));
        private ApiPropertyString _objectName;
        /// <summary>
        /// Gets or sets the name of the type of object the task is associated with.
        /// </summary>
        public string ObjectNameValue { get => ObjectName.Value; set => ObjectName.Value = value; }





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
