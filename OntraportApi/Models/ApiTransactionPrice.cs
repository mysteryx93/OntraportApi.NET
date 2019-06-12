using System;
using EmergenceGuardian.OntraportApi.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// Any array of price data should be included with products.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ApiTransactionPrice
    {
        /// <summary>
        /// Gets or sets the ID of the pricing item.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// If a payment plan item, gets or sets the number of payments to be made.
        /// </summary>
        public int? PaymentCount { get; set; }

        /// <summary>
        /// Gets or sets the units of time of payments.
        /// </summary>
        [JsonConverter(typeof(JsonConverterStringEnum<TransactionPeriodUnit>))]
        public TransactionPeriodUnit? Unit { get; set; }
    }
}
