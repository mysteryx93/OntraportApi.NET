# EmergenceGuardian.OntraportApi
.NET Library to Consume Ontraport API in a Strongly-Typed Way

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
    return $"{customer.FirstName} {customer.LastName} - {customer.Birthday}";
}
```

Add or merge a contact

```c#
public async Task AddOrMergeContact(string email, string firstName, string lastName)
{
    var contact = new ApiContact()
    {
        Email = email,
        FirstName = firstName,
        LastName = lastName
    };
    await _ontraContacts.CreateOrMergeAsync(contact.GetChanges());
}
```

Edit contacts

```c#
public async Task EditCompanyField(string oldName, string newName)
{
    var contacts = await _ontraContacts.SelectMultipleAsync(
        new ApiSearchOptions().AddCondition(ApiContact.CompanyKey, "=", oldName));
    var tasks = contacts.Select(async x =>
    {
        x.Company = newName;
        return await _ontraContacts.UpdateAsync(x.Id.Value, x.GetChanges());
    });
    await Task.WhenAll(tasks);
}
```

Log a transaction manually

```c#
public async Task LogTransaction(string email, string productName, int quantity)
{
    var contact = await _ontraContacts.CreateOrMergeAsync(new ApiContact()
    {
        Email = email
    }.GetChanges());
    var product = await _ontraProducts.SelectAsync(productName);
    await _ontraTransactions.LogTransactionAsync(contact.Id.Value,
        new ApiTransactionOffer().AddProduct(product.Id.Value, quantity, product.Price.Value));
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

[Ontraport supports many other (undocumented) objects](https://api.ontraport.com/doc/#accessible-objects) which can be used via IOntraportObjects.


## How to Configure in ASP.NET Core

Add *EmergenceGuardian.OntraportApi* and *EmergenceGuardian.OntraportApi.AspNetCore* to your project via NuGet.

Add this to ConfigureServices in Startup.cs

```c#
services.Configure<OntraportConfig>(options => Configuration.Bind("Ontraport", options));
services.AddOntraportApi();
```

Add this to appsettings.json

```
"Ontraport": {
  "AppId": "your-app-id",
  "ApiKey": "your-api-key"
}
```

#### Adding Polly

For better reliability of communication,  you can use [Polly](http://www.thepollyproject.org/) to automatically retry API requests on timeout or failure.

Add *Polly* and *Microsoft.Extensions.Http.Polly* to your project via NuGet.

Add something like this just before services.AddOntraportApi();

```c#
services.AddHttpClient<OntraportHttpClient>()
    .AddTransientHttpErrorPolicy(p =>
        p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(600)));
```

#### Using a different version of .NET or a different IoC container?

No problem, [this is the only class](https://github.com/mysteryx93/EmergenceGuardian.OntraportApi/blob/master/OntraportApi.AspNetCore/OntraportApiServiceCollectionExtensions.cs) that depends on .NET Core so you can easily rewrite it for whatever technology you use.


## Posting SmartForms

In many cases, a simpler way to send data to Ontraport is to simply submit a SmartForm. Then, you can perform additional actions in your form via Ontraport. You can obtain the form id and custom field names (that look like f0000) by clicking Publish and looking at the HTML view.

Posting forms doesn't have any kind of security so it works in many cases but don't use this for important management data.

To post forms, use *IOntraportPostForms*. It supports posting via the client's browser or via the server.

You do not need an API key to submit forms. If you wish to only post forms without using the rest of the API, you can register it with *services.AddOntraportPostForms*

```c#
public void PostForm(string email, string firstName)
{
    _ontraPostForms.ServerPost("my-form-id", new ApiContact()
    {
        Email = email,
        FirstName = firstName
    }.GetChanges());
}
```


## Adding Custom Fields

Simple way: you can access all custom property using the Data property of the object returned by the API. It exposes all raw data returned from Ontraport.

To add strongly-typed support for your custom fields for Contact, Company and Deal objects, create a class defining your extra fields.

You can get the list of custom field keys using the *GetCustomFieldsAsync* method.

```c#
public class ApiCustomContact : ApiContact
{
    public ApiPropertyString Custom1Field => _custom1Field ?? (_custom1Field = new ApiPropertyString(this, Custom1Key));
    private ApiPropertyString _custom1Field;
    public const string Custom1Key = "f1234";
    public string Custom1 { get => Custom1Field.Value; set => Custom1Field.Value = value; }

    public ApiPropertyDateTime Custom2Field => _custom2Field ?? (_custom2Field = new ApiPropertyDateTime(this, Custom2Key));
    private ApiPropertyDateTime _custom2Field;
    public const string Custom2Key = "f2222";
    public DateTimeOffset? Custom2 { get => Custom2Field.Value; set => Custom2Field.Value = value; }
}
```

Then, use *OntraportContacts\<ApiCustomContact\>* instead of *OntraportContacts<ApiContact>*. You may want to create this class for convenience.

```c#
public class OntraportContacts : OntraportContacts\<ApiCustomContact\>, IOntraportContacts
{ }

public interface IOntraportContacts : IOntraportContacts\<ApiCustomContact\>
{ }
```

Don't forget to register your new class in Startup.cs
```c#
services.AddTransient<IOntraportContacts, OntraportContacts>();
```
    
Supprted ApiProperty types (and you can easily implement your own parser):
- ApiProperty\<int\>
- ApiProperty\<decimal\>
- ApiProperty\<float\>
- ApiPropertyString
- ApiPropertyBool ("true", "false" parsed as Boolean)
- ApiPropertyDateTime (Unix Epoch seconds date parsed as DateTimeOffset)
- ApiPropertyIntBool ("1", "0", parsed as Boolean)
- ApiPropertyIntEnum\<T\> (Numeric field parsed as enumeration of type T)
- ApiPropertyStringEnum\<T\> (string parsed as enumeration of type T)
- ApiPropertyTimeSpan (seconds parsed as Timespan)

## Adding Strongly-Typed Support for Custom Objects

Simple way: use OntraportObject with the ObjectTypeId of your custom object. It takes an ObjectType parameter of type ApiCustomObject but you can pass any integer like this: (ApiObjectType)10000. Custom Objects have an ObjectTypeId above 10000.

Custom Objects behave like Contacts. They have their standard fields, custom fields, campaigns, tags, rules and messages.

To add strongly-typed support for a custom object:

1. Create a class to expose all API methods related to custom objects. All methods are implemented through the base class.

```c#
public class OntraportRecordings : OntraportBaseCustomObject<ApiCustomObjectBase>
{
    public OntraportRecordings(OntraportHttpClient apiRequest) :
        base(apiRequest, "Recording", "Recordings", ObjectTypeId, "name")
    { }
    
    public static int ObjectTypeId = 10000;
}
```

2. Register it in ConfigureServices in Startup.cs

```c#
services.AddTransient<OntraportRecordings>();
```

3. Obtain your list of custom fields using the *OntraportRecordings.GetCustomFieldsAsync* method. Obtain your ObjectTypeId using *IOntraportCustomObjects.SelectAsync*.

4. Create a typed object exposing all your custom fields. Your class will inherit from ApiCustomObjectBase.

```c#
public class ApiRecording : ApiCustomObjectBase
{
    public ApiProperty<int> Custom1Field => _custom1Field ?? (_custom1Field = new ApiProperty<int>(this, Custom1Key));
    private ApiProperty<int> _custom1Field;
    public const string Custom1Key = "f3333";
    public int? Custom1 { get => Custom1Field.Value; set => Custom1Field.Value = value; }
}
```

5. Change your OntraportRecordings class definition to return ApiRecording

6. Add an Interface for your class

```c#
public interface IOntraportRecordings : IOntraportBaseCustomObject<ApiRecording>
{ }
```

Your class definition will now look like this:

```c#
public class OntraportRecordings : OntraportBaseCustomObject<ApiRecording>, IOntraportRecordings
```

7. Update your service registration in Startup.cs

```c#
services.AddTransient<IOntraportRecordings, OntraportRecordings>();
```

## Unit Testing the Source Code

DO NOT RUN TESTS ON YOUR LIVE ONTRAPORT ACCOUNT

[Ask for a SandBox account here.](https://ontraport.com/tools/sandbox)

We can't control the server environment and thus must run Integration Tests. Current integration tests are sufficient to show it's working, but more work could be done so they can run reliably and test more in-depth.

To run Unit Tests, Ontraport API credentials must be set in your User Secret Manager. Open the command-line tool and navigate to the OntraportApi.IntegrationTests project directory.

Use the following commands to set your keys to your sandbox account
```
dotnet user-secrets set OntraportAppId ""your-app-id-here""
dotnet user-secrets set OntraportApiKey ""your-api-key-here""");
```
 
## About The Author

[Etienne Charland](https://www.spiritualselftransformation.com), known as the Emergence Guardian, helps starseeds reconnect with their soul power to accomplish the purpose 
they came here to do. [You can read his book at Satrimono Publishing.](https://satrimono.com/) Warning: non-geek zone.

You may also be interested in the [Natural Grounding Player, Yin Media Encoder, 432hz Player, Powerliminals Player, and Audio Video Muxer.](https://github.com/mysteryx93/NaturalGroundingPlayer)
