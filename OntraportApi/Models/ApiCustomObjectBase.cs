using System;
using EmergenceGuardian.OntraportApi.Converters;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// Custom objects behave like contacts and have their own properties, forms, campaigns and emails.
    /// </summary>
    public class ApiCustomObjectBase : ApiObject
    {
        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the user who controls the custom object. This field must contain a value for a custom object to be saved properly.
        /// </summary>
        public ApiProperty<int> Owner => _owner ?? (_owner = new ApiProperty<int>(this, "owner"));
        private ApiProperty<int> _owner;
        /// <summary>
        /// Gets or sets the ID of the user who controls the custom object. This field must contain a value for a custom object to be saved properly.
        /// </summary>
        public int OwnerValue { get => Owner.Value; set => Owner.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date the custom object was added.
        /// </summary>
        public ApiPropertyDateTime DateAdded => _dateAdded ?? (_dateAdded = new ApiPropertyDateTime(this, "date"));
        private ApiPropertyDateTime _dateAdded;
        /// <summary>
        /// Gets or sets the date the custom object was added.
        /// </summary>
        public DateTimeOffset DateAddedValue { get => DateAdded.Value; set => DateAdded.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date of the custom object's last activity. In this documentation, activity means that the object object interacted with a form, website, or email link.
        /// </summary>
        public ApiPropertyDateTime DateLastActivity => _dateLastActivity ?? (_dateLastActivity = new ApiPropertyDateTime(this, "dla"));
        private ApiPropertyDateTime _dateLastActivity;
        /// <summary>
        /// Gets or sets the date of the custom object's last activity. In this documentation, activity means that the object object interacted with a form, website, or email link.
        /// </summary>
        public DateTimeOffset DateLastActivityValue { get => DateLastActivity.Value; set => DateLastActivity.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date the custom object was last modified.
        /// </summary>
        public ApiPropertyDateTime DateLastModified => _dateLastModified ?? (_dateLastModified = new ApiPropertyDateTime(this, "dlm"));
        private ApiPropertyDateTime _dateLastModified;
        /// <summary>
        /// Gets or sets the date the custom object was last modified.
        /// </summary>
        public DateTimeOffset DateLastModifiedValue { get => DateLastModified.Value; set => DateLastModified.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the source from which the custom object was added to the database.
        /// </summary>
        public ApiProperty<int> SystemSource => _systemSource ?? (_systemSource = new ApiProperty<int>(this, "system_source"));
        private ApiProperty<int> _systemSource;
        /// <summary>
        /// Gets or sets the source from which the custom object was added to the database.
        /// </summary>
        public int SystemSourceValue { get => SystemSource.Value; set => SystemSource.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the specific location from which the custom object was added to the database.
        /// </summary>
        public ApiPropertyString SourceLocation => _sourceLocation ?? (_sourceLocation = new ApiPropertyString(this, "source_location"));
        private ApiPropertyString _sourceLocation;
        /// <summary>
        /// Gets or sets the specific location from which the custom object was added to the database.
        /// </summary>
        public string SourceLocationValue { get => SourceLocation.Value; set => SourceLocation.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the custom object's IP address.
        /// </summary>
        public ApiPropertyString IpAddress => _ipAddress ?? (_ipAddress = new ApiPropertyString(this, "ip_addy"));
        private ApiPropertyString _ipAddress;
        /// <summary>
        /// Gets or sets the custom object's IP address.
        /// </summary>
        public string IpAddressValue { get => IpAddress.Value; set => IpAddress.Value = value; }

        public ApiPropertyString IpAddressDisplay => _ipAddressDisplay ?? (_ipAddressDisplay = new ApiPropertyString(this, "ip_addy_display"));
        private ApiPropertyString _ipAddressDisplay;
        public string IpAddressDisplayValue { get => IpAddressDisplay.Value; set => IpAddressDisplay.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the import batch the custom object was imported with, if any.
        /// </summary>
        public ApiProperty<int> ImportId => _importId ?? (_importId = new ApiProperty<int>(this, "import_id"));
        private ApiProperty<int> _importId;
        /// <summary>
        /// Gets or sets the ID of the import batch the custom object was imported with, if any.
        /// </summary>
        public int ImportIdValue { get => ImportId.Value; set => ImportId.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set a flag that indicates a custom object's bulk email status.
        /// </summary>
        public ApiProperty<BulkMailStatus> BulkMail => _bulkMail ?? (_bulkMail = new ApiPropertyIntEnum<BulkMailStatus>(this, "bulk_mail"));
        private ApiProperty<BulkMailStatus> _bulkMail;
        /// <summary>
        /// Gets or sets a flag that indicates a custom object's bulk email status.
        /// </summary>
        public BulkMailStatus BulkMailValue { get => BulkMail.Value; set => BulkMail.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set a flag that indicates whether or not a custom object is opted in to receive bulk texts.
        /// </summary>
        public ApiProperty<BulkSmsStatus> BulkSms => _bulkSms ?? (_bulkSms = new ApiPropertyIntEnum<BulkSmsStatus>(this, "bulk_sms"));
        private ApiProperty<BulkSmsStatus> _bulkSms;
        /// <summary>
        /// Gets or sets a flag that indicates whether or not a custom object is opted in to receive bulk texts.
        /// </summary>
        public BulkSmsStatus BulkSmsValue { get => BulkSms.Value; set => BulkSms.Value = value; }

        /// <summary>
        /// Deprecated. Returns a ApiProperty object to get or set the tags a contact is subscribed to.
        /// </summary>
        public ApiPropertyString ListTags => _listTags ?? (_listTags = new ApiPropertyString(this, "contact_cat"));
        private ApiPropertyString _listTags;
        /// <summary>
        /// Deprecated. Gets or sets the tags a contact is subscribed to.
        /// </summary>
        public string ListTagsValue { get => ListTags.Value; set => ListTags.Value = value; }

        /// <summary>
        /// Deprecated. Returns a ApiProperty object to get or set the sequences a contact is subscribed to.
        /// </summary>
        public ApiPropertyString ListSequences => _listSequences ?? (_listSequences = new ApiPropertyString(this, "updateSequence"));
        private ApiPropertyString _listSequences;
        /// <summary>
        /// Deprecated. Gets or sets the sequences a contact is subscribed to.
        /// </summary>
        public string ListSequencesValue { get => ListSequences.Value; set => ListSequences.Value = value; }

        /// <summary>
        /// Deprecated. Returns a ApiProperty object to get or set the campaigns a contact is subscribed to.
        /// </summary>
        public ApiPropertyString ListCampaigns => _listCampaigns ?? (_listCampaigns = new ApiPropertyString(this, "updateCampaign"));
        private ApiPropertyString _listCampaigns;
        /// <summary>
        /// Deprecated. Gets or sets the campaigns a contact is subscribed to.
        /// </summary>
        public string ListCampaignsValue { get => ListCampaigns.Value; set => ListCampaigns.Value = value; }

        public ApiProperty<int> BIndex => _bindex ?? (_bindex = new ApiProperty<int>(this, "bindex"));
        private ApiProperty<int> _bindex;
        public int BIndexValue { get => BIndex.Value; set => BIndex.Value = value; }
    }
}
