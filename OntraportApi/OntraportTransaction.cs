﻿namespace HanumanInstitute.OntraportApi;

/// <summary>
/// Provides Ontraport API support for Transaction objects.
/// A transaction object is created when one of your contacts purchases a product.
/// </summary>
public class OntraportTransactions : OntraportBaseRead<ApiTransaction>, IOntraportTransactions
{
    public OntraportTransactions(OntraportHttpClient apiRequest) :
        base(apiRequest, "Transaction", "Transactions")
    { }

    /// <summary>
    /// Marks a transaction as in collections.
    /// </summary>
    /// <param name="transactionId">The transaction ID.</param>
    public async Task MarkCollectionsAsync(int transactionId, CancellationToken cancellationToken = default)
    {
        var query = new Dictionary<string, object?>
        {
            { "id", transactionId }
        };

        await ApiRequest.PutAsync<object>(
            "transaction/convertToCollections", query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Marks a transaction as declined.
    /// </summary>
    /// <param name="transactionId">The transaction ID.</param>
    public async Task MarkDeclinedAsync(int transactionId, CancellationToken cancellationToken = default)
    {
        var query = new Dictionary<string, object?>
        {
            { "id", transactionId }
        };

        await ApiRequest.PutAsync<object>(
            "transaction/convertToDecline", query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Marks a transaction as paid.
    /// </summary>
    /// <param name="transactionId">The transaction ID.</param>
    public async Task MarkPaidAsync(int transactionId, CancellationToken cancellationToken = default)
    {
        var query = new Dictionary<string, object?>
        {
            { "id", transactionId }
        };

        await ApiRequest.PutAsync<object>(
            "transaction/markPaid", query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Updates an order to include new offer data. For example, to update the credit card tied to the recurring subscription.
    /// </summary>
    /// <param name="offer">The product and pricing offer for the transaction.</param>
    public async Task UpdateOrderAsync(ApiOffer offer, CancellationToken cancellationToken = default)
    {
        Check.NotNull(offer);

        var query = new Dictionary<string, object?>
        {
            { "offer", offer}
        };

        await ApiRequest.PutAsync<object>(
            "transaction/order", query, cancellationToken).ConfigureAwait(false);
    }

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
    public async Task<ApiTransactionResult> ProcessManualAsync(int contactId, int gatewayId,
        ApiTransactionOffer offer, ApiTransactionAddress? billingAddress = null, ApiTransactionPayer? payer = null,
        int? creditCardId = null, string? externalOrderId = null, DateTimeOffset? transactionDate = null, int invoiceTemplate = 1,
        CancellationToken cancellationToken = default)
    {
        Check.NotNull(offer);

        var query = new Dictionary<string, object?>
            {
                { "contact_id", contactId },
                { "chargeNow", "chargeNow" },
                { "invoice_template", invoiceTemplate },
                { "gateway_id", gatewayId },
                { "offer", offer }
            }
            .AddIfHasValue("external_order_id", externalOrderId)
            .AddIfHasValue("trans_date", new JsonConverterDateTimeNullable(true).Format(transactionDate))
            .AddIfHasValue("billing_address", billingAddress)
            .AddIfHasValue("payer", payer)
            .AddIfHasValue("cc_id", creditCardId);

        return await ApiRequest.PostAsync<ApiTransactionResult>(
            "transaction/processManual", query, true, cancellationToken).ConfigureAwait(false);
    }

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
    public async Task<int> LogTransactionAsync(int contactId, ApiTransactionOffer offer,
        string? externalOrderId = null, DateTimeOffset? transactionDate = null, int invoiceTemplate = 1, CancellationToken cancellationToken = default)
    {
        Check.NotNull(offer);

        var query = new Dictionary<string, object?>
            {
                { "contact_id", contactId },
                { "chargeNow", "chargeLog" },
                { "invoice_template", invoiceTemplate },
                { "offer", offer }
            }
            .AddIfHasValue("external_order_id", externalOrderId)
            .AddIfHasValue("trans_date", new JsonConverterDateTimeNullable(true).Format(transactionDate));

        var json = await ApiRequest.PostJsonAsync(
            "transaction/processManual", query, true, cancellationToken).ConfigureAwait(false);
        return await json.RunStructAndCatchAsync(x => json.JsonData().JsonChild("invoice_id").GetInt32()).ConfigureAwait(false);
    }

    /// <summary>
    /// Refunds a previously charged transaction.
    /// </summary>
    /// <param name="searchOptions">The search options.</param>
    public async Task RefundAsync(ApiSearchOptions searchOptions, CancellationToken cancellationToken = default)
    {
        var query = new Dictionary<string, object?>()
            .AddSearchOptions(searchOptions, this.GetKeysOverride());

        await ApiRequest.PutAsync<object>(
            "transaction/refund", query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Reruns a previously charged transaction.
    /// </summary>
    /// <param name="searchOptions">The search options.</param>
    public async Task RerunAsync(ApiSearchOptions searchOptions, CancellationToken cancellationToken = default)
    {
        var query = new Dictionary<string, object?>()
            .AddSearchOptions(searchOptions, this.GetKeysOverride());

        await ApiRequest.PostAsync<object>(
            "transaction/rerun", query, true, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Reruns partner commissions for a previously charged transaction.
    /// </summary>
    /// <param name="searchOptions">The search options.</param>
    public async Task RerunCommissionsAsync(ApiSearchOptions searchOptions, CancellationToken cancellationToken = default)
    {
        var query = new Dictionary<string, object?>()
            .AddSearchOptions(searchOptions, this.GetKeysOverride());

        await ApiRequest.PutAsync<object>(
            "transaction/rerunCommission", query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Resends an invoice for a previously charged transaction.
    /// </summary>
    /// <param name="searchOptions">The search options.</param>
    public async Task ResendInvoiceAsync(ApiSearchOptions searchOptions, CancellationToken cancellationToken = default)
    {
        var query = new Dictionary<string, object?>()
            .AddSearchOptions(searchOptions, this.GetKeysOverride());

        await ApiRequest.PostAsync<object>(
            "transaction/resendInvoice", query, true, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Voids a previously charged transaction.
    /// </summary>
    /// <param name="searchOptions">The search options.</param>
    public async Task VoidAsync(ApiSearchOptions searchOptions, CancellationToken cancellationToken = default)
    {
        var query = new Dictionary<string, object?>()
            .AddSearchOptions(searchOptions, this.GetKeysOverride());

        await ApiRequest.PutAsync<object>(
            "transaction/void", query, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Writes off a previously charged transaction.
    /// </summary>
    /// <param name="searchOptions">The search options.</param>
    public async Task WriteOffAsync(ApiSearchOptions searchOptions, CancellationToken cancellationToken = default)
    {
        var query = new Dictionary<string, object?>()
            .AddSearchOptions(searchOptions, this.GetKeysOverride());

        await ApiRequest.PutAsync<object>(
            "transaction/writeOff", query, cancellationToken).ConfigureAwait(false);
    }
}
