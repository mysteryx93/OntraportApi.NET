using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace HanumanInstitute.OntraportApi.Models
{
    public class ResponseSuccessList
    {
        public ResponseSuccessList()
        {
        }

        /// <summary>
        /// Initializes a new instance of ResponseSuccessList and parses the data from a JSON parser.
        /// </summary>
        /// <param name="json"></param>
        public ResponseSuccessList(JObject json)
        {
            json.CheckNotNull(nameof(json));
            var data = json["data"];
            if (data != null)
            {
                var jsonSuccess = data["success"];
                var jsonError = data["error"];
                if (jsonSuccess?.Any() == true)
                {
                    Success = jsonSuccess.ToObject<IDictionary<string, string>>()!;
                }
                if (jsonError?.Any() == true)
                {
                    Error = jsonError.ToObject<IDictionary<string, string>>()!;
                }
            }
        }

        public IDictionary<string, string> Success { get; private set; } = new Dictionary<string, string>();
        public IDictionary<string, string> Error { get; private set; } = new Dictionary<string, string>();
    }
}
