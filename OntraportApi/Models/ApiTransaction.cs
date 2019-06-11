using System;
using EmergenceGuardian.OntraportApi.Converters;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// A transaction object is created when one of your contacts purchases a product.
    /// </summary>
    public class ApiTransaction : ApiObject
    {
        /// <summary>
        /// Returns a ApiProperty object to get or set whether or not the transaction is assessible.
        /// </summary>
        public ApiPropertyBool Hidden => _hidden ?? (_hidden = new ApiPropertyBool(this, "hidden"));
        private ApiPropertyBool _hidden;
        /// <summary>
        /// Gets or sets whether or not the transaction is assessible.
        /// </summary>
        public bool HiddenValue { get => Hidden.Value; set => Hidden.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the status of the transaction.
        /// </summary>
        public ApiPropertyIntEnum<TransactionStatus> Status => _status ?? (_status = new ApiPropertyIntEnum<TransactionStatus>(this, "status"));
        private ApiPropertyIntEnum<TransactionStatus> _status;
        /// <summary>
        /// Gets or sets the status of the transaction.
        /// </summary>
        public TransactionStatus StatusValue { get => Status.Value; set => Status.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the contact who made the transaction.
        /// </summary>
        public ApiPropertyInt ContactId => _contactId ?? (_contactId = new ApiPropertyInt(this, "contact_id"));
        private ApiPropertyInt _contactId;
        /// <summary>
        /// Gets or sets the ID of the contact who made the transaction.
        /// </summary>
        public int ContactIdValue { get => ContactId.Value; set => ContactId.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the full name of the contact who made the transaction.
        /// </summary>
        public ApiPropertyString ContactName => _contactName ?? (_contactName = new ApiPropertyString(this, "contact_name"));
        private ApiPropertyString _contactName;
        /// <summary>
        /// Gets or sets the full name of the contact who made the transaction.
        /// </summary>
        public string ContactNameValue { get => ContactName.Value; set => ContactName.Value = value; }

        /// <summary>
        /// If the transaction resulted from a subscription purchase, returns a ApiProperty object to get or set the ID of the associated order.
        /// </summary>
        public ApiPropertyInt OrderId => _orderId ?? (_orderId = new ApiPropertyInt(this, "order_id"));
        private ApiPropertyInt _orderId;
        /// <summary>
        /// If the transaction resulted from a subscription purchase, gets or sets the ID of the associated order.
        /// </summary>
        public int OrderIdValue { get => OrderId.Value; set => OrderId.Value = value; }

        /// <summary>
        /// If the transaction resulted from a purchase made via a form, returns a ApiProperty object to get or set the ID of that form.
        /// </summary>
        public ApiPropertyInt FormId => _formId ?? (_formId = new ApiPropertyInt(this, "form_id"));
        private ApiPropertyInt _formId;
        /// <summary>
        /// If the transaction resulted from a purchase made via a form, returns a ApiProperty object to get or set the ID of that form.
        /// </summary>
        public int FormIdValue { get => FormId.Value; set => FormId.Value = value; }

        /// <summary>
        /// If the transaction resulted from a purchase made via a landing page, returns a ApiProperty object to get or set the ID of that landing page.
        /// </summary>
        public ApiPropertyInt LandingPageId => _landingPageId ?? (_landingPageId = new ApiPropertyInt(this, "lp_id"));
        private ApiPropertyInt _landingPageId;
        /// <summary>
        /// If the transaction resulted from a purchase made via a landing page, gets or sets the ID of that landing page.
        /// </summary>
        public int LandingPageIdValue { get => LandingPageId.Value; set => LandingPageId.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the credit card used to charge the transaction.
        /// </summary>
        public ApiPropertyInt CreditCardId => _creditCardId ?? (_creditCardId = new ApiPropertyInt(this, "cc_id"));
        private ApiPropertyInt _creditCardId;
        /// <summary>
        /// Gets or sets the ID of the credit card used to charge the transaction.
        /// </summary>
        public int CreditCardIdValue { get => CreditCardId.Value; set => CreditCardId.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the payment gateway used to complete the transaction.
        /// </summary>
        public ApiPropertyInt GatewayId => _gatewayId ?? (_gatewayId = new ApiPropertyInt(this, "gateway_id"));
        private ApiPropertyInt _gatewayId;
        /// <summary>
        /// Gets or sets the ID of the payment gateway used to complete the transaction.
        /// </summary>
        public int GatewayIdValue { get => GatewayId.Value; set => GatewayId.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date and time the transaction was made.
        /// </summary>
        public ApiPropertyDateTime DateCreated => _date ?? (_date = new ApiPropertyDateTime(this, "date"));
        private ApiPropertyDateTime _date;
        /// <summary>
        /// Gets or sets the date and time the transaction was made.
        /// </summary>
        public DateTimeOffset DateValue { get => DateCreated.Value; set => DateCreated.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the invoice template sent to the contact.
        /// </summary>
        public ApiPropertyInt TemplateId => _templateId ?? (_templateId = new ApiPropertyInt(this, "template_id"));
        private ApiPropertyInt _templateId;
        /// <summary>
        /// Gets or sets the ID of the invoice template sent to the contact.
        /// </summary>
        public int TemplateIdValue { get => TemplateId.Value; set => TemplateId.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the amount of the transaction prior to tax and shipping.
        /// </summary>
        public ApiPropertyDouble Subtotal => _subtotal ?? (_subtotal = new ApiPropertyDouble(this, "subtotal"));
        private ApiPropertyDouble _subtotal;
        /// <summary>
        /// Gets or sets the amount of the transaction prior to tax and shipping.
        /// </summary>
        public double SubtotalValue { get => Subtotal.Value; set => Subtotal.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the amount of the tax on the transaction.
        /// </summary>
        public ApiPropertyDouble Tax => _tax ?? (_tax = new ApiPropertyDouble(this, "tax"));
        private ApiPropertyDouble _tax;
        /// <summary>
        /// Gets or sets the amount of the tax on the transaction.
        /// </summary>
        public double TaxValue { get => Tax.Value; set => Tax.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the amount of any city tax on the transaction.
        /// </summary>
        public ApiPropertyDouble TaxCity => _taxCity ?? (_taxCity = new ApiPropertyDouble(this, "tax_city"));
        private ApiPropertyDouble _taxCity;
        /// <summary>
        /// Gets or sets the amount of any city tax on the transaction.
        /// </summary>
        public double TaxCityValue { get => TaxCity.Value; set => TaxCity.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the amount of any state tax on the transaction.
        /// </summary>
        public ApiPropertyDouble TaxState => _taxState ?? (_taxState = new ApiPropertyDouble(this, "tax_state"));
        private ApiPropertyDouble _taxState;
        /// <summary>
        /// Gets or sets the amount of any state tax on the transaction.
        /// </summary>
        public double TaxStateValue { get => TaxState.Value; set => TaxState.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the amount of any county tax on the transaction.
        /// </summary>
        public ApiPropertyDouble TaxCountry => _taxCountry ?? (_taxCountry = new ApiPropertyDouble(this, "tax_county"));
        private ApiPropertyDouble _taxCountry;
        /// <summary>
        /// Gets or sets the amount of any county tax on the transaction.
        /// </summary>
        public double TaxCountryValue { get => TaxCountry.Value; set => TaxCountry.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the cost of shipping for the transaction.
        /// </summary>
        public ApiPropertyDouble Shipping => _shipping ?? (_shipping = new ApiPropertyDouble(this, "shipping"));
        private ApiPropertyDouble _shipping;
        /// <summary>
        /// Gets or sets the cost of shipping for the transaction.
        /// </summary>
        public double ShippingValue { get => Shipping.Value; set => Shipping.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the total amount of the transaction.
        /// </summary>
        public ApiPropertyDouble Total => _total ?? (_total = new ApiPropertyDouble(this, "total"));
        private ApiPropertyDouble _total;
        /// <summary>
        /// Gets or sets the total amount of the transaction.
        /// </summary>
        public double TotalValue { get => Total.Value; set => Total.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the zip code for the shipping address.
        /// </summary>
        public ApiPropertyString Zip => _zip ?? (_zip = new ApiPropertyString(this, "zip"));
        private ApiPropertyString _zip;
        /// <summary>
        /// Gets or sets the zip code for the shipping address.
        /// </summary>
        public string ZipValue { get => Zip.Value; set => Zip.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the city for the shipping address.
        /// </summary>
        public ApiPropertyString City => _city ?? (_city = new ApiPropertyString(this, "city"));
        private ApiPropertyString _city;
        /// <summary>
        /// Gets or sets the city for the shipping address.
        /// </summary>
        public string CityValue { get => City.Value; set => City.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the state for the shipping address.
        /// </summary>
        public ApiPropertyString State => _state ?? (_state = new ApiPropertyString(this, "state"));
        private ApiPropertyString _state;
        /// <summary>
        /// Gets or sets the state for the shipping address.
        /// </summary>
        public string StateValue { get => State.Value; set => State.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the county for the shipping address.
        /// </summary>
        public ApiPropertyString County => _county ?? (_county = new ApiPropertyString(this, "county"));
        private ApiPropertyString _county;
        /// <summary>
        /// Gets or sets the county for the shipping address.
        /// </summary>
        public string CountyValue { get => County.Value; set => County.Value = value; }

        /// <summary>
        /// If a sale comes from another system, returns a ApiProperty object to get or set the order ID sent from that system.
        /// </summary>
        public ApiPropertyInt ExternalOrderId => _externalOrderId ?? (_externalOrderId = new ApiPropertyInt(this, "external_order_id"));
        private ApiPropertyInt _externalOrderId;
        /// <summary>
        /// If a sale comes from another system, gets or sets the order ID sent from that system.
        /// </summary>
        public int ExternalOrderIdValue { get => ExternalOrderId.Value; set => ExternalOrderId.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the affiliate to be credited for the transaction.
        /// </summary>
        public ApiPropertyInt AffiliateId => _affiliateId ?? (_affiliateId = new ApiPropertyInt(this, "oprid"));
        private ApiPropertyInt _affiliateId;
        /// <summary>
        /// Gets or sets the ID of the affiliate to be credited for the transaction.
        /// </summary>
        public int AffiliateIdValue { get => AffiliateId.Value; set => AffiliateId.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the JSON encoded offer data. The offer object contains all information about products, quantities, coupons, tax and shipping.
        /// </summary>
        public ApiPropertyString OfferData => _offerData ?? (_offerData = new ApiPropertyString(this, "offer_data"));
        private ApiPropertyString _offerData;
        /// <summary>
        /// Gets or sets the JSON encoded offer data. The offer object contains all information about products, quantities, coupons, tax and shipping.
        /// </summary>
        public string OfferDataValue { get => OfferData.Value; set => OfferData.Value = value; }

        /// <summary>
        /// If the transaction has been recharged, returns a ApiProperty object to get or set the date and time of the last attempt.
        /// </summary>
        public ApiPropertyDateTime LastRechargeDate => _lastRechargeDate ?? (_lastRechargeDate = new ApiPropertyDateTime(this, "last_recharge_date"));
        private ApiPropertyDateTime _lastRechargeDate;
        /// <summary>
        /// If the transaction has been recharged, gets or sets the date and time of the last attempt.
        /// </summary>
        public DateTimeOffset LastRechargeDateValue { get => LastRechargeDate.Value; set => LastRechargeDate.Value = value; }

        /// <summary>
        /// If the transaction has been recharged, returns a ApiProperty object to get or set the count of the number of times this has been attempted.
        /// </summary>
        public ApiPropertyInt RechargeAttempts => _rechargeAttempts ?? (_rechargeAttempts = new ApiPropertyInt(this, "recharge_attempts"));
        private ApiPropertyInt _rechargeAttempts;
        /// <summary>
        /// If the transaction has been recharged, gets or sets the count of the number of times this has been attempted.
        /// </summary>
        public int RechargeAttemptsValue { get => RechargeAttempts.Value; set => RechargeAttempts.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set whether or not the transaction should be recharged.
        /// </summary>
        public ApiPropertyIntBool Recharge => _recharge ?? (_recharge = new ApiPropertyIntBool(this, "recharge"));
        private ApiPropertyIntBool _recharge;
        /// <summary>
        /// Gets or sets whether or not the transaction should be recharged.
        /// </summary>
        public bool RechargeValue { get => Recharge.Value; set => Recharge.Value = value; }





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
