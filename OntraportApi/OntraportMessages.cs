using System;
using System.Text.Json;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;

namespace HanumanInstitute.OntraportApi
{
    /// <summary>
    /// Provides API support for Message objects.
    /// Message objects contain data for all of the messages in an account. Supported message types include ONTRAmail, legacy HTML emails, 
    /// SMS, task messages, and postcards. All of these types can be retrieved through the API, and all but postcards can be created and updated. 
    /// When modifying message content, pay close attention to the format required to avoid unexpected results.
    /// </summary>
    public class OntraportMessages : OntraportBaseWrite<ApiMessage>, IOntraportMessages
    {
        public OntraportMessages(OntraportHttpClient apiRequest) : 
            base(apiRequest, "Message", "Messages", ApiMessage.AliasKey)
        { }

        // It's normally under data/attrs.
        protected override ApiMessage OnParseUpdate(JsonElement json) => 
            CreateApiObject(json.JsonData());
    }
}
