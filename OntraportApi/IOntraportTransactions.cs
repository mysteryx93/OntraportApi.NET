using System;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for Transaction objects.
    /// A transaction object is created when one of your contacts purchases a product.
    /// </summary>
    public interface IOntraportTransactions : IOntraportBaseRead<ApiTransaction>
    {
    }
}
