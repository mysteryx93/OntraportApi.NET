﻿using System;
using System.Collections.Generic;
using EmergenceGuardian.OntraportApi.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// An array of products is included with every offer. If valid, existing products are not included, a transaction can't be processed.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ApiTransactionProduct
    {
        [JsonProperty("id")]
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the total number of this item to be included in the purchase.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the total amount of this purchase.
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Gets or sets whether or not there is a cost to ship this product.
        /// </summary>
        [JsonConverter(typeof(JsonConverterBool))]
        public bool Shipping { get; set; }

        /// <summary>
        /// Gets or sets whether or not this product should be taxed.
        /// </summary>
        [JsonConverter(typeof(JsonConverterBool))]
        public bool Taxable { get; set; }

        /// <summary>
        /// Gets or sets a list of pricing elements associated with this product. 
        /// </summary>
        public IList<ApiTransactionPrice> Price { get; set; }

        /// <summary>
        /// Gets or sets the type of product.
        /// </summary>
        [JsonConverter(typeof(JsonConverterStringEnum<ProductType>))]
        public ProductType? Type { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user controlling the product.
        /// </summary>
        public int? Owner { get; set; }

        /// <summary>
        /// Gets or sets the partner level 1 commission flat or percentage, if any.
        /// </summary>
        public decimal? Level1 { get; set; }

        /// <summary>
        /// Gets or sets the partner level 2 commission flat or percentage, if any.
        /// </summary>
        public decimal? Level2 { get; set; }

        /// <summary>
        /// Gets or sets whether or not this product is offered to affiliates.
        /// </summary>
        public bool? OfferToAffiliates { get; set; }

        /// <summary>
        /// If there is a trial period for the product, gets or sets the units of length of the trial period. 
        /// </summary>
        [JsonConverter(typeof(JsonConverterStringEnum<ApiTransactionPeriodUnit>))]
        public ApiTransactionPeriodUnit? TrialPeriodUnit { get; set; }

        /// <summary>
        /// Gets or sets the length of the trial period. Must be used in conjunction with trial_period_unit.
        /// </summary>
        public int? TrialPeriodCount { get; set; }

        /// <summary>
        /// Gets or sets the price of the product during the trial period.
        /// </summary>
        public decimal? TrialPrice { get; set; }

        /// <summary>
        /// Gets or sets the cost of of any one-time set-up fee, if applicable.
        /// </summary>
        public decimal? SetupFee { get; set; }

        /// <summary>
        /// Gets or sets when the setup fee should be applied.
        /// </summary>
        [JsonConverter(typeof(JsonConverterStringEnum<ProductSetupFeeWhen>))]
        public ProductSetupFeeWhen? SetupFeeWhen { get; set; }

        /// <summary>
        /// If the value for setup_fee_when is on_date, gets or sets the date of when the setup fee should be applied.
        /// </summary>
        public DateTimeOffset? SetupFeeDate { get; set; }

        /// <summary>
        /// Gets or sets the number of days to delay the start of a subscription.
        /// </summary>
        public int? DelayStart { get; set; }

        /// <summary>
        /// Gets or sets the cost of any additional fee for a subscription product.
        /// </summary>
        public decimal? SubscriptionFee { get; set; }

        /// <summary>
        /// Gets or sets the number of subscriptions.
        /// </summary>
        public int? SubscriptionCount { get; set; }

        /// <summary>
        /// Gets or sets how often a subscription product is delivered. 
        /// </summary>
        [JsonConverter(typeof(JsonConverterStringEnum<ApiTransactionPeriodUnit>))]
        public ApiTransactionPeriodUnit? SubscriptionUnit { get; set; }


        public ApiTransactionProduct AddPrice(decimal price)
        {
            Price = Price ?? new List<ApiTransactionPrice>();
            Price.Add(new ApiTransactionPrice()
            {
                Price = price
            });
            return this;
        }




        /// <summary>
        /// The type of product payment.
        /// </summary>
        public enum ProductType
        {
            /// <summary>
            /// A recurring purchase item.
            /// </summary>
            Subscription,
            /// <summary>
            /// A single purchase item.
            /// </summary>
            OneTime,
            /// <summary>
            /// A product paid for on installment.
            /// </summary>
            PaymentPlan
        }

        /// <summary>
        /// Indicates when the setup fee should be applied.
        /// </summary>
        public enum ProductSetupFeeWhen
        {
            Immediately,
            AfterTrial,
            OnDate
        }
    }
}