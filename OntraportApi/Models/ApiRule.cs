using System;
using EmergenceGuardian.OntraportApi.Converters;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// Rules are set to perform a user-specified “Action” when a certain "Event" occurs, which is also defined in the category of “Triggers”, 
    /// and such criteria in triggering a rule to act can be further detailed out through user-specified “Conditions”.
    /// </summary>
    public class ApiRule : ApiObject
    {
        /// <summary>
        /// If the rule is a step in a sequence, returns a ApiProperty object to get or set the ID of that sequence.
        /// </summary>
        public ApiProperty<int> DripId => _dripId ?? (_dripId = new ApiProperty<int>(this, "drip_id"));
        private ApiProperty<int> _dripId;
        /// <summary>
        /// If the rule is a step in a sequence, gets or sets the ID of that sequence.
        /// </summary>
        public int DripIdValue { get => DripId.Value; set => DripId.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the events that trigger rule execution.
        /// </summary>
        public ApiPropertyString Events => _events ?? (_events = new ApiPropertyString(this, "events"));
        private ApiPropertyString _events;
        /// <summary>
        /// Gets or sets the events that trigger rule execution.
        /// </summary>
        public string EventsValue { get => Events.Value; set => Events.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the criteria that must be met for the rule to act after it is triggered.
        /// </summary>
        public ApiPropertyString Conditions => _conditions ?? (_conditions = new ApiPropertyString(this, "conditions"));
        private ApiPropertyString _conditions;
        /// <summary>
        /// Gets or sets the criteria that must be met for the rule to act after it is triggered.
        /// </summary>
        public string ConditionsValue { get => Conditions.Value; set => Conditions.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the action to perform when rule is triggered.
        /// </summary>
        public ApiPropertyString Actions => _actions ?? (_actions = new ApiPropertyString(this, "actions"));
        private ApiPropertyString _actions;
        /// <summary>
        /// Gets or sets the action to perform when rule is triggered.
        /// </summary>
        public string ActionsValue { get => Actions.Value; set => Actions.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the name of the rule.
        /// </summary>
        public ApiPropertyString Name => _name ?? (_name = new ApiPropertyString(this, "name"));
        private ApiPropertyString _name;
        /// <summary>
        /// Gets or sets the name of the rule.
        /// </summary>
        public string NameValue { get => Name.Value; set => Name.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set whether or not the rule is paused.
        /// </summary>
        public ApiPropertyIntBool Paused => _pause ?? (_pause = new ApiPropertyIntBool(this, "pause"));
        private ApiPropertyIntBool _pause;
        /// <summary>
        /// Gets or sets whether or not the rule is paused.
        /// </summary>
        public bool PausedValue { get => Paused.Value; set => Paused.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the last time the rule was triggered.
        /// </summary>
        public ApiPropertyIntBool DateLastAction => _dateLastAction ?? (_dateLastAction = new ApiPropertyIntBool(this, "last_action"));
        private ApiPropertyIntBool _dateLastAction;
        /// <summary>
        /// Gets or sets the last time the rule was triggered.
        /// </summary>
        public bool DateLastActionValue { get => DateLastAction.Value; set => DateLastAction.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID for the type of object the rule is associated with.
        /// </summary>
        public ApiProperty<int> ObjectTypeId => _objectTypeId ?? (_objectTypeId = new ApiProperty<int>(this, "object_type_id"));
        private ApiProperty<int> _objectTypeId;
        /// <summary>
        /// Gets or sets the ID for the type of object the rule is associated with.
        /// </summary>
        public int ObjectTypeIdValue { get => ObjectTypeId.Value; set => ObjectTypeId.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date the rule was added.
        /// </summary>
        public ApiPropertyDateTime DateAdded => _dateAdded ?? (_dateAdded = new ApiPropertyDateTime(this, "date"));
        private ApiPropertyDateTime _dateAdded;
        /// <summary>
        /// Gets or sets the date the rule was added.
        /// </summary>
        public DateTimeOffset DateAddedValue { get => DateAdded.Value; set => DateAdded.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date the rule was last modified.
        /// </summary>
        public ApiPropertyDateTime DateLastModified => _dateLastModified ?? (_dateLastModified = new ApiPropertyDateTime(this, "dlm"));
        private ApiPropertyDateTime _dateLastModified;
        /// <summary>
        /// Gets or sets the date the rule was last modified.
        /// </summary>
        public DateTimeOffset DateLastModifiedValue { get => DateLastModified.Value; set => DateLastModified.Value = value; }

    }
}
