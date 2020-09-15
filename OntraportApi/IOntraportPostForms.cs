using System;
using System.Collections.Generic;

namespace HanumanInstitute.OntraportApi
{
    /// <summary>
    /// Sends data to Ontraport by posting a SmartForm which can then perform additional actions. 
    /// This can be used as an alternative to the API. The form post can be done from the client's browser or from the server.
    /// </summary>
    public interface IOntraportPostForms
    {
        /// <summary>
        /// Posts an Ontraport form with specified data from the server. This method does not lock the thread.
        /// </summary>
        /// <param name="formId">The Ontraport UID of the form.</param>
        /// <param name="formParams">The list of form data to send.</param>
        void ServerPost(string formId, IDictionary<string, object?> formParams, CancellationToken cancellationToken = default);

        /// <summary>
        /// Posts an Ontraport form with specified data from the client.
        /// </summary>
        /// <param name="response">The Http response handler.</param>
        /// <param name="formId">The Ontraport UID of the form.</param>
        /// <param name="formParams">The list of form data to send.</param>
        /// <returns>The HTML page that performs the post and redirect.</returns>
        string ClientPost(string formId, IDictionary<string, object?> formParams);
    }
}
