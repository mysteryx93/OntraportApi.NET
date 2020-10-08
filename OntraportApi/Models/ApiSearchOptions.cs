using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using HanumanInstitute.OntraportApi.Converters;

namespace HanumanInstitute.OntraportApi.Models
{
    /// <summary>
    /// Contains all common search options and constructs a condition query for Ontraport API.
    /// This object can be constructed via fluent API.
    /// </summary>
    public class ApiSearchOptions
    {
        public ApiSearchOptions() { }

        public ApiSearchOptions(int id)
        {
            Ids.Add(id);
        }

        public ApiSearchOptions(IList<int> ids)
        {
            Ids.AddRange(ids);
        }

        /// <summary>
        /// Gets or sets a list of the IDs of the objects to retrieve.
        /// </summary>
        public List<int> Ids { get; private set; } = new List<int>();

        /// <summary>
        /// Gets or sets the list of the group ids of objects to retrieve.
        /// </summary>
        public int? GroupId { get; set; }

        /// <summary>
        /// Gets or sets the offset to start your search from.
        /// </summary>
        public int? Start { get; set; }

        /// <summary>
        /// Gets or sets the number of objects you want to retrieve. The maximum and default range is 50.
        /// </summary>
        public int? Range { get; set; }

        /// <summary>
        /// Gets or sets a string to search your objects for.
        /// </summary>
        public string? Search { get; set; }

        /// <summary>
        /// Used in conjunction with the search parameter to indicate whether or not object notes should be searched for the specified string 
        /// in addition to other object fields.
        /// </summary>
        public bool SearchNotes { get; set; }

        /// <summary>
        /// Gets or sets the list of conditions to apply to the search. Can be set using AddCondition method.
        /// </summary>
        public List<ApiSearchConditionBase> Conditions { get; private set; } = new List<ApiSearchConditionBase>();

        /// <summary>
        /// Sets the Ids value.
        /// </summary>
        /// <param name="ids">A list of the IDs of the objects to retrieve.</param>
        public ApiSearchOptions SetId(int id)
        {
            Ids.Add(id);
            return this;
        }

        /// <summary>
        /// Sets the Ids value.
        /// </summary>
        /// <param name="ids">A list of the IDs of the objects to retrieve.</param>
        public ApiSearchOptions SetIds(IList<int> ids)
        {
            Ids.AddRange(ids);
            return this;
        }

        /// <summary>
        /// Sets the GroupIds value.
        /// </summary>
        /// <param name="groupIds">List of the group ids of objects to retrieve.</param>
        public ApiSearchOptions SetGroupId(int groupId)
        {
            GroupId = groupId;
            return this;
        }

        /// <summary>
        /// Sets the Start and Range values.
        /// </summary>
        /// <param name="start">The offset to start your search from.</param>
        /// <param name="range">The number of objects you want to retrieve. The maximum and default range is 50.</param>
        public ApiSearchOptions SetStart(int? start, int? range = null)
        {
            Start = start;
            Range = range;
            return this;
        }

        /// <summary>
        /// Sets the Search and SearchNotes values.
        /// </summary>
        /// <param name="search">A string to search your objects for.</param>
        /// <param name="searchNotes">Used in conjunction with the search parameter to indicate whether or not object notes should be searched for the specified string in addition to other object fields.</param>
        public ApiSearchOptions SetSearch(string search, bool searchNotes = false)
        {
            Search = search;
            SearchNotes = searchNotes;
            return this;
        }

        /// <summary>
        /// Adds a condition to the object.
        /// </summary>
        /// <param name="field">What field you want to check for a condition.</param>
        /// <param name="op">The comparison operator you would like to use: &gt;, &lt;, &gt;=, &lt;=, =.</param>
        /// <param name="value">The value to compare field to.</param>
        /// <param name="andCond">True to check that both this condition and the previous are true, false to check that either this condition
        /// or the previous is true. Ignored for the first added condition.</param>
        /// <returns>This object.</returns>
        public ApiSearchOptions AddCondition(string field, string op, object? value, bool andCond = true)
        {
            Conditions.Add(new ApiSearchCondition(field, op, value, andCond));
            return this;
        }

        /// <summary>
        /// Adds a condition to the object.
        /// </summary>
        /// <param name="field">What field you want to check for a condition.</param>
        /// <param name="valueList">The list of values to compare field to.</param>
        /// <param name="andCond">True to check that both this condition and the previous are true, false to check that either this condition
        /// or the previous is true. Ignored for the first added condition.</param>
        /// <returns>This object.</returns>
        public ApiSearchOptions AddConditionInList(string field, IEnumerable valueList, bool andCond = true)
        {
            Conditions.Add(new ApiSearchConditionInList(field, valueList, andCond));
            return this;
        }

        /// <summary>
        /// Returns the conditions as a JSON-encoded string.
        /// </summary>
        public string? GetCondition() => Conditions.Any() ? JsonSerializer.Serialize(Conditions, OntraportSerializerOptions.Default) : null;
    }
}
