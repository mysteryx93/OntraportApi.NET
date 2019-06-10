using System;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for CreditCard objects.
    /// Credit cards objects store data for a contact's saved credit cards, including card information, type, status, and billing details.
    /// </summary>
    public interface IOntraportCreditCards : IOntraportBaseRead<ApiCreditCard>
    {
        /// <summary>
        /// Sets the status of an existing card to default and adjusts the status of the current default card.
        /// </summary>
        /// <param name="creditCardId">The credit card ID.</param>
        /// <returns>An ApiCreditCard containing updated fields.</returns>
        Task<ApiCreditCard> SetDefaultAsync(int creditCardId);
    }
}
