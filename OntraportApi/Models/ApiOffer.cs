using System;
using HanumanInstitute.OntraportApi.Converters;

namespace HanumanInstitute.OntraportApi.Models
{
    /// <summary>
    /// Offer objects allow you to save the details of products, quantities, and prices of frequently used transactions as offers for rapid processing with other Contacts.
    /// </summary>
    public class ApiOffer : ApiObject
    {
        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the user who controls the offer. This field must contain a value for an offer object to be saved properly.
        /// </summary>
        public ApiProperty<int> OwnerField => _ownerField ??= new ApiProperty<int>(this, OwnerKey);
        private ApiProperty<int>? _ownerField;
        public const string OwnerKey = "owner";
        /// <summary>
        /// Gets or sets the ID of the user who controls the offer. This field must contain a value for an offer object to be saved properly.
        /// </summary>
        public int? Owner { get => OwnerField.Value; set => OwnerField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the offer's name.
        /// </summary>
        public ApiPropertyString NameField => _nameField ??= new ApiPropertyString(this, NameKey);
        private ApiPropertyString? _nameField;
        public const string NameKey = "name";
        /// <summary>
        /// Gets or sets the offer's name.
        /// </summary>
        public string? Name { get => NameField.Value; set => NameField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set whether the offer is accessible for processing manual transactions. 
        /// </summary>
        public ApiPropertyIntBool PublicField => _publicField ??= new ApiPropertyIntBool(this, PublicKey);
        private ApiPropertyIntBool? _publicField;
        public const string PublicKey = "public";
        /// <summary>
        /// Gets or sets whether the offer is accessible for processing manual transactions. 
        /// </summary>
        public bool? Public { get => PublicField.Value; set => PublicField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set a json encoded string containing an offer's data.
        /// </summary>
        public ApiPropertyString ContentField => _contentField ??= new ApiPropertyString(this, ContentKey);
        private ApiPropertyString? _contentField;
        public const string ContentKey = "data";
        /// <summary>
        /// Gets or sets a json encoded string containing an offer's data.
        /// </summary>
        public string? Content { get => ContentField.Value; set => ContentField.Value = value; }

        public ApiProperty<int> ReferencedField => _referencedField ??= new ApiProperty<int>(this, ReferencedKey);
        private ApiProperty<int>? _referencedField;
        public const string ReferencedKey = "referenced";
        public int? Referenced { get => ReferencedField.Value; set => ReferencedField.Value = value; }

    }
}
