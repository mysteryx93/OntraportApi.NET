using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Sends API requests to Ontraport, formatting the parameters and parsing the response.
    /// </summary>
    public class ApiRequestHelper : IApiRequestHelper
    {
        private const string ContentJson = "application/json";
        // private const string ContentUrl = "application/x-www-form-urlencoded";
        private readonly ApiConfig _config;
        private readonly IWebRequestService _webRequest;

        public ApiRequestHelper(ApiConfig config, IWebRequestService webRequest)
        {
            if (string.IsNullOrEmpty(config.ApiKey)) throw new ArgumentException("ApiConfig.ApiKey is required.");
            if (string.IsNullOrEmpty(config.AppId)) throw new ArgumentException("ApiConfig.AppId is required.");

            _config = config;
            _webRequest = webRequest;
        }

        /// <summary>
        /// Sends a GET API query to Ontraport.
        /// </summary>
        /// <typeparam name="T">The expected response data type. Set to JObject to parse manually. Set to Object to discard output.</typeparam>
        /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
        /// <param name="values">Values set by the method type.</param>
        /// <returns>An ApiResponse of the expected type.</returns>
        public async Task<T> GetAsync<T>(string endpoint, IDictionary<string, object> values = null) where T : class =>
            await RequestAsync<T>(endpoint, "GET", false, values);

        /// <summary>
        /// Sends a DELETE API query to Ontraport.
        /// </summary>
        /// <typeparam name="T">The expected response data type. Set to JObject to parse manually. Set to Object to discard output.</typeparam>
        /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
        /// <param name="values">Values set by the method type.</param>
        /// <returns>An ApiResponse of the expected type.</returns>
        public async Task<T> DeleteAsync<T>(string endpoint, IDictionary<string, object> values = null, bool encodeJson = true) where T : class =>
            await RequestAsync<T>(endpoint, "DELETE", encodeJson, values);

        /// <summary>
        /// Sends a POST API query to Ontraport.
        /// </summary>
        /// <typeparam name="T">The expected response data type. Set to JObject to parse manually. Set to Object to discard output.</typeparam>
        /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
        /// <param name="values">Values set by the method type.</param>
        /// <returns>An ApiResponse of the expected type.</returns>
        public async Task<T> PostAsync<T>(string endpoint, IDictionary<string, object> values = null) where T : class =>
            await RequestAsync<T>(endpoint, "POST", true, values);

        /// <summary>
        /// Sends a PUT API query to Ontraport.
        /// </summary>
        /// <typeparam name="T">The expected response data type. Set to JObject to parse manually. Set to Object to discard output.</typeparam>
        /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
        /// <param name="values">Values set by the method type.</param>
        /// <returns>An ApiResponse of the expected type.</returns>
        public async Task<T> PutAsync<T>(string endpoint, IDictionary<string, object> values = null) where T : class =>
            await RequestAsync<T>(endpoint, "PUT", true, values);

        /// <summary>
        /// Sends an API query to Ontraport.
        /// </summary>
        /// <typeparam name="T">The expected response data type. Set to JObject to parse manually. Set to Object to discard output.</typeparam>
        /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
        /// <param name="method">The web request method.</param>
        /// <param name="encodeJson">True to encode the request as Json, false to encode as URL query.</param>
        /// <param name="values">Values set by the method type.</param>
        /// <param name="valuesOptional">Optional values set by the caller.</param>
        /// <returns>An ApiResponse of the expected type.</returns>
        protected async Task<T> RequestAsync<T>(string endpoint, string method, bool encodeJson, IDictionary<string, object> values = null)
            where T : class
        {
            values = values ?? new Dictionary<string, object>();

            // Serialize request.
            var content = encodeJson ?
                JsonConvert.SerializeObject(values, Formatting.None) :
                values.ToQueryString();

            var requestUrl = "https://api.ontraport.com/1/" + endpoint;
            if (!encodeJson && !string.IsNullOrEmpty(content))
            {
                requestUrl += "?" + content;
                content = null;
            }

            // Send request.
            var response = await _webRequest.ServerRequestAsync(
                requestUrl,
                content,
                method,
                encodeJson ? ContentJson : null,
                new NameValueCollection()
            {
                { "Api-key", _config.ApiKey },
                { "Api-Appid", _config.AppId },
            });

            if (typeof(T) == typeof(object))
            {
                return new object() as T;
            }
            if (typeof(T) == typeof(JObject))
            {
                // Return JSON manual parser.
                return JObject.Parse(response) as T;
            }
            else
            {
                // Parse response.
                var result = JsonConvert.DeserializeObject<ApiResponse<T>>(response);
                if (result.Code != 0)
                {
                    throw new WebException($"The remote server returned an error: ({result.Code})");
                }
                return result.Data;
            }
        }
    }
}
