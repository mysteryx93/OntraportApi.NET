using System;
using HanumanInstitute.OntraportApi.Converters;

namespace HanumanInstitute.OntraportApi.Models
{
    /// <summary>
    /// Represents a coupon to provide discounts on purchases.
    /// </summary>
    public class ApiCoupon : ApiObject
    {
        public ApiPropertyString NameField => _nameField ??= new ApiPropertyString(this, NameKey);
        private ApiPropertyString? _nameField;
        public const string NameKey = "name";
        public string Name { get => NameField.Value; set => NameField.Value = value; }

        public ApiPropertyStringEnum<CouponType> TypeField => _typeField ??= new ApiPropertyStringEnum<CouponType>(this, TypeKey);
        private ApiPropertyStringEnum<CouponType>? _typeField;
        public const string TypeKey = "type";
        public CouponType? Type { get => TypeField.Value; set => TypeField.Value = value; }

        public ApiProperty<int> IssuedField => _issuedField ??= new ApiProperty<int>(this, IssuedKey);
        private ApiProperty<int>? _issuedField;
        public const string IssuedKey = "issued";
        public int? Issued { get => IssuedField.Value; set => IssuedField.Value = value; }

        public ApiPropertyIntBool RedeemedField => _redeemedField ??= new ApiPropertyIntBool(this, RedeemedKey);
        private ApiPropertyIntBool? _redeemedField;
        public const string RedeemedKey = "redeemed";
        public bool? Redeemed { get => RedeemedField.Value; set => RedeemedField.Value = value; }

        public ApiProperty<int> RemainingField => _remainingField ??= new ApiProperty<int>(this, RemainingKey);
        private ApiProperty<int>? _remainingField;
        public const string RemainingKey = "remaining";
        public int? Remaining { get => RemainingField.Value; set => RemainingField.Value = value; }

        public ApiProperty<decimal> TotalCollectedField => _totalCollectedField ??= new ApiProperty<decimal>(this, TotalCollectedKey);
        private ApiProperty<decimal>? _totalCollectedField;
        public const string TotalCollectedKey = "total_collected";
        public decimal? TotalCollected { get => TotalCollectedField.Value; set => TotalCollectedField.Value = value; }

        public ApiProperty<int> NewBuyersField => _newBuyersField ??= new ApiProperty<int>(this, NewBuyersKey);
        private ApiProperty<int>? _newBuyersField;
        public const string NewBuyersKey = "new_buyers";
        public int? NewBuyers { get => NewBuyersField.Value; set => NewBuyersField.Value = value; }

        public ApiPropertyString ProductSelectionField => _productSelectionField ??= new ApiPropertyString(this, ProductSelectionKey);
        private ApiPropertyString? _productSelectionField;
        public const string ProductSelectionKey = "product_selection";
        public string ProductSelection { get => ProductSelectionField.Value; set => ProductSelectionField.Value = value; }

        public ApiPropertyStringEnum<CouponDiscountType> DiscountTypeField => _discountTypeField ??= new ApiPropertyStringEnum<CouponDiscountType>(this, DiscountTypeKey);
        private ApiPropertyStringEnum<CouponDiscountType>? _discountTypeField;
        public const string DiscountTypeKey = "discount_type";
        public CouponDiscountType? DiscountType { get => DiscountTypeField.Value; set => DiscountTypeField.Value = value; }

        public ApiProperty<decimal> DiscountValueField => _discountValueField ??= new ApiProperty<decimal>(this, DiscountValueKey);
        private ApiProperty<decimal>? _discountValueField;
        public const string DiscountValueKey = "discount_value";
        public decimal? DiscountValue { get => DiscountValueField.Value; set => DiscountValueField.Value = value; }

        public ApiPropertyString DiscountDescriptionField => _discountDescriptionField ??= new ApiPropertyString(this, DiscountDescriptionKey);
        private ApiPropertyString? _discountDescriptionField;
        public const string DiscountDescriptionKey = "discount_description";
        public string DiscountDescription { get => DiscountDescriptionField.Value; set => DiscountDescriptionField.Value = value; }

        public ApiPropertyStringEnum<CouponValidType> ValidTypeField => _validTypeField ??= new ApiPropertyStringEnum<CouponValidType>(this, ValidTypeKey);
        private ApiPropertyStringEnum<CouponValidType>? _validTypeField;
        public const string ValidTypeKey = "valid_type";
        public CouponValidType? ValidType { get => ValidTypeField.Value; set => ValidTypeField.Value = value; }

        public ApiPropertyDateTime ValidStartDateField => _validStartDateField ??= new ApiPropertyDateTime(this, ValidStartDateKey);
        private ApiPropertyDateTime? _validStartDateField;
        public const string ValidStartDateKey = "valid_start_date";
        public DateTimeOffset? ValidStartDate { get => ValidStartDateField.Value; set => ValidStartDateField.Value = value; }

        public ApiPropertyDateTime ValidEndDateField => _validEndDateField ??= new ApiPropertyDateTime(this, ValidEndDateKey);
        private ApiPropertyDateTime? _validEndDateField;
        public const string ValidEndDateKey = "valid_end_date";
        public DateTimeOffset? ValidEndDate { get => ValidEndDateField.Value; set => ValidEndDateField.Value = value; }

        /// <summary>
        /// When ValidationType is Time, gets or sets for how many days the coupon is valid.
        /// </summary>
        public ApiProperty<int> ValidTimeframeField => _validTimeframeField ??= new ApiProperty<int>(this, ValidTimeframeKey);
        private ApiProperty<int>? _validTimeframeField;
        public const string ValidTimeframeKey = "valid_timeframe";
        public int? ValidTimeframe { get => ValidTimeframeField.Value; set => ValidTimeframeField.Value = value; }

        public ApiPropertyStringEnum<CouponStatus> StatusField => _statusField ??= new ApiPropertyStringEnum<CouponStatus>(this, StatusKey);
        private ApiPropertyStringEnum<CouponStatus>? _statusField;
        public const string StatusKey = "status";
        public CouponStatus? Status { get => StatusField.Value; set => StatusField.Value = value; }

        public ApiPropertyDateTime DateCreatedField => _dateCreatedField ??= new ApiPropertyDateTime(this, DateCreatedKey);
        private ApiPropertyDateTime? _dateCreatedField;
        public const string DateCreatedKey = "date";
        public DateTimeOffset? DateCreated { get => DateCreatedField.Value; set => DateCreatedField.Value = value; }

        public ApiPropertyIntBool DeletedField => _deletedField ??= new ApiPropertyIntBool(this, DeletedKey);
        private ApiPropertyIntBool? _deletedField;
        public const string DeletedKey = "deleted";
        public bool? Deleted { get => DeletedField.Value; set => DeletedField.Value = value; }

        public ApiPropertyIntBool RecurringField => _recurringField ??= new ApiPropertyIntBool(this, RecurringKey);
        private ApiPropertyIntBool? _recurringField;
        public const string RecurringKey = "recurring";
        public bool? Recurring { get => RecurringField.Value; set => RecurringField.Value = value; }

        public ApiPropertyString CouponCodeField => _couponCodeField ??= new ApiPropertyString(this, CouponCodeKey);
        private ApiPropertyString? _couponCodeField;
        public const string CouponCodeKey = "coupon_code";
        public string CouponCode { get => CouponCodeField.Value; set => CouponCodeField.Value = value; }





        /// <summary>
        /// The type of coupon.
        /// </summary>
        public enum CouponType
        {
            Group,
            Personal
        }

        /// <summary>
        /// The type of coupon discount.
        /// </summary>
        public enum CouponDiscountType
        {
            Flat,
            Percent,
            Trial
        }

        /// <summary>
        /// The coupon validation type.
        /// </summary>
        public enum CouponValidType
        {
            Date,
            Time
        }

        /// <summary>
        /// The status of the coupon.
        /// </summary>
        public enum CouponStatus
        {
            Valid,
            NotValid,
            Expired,
            ReachedLimit
        }
    }
}
