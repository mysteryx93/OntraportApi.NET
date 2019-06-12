using System;
using EmergenceGuardian.OntraportApi.Converters;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// Landing page objects contain the data for one-off web pages a prospect can land on after clicking on an online marketing call-to-action.
    /// </summary>
    public class ApiLandingPage : ApiObject
    {
        /// <summary>
        /// Returns a ApiProperty object to get or set the hosted URL's ID.
        /// </summary>
        public ApiProperty<int> UriId => _uriId ?? (_uriId = new ApiProperty<int>(this, "uri_id"));
        private ApiProperty<int> _uriId;
        /// <summary>
        /// Gets or sets the hosted URL's ID.
        /// </summary>
        public int UriIdValue { get=> UriId.Value; set => UriId.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the JSON encoded data containing the entire structure of the landing page.
        /// </summary>
        public ApiPropertyString Resource => _resource ?? (_resource = new ApiPropertyString(this, "resource"));
        private ApiPropertyString _resource;
        /// <summary>
        /// Gets or sets the JSON encoded data containing the entire structure of the landing page.
        /// </summary>
        public string ResourceValue { get=> Resource.Value; set => Resource.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the landing page's design type.
        /// </summary>
        public ApiProperty<PageDesignType> DesignType => _designType ?? (_designType = new ApiPropertyIntEnum<PageDesignType>(this, "design_type"));
        private ApiProperty<PageDesignType> _designType;
        /// <summary>
        /// Gets or sets the landing page's design type.
        /// </summary>
        public PageDesignType DesignTypeValue { get=> DesignType.Value; set => DesignType.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the landing page's name.
        /// </summary>
        public ApiPropertyString Name => _name ?? (_name = new ApiPropertyString(this, "name"));
        private ApiPropertyString _name;
        /// <summary>
        /// Gets or sets the landing page's name.
        /// </summary>
        public string NameValue { get=> Name.Value; set => Name.Value = value; }

        /// <summary>
        /// If using split testing, returns a ApiProperty object to get or set the ID of the next split test in line for rotation.
        /// </summary>
        public ApiProperty<int> Rotation => _rotation ?? (_rotation = new ApiProperty<int>(this, "rotation"));
        private ApiProperty<int> _rotation;
        /// <summary>
        /// If using split testing, gets or sets the ID of the next split test in line for rotation.
        /// </summary>
        public int RotationValue { get=> Rotation.Value; set => Rotation.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the last time the landing page was manually saved.
        /// </summary>
        public ApiPropertyDateTime LastSaveTime => _lastSaveTime ?? (_lastSaveTime = new ApiPropertyDateTime(this, "last_save"));
        private ApiPropertyDateTime _lastSaveTime;
        /// <summary>
        /// Gets or sets the last time the landing page was manually saved.
        /// </summary>
        public DateTimeOffset LastSaveTimeValue { get=> LastSaveTime.Value; set => LastSaveTime.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the last time the landing page was automatically saved.
        /// </summary>
        public ApiPropertyDateTime LastAutoSaveTime => _lastAutoSaveTime ?? (_lastAutoSaveTime = new ApiPropertyDateTime(this, "last_auto"));
        private ApiPropertyDateTime _lastAutoSaveTime;
        /// <summary>
        /// Gets or sets the last time the landing page was automatically saved.
        /// </summary>
        public DateTimeOffset LastAutoSaveTimeValue { get=> LastAutoSaveTime.Value; set => LastAutoSaveTime.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the content of the last autosave.
        /// </summary>
        public ApiPropertyString AutoSaveContent => _autoSaveContent ?? (_autoSaveContent = new ApiPropertyString(this, "autosave"));
        private ApiPropertyString _autoSaveContent;
        /// <summary>
        /// Gets or sets the content of the last autosave.
        /// </summary>
        public string AutoSaveContentValue { get=> AutoSaveContent.Value; set => AutoSaveContent.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set count of visits for split test A.
        /// </summary>
        public ApiProperty<int> Visits0 => _visits0 ?? (_visits0 = new ApiProperty<int>(this, "visits_0"));
        private ApiProperty<int> _visits0;
        /// <summary>
        /// Gets or sets count of visits for split test A.
        /// </summary>
        public int Visits0Value { get=> Visits0.Value; set => Visits0.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the count of visits for split test B.
        /// </summary>
        public ApiProperty<int> Visits1 => _visits1 ?? (_visits1 = new ApiProperty<int>(this, "visits_1"));
        private ApiProperty<int> _visits1;
        /// <summary>
        /// Gets or sets the count of visits for split test B.
        /// </summary>
        public int Visits1Value { get=> Visits1.Value; set => Visits1.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the count of visits for split test C.
        /// </summary>
        public ApiProperty<int> Visits2 => _visits2 ?? (_visits2 = new ApiProperty<int>(this, "visits_2"));
        private ApiProperty<int> _visits2;
        /// <summary>
        /// Gets or sets the count of visits for split test C.
        /// </summary>
        public int Visits2Value { get=> Visits2.Value; set => Visits2.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the count of visits for split test D.
        /// </summary>
        public ApiProperty<int> Visits3 => _visits3 ?? (_visits3 = new ApiProperty<int>(this, "visits_3"));
        private ApiProperty<int> _visits3;
        /// <summary>
        /// Gets or sets the count of visits for split test D.
        /// </summary>
        public int Visits3Value { get=> Visits3.Value; set => Visits3.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the URL where the landing page is hosted.
        /// </summary>
        public ApiPropertyString Domain => _domain ?? (_domain = new ApiPropertyString(this, "domain"));
        private ApiPropertyString _domain;
        /// <summary>
        /// Gets or sets the URL where the landing page is hosted.
        /// </summary>
        public string DomainValue { get=> Domain.Value; set => Domain.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set whether or not ssl certification is enabled.
        /// </summary>
        public ApiPropertyIntBool SslEnabled => _sslEnabled ?? (_sslEnabled = new ApiPropertyIntBool(this, "ssl_enabled"));
        private ApiPropertyIntBool _sslEnabled;
        /// <summary>
        /// Gets or sets whether or not ssl certification is enabled.
        /// </summary>
        public bool SslEnabledValue { get=> SslEnabled.Value; set => SslEnabled.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the date the landing page was created.
        /// </summary>
        public ApiPropertyDateTime DateCreated => _dateCreated ?? (_dateCreated = new ApiPropertyDateTime(this, "date"));
        private ApiPropertyDateTime _dateCreated;
        /// <summary>
        /// Gets or sets the date the landing page was created.
        /// </summary>
        public DateTimeOffset DateCreatedValue { get=> DateCreated.Value; set => DateCreated.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the data and time the landing page was last modified.
        /// </summary>
        public ApiPropertyDateTime DateLastModified => _dateLastModified ?? (_dateLastModified = new ApiPropertyDateTime(this, "dlm"));
        private ApiPropertyDateTime _dateLastModified;
        /// <summary>
        /// Gets or sets the data and time the landing page was last modified.
        /// </summary>
        public DateTimeOffset DateLastModifiedValue { get=> DateLastModified.Value; set => DateLastModified.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the count of unique visits for split test A.
        /// </summary>
        public ApiProperty<int> UniqueVisits0 => _uniqueVisits0 ?? (_uniqueVisits0 = new ApiProperty<int>(this, "unique_visits_0"));
        private ApiProperty<int> _uniqueVisits0;
        /// <summary>
        /// Gets or sets the count of unique visits for split test A.
        /// </summary>
        public int UniqueVisits0Value { get=> UniqueVisits0.Value; set => UniqueVisits0.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the count of unique visits for split test B.
        /// </summary>
        public ApiProperty<int> UniqueVisits1 => _uniqueVisits1 ?? (_uniqueVisits1 = new ApiProperty<int>(this, "unique_visits_1"));
        private ApiProperty<int> _uniqueVisits1;
        /// <summary>
        /// Gets or sets the count of unique visits for split test B.
        /// </summary>
        public int UniqueVisits1Value { get=> UniqueVisits1.Value; set => UniqueVisits1.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the count of unique visits for split test C.
        /// </summary>
        public ApiProperty<int> UniqueVisits2 => _uniqueVisits2 ?? (_uniqueVisits2 = new ApiProperty<int>(this, "unique_visits_2"));
        private ApiProperty<int> _uniqueVisits2;
        /// <summary>
        /// Gets or sets the count of unique visits for split test C.
        /// </summary>
        public int UniqueVisits2Value { get=> UniqueVisits2.Value; set => UniqueVisits2.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the count of unique visits for split test D.
        /// </summary>
        public ApiProperty<int> UniqueVisits3 => _uniqueVisits3 ?? (_uniqueVisits3 = new ApiProperty<int>(this, "unique_visits_3"));
        private ApiProperty<int> _uniqueVisits3;
        /// <summary>
        /// Gets or sets the count of unique visits for split test D.
        /// </summary>
        public int UniqueVisits3Value { get=> UniqueVisits3.Value; set => UniqueVisits3.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the count of converts for split test A.
        /// </summary>
        public ApiProperty<int> Convert0 => _convert0 ?? (_convert0 = new ApiProperty<int>(this, "convert_0"));
        private ApiProperty<int> _convert0;
        /// <summary>
        /// Gets or sets the count of converts for split test A.
        /// </summary>
        public int Convert0Value { get=> Convert0.Value; set => Convert0.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the count of converts for split test B.
        /// </summary>
        public ApiProperty<int> Convert1 => _convert1 ?? (_convert1 = new ApiProperty<int>(this, "convert_1"));
        private ApiProperty<int> _convert1;
        /// <summary>
        /// Gets or sets the count of converts for split test B.
        /// </summary>
        public int Convert1Value { get=> Convert1.Value; set => Convert1.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the count of converts for split test C.
        /// </summary>
        public ApiProperty<int> Convert2 => _convert2 ?? (_convert2 = new ApiProperty<int>(this, "convert_2"));
        private ApiProperty<int> _convert2;
        /// <summary>
        /// Gets or sets the count of converts for split test C.
        /// </summary>
        public int Convert2Value { get=> Convert2.Value; set => Convert2.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the count of converts for split test D.
        /// </summary>
        public ApiProperty<int> Convert3 => _convert3 ?? (_convert3 = new ApiProperty<int>(this, "convert_3"));
        private ApiProperty<int> _convert3;
        /// <summary>
        /// Gets or sets the count of converts for split test D.
        /// </summary>
        public int Convert3Value { get=> Convert3.Value; set => Convert3.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the count of unique convert for split test A.
        /// </summary>
        public ApiProperty<int> UniqueConvert0 => _unique_convert0 ?? (_unique_convert0 = new ApiProperty<int>(this, "unique_convert_0"));
        private ApiProperty<int> _unique_convert0;
        /// <summary>
        /// Gets or sets the count of unique convert for split test A.
        /// </summary>
        public int UniqueConvert0Value { get=> UniqueConvert0.Value; set => UniqueConvert0.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the count of unique convert for split test B.
        /// </summary>
        public ApiProperty<int> UniqueConvert1 => _unique_convert1 ?? (_unique_convert1 = new ApiProperty<int>(this, "unique_convert_1"));
        private ApiProperty<int> _unique_convert1;
        /// <summary>
        /// Gets or sets the count of unique convert for split test B.
        /// </summary>
        public int UniqueConvert1Value { get=> UniqueConvert1.Value; set => UniqueConvert1.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the count of unique convert for split test C.
        /// </summary>
        public ApiProperty<int> UniqueConvert2 => _unique_convert2 ?? (_unique_convert2 = new ApiProperty<int>(this, "unique_convert_2"));
        private ApiProperty<int> _unique_convert2;
        /// <summary>
        /// Gets or sets the count of unique convert for split test C.
        /// </summary>
        public int UniqueConvert2Value { get=> UniqueConvert2.Value; set => UniqueConvert2.Value = value; }

        /// <summary>
        /// Returns a ApiProperty object to get or set the count of unique convert for split test D.
        /// </summary>
        public ApiProperty<int> UniqueConvert3 => _unique_convert3 ?? (_unique_convert3 = new ApiProperty<int>(this, "unique_convert_3"));
        private ApiProperty<int> _unique_convert3;
        /// <summary>
        /// Gets or sets the count of unique convert for split test D.
        /// </summary>
        public int UniqueConvert3Value { get=> UniqueConvert3.Value; set => UniqueConvert3.Value = value; }

        public ApiPropertyString SeoSettings => _seoSettings ?? (_seoSettings = new ApiPropertyString(this, "seo_settings"));
        private ApiPropertyString _seoSettings;
        public string SeoSettingsValue { get=> SeoSettings.Value; set => SeoSettings.Value = value; }





        /// <summary>
        /// The landing page's design type.
        /// </summary>
        public enum PageDesignType
        {
            Html = 0,
            CodeMode = 1,
            Redirect = 2,
            OntraPages = 3
        }
    }
}
