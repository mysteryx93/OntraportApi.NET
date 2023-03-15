using System.ComponentModel;

namespace HanumanInstitute.OntraportApi.Models;

/// <summary>
/// Contains common sort options.
/// </summary>
public class ApiSortOptions
{
    public ApiSortOptions() { }

    public ApiSortOptions(string sort, ListSortDirection direction = ListSortDirection.Ascending)
    {
        Sort = sort;
        Direction = direction;
    }

    /// <summary>
    /// Gets or sets the field results should be sorted on.
    /// </summary>
    public string? Sort { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the direction your results should be sorted.
    /// </summary>
    public ListSortDirection Direction { get; set; } = ListSortDirection.Ascending;
}
