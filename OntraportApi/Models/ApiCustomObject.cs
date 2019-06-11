using System;
using System.Collections.Generic;
using System.Text;
using EmergenceGuardian.OntraportApi.Converters;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// Custom objects represent special types of objects created in the account that behave like Contacts and can have relationships.
    /// This type contains the name and structure of those objects, not the content of those objects.
    /// </summary>
    public class ApiCustomObject : ApiObject
    {
        public ApiPropertyString Name => _name ?? (_name = new ApiPropertyString(this, "name"));
        private ApiPropertyString _name;
        public string NameValue { get => Name.Value; set => Name.Value = value; }

        public ApiPropertyDateTime DateCreated => _dateCreated ?? (_dateCreated = new ApiPropertyDateTime(this, "date_created"));
        private ApiPropertyDateTime _dateCreated;
        public DateTimeOffset DateCreatedValue { get => DateCreated.Value; set => DateCreated.Value = value; }

        public ApiPropertyString Table => _table ?? (_table = new ApiPropertyString(this, "table"));
        private ApiPropertyString _table;
        public string TableValue { get => Table.Value; set => Table.Value = value; }

        public ApiPropertyString Key => _key ?? (_key = new ApiPropertyString(this, "key"));
        private ApiPropertyString _key;
        public string KeyValue { get => Key.Value; set => Key.Value = value; }

        public ApiPropertyString ExternalKey => _externalKey ?? (_externalKey = new ApiPropertyString(this, "external_key"));
        private ApiPropertyString _externalKey;
        public string ExternalKeyValue { get => ExternalKey.Value; set => ExternalKey.Value = value; }

        public ApiPropertyIntBool PrimaryNav => _primaryNav ?? (_primaryNav = new ApiPropertyIntBool(this, "primary_nav"));
        private ApiPropertyIntBool _primaryNav;
        public bool PrimaryNavValue { get => PrimaryNav.Value; set => PrimaryNav.Value = value; }

        public ApiPropertyString Singular => _singular ?? (_singular = new ApiPropertyString(this, "singular"));
        private ApiPropertyString _singular;
        public string SingularValue { get => Singular.Value; set => Singular.Value = value; }

        public ApiPropertyString Plural => _plural ?? (_plural = new ApiPropertyString(this, "plural"));
        private ApiPropertyString _plural;
        public string PluralValue { get => Plural.Value; set => Plural.Value = value; }

        public ApiPropertyString Possessive => _possessive ?? (_possessive = new ApiPropertyString(this, "possessive"));
        private ApiPropertyString _possessive;
        public string PossessiveValue { get => Possessive.Value; set => Possessive.Value = value; }

        public ApiPropertyString PluralPossessive => _pluralPossessive ?? (_pluralPossessive = new ApiPropertyString(this, "plural_possessive"));
        private ApiPropertyString _pluralPossessive;
        public string PluralPossessiveValue { get => PluralPossessive.Value; set => PluralPossessive.Value = value; }

        public ApiPropertyString Icon => _icon ?? (_icon = new ApiPropertyString(this, "icon"));
        private ApiPropertyString _icon;
        public string IconValue { get => Icon.Value; set => Icon.Value = value; }

        public ApiPropertyString Theme => _theme ?? (_theme = new ApiPropertyString(this, "theme"));
        private ApiPropertyString _theme;
        public string ThemeValue { get => Theme.Value; set => Theme.Value = value; }

        public ApiPropertyIntBool Deletable => _deletable ?? (_deletable = new ApiPropertyIntBool(this, "deletable"));
        private ApiPropertyIntBool _deletable;
        public bool DeletableValue { get => Deletable.Value; set => Deletable.Value = value; }

        public ApiPropertyString ObjectLabel => _objectLabel ?? (_objectLabel = new ApiPropertyString(this, "object_label"));
        private ApiPropertyString _objectLabel;
        public string ObjectLabelValue { get => ObjectLabel.Value; set => ObjectLabel.Value = value; }

    }
}
