using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HanumanInstitute.OntraportApi.Models
{
    /// <summary>
    /// Payer information is stored for contacts with credit card information on file. 
    /// If this information is not currently on file for a contact, it needs to be included in order to successfully process a transaction.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ApiTransactionPayer
    {
        /// <summary>
        /// Gets or sets the contact's full credit card number.
        /// </summary>
        [JsonProperty("ccnumber")]
        public string? CardNumber { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the CVV code for the contact's credit card.
        /// </summary>
        public string? CvvCode { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the expiration month, in digits, of the credit card to be processed.
        /// </summary>
        public int ExpireMonth { get; set; }
        /// <summary>
        /// Gets or sets the four-digit expiration year of the credit card to be processed.
        /// </summary>
        public int ExpireYear { get; set; }
    }
}
