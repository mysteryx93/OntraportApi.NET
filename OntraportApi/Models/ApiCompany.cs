using System;
using System.Collections.Generic;
using System.Text;
using EmergenceGuardian.OntraportApi.Converters;

namespace EmergenceGuardian.OntraportApi.Models
{
    public class ApiCompany : ApiCustomObjectBase
    {
        /// <summary>
        /// Returns a ApiProperty object to get or set the company's name.
        /// </summary>
        public ApiPropertyString NameField => _nameField ?? (_nameField = new ApiPropertyString(this, NameKey));
        private ApiPropertyString _nameField;
        public const string NameKey = "name";
        /// <summary>
        /// Gets or sets the company's name.
        /// </summary>
        public string Name { get => NameField.Value; set => NameField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the company's phone number.
        /// </summary>
        public ApiPropertyString PhoneField => _phoneField ?? (_phoneField = new ApiPropertyString(this, PhoneKey));
        private ApiPropertyString _phoneField;
        public const string PhoneKey = "phone";
        /// <summary>
        /// Gets or sets the company's phone number.
        /// </summary>
        public string Phone { get => PhoneField.Value; set => PhoneField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the company's industry.
        /// </summary>
        public ApiPropertyString IndustryField => _industryField ?? (_industryField = new ApiPropertyString(this, IndustryKey));
        private ApiPropertyString _industryField;
        public const string IndustryKey = "industry";
        /// <summary>
        /// Gets or sets the company's industry.
        /// </summary>
        public string Industry { get => IndustryField.Value; set => IndustryField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the company's description.
        /// </summary>
        public ApiPropertyString DescriptionField => _descriptionField ?? (_descriptionField = new ApiPropertyString(this, DescriptionKey));
        private ApiPropertyString _descriptionField;
        public const string DescriptionKey = "description";
        /// <summary>
        /// Gets or sets the company's description.
        /// </summary>
        public string Description { get => DescriptionField.Value; set => DescriptionField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set how much the company earns in a year.
        /// </summary>
        public ApiProperty<int> AnnualRevenueField => _annualRevenueField ?? (_annualRevenueField = new ApiProperty<int>(this, AnnualRevenueKey));
        private ApiProperty<int> _annualRevenueField;
        public const string AnnualRevenueKey = "annual_revenue";
        /// <summary>
        /// Gets or sets how much the company earns in a year.
        /// </summary>
        public int? AnnualRevenue { get => AnnualRevenueField.Value; set => AnnualRevenueField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set how many employees are in the company.
        /// </summary>
        public ApiProperty<int> EmployeeCountField => _employeeCountField ?? (_employeeCountField = new ApiProperty<int>(this, EmployeeCountKey));
        private ApiProperty<int> _employeeCountField;
        public const string EmployeeCountKey = "employee_count";
        /// <summary>
        /// Gets or sets how many employees are in the company.
        /// </summary>
        public int? EmployeeCount { get => EmployeeCountField.Value; set => EmployeeCountField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the company's Facebook page URL.
        /// </summary>
        public ApiPropertyString FacebookPageField => _facebookPageField ?? (_facebookPageField = new ApiPropertyString(this, FacebookPageKey));
        private ApiPropertyString _facebookPageField;
        public const string FacebookPageKey = "facebook_page";
        /// <summary>
        /// Gets or sets the company's Facebook page URL.
        /// </summary>
        public string FacebookPage { get => FacebookPageField.Value; set => FacebookPageField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the company's Instagram username.
        /// </summary>
        public ApiPropertyString InstagramNameField => _instagramNameField ?? (_instagramNameField = new ApiPropertyString(this, InstagramNameKey));
        private ApiPropertyString _instagramNameField;
        public const string InstagramNameKey = "instagram_name";
        /// <summary>
        /// Gets or sets the company's Instagram username.
        /// </summary>
        public string InstagramName { get => InstagramNameField.Value; set => InstagramNameField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the company's postal address.
        /// </summary>
        public ApiPropertyString AddressField => _addressField ?? (_addressField = new ApiPropertyString(this, AddressKey));
        private ApiPropertyString _addressField;
        public const string AddressKey = "address";
        /// <summary>
        /// Gets or sets the company's postal address.
        /// </summary>
        public string Address { get => AddressField.Value; set => AddressField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the company's city.
        /// </summary>
        public ApiPropertyString CityField => _cityField ?? (_cityField = new ApiPropertyString(this, CityKey));
        private ApiPropertyString _cityField;
        public const string CityKey = "city";
        /// <summary>
        /// Gets or sets the company's city.
        /// </summary>
        public string City { get => CityField.Value; set => CityField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the company's state.
        /// </summary>
        public ApiPropertyString StateField => _stateField ?? (_stateField = new ApiPropertyString(this, StateKey));
        private ApiPropertyString _stateField;
        public const string StateKey = "state";
        /// <summary>
        /// Gets or sets the company's state.
        /// </summary>
        public string State { get => StateField.Value; set => StateField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the company's postal code.
        /// </summary>
        public ApiPropertyString ZipField => _zipField ?? (_zipField = new ApiPropertyString(this, ZipKey));
        private ApiPropertyString _zipField;
        public const string ZipKey = "zipcode";
        /// <summary>
        /// Gets or sets the company's postal code.
        /// </summary>
        public string Zip { get => ZipField.Value; set => ZipField.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the company's country.
        /// </summary>
        public ApiPropertyString CountryField => _countryField ?? (_countryField = new ApiPropertyString(this, CountryKey));
        private ApiPropertyString _countryField;
        public const string CountryKey = "country";
        /// <summary>
        /// Gets or sets the company's country.
        /// </summary>
        public string Country { get => CountryField.Value; set => CountryField.Value = value; }

    }
}
