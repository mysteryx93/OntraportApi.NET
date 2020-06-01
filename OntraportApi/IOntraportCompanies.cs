using System;
using HanumanInstitute.OntraportApi.Models;

namespace HanumanInstitute.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for Companies objects.
    /// </summary>
    /// <typeparam name="T">A type deriving from ApiCompany exposing additional custom fields.</typeparam>
    public interface IOntraportCompanies<T> : IOntraportBaseCustomObject<T>
        where T : ApiCompany
    {
    }
}
