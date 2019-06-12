using System;
using EmergenceGuardian.OntraportApi.Converters;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// Contact objects allow you to keep up-to-date records for all the contacts you are managing.
    /// </summary>
    public class ApiContact : ApiCustomObjectBase
    {
        /// <summary>
        /// Returns a ApiProperty object to get or set the contact's first name.
        /// </summary>
        public ApiPropertyString FirstName => _firstName ?? (_firstName = new ApiPropertyString(this, "firstname"));
        private ApiPropertyString _firstName;
        /// <summary>
        /// Gets or sets the contact's first name.
        /// </summary>
        public string FirstNameValue { get => FirstName.Value; set => FirstName.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the contact's last name.
        /// </summary>
        public ApiPropertyString LastName => _lastName ?? (_lastName = new ApiPropertyString(this, "lastname"));
        private ApiPropertyString _lastName;
        /// <summary>
        /// Gets or sets the contact's last name.
        /// </summary>
        public string LastNameValue { get => LastName.Value; set => LastName.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the contact's email address.
        /// </summary>
        public ApiPropertyString Email => _email ?? (_email = new ApiPropertyString(this, "email"));
        private ApiPropertyString _email;
        /// <summary>
        /// Gets or sets the contact's email address.
        /// </summary>
        public string EmailValue { get => Email.Value; set => Email.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the affiliate ID of the first affiliate to refer the contact.
        /// </summary>
        public ApiProperty<int> FirstReferrer => _firstReferrer ?? (_firstReferrer = new ApiProperty<int>(this, "freferrer"));
        private ApiProperty<int> _firstReferrer;
        /// <summary>
        /// Gets or sets the affiliate ID of the first affiliate to refer the contact.
        /// </summary>
        public int FirstReferrerValue { get => FirstReferrer.Value; set => FirstReferrer.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the affiliate ID of the last affiliate to refer the contact.
        /// </summary>
        public ApiProperty<int> LastReferrer => _lastReferrer ?? (_lastReferrer = new ApiProperty<int>(this, "lreferrer"));
        private ApiProperty<int> _lastReferrer;
        /// <summary>
        /// Gets or sets the affiliate ID of the last affiliate to refer the contact.
        /// </summary>
        public int LastReferrerValue { get => LastReferrer.Value; set => LastReferrer.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the contact's postal address.
        /// </summary>
        public ApiPropertyString Address => _address ?? (_address = new ApiPropertyString(this, "address"));
        private ApiPropertyString _address;
        /// <summary>
        /// Gets or sets the contact's postal address.
        /// </summary>
        public string AddressValue { get => Address.Value; set => Address.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set a second address field which is generally used for storing suite or unit numbers.
        /// </summary>
        public ApiPropertyString Address2 => _address2 ?? (_address2 = new ApiPropertyString(this, "address2"));
        private ApiPropertyString _address2;
        /// <summary>
        /// Gets or sets a second address field which is generally used for storing suite or unit numbers.
        /// </summary>
        public string Address2Value { get => Address2.Value; set => Address2.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the contact's city.
        /// </summary>
        public ApiPropertyString City => _city ?? (_city = new ApiPropertyString(this, "city"));
        private ApiPropertyString _city;
        /// <summary>
        /// Gets or sets the contact's city.
        /// </summary>
        public string CityValue { get => City.Value; set => City.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the contact's state.
        /// </summary>
        public ApiPropertyString State => _state ?? (_state = new ApiPropertyString(this, "state"));
        private ApiPropertyString _state;
        /// <summary>
        /// Gets or sets the contact's state.
        /// </summary>
        public string StateValue { get => State.Value; set => State.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the contact's postal code.
        /// </summary>
        public ApiPropertyString Zip => _zip ?? (_zip = new ApiPropertyString(this, "zip"));
        private ApiPropertyString _zip;
        /// <summary>
        /// Gets or sets the contact's postal code.
        /// </summary>
        public string ZipValue { get => Zip.Value; set => Zip.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the contact's country.
        /// </summary>
        public ApiPropertyString Country => _country ?? (_country = new ApiPropertyString(this, "country"));
        private ApiPropertyString _country;
        /// <summary>
        /// Gets or sets the contact's country.
        /// </summary>
        public string CountryValue { get => Country.Value; set => Country.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the contact's birthday.
        /// </summary>
        public ApiPropertyDateTime Birthday => _birthday ?? (_birthday = new ApiPropertyDateTime(this, "birthday"));
        private ApiPropertyDateTime _birthday;
        /// <summary>
        /// Gets or sets the contact's birthday.
        /// </summary>
        public DateTimeOffset BirthdayValue { get => Birthday.Value; set => Birthday.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the contact's priority.
        /// </summary>
        public ApiPropertyIntEnum<ContactPriority> Priority => _priority ?? (_priority = new ApiPropertyIntEnum<ContactPriority>(this, "priority"));
        private ApiPropertyIntEnum<ContactPriority> _priority;
        /// <summary>
        /// Gets or sets the contact's priority.
        /// </summary>
        public ContactPriority PriorityValue { get => Priority.Value; set => Priority.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the contact's Sales Stage.
        /// </summary>
        public ApiPropertyIntEnum<SaleStatus> Status => _status ?? (_status = new ApiPropertyIntEnum<SaleStatus>(this, "status"));
        private ApiPropertyIntEnum<SaleStatus> _status;
        /// <summary>
        /// Gets or sets the contact's Sales Stage.
        /// </summary>
        public SaleStatus StatusValue { get => Status.Value; set => Status.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the contact's home phone number.
        /// </summary>
        public ApiPropertyString HomePhone => _homePhone ?? (_homePhone = new ApiPropertyString(this, "home_phone"));
        private ApiPropertyString _homePhone;
        /// <summary>
        /// Gets or sets the contact's home phone number.
        /// </summary>
        public string HomePhoneValue { get => HomePhone.Value; set => HomePhone.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the mobile number where the contact prefers receive text messages.
        /// </summary>
        public ApiPropertyString SmsNumber => _smsNumber ?? (_smsNumber = new ApiPropertyString(this, "sms_number"));
        private ApiPropertyString _smsNumber;
        /// <summary>
        /// Gets or sets the mobile number where the contact prefers receive text messages.
        /// </summary>
        public string SmsNumberValue { get => SmsNumber.Value; set => SmsNumber.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the contact's office phone number.
        /// </summary>
        public ApiPropertyString OfficePhone => _officePhone ?? (_officePhone = new ApiPropertyString(this, "office_phone"));
        private ApiPropertyString _officePhone;
        /// <summary>
        /// Gets or sets the contact's office phone number.
        /// </summary>
        public string OfficePhoneValue { get => OfficePhone.Value; set => OfficePhone.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the contact's fax number.
        /// </summary>
        public ApiPropertyString Fax => _fax ?? (_fax = new ApiPropertyString(this, "fax"));
        private ApiPropertyString _fax;
        /// <summary>
        /// Gets or sets the contact's fax number.
        /// </summary>
        public string FaxValue { get => Fax.Value; set => Fax.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the company the contact is affiliated with.
        /// </summary>
        public ApiPropertyString Company => _company ?? (_company = new ApiPropertyString(this, "company"));
        private ApiPropertyString _company;
        /// <summary>
        /// Gets or sets the company the contact is affiliated with.
        /// </summary>
        public string CompanyValue { get => _company.Value; set => Company.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the contact's job title.
        /// </summary>
        public ApiPropertyString Title => _title ?? (_title = new ApiPropertyString(this, "title"));
        private ApiPropertyString _title;
        /// <summary>
        /// Gets or sets the contact's job title.
        /// </summary>
        public string TitleValue { get => Title.Value; set => Title.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the contact's website.
        /// </summary>
        public ApiPropertyString Website => _website ?? (_website = new ApiPropertyString(this, "website"));
        private ApiPropertyString _website;
        /// <summary>
        /// Gets or sets the contact's website.
        /// </summary>
        public string WebsiteValue { get => Website.Value; set => Website.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the lead source ID for the tracking URL the contact arrived from.
        /// </summary>
        public ApiProperty<int> LeadSourceFirst => _leadSourceFirst ?? (_leadSourceFirst = new ApiProperty<int>(this, "n_lead_source"));
        private ApiProperty<int> _leadSourceFirst;
        /// <summary>
        /// Gets or sets the lead source ID for the tracking URL the contact arrived from.
        /// </summary>
        public int LeadSourceFirstValue { get => LeadSourceFirst.Value; set => LeadSourceFirst.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the content ID for the tracking URL the contact arrived from.
        /// </summary>
        public ApiProperty<int> LeadContentFirst => _leadContentFirst ?? (_leadContentFirst = new ApiProperty<int>(this, "n_content"));
        private ApiProperty<int> _leadContentFirst;
        /// <summary>
        /// Gets or sets the content ID for the tracking URL the contact arrived from.
        /// </summary>
        public int LeadContentFirstValue { get => LeadContentFirst.Value; set => LeadContentFirst.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the medium ID for the tracking URL the contact arrived from.
        /// </summary>
        public ApiProperty<int> LeadMediumFirst => _leadMediumFirst ?? (_leadMediumFirst = new ApiProperty<int>(this, "n_medium"));
        private ApiProperty<int> _leadMediumFirst;
        /// <summary>
        /// Gets or sets the medium ID for the tracking URL the contact arrived from.
        /// </summary>
        public int LeadMediumFirstValue { get => LeadMediumFirst.Value; set => LeadMediumFirst.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the tracking campaign ID for the tracking URL the contact arrived from.
        /// </summary>
        public ApiProperty<int> LeadCampaignFirst => _leadCampaignFirst ?? (_leadCampaignFirst = new ApiProperty<int>(this, "n_campaign"));
        private ApiProperty<int> _leadCampaignFirst;
        /// <summary>
        /// Gets or sets the tracking campaign ID for the tracking URL the contact arrived from.
        /// </summary>
        public int LeadCampaignFirstValue { get => LeadCampaignFirst.Value; set => LeadCampaignFirst.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the term ID for the tracking URL the contact arrived from.
        /// </summary>
        public ApiProperty<int> LeadTermsFirst => _leadTermsFirst ?? (_leadTermsFirst = new ApiProperty<int>(this, "n_term"));
        private ApiProperty<int> _leadTermsFirst;
        /// <summary>
        /// Gets or sets the term ID for the tracking URL the contact arrived from.
        /// </summary>
        public int LeadTermsFirstValue { get => LeadTermsFirst.Value; set => LeadTermsFirst.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the last lead source ID for the tracking URL the contact arrived from.
        /// </summary>
        public ApiProperty<int> LeadSourceLast => _leadSourceLast ?? (_leadSourceLast = new ApiProperty<int>(this, "l_lead_source"));
        private ApiProperty<int> _leadSourceLast;
        /// <summary>
        /// Gets or sets the last lead source ID for the tracking URL the contact arrived from.
        /// </summary>
        public int LeadSourceLastValue { get => LeadSourceLast.Value; set => LeadSourceLast.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the last content ID for the tracking URL the contact arrived from.
        /// </summary>
        public ApiProperty<int> LeadContentLast => _leadContentLast ?? (_leadContentLast = new ApiProperty<int>(this, "l_content"));
        private ApiProperty<int> _leadContentLast;
        /// <summary>
        /// Gets or sets the last content ID for the tracking URL the contact arrived from.
        /// </summary>
        public int LeadContentLastValue { get => LeadContentLast.Value; set => LeadContentLast.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the last medium ID for the tracking URL the contact arrived from.
        /// </summary>
        public ApiProperty<int> LeadMediumLast => _leadMediumLast ?? (_leadMediumLast = new ApiProperty<int>(this, "l_medium"));
        private ApiProperty<int> _leadMediumLast;
        /// <summary>
        /// Gets or sets the last medium ID for the tracking URL the contact arrived from.
        /// </summary>
        public int LeadMediumLastValue { get => LeadMediumLast.Value; set => LeadMediumLast.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the last tracking campaign ID for the tracking URL the contact arrived from.
        /// </summary>
        public ApiProperty<int> LeadCampaignLast => _leadCampaignLast ?? (_leadCampaignLast = new ApiProperty<int>(this, "l_campaign"));
        private ApiProperty<int> _leadCampaignLast;
        /// <summary>
        /// Gets or sets the last tracking campaign ID for the tracking URL the contact arrived from.
        /// </summary>
        public int LeadCampaignLastValue { get => LeadCampaignLast.Value; set => LeadCampaignLast.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the last term ID for the tracking URL the contact arrived from.
        /// </summary>
        public ApiProperty<int> LeadTermsLast => _leadTermsLast ?? (_leadTermsLast = new ApiProperty<int>(this, "l_term"));
        private ApiProperty<int> _leadTermsLast;
        /// <summary>
        /// Gets or sets the last term ID for the tracking URL the contact arrived from.
        /// </summary>
        public int LeadTermsLastValue { get => LeadTermsLast.Value; set => LeadTermsLast.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the page the contact was referred from.
        /// </summary>
        public ApiProperty<int> ReferralPage => _referralPage ?? (_referralPage = new ApiProperty<int>(this, "referral_page"));
        private ApiProperty<int> _referralPage;
        /// <summary>
        /// Gets or sets the page the contact was referred from.
        /// </summary>
        public int ReferralPageValue { get => ReferralPage.Value; set => ReferralPage.Value = value; }

        /// <summary>
        /// If the contact is an affiliate, returns a ApiProperty object to get or set the total number of affiliate sales.
        /// </summary>
        public ApiProperty<int> AffiliateSales => _affiliateSales ?? (_affiliateSales = new ApiProperty<int>(this, "aff_sales"));
        private ApiProperty<int> _affiliateSales;
        /// <summary>
        /// If the contact is an affiliate, gets or sets the total number of affiliate sales.
        /// </summary>
        public int AffiliateSalesValue { get => AffiliateSales.Value; set => AffiliateSales.Value = value; }

        /// <summary>
        /// If the contact is an affiliate, returns a ApiProperty object to get or set the total amount of affiliate sales.
        /// </summary>
        public ApiProperty<decimal> AffiliateAmount => _affiliateAmount ?? (_affiliateAmount = new ApiProperty<decimal>(this, "aff_amount"));
        private ApiProperty<decimal> _affiliateAmount;
        /// <summary>
        /// If the contact is an affiliate, gets or sets the total amount of affiliate sales.
        /// </summary>
        public decimal AffiliateAmountValue { get => AffiliateAmount.Value; set => AffiliateAmount.Value = value; }

        /// <summary>
        /// For affiliates, returns a ApiProperty object to get or set the partner program ID.
        /// </summary>
        public ApiProperty<int> AffiliateProgramId => _affiliateProgramId ?? (_affiliateProgramId = new ApiProperty<int>(this, "program_id"));
        private ApiProperty<int> _affiliateProgramId;
        /// <summary>
        /// For affiliates, returns a ApiProperty object to get or set the partner program ID.
        /// </summary>
        public int AffiliateProgramIdValue { get => AffiliateProgramId.Value; set => AffiliateProgramId.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the affiliate email address for Paypal payments.
        /// </summary>
        public ApiPropertyString AffiliatePayPal => _affiliatePayPal ?? (_affiliatePayPal = new ApiPropertyString(this, "aff_paypal"));
        private ApiPropertyString _affiliatePayPal;
        /// <summary>
        /// Gets or sets the affiliate email address for Paypal payments.
        /// </summary>
        public string AffiliatePayPalValue { get => AffiliatePayPal.Value; set => AffiliatePayPal.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the contact's gender as listed on Facebook.
        /// </summary>
        public ApiPropertyString FacebookGender => _facebookGender ?? (_facebookGender = new ApiPropertyString(this, "fb_gender"));
        private ApiPropertyString _facebookGender;
        /// <summary>
        /// Gets or sets the contact's gender as listed on Facebook.
        /// </summary>
        public string FacebookGenderValue { get => FacebookGender.Value; set => FacebookGender.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the amount of the contact's most recent credit card charge.
        /// </summary>
        public ApiProperty<decimal> LastTransactionAmount => _lastTransactionAmount ?? (_lastTransactionAmount = new ApiProperty<decimal>(this, "mrcAmount"));
        private ApiProperty<decimal> _lastTransactionAmount;
        /// <summary>
        /// Gets or sets the amount of the contact's most recent credit card charge.
        /// </summary>
        public decimal LastTransactionAmountValue { get => LastTransactionAmount.Value; set => LastTransactionAmount.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the total contact transactions remaining unpaid.
        /// </summary>
        public ApiProperty<decimal> LastTransactionUnpaid => _lastTransactionUnpaid ?? (_lastTransactionUnpaid = new ApiProperty<decimal>(this, "mrcUnpaid"));
        private ApiProperty<decimal> _lastTransactionUnpaid;
        /// <summary>
        /// Gets or sets the total contact transactions remaining unpaid.
        /// </summary>
        public decimal LastTransactionUnpaidValue { get => LastTransactionUnpaid.Value; set => LastTransactionUnpaid.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the contact's most recent invoice number.
        /// </summary>
        public ApiProperty<int> LastInvoiceNumber => _lastInvoiceNumber ?? (_lastInvoiceNumber = new ApiProperty<int>(this, "mriInvoiceNum"));
        private ApiProperty<int> _lastInvoiceNumber;
        /// <summary>
        /// Gets or sets the contact's most recent invoice number.
        /// </summary>
        public int LastInvoiceNumberValue { get => LastInvoiceNumber.Value; set => LastInvoiceNumber.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the contact's most recent invoice total.
        /// </summary>
        public ApiProperty<decimal> LastInvoiceTotal => _lastInvoiceTotal ?? (_lastInvoiceTotal = new ApiProperty<decimal>(this, "mriInvoiceTotal"));
        private ApiProperty<decimal> _lastInvoiceTotal;
        /// <summary>
        /// Gets or sets the contact's most recent invoice total.
        /// </summary>
        public decimal LastInvoiceTotalValue { get => LastInvoiceTotal.Value; set => LastInvoiceTotal.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the contact's credit card type.
        /// </summary>
        public ApiProperty<CreditCardType> CreditCardType => _creditCardType ?? (_creditCardType = new ApiPropertyIntEnum<CreditCardType>(this, "ccType"));
        private ApiProperty<CreditCardType> _creditCardType;
        /// <summary>
        /// Gets or sets the contact's credit card type.
        /// </summary>
        public CreditCardType CreditCardTypeValue { get => CreditCardType.Value; set => CreditCardType.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the expiration month of the contact's credit card.
        /// </summary>
        public ApiProperty<int> CreditCardExpirationMonth => _creditCardExpirationMonth ?? (_creditCardExpirationMonth = new ApiProperty<int>(this, "ccExpirationMonth"));
        private ApiProperty<int> _creditCardExpirationMonth;
        /// <summary>
        /// Gets or sets the expiration month of the contact's credit card.
        /// </summary>
        public int CreditCardExpirationMonthValue { get => CreditCardExpirationMonth.Value; set => CreditCardExpirationMonth.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the year the contact's credit card expires.
        /// </summary>
        public ApiProperty<int> CreditCardExpirationYear => _creditCardExpirationYear ?? (_creditCardExpirationYear = new ApiProperty<int>(this, "ccExpirationYear"));
        private ApiProperty<int> _creditCardExpirationYear;
        /// <summary>
        /// Gets or sets the year the contact's credit card expires.
        /// </summary>
        public int CreditCardExpirationYearValue { get => CreditCardExpirationYear.Value; set => CreditCardExpirationYear.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the day of the month that the contact's credit card expires.
        /// </summary>
        public ApiProperty<int> CreditCardExpirationDay => _creditCardExpirationDay ?? (_creditCardExpirationDay = new ApiProperty<int>(this, "ccExpirationDate"));
        private ApiProperty<int> _creditCardExpirationDay;
        /// <summary>
        /// Gets or sets the day of the month that the contact's credit card expires.
        /// </summary>
        public int CreditCardExpirationDayValue { get => CreditCardExpirationDay.Value; set => CreditCardExpirationDay.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the last 4 digits of the contact's credit card number.
        /// </summary>
        public ApiPropertyString CreditCardNumber => _creditCardNumber ?? (_creditCardNumber = new ApiPropertyString(this, "ccNumber"));
        private ApiPropertyString _creditCardNumber;
        /// <summary>
        /// Gets or sets the last 4 digits of the contact's credit card number.
        /// </summary>
        public string CreditCardNumberValue { get => CreditCardNumber.Value; set => CreditCardNumber.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the result of the contact's most recent credit card charge.
        /// </summary>
        public ApiProperty<ContactTransactionResult> LastTransactionResult => _lastTransactionResult ?? (_lastTransactionResult = new ApiPropertyIntEnum<ContactTransactionResult>(this, "mrcResult"));
        private ApiProperty<ContactTransactionResult> _lastTransactionResult;
        /// <summary>
        /// Gets or sets the result of the contact's most recent credit card charge.
        /// </summary>
        public ContactTransactionResult LastTransactionResultValue { get => LastTransactionResult.Value; set => LastTransactionResult.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the last text message the contact received from you.
        /// </summary>
        public ApiPropertyString LastInboundSms => _lastInboundSms ?? (_lastInboundSms = new ApiPropertyString(this, "last_inbound_sms"));
        private ApiPropertyString _lastInboundSms;
        /// <summary>
        /// Gets or sets the last text message the contact received from you.
        /// </summary>
        public string LastInboundSmsValue { get => LastInboundSms.Value; set => LastInboundSms.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the contact's timezone.
        /// </summary>
        public ApiPropertyString Timezone => _timezone ?? (_timezone = new ApiPropertyString(this, "timezone"));
        private ApiPropertyString _timezone;
        /// <summary>
        /// Gets or sets the contact's timezone.
        /// </summary>
        public string TimezoneValue { get => Timezone.Value; set => Timezone.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the total amount the contact has spent with your company.
        /// </summary>
        public ApiProperty<decimal> Spent => _spent ?? (_spent = new ApiProperty<decimal>(this, "spent"));
        private ApiProperty<decimal> _spent;
        /// <summary>
        /// Gets or sets the total amount the contact has spent with your company.
        /// </summary>
        public decimal SpentValue { get => Spent.Value; set => Spent.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the contact's total orders.
        /// </summary>
        public ApiProperty<int> NumPurchased => _numPurchased ?? (_numPurchased = new ApiProperty<int>(this, "num_purchased"));
        private ApiProperty<int> _numPurchased;
        /// <summary>
        /// Gets or sets the contact's total orders.
        /// </summary>
        public int NumPurchasedValue { get => NumPurchased.Value; set => NumPurchased.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the contact's score based upon lead scoring rules.
        /// </summary>
        public ApiProperty<int> Grade => _grade ?? (_grade = new ApiProperty<int>(this, "grade"));
        private ApiProperty<int> _grade;
        /// <summary>
        /// Gets or sets the contact's score based upon lead scoring rules.
        /// </summary>
        public int GradeValue { get => Grade.Value; set => Grade.Value = value; }

        public ApiProperty<int> NMedia => _nMedia ?? (_nMedia = new ApiProperty<int>(this, "n_media"));
        private ApiProperty<int> _nMedia;
        public int NMediaValue { get => NMedia.Value; set => NMedia.Value = value; }

        public ApiProperty<int> TimeSinceLastActivityDate => _timeSinceLastActivityDate ?? (_timeSinceLastActivityDate = new ApiProperty<int>(this, "time_since_dla"));
        private ApiProperty<int> _timeSinceLastActivityDate;
        public int TimeSinceLastActivityDateValue { get => TimeSinceLastActivityDate.Value; set => TimeSinceLastActivityDate.Value = value; }




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

        public enum ContactTransactionResult
        {
            Success = 0,
            Declined = 1
        }
    }
}
