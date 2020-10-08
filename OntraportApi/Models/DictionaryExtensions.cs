using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using HanumanInstitute.OntraportApi.Converters;

namespace HanumanInstitute.OntraportApi.Models
{
    /// <summary>
    /// Facilitates building Ontraport queries by adding common parameters.
    /// </summary>
    internal static class DictionaryExtensions
    {
        /// <summary>
        /// Adds a key-value pair to the dictionary if value is not null.
        /// </summary>
        /// <param name="list">The dictionary of query parameters.</param>
        /// <param name="key">The key to add.</param>
        /// <param name="value">The value to add if not null.</param>
        /// <returns>The query dictionary.</returns>
        internal static Dictionary<string, object?> AddIfHasValue(this Dictionary<string, object?> list, string key, object? value)
        {
            if (value != null)
            {
                list.Add(key, value);
            }
            return list;
        }

        /// <summary>
        /// Adds search options to the query parameters.
        /// </summary>
        /// <param name="list">The dictionary of query parameters.</param>
        /// <param name="options">An ApiSearchOptions object containing search options.</param>
        /// <param name="performsAction">Whether the query performs an action other than selecting data.</param>
        /// <returns></returns>
        internal static Dictionary<string, object?> AddSearchOptions(this Dictionary<string, object?> list, ApiSearchOptions? options, bool performsAction = false)
        {
            if (options != null)
            {
                // OntraportHttpClient.SerializerOptions.Converters.Add(new ApiSearchConditionConverter());
                var condition = options.GetCondition();
                if (options.Ids.Any())
                {
                    list.Add("ids", string.Join(",", options.Ids));
                }
                list.AddIfHasValue("group_id", options.GroupId)
                    .AddIfHasValue("start", options.Start)
                    .AddIfHasValue("range", options.Range)
                    .AddIfHasValue("condition", condition)
                    .AddIfHasValue("search", options.Search);
                if (!string.IsNullOrEmpty(options.Search) && options.SearchNotes)
                {
                    list.Add("searchNotes", options.SearchNotes);
                }
                if (performsAction && !options.Ids.Any())
                {
                    list.Add("performAll", "1");
                }
            }
            else
            {
                // list.Add("performAll", "1");
            }
            return list;
        }

        /// <summary>
        /// Adds sort options to the query parameters.
        /// </summary>
        /// <param name="list">The dictionary of query parameters.</param>
        /// <param name="options">An ApiSortOptions object containing sort options.</param>
        internal static Dictionary<string, object?> AddSortOptions(this Dictionary<string, object?> list, ApiSortOptions? options)
        {
            if (options != null)
            {
                if (!string.IsNullOrEmpty(options.Sort))
                {
                    list.Add("sort", options.Sort);
                    list.Add("sortDir", options.Direction == ListSortDirection.Ascending ? "asc" : "desc");
                }
            }
            return list;
        }

        ///// <summary>
        ///// Adds GroupIds and PerformAll query parameters.
        ///// </summary>
        ///// <param name="list">The dictionary of query parameters.</param>
        ///// <param name="groupId">The group id of objects to retrieve</param>
        ///// <param name="performAll">Used in conjunction with group_id to indicates wether specified action should be performed on all members of a group.</param>
        ///// <returns>The query dictionnary.</returns>
        //internal static Dictionary<string, object?> AddGroupId(this Dictionary<string, object?> list, int? groupId = null, bool? performAll = null)
        //{
        //    if (groupIds != null)
        //    {
        //        list.Add("group_ids", string.Join(",", groupIds));
        //        if (performAll.HasValue)
        //        {
        //            list.Add("performAll", performAll.Value ? 1 : 0);
        //        }
        //    }
        //    return list;
        //}

        /// <summary>
        /// Adds Externs and ListFields query parameters.
        /// </summary>
        /// <param name="list">The dictionary of query parameters.</param>
        /// <param name="externs">If you have a relationship between your object and another object, you may want to include the data from a related field in your results. Each external field is listed in the format {object}//{field}.</param>
        /// <param name="listFields">A string array of the fields which should be returned in your results.</param>
        /// <returns>The query dictionary.</returns>
        internal static Dictionary<string, object?> AddFields(this Dictionary<string, object?> list, IEnumerable<string>? externs = null, IEnumerable<string>? listFields = null)
        {
            if (externs != null)
            {
                list.Add("externs", string.Join(",", externs));
            }
            if (listFields != null)
            {
                list.Add("listFields", string.Join(",", listFields));
            }
            return list;
        }

        /// <summary>
        /// Adds all properties of an object into the dictionary using reflection.
        /// If object is a Dictionary, its content will instead be added.
        /// </summary>
        /// <param name="list">The dictionary of query parameters.</param>
        /// <param name="values">An object containing the values to add.</param>
        /// <returns>The query dictionary.</returns>
        internal static IDictionary<string, object?> AddObject(this IDictionary<string, object?> list, object? values)
        {
            if (values != null)
            {
                if (values is IDictionary<string, object>)
                {
                    (values as IDictionary<string, object>).ToList().ForEach(x => list.Add(x.Key, x.Value));
                }
                else
                {
                    // Object properties through reflection.
                    var properties = values.GetType().GetProperties();
                    foreach (var item in properties)
                    {
                        var itemName = item.Name;
                        var itemValue = item.GetValue(values, null);
                        list.Add(itemName, itemValue);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Wraps a dictionary within a list.
        /// </summary>
        /// <param name="dictionary">The dictionary to wrap within a list.</param>
        /// <returns>A new list.</returns>
        internal static List<Dictionary<string, string>> WrapInList(this Dictionary<string, string> dictionary)
        {
            return new List<Dictionary<string, string>>
            {
                dictionary
            };
        }

        /// <summary>
        /// Converts a dictionary to a URI-encoded string.
        /// </summary>
        /// <param name="parameters">The parameters to encode.</param>
        /// <returns>A URI-encoded string.</returns>
        internal static string ToQueryString(this IDictionary<string, object> parameters) =>
            string.Join("&", parameters.Select(kvp => $"{WebUtility.UrlEncode(kvp.Key)}={WebUtility.UrlEncode(ValueToQueryString(kvp.Value))}"));

        /// <summary>
        /// Converts an object into its string representation. Lists will be returned as comma-delimited strings.
        /// </summary>
        /// <param name="value">The value to convert to string.</param>
        /// <returns>The formatted string.</returns>
        internal static string ValueToQueryString(object value)
        {
            if (value is IEnumerable enumValue && !(value is string))
            {
                return string.Join(",", ((enumValue).Cast<object>()));
            }
            return value.ToStringInvariant();
        }
    }
}
