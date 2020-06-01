using System;
using System.Collections.Generic;
using System.Text;
using HanumanInstitute.OntraportApi.Converters;

namespace HanumanInstitute.OntraportApi.Models
{
    public class ApiDeal : ApiCustomObjectBase
    {
        /// <summary>
        /// Returns a ApiProperty object to get or set the deal's name.
        /// </summary>
        public ApiPropertyString NameField => _nameField ??= new ApiPropertyString(this, NameKey);
        private ApiPropertyString? _nameField;
        public const string NameKey = "name";
        /// <summary>
        /// Gets or sets the deal's name.
        /// </summary>
        public string Name { get => NameField.Value; set => NameField.Value = value; }

        public ApiProperty<decimal> ValueField => _valueField ??= new ApiProperty<decimal>(this, ValueKey);
        private ApiProperty<decimal>? _valueField;
        public const string ValueKey = "value";
        public decimal? Value { get => ValueField.Value; set => ValueField.Value = value; }

        public ApiPropertyDateTime ExpectedCloseDateField => _expectedCloseDateField ??= new ApiPropertyDateTime(this, ExpectedCloseDateKey);
        private ApiPropertyDateTime? _expectedCloseDateField;
        public const string ExpectedCloseDateKey = "expected_close_date";
        public DateTimeOffset? ExpectedCloseDate { get => ExpectedCloseDateField.Value; set => ExpectedCloseDateField.Value = value; }

        public ApiProperty<int> ExpectedWinPercentField => _expectedWinPercentField ??= new ApiProperty<int>(this, ExpectedWinPercentKey);
        private ApiProperty<int>? _expectedWinPercentField;
        public const string ExpectedWinPercentKey = "expected_win_percent";
        public int? ExpectedWinPercent { get => ExpectedWinPercentField.Value; set => ExpectedWinPercentField.Value = value; }

        public ApiProperty<int> CalcField => _calcField ??= new ApiProperty<int>(this, CalcKey);
        private ApiProperty<int>? _calcField;
        public const string CalcKey = "calc";
        public int? Calc { get => CalcField.Value; set => CalcField.Value = value; }

        public ApiProperty<int> PrimaryContactField => _primaryContactField ??= new ApiProperty<int>(this, PrimaryContactKey);
        private ApiProperty<int>? _primaryContactField;
        public const string PrimaryContactKey = "primary_contact";
        public int? PrimaryContact { get => PrimaryContactField.Value; set => PrimaryContactField.Value = value; }

        public ApiPropertyString CompanyField => _companyField ??= new ApiPropertyString(this, CompanyKey);
        private ApiPropertyString? _companyField;
        public const string CompanyKey = "company";
        public string Company { get => CompanyField.Value; set => CompanyField.Value = value; }

        public ApiProperty<decimal> WeightedValueField => _weightedValueField ??= new ApiProperty<decimal>(this, WeightedValueKey);
        private ApiProperty<decimal>? _weightedValueField;
        public const string WeightedValueKey = "weighted_value";
        public decimal? WeightedValue { get => WeightedValueField.Value; set => WeightedValueField.Value = value; }

        public ApiProperty<SaleStatus> SaleStageField => _saleStageField ??= new ApiPropertyIntEnum<SaleStatus>(this, SaleStageKey);
        private ApiProperty<SaleStatus>? _saleStageField;
        public const string SaleStageKey = "sales_stage";
        public SaleStatus? SaleStage { get => SaleStageField.Value; set => SaleStageField.Value = value; }

        public ApiPropertyDateTime ActualCloseDateField => _actualCloseDateField ??= new ApiPropertyDateTime(this, ActualCloseDateKey);
        private ApiPropertyDateTime? _actualCloseDateField;
        public const string ActualCloseDateKey = "actual_close_date";
        public DateTimeOffset? ActualCloseDate { get => ActualCloseDateField.Value; set => ActualCloseDateField.Value = value; }

        // This is a configurable enum.
        public ApiProperty<int> ExpectedCloseTimeFrameField => _expectedCloseTimeFrameField ??= new ApiProperty<int>(this, ExpectedCloseTimeFrameKey);
        private ApiProperty<int>? _expectedCloseTimeFrameField;
        public const string ExpectedCloseTimeFrameKey = "expected_close_timeframe";
        public int? ExpectedCloseTimeFrame { get => ExpectedCloseTimeFrameField.Value; set => ExpectedCloseTimeFrameField.Value = value; }

        public ApiProperty<DealSizeEnum> DealSizeField => _dealSizeField ??= new ApiPropertyIntEnum<DealSizeEnum>(this, DealSizeKey);
        private ApiProperty<DealSizeEnum>? _dealSizeField;
        public const string DealSizeKey = "deal_size";
        public DealSizeEnum? DealSize { get => DealSizeField.Value; set => DealSizeField.Value = value; }

        public ApiPropertyDateTime RecentActivityField => _recentActivityField ??= new ApiPropertyDateTime(this, RecentActivityKey);
        private ApiPropertyDateTime? _recentActivityField;
        public const string RecentActivityKey = "recent_activity";
        public DateTimeOffset? RecentActivity { get => RecentActivityField.Value; set => RecentActivityField.Value = value; }



        public enum DealSizeEnum
        {
            None = 0,
            Small = 1,
            Medium = 2,
            Large = 3
        }
    }
}
