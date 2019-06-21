using System;
using EmergenceGuardian.OntraportApi.Converters;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi.UnitTests
{
    public class ApiPropertyBoolTests : ApiPropertyBaseTests<ApiPropertyBool, bool, bool?>
    { }

    public class ApiPropertyDateTimeTests : ApiPropertyBaseTests<ApiPropertyDateTime, DateTimeOffset, DateTimeOffset?>
    { }

    public class ApiPropertyIntBoolTests : ApiPropertyBaseTests<ApiPropertyIntBool, bool, bool?>
    { }

    public class ApiPropertyIntEnumTests : ApiPropertyBaseTests<ApiPropertyIntEnum<BulkMailStatus>, BulkMailStatus, BulkMailStatus?>
    { }

    public class ApiPropertyStringTests : ApiPropertyBaseTests<ApiPropertyString, string, string>
    {
    }

    public class ApiPropertyStringEnumTests : ApiPropertyBaseTests<ApiPropertyStringEnum<BulkMailStatus>, BulkMailStatus, BulkMailStatus?>
    { }

    public class ApiPropertyintTests : ApiPropertyBaseTests<ApiProperty<int>, int, int?>
    { }

    public class ApiPropertyDecimalTests : ApiPropertyBaseTests<ApiProperty<decimal>, decimal, decimal?>
    { }
}
