using System;
using EmergenceGuardian.OntraportApi.Converters;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// Credit cards objects store data for a contact's saved credit cards, including card information, type, status, and billing details.
    /// </summary>
    public class ApiCreditCard : ApiObject
    {
        /// <summary>
        /// Returns a ApiProperty object to get or set the first name of the credit card owner.
        /// </summary>
        public ApiPropertyString FirstName => _firstName ?? (_firstName = new ApiPropertyString(this, "firstname"));
        private ApiPropertyString _firstName;
        /// <summary>
        /// Gets or sets the first name of the credit card owner.
        /// </summary>
        public string FirstNameValue { get => FirstName.Value; set => FirstName.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the last name of the credit card owner.
        /// </summary>
        public ApiPropertyString Lastname => _lastname ?? (_lastname = new ApiPropertyString(this, "lastname"));
        private ApiPropertyString _lastname;
        /// <summary>
        /// Gets or sets the last name of the credit card owner.
        /// </summary>
        public string LastnameValue { get => Lastname.Value; set => Lastname.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the contact associated with the credit card.
        /// </summary>
        public ApiPropertyInt ContactId => _contactId ?? (_contactId = new ApiPropertyInt(this, "contact_id"));
        private ApiPropertyInt _contactId;
        /// <summary>
        /// Gets or sets the ID of the contact associated with the credit card.
        /// </summary>
        public int ContactIdValue { get => ContactId.Value; set => ContactId.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the last four digits of the credit card number.
        /// </summary>
        public ApiPropertyInt LastFourDigits => _last4 ?? (_last4 = new ApiPropertyInt(this, "last4"));
        private ApiPropertyInt _last4;
        /// <summary>
        /// Gets or sets the last four digits of the credit card number.
        /// </summary>
        public int LastFourDigitsValue { get => LastFourDigits.Value; set => LastFourDigits.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the credit card issuer.
        /// </summary>
        public ApiProperty<CreditCardType> Type => _type ?? (_type = new ApiPropertyIntEnum<CreditCardType>(this, "type"));
        private ApiProperty<CreditCardType> _type;
        /// <summary>
        /// Gets or sets the credit card issuer.
        /// </summary>
        public CreditCardType TypeValue { get => Type.Value; set => Type.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the two-digit integer representation of the credit card's expiration month.
        /// </summary>
        public ApiPropertyInt ExpirationMonth => _expirationMonth ?? (_expirationMonth = new ApiPropertyInt(this, "exp_month"));
        private ApiPropertyInt _expirationMonth;
        /// <summary>
        /// Gets or sets the two-digit integer representation of the credit card's expiration month.
        /// </summary>
        public int ExpirationMonthValue { get => ExpirationMonth.Value; set => ExpirationMonth.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the four-digit credit card expiration year.
        /// </summary>
        public ApiPropertyInt ExpirationYear => _expirationYear ?? (_expirationYear = new ApiPropertyInt(this, "exp_year"));
        private ApiPropertyInt _expirationYear;
        /// <summary>
        /// Gets or sets the four-digit credit card expiration year.
        /// </summary>
        public int ExpirationYearValue { get => ExpirationYear.Value; set => ExpirationYear.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the credit card's billing address.
        /// </summary>
        public ApiPropertyString Address => _address ?? (_address = new ApiPropertyString(this, "address"));
        private ApiPropertyString _address;
        /// <summary>
        /// Gets or sets the credit card's billing address.
        /// </summary>
        public string AddressValue { get => Address.Value; set => Address.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set additional information about the credit card's billing address, such as unit number.
        /// </summary>
        public ApiPropertyString Address2 => _address2 ?? (_address2 = new ApiPropertyString(this, "address2"));
        private ApiPropertyString _address2;
        /// <summary>
        /// Gets or sets additional information about the credit card's billing address, such as unit number.
        /// </summary>
        public string Address2Value { get => Address2.Value; set => Address2.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the credit card's billing address city.
        /// </summary>
        public ApiPropertyString City => _city ?? (_city = new ApiPropertyString(this, "city"));
        private ApiPropertyString _city;
        /// <summary>
        /// Gets or sets the credit card's billing address city.
        /// </summary>
        public string CityValue { get => City.Value; set => City.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the credit card's billing address state.
        /// </summary>
        public ApiPropertyString State => _state ?? (_state = new ApiPropertyString(this, "state"));
        private ApiPropertyString _state;
        /// <summary>
        /// Gets or sets the credit card's billing address state.
        /// </summary>
        public string StateValue { get => State.Value; set => State.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the credit card's billing address zip code.
        /// </summary>
        public ApiPropertyString Zip => _zip ?? (_zip = new ApiPropertyString(this, "zip"));
        private ApiPropertyString _zip;
        /// <summary>
        /// Gets or sets the credit card's billing address zip code.
        /// </summary>
        public string ZipValue { get => Zip.Value; set => Zip.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the credit card's billing address country.
        /// </summary>
        public ApiPropertyString Country => _country ?? (_country = new ApiPropertyString(this, "country"));
        private ApiPropertyString _country;
        /// <summary>
        /// Gets or sets the credit card's billing address country.
        /// </summary>
        public string CountryValue { get => Country.Value; set => Country.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the current status of the credit card.
        /// </summary>
        public ApiProperty<CreditCardStatus> Status => _status ?? (_status = new ApiPropertyIntEnum<CreditCardStatus>(this, "status"));
        private ApiProperty<CreditCardStatus> _status;
        /// <summary>
        /// Gets or sets the current status of the credit card.
        /// </summary>
        public CreditCardStatus StatusValue { get => Status.Value; set => Status.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date and time of the most recent charge.
        /// </summary>
        public ApiPropertyDateTime LastTransactionDate => _lastTransactionDate ?? (_lastTransactionDate = new ApiPropertyDateTime(this, "recent_sale"));
        private ApiPropertyDateTime _lastTransactionDate;
        /// <summary>
        /// Gets or sets the date and time of the most recent charge.
        /// </summary>
        public DateTimeOffset LastTransactionDateValue { get => LastTransactionDate.Value; set => LastTransactionDate.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the invoice generated in relation to the most recent charge to the credit card.
        /// </summary>
        public ApiPropertyInt LastInvoiceId => _lastInvoiceId ?? (_lastInvoiceId = new ApiPropertyInt(this, "invoice_id"));
        private ApiPropertyInt _lastInvoiceId;
        /// <summary>
        /// Gets or sets the ID of the invoice generated in relation to the most recent charge to the credit card.
        /// </summary>
        public int LastInvoiceIdValue { get => LastInvoiceId.Value; set => LastInvoiceId.Value = value; }



        /// <summary>
        /// The status of the credit card.
        /// </summary>
        public enum CreditCardStatus
        {
            Active = 1,
            Expired = 1,
            ActiveDefault = 3,
            ExpiredDefault = 4
        }
    }
}
