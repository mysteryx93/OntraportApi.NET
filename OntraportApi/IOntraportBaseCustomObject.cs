using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Base class to provides Ontraport API support for custom objects.
    /// </summary>
    public interface IOntraportBaseCustomObject<T>  : IOntraportBaseDelete<T>
        where T : ApiCustomObject
    {
        /// <summary>
        /// Looks for an existing object with a matching unique field and merges supplied data with existing data.
        /// </summary>
        /// <param name="values">The field values to set.</param>
        /// <returns>The updated ApiObject.</returns>
        Task<T> CreateOrMergeAsync(object values = null);

        /// <summary>
        /// Retrieves the custom fields data.
        /// </summary>
        /// <returns>A ResponseMetadata object.</returns>
        Task<ResponseMetadata> SelectCustomFieldsAsync();
    }
}
