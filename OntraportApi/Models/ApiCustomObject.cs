using System;
using EmergenceGuardian.OntraportApi.Converters;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// Custom objects represent special types of objects created in the account that behave like Contacts and can have relationships.
    /// This type contains the name and structure of those objects, not the content of those objects.
    /// </summary>
    public class ApiCustomObject : ApiObject
    {
        public ApiPropertyString NameField => _nameField ?? (_nameField = new ApiPropertyString(this, NameKey));
        private ApiPropertyString _nameField;
        public const string NameKey = "name";
        public string NameValue { get => NameField.Value; set => NameField.Value = value; }

        public ApiPropertyDateTime DateCreatedField => _dateCreatedField ?? (_dateCreatedField = new ApiPropertyDateTime(this, DateCreatedKey));
        private ApiPropertyDateTime _dateCreatedField;
        public const string DateCreatedKey = "date_created";
        public DateTimeOffset? DateCreatedValue { get => DateCreatedField.Value; set => DateCreatedField.Value = value; }

        public ApiPropertyString TableField => _tableField ?? (_tableField = new ApiPropertyString(this, TableKey));
        private ApiPropertyString _tableField;
        public const string TableKey = "table";
        public string TableValue { get => TableField.Value; set => TableField.Value = value; }

        public ApiPropertyString KeyField => _keyField ?? (_keyField = new ApiPropertyString(this, KeyKey));
        private ApiPropertyString _keyField;
        public const string KeyKey = "key";
        public string KeyValue { get => KeyField.Value; set => KeyField.Value = value; }

        public ApiPropertyString ExternalKeyField => _externalKeyField ?? (_externalKeyField = new ApiPropertyString(this, ExternalKeyKey));
        private ApiPropertyString _externalKeyField;
        public const string ExternalKeyKey = "external_key";
        public string ExternalKeyValue { get => ExternalKeyField.Value; set => ExternalKeyField.Value = value; }

        public ApiPropertyIntBool PrimaryNavField => _primaryNavField ?? (_primaryNavField = new ApiPropertyIntBool(this, PrimaryNavKey));
        private ApiPropertyIntBool _primaryNavField;
        public const string PrimaryNavKey = "primary_nav";
        public bool? PrimaryNavValue { get => PrimaryNavField.Value; set => PrimaryNavField.Value = value; }

        public ApiPropertyString SingularField => _singularField ?? (_singularField = new ApiPropertyString(this, SingularKey));
        private ApiPropertyString _singularField;
        public const string SingularKey = "singular";
        public string SingularValue { get => SingularField.Value; set => SingularField.Value = value; }

        public ApiPropertyString PluralField => _pluralField ?? (_pluralField = new ApiPropertyString(this, PluralKey));
        private ApiPropertyString _pluralField;
        public const string PluralKey = "plural";
        public string PluralValue { get => PluralField.Value; set => PluralField.Value = value; }

        public ApiPropertyString PossessiveField => _possessiveField ?? (_possessiveField = new ApiPropertyString(this, PossessiveKey));
        private ApiPropertyString _possessiveField;
        public const string PossessiveKey = "possessive";
        public string PossessiveValue { get => PossessiveField.Value; set => PossessiveField.Value = value; }

        public ApiPropertyString PluralPossessiveField => _pluralPossessiveField ?? (_pluralPossessiveField = new ApiPropertyString(this, PluralPossessiveKey));
        private ApiPropertyString _pluralPossessiveField;
        public const string PluralPossessiveKey = "plural_possessive";
        public string PluralPossessiveValue { get => PluralPossessiveField.Value; set => PluralPossessiveField.Value = value; }

        public ApiPropertyString IconField => _iconField ?? (_iconField = new ApiPropertyString(this, IconKey));
        private ApiPropertyString _iconField;
        public const string IconKey = "icon";
        public string IconValue { get => IconField.Value; set => IconField.Value = value; }

        public ApiPropertyString ThemeField => _themeField ?? (_themeField = new ApiPropertyString(this, ThemeKey));
        private ApiPropertyString _themeField;
        public const string ThemeKey = "theme";
        public string ThemeValue { get => ThemeField.Value; set => ThemeField.Value = value; }

        public ApiPropertyIntBool DeletableField => _deletableField ?? (_deletableField = new ApiPropertyIntBool(this, DeletableKey));
        private ApiPropertyIntBool _deletableField;
        public const string DeletableKey = "deletable";
        public bool? DeletableValue { get => DeletableField.Value; set => DeletableField.Value = value; }

        public ApiPropertyString ObjectLabelField => _objectLabelField ?? (_objectLabelField = new ApiPropertyString(this, ObjectLabelKey));
        private ApiPropertyString _objectLabelField;
        public const string ObjectLabelKey = "object_label";
        public string ObjectLabelValue { get => ObjectLabelField.Value; set => ObjectLabelField.Value = value; }

    }
}
