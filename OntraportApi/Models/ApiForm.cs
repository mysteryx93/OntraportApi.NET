using System;
using EmergenceGuardian.OntraportApi.Converters;

namespace EmergenceGuardian.OntraportApi.Models
{
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
        public ApiPropertyString FormName => _formName ?? (_formName = new ApiPropertyString(this, "formname"));
        private ApiPropertyString _formName;
        /// <summary>
        /// Gets or sets an arbitrary name for the form.
        /// </summary>
        public string FormNameValue { get=> FormName.Value; set => FormName.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the type of form.
        /// </summary>
        public ApiProperty<FormType> Type => _type ?? (_type = new ApiPropertyIntEnum<FormType>(this, "type"));
        private ApiProperty<FormType> _type;
        /// <summary>
        /// Gets or sets the type of form.
        /// </summary>
        public FormType TypeValue { get=> Type.Value; set => Type.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the tags a contact should be added to upon form fillout.
        /// </summary>
        public ApiPropertyString Tags => _tags ?? (_tags = new ApiPropertyString(this, "tags"));
        private ApiPropertyString _tags;
        /// <summary>
        /// Gets or sets the tags a contact should be added to upon form fillout.
        /// </summary>
        public string TagsValue { get=> Tags.Value; set => Tags.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the sequences a contact should be added to upon form fillout.
        /// </summary>
        public ApiPropertyString Sequences => _sequences ?? (_sequences = new ApiPropertyString(this, "sequences"));
        private ApiPropertyString _sequences;
        /// <summary>
        /// Gets or sets the sequences a contact should be added to upon form fillout.
        /// </summary>
        public string SequencesValue { get=> Sequences.Value; set => Sequences.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the URL for the thank you page the user is redirected to upon form fillout.
        /// </summary>
        public ApiPropertyString RedirectUrl => _redirectUrl ?? (_redirectUrl = new ApiPropertyString(this, "redirect"));
        private ApiPropertyString _redirectUrl;
        /// <summary>
        /// Gets or sets the URL for the thank you page the user is redirected to upon form fillout.
        /// </summary>
        public string RedirectUrlValue { get=> RedirectUrl.Value; set => RedirectUrl.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the user controlling the form.
        /// </summary>
        public ApiProperty<int> Owner => _owner ?? (_owner = new ApiProperty<int>(this, "owner"));
        private ApiProperty<int> _owner;
        /// <summary>
        /// Gets or sets the ID of the user controlling the form.
        /// </summary>
        public int OwnerValue { get=> Owner.Value; set => Owner.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set whether or not the form includes a Captcha.
        /// </summary>
        public ApiPropertyIntBool HasCatcha => _hasCaptcha ?? (_hasCaptcha = new ApiPropertyIntBool(this, "captcha"));
        private ApiPropertyIntBool _hasCaptcha;
        /// <summary>
        /// Gets or sets whether or not the form includes a Captcha.
        /// </summary>
        public bool HasCatchaValue { get=> HasCatcha.Value; set => HasCatcha.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the email address to send notififications when the form is filled out.
        /// </summary>
        public ApiPropertyString NotificationEmail => _notificationEmail ?? (_notificationEmail = new ApiPropertyString(this, "notif"));
        private ApiPropertyString _notificationEmail;
        /// <summary>
        /// Gets or sets the email address to send notififications when the form is filled out.
        /// </summary>
        public string NotificationEmailValue { get=> NotificationEmail.Value; set => NotificationEmail.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the number of times the form has been filled out.
        /// </summary>
        public ApiProperty<int> Fillouts => _fillouts ?? (_fillouts = new ApiProperty<int>(this, "fillouts"));
        private ApiProperty<int> _fillouts;
        /// <summary>
        /// Gets or sets the number of times the form has been filled out.
        /// </summary>
        public int FilloutsValue { get=> Fillouts.Value; set => Fillouts.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the JSON-encoded form data.
        /// </summary>
        public ApiPropertyString JsonRawData => _jsonRawData ?? (_jsonRawData = new ApiPropertyString(this, "json_raw_object"));
        private ApiPropertyString _jsonRawData;
        /// <summary>
        /// Gets or sets the JSON-encoded form data.
        /// </summary>
        public string JsonRawDataValue { get=> JsonRawData.Value; set => JsonRawData.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set whether or not the form has been deleted.
        /// </summary>
        public ApiPropertyIntBool Deleted => _deleted ?? (_deleted = new ApiPropertyIntBool(this, "deleted"));
        private ApiPropertyIntBool _deleted;
        /// <summary>
        /// Gets or sets whether or not the form has been deleted.
        /// </summary>
        public bool DeletedValue { get=> Deleted.Value; set => Deleted.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the object type associated with the form.
        /// </summary>
        public ApiProperty<int> ObjectTypeId => _objectTypeId ?? (_objectTypeId = new ApiProperty<int>(this, "object_type_id"));
        private ApiProperty<int> _objectTypeId;
        /// <summary>
        /// Gets or sets the ID of the object type associated with the form.
        /// </summary>
        public int ObjectTypeIdValue { get=> ObjectTypeId.Value; set => ObjectTypeId.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set whether or not the form has a responsive layout.
        /// </summary>
        public ApiPropertyIntBool ResponsiveLayout => _responsiveLayout ?? (_responsiveLayout = new ApiPropertyIntBool(this, "responsive"));
        private ApiPropertyIntBool _responsiveLayout;
        /// <summary>
        /// Gets or sets whether or not the form has a responsive layout.
        /// </summary>
        public bool ResponsiveLayoutValue { get=> ResponsiveLayout.Value; set => ResponsiveLayout.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the number of times the form has been visited.
        /// </summary>
        public ApiProperty<int> Visits => _visits ?? (_visits = new ApiProperty<int>(this, "visits"));
        private ApiProperty<int> _visits;
        /// <summary>
        /// Gets or sets the number of times the form has been visited.
        /// </summary>
        public int VisitsValue { get=> Visits.Value; set => Visits.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the number of times unique visitors have visited the form.
        /// </summary>
        public ApiProperty<int> UniqueVisits => _uniqueVisits ?? (_uniqueVisits = new ApiProperty<int>(this, "unique_visits"));
        private ApiProperty<int> _uniqueVisits;
        /// <summary>
        /// Gets or sets the number of times unique visitors have visited the form.
        /// </summary>
        public int UniqueVisitsValue { get=> UniqueVisits.Value; set => UniqueVisits.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date and time the form was created. Note that this field will not contain data for any forms created prior to November 7, 2017.
        /// </summary>
        public ApiPropertyDateTime DateCreated => _dateCreated ?? (_dateCreated = new ApiPropertyDateTime(this, "date"));
        private ApiPropertyDateTime _dateCreated;
        /// <summary>
        /// Gets or sets the date and time the form was created. Note that this field will not contain data for any forms created prior to November 7, 2017.
        /// </summary>
        public DateTimeOffset DateCreatedValue { get=> DateCreated.Value; set => DateCreated.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date and time the form was last modified.
        /// </summary>
        public ApiPropertyDateTime DateModified => _dateModified ?? (_dateModified = new ApiPropertyDateTime(this, "dlm"));
        private ApiPropertyDateTime _dateModified;
        /// <summary>
        /// Gets or sets the date and time the form was last modified.
        /// </summary>
        public DateTimeOffset DateModifiedValue { get=> DateModified.Value; set => DateModified.Value = value; }

        public ApiPropertyString Campaigns => _campaigns ?? (_campaigns = new ApiPropertyString(this, "campaigns"));
        private ApiPropertyString _campaigns;
        public string CampaignsValue { get=> Campaigns.Value; set => Campaigns.Value = value; }

        public ApiProperty<int> UniqueFillouts => _uniqueFillouts ?? (_uniqueFillouts = new ApiProperty<int>(this, "unique_fillouts"));
        private ApiProperty<int> _uniqueFillouts;
        public int UniqueFilloutsValue { get=> UniqueFillouts.Value; set => UniqueFillouts.Value = value; }

        public ApiProperty<decimal> Revenue => _revenue ?? (_revenue = new ApiProperty<decimal>(this, "revenue"));
        private ApiProperty<decimal> _revenue;
        public decimal RevenueValue { get=> Revenue.Value; set => Revenue.Value = value; }

        public ApiPropertyBool SkipBackgroundAutomation => _skipBackgroundAutomation ?? (_skipBackgroundAutomation = new ApiPropertyBool(this, "skip_bg_automation"));
        private ApiPropertyBool _skipBackgroundAutomation;
        public bool SkipBackgroundAutomationValue { get=> SkipBackgroundAutomation.Value; set => SkipBackgroundAutomation.Value = value; }

        public ApiProperty<int> RuleHash => _ruleHash ?? (_ruleHash = new ApiProperty<int>(this, "rule_hash"));
        private ApiProperty<int> _ruleHash;
        public int RuleHashValue { get=> RuleHash.Value; set => RuleHash.Value = value; }




        /// <summary>
        /// The type of form.
        /// </summary>
        public enum FormType
        {
            SmartForm = 10,
            ONTRAform = 11
        }
    }
}
