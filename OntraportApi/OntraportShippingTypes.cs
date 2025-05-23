namespace HanumanInstitute.OntraportApi;


public class OntraportShippingTypes : OntraportBaseDelete<ApiShippingType>, IOntraportShippingTypes
{
    public OntraportShippingTypes(OntraportHttpClient apiRequest) : base(apiRequest, "ShippingType", "ShippingTypes", ApiShippingType.NameKey)
    {
    }
}
