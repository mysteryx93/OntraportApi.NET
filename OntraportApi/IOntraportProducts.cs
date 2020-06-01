using System;
using HanumanInstitute.OntraportApi.Models;

namespace HanumanInstitute.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for Product objects.
    /// Product objects allow you to process transactions and order forms. 
    /// Products can be associated with many other objects such as transactions, offers, orders, and forms. 
    /// You can access additional functionality for adding products to transactions or offers using the transactions API.
    /// </summary>
    public interface IOntraportProducts : IOntraportBaseDelete<ApiProduct>
    {
    }
}
