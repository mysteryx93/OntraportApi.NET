using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;

namespace HanumanInstitute.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for Form objects.
    /// Forms are used to simply and easily gather information from your contacts. Our ONTRAforms are the recommended form type, as we offer 
    /// many pre-designed and customizable templates which will greatly simplify your process. We also offer legacy SmartForms, which allow you to create your own designs.
    /// </summary>
    public interface IOntraportForms : IOntraportBaseRead<ApiForm>
    {
        /// <summary>
        /// Retrieves the HTML for a SmartForm by its ID. This endpoint does not support ONTRAforms.
        /// </summary>
        /// <param name="formId">The ID of the form to retrieve HTML for.</param>
        /// <returns>The form HTML.</returns>
        Task<string?> SelectSmartFormHtmlAsync(int formId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves name and ID pairs for all existing form blocks.
        /// </summary>
        /// <param name="page">The zero-indexed page number. 50 entries are returned per page.</param>
        /// <returns>A dictionary of form blocks.</returns>
        Task<IDictionary<string, string>> SelectAllFormBlocksAsync(int? page = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves IDs for all form blocks in a specified form or landing page.
        /// </summary>
        /// <param name="formName">The name of the form.</param>
        /// <returns>The list of block IDs.</returns>
        Task<IEnumerable<string>> SelectBlocksByFormNameAsync(string formName, CancellationToken cancellationToken = default);
    }
}
