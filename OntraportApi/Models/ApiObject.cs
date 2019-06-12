using System;
using System.Collections.Generic;
using EmergenceGuardian.OntraportApi.Converters;

namespace EmergenceGuardian.OntraportApi.Models
{
    /// <summary>
    /// Base class for all API typed objects providing common functions.
    /// </summary>
    public class ApiObject
    {
        private readonly string _idField;

        /// <summary>
        /// Initializes a new instance of the ApiObject class.
        /// </summary>
        public ApiObject() : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the ApiObject class and change the default ID field if different than "id".
        /// </summary>
        /// <param name="idField">The name of the ID field for this object. Default is "id".</param>
        public ApiObject(string idField)
        {
            _idField = idField ?? "id";
        }

        /// <summary>
        /// Returns a ApiProperty object to get or set the object's ID.
        /// </summary>
        public ApiProperty<int> Id => _id ?? (_id = new ApiProperty<int>(this, _idField));
        private ApiProperty<int> _id;
        /// <summary>
        /// Gets or sets the object's ID.
        /// </summary>
        public int IdValue { get => Id.Value; set => Id.Value = value; }

        /// <summary>
        /// Gets or sets the raw data for this object as a dictionnary of string values.
        /// </summary>
        public IDictionary<string, string> Data { get; set; } = new Dictionary<string, string>();
        internal readonly IList<string> EditedKeys = new List<string>();

        /// <summary>
        /// Gets or sets the value for the specified dictionary key.
        /// </summary>
        /// <param name="key">The key of the value to get or set.</param>
        /// <returns>The raw string value.</returns>
        public string this[string key]
        {
            get => Data[key];
            set => Data[key] = value;
        }

        /// <summary>
        /// Returns a list of all values that were edited.
        /// </summary>
        /// <returns>A dictionary of edited values.</returns>
        public IDictionary<string, object> GetChanges()
        {
            var result = new Dictionary<string, object>();
            foreach (var key in EditedKeys)
            {
                result.Add(key, Data[key]);
            }
            return result;
        }
    }
}
