using System;
using EmergenceGuardian.OntraportApi.Converters;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// Product objects allow you to process transactions and order forms. 
    /// </summary>
    public class ApiProduct : ApiObject
    {
        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the user who controls the product. This field must contain a value for a product object to be saved properly.
        /// </summary>
        public ApiProperty<int> OwnerField => _ownerField ?? (_ownerField = new ApiProperty<int>(this, OwnerKey));
        private ApiProperty<int> _ownerField;
        public const string OwnerKey = "owner";
        /// <summary>
        /// Gets or sets the ID of the user who controls the product. This field must contain a value for a product object to be saved properly.
        /// </summary>
        public int? Owner { get => OwnerField.Value; set => OwnerField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the product's name.
        /// </summary>
        public ApiPropertyString NameField => _nameField ?? (_nameField = new ApiPropertyString(this, NameKey));
        private ApiPropertyString _nameField;
        public const string NameKey = "name";
        /// <summary>
        /// Gets or sets the product's name.
        /// </summary>
        public string Name { get => NameField.Value; set => NameField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the product's price.
        /// </summary>
        public ApiProperty<decimal> PriceField => _priceField ?? (_priceField = new ApiProperty<decimal>(this, PriceKey));
        private ApiProperty<decimal> _priceField;
        public const string PriceKey = "price";
        /// <summary>
        /// Gets or sets the product's price.
        /// </summary>
        public decimal? Price { get => PriceField.Value; set => PriceField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date the product was added.
        /// </summary>
        public ApiPropertyDateTime DateAddedField => _dateAddedField ?? (_dateAddedField = new ApiPropertyDateTime(this, DateAddedKey));
        private ApiPropertyDateTime _dateAddedField;
        public const string DateAddedKey = "date";
        /// <summary>
        /// Gets or sets the date the product was added.
        /// </summary>
        public DateTimeOffset? DateAdded { get => DateAddedField.Value; set => DateAddedField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date the product was last modified.
        /// </summary>
        public ApiPropertyDateTime DateLastModifiedField => _dateLastModifiedField ?? (_dateLastModifiedField = new ApiPropertyDateTime(this, DateLastModifiedKey));
        private ApiPropertyDateTime _dateLastModifiedField;
        public const string DateLastModifiedKey = "dlm";
        /// <summary>
        /// Gets or sets the date the product was last modified.
        /// </summary>
        public DateTimeOffset? DateLastModified { get => DateLastModifiedField.Value; set => DateLastModifiedField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set whether or not the product has been deleted.
        /// </summary>
        public ApiPropertyBool DeletedField => _deletedField ?? (_deletedField = new ApiPropertyBool(this, DeletedKey));
        private ApiPropertyBool _deletedField;
        public const string DeletedKey = "deleted";
        /// <summary>
        /// Gets or sets whether or not the product has been deleted.
        /// </summary>
        public bool? Deleted { get => DeletedField.Value; set => DeletedField.Value = value; }

    }
}
