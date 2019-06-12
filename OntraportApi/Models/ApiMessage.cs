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
        public ApiPropertyString Alias => _alias ?? (_alias = new ApiPropertyString(this, "alias"));
        private ApiPropertyString _alias;
        /// <summary>
        /// Gets or sets the message name.
        /// </summary>
        public string AliasValue { get => Alias.Value; set => Alias.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the message type.
        /// </summary>
        public ApiPropertyStringEnum<MessageType> Type => _type ?? (_type = new ApiPropertyStringEnum<MessageType>(this, "type"));
        private ApiPropertyStringEnum<MessageType> _type;
        /// <summary>
        /// Gets or sets the message type.
        /// </summary>
        public MessageType TypeValue { get => Type.Value; set => Type.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the last time the message was manually saved.
        /// </summary>
        public ApiPropertyDateTime LastSaveTime => _lastSaveTime ?? (_lastSaveTime = new ApiPropertyDateTime(this, "last_save"));
        private ApiPropertyDateTime _lastSaveTime;
        /// <summary>
        /// Gets or sets the last time the message was manually saved.
        /// </summary>
        public DateTimeOffset LastSaveTimeValue { get => LastSaveTime.Value; set => LastSaveTime.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the last time the message was automatically saved.
        /// </summary>
        public ApiPropertyDateTime LastAutoSaveTime => _lastAutoSaveTime ?? (_lastAutoSaveTime = new ApiPropertyDateTime(this, "last_auto"));
        private ApiPropertyDateTime _lastAutoSaveTime;
        /// <summary>
        /// Gets or sets the last time the message was automatically saved.
        /// </summary>
        public DateTimeOffset LastAutoSaveTimeValue { get => LastAutoSaveTime.Value; set => LastAutoSaveTime.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the content of the last autosave.
        /// </summary>
        public ApiPropertyString AutoSaveContent => _autoSaveContent ?? (_autoSaveContent = new ApiPropertyString(this, "autosave"));
        private ApiPropertyString _autoSaveContent;
        /// <summary>
        /// Gets or sets the content of the last autosave.
        /// </summary>
        public string AutoSaveContentValue { get => AutoSaveContent.Value; set => AutoSaveContent.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date the message was created.
        /// </summary>
        public ApiPropertyDateTime DateCreated => _dateCreated ?? (_dateCreated = new ApiPropertyDateTime(this, "date"));
        private ApiPropertyDateTime _dateCreated;
        /// <summary>
        /// Gets or sets the date the message was created.
        /// </summary>
        public DateTimeOffset DateCreatedValue { get => DateCreated.Value; set => DateCreated.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the number of times the message has been sent.
        /// </summary>
        public ApiProperty<int> StatSent => _statSent ?? (_statSent = new ApiProperty<int>(this, "mcsent"));
        private ApiProperty<int> _statSent;
        /// <summary>
        /// Gets or sets the number of times the message has been sent.
        /// </summary>
        public int StatSentValue { get => StatSent.Value; set => StatSent.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the rate of messages that have been opened versus sent, represented as a percentage.
        /// </summary>
        public ApiProperty<int> StatOpened => _statOpened ?? (_statOpened = new ApiProperty<int>(this, "mcopened"));
        private ApiProperty<int> _statOpened;
        /// <summary>
        /// Gets or sets the rate of messages that have been opened versus sent, represented as a percentage.
        /// </summary>
        public int StatOpenedValue { get => StatOpened.Value; set => StatOpened.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the rate of clickthroughs in opened messages, represented as a percentage.
        /// </summary>
        public ApiProperty<int> StatClicked => _statClicked ?? (_statClicked = new ApiProperty<int>(this, "mcclicked"));
        private ApiProperty<int> _statClicked;
        /// <summary>
        /// Gets or sets the rate of clickthroughs in opened messages, represented as a percentage.
        /// </summary>
        public int StatClickedValue { get => StatClicked.Value; set => StatClicked.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the rate of complaints about sent messages, represented as a percentage.
        /// </summary>
        public ApiProperty<int> StatAbuse => _statAbuse ?? (_statAbuse = new ApiProperty<int>(this, "mcabuse"));
        private ApiProperty<int> _statAbuse;
        /// <summary>
        /// Gets or sets the rate of complaints about sent messages, represented as a percentage.
        /// </summary>
        public int StatAbuseValue { get => StatAbuse.Value; set => StatAbuse.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the rate of opt-outs on this message, represented as a percentage.
        /// </summary>
        public ApiProperty<int> StatUnsubscribed => _statUnsubscribed ?? (_statUnsubscribed = new ApiProperty<int>(this, "mcunsub"));
        private ApiProperty<int> _statUnsubscribed;
        /// <summary>
        /// Gets or sets the rate of opt-outs on this message, represented as a percentage.
        /// </summary>
        public int StatUnsubscribedValue { get => StatUnsubscribed.Value; set => StatUnsubscribed.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the SpamAssassin spam score of the message. The lower the score, the better the rating. Messages with a spam score of 5 or higher will not be sent.
        /// </summary>
        public ApiProperty<float> SpamScore => _spamScore ?? (_spamScore = new ApiProperty<float>(this, "spam_score"));
        private ApiProperty<float> _spamScore;
        /// <summary>
        /// Gets or sets the SpamAssassin spam score of the message. The lower the score, the better the rating. Messages with a spam score of 5 or higher will not be sent.
        /// </summary>
        public float SpamScoreValue { get => SpamScore.Value; set => SpamScore.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the email subject line.
        /// </summary>
        public ApiPropertyString Subject => _subject ?? (_subject = new ApiPropertyString(this, "subject"));
        private ApiPropertyString _subject;
        /// <summary>
        /// Gets or sets the email subject line.
        /// </summary>
        public string SubjectValue { get => Subject.Value; set => Subject.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the object type associated with the message. The default is 0 for contact objects. This field should only be changed if you are using custom objects.
        /// </summary>
        public ApiProperty<int> ObjectTypeId => _objectTypeId ?? (_objectTypeId = new ApiProperty<int>(this, "object_type_id"));
        private ApiProperty<int> _objectTypeId;
        /// <summary>
        /// Gets or sets the ID of the object type associated with the message. The default is 0 for contact objects. This field should only be changed if you are using custom objects.
        /// </summary>
        public int ObjectTypeIdValue { get => ObjectTypeId.Value; set => ObjectTypeId.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the data and time the message was last modified.
        /// </summary>
        public ApiPropertyDateTime DateLastModified => _dateLastModified ?? (_dateLastModified = new ApiPropertyDateTime(this, "dlm"));
        private ApiPropertyDateTime _dateLastModified;
        /// <summary>
        /// Gets or sets the data and time the message was last modified.
        /// </summary>
        public DateTimeOffset DateLastModifiedValue { get => DateLastModified.Value; set => DateLastModified.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set whether or not this message is transactional email.
        /// </summary>
        public ApiPropertyIntBool TransactionEmail => _transactionEmail ?? (_transactionEmail = new ApiPropertyIntBool(this, "transactional_email"));
        private ApiPropertyIntBool _transactionEmail;
        /// <summary>
        /// Gets or sets whether or not this message is transactional email.
        /// </summary>
        public bool TransactionEmailValue { get => TransactionEmail.Value; set => TransactionEmail.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the content of an ONTRAmail message.
        /// </summary>
        public ApiPropertyString Content => _content ?? (_content = new ApiPropertyString(this, "json_data"));
        private ApiPropertyString _content;
        /// <summary>
        /// Gets or sets the content of an ONTRAmail message.
        /// </summary>
        public string ContentValue { get => Content.Value; set => Content.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the user having ownership of the message.
        /// </summary>
        public ApiProperty<int> Owner => _owner ?? (_owner = new ApiProperty<int>(this, "owner"));
        private ApiProperty<int> _owner;
        /// <summary>
        /// Gets or sets the ID of the user having ownership of the message.
        /// </summary>
        public int OwnerValue { get => Owner.Value; set => Owner.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set who the message will be sent from. Options are owner, custom, or the desired user ID.
        /// </summary>
        public ApiPropertyString From => _from ?? (_from = new ApiPropertyString(this, "from"));
        private ApiPropertyString _from;
        /// <summary>
        /// Gets or sets who the message will be sent from. Options are owner, custom, or the desired user ID.
        /// </summary>
        public string FromValue { get => From.Value; set => From.Value = value; }

        /// <summary>
        /// For legacy emails only, returns a ApiProperty object to get or set the HTML content of the message.
        /// </summary>
        public ApiPropertyString MessageBody => _messageBody ?? (_messageBody = new ApiPropertyString(this, "message_body"));
        private ApiPropertyString _messageBody;
        /// <summary>
        /// For legacy emails only, gets or sets the HTML content of the message.
        /// </summary>
        public string MessageBodyValue { get => MessageBody.Value; set => MessageBody.Value = value; }

        /// <summary>
        /// If the from field is set to custom, returns a ApiProperty object to get or set the name the message should come from.
        /// </summary>
        public ApiPropertyString FromName => _fromName ?? (_fromName = new ApiPropertyString(this, "send_out_name"));
        private ApiPropertyString _fromName;
        /// <summary>
        /// If the from field is set to custom, gets or sets the name the message should come from.
        /// </summary>
        public string FromNameValue { get => FromName.Value; set => FromName.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the "reply to" email address.
        /// </summary>
        public ApiPropertyString ReplyToEmail => _replyToEmail ?? (_replyToEmail = new ApiPropertyString(this, "reply_to_email"));
        private ApiPropertyString _replyToEmail;
        /// <summary>
        /// Gets or sets the "reply to" email address.
        /// </summary>
        public string ReplyToEmailValue { get => ReplyToEmail.Value; set => ReplyToEmail.Value = value; }

        /// <summary>
        /// For email messages, returns a ApiProperty object to get or set the plain text version of your email. For SMS messages, the content to be sent.
        /// </summary>
        public ApiPropertyString PlainText => _plainText ?? (_plainText = new ApiPropertyString(this, "plaintext"));
        private ApiPropertyString _plainText;
        /// <summary>
        /// For email messages, gets or sets the plain text version of your email. For SMS messages, the content to be sent.
        /// </summary>
        public string PlainTextValue { get => PlainText.Value; set => PlainText.Value = value; }

        /// <summary>
        /// Emails are automatically sent from your default email address. If you would like to send from another email address, this field can contain any validated email address.
        /// </summary>
        public ApiPropertyString FromEmail => _fromEmail ?? (_fromEmail = new ApiPropertyString(this, "send_from"));
        private ApiPropertyString _fromEmail;
        /// <summary>
        /// Emails are automatically sent from your default email address. If you would like to send from another email address, this field can contain any validated email address.
        /// </summary>
        public string FromEmailValue { get => FromEmail.Value; set => FromEmail.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the SendTo address.
        /// </summary>
        public ApiPropertyString SendTo => _sendTo ?? (_sendTo = new ApiPropertyString(this, "send_to"));
        private ApiPropertyString _sendTo;
        /// <summary>
        /// Used only with custom objects and SMS messages. In custom objects, you can use this field to send to another email in a parent/child relationship. 
        /// For example, you could send to a related child object instead of the contact's default email address. The field is stored in the 
        /// format {related_field}//{child_field}, where related_field is the parent field relating one object to another and child_field is 
        /// the actual email field in the related object you would like to send to. For SMS messages, this field defaults to sms_number.
        /// </summary>
        public string SendToValue { get => SendTo.Value; set => SendTo.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set custom HTML email header data.
        /// </summary>
        public ApiPropertyString EmailHeaderData => _emailHeaderData ?? (_emailHeaderData = new ApiPropertyString(this, "email_header_data"));
        private ApiPropertyString _emailHeaderData;
        /// <summary>
        /// Gets or sets custom HTML email header data.
        /// </summary>
        public string EmailHeaderDataValue { get => EmailHeaderData.Value; set => EmailHeaderData.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or setes whether or not long lines are being wrapped.
        /// </summary>
        public ApiProperty<int> WordWrap => _wordWrap ?? (_wordWrap = new ApiProperty<int>(this, "word_wrap_checkbox"));
        private ApiProperty<int> _wordWrap;
        /// <summary>
        /// Gets or setes whether or not long lines are being wrapped.
        /// </summary>
        public int WordWrapValue { get => WordWrap.Value; set => WordWrap.Value = value; }

        //public ApiProperty<int> UtmTracking => _utmTracking ?? (_utmTracking = new ApiProperty<int>(this, "utm_tracking"));
        //private ApiProperty<int> _utmTracking;

        //public ApiProperty Resource => _resource ?? (_resource = new ApiProperty(this, "resource"));
        //private ApiProperty _resource;





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
