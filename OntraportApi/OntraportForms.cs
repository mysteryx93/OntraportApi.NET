using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Newtonsoft.Json.Linq;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for Form objects.
    /// Forms are used to simply and easily gather information from your contacts. Our ONTRAforms are the recommended form type, as we offer 
    /// many pre-designed and customizable templates which will greatly simplify your process. We also offer legacy SmartForms, which allow you to create your own designs.
    /// </summary>
    public class OntraportForms : OntraportBaseRead<ApiForm>, IOntraportForms
    {
        public OntraportForms(OntraportHttpClient apiRequest) :
            base(apiRequest, "Form", "Forms")
        { }

        /// <summary>
        /// Retrieves the HTML for a SmartForm by its ID. This endpoint does not support ONTRAforms.
        /// </summary>
        /// <param name="formId">The ID of the form to retrieve HTML for.</param>
        /// <returns>The form HTML.</returns>
        public async Task<string> SelectSmartFormHtmlAsync(int formId)
        {
            var query = new Dictionary<string, object>
            {
                { "id", formId }
            };

            return await ApiRequest.GetAsync<string>(
                "form", query);
        }

        /// <summary>
        /// Retrieves name and ID pairs for all existing form blocks.
        /// </summary>
        /// <param name="page">The zero-indexed page number. 50 entries are returned per page.</param>
        /// <returns>A dictionary of form blocks.</returns>
        public async Task<IDictionary<string, string>> SelectAllFormBlocksAsync(int? page = null)
        {
            var query = new Dictionary<string, object>()
                .AddIfHasValue("page", page);

            return await ApiRequest.GetAsync<Dictionary<string, string>>(
                "Form/getAllFormBlocks", query);
        }

        /// <summary>
        /// Retrieves IDs for all form blocks in a specified form or landing page.
        /// </summary>
        /// <param name="formName">The name of the form.</param>
        /// <returns>The list of block IDs.</returns>
        public async Task<IEnumerable<string>> SelectBlocksByFormNameAsync(string formName)
        {
            var query = new Dictionary<string, object>
            {
                { "name", formName }
            };

            var json = await ApiRequest.GetAsync<JObject>(
                "Form/getBlocksByFormName", query);
            return json["data"]["block_ids"].ToObject<IEnumerable<string>>();
        }
    }
}
