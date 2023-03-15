namespace HanumanInstitute.OntraportApi.Models;

/// <summary>
/// Contains information about an Ontraport field.
/// </summary>
public class ApiFieldInfo
{
    public int? Id { get; set; }

    public string? Alias { get; set; }

    public string? Field { get; set; }

    public string? Type { get; set; }

    public bool? Required { get; set; }

    public bool? Unique { get; set; }

    public bool? Editable { get; set; }

    public bool? Deletable { get; set; }

    public string? Options { get; set; }

    public override string ToString() => $"\"{Alias}\", \"{Type}\"";
}
