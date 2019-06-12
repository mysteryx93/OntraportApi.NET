using System;
using EmergenceGuardian.OntraportApi.Converters;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// Represents the code of a coupon.
    /// </summary>
    public class ApiCouponCode : ApiObject
    {
        public ApiProperty<int> CouponId => _couponId ?? (_couponId = new ApiProperty<int>(this, "coupon_id"));
        private ApiProperty<int> _couponId;
        public int CouponIdValue { get => CouponId.Value; set => CouponId.Value = value; }

        public ApiProperty<int> ContactId => _contactId ?? (_contactId = new ApiProperty<int>(this, "contact_id"));
        private ApiProperty<int> _contactId;
        public int ContactIdValue { get => ContactId.Value; set => ContactId.Value = value; }

        public ApiPropertyString Code => _code ?? (_code = new ApiPropertyString(this, "code"));
        private ApiPropertyString _code;
        public string CodeValue { get => Code.Value; set => Code.Value = value; }

        public ApiPropertyDateTime Expiration => _expiration ?? (_expiration = new ApiPropertyDateTime(this, "expiration"));
        private ApiPropertyDateTime _expiration;
        public DateTimeOffset ExpirationValue { get => Expiration.Value; set => Expiration.Value = value; }

        public ApiPropertyDateTime DateCreated => _dateCreated ?? (_dateCreated = new ApiPropertyDateTime(this, "date"));
        private ApiPropertyDateTime _dateCreated;
        public DateTimeOffset DateCreatedValue { get => DateCreated.Value; set => DateCreated.Value = value; }

        public ApiPropertyDateTime DateRedeemed => _dateRedeemed ?? (_dateRedeemed = new ApiPropertyDateTime(this, "date_redeemed"));
        private ApiPropertyDateTime _dateRedeemed;
        public DateTimeOffset DateRedeemedValue { get => DateRedeemed.Value; set => DateRedeemed.Value = value; }

        public ApiPropertyIntBool Deleted => _deleted ?? (_deleted = new ApiPropertyIntBool(this, "deleted"));
        private ApiPropertyIntBool _deleted;
        public bool DeletedValue { get => Deleted.Value; set => Deleted.Value = value; }

    }
}
