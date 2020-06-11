using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HanumanInstitute.OntraportApi.Models
{
    /// <summary>
    /// If billing address information is not already on file for a contact, this information must be included with any manual transaction.
    /// Address information does not need to be included if it is already on file.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ApiTransactionAddress
    {
        /// <summary>
        /// Gets or sets the contact's billing address.
        /// </summary>
        public string? Address { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets any additional address information for the contact, such as building or suite number.
        /// </summary>
        public string? Address2 { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the contact's city.
        /// </summary>
        public string? City { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the contact's state.
        /// </summary>
        public string? State { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the contact's zip code.
        /// </summary>
        public string? Zip { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the contact's country.
        /// </summary>
        public string? Country { get; set; } = string.Empty;
    }
}
