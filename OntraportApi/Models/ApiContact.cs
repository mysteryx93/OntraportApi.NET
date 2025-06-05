﻿namespace HanumanInstitute.OntraportApi.Models;

/// <summary>
/// Contact objects allow you to keep up-to-date records for all the contacts you are managing.
/// </summary>
public class ApiContact : ApiCustomObjectBase
{
    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's first name.
    /// </summary>
    public ApiPropertyString FirstNameField => _firstNameField ??= new ApiPropertyString(this, FirstNameKey);
    private ApiPropertyString? _firstNameField;
    public const string FirstNameKey = "firstname";
    /// <summary>
    /// Gets or sets the contact's first name.
    /// </summary>
    public string? FirstName { get => FirstNameField.Value; set => FirstNameField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's last name.
    /// </summary>
    public ApiPropertyString LastNameField => _lastNameField ??= new ApiPropertyString(this, LastNameKey);
    private ApiPropertyString? _lastNameField;
    public const string LastNameKey = "lastname";
    /// <summary>
    /// Gets or sets the contact's last name.
    /// </summary>
    public string? LastName { get => LastNameField.Value; set => LastNameField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's email address.
    /// </summary>
    public ApiPropertyString EmailField => _emailField ??= new ApiPropertyString(this, EmailKey);
    private ApiPropertyString? _emailField;
    public const string EmailKey = "email";
    /// <summary>
    /// Gets or sets the contact's email address.
    /// </summary>
    public string? Email { get => EmailField.Value; set => EmailField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the affiliate ID of the first affiliate to refer the contact.
    /// </summary>
    public ApiProperty<int> FirstReferrerField => _firstReferrerField ??= new ApiProperty<int>(this, FirstReferrerKey);
    private ApiProperty<int>? _firstReferrerField;
    public const string FirstReferrerKey = "freferrer";
    /// <summary>
    /// Gets or sets the affiliate ID of the first affiliate to refer the contact.
    /// </summary>
    public int? FirstReferrer { get => FirstReferrerField.Value; set => FirstReferrerField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the affiliate ID of the last affiliate to refer the contact.
    /// </summary>
    public ApiProperty<int> LastReferrerField => _lastReferrerField ??= new ApiProperty<int>(this, LastReferrerKey);
    private ApiProperty<int>? _lastReferrerField;
    public const string LastReferrerKey = "lreferrer";
    /// <summary>
    /// Gets or sets the affiliate ID of the last affiliate to refer the contact.
    /// </summary>
    public int? LastReferrer { get => LastReferrerField.Value; set => LastReferrerField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's postal address.
    /// </summary>
    public ApiPropertyString AddressField => _addressField ??= new ApiPropertyString(this, AddressKey);
    private ApiPropertyString? _addressField;
    public const string AddressKey = "address";
    /// <summary>
    /// Gets or sets the contact's postal address.
    /// </summary>
    public string? Address { get => AddressField.Value; set => AddressField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set a second address field which is generally used for storing suite or unit numbers.
    /// </summary>
    public ApiPropertyString Address2Field => _address2Field ??= new ApiPropertyString(this, Address2Key);
    private ApiPropertyString? _address2Field;
    public const string Address2Key = "address2";
    /// <summary>
    /// Gets or sets a second address field which is generally used for storing suite or unit numbers.
    /// </summary>
    public string? Address2 { get => Address2Field.Value; set => Address2Field.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's city.
    /// </summary>
    public ApiPropertyString CityField => _cityField ??= new ApiPropertyString(this, CityKey);
    private ApiPropertyString? _cityField;
    public const string CityKey = "city";
    /// <summary>
    /// Gets or sets the contact's city.
    /// </summary>
    public string? City { get => CityField.Value; set => CityField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's state.
    /// </summary>
    public ApiPropertyString StateField => _stateField ??= new ApiPropertyString(this, StateKey);
    private ApiPropertyString? _stateField;
    public const string StateKey = "state";
    /// <summary>
    /// Gets or sets the contact's state.
    /// </summary>
    public string? State { get => StateField.Value; set => StateField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's postal code.
    /// </summary>
    public ApiPropertyString ZipField => _zipField ??= new ApiPropertyString(this, ZipKey);
    private ApiPropertyString? _zipField;
    public const string ZipKey = "zip";
    /// <summary>
    /// Gets or sets the contact's postal code.
    /// </summary>
    public string? Zip { get => ZipField.Value; set => ZipField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's country.
    /// </summary>
    public ApiPropertyString CountryField => _countryField ??= new ApiPropertyString(this, CountryKey);
    private ApiPropertyString? _countryField;
    public const string CountryKey = "country";
    /// <summary>
    /// Gets or sets the contact's country.
    /// </summary>
    public string? Country { get => CountryField.Value; set => CountryField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's birthday.
    /// </summary>
    public ApiPropertyDateTime BirthdayField => _birthdayField ??= new ApiPropertyDateTime(this, BirthdayKey);
    private ApiPropertyDateTime? _birthdayField;
    public const string BirthdayKey = "birthday";
    /// <summary>
    /// Gets or sets the contact's birthday.
    /// </summary>
    public DateTimeOffset? Birthday { get => BirthdayField.Value; set => BirthdayField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's priority.
    /// </summary>
    public ApiPropertyIntEnum<ContactPriority> PriorityField => _priorityField ??= new ApiPropertyIntEnum<ContactPriority>(this, PriorityKey);
    private ApiPropertyIntEnum<ContactPriority>? _priorityField;
    public const string PriorityKey = "priority";
    /// <summary>
    /// Gets or sets the contact's priority.
    /// </summary>
    public ContactPriority? Priority { get => PriorityField.Value; set => PriorityField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's Sales Stage.
    /// </summary>
    public ApiProperty<int> StatusField => _statusField ??= new ApiProperty<int>(this, StatusKey);
    private ApiProperty<int>? _statusField;
    public const string StatusKey = "status";
    /// <summary>
    /// Gets or sets the contact's Sales Stage.
    /// </summary>
    public int? Status { get => StatusField.Value; set => StatusField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's home phone number.
    /// </summary>
    public ApiPropertyString HomePhoneField => _homePhoneField ??= new ApiPropertyString(this, HomePhoneKey);
    private ApiPropertyString? _homePhoneField;
    public const string HomePhoneKey = "home_phone";
    /// <summary>
    /// Gets or sets the contact's home phone number.
    /// </summary>
    public string? HomePhone { get => HomePhoneField.Value; set => HomePhoneField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the mobile number where the contact prefers receive text messages.
    /// </summary>
    public ApiPropertyString SmsNumberField => _smsNumberField ??= new ApiPropertyString(this, SmsNumberKey);
    private ApiPropertyString? _smsNumberField;
    public const string SmsNumberKey = "sms_number";
    /// <summary>
    /// Gets or sets the mobile number where the contact prefers receive text messages.
    /// </summary>
    public string? SmsNumber { get => SmsNumberField.Value; set => SmsNumberField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's office phone number.
    /// </summary>
    public ApiPropertyString OfficePhoneField => _officePhoneField ??= new ApiPropertyString(this, OfficePhoneKey);
    private ApiPropertyString? _officePhoneField;
    public const string OfficePhoneKey = "office_phone";
    /// <summary>
    /// Gets or sets the contact's office phone number.
    /// </summary>
    public string? OfficePhone { get => OfficePhoneField.Value; set => OfficePhoneField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's fax number.
    /// </summary>
    public ApiPropertyString FaxField => _faxField ??= new ApiPropertyString(this, FaxKey);
    private ApiPropertyString? _faxField;
    public const string FaxKey = "fax";
    /// <summary>
    /// Gets or sets the contact's fax number.
    /// </summary>
    public string? Fax { get => FaxField.Value; set => FaxField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the company the contact is affiliated with.
    /// </summary>
    public ApiPropertyString CompanyField => _companyField ??= new ApiPropertyString(this, CompanyKey);
    private ApiPropertyString? _companyField;
    public const string CompanyKey = "company";
    /// <summary>
    /// Gets or sets the company the contact is affiliated with.
    /// </summary>
    public string? Company { get => CompanyField.Value; set => CompanyField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's job title.
    /// </summary>
    public ApiPropertyString TitleField => _titleField ??= new ApiPropertyString(this, TitleKey);
    private ApiPropertyString? _titleField;
    public const string TitleKey = "title";
    /// <summary>
    /// Gets or sets the contact's job title.
    /// </summary>
    public string? Title { get => TitleField.Value; set => TitleField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's website.
    /// </summary>
    public ApiPropertyString WebsiteField => _websiteField ??= new ApiPropertyString(this, WebsiteKey);
    private ApiPropertyString? _websiteField;
    public const string WebsiteKey = "website";
    /// <summary>
    /// Gets or sets the contact's website.
    /// </summary>
    public string? Website { get => WebsiteField.Value; set => WebsiteField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the lead source ID for the tracking URL the contact arrived from.
    /// </summary>
    public ApiProperty<int> LeadSourceFirstField => _leadSourceFirstField ??= new ApiProperty<int>(this, LeadSourceFirstKey);
    private ApiProperty<int>? _leadSourceFirstField;
    public const string LeadSourceFirstKey = "n_lead_source";
    /// <summary>
    /// Gets or sets the lead source ID for the tracking URL the contact arrived from.
    /// </summary>
    public int? LeadSourceFirst { get => LeadSourceFirstField.Value; set => LeadSourceFirstField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the content ID for the tracking URL the contact arrived from.
    /// </summary>
    public ApiProperty<int> LeadContentFirstField => _leadContentFirstField ??= new ApiProperty<int>(this, LeadContentFirstKey);
    private ApiProperty<int>? _leadContentFirstField;
    public const string LeadContentFirstKey = "n_content";
    /// <summary>
    /// Gets or sets the content ID for the tracking URL the contact arrived from.
    /// </summary>
    public int? LeadContentFirst { get => LeadContentFirstField.Value; set => LeadContentFirstField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the medium ID for the tracking URL the contact arrived from.
    /// </summary>
    public ApiProperty<int> LeadMediumFirstField => _leadMediumFirstField ??= new ApiProperty<int>(this, LeadMediumFirstKey);
    private ApiProperty<int>? _leadMediumFirstField;
    public const string LeadMediumFirstKey = "n_medium";
    /// <summary>
    /// Gets or sets the medium ID for the tracking URL the contact arrived from.
    /// </summary>
    public int? LeadMediumFirst { get => LeadMediumFirstField.Value; set => LeadMediumFirstField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the tracking campaign ID for the tracking URL the contact arrived from.
    /// </summary>
    public ApiProperty<int> LeadCampaignFirstField => _leadCampaignFirstField ??= new ApiProperty<int>(this, LeadCampaignFirstKey);
    private ApiProperty<int>? _leadCampaignFirstField;
    public const string LeadCampaignFirstKey = "n_campaign";
    /// <summary>
    /// Gets or sets the tracking campaign ID for the tracking URL the contact arrived from.
    /// </summary>
    public int? LeadCampaignFirst { get => LeadCampaignFirstField.Value; set => LeadCampaignFirstField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the term ID for the tracking URL the contact arrived from.
    /// </summary>
    public ApiProperty<int> LeadTermsFirstField => _leadTermsFirstField ??= new ApiProperty<int>(this, LeadTermsFirstKey);
    private ApiProperty<int>? _leadTermsFirstField;
    public const string LeadTermsFirstKey = "n_term";
    /// <summary>
    /// Gets or sets the term ID for the tracking URL the contact arrived from.
    /// </summary>
    public int? LeadTermsFirst { get => LeadTermsFirstField.Value; set => LeadTermsFirstField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the last lead source ID for the tracking URL the contact arrived from.
    /// </summary>
    public ApiProperty<int> LeadSourceLastField => _leadSourceLastField ??= new ApiProperty<int>(this, LeadSourceLastKey);
    private ApiProperty<int>? _leadSourceLastField;
    public const string LeadSourceLastKey = "l_lead_source";
    /// <summary>
    /// Gets or sets the last lead source ID for the tracking URL the contact arrived from.
    /// </summary>
    public int? LeadSourceLast { get => LeadSourceLastField.Value; set => LeadSourceLastField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the last content ID for the tracking URL the contact arrived from.
    /// </summary>
    public ApiProperty<int> LeadContentLastField => _leadContentLastField ??= new ApiProperty<int>(this, LeadContentLastKey);
    private ApiProperty<int>? _leadContentLastField;
    public const string LeadContentLastKey = "l_content";
    /// <summary>
    /// Gets or sets the last content ID for the tracking URL the contact arrived from.
    /// </summary>
    public int? LeadContentLast { get => LeadContentLastField.Value; set => LeadContentLastField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the last medium ID for the tracking URL the contact arrived from.
    /// </summary>
    public ApiProperty<int> LeadMediumLastField => _leadMediumLastField ??= new ApiProperty<int>(this, LeadMediumLastKey);
    private ApiProperty<int>? _leadMediumLastField;
    public const string LeadMediumLastKey = "l_medium";
    /// <summary>
    /// Gets or sets the last medium ID for the tracking URL the contact arrived from.
    /// </summary>
    public int? LeadMediumLast { get => LeadMediumLastField.Value; set => LeadMediumLastField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the last tracking campaign ID for the tracking URL the contact arrived from.
    /// </summary>
    public ApiProperty<int> LeadCampaignLastField => _leadCampaignLastField ??= new ApiProperty<int>(this, LeadCampaignLastKey);
    private ApiProperty<int>? _leadCampaignLastField;
    public const string LeadCampaignLastKey = "l_campaign";
    /// <summary>
    /// Gets or sets the last tracking campaign ID for the tracking URL the contact arrived from.
    /// </summary>
    public int? LeadCampaignLast { get => LeadCampaignLastField.Value; set => LeadCampaignLastField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the last term ID for the tracking URL the contact arrived from.
    /// </summary>
    public ApiProperty<int> LeadTermsLastField => _leadTermsLastField ??= new ApiProperty<int>(this, LeadTermsLastKey);
    private ApiProperty<int>? _leadTermsLastField;
    public const string LeadTermsLastKey = "l_term";
    /// <summary>
    /// Gets or sets the last term ID for the tracking URL the contact arrived from.
    /// </summary>
    public int? LeadTermsLast { get => LeadTermsLastField.Value; set => LeadTermsLastField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the page the contact was referred from.
    /// </summary>
    public ApiProperty<int> ReferralPageField => _referralPageField ??= new ApiProperty<int>(this, ReferralPageKey);
    private ApiProperty<int>? _referralPageField;
    public const string ReferralPageKey = "referral_page";
    /// <summary>
    /// Gets or sets the page the contact was referred from.
    /// </summary>
    public int? ReferralPage { get => ReferralPageField.Value; set => ReferralPageField.Value = value; }

    /// <summary>
    /// If the contact is an affiliate, returns a ApiProperty object to get or set the total number of affiliate sales.
    /// </summary>
    public ApiProperty<int> AffiliateSalesField => _affiliateSalesField ??= new ApiProperty<int>(this, AffiliateSalesKey);
    private ApiProperty<int>? _affiliateSalesField;
    public const string AffiliateSalesKey = "aff_sales";
    /// <summary>
    /// If the contact is an affiliate, gets or sets the total number of affiliate sales.
    /// </summary>
    public int? AffiliateSales { get => AffiliateSalesField.Value; set => AffiliateSalesField.Value = value; }

    /// <summary>
    /// If the contact is an affiliate, returns a ApiProperty object to get or set the total amount of affiliate sales.
    /// </summary>
    public ApiProperty<decimal> AffiliateAmountField => _affiliateAmountField ??= new ApiProperty<decimal>(this, AffiliateAmountKey);
    private ApiProperty<decimal>? _affiliateAmountField;
    public const string AffiliateAmountKey = "aff_amount";
    /// <summary>
    /// If the contact is an affiliate, gets or sets the total amount of affiliate sales.
    /// </summary>
    public decimal? AffiliateAmount { get => AffiliateAmountField.Value; set => AffiliateAmountField.Value = value; }

    /// <summary>
    /// For affiliates, returns a ApiProperty object to get or set the partner program ID.
    /// </summary>
    public ApiProperty<int> AffiliateProgramIdField => _affiliateProgramIdField ??= new ApiProperty<int>(this, AffiliateProgramKey);
    private ApiProperty<int>? _affiliateProgramIdField;
    public const string AffiliateProgramKey = "program_id";
    /// <summary>
    /// For affiliates, returns a ApiProperty object to get or set the partner program ID.
    /// </summary>
    public int? AffiliateProgramId { get => AffiliateProgramIdField.Value; set => AffiliateProgramIdField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the affiliate email address for Paypal payments.
    /// </summary>
    public ApiPropertyString AffiliatePayPalField => _affiliatePayPalField ??= new ApiPropertyString(this, AffiliatePayPalKey);
    private ApiPropertyString? _affiliatePayPalField;
    public const string AffiliatePayPalKey = "aff_paypal";
    /// <summary>
    /// Gets or sets the affiliate email address for Paypal payments.
    /// </summary>
    public string? AffiliatePayPal { get => AffiliatePayPalField.Value; set => AffiliatePayPalField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's gender as listed on Facebook.
    /// </summary>
    public ApiPropertyString FacebookGenderField => _facebookGenderField ??= new ApiPropertyString(this, FacebookGenderKey);
    private ApiPropertyString? _facebookGenderField;
    public const string FacebookGenderKey = "fb_gender";
    /// <summary>
    /// Gets or sets the contact's gender as listed on Facebook.
    /// </summary>
    public string? FacebookGender { get => FacebookGenderField.Value; set => FacebookGenderField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the amount of the contact's most recent credit card charge.
    /// </summary>
    public ApiProperty<decimal> LastTransactionAmountField => _lastTransactionAmountField ??= new ApiProperty<decimal>(this, LastTransactionAmountKey);
    private ApiProperty<decimal>? _lastTransactionAmountField;
    public const string LastTransactionAmountKey = "mrcAmount";
    /// <summary>
    /// Gets or sets the amount of the contact's most recent credit card charge.
    /// </summary>
    public decimal? LastTransactionAmount { get => LastTransactionAmountField.Value; set => LastTransactionAmountField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the total contact transactions remaining unpaid.
    /// </summary>
    public ApiProperty<decimal> LastTransactionUnpaidField => _lastTransactionUnpaidField ??= new ApiProperty<decimal>(this, LastTransactionUnpaidKey);
    private ApiProperty<decimal>? _lastTransactionUnpaidField;
    public const string LastTransactionUnpaidKey = "mrcUnpaid";
    /// <summary>
    /// Gets or sets the total contact transactions remaining unpaid.
    /// </summary>
    public decimal? LastTransactionUnpaid { get => LastTransactionUnpaidField.Value; set => LastTransactionUnpaidField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's most recent invoice number.
    /// </summary>
    public ApiProperty<int> LastInvoiceNumberField => _lastInvoiceNumberField ??= new ApiProperty<int>(this, LastInvoiceNumberKey);
    private ApiProperty<int>? _lastInvoiceNumberField;
    public const string LastInvoiceNumberKey = "mriInvoiceNum";
    /// <summary>
    /// Gets or sets the contact's most recent invoice number.
    /// </summary>
    public int? LastInvoiceNumber { get => LastInvoiceNumberField.Value; set => LastInvoiceNumberField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's most recent invoice total.
    /// </summary>
    public ApiProperty<decimal> LastInvoiceTotalField => _lastInvoiceTotalField ??= new ApiProperty<decimal>(this, LastInvoiceTotalKey);
    private ApiProperty<decimal>? _lastInvoiceTotalField;
    public const string LastInvoiceTotalKey = "mriInvoiceTotal";
    /// <summary>
    /// Gets or sets the contact's most recent invoice total.
    /// </summary>
    public decimal? LastInvoiceTotal { get => LastInvoiceTotalField.Value; set => LastInvoiceTotalField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's credit card type.
    /// </summary>
    public ApiProperty<CreditCardType> CreditCardTypeField => _creditCardTypeField ??= new ApiPropertyIntEnum<CreditCardType>(this, CreditCardTypeKey);
    private ApiProperty<CreditCardType>? _creditCardTypeField;
    public const string CreditCardTypeKey = "ccType";
    /// <summary>
    /// Gets or sets the contact's credit card type.
    /// </summary>
    public CreditCardType? CreditCardType { get => CreditCardTypeField.Value; set => CreditCardTypeField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the expiration month of the contact's credit card.
    /// </summary>
    public ApiProperty<int> CreditCardExpirationMonthField => _creditCardExpirationMonthField ??= new ApiProperty<int>(this, CreditCardExpirationMonthKey);
    private ApiProperty<int>? _creditCardExpirationMonthField;
    public const string CreditCardExpirationMonthKey = "ccExpirationMonth";
    /// <summary>
    /// Gets or sets the expiration month of the contact's credit card.
    /// </summary>
    public int? CreditCardExpirationMonth { get => CreditCardExpirationMonthField.Value; set => CreditCardExpirationMonthField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the year the contact's credit card expires.
    /// </summary>
    public ApiProperty<int> CreditCardExpirationYearField => _creditCardExpirationYearField ??= new ApiProperty<int>(this, CreditCardExpirationYearKey);
    private ApiProperty<int>? _creditCardExpirationYearField;
    public const string CreditCardExpirationYearKey = "ccExpirationYear";
    /// <summary>
    /// Gets or sets the year the contact's credit card expires.
    /// </summary>
    public int? CreditCardExpirationYear { get => CreditCardExpirationYearField.Value; set => CreditCardExpirationYearField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the day of the month that the contact's credit card expires.
    /// </summary>
    public ApiProperty<int> CreditCardExpirationDayField => _creditCardExpirationDayField ??= new ApiProperty<int>(this, CreditCardExpirationDayKey);
    private ApiProperty<int>? _creditCardExpirationDayField;
    public const string CreditCardExpirationDayKey = "ccExpirationDate";
    /// <summary>
    /// Gets or sets the day of the month that the contact's credit card expires.
    /// </summary>
    public int? CreditCardExpirationDay { get => CreditCardExpirationDayField.Value; set => CreditCardExpirationDayField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the last 4 digits of the contact's credit card number.
    /// </summary>
    public ApiPropertyString CreditCardNumberField => _creditCardNumberField ??= new ApiPropertyString(this, CreditCardNumberKey);
    private ApiPropertyString? _creditCardNumberField;
    public const string CreditCardNumberKey = "ccNumber";
    /// <summary>
    /// Gets or sets the last 4 digits of the contact's credit card number.
    /// </summary>
    public string? CreditCardNumber { get => CreditCardNumberField.Value; set => CreditCardNumberField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the result of the contact's most recent credit card charge.
    /// </summary>
    public ApiProperty<ContactTransactionResult> LastTransactionResultField => _lastTransactionResultField ??= new ApiPropertyIntEnum<ContactTransactionResult>(this, LastTransactionResultKey);
    private ApiProperty<ContactTransactionResult>? _lastTransactionResultField;
    public const string LastTransactionResultKey = "mrcResult";
    /// <summary>
    /// Gets or sets the result of the contact's most recent credit card charge.
    /// </summary>
    public ContactTransactionResult? LastTransactionResult { get => LastTransactionResultField.Value; set => LastTransactionResultField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the last text message the contact received from you.
    /// </summary>
    public ApiPropertyString LastInboundSmsField => _lastInboundSmsField ??= new ApiPropertyString(this, LastInboundSmsKey);
    private ApiPropertyString? _lastInboundSmsField;
    public const string LastInboundSmsKey = "last_inbound_sms";
    /// <summary>
    /// Gets or sets the last text message the contact received from you.
    /// </summary>
    public string? LastInboundSms { get => LastInboundSmsField.Value; set => LastInboundSmsField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's timezone.
    /// </summary>
    public ApiPropertyString TimezoneField => _timezoneField ??= new ApiPropertyString(this, TimezoneKey);
    private ApiPropertyString? _timezoneField;
    public const string TimezoneKey = "timezone";
    /// <summary>
    /// Gets or sets the contact's timezone.
    /// </summary>
    public string? Timezone { get => TimezoneField.Value; set => TimezoneField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the total amount the contact has spent with your company.
    /// </summary>
    public ApiProperty<decimal> SpentField => _spentField ??= new ApiProperty<decimal>(this, SpentKey);
    private ApiProperty<decimal>? _spentField;
    public const string SpentKey = "spent";
    /// <summary>
    /// Gets or sets the total amount the contact has spent with your company.
    /// </summary>
    public decimal? Spent { get => SpentField.Value; set => SpentField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's score based upon lead scoring rules.
    /// </summary>
    public ApiProperty<int> GradeField => _gradeField ??= new ApiProperty<int>(this, GradeKey);
    private ApiProperty<int>? _gradeField;
    public const string GradeKey = "grade";
    /// <summary>
    /// Gets or sets the contact's score based upon lead scoring rules.
    /// </summary>
    public int? Grade { get => GradeField.Value; set => GradeField.Value = value; }

    public ApiProperty<int> NMediaField => _nMediaField ??= new ApiProperty<int>(this, NMediaKey);
    private ApiProperty<int>? _nMediaField;
    public const string NMediaKey = "n_media";
    public int? NMedia { get => NMediaField.Value; set => NMediaField.Value = value; }

    /// <summary>
    /// The time since the contact's last activity. Only accounts after 2018 will have this field. This is a configurable enum.
    /// </summary>
    public ApiProperty<int> TimeSinceLastActivityField => _timeSinceLastActivityField ??= new ApiProperty<int>(this, TimeSinceLastActivityKey);
    private ApiProperty<int>? _timeSinceLastActivityField;
    public const string TimeSinceLastActivityKey = "time_since_dla";
    public int? TimeSinceLastActivity { get => TimeSinceLastActivityField.Value; set => TimeSinceLastActivityField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's Facebook profile link.
    /// </summary>
    public ApiPropertyString FacebookLinkField => _facebookLinkField ??= new ApiPropertyString(this, FacebookLinkKey);
    private ApiPropertyString? _facebookLinkField;
    public const string FacebookLinkKey = "facebook_link";
    /// <summary>
    /// Gets or sets the contact's Facebook profile link.
    /// </summary>
    public string? FacebookLink { get => FacebookLinkField.Value; set => FacebookLinkField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's Twitter profile link.
    /// </summary>
    public ApiPropertyString TwitterLinkField => _twitterLinkField ??= new ApiPropertyString(this, TwitterLinkKey);
    private ApiPropertyString? _twitterLinkField;
    public const string TwitterLinkKey = "twitter_link";
    /// <summary>
    /// Gets or sets the contact's Twitter profile link.
    /// </summary>
    public string? TwitterLink { get => TwitterLinkField.Value; set => TwitterLinkField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's Instagram profile link.
    /// </summary>
    public ApiPropertyString InstagramLinkField => _instagramLinkField ??= new ApiPropertyString(this, InstagramLinkKey);
    private ApiPropertyString? _instagramLinkField;
    public const string InstagramLinkKey = "instagram_link";
    /// <summary>
    /// Gets or sets the contact's Instagram profile link.
    /// </summary>
    public string? InstagramLink { get => InstagramLinkField.Value; set => InstagramLinkField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's LinkedIn profile link.
    /// </summary>
    public ApiPropertyString LinkedInLinkField => _linkedInLinkField ??= new ApiPropertyString(this, LinkedInLinkKey);
    private ApiPropertyString? _linkedInLinkField;
    public const string LinkedInLinkKey = "linkedin_link";
    /// <summary>
    /// Gets or sets the contact's LinkedIn profile link.
    /// </summary>
    public string? LinkedInLink { get => LinkedInLinkField.Value; set => LinkedInLinkField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's profile image link.
    /// </summary>
    public ApiPropertyString ProfileImageField => _profileImageField ??= new ApiPropertyString(this, ProfileImageKey);
    private ApiPropertyString? _profileImageField;
    public const string ProfileImageKey = "profile_image";
    /// <summary>
    /// Gets or sets the contact's profile image link.
    /// </summary>
    public string? ProfileImage { get => ProfileImageField.Value; set => ProfileImageField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact has unpaid invoices.
    /// </summary>
    public ApiPropertyBool UnpaidInvoicesField => _unpaidInvoicesField ??= new ApiPropertyBool(this, UnpaidInvoicesKey);
    private ApiPropertyBool? _unpaidInvoicesField;
    public const string UnpaidInvoicesKey = "unpaid_invoices";
    /// <summary>
    /// Gets or sets whether the contact has unpaid invoices.
    /// </summary>
    public bool? UnpaidInvoices { get => UnpaidInvoicesField.Value; set => UnpaidInvoicesField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact has unpaid invoices.
    /// </summary>
    public ApiPropertyBool HasMembershipField => _hasMembershipField ??= new ApiPropertyBool(this, HasMembershipKey);
    private ApiPropertyBool? _hasMembershipField;
    public const string HasMembershipKey = "has_membership";
    /// <summary>
    /// Gets or sets whether the contact has unpaid invoices.
    /// </summary>
    public bool? HasMembership { get => HasMembershipField.Value; set => HasMembershipField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the contact's email hash.
    /// </summary>
    public ApiPropertyString EmailHashField => _emailHashField ??= new ApiPropertyString(this, EmailHashKey);
    private ApiPropertyString? _emailHashField;
    public const string EmailHashKey = "emailHash";
    /// <summary>
    /// Gets or sets the contact's email hash.
    /// </summary>
    public string? EmailHash { get => EmailHashField.Value; set => EmailHashField.Value = value; }



    /// <summary>
    /// The contact's priority.
    /// </summary>
    public enum ContactPriority
    {
        None = 0,
        High = 8,
        Medium = 9,
        Low = 10
    }

    /// <summary>
    /// The result of a credit card charge.
    /// </summary>
    public enum ContactTransactionResult
    {
        Success = 0,
        Declined = 1
    }
}
