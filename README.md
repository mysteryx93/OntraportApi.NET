# EmergenceGuardian.OntraportApi
Strongly-Typed .NET Wrapper for Ontraport API.

Fully supports .NET Core and Dependency Injection.

If you want to support this project, [subscribe to Ontraport via my affiliate link.](https://ontraport.com/?orid=480125&utm_source=referral&utm_medium=inapp&utm_campaign=refer&utm_term=ShareTheLove&utm_content=ontraport)

## What is Ontraport?

Ontraport is essentially the engine that powers all the interactions between you and your customers online — in ways that wouldn’t be possible manually.

It does everything related to email marketing and automation for your business, just like InfusionSoft, but it's cheaper and more user-friendly.

Their [API documentation is available here](https://api.ontraport.com/doc/), but it is very complex and difficult to use manually. This library makes it very simple, allowing you to focus on your .NET web application while letting Ontraport manage the business-side of it and all email communications campaigns.

## Sample Code

Return the name and birthday of a contact by email.

```c#
public async Task<string> GetCustomerNameAndBirthday(string email)
{
    var customer = await _ontraContacts.SelectAsync(email);
    return $"{customer.FirstNameValue} {customer.LastNameValue} - {customer.BirthdayValue}";
}
```

Add or merge a contact

```c#
public async Task AddOrMergeContact(string email, string firstName, string lastName)
{
    var contact = new ApiContact()
    {
        EmailValue = email,
        FirstNameValue = firstName,
        LastNameValue = lastName
     };
    await _ontraContacts.CreateOrMergeAsync(contact.GetChanges());
}
```

Edit contacts

```c#
public async Task EditCompany(string oldName, string newName)
{
    var contacts = await _ontraContacts.SelectMultipleAsync(
        new ApiSearchOptions().AddCondition("company", "=", oldName));
    var tasks = contacts.Select(async x =>
    {
        x.CompanyValue = newName;
        return await _ontraContacts.UpdateAsync(x.IdValue, x.GetChanges());
    });
    await Task.WhenAll(tasks);
}
```

Log a transaction manually

```c#
public async Task LogTransaction(string email, string productName, int quantity)
{
    var customer = await _ontraContacts.SelectAsync(email);
    var product = await _ontraProducts.SelectAsync(productName);
    await _ontraTransactions.LogTransactionAsync(customer.IdValue,
        new ApiTransactionOffer().AddProduct(product.IdValue, quantity, product.PriceValue));
}
```    

## Supported Classes

Fully-typed API and classes for all main documented classes (and a few more), with very good documentation for Intellisense.
- CampaignBuilderItems
- Companies
- Contacts
- CouponCodes
- CouponProducts
- Coupons
- CreditCards
- CustomObjects
- Deals
- Forms
- LandingPages
- Messages
- Objects
- Offers
- Products
- Rules
- Tasks
- Transactions
- Webhooks

Each typed ApiObject has integrated changes-tracking support. You can return a dictionary of edited field keys and values with GetChanges().

All data formatting and parsing, such as Unix Epoch date time format to DateTimeOffset, is done automatically.

All other object types can be used via IOntraportObjects.
