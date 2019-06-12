using System;
using EmergenceGuardian.OntraportApi.Converters;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// These objects contain data on your CampaignBuilder campaigns, such as names, IDs, and current status. In this section, "campaign" refers to automated marketing campaigns.
    /// </summary>
    public class ApiCampaignBuilderItem : ApiObject
    {
        /// <summary>
        /// Returns a ApiProperty object to get or set the campaign name.
        /// </summary>
        public ApiPropertyString Name => _name ?? (_name = new ApiPropertyString(this, "name"));
        private ApiPropertyString _name;
        /// <summary>
        /// Gets or sets the campaign name.
        /// </summary>
        public string NameValue { get => Name.Value; set => Name.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date the campaign was created.
        /// </summary>
        public ApiPropertyDateTime DateCreated => _date ?? (_date = new ApiPropertyDateTime(this, "date"));
        private ApiPropertyDateTime _date;
        /// <summary>
        /// Returns a ApiProperty object to get or set the date the campaign was created.
        /// </summary>
        public DateTimeOffset DateCreatedValue { get => DateCreated.Value; set => DateCreated.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date the campaign was last modified.
        /// </summary>
        public ApiPropertyDateTime DateLastModified => _dateLastModified ?? (_dateLastModified = new ApiPropertyDateTime(this, "dlm"));
        private ApiPropertyDateTime _dateLastModified;
        /// <summary>
        /// Returns a ApiProperty object to get or set the date the campaign was last modified.
        /// </summary>
        public DateTimeOffset DateLastModifiedValue { get => DateLastModified.Value; set => DateLastModified.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the object type the campaign relates to.
        /// </summary>
        public ApiProperty<int> ObjectTypeId => _objectTypeId ?? (_objectTypeId = new ApiProperty<int>(this, "object_type_id"));
        private ApiProperty<int> _objectTypeId;
        /// <summary>
        /// Gets or sets the ID of the object type the campaign relates to.
        /// </summary>
        public int ObjectTypeIdValue { get => ObjectTypeId.Value; set => ObjectTypeId.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set whether or not the campaign is paused.
        /// </summary>
        public ApiPropertyIntBool Pause => _pause ?? (_pause = new ApiPropertyIntBool(this, "pause"));
        private ApiPropertyIntBool _pause;
        /// <summary>
        /// Gets or sets whether or not the campaign is paused.
        /// </summary>
        public bool PauseValue { get => Pause.Value; set => Pause.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set whether or not the campaign has been deleted.
        /// </summary>
        public ApiPropertyBool Deleted => _deleted ?? (_deleted = new ApiPropertyBool(this, "deleted"));
        private ApiPropertyBool _deleted;
        /// <summary>
        /// Gets or sets whether or not the campaign has been deleted.
        /// </summary>
        public bool DeletedValue { get => Deleted.Value; set => Deleted.Value = value; }

    }
}
