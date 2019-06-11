using System;
using EmergenceGuardian.OntraportApi.Converters;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// Represents a coupon to provide discounts on purchases.
    /// </summary>
    public class ApiCoupon : ApiObject
    {
        public ApiPropertyString Name => _name ?? (_name = new ApiPropertyString(this, "name"));
        private ApiPropertyString _name;
        public string NameValue { get => Name.Value; set => Name.Value = value; }

        public ApiPropertyStringEnum<CouponType> Type => _type ?? (_type = new ApiPropertyStringEnum<CouponType>(this, "type"));
        private ApiPropertyStringEnum<CouponType> _type;
        public CouponType TypeValue { get => Type.Value; set => Type.Value = value; }

        public ApiPropertyInt Issued => _issued ?? (_issued = new ApiPropertyInt(this, "issued"));
        private ApiPropertyInt _issued;
        public int IssuedValue { get => Issued.Value; set => Issued.Value = value; }

        public ApiPropertyIntBool Redeemed => _redeemed ?? (_redeemed = new ApiPropertyIntBool(this, "redeemed"));
        private ApiPropertyIntBool _redeemed;
        public bool RedeemedValue { get => Redeemed.Value; set => Redeemed.Value = value; }

        public ApiPropertyInt Remaining => _remaining ?? (_remaining = new ApiPropertyInt(this, "remaining"));
        private ApiPropertyInt _remaining;
        public int RemainingValue { get => Remaining.Value; set => Remaining.Value = value; }

        public ApiPropertyDouble TotalCollected => _totalCollected ?? (_totalCollected = new ApiPropertyDouble(this, "total_collected"));
        private ApiPropertyDouble _totalCollected;
        public double TotalCollectedValue { get => TotalCollected.Value; set => TotalCollected.Value = value; }

        public ApiPropertyInt NewBuyers => _newBuyers ?? (_newBuyers = new ApiPropertyInt(this, "new_buyers"));
        private ApiPropertyInt _newBuyers;
        public int NewBuyersValue { get => NewBuyers.Value; set => NewBuyers.Value = value; }

        public ApiPropertyString ProductSelection => _productSelection ?? (_productSelection = new ApiPropertyString(this, "product_selection"));
        private ApiPropertyString _productSelection;
        public string ProductSelectionValue { get => ProductSelection.Value; set => ProductSelection.Value = value; }

        public ApiPropertyStringEnum<CouponDiscountType> DiscountType => _discountType ?? (_discountType = new ApiPropertyStringEnum<CouponDiscountType>(this, "discount_type"));
        private ApiPropertyStringEnum<CouponDiscountType> _discountType;
        public CouponDiscountType DiscountTypeValue { get => DiscountType.Value; set => DiscountType.Value = value; }

        public ApiPropertyDouble DiscountValue => _discountValue ?? (_discountValue = new ApiPropertyDouble(this, "discount_value"));
        private ApiPropertyDouble _discountValue;
        public double DiscountValueValue { get => DiscountValue.Value; set => DiscountValue.Value = value; }

        public ApiPropertyString DiscountDescription => _discountDescription ?? (_discountDescription = new ApiPropertyString(this, "discount_description"));
        private ApiPropertyString _discountDescription;
        public string DiscountDescriptionValue { get => DiscountDescription.Value; set => DiscountDescription.Value = value; }

        public ApiPropertyStringEnum<CouponValidType> ValidType => _validType ?? (_validType = new ApiPropertyStringEnum<CouponValidType>(this, "valid_type"));
        private ApiPropertyStringEnum<CouponValidType> _validType;
        public CouponValidType ValidTypeValue { get => ValidType.Value; set => ValidType.Value = value; }

        public ApiPropertyDateTime ValidStartDate => _validStartDate ?? (_validStartDate = new ApiPropertyDateTime(this, "valid_start_date"));
        private ApiPropertyDateTime _validStartDate;
        public DateTimeOffset ValidStartDateValue { get => ValidStartDate.Value; set => ValidStartDate.Value = value; }

        public ApiPropertyDateTime ValidEndDate => _validEndDate ?? (_validEndDate = new ApiPropertyDateTime(this, "valid_end_date"));
        private ApiPropertyDateTime _validEndDate;
        public DateTimeOffset ValidEndDateValue { get => ValidEndDate.Value; set => ValidEndDate.Value = value; }

        /// <summary>
        /// When ValidationType is Time, gets or sets for how many days the coupon is valid.
        /// </summary>
        public ApiPropertyInt ValidTimeframe => _validTimeframe ?? (_validTimeframe = new ApiPropertyInt(this, "valid_timeframe"));
        private ApiPropertyInt _validTimeframe;
        public int ValidTimeframeValue { get => ValidTimeframe.Value; set => ValidTimeframe.Value = value; }

        public ApiPropertyStringEnum<CouponStatus> Status => _status ?? (_status = new ApiPropertyStringEnum<CouponStatus>(this, "status"));
        private ApiPropertyStringEnum<CouponStatus> _status;
        public CouponStatus StatusValue { get => Status.Value; set => Status.Value = value; }

        public ApiPropertyDateTime DateCreated => _dateCreated ?? (_dateCreated = new ApiPropertyDateTime(this, "date"));
        private ApiPropertyDateTime _dateCreated;
        public DateTimeOffset DateCreatedValue { get => DateCreated.Value; set => DateCreated.Value = value; }

        public ApiPropertyIntBool Deleted => _deleted ?? (_deleted = new ApiPropertyIntBool(this, "deleted"));
        private ApiPropertyIntBool _deleted;
        public bool DeletedValue { get => Deleted.Value; set => Deleted.Value = value; }

        public ApiPropertyIntBool Recurring => _recurring ?? (_recurring = new ApiPropertyIntBool(this, "recurring"));
        private ApiPropertyIntBool _recurring;
        public bool RecurringValue { get => Recurring.Value; set => Recurring.Value = value; }

        public ApiPropertyString CouponCode => _couponCode ?? (_couponCode = new ApiPropertyString(this, "coupon_code"));
        private ApiPropertyString _couponCode;
        public string CouponCodeValue { get => CouponCode.Value; set => CouponCode.Value = value; }





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
            Invalid
        }
    }
}
