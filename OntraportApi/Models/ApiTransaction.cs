using System;
using System.Text.Json;
using HanumanInstitute.OntraportApi.Converters;
using HanumanInstitute.Validators;

namespace HanumanInstitute.OntraportApi.Models
{
    /// <summary>
    /// A transaction object is created when one of your contacts purchases a product.
    /// </summary>
    public class ApiTransaction : ApiObject
    {
        /// <summary>
        /// Returns a ApiProperty object to get or set whether or not the transaction is assessible.
        /// </summary>
        public ApiPropertyBool HiddenField => _hiddenField ??= new ApiPropertyBool(this, HiddenKey);
        private ApiPropertyBool? _hiddenField;
        public const string HiddenKey = "hidden";
        /// <summary>
        /// Gets or sets whether or not the transaction is assessible.
        /// </summary>
        public bool? Hidden { get => HiddenField.Value; set => HiddenField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the status of the transaction.
        /// </summary>
        public ApiPropertyIntEnum<TransactionStatus> StatusField => _statusField ??= new ApiPropertyIntEnum<TransactionStatus>(this, StatusKey);
        private ApiPropertyIntEnum<TransactionStatus>? _statusField;
        public const string StatusKey = "status";
        /// <summary>
        /// Gets or sets the status of the transaction.
        /// </summary>
        public TransactionStatus? Status { get => StatusField.Value; set => StatusField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the contact who made the transaction.
        /// </summary>
        public ApiProperty<int> ContactIdField => _contactIdField ??= new ApiProperty<int>(this, ContactIdKey);
        private ApiProperty<int>? _contactIdField;
        public const string ContactIdKey = "contact_id";
        /// <summary>
        /// Gets or sets the ID of the contact who made the transaction.
        /// </summary>
        public int? ContactId { get => ContactIdField.Value; set => ContactIdField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the full name of the contact who made the transaction.
        /// </summary>
        public ApiPropertyString ContactNameField => _contactNameField ??= new ApiPropertyString(this, ContactNameKey);
        private ApiPropertyString? _contactNameField;
        public const string ContactNameKey = "contact_name";
        /// <summary>
        /// Gets or sets the full name of the contact who made the transaction.
        /// </summary>
        public string? ContactName { get => ContactNameField.Value; set => ContactNameField.Value = value; }

        /// <summary>
        /// If the transaction resulted from a subscription purchase, returns a ApiProperty object to get or set the ID of the associated order.
        /// </summary>
        public ApiProperty<int> OrderIdField => _orderIdField ??= new ApiProperty<int>(this, OrderIdKey);
        private ApiProperty<int>? _orderIdField;
        public const string OrderIdKey = "order_id";
        /// <summary>
        /// If the transaction resulted from a subscription purchase, gets or sets the ID of the associated order.
        /// </summary>
        public int? OrderId { get => OrderIdField.Value; set => OrderIdField.Value = value; }

        /// <summary>
        /// If the transaction resulted from a purchase made via a form, returns a ApiProperty object to get or set the ID of that form.
        /// </summary>
        public ApiProperty<int> FormIdField => _formIdField ??= new ApiProperty<int>(this, FormIdKey);
        private ApiProperty<int>? _formIdField;
        public const string FormIdKey = "form_id";
        /// <summary>
        /// If the transaction resulted from a purchase made via a form, returns a ApiProperty object to get or set the ID of that form.
        /// </summary>
        public int? FormId { get => FormIdField.Value; set => FormIdField.Value = value; }

        /// <summary>
        /// If the transaction resulted from a purchase made via a landing page, returns a ApiProperty object to get or set the ID of that landing page.
        /// </summary>
        public ApiProperty<int> LandingPageIdField => _landingPageIdField ??= new ApiProperty<int>(this, LandingPageIdKey);
        private ApiProperty<int>? _landingPageIdField;
        public const string LandingPageIdKey = "lp_id";
        /// <summary>
        /// If the transaction resulted from a purchase made via a landing page, gets or sets the ID of that landing page.
        /// </summary>
        public int? LandingPageId { get => LandingPageIdField.Value; set => LandingPageIdField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the credit card used to charge the transaction.
        /// </summary>
        public ApiProperty<int> CreditCardIdField => _creditCardIdField ??= new ApiProperty<int>(this, CreditCardIdKey);
        private ApiProperty<int>? _creditCardIdField;
        public const string CreditCardIdKey = "cc_id";
        /// <summary>
        /// Gets or sets the ID of the credit card used to charge the transaction.
        /// </summary>
        public int? CreditCardId { get => CreditCardIdField.Value; set => CreditCardIdField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the payment gateway used to complete the transaction.
        /// </summary>
        public ApiProperty<int> GatewayIdField => _gatewayIdField ??= new ApiProperty<int>(this, GatewayIdKey);
        private ApiProperty<int>? _gatewayIdField;
        public const string GatewayIdKey = "gateway_id";
        /// <summary>
        /// Gets or sets the ID of the payment gateway used to complete the transaction.
        /// </summary>
        public int? GatewayId { get => GatewayIdField.Value; set => GatewayIdField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date and time the transaction was made.
        /// </summary>
        public ApiPropertyDateTime DateCreatedField => _dateCreatedField ??= new ApiPropertyDateTime(this, DateCreatedKey);
        private ApiPropertyDateTime? _dateCreatedField;
        public const string DateCreatedKey = "date";
        /// <summary>
        /// Gets or sets the date and time the transaction was made.
        /// </summary>
        public DateTimeOffset? DateCreated { get => DateCreatedField.Value; set => DateCreatedField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the invoice template sent to the contact.
        /// </summary>
        public ApiProperty<int> TemplateIdField => _templateIdField ??= new ApiProperty<int>(this, TemplateIdKey);
        private ApiProperty<int>? _templateIdField;
        public const string TemplateIdKey = "template_id";
        /// <summary>
        /// Gets or sets the ID of the invoice template sent to the contact.
        /// </summary>
        public int? TemplateId { get => TemplateIdField.Value; set => TemplateIdField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the amount of the transaction prior to tax and shipping.
        /// </summary>
        public ApiProperty<decimal> SubtotalField => _subtotalField ??= new ApiProperty<decimal>(this, SubtotalKey);
        private ApiProperty<decimal>? _subtotalField;
        public const string SubtotalKey = "subtotal";
        /// <summary>
        /// Gets or sets the amount of the transaction prior to tax and shipping.
        /// </summary>
        public decimal? Subtotal { get => SubtotalField.Value; set => SubtotalField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the amount of the tax on the transaction.
        /// </summary>
        public ApiProperty<decimal> TaxField => _taxField ??= new ApiProperty<decimal>(this, TaxKey);
        private ApiProperty<decimal>? _taxField;
        public const string TaxKey = "tax";
        /// <summary>
        /// Gets or sets the amount of the tax on the transaction.
        /// </summary>
        public decimal? Tax { get => TaxField.Value; set => TaxField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the amount of any city tax on the transaction.
        /// </summary>
        public ApiProperty<decimal> TaxCityField => _taxCityField ??= new ApiProperty<decimal>(this, TaxCityKey);
        private ApiProperty<decimal>? _taxCityField;
        public const string TaxCityKey = "tax_city";
        /// <summary>
        /// Gets or sets the amount of any city tax on the transaction.
        /// </summary>
        public decimal? TaxCity { get => TaxCityField.Value; set => TaxCityField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the amount of any state tax on the transaction.
        /// </summary>
        public ApiProperty<decimal> TaxStateField => _taxStateField ??= new ApiProperty<decimal>(this, TaxStateKey);
        private ApiProperty<decimal>? _taxStateField;
        public const string TaxStateKey = "tax_state";
        /// <summary>
        /// Gets or sets the amount of any state tax on the transaction.
        /// </summary>
        public decimal? TaxState { get => TaxStateField.Value; set => TaxStateField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the amount of any county tax on the transaction.
        /// </summary>
        public ApiProperty<decimal> TaxCountryField => _taxCountryField ??= new ApiProperty<decimal>(this, TaxCountryKey);
        private ApiProperty<decimal>? _taxCountryField;
        public const string TaxCountryKey = "tax_county";
        /// <summary>
        /// Gets or sets the amount of any county tax on the transaction.
        /// </summary>
        public decimal? TaxCountry { get => TaxCountryField.Value; set => TaxCountryField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the cost of shipping for the transaction.
        /// </summary>
        public ApiProperty<decimal> ShippingField => _shippingField ??= new ApiProperty<decimal>(this, ShippingKey);
        private ApiProperty<decimal>? _shippingField;
        public const string ShippingKey = "shipping";
        /// <summary>
        /// Gets or sets the cost of shipping for the transaction.
        /// </summary>
        public decimal? Shipping { get => ShippingField.Value; set => ShippingField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the total amount of the transaction.
        /// </summary>
        public ApiProperty<decimal> TotalField => _totalField ??= new ApiProperty<decimal>(this, TotalKey);
        private ApiProperty<decimal>? _totalField;
        public const string TotalKey = "total";
        /// <summary>
        /// Gets or sets the total amount of the transaction.
        /// </summary>
        public decimal? Total { get => TotalField.Value; set => TotalField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the zip code for the shipping address.
        /// </summary>
        public ApiPropertyString ZipField => _zipField ??= new ApiPropertyString(this, ZipKey);
        private ApiPropertyString? _zipField;
        public const string ZipKey = "zip";
        /// <summary>
        /// Gets or sets the zip code for the shipping address.
        /// </summary>
        public string? Zip { get => ZipField.Value; set => ZipField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the city for the shipping address.
        /// </summary>
        public ApiPropertyString CityField => _cityField ??= new ApiPropertyString(this, CityKey);
        private ApiPropertyString? _cityField;
        public const string CityKey = "city";
        /// <summary>
        /// Gets or sets the city for the shipping address.
        /// </summary>
        public string? City { get => CityField.Value; set => CityField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the state for the shipping address.
        /// </summary>
        public ApiPropertyString StateField => _stateField ??= new ApiPropertyString(this, StateKey);
        private ApiPropertyString? _stateField;
        public const string StateKey = "state";
        /// <summary>
        /// Gets or sets the state for the shipping address.
        /// </summary>
        public string? State { get => StateField.Value; set => StateField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the county for the shipping address.
        /// </summary>
        public ApiPropertyString CountryField => _countryField ??= new ApiPropertyString(this, CountryKey);
        private ApiPropertyString? _countryField;
        public const string CountryKey = "county";
        /// <summary>
        /// Gets or sets the county for the shipping address.
        /// </summary>
        public string? Country { get => CountryField.Value; set => CountryField.Value = value; }

        /// <summary>
        /// If a sale comes from another system, returns a ApiProperty object to get or set the order ID sent from that system.
        /// </summary>
        public ApiProperty<int> ExternalOrderIdField => _externalOrderIdField ??= new ApiProperty<int>(this, ExternalOrderIdKey);
        private ApiProperty<int>? _externalOrderIdField;
        public const string ExternalOrderIdKey = "external_order_id";
        /// <summary>
        /// If a sale comes from another system, gets or sets the order ID sent from that system.
        /// </summary>
        public int? ExternalOrderId { get => ExternalOrderIdField.Value; set => ExternalOrderIdField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the affiliate to be credited for the transaction.
        /// </summary>
        public ApiProperty<int> AffiliateIdField => _affiliateIdField ??= new ApiProperty<int>(this, AffiliateIdKey);
        private ApiProperty<int>? _affiliateIdField;
        public const string AffiliateIdKey = "oprid";
        /// <summary>
        /// Gets or sets the ID of the affiliate to be credited for the transaction.
        /// </summary>
        public int? AffiliateId { get => AffiliateIdField.Value; set => AffiliateIdField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the JSON encoded offer data. The offer object contains all information about products, quantities, coupons, tax and shipping.
        /// </summary>
        public ApiPropertyString OfferDataField => _offerDataField ??= new ApiPropertyString(this, OfferDataKey);
        private ApiPropertyString? _offerDataField;
        public const string OfferDataKey = "offer_data";
        /// <summary>
        /// Gets or sets the JSON encoded offer data. The offer object contains all information about products, quantities, coupons, tax and shipping.
        /// </summary>
        public string? OfferData { get => OfferDataField.Value; set => OfferDataField.Value = value; }

        /// <summary>
        /// If the transaction has been recharged, returns a ApiProperty object to get or set the date and time of the last attempt.
        /// </summary>
        public ApiPropertyDateTime LastRechargeDateField => _lastRechargeDateField ??= new ApiPropertyDateTime(this, LastRechargeDateKey);
        private ApiPropertyDateTime? _lastRechargeDateField;
        public const string LastRechargeDateKey = "last_recharge_date";
        /// <summary>
        /// If the transaction has been recharged, gets or sets the date and time of the last attempt.
        /// </summary>
        public DateTimeOffset? LastRechargeDate { get => LastRechargeDateField.Value; set => LastRechargeDateField.Value = value; }

        /// <summary>
        /// If the transaction has been recharged, returns a ApiProperty object to get or set the count of the number of times this has been attempted.
        /// </summary>
        public ApiProperty<int> RechargeAttemptsField => _rechargeAttemptsField ??= new ApiProperty<int>(this, RechargeAttemptsKey);
        private ApiProperty<int>? _rechargeAttemptsField;
        public const string RechargeAttemptsKey = "recharge_attempts";
        /// <summary>
        /// If the transaction has been recharged, gets or sets the count of the number of times this has been attempted.
        /// </summary>
        public int? RechargeAttempts { get => RechargeAttemptsField.Value; set => RechargeAttemptsField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set whether or not the transaction should be recharged.
        /// </summary>
        public ApiPropertyIntBool RechargeField => _rechargeField ??= new ApiPropertyIntBool(this, RechargeKey);
        private ApiPropertyIntBool? _rechargeField;
        public const string RechargeKey = "recharge";
        /// <summary>
        /// Gets or sets whether or not the transaction should be recharged.
        /// </summary>
        public bool? Recharge { get => RechargeField.Value; set => RechargeField.Value = value; }

        /// <summary>
        /// Parses and returns the offer data associated with this transaction.
        /// </summary>
        public ApiTransactionOffer? Offer => _offer ??= ParseOfferData();
        private ApiTransactionOffer? _offer;
        private ApiTransactionOffer? ParseOfferData()
        {
            if (string.IsNullOrEmpty(OfferData)) { return null; }
            return JsonSerializer.Deserialize<ApiTransactionOffer>(OfferData, OntraportSerializerOptions.Default);
        }



        /// <summary>
        /// The status of the transaction.
        /// </summary>
        public enum TransactionStatus
        {
            Unpaid = 0,
            Paid = 1,
            Refunded = 2,
            PartiallyRefunded = 3,
            Void = 4,
            Declined = 5,
            WrittenOff = 6,
            Pending = 7
        }
    }
}
