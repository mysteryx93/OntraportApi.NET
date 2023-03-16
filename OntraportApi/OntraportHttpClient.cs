using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Res = HanumanInstitute.OntraportApi.Properties.Resources;

namespace HanumanInstitute.OntraportApi;

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

        if (string.IsNullOrEmpty(conf.ApiKey))
        {
            throw new ArgumentException(Res.ConfigApiKeyRequired);
        }

        if (string.IsNullOrEmpty(conf.AppId))
        {
            throw new ArgumentException(Res.ConfigAppIdRequired);
        }

        _httpClient.BaseAddress = new Uri("https://api.ontraport.com/1/");
        _httpClient.DefaultRequestHeaders.Add("Api-key", conf.ApiKey);
        _httpClient.DefaultRequestHeaders.Add("Api-Appid", conf.AppId);
    }

    /// <summary>
    /// Sends a GET API query to Ontraport and deserializes the response as an object.
    /// </summary>
    /// <typeparam name="T">The expected response data type. Set to JsonElement to parse manually. Set to Object to discard output.</typeparam>
    /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <param name="values">Values set by the method type.</param>
    /// <returns>An ApiResponse of the expected type.</returns>
    /// <exception cref="InvalidOperationException">There was an error while sending or parsing the request.</exception>
    /// <exception cref="HttpRequestException">There was an HTTP communication error or Ontraport returned an error.</exception>
    /// <exception cref="TaskCanceledException">The request timed-out or the user canceled the request's Task.</exception>
    public async Task<T?> GetAsync<T>(string endpoint, IDictionary<string, object?>? values = null, bool returnNotFoundAsNull = true, CancellationToken cancellationToken = default)
        where T : class
    {
        var result = await RequestAsync<T>(endpoint, HttpMethod.Get, false, values, returnNotFoundAsNull, cancellationToken).ConfigureAwait(false);
        return result;
    }

    /// <summary>
    /// Sends a GET API query to Ontraport and returns the response as a JsonElement for custom parsing.
    /// </summary>
    /// <typeparam name="T">The expected response data type. Set to JsonElement to parse manually. Set to Object to discard output.</typeparam>
    /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <param name="values">Values set by the method type.</param>
    /// <returns>An ApiResponse of the expected type.</returns>
    /// <exception cref="InvalidOperationException">There was an error while sending or parsing the request.</exception>
    /// <exception cref="HttpRequestException">There was an HTTP communication error or Ontraport returned an error.</exception>
    /// <exception cref="TaskCanceledException">The request timed-out or the user canceled the request's Task.</exception>
    public async Task<JsonElement?> GetJsonAsync(string endpoint, IDictionary<string, object?>? values = null, bool returnNotFoundAsNull = true, CancellationToken cancellationToken = default)
    {
        var result = await RequestJsonAsync(endpoint, HttpMethod.Get, false, values, returnNotFoundAsNull, cancellationToken).ConfigureAwait(false);
        return result;
    }

    /// <summary>
    /// Sends a DELETE API query to Ontraport and deserializes the response as an object.
    /// </summary>
    /// <typeparam name="T">The expected response data type. Set to JsonElement to parse manually. Set to Object to discard output.</typeparam>
    /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <param name="values">Values set by the method type.</param>
    /// <returns>An ApiResponse of the expected type.</returns>
    /// <exception cref="InvalidOperationException">There was an error while sending or parsing the request.</exception>
    /// <exception cref="HttpRequestException">There was an HTTP communication error or Ontraport returned an error.</exception>
    /// <exception cref="TaskCanceledException">The request timed-out or the user canceled the request's Task.</exception>
    public async Task<T> DeleteAsync<T>(string endpoint, IDictionary<string, object?>? values = null, bool encodeJson = true, CancellationToken cancellationToken = default)
        where T : class
    {
        var result = await RequestAsync<T>(endpoint, HttpMethod.Delete, encodeJson, values, false, cancellationToken).ConfigureAwait(false);
        return result!;
    }

    /// <summary>
    /// Sends a DELETE API query to Ontraport and returns the response as a JsonElement for custom parsing.
    /// </summary>
    /// <typeparam name="T">The expected response data type. Set to JsonElement to parse manually. Set to Object to discard output.</typeparam>
    /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <param name="values">Values set by the method type.</param>
    /// <returns>An ApiResponse of the expected type.</returns>
    /// <exception cref="InvalidOperationException">There was an error while sending or parsing the request.</exception>
    /// <exception cref="HttpRequestException">There was an HTTP communication error or Ontraport returned an error.</exception>
    /// <exception cref="TaskCanceledException">The request timed-out or the user canceled the request's Task.</exception>
    public async Task<JsonElement> DeleteJsonAsync(string endpoint, IDictionary<string, object?>? values = null, bool encodeJson = true, CancellationToken cancellationToken = default)
    {
        var result = await RequestJsonAsync(endpoint, HttpMethod.Delete, encodeJson, values, false, cancellationToken).ConfigureAwait(false);
        return result.Value;
    }

    /// <summary>
    /// Sends a POST API query to Ontraport and deserializes the response as an object.
    /// </summary>
    /// <typeparam name="T">The expected response data type. Set to JsonElement to parse manually. Set to Object to discard output.</typeparam>
    /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
    /// <param name="values">Values set by the method type.</param>
    /// <param name="encodeJson">True to encode the request as Json, false to encode as query data.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An ApiResponse of the expected type.</returns>
    /// <exception cref="InvalidOperationException">There was an error while sending or parsing the request.</exception>
    /// <exception cref="HttpRequestException">There was an HTTP communication error or Ontraport returned an error.</exception>
    /// <exception cref="TaskCanceledException">The request timed-out or the user canceled the request's Task.</exception>
    public async Task<T> PostAsync<T>(string endpoint, IDictionary<string, object?>? values = null, bool encodeJson = true, CancellationToken cancellationToken = default)
        where T : class
    {
        var result = await RequestAsync<T>(endpoint, HttpMethod.Post, encodeJson, values, false, cancellationToken).ConfigureAwait(false);
        return result!;
    }

    /// <summary>
    /// Sends a POST API query to Ontraport and returns the response as a JsonElement for custom parsing.
    /// </summary>
    /// <typeparam name="T">The expected response data type. Set to JsonElement to parse manually. Set to Object to discard output.</typeparam>
    /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
    /// <param name="values">Values set by the method type.</param>
    /// <param name="encodeJson">True to encode the request as Json, false to encode as query data.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An ApiResponse of the expected type.</returns>
    /// <exception cref="InvalidOperationException">There was an error while sending or parsing the request.</exception>
    /// <exception cref="HttpRequestException">There was an HTTP communication error or Ontraport returned an error.</exception>
    /// <exception cref="TaskCanceledException">The request timed-out or the user canceled the request's Task.</exception>
    public async Task<JsonElement> PostJsonAsync(string endpoint, IDictionary<string, object?>? values = null, bool encodeJson = true, CancellationToken cancellationToken = default)
    {
        var result = await RequestJsonAsync(endpoint, HttpMethod.Post, encodeJson, values, false, cancellationToken).ConfigureAwait(false);
        return result.Value;
    }

    /// <summary>
    /// Sends a PUT API query to Ontraport and deserializes the response as an object.
    /// </summary>
    /// <typeparam name="T">The expected response data type. Set to JsonElement to parse manually. Set to Object to discard output.</typeparam>
    /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <param name="values">Values set by the method type.</param>
    /// <returns>An ApiResponse of the expected type.</returns>
    /// <exception cref="InvalidOperationException">There was an error while sending or parsing the request.</exception>
    /// <exception cref="HttpRequestException">There was an HTTP communication error or Ontraport returned an error.</exception>
    /// <exception cref="TaskCanceledException">The request timed-out or the user canceled the request's Task.</exception>
    public async Task<T> PutAsync<T>(string endpoint, IDictionary<string, object?>? values = null, CancellationToken cancellationToken = default)
        where T : class
    {
        var result = await RequestAsync<T>(endpoint, HttpMethod.Put, true, values, false, cancellationToken).ConfigureAwait(false);
        return result!;
    }

    /// <summary>
    /// Sends a PUT API query to Ontraport and returns the response as a JsonElement for custom parsing.
    /// </summary>
    /// <typeparam name="T">The expected response data type. Set to JsonElement to parse manually. Set to Object to discard output.</typeparam>
    /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <param name="values">Values set by the method type.</param>
    /// <returns>An ApiResponse of the expected type.</returns>
    /// <exception cref="InvalidOperationException">There was an error while sending or parsing the request.</exception>
    /// <exception cref="HttpRequestException">There was an HTTP communication error or Ontraport returned an error.</exception>
    /// <exception cref="TaskCanceledException">The request timed-out or the user canceled the request's Task.</exception>
    public async Task<JsonElement> PutJsonAsync(string endpoint, IDictionary<string, object?>? values = null, CancellationToken cancellationToken = default)
    {
        var result = await RequestJsonAsync(endpoint, HttpMethod.Put, true, values, false, cancellationToken).ConfigureAwait(false);
        return result.Value;
    }

    /// <summary>
    /// Sends an API query to Ontraport and deserializes the result into an object.
    /// </summary>
    /// <typeparam name="T">The expected response data type. Set to JsonElement to parse manually. Set to Object to discard output.</typeparam>
    /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
    /// <param name="method">The web request method.</param>
    /// <param name="encodeJson">True to encode the request as Json, false to encode as URL query.</param>
    /// <param name="values">Values set by the method type.</param>
    /// <param name="returnNotFoundAsNull">If true, response code 404 will be returned as null instead of an exception.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An ApiResponse of the expected type.</returns>
    /// <exception cref="InvalidOperationException">There was an error while sending or parsing the request.</exception>
    /// <exception cref="HttpRequestException">There was an HTTP communication error or Ontraport returned an error.</exception>
    /// <exception cref="TaskCanceledException">The request timed-out or the user canceled the request's Task.</exception>
    protected async Task<T?> RequestAsync<T>(string endpoint, HttpMethod method, bool encodeJson, IDictionary<string, object?>? values = null, bool returnNotFoundAsNull = false, CancellationToken cancellationToken = default)
        where T : class
    {
        using var response = await SendRequestAsync(endpoint, method, encodeJson, values, returnNotFoundAsNull, cancellationToken).ConfigureAwait(false);
        if (response == null)
        {
            return null;
        }
        using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

        // Log response.
        if (_logger?.IsEnabled(LogLevel.Trace) == true)
        {
            using var logReader = new StreamReader(responseStream, Encoding.UTF8, true, 512, true);
            var logMsg = logReader.ReadToEnd();
            _logger?.LogInformation(logMsg);
            responseStream.Seek(0, SeekOrigin.Begin);
        }

        if (typeof(T) == typeof(object))
        {
            return (T?)null;
        }
        else
        {
            // Parse response.
            try
            {
                var result = await JsonSerializer.DeserializeAsync<ApiResponse<T>>(responseStream, OntraportSerializerOptions.Default, CancellationToken.None).ConfigureAwait(false);
                if (result.Code != 0)
                {
                    throw new InvalidOperationException(Res.ResponseErrorCode.FormatInvariant(result.Code));
                }
                if (result.Data == null)
                {
                    throw new InvalidOperationException(Res.InvalidResponseData);
                }
                return result.Data!;
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException(Res.InvalidResponseData, ex);
            }
        }
    }

    /// <summary>
    /// Sends an API query to Ontraport and returns a JsonElement.
    /// </summary>
    /// <typeparam name="T">The expected response data type. Set to JsonElement to parse manually. Set to Object to discard output.</typeparam>
    /// <param name="endpoint">The URL endpoint, excluding that goes after https://api.ontraport.com/1/ </param>
    /// <param name="method">The web request method.</param>
    /// <param name="encodeJson">True to encode the request as Json, false to encode as URL query.</param>
    /// <param name="values">Values set by the method type.</param>
    /// <param name="returnNotFoundAsNull">If true, response code 404 will be returned as null instead of an exception.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An ApiResponse of the expected type.</returns>
    /// <exception cref="InvalidOperationException">There was an error while sending or parsing the request.</exception>
    /// <exception cref="HttpRequestException">There was an HTTP communication error or Ontraport returned an error.</exception>
    /// <exception cref="TaskCanceledException">The request timed-out or the user canceled the request's Task.</exception>
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "Reviewed: It is safe to let the GC dispose the MemoryStream.")]
    protected async Task<JsonElement?> RequestJsonAsync(string endpoint, HttpMethod method, bool encodeJson, IDictionary<string, object?>? values = null, bool returnNotFoundAsNull = false, CancellationToken cancellationToken = default)
    {
        using var response = await SendRequestAsync(endpoint, method, encodeJson, values, returnNotFoundAsNull, cancellationToken).ConfigureAwait(false);
        if (response == null)
        {
            return null;
        }

        // Create a copy of the stream that we have control over.
        using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        var responseCopy = new MemoryStream();
        responseStream.CopyTo(responseCopy);
        responseCopy.Seek(0, SeekOrigin.Begin);

        // Log response.
        if (_logger?.IsEnabled(LogLevel.Trace) == true)
        {
            var logMsg = Encoding.UTF8.GetString(responseCopy.GetBuffer());
            _logger?.LogInformation(logMsg);
        }

        try
        {
            var doc = await JsonDocument.ParseAsync(responseCopy, new JsonDocumentOptions(), CancellationToken.None).ConfigureAwait(false);
            return doc.RootElement;
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException(Res.InvalidResponseData, ex);
        }
    }

    /// <summary>
    /// Sends an API query to Ontraport.
    /// </summary>
    private async Task<HttpResponseMessage?> SendRequestAsync(string endpoint, HttpMethod method, bool encodeJson, IDictionary<string, object?>? values = null, bool returnNotFoundAsNull = false, CancellationToken cancellationToken = default)
    {
        endpoint.CheckNotNull(nameof(endpoint));
        values ??= new Dictionary<string, object?>();

        // Serialize request.
        var content = encodeJson ?
            JsonSerializer.Serialize(values, OntraportSerializerOptions.Default) :
            values!.ToQueryString();

        var requestUrl = endpoint;
        if ((method == HttpMethod.Get || method == HttpMethod.Delete) && !encodeJson && !string.IsNullOrEmpty(content))
        {
            requestUrl += "?" + content;
            content = null;
        }

        // Log request.
        if (_logger?.IsEnabled(LogLevel.Information) == true)
        {
            _logger?.LogInformation("{Method} {BaseAddress}{Endpoint}    {Content}", method, _httpClient.BaseAddress, endpoint, content ?? string.Empty);
        }
        
        using var request = new HttpRequestMessage(method, requestUrl)
        {
            Content = content != null ? new StringContent(content, Encoding.UTF8, encodeJson ? ContentJson : ContentUrl) : null
        };
        var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

        // Return null instead of throwing an error when object is not found.
        if (returnNotFoundAsNull && response.StatusCode == HttpStatusCode.NotFound)
        {
            return default;
        }
        else
        {
            response.EnsureSuccessStatusCode();
        }
        return response;
    }
}
