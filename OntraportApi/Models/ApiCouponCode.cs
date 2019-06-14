using System;
using EmergenceGuardian.OntraportApi.Converters;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// Represents the code of a coupon.
    /// </summary>
    public class ApiCouponCode : ApiObject
    {
        public ApiProperty<int> CouponIdField => _couponIdField ?? (_couponIdField = new ApiProperty<int>(this, CouponIdKey));
        private ApiProperty<int> _couponIdField;
        public const string CouponIdKey = "coupon_id";
        public int? CouponId { get => CouponIdField.Value; set => CouponIdField.Value = value; }

        public ApiProperty<int> ContactIdField => _contactIdField ?? (_contactIdField = new ApiProperty<int>(this, ContactIdKey));
        private ApiProperty<int> _contactIdField;
        public const string ContactIdKey = "contact_id";
        public int? ContactId { get => ContactIdField.Value; set => ContactIdField.Value = value; }

        public ApiPropertyString CodeField => _codeField ?? (_codeField = new ApiPropertyString(this, CodeKey));
        private ApiPropertyString _codeField;
        public const string CodeKey = "code";
        public string Code { get => CodeField.Value; set => CodeField.Value = value; }

        public ApiPropertyDateTime ExpirationField => _expirationField ?? (_expirationField = new ApiPropertyDateTime(this, ExpirationKey));
        private ApiPropertyDateTime _expirationField;
        public const string ExpirationKey = "expiration";
        public DateTimeOffset? Expiration { get => ExpirationField.Value; set => ExpirationField.Value = value; }

        public ApiPropertyDateTime DateCreatedField => _dateCreatedField ?? (_dateCreatedField = new ApiPropertyDateTime(this, DateCreatedKey));
        private ApiPropertyDateTime _dateCreatedField;
        public const string DateCreatedKey = "date";
        public DateTimeOffset? DateCreated { get => DateCreatedField.Value; set => DateCreatedField.Value = value; }

        public ApiPropertyDateTime DateRedeemedField => _dateRedeemedField ?? (_dateRedeemedField = new ApiPropertyDateTime(this, DateRedeemedKey));
        private ApiPropertyDateTime _dateRedeemedField;
        public const string DateRedeemedKey = "date_redeemed";
        public DateTimeOffset? DateRedeemed { get => DateRedeemedField.Value; set => DateRedeemedField.Value = value; }

        public ApiPropertyIntBool DeletedField => _deletedField ?? (_deletedField = new ApiPropertyIntBool(this, DeletedKey));
        private ApiPropertyIntBool _deletedField;
        public const string DeletedKey = "deleted";
        public bool? Deleted { get => DeletedField.Value; set => DeletedField.Value = value; }

    }
}
