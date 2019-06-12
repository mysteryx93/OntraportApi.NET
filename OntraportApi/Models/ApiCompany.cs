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
        public ApiPropertyString Name => _name ?? (_name = new ApiPropertyString(this, "name"));
        private ApiPropertyString _name;
        /// <summary>
        /// Gets or sets the company's name.
        /// </summary>
        public string NameValue { get => Name.Value; set => Name.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the company's phone number.
        /// </summary>
        public ApiPropertyString Phone => _phone ?? (_phone = new ApiPropertyString(this, "phone"));
        private ApiPropertyString _phone;
        /// <summary>
        /// Gets or sets the company's phone number.
        /// </summary>
        public string PhoneValue { get => Phone.Value; set => Phone.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the company's industry.
        /// </summary>
        public ApiPropertyString Industry => _industry ?? (_industry = new ApiPropertyString(this, "industry"));
        private ApiPropertyString _industry;
        /// <summary>
        /// Gets or sets the company's industry.
        /// </summary>
        public string IndustryValue { get => Industry.Value; set => Industry.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the company's description.
        /// </summary>
        public ApiPropertyString Description => _description ?? (_description = new ApiPropertyString(this, "description"));
        private ApiPropertyString _description;
        /// <summary>
        /// Gets or sets the company's description.
        /// </summary>
        public string DescriptionValue { get => Description.Value; set => Description.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set how much the company earns in a year.
        /// </summary>
        public ApiProperty<int> AnnualRevenue => _annualRevenue ?? (_annualRevenue = new ApiProperty<int>(this, "annual_revenue"));
        private ApiProperty<int> _annualRevenue;
        /// <summary>
        /// Gets or sets how much the company earns in a year.
        /// </summary>
        public int AnnualRevenueValue { get => AnnualRevenue.Value; set => AnnualRevenue.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set how many employees are in the company.
        /// </summary>
        public ApiProperty<int> EmployeeCount => _employeeCount ?? (_employeeCount = new ApiProperty<int>(this, "employee_count"));
        private ApiProperty<int> _employeeCount;
        /// <summary>
        /// Gets or sets how many employees are in the company.
        /// </summary>
        public int EmployeeCountValue { get => EmployeeCount.Value; set => EmployeeCount.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the company's Facebook page URL.
        /// </summary>
        public ApiPropertyString FacebookPage => _facebookPage ?? (_facebookPage = new ApiPropertyString(this, "facebook_page"));
        private ApiPropertyString _facebookPage;
        /// <summary>
        /// Gets or sets the company's Facebook page URL.
        /// </summary>
        public string FacebookPageValue { get => FacebookPage.Value; set => FacebookPage.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the company's Instagram username.
        /// </summary>
        public ApiPropertyString InstagramName => _instagramName ?? (_instagramName = new ApiPropertyString(this, "instagram_name"));
        private ApiPropertyString _instagramName;
        /// <summary>
        /// Gets or sets the company's Instagram username.
        /// </summary>
        public string InstagramNameValue { get => InstagramName.Value; set => InstagramName.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the company's postal address.
        /// </summary>
        public ApiPropertyString Address => _address ?? (_address = new ApiPropertyString(this, "address"));
        private ApiPropertyString _address;
        /// <summary>
        /// Gets or sets the company's postal address.
        /// </summary>
        public string AddressValue { get => Address.Value; set => Address.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the company's city.
        /// </summary>
        public ApiPropertyString City => _city ?? (_city = new ApiPropertyString(this, "city"));
        private ApiPropertyString _city;
        /// <summary>
        /// Gets or sets the company's city.
        /// </summary>
        public string CityValue { get => City.Value; set => City.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the company's state.
        /// </summary>
        public ApiPropertyString State => _state ?? (_state = new ApiPropertyString(this, "state"));
        private ApiPropertyString _state;
        /// <summary>
        /// Gets or sets the company's state.
        /// </summary>
        public string StateValue { get => State.Value; set => State.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the company's postal code.
        /// </summary>
        public ApiPropertyString Zip => _zip ?? (_zip = new ApiPropertyString(this, "zipcode"));
        private ApiPropertyString _zip;
        /// <summary>
        /// Gets or sets the company's postal code.
        /// </summary>
        public string ZipValue { get => Zip.Value; set => Zip.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the company's country.
        /// </summary>
        public ApiPropertyString Country => _country ?? (_country = new ApiPropertyString(this, "country"));
        private ApiPropertyString _country;
        /// <summary>
        /// Gets or sets the company's country.
        /// </summary>
        public string CountryValue { get => Country.Value; set => Country.Value = value; }

    }
}
