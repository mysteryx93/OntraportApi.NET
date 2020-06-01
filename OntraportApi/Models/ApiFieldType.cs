using System;

namespace HanumanInstitute.OntraportApi.Models
{
    /// <summary>
    /// The Ontraport field type when creating custom fields. System fields can be of additional types.
    /// </summary>
    public enum ApiFieldType
    {
        check,
        country,
        fulldate,
        list,
        longtext,
        numeric,
        price,
        phone,
        state,
        drop,
        text,
        email,
        sms,
        address
    }
}
