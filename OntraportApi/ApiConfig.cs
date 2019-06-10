using System;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Contains the Ontraport configuration settings.
    /// </summary>
    public class ApiConfig
    {
        /// <summary>
        /// Gets or sets the Ontraport API Application Id, found in your account administration section.
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// Gets or sets the Ontraport API Key, found in your account administration section.
        /// </summary>
        public string ApiKey { get; set; }
        /// <summary>
        /// Gets or sets how many times to retry a query if it fails.
        /// </summary>
        public int AutoRetries { get; set; } = 3;
    }
}
