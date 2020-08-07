using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using HanumanInstitute.OntraportApi.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace HanumanInstitute.OntraportApi
{
    /// <summary>
    /// Sends API requests to Ontraport, formatting the parameters and parsing the response.
    /// </summary>
    public class OntraportHttpClient
    {
        private const string ContentJson = "application/json";
        private const string ContentUrl = "application/x-www-form-urlencoded";
        private readonly HttpClient _httpClient;
        private readonly ILogger<OntraportHttpClient>? _logger;

        public OntraportHttpClient(HttpClient httpClient, IOptions<OntraportConfig> config, ILogger<OntraportHttpClient>? logger)
        {
            _httpClient = httpClient.CheckNotNull(nameof(httpClient));
            _logger = logger;

            var conf = config.CheckNotNull(nameof(config)).Value;

            if (string.IsNullOrEmpty(conf.ApiKey)) throw new ArgumentException(Properties.Resources.ConfigApiKeyRequired);
            if (string.IsNullOrEmpty(conf.AppId)) throw new ArgumentException(Properties.Resources.ConfigAppIdRequired);

            _httpClient.BaseAddress = new Uri("https://api.ontraport.com/1/");
            _httpClient.DefaultRequestHeaders.Add("Api-key", conf.ApiKey);
            _httpClient.DefaultRequestHeaders.Add("Api-Appid", conf.AppId);
        }

        /// <summary>
        /// Sends a GET API query to Ontraport.
        /// </summary>
        /// <typeparam name="T">The expected response data type. Set to JObject to parse manually. Set to Object to discard output.</typeparam>
        /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <param name="values">Values set by the method type.</param>
        /// <returns>An ApiResponse of the expected type.</returns>
        public async Task<T> GetAsync<T>(string endpoint, IDictionary<string, object?>? values = null, CancellationToken? cancellationToken = null) where T : class =>
            await RequestAsync<T>(endpoint, HttpMethod.Get, false, values).ConfigureAwait(false);

        /// <summary>
        /// Sends a DELETE API query to Ontraport.
        /// </summary>
        /// <typeparam name="T">The expected response data type. Set to JObject to parse manually. Set to Object to discard output.</typeparam>
        /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <param name="values">Values set by the method type.</param>
        /// <returns>An ApiResponse of the expected type.</returns>
        public async Task<T> DeleteAsync<T>(string endpoint, IDictionary<string, object?>? values = null, bool encodeJson = true, CancellationToken? cancellationToken = null) where T : class =>
            await RequestAsync<T>(endpoint, HttpMethod.Delete, encodeJson, values).ConfigureAwait(false);

        /// <summary>
        /// Sends a POST API query to Ontraport.
        /// </summary>
        /// <typeparam name="T">The expected response data type. Set to JObject to parse manually. Set to Object to discard output.</typeparam>
        /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <param name="values">Values set by the method type.</param>
        /// <returns>An ApiResponse of the expected type.</returns>
        public async Task<T> PostAsync<T>(string endpoint, IDictionary<string, object?>? values = null, CancellationToken? cancellationToken = null) where T : class =>
            await RequestAsync<T>(endpoint, HttpMethod.Post, true, values).ConfigureAwait(false);

        /// <summary>
        /// Sends a PUT API query to Ontraport.
        /// </summary>
        /// <typeparam name="T">The expected response data type. Set to JObject to parse manually. Set to Object to discard output.</typeparam>
        /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <param name="values">Values set by the method type.</param>
        /// <returns>An ApiResponse of the expected type.</returns>
        public async Task<T> PutAsync<T>(string endpoint, IDictionary<string, object?>? values = null, CancellationToken? cancellationToken = null) where T : class =>
            await RequestAsync<T>(endpoint, HttpMethod.Put, true, values).ConfigureAwait(false);

        /// <summary>
        /// Sends an API query to Ontraport.
        /// </summary>
        /// <typeparam name="T">The expected response data type. Set to JObject to parse manually. Set to Object to discard output.</typeparam>
        /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
        /// <param name="method">The web request method.</param>
        /// <param name="encodeJson">True to encode the request as Json, false to encode as URL query.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <param name="values">Values set by the method type.</param>
        /// <returns>An ApiResponse of the expected type.</returns>
        protected async Task<T> RequestAsync<T>(string endpoint, HttpMethod method, bool encodeJson, IDictionary<string, object?>? values = null, CancellationToken? cancellationToken = null)
            where T : class
        {
            values ??= new Dictionary<string, object?>();

            // Serialize request.
            var content = encodeJson ?
                JsonConvert.SerializeObject(values, Formatting.None) :
                values!.ToQueryString();

            // Log request.
            _logger?.LogInformation($"Request {endpoint} {method}: {content}");

            var requestUrl = endpoint;
            if (!encodeJson && !string.IsNullOrEmpty(content))
            {
                requestUrl += "?" + content;
                content = "";
            }

            using var request = new HttpRequestMessage(method, requestUrl)
            {
                Content = new StringContent(content, Encoding.UTF8, encodeJson ? ContentJson : ContentUrl)
            };
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            response.Content?.Dispose();

            if (typeof(T) == typeof(object))
            {
                return (T)new object();
            }
            if (typeof(T) == typeof(JObject))
            {
                // Return JSON manual parser.
                return (JObject.Parse(responseText) as T)!;
            }
            else
            {
                // Parse response.
                var result = JsonConvert.DeserializeObject<ApiResponse<T>>(responseText);
                if (result.Code != 0)
                {
                    throw new WebException($"The remote server returned an error: ({result.Code})");
                }
                if (result.Data == null)
                {
                    throw new NullReferenceException(Properties.Resources.ResponseDataNull);
                }
                return result.Data!;
            }
        }
    }
}
