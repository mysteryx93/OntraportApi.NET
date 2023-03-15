using System.ComponentModel.DataAnnotations;

namespace HanumanInstitute.OntraportApi.Models;

/// <summary>
/// Contains the Ontraport configuration settings.
/// </summary>
public class OntraportConfig
{
    /// <summary>
    /// Gets or sets the Ontraport API Application Id, found in your account administration section.
    /// </summary>
    [Required]
    public string AppId { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the Ontraport API Key, found in your account administration section.
    /// </summary>
    [Required]
    public string ApiKey { get; set; } = string.Empty;
}
