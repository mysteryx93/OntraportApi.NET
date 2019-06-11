using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmergenceGuardian.OntraportApi
{
    public interface IOntraportRequestHelper
    {
        /// <summary>
        /// Sends a GET API query to Ontraport.
        /// </summary>
        /// <typeparam name="T">The expected response data type. Set to JObject to parse manually. Set to Object to discard output.</typeparam>
        /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
        /// <param name="values">Values set by the method type.</param>
        /// <returns>An ApiResponse of the expected type.</returns>
        Task<T> GetAsync<T>(string endpoint, IDictionary<string, object> values = null) where T : class;
        /// <summary>
        /// Sends a DELETE API query to Ontraport.
        /// </summary>
        /// <typeparam name="T">The expected response data type. Set to JObject to parse manually. Set to Object to discard output.</typeparam>
        /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
        /// <param name="values">Values set by the method type.</param>
        /// <returns>An ApiResponse of the expected type.</returns>
        Task<T> DeleteAsync<T>(string endpoint, IDictionary<string, object> values = null, bool encodeJson = true) where T : class;
        /// <summary>
        /// Sends a POST API query to Ontraport.
        /// </summary>
        /// <typeparam name="T">The expected response data type. Set to JObject to parse manually. Set to Object to discard output.</typeparam>
        /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
        /// <param name="values">Values set by the method type.</param>
        /// <returns>An ApiResponse of the expected type.</returns>
        Task<T> PostAsync<T>(string endpoint, IDictionary<string, object> values = null) where T : class;
        /// <summary>
        /// Sends a PUT API query to Ontraport.
        /// </summary>
        /// <typeparam name="T">The expected response data type. Set to JObject to parse manually. Set to Object to discard output.</typeparam>
        /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
        /// <param name="values">Values set by the method type.</param>
        /// <returns>An ApiResponse of the expected type.</returns>
        Task<T> PutAsync<T>(string endpoint, IDictionary<string, object> values = null) where T : class;
    }
}
