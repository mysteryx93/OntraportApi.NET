using System;
using HanumanInstitute.OntraportApi.Models;

namespace HanumanInstitute.OntraportApi
{
    /// <summary>
    /// Provides API support for Message objects.
    /// Message objects contain data for all of the messages in an account. Supported message types include ONTRAmail, legacy HTML emails, 
    /// SMS, task messages, and postcards. All of these types can be retrieved through the API, and all but postcards can be created and updated. 
    /// When modifying message content, pay close attention to the format required to avoid unexpected results.
    /// </summary>
    public interface IOntraportMessages : IOntraportBaseWrite<ApiMessage>
    {
    }
}
