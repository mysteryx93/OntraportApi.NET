using System;
using EmergenceGuardian.OntraportApi.Models;
using Newtonsoft.Json;

namespace EmergenceGuardian.OntraportApi.Converters
{
    /// <summary>
    /// Converts a "0" or "1" field into a boolean property.
    /// </summary>
    public class JsonConverterIntBool : JsonConverterBase<bool>
    {
        public override string NullString => "";

        public override P Parse<P>(string value)
        {
            // Different forms may use either a binary integer or boolean value for deleted field.
            int? valueInt = null;
            if (value == "true" || value == "True")
            {
                valueInt = 1;
            }
            else if (value == "false" || value == "False")
            {
                valueInt = 0;
            }
            else if (!string.IsNullOrEmpty(value))
            {
                valueInt = value.Convert<int?>();
            }

            return (P)(object)((valueInt ?? 0) == 1);
            //if (valueInt.HasValue)
            //{
            //    return (P)(object)(valueInt == 1);
            //}
            //return CreateNull<P>();
        }

        public override object Format(bool? value) => value.HasValue ? (value == true ? 1 : 0) : (object)null;
    }
}
