namespace HanumanInstitute.OntraportApi;

/// <summary>
/// Provides Ontraport API support for Transaction objects.
/// A transaction object is created when one of your contacts purchases a product.
/// </summary>
public interface IOntraportTransactions : IOntraportBaseRead<ApiTransaction>
{
    Task MarkCollectionsAsync(int transactionId, CancellationToken cancellationToken = default);
    /// <summary>
    /// Marks a transaction as in collections.
    /// </summary>
    /// <param name="transactionId">The transaction ID.</param>

    /// <summary>
    /// Marks a transaction as declined.
    /// </summary>
    /// <param name="transactionId">The transaction ID.</param>
    Task MarkDeclinedAsync(int transactionId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Marks a transaction as paid.
    /// </summary>
    /// <param name="transactionId">The transaction ID.</param>
    Task MarkPaidAsync(int transactionId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an order to include new offer data. For example, to update the credit card tied to the recurring subscription.
    /// </summary>
    /// <param name="offer">The product and pricing offer for the transaction.</param>
    Task UpdateOrderAsync(ApiOffer offer, CancellationToken cancellationToken = default);

    /// <summary>
    /// Processes a transaction for a contact. Please note that this request requires valid parameters for all associated members of the transaction or the request will fail.
    /// </summary>
    /// <param name="contactId">The ID of the contact for whom a transaction should be created.</param>
    /// <param name="gatewayId">The ID of the gateway to use for this transaction. Note that this is the ID of the gateway object itself and not the external_id of the gateway.</param>
    /// <param name="offer">The product and pricing offer for the transaction.</param>
    /// <param name="billingAddress">The complete billing address information for this transaction. Only required if not already on file for this contact.</param>
    /// <param name="payer">The credit card information for this transaction. Only required if not already on file for this contact.</param>
    /// <param name="creditCardId">The existing credit card to use for this transaction, when not specifying payer. Leave both payer and creditCardId null to use the default care on file.</param>
    /// <param name="externalOrderId">Optional external order id that you can save within the generated transaction.</param>
    /// <param name="transactionDate">The date and time of the transaction.</param>
    /// <param name="invoiceTemplate">The ID of the invoice template to use for this transaction. The default invoice ID is 1.</param>
    /// <returns>The transaction result.</returns>
    Task<ApiTransactionResult> ProcessManualAsync(int contactId, int gatewayId, ApiTransactionOffer offer, ApiTransactionAddress? billingAddress = null, ApiTransactionPayer? payer = null, int? creditCardId = null, string? externalOrderId = null, DateTimeOffset? transactionDate = null, int invoiceTemplate = 1, CancellationToken cancellationToken = default);

    /// <summary>
    /// Far less data is needed to simply log a transaction than to manually process one. The gateway, payer, and billing details are unnecessary 
    /// in this case. The mandatory information in this case include a contact ID, the "chargeLog" designation, and product and pricing details.
    /// </summary>
    /// <param name="contactId">The ID of the contact for whom a transaction should be created.</param>
    /// <param name="offer">The product and pricing offer for the transaction.</param>
    /// <param name="externalOrderId">Optional external order id that you can save within the generated transaction.</param>
    /// <param name="transactionDate">The date and time of the transaction.</param>
    /// <param name="invoiceTemplate">The ID of the invoice template to use for this transaction. The default invoice ID is 1.</param>
    /// <returns>The invoice ID.</returns>
    Task<int> LogTransactionAsync(int contactId, ApiTransactionOffer offer, string? externalOrderId = null, DateTimeOffset? transactionDate = null, int invoiceTemplate = 1, CancellationToken cancellationToken = default);

    /// <summary>
    /// Refunds a previously charged transaction.
    /// </summary>
    /// <param name="searchOptions">The search options.</param>
    Task RefundAsync(ApiSearchOptions searchOptions, CancellationToken cancellationToken = default);

    /// <summary>
    /// Reruns a previously charged transaction.
    /// </summary>
    /// <param name="searchOptions">The search options.</param>
    Task RerunAsync(ApiSearchOptions searchOptions, CancellationToken cancellationToken = default);

    /// <summary>
    /// Reruns partner commissions for a previously charged transaction.
    /// </summary>
    /// <param name="searchOptions">The search options.</param>
    Task RerunCommissionsAsync(ApiSearchOptions searchOptions, CancellationToken cancellationToken = default);

    /// <summary>
    /// Resends an invoice for a previously charged transaction.
    /// </summary>
    /// <param name="searchOptions">The search options.</param>
    Task ResendInvoiceAsync(ApiSearchOptions searchOptions, CancellationToken cancellationToken = default);

    /// <summary>
    /// Voids a previously charged transaction.
    /// </summary>
    /// <param name="searchOptions">The search options.</param>
    Task VoidAsync(ApiSearchOptions searchOptions, CancellationToken cancellationToken = default);

    /// <summary>
    /// Writes off a previously charged transaction.
    /// </summary>
    /// <param name="searchOptions">The search options.</param>
    Task WriteOffAsync(ApiSearchOptions searchOptions, CancellationToken cancellationToken = default);
}
