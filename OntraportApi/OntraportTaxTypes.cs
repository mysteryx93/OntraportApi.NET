namespace HanumanInstitute.OntraportApi;

/// <summary>
/// Provides Ontraport API support for ShippingType objects.
/// </summary>
public class OntraportTaxTypes : OntraportBaseDelete<ApiTaxType>, IOntraportTaxTypes
{
	public OntraportTaxTypes(OntraportHttpClient apiRequest) :
		base(apiRequest, "Taxtype", "Taxtypes", ApiTaxType.NameKey)
	{
	}
}
