namespace HanumanInstitute.OntraportApi.Models;

public class ApiTaxType : ApiObject
{
	/// <summary>
	/// Returns a ApiProperty object to get or set the tax type's name.
	/// </summary>
	public ApiPropertyString NameField => _nameField ??= new ApiPropertyString(this, NameKey);
	private ApiPropertyString? _nameField;
	public const string NameKey = "name";
	/// <summary>
	/// Gets or sets the tax type's name.
	/// </summary>
	public string? Name { get => NameField.Value; set => NameField.Value = value; }

	/// <summary>
	/// Returns a ApiProperty object to get or set the tax type's price.
	/// </summary>
	public ApiProperty<float> RateField => _rateField ??= new ApiProperty<float>(this, RateKey);
	private ApiProperty<float>? _rateField;
	public const string RateKey = "rate";
	/// <summary>
	/// Gets or sets the tax type's price.
	/// </summary>
	public float? Rate { get => RateField.Value; set => RateField.Value = value; }
}
