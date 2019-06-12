using System;
using System.Collections.Generic;
using System.Text;
using EmergenceGuardian.OntraportApi.Converters;

namespace EmergenceGuardian.OntraportApi.Models
{
    public class ApiDeal : ApiCustomObjectBase
    {
        /// <summary>
        /// Returns a ApiProperty object to get or set the deal's name.
        /// </summary>
        public ApiPropertyString Name => _name ?? (_name = new ApiPropertyString(this, "name"));
        private ApiPropertyString _name;
        /// <summary>
        /// Gets or sets the deal's name.
        /// </summary>
        public string NameValue { get => Name.Value; set => Name.Value = value; }

        public ApiProperty<decimal> Value => _value ?? (_value = new ApiProperty<decimal>(this, "value"));
        private ApiProperty<decimal> _value;
        public decimal ValueValue { get => Value.Value; set => Value.Value = value; }

        public ApiPropertyDateTime ExpectedCloseDate => _expectedCloseDate ?? (_expectedCloseDate = new ApiPropertyDateTime(this, "expected_close_date"));
        private ApiPropertyDateTime _expectedCloseDate;
        public DateTimeOffset ExpectedCloseDateValue { get => ExpectedCloseDate.Value; set => ExpectedCloseDate.Value = value; }

        public ApiProperty<int> ExpectedWinPercent => _expectedWinPercent ?? (_expectedWinPercent = new ApiProperty<int>(this, "expected_win_percent"));
        private ApiProperty<int> _expectedWinPercent;
        public int ExpectedWinPercentValue { get => ExpectedWinPercent.Value; set => ExpectedWinPercent.Value = value; }

        public ApiProperty<int> Calc => _calc ?? (_calc = new ApiProperty<int>(this, "calc"));
        private ApiProperty<int> _calc;
        public int CalcValue { get => Calc.Value; set => Calc.Value = value; }

        public ApiProperty<int> PrimaryContact => _primaryContact ?? (_primaryContact = new ApiProperty<int>(this, "primary_contact"));
        private ApiProperty<int> _primaryContact;
        public int PrimaryContactValue { get => PrimaryContact.Value; set => PrimaryContact.Value = value; }

        public ApiProperty<int> Company => _company ?? (_company = new ApiProperty<int>(this, "company"));
        private ApiProperty<int> _company;
        public int CompanyValue { get => Company.Value; set => Company.Value = value; }

        public ApiProperty<decimal> WeightedValue => _weightedValue ?? (_weightedValue = new ApiProperty<decimal>(this, "weighted_value"));
        private ApiProperty<decimal> _weightedValue;
        public decimal WeightedValueValue { get => WeightedValue.Value; set => WeightedValue.Value = value; }

        public ApiProperty<SaleStatus> SaleStage => _saleStage ?? (_saleStage = new ApiPropertyIntEnum<SaleStatus>(this, "sales_stage"));
        private ApiProperty<SaleStatus> _saleStage;
        public SaleStatus SaleStageValue { get => SaleStage.Value; set => SaleStage.Value = value; }

        public ApiPropertyDateTime ActualCloseDate => _actualCloseDate ?? (_actualCloseDate = new ApiPropertyDateTime(this, "actual_close_date"));
        private ApiPropertyDateTime _actualCloseDate;
        public DateTimeOffset ActualCloseDateValue { get => ActualCloseDate.Value; set => ActualCloseDate.Value = value; }

        // This is an enum.
        public ApiPropertyString ExpectedCloseTimeFrame => _expectedCloseTimeFrame ?? (_expectedCloseTimeFrame = new ApiPropertyString(this, "expected_close_timeframe"));
        private ApiPropertyString _expectedCloseTimeFrame;
        public string ExpectedCloseTimeFrameValue { get => ExpectedCloseTimeFrame.Value; set => ExpectedCloseTimeFrame.Value = value; }

        public ApiProperty<DealSizeEnum> DealSize => _dealSize ?? (_dealSize = new ApiPropertyIntEnum<DealSizeEnum>(this, "deal_size"));
        private ApiProperty<DealSizeEnum> _dealSize;
        public DealSizeEnum DealSizeValue { get => DealSize.Value; set => DealSize.Value = value; }

        public ApiPropertyDateTime RecentActivity => _recentActivity ?? (_recentActivity = new ApiPropertyDateTime(this, "recent_activity"));
        private ApiPropertyDateTime _recentActivity;
        public DateTimeOffset RecentActivityValue { get => RecentActivity.Value; set => RecentActivity.Value = value; }




        public enum DealSizeEnum
        {
            None = 0,
            Small = 1,
            Medium = 2,
            Large = 3
        }
    }
}
