using System;
using EmergenceGuardian.OntraportApi.Converters;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// Offer objects allow you to save the details of products, quantities, and prices of frequently used transactions as offers for rapid processing with other Contacts.
    /// </summary>
    public class ApiOffer : ApiObject
    {
        /// <summary>
        /// Returns a ApiProperty object to get or set the ID of the user who controls the offer. This field must contain a value for an offer object to be saved properly.
        /// </summary>
        public ApiProperty<int> Owner => _owner ?? (_owner = new ApiProperty<int>(this, "owner"));
        private ApiProperty<int> _owner;
        /// <summary>
        /// Gets or sets the ID of the user who controls the offer. This field must contain a value for an offer object to be saved properly.
        /// </summary>
        public int OwnerValue { get => Owner.Value; set => Owner.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the offer's name.
        /// </summary>
        public ApiPropertyString Name => _name ?? (_name = new ApiPropertyString(this, "name"));
        private ApiPropertyString _name;
        /// <summary>
        /// Gets or sets the offer's name.
        /// </summary>
        public string NameValue { get => Name.Value; set => Name.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set whether the offer is accessible for processing manual transactions. 
        /// </summary>
        public ApiPropertyIntBool Public => _public ?? (_public = new ApiPropertyIntBool(this, "public"));
        private ApiPropertyIntBool _public;
        /// <summary>
        /// Gets or sets whether the offer is accessible for processing manual transactions. 
        /// </summary>
        public bool PublicValue { get => Public.Value; set => Public.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set a json encoded string containing an offer's data.
        /// </summary>
        public ApiPropertyString Content => _data ?? (_data = new ApiPropertyString(this, "data"));
        private ApiPropertyString _data;
        /// <summary>
        /// Gets or sets a json encoded string containing an offer's data.
        /// </summary>
        public string ContentValue { get => Content.Value; set => Content.Value = value; }

    }
}
