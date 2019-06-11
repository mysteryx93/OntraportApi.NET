using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Newtonsoft.Json.Linq;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Provides API support for Message objects.
    /// Message objects contain data for all of the messages in an account. Supported message types include ONTRAmail, legacy HTML emails, 
    /// SMS, task messages, and postcards. All of these types can be retrieved through the API, and all but postcards can be created and updated. 
    /// When modifying message content, pay close attention to the format required to avoid unexpected results.
    /// </summary>
    public class OntraportMessages : OntraportBaseWrite<ApiMessage>, IOntraportMessages
    {
        public OntraportMessages(IOntraportRequestHelper apiRequest) : 
            base(apiRequest, "Message", "Messages", "alias")
        { }

        // It's normally under data/attrs.
        protected override async Task<ApiMessage> OnParseUpdateAsync(JObject json) => await CreateApiObjectAsync(json["data"]);
    }
}
