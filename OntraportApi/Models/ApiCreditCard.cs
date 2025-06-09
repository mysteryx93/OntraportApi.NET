namespace HanumanInstitute.OntraportApi.Models;

/// <summary>
/// Credit cards objects store data for a contact's saved credit cards, including card information, type, status, and billing details.
/// </summary>
public class ApiCreditCard : ApiObject
{
    /// <summary>
    /// Returns a ApiProperty object to get or set the first name of the credit card owner.
    /// </summary>
    public ApiPropertyString FirstNameField => _firstNameField ??= new ApiPropertyString(this, FirstNameKey);
    private ApiPropertyString? _firstNameField;
    public const string FirstNameKey = "firstname";
    /// <summary>
    /// Gets or sets the first name of the credit card owner.
    /// </summary>
    public string? FirstName { get => FirstNameField.Value; set => FirstNameField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the last name of the credit card owner.
    /// </summary>
    public ApiPropertyString LastnameField => _lastnameField ??= new ApiPropertyString(this, LastNameKey);
    private ApiPropertyString? _lastnameField;
    public const string LastNameKey = "lastname";
    /// <summary>
    /// Gets or sets the last name of the credit card owner.
    /// </summary>
    public string? Lastname { get => LastnameField.Value; set => LastnameField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the contact associated with the credit card.
    /// </summary>
    public ApiProperty<long> ContactIdField => _contactIdField ??= new ApiProperty<long>(this, ContactIdKey);
    private ApiProperty<long>? _contactIdField;
    public const string ContactIdKey = "contact_id";
    /// <summary>
    /// Gets or sets the ID of the contact associated with the credit card.
    /// </summary>
    public long? ContactId { get => ContactIdField.Value; set => ContactIdField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the last four digits of the credit card number.
    /// </summary>
    public ApiProperty<int> LastFourDigitsField => _lastFourDigitsField ??= new ApiProperty<int>(this, LastFourDigitsKey);
    private ApiProperty<int>? _lastFourDigitsField;
    public const string LastFourDigitsKey = "last4";
    /// <summary>
    /// Gets or sets the last four digits of the credit card number.
    /// </summary>
    public int? LastFourDigits { get => LastFourDigitsField.Value; set => LastFourDigitsField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the credit card issuer.
    /// </summary>
    public ApiProperty<CreditCardType> TypeField => _typeField ??= new ApiPropertyIntEnum<CreditCardType>(this, TypeKey);
    private ApiProperty<CreditCardType>? _typeField;
    public const string TypeKey = "type";
    /// <summary>
    /// Gets or sets the credit card issuer.
    /// </summary>
    public CreditCardType? Type { get => TypeField.Value; set => TypeField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the two-digit integer representation of the credit card's expiration month.
    /// </summary>
    public ApiProperty<int> ExpirationMonthField => _expirationMonthField ??= new ApiProperty<int>(this, ExpirationMonthKey);
    private ApiProperty<int>? _expirationMonthField;
    public const string ExpirationMonthKey = "exp_month";
    /// <summary>
    /// Gets or sets the two-digit integer representation of the credit card's expiration month.
    /// </summary>
    public int? ExpirationMonth { get => ExpirationMonthField.Value; set => ExpirationMonthField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the four-digit credit card expiration year.
    /// </summary>
    public ApiProperty<int> ExpirationYearField => _expirationYearField ??= new ApiProperty<int>(this, ExpirationYearKey);
    private ApiProperty<int>? _expirationYearField;
    public const string ExpirationYearKey = "exp_year";
    /// <summary>
    /// Gets or sets the four-digit credit card expiration year.
    /// </summary>
    public int? ExpirationYear { get => ExpirationYearField.Value; set => ExpirationYearField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the credit card's billing address.
    /// </summary>
    public ApiPropertyString AddressField => _addressField ??= new ApiPropertyString(this, AddressKey);
    private ApiPropertyString? _addressField;
    public const string AddressKey = "address";
    /// <summary>
    /// Gets or sets the credit card's billing address.
    /// </summary>
    public string? Address { get => AddressField.Value; set => AddressField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set additional information about the credit card's billing address, such as unit number.
    /// </summary>
    public ApiPropertyString Address2Field => _address2Field ??= new ApiPropertyString(this, Address2Key);
    private ApiPropertyString? _address2Field;
    public const string Address2Key = "address2";
    /// <summary>
    /// Gets or sets additional information about the credit card's billing address, such as unit number.
    /// </summary>
    public string? Address2 { get => Address2Field.Value; set => Address2Field.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the credit card's billing address city.
    /// </summary>
    public ApiPropertyString CityField => _cityField ??= new ApiPropertyString(this, CityKey);
    private ApiPropertyString? _cityField;
    public const string CityKey = "city";
    /// <summary>
    /// Gets or sets the credit card's billing address city.
    /// </summary>
    public string? City { get => CityField.Value; set => CityField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the credit card's billing address state.
    /// </summary>
    public ApiPropertyString StateField => _stateField ??= new ApiPropertyString(this, StateKey);
    private ApiPropertyString? _stateField;
    public const string StateKey = "state";
    /// <summary>
    /// Gets or sets the credit card's billing address state.
    /// </summary>
    public string? State { get => StateField.Value; set => StateField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the credit card's billing address zip code.
    /// </summary>
    public ApiPropertyString ZipField => _zipField ??= new ApiPropertyString(this, ZipKey);
    private ApiPropertyString? _zipField;
    public const string ZipKey = "zip";
    /// <summary>
    /// Gets or sets the credit card's billing address zip code.
    /// </summary>
    public string? Zip { get => ZipField.Value; set => ZipField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the credit card's billing address country.
    /// </summary>
    public ApiPropertyString CountryField => _countryField ??= new ApiPropertyString(this, CountryKey);
    private ApiPropertyString? _countryField;
    public const string CountryKey = "country";
    /// <summary>
    /// Gets or sets the credit card's billing address country.
    /// </summary>
    public string? Country { get => CountryField.Value; set => CountryField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the current status of the credit card.
    /// </summary>
    public ApiProperty<CreditCardStatus> StatusField => _statusField ??= new ApiPropertyIntEnum<CreditCardStatus>(this, StatusKey);
    private ApiProperty<CreditCardStatus>? _statusField;
    public const string StatusKey = "status";
    /// <summary>
    /// Gets or sets the current status of the credit card.
    /// </summary>
    public CreditCardStatus? Status { get => StatusField.Value; set => StatusField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the date and time of the most recent charge.
    /// </summary>
    public ApiPropertyDateTime LastTransactionDateField => _lastTransactionDateField ??= new ApiPropertyDateTime(this, LastTransactionDateKey);
    private ApiPropertyDateTime? _lastTransactionDateField;
    public const string LastTransactionDateKey = "recent_sale";
    /// <summary>
    /// Gets or sets the date and time of the most recent charge.
    /// </summary>
    public DateTimeOffset? LastTransactionDate { get => LastTransactionDateField.Value; set => LastTransactionDateField.Value = value; }

    /// <summary>
    /// Returns a ApiProperty object to get or set the ID of the invoice generated in relation to the most recent charge to the credit card.
    /// </summary>
    public ApiProperty<long> LastInvoiceIdField => _lastInvoiceIdField ??= new ApiProperty<long>(this, LastInvoiceIdKey);
    private ApiProperty<long>? _lastInvoiceIdField;
    public const string LastInvoiceIdKey = "invoice_id";
    /// <summary>
    /// Gets or sets the ID of the invoice generated in relation to the most recent charge to the credit card.
    /// </summary>
    public long? LastInvoiceId { get => LastInvoiceIdField.Value; set => LastInvoiceIdField.Value = value; }



    /// <summary>
    /// The status of the credit card.
    /// </summary>
    public enum CreditCardStatus
    {
        Active = 1,
        Expired = 2,
        ActiveDefault = 3,
        ExpiredDefault = 4
    }
}
