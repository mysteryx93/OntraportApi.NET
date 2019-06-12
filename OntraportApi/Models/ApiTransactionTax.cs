using System;
using EmergenceGuardian.OntraportApi.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// Any array of price data should be included with products.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ApiTransactionTax
    {
        /// <summary>
        /// Gets or sets the ID of the existing tax object to apply to the offer.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the rate at which the offer should be taxed.
        /// </summary>
        public float? Rate { get; set; }

        /// <summary>
        /// Gets or sets the name of the tax to be applied.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets whether or not shipping charges should be taxed.
        /// </summary>
        public bool? TaxShipping { get; set; }

        /// <summary>
        /// Gets or sets the total amount of the applied taxes.
        /// </summary>
        public decimal? TaxTotal { get; set; }

        /// <summary>
        /// Gets or sets the ID of the related form, if any.
        /// </summary>
        [JsonProperty("form_id")]
        public int? FormId { get; set; }
    }
}
