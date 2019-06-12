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
        public ApiProperty<int> Owner => _owner ?? (_owner = new ApiProperty<int>(this, "owner"));
        private ApiProperty<int> _owner;
        /// <summary>
        /// Gets or sets the ID of the user who controls the product. This field must contain a value for a product object to be saved properly.
        /// </summary>
        public int OwnerValue { get => Owner.Value; set => Owner.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the product's name.
        /// </summary>
        public ApiPropertyString Name => _name ?? (_name = new ApiPropertyString(this, "name"));
        private ApiPropertyString _name;
        /// <summary>
        /// Gets or sets the product's name.
        /// </summary>
        public string NameValue { get => Name.Value; set => Name.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the product's price.
        /// </summary>
        public ApiProperty<decimal> Price => _price ?? (_price = new ApiProperty<decimal>(this, "price"));
        private ApiProperty<decimal> _price;
        /// <summary>
        /// Gets or sets the product's price.
        /// </summary>
        public decimal PriceValue { get => Price.Value; set => Price.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date the product was added.
        /// </summary>
        public ApiPropertyDateTime DateAdded => _dateAdded ?? (_dateAdded = new ApiPropertyDateTime(this, "date"));
        private ApiPropertyDateTime _dateAdded;
        /// <summary>
        /// Gets or sets the date the product was added.
        /// </summary>
        public DateTimeOffset DateAddedValue { get => DateAdded.Value; set => DateAdded.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date the product was last modified.
        /// </summary>
        public ApiPropertyDateTime DateLastModified => _dateLastModified ?? (_dateLastModified = new ApiPropertyDateTime(this, "dlm"));
        private ApiPropertyDateTime _dateLastModified;
        /// <summary>
        /// Gets or sets the date the product was last modified.
        /// </summary>
        public DateTimeOffset DateLastModifiedValue { get => DateLastModified.Value; set => DateLastModified.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set whether or not the product has been deleted.
        /// </summary>
        public ApiPropertyBool Deleted => _deleted ?? (_deleted = new ApiPropertyBool(this, "deleted"));
        private ApiPropertyBool _deleted;
        /// <summary>
        /// Gets or sets whether or not the product has been deleted.
        /// </summary>
        public bool DeletedValue { get => Deleted.Value; set => Deleted.Value = value; }

    }
}
