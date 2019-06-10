using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EmergenceGuardian.OntraportApi.Models
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
            var jsonSuccess = json["data"]["success"];
            var jsonError = json["data"]["error"];
            if (jsonSuccess.Any())
            {
                Success = jsonSuccess.ToObject<IDictionary<string, string>>();
            }
            if (jsonError.Any())
            {
                Error = jsonError.ToObject<IDictionary<string, string>>();
            }
        }

        public IDictionary<string, string> Success { get; set; } = new Dictionary<string, string>();
        public IDictionary<string, string> Error { get; set; } = new Dictionary<string, string>();
    }
}
