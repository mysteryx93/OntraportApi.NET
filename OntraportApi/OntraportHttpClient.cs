using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using EmergenceGuardian.OntraportApi.Models;
using Microsoft.Extensions.Options;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Sends API requests to Ontraport, formatting the parameters and parsing the response.
    /// </summary>
    public class OntraportHttpClient
    {
        private const string ContentJson = "application/json";
        private const string ContentUrl = "application/x-www-form-urlencoded";
        private readonly OntraportConfig _config;
        private readonly HttpClient _httpClient;

        public OntraportHttpClient(IOptions<OntraportConfig> config, HttpClient httpClientFactory)
        {
            _config = config.Value;
            _httpClient = httpClientFactory;

            if (string.IsNullOrEmpty(_config.ApiKey)) throw new ArgumentException("ApiConfig.ApiKey is required.");
            if (string.IsNullOrEmpty(_config.AppId)) throw new ArgumentException("ApiConfig.AppId is required.");

            _httpClient.BaseAddress = new Uri("https://api.ontraport.com/1/");
            _httpClient.DefaultRequestHeaders.Add("Api-key", _config.ApiKey);
            _httpClient.DefaultRequestHeaders.Add("Api-Appid", _config.AppId);
        }

        /// <summary>
        /// Sends a GET API query to Ontraport.
        /// </summary>
        /// <typeparam name="T">The expected response data type. Set to JObject to parse manually. Set to Object to discard output.</typeparam>
        /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
        /// <param name="values">Values set by the method type.</param>
        /// <returns>An ApiResponse of the expected type.</returns>
        public async Task<T> GetAsync<T>(string endpoint, IDictionary<string, object> values = null) where T : class =>
            await RequestAsync<T>(endpoint, HttpMethod.Get, false, values);

        /// <summary>
        /// Sends a DELETE API query to Ontraport.
        /// </summary>
        /// <typeparam name="T">The expected response data type. Set to JObject to parse manually. Set to Object to discard output.</typeparam>
        /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
        /// <param name="values">Values set by the method type.</param>
        /// <returns>An ApiResponse of the expected type.</returns>
        public async Task<T> DeleteAsync<T>(string endpoint, IDictionary<string, object> values = null, bool encodeJson = true) where T : class =>
            await RequestAsync<T>(endpoint, HttpMethod.Delete, encodeJson, values);

        /// <summary>
        /// Sends a POST API query to Ontraport.
        /// </summary>
        /// <typeparam name="T">The expected response data type. Set to JObject to parse manually. Set to Object to discard output.</typeparam>
        /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
        /// <param name="values">Values set by the method type.</param>
        /// <returns>An ApiResponse of the expected type.</returns>
        public async Task<T> PostAsync<T>(string endpoint, IDictionary<string, object> values = null) where T : class =>
            await RequestAsync<T>(endpoint, HttpMethod.Post, true, values);

        /// <summary>
        /// Sends a PUT API query to Ontraport.
        /// </summary>
        /// <typeparam name="T">The expected response data type. Set to JObject to parse manually. Set to Object to discard output.</typeparam>
        /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
        /// <param name="values">Values set by the method type.</param>
        /// <returns>An ApiResponse of the expected type.</returns>
        public async Task<T> PutAsync<T>(string endpoint, IDictionary<string, object> values = null) where T : class =>
            await RequestAsync<T>(endpoint, HttpMethod.Put, true, values);

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
        protected async Task<T> RequestAsync<T>(string endpoint, HttpMethod method, bool encodeJson, IDictionary<string, object> values = null)
            where T : class
        {
            values = values ?? new Dictionary<string, object>();

            // Serialize request.
            var content = encodeJson ?
                JsonConvert.SerializeObject(values, Formatting.None) :
                values.ToQueryString();

            var requestUrl = endpoint;
            if (!encodeJson && !string.IsNullOrEmpty(content))
            {
                requestUrl += "?" + content;
                content = "";
            }

            var response = await _httpClient.SendAsync(new HttpRequestMessage(method, requestUrl)
            {
                 Content = new StringContent(content, Encoding.UTF8, encodeJson ? ContentJson : ContentUrl)
            });
            response.EnsureSuccessStatusCode();

            var responseText = await response.Content.ReadAsStringAsync();
            response.Content?.Dispose();

            if (typeof(T) == typeof(object))
            {
                return new object() as T;
            }
            if (typeof(T) == typeof(JObject))
            {
                // Return JSON manual parser.
                return JObject.Parse(responseText) as T;
            }
            else
            {
                // Parse response.
                var result = JsonConvert.DeserializeObject<ApiResponse<T>>(responseText);
                if (result.Code != 0)
                {
                    throw new WebException($"The remote server returned an error: ({result.Code})");
                }
                return result.Data;
            }
        }
    }
}
