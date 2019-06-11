using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Newtonsoft.Json.Linq;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for Transaction objects.
    /// A transaction object is created when one of your contacts purchases a product.
    /// </summary>
    public class OntraportTransactions : OntraportBaseRead<ApiTransaction>, IOntraportTransactions
    {
        public OntraportTransactions(IOntraportRequestHelper apiRequest) : 
            base(apiRequest, "Transaction", "Transactions")
        { }

    }
}
