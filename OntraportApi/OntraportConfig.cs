using System;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Contains the Ontraport configuration settings.
    /// </summary>
    public class OntraportConfig
    {
        /// <summary>
        /// Gets or sets the Ontraport API Application Id, found in your account administration section.
        /// </summary>
        public string AppId { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the Ontraport API Key, found in your account administration section.
        /// </summary>
        public string ApiKey { get; set; } = string.Empty;
    }
}
