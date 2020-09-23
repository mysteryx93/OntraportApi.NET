using System;
using System.Globalization;
using System.Text;
using System.Text.Json;
using HanumanInstitute.Validators;

namespace HanumanInstitute.OntraportApi
{
    /// <summary>
    /// Naming policy to convert 'PropertyName' into 'property_name'. While JsonSerializer uses CamelCasePolicy, this is used by JsonConverterStringEnum.
    /// </summary>
    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            name.CheckNotNullOrEmpty(nameof(name));

            var result = new StringBuilder();
            for (var i = 0; i < name.Length; i++)
            {
                var c = name[i];
                if (i == 0)
                {
                    result.Append(char.ToLower(c, CultureInfo.InvariantCulture));
                }
                else
                {
                    if (char.IsUpper(c))
                    {
                        result.Append('_');
                        result.Append(char.ToLower(c, CultureInfo.InvariantCulture));
                    }
                    else
                    {
                        result.Append(c);
                    }
                }
            }
            return result.ToString();
        }
    }
}
