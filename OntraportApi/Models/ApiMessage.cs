using System;
using EmergenceGuardian.OntraportApi.Converters;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// Message objects contain data for all of the messages in an account. Supported message types include ONTRAmail, legacy HTML emails, SMS, task messages, and postcards.
    /// </summary>
    public class ApiMessage : ApiObject
    {
        /// <summary>
        /// Returns a ApiProperty object to get or set the message name.
        /// </summary>
        public ApiPropertyString AliasField => _aliasField ?? (_aliasField = new ApiPropertyString(this, AliasKey));
        private ApiPropertyString _aliasField;
        public const string AliasKey = "alias";
        /// <summary>
        /// Gets or sets the message name.
        /// </summary>
        public string Alias { get => AliasField.Value; set => AliasField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the message type.
        /// </summary>
        public ApiPropertyStringEnum<MessageType> TypeField => _typeField ?? (_typeField = new ApiPropertyStringEnum<MessageType>(this, TypeKey));
        private ApiPropertyStringEnum<MessageType> _typeField;
        public const string TypeKey = "type";
        /// <summary>
        /// Gets or sets the message type.
        /// </summary>
        public MessageType? Type { get => TypeField.Value; set => TypeField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the last time the message was manually saved.
        /// </summary>
        public ApiPropertyDateTime LastSaveTimeField => _lastSaveTimeField ?? (_lastSaveTimeField = new ApiPropertyDateTime(this, LastSaveTimeKey));
        private ApiPropertyDateTime _lastSaveTimeField;
        public const string LastSaveTimeKey = "last_save";
        /// <summary>
        /// Gets or sets the last time the message was manually saved.
        /// </summary>
        public DateTimeOffset? LastSaveTime { get => LastSaveTimeField.Value; set => LastSaveTimeField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the last time the message was automatically saved.
        /// </summary>
        public ApiPropertyDateTime LastAutoSaveTimeField => _lastAutoSaveTimeField ?? (_lastAutoSaveTimeField = new ApiPropertyDateTime(this, LastAutoSaveTimeKey));
        private ApiPropertyDateTime _lastAutoSaveTimeField;
        public const string LastAutoSaveTimeKey = "last_auto";
        /// <summary>
        /// Gets or sets the last time the message was automatically saved.
        /// </summary>
        public DateTimeOffset? LastAutoSaveTime { get => LastAutoSaveTimeField.Value; set => LastAutoSaveTimeField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the content of the last autosave.
        /// </summary>
        public ApiPropertyString AutoSaveContentField => _autoSaveContentField ?? (_autoSaveContentField = new ApiPropertyString(this, AutoSaveContentKey));
        private ApiPropertyString _autoSaveContentField;
        public const string AutoSaveContentKey = "autosave";
        /// <summary>
        /// Gets or sets the content of the last autosave.
        /// </summary>
        public string AutoSaveContent { get => AutoSaveContentField.Value; set => AutoSaveContentField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date the message was created.
        /// </summary>
        public ApiPropertyDateTime DateCreatedField => _dateCreatedField ?? (_dateCreatedField = new ApiPropertyDateTime(this, DateCreatedKey));
        private ApiPropertyDateTime _dateCreatedField;
        public const string DateCreatedKey = "date";
        /// <summary>
        /// Gets or sets the date the message was created.
        /// </summary>
        public DateTimeOffset? DateCreated { get => DateCreatedField.Value; set => DateCreatedField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the number of times the message has been sent.
        /// </summary>
        public ApiProperty<int> StatSentField => _statSentField ?? (_statSentField = new ApiProperty<int>(this, StatSentKey));
        private ApiProperty<int> _statSentField;
        public const string StatSentKey = "mcsent";
        /// <summary>
        /// Gets or sets the number of times the message has been sent.
        /// </summary>
        public int? StatSent { get => StatSentField.Value; set => StatSentField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the rate of messages that have been opened versus sent, represented as a percentage.
        /// </summary>
        public ApiProperty<int> StatOpenedField => _statOpenedField ?? (_statOpenedField = new ApiProperty<int>(this, StatOpenedKey));
        private ApiProperty<int> _statOpenedField;
        public const string StatOpenedKey = "mcopened";
        /// <summary>
        /// Gets or sets the rate of messages that have been opened versus sent, represented as a percentage.
        /// </summary>
        public int? StatOpened { get => StatOpenedField.Value; set => StatOpenedField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the rate of clickthroughs in opened messages, represented as a percentage.
        /// </summary>
        public ApiProperty<int> StatClickedField => _statClickedField ?? (_statClickedField = new ApiProperty<int>(this, StatClickedKey));
        private ApiProperty<int> _statClickedField;
        public const string StatClickedKey = "mcclicked";
        /// <summary>
        /// Gets or sets the rate of clickthroughs in opened messages, represented as a percentage.
        /// </summary>
        public int? StatClicked { get => StatClickedField.Value; set => StatClickedField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the rate of complaints about sent messages, represented as a percentage.
        /// </summary>
        public ApiProperty<int> StatAbuseField => _statAbuseField ?? (_statAbuseField = new ApiProperty<int>(this, StatAbuseKey));
        private ApiProperty<int> _statAbuseField;
        public const string StatAbuseKey = "mcabuse";
        /// <summary>
        /// Gets or sets the rate of complaints about sent messages, represented as a percentage.
        /// </summary>
        public int? StatAbuse { get => StatAbuseField.Value; set => StatAbuseField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the rate of opt-outs on this message, represented as a percentage.
        /// </summary>
        public ApiProperty<int> StatUnsubscribedField => _statUnsubscribedField ?? (_statUnsubscribedField = new ApiProperty<int>(this, StatUnsubscribedKey));
        private ApiProperty<int> _statUnsubscribedField;
        public const string StatUnsubscribedKey = "mcunsub";
        /// <summary>
        /// Gets or sets the rate of opt-outs on this message, represented as a percentage.
        /// </summary>
        public int? StatUnsubscribed { get => StatUnsubscribedField.Value; set => StatUnsubscribedField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the SpamAssassin spam score of the message. The lower the score, the better the rating. Messages with a spam score of 5 or higher will not be sent.
        /// </summary>
        public ApiProperty<float> SpamScoreField => _spamScoreField ?? (_spamScoreField = new ApiProperty<float>(this, SpamScoreKey));
        private ApiProperty<float> _spamScoreField;
        public const string SpamScoreKey = "spam_score";
        /// <summary>
        /// Gets or sets the SpamAssassin spam score of the message. The lower the score, the better the rating. Messages with a spam score of 5 or higher will not be sent.
        /// </summary>
        public float? SpamScore { get => SpamScoreField.Value; set => SpamScoreField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the email subject line.
        /// </summary>
        public ApiPropertyString SubjectField => _subjectField ?? (_subjectField = new ApiPropertyString(this, SubjectKey));
        private ApiPropertyString _subjectField;
        public const string SubjectKey = "subject";
        /// <summary>
        /// Gets or sets the email subject line.
        /// </summary>
        public string Subject { get => SubjectField.Value; set => SubjectField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the object type associated with the message. The default is 0 for contact objects. This field should only be changed if you are using custom objects.
        /// </summary>
        public ApiProperty<int> ObjectTypeIdField => _objectTypeIdField ?? (_objectTypeIdField = new ApiProperty<int>(this, ObjectTypeIdKey));
        private ApiProperty<int> _objectTypeIdField;
        public const string ObjectTypeIdKey = "object_type_id";
        /// <summary>
        /// Gets or sets the ID of the object type associated with the message. The default is 0 for contact objects. This field should only be changed if you are using custom objects.
        /// </summary>
        public int? ObjectTypeId { get => ObjectTypeIdField.Value; set => ObjectTypeIdField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the data and time the message was last modified.
        /// </summary>
        public ApiPropertyDateTime DateLastModifiedField => _dateLastModifiedField ?? (_dateLastModifiedField = new ApiPropertyDateTime(this, DateLastModifiedKey));
        private ApiPropertyDateTime _dateLastModifiedField;
        public const string DateLastModifiedKey = "dlm";
        /// <summary>
        /// Gets or sets the data and time the message was last modified.
        /// </summary>
        public DateTimeOffset? DateLastModified { get => DateLastModifiedField.Value; set => DateLastModifiedField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set whether or not this message is transactional email.
        /// </summary>
        public ApiPropertyIntBool TransactionEmailField => _transactionEmailField ?? (_transactionEmailField = new ApiPropertyIntBool(this, TransactionEmailKey));
        private ApiPropertyIntBool _transactionEmailField;
        public const string TransactionEmailKey = "transactional_email";
        /// <summary>
        /// Gets or sets whether or not this message is transactional email.
        /// </summary>
        public bool? TransactionEmail { get => TransactionEmailField.Value; set => TransactionEmailField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the content of an ONTRAmail message.
        /// </summary>
        public ApiPropertyString ContentField => _contentField ?? (_contentField = new ApiPropertyString(this, ContentKey));
        private ApiPropertyString _contentField;
        public const string ContentKey = "json_data";
        /// <summary>
        /// Gets or sets the content of an ONTRAmail message.
        /// </summary>
        public string Content { get => ContentField.Value; set => ContentField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the user having ownership of the message.
        /// </summary>
        public ApiProperty<int> OwnerField => _ownerField ?? (_ownerField = new ApiProperty<int>(this, OwnerKey));
        private ApiProperty<int> _ownerField;
        public const string OwnerKey = "owner";
        /// <summary>
        /// Gets or sets the ID of the user having ownership of the message.
        /// </summary>
        public int? Owner { get => OwnerField.Value; set => OwnerField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set who the message will be sent from. Options are owner, custom, or the desired user ID.
        /// </summary>
        public ApiPropertyString FromField => _fromField ?? (_fromField = new ApiPropertyString(this, FromKey));
        private ApiPropertyString _fromField;
        public const string FromKey = "from";
        /// <summary>
        /// Gets or sets who the message will be sent from. Options are owner, custom, or the desired user ID.
        /// </summary>
        public string From { get => FromField.Value; set => FromField.Value = value; }

        /// <summary>
        /// For legacy emails only, returns a ApiProperty object to get or set the HTML content of the message.
        /// </summary>
        public ApiPropertyString MessageBodyField => _messageBodyField ?? (_messageBodyField = new ApiPropertyString(this, MessageBodyKey));
        private ApiPropertyString _messageBodyField;
        public const string MessageBodyKey = "message_body";
        /// <summary>
        /// For legacy emails only, gets or sets the HTML content of the message.
        /// </summary>
        public string MessageBody { get => MessageBodyField.Value; set => MessageBodyField.Value = value; }

        /// <summary>
        /// If the from field is set to custom, returns a ApiProperty object to get or set the name the message should come from.
        /// </summary>
        public ApiPropertyString FromNameField => _fromNameField ?? (_fromNameField = new ApiPropertyString(this, FromNameKey));
        private ApiPropertyString _fromNameField;
        public const string FromNameKey = "send_out_name";
        /// <summary>
        /// If the from field is set to custom, gets or sets the name the message should come from.
        /// </summary>
        public string FromName { get => FromNameField.Value; set => FromNameField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the "reply to" email address.
        /// </summary>
        public ApiPropertyString ReplyToEmailField => _replyToEmailField ?? (_replyToEmailField = new ApiPropertyString(this, ReplyToEmailKey));
        private ApiPropertyString _replyToEmailField;
        public const string ReplyToEmailKey = "reply_to_email";
        /// <summary>
        /// Gets or sets the "reply to" email address.
        /// </summary>
        public string ReplyToEmail { get => ReplyToEmailField.Value; set => ReplyToEmailField.Value = value; }

        /// <summary>
        /// For email messages, returns a ApiProperty object to get or set the plain text version of your email. For SMS messages, the content to be sent.
        /// </summary>
        public ApiPropertyString PlainTextField => _plainTextField ?? (_plainTextField = new ApiPropertyString(this, PlainTextKey));
        private ApiPropertyString _plainTextField;
        public const string PlainTextKey = "plaintext";
        /// <summary>
        /// For email messages, gets or sets the plain text version of your email. For SMS messages, the content to be sent.
        /// </summary>
        public string PlainText { get => PlainTextField.Value; set => PlainTextField.Value = value; }

        /// <summary>
        /// Emails are automatically sent from your default email address. If you would like to send from another email address, this field can contain any validated email address.
        /// </summary>
        public ApiPropertyString FromEmailField => _fromEmailField ?? (_fromEmailField = new ApiPropertyString(this, FromEmailKey));
        private ApiPropertyString _fromEmailField;
        public const string FromEmailKey = "send_from";
        /// <summary>
        /// Emails are automatically sent from your default email address. If you would like to send from another email address, this field can contain any validated email address.
        /// </summary>
        public string FromEmail { get => FromEmailField.Value; set => FromEmailField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the SendTo address.
        /// </summary>
        public ApiPropertyString SendToField => _sendToField ?? (_sendToField = new ApiPropertyString(this, SendToKey));
        private ApiPropertyString _sendToField;
        public const string SendToKey = "send_to";
        /// <summary>
        /// Used only with custom objects and SMS messages. In custom objects, you can use this field to send to another email in a parent/child relationship. 
        /// For example, you could send to a related child object instead of the contact's default email address. The field is stored in the 
        /// format {related_field}//{child_field}, where related_field is the parent field relating one object to another and child_field is 
        /// the actual email field in the related object you would like to send to. For SMS messages, this field defaults to sms_number.
        /// </summary>
        public string SendTo { get => SendToField.Value; set => SendToField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set custom HTML email header data.
        /// </summary>
        public ApiPropertyString EmailHeaderDataField => _emailHeaderDataField ?? (_emailHeaderDataField = new ApiPropertyString(this, EmailHeaderDataKey));
        private ApiPropertyString _emailHeaderDataField;
        public const string EmailHeaderDataKey = "email_header_data";
        /// <summary>
        /// Gets or sets custom HTML email header data.
        /// </summary>
        public string EmailHeaderData { get => EmailHeaderDataField.Value; set => EmailHeaderDataField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or setes whether or not long lines are being wrapped.
        /// </summary>
        public ApiProperty<int> WordWrapField => _wordWrapField ?? (_wordWrapField = new ApiProperty<int>(this, WordWrapKey));
        private ApiProperty<int> _wordWrapField;
        public const string WordWrapKey = "word_wrap_checkbox";
        /// <summary>
        /// Gets or setes whether or not long lines are being wrapped.
        /// </summary>
        public int? WordWrap { get => WordWrapField.Value; set => WordWrapField.Value = value; }

        public ApiProperty<int> UtmTrackingField => _utmTrackingField ?? (_utmTrackingField = new ApiProperty<int>(this, UtmTrackingKey));
        private ApiProperty<int> _utmTrackingField;
        public const string UtmTrackingKey = "utm_tracking";
        public int? UtmTracking { get => _utmTrackingField.Value; set => _utmTrackingField.Value = value; }

        public ApiPropertyString ResourceField => _resourceField ?? (_resourceField = new ApiPropertyString(this, ResourceKey));
        private ApiPropertyString _resourceField;
        public const string ResourceKey = "resource";
        public string Resource { get => _resourceField.Value; set => _resourceField.Value = value; }






        /// <summary>
        /// The message type.
        /// </summary>
        public enum MessageType
        {
            /// <summary>
            /// Legacy email
            /// </summary>
            Email,
            /// <summary>
            /// ONTRAmail
            /// </summary>
            Template,
            /// <summary>
            /// Text message
            /// </summary>
            Sms,
            /// <summary>
            /// Task messages
            /// </summary>
            Task,
            /// <summary>
            /// Postcard
            /// </summary>
            Postcard
        }
    }
}
