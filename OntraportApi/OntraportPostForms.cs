using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Sends data to Ontraport by posting a SmartForm which can then perform additional actions. 
    /// This can be used as an alternative to the API. The form post can be done from the client's browser or from the server.
    /// </summary>
    public class OntraportPostForms : IOntraportPostForms
    {
        private const string FormPosttUrl = "https://forms.ontraport.com/v2.4/form_processor.php?";
        private readonly HttpClient _httpClient;

        public OntraportPostForms(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(FormPosttUrl);
        }

        /// <summary>
        /// Posts an Ontraport form with specified data from the server. This method does not lock the thread.
        /// </summary>
        /// <param name="formId">The Ontraport UID of the form.</param>
        /// <param name="formParams">The list of form data to send.</param>
        public async void ServerPost(string formId, IDictionary<string, object> formParams)
        {
            formParams = formParams ?? new Dictionary<string, object>();
            formParams.Add("uid", formId);
            var formString = formParams.Select(x => new KeyValuePair<string, string>(x.Key, x.Value?.ToStringInvariant()));
            await _httpClient.PostAsync("", new FormUrlEncodedContent(formString));
        }

        /// <summary>
        /// Posts an Ontraport form with specified data from the client.
        /// </summary>
        /// <param name="response">The Http response handler.</param>
        /// <param name="formId">The Ontraport UID of the form.</param>
        /// <param name="formParams">The list of form data to send.</param>
        /// <returns>The HTML page that performs the post and redirect.</returns>
        public string ClientPost(string formId, IDictionary<string, object> formParams)
        {
            formParams = formParams ?? new Dictionary<string, object>();
            formParams.Add("uid", formId);

            var response = new StringBuilder()
                .AppendLine("<html>")
                .AppendLine("<body onload='document.forms[0].submit();'>")
                .AppendLine($"<form action='{FormPosttUrl}' method='post' accept-charset='UTF-8'>");
            foreach (var item in formParams)
            {
                var key = WebUtility.HtmlEncode(item.Key);
                var value = WebUtility.HtmlEncode(item.Value.ToString());
                response.AppendLine($"<input type=\"hidden\" name=\"{key}\" value=\"{value}\"/>");
            }
            response.AppendLine("</form>")
                .AppendLine("</body>")
                .AppendLine("</html>");

            return response.ToString();
        }
    }
}
