using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for CustomObject objects.
    /// This provides the list of custom objects and their IDs.
    /// To use those custom objects, refer to the classes specific to each object or use OntraportObjects with the ID obtained here.
    /// You can cast any integer to ApiObjectType such as (ApiObjectType)10000.
    /// </summary>
    public interface IOntraportCustomObjects : IOntraportBaseRead<ApiCustomObject>
    {
        /// <summary>
        /// Retrieves all the information for custom object by its plural name.
        /// </summary>
        /// <param name="pluralName">The plural name of the object.</param>
        /// <returns>The selected object.</returns>
        Task<ApiCustomObject> SelectAsync(string pluralName);
    }
}
