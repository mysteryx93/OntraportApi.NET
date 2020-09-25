# OntraportApi.NET
Strongly-Typed .NET API for Ontraport (Marketing Automation System)

Fully supports .NET Core and Dependency Injection.

I've spent a lot of time to develop this enterprise-grade framework and am making it available for free. However, **[please subscribe to Ontraport via my affiliate link to support this project!](https://ontraport.com/?orid=480125&utm_source=referral&utm_medium=inapp&utm_campaign=refer&utm_term=ShareTheLove&utm_content=ontraport)**

[What is Ontraport?](#what-is-ontraport)  
[Sample Code](#sample-code)  
[Supported Classes](#supported-classes)  
[How to Configure in ASP.NET Core](#how-to-configure)  
[Posting SmartForms](#posting-smartforms)  
[Adding Custom Fields](#adding-custom-fields)  
[Adding Strongly-Typed Support for Custom Objects](#custom-objects)  
[Switching Between Live and Dev Ontraport Accounts](#switching-accounts)  
[Ontraport Membership Provider for Identity Framework Core](#ontraport-membership-provider)  
[Unit Testing the Source Code](#unit-testing)  
[About The Author](#about)  


## <a name="what-is-ontraport"/>What is Ontraport?

Ontraport is essentially the engine that powers all the interactions between you and your customers online — in ways that wouldn’t be possible manually.

It does everything related to email marketing and automation for your business, just like InfusionSoft/Keap, but it's cheaper and more user-friendly.

Their [API documentation is available here](https://api.ontraport.com/doc/), but it is very complex and difficult to use manually. This library makes it very simple, allowing you to focus on your .NET web application while letting Ontraport manage the business-side of it and all email communications campaigns.

Your .NET application can combine a private database with Ontraport. In this case, you end up with two databases, and you have to be careful to keep both databases in sync, especially if users change their email addresses in Ontraport or you merge two duplicate records of a same user.

Another option is to store all your data in Ontraport, if your data structures are simple enough and if you don't mind the performance cost of fetching all the data via API requests. For a shopping-cart type of application, where most of the data is stored in Ontraport anyway, this is the best option and you don't need a local database.

If you do not use a local database, I've created a custom Identity Framework Membership Provider for Ontraport.


## <a name="sample-code"/>Sample Code

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

#### Exceptions

All API calls can throw either of these 3 exceptions. (as of v1.2)

**InvalidOperationException:** There was an error while sending or parsing the request.  
**HttpRequestException:** There was an HTTP communication error or Ontraport returned an error.  
**TaskCanceledException:** The request timed-out or the user canceled the request's Task.  

Before v1.2, Select requests would throw HttpRequestException when the record is not found. As of v1.2, it instead returns null.


## <a name="supported-classes"/>Supported Classes

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


## <a name="how-to-configure"/>How to Configure in ASP.NET Core

Add *OntraportApi* and *OntraportApi.AspNetCore* to your project via NuGet.

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

No problem, [this is the only class](https://github.com/mysteryx93/OntraportApi.NET/blob/master/OntraportApi.AspNetCore/OntraportApiServiceCollectionExtensions.cs) that depends on .NET Core so you can easily rewrite it for whatever technology you use.


## <a name="posting-smartforms"/>Posting SmartForms

In many cases, a simpler way to send data to Ontraport is to simply submit a SmartForm. Then, you can perform additional actions in your form via Ontraport. You can obtain the form id and custom field names (that look like f0000) by clicking Publish and looking at the HTML view.

Advantages: simpler, and it gives you form fillout statistics.

Disadvantages: it doesn't have any kind of security so don't use this for important management data.

You can use this to provide forms to the user that perform additional server-side actions, such as uploading files and resizing pictures.

To post forms, use *IOntraportPostForms*. It supports posting via the client's browser or via the server.

You do not need an API key to submit forms. If you wish to only post forms without using the rest of the API, you can register it with *services.AddOntraportPostForms()*

```c#
// Post and don't wait.
_ontraPostForms.ServerPost("my-form-id", new ApiContact()
{
    Email = email,
    FirstName = firstName
}.GetChanges());
```


## <a name="adding-custom-fields"/>Adding Custom Fields

Simple way: you can access all custom properties using the Data property of the object returned by the API. It exposes all raw data returned from Ontraport.

To add strongly-typed support for your custom fields for Contact, Company and Deal objects, create a class defining your extra fields.

You can get the list of custom field keys using the *GetCustomFieldsAsync* method.

```c#
public class ApiCustomContact : ApiContact
{
    public ApiPropertyString Custom1Field => _custom1Field ?? (_custom1Field = new ApiPropertyString(this, Custom1Key));
    private ApiPropertyString _custom1Field;
    public virtual string Custom1Key => "f1234";
    public string Custom1 { get => Custom1Field.Value; set => Custom1Field.Value = value; }

    public ApiPropertyDateTime Custom2Field => _custom2Field ?? (_custom2Field = new ApiPropertyDateTime(this, Custom2Key));
    private ApiPropertyDateTime _custom2Field;
    public virtual string Custom2Key => "f2222";
    public DateTimeOffset? Custom2 { get => Custom2Field.Value; set => Custom2Field.Value = value; }
}
```

Then, use *OntraportContacts\<ApiCustomContact\>* instead of *OntraportContacts<ApiContact>*.

```c#
public class OntraportContacts : OntraportContacts<ApiCustomContact>, IOntraportContacts
{
    public OntraportContacts(OntraportHttpClient apiRequest, IOntraportObjects ontraObjects) :
        base(apiRequest, ontraObjects)
    { }
}
```

You may want to declare the IOntraportContacts interface for convenience.

```c#
public interface IOntraportContacts : IOntraportContacts<ApiCustomContact>
{ }
```

Don't forget to register your new class in Startup.cs
```c#
services.AddTransient<IOntraportContacts, OntraportContacts>();
```
    
Supprted ApiProperty types (and you can easily implement your own parsers):
- ApiProperty\<int\>
- ApiProperty\<decimal\>
- ApiProperty\<float\>
- ApiPropertyString
- ApiPropertyBool ("true", "false" parsed as Boolean)
- ApiPropertyDateTime (Unix Epoch seconds date parsed as DateTimeOffset)
- ApiPropertyIntBool ("1", "0", parsed as Boolean)
- ApiPropertyIntEnum\<T\> (Numeric field parsed as enumeration of type T)
- ApiPropertyStringEnum\<T\> (string parsed as enumeration of type T)


## <a name="custom-objects"/>Adding Strongly-Typed Support for Custom Objects

Simple way: use OntraportObject with the ObjectTypeId of your custom object. It takes an ObjectType parameter of type ApiCustomObject but you can pass any integer like this: (ApiObjectType)10000. Custom Objects have an ObjectTypeId above 10000.

Custom Objects behave like Contacts. They have their standard fields, custom fields, campaigns, tags, rules and messages.

To add strongly-typed support for a custom object:

1. Create a class to expose all API methods related to custom objects. All methods are implemented through the base class.

You can obtain ObjectTypeId in Ontraport by clicking on the custom object section. It's ID will appear in the address bar.

```c#
public class OntraportRecordings : OntraportBaseCustomObject<ApiRecording>, IOntraportRecordings
{
    public OntraportRecordings(OntraportHttpClient apiRequest, IOntraportObjects ontraObjects) :
        base(apiRequest, ontraObjects, "Recording", "Recordings", ObjectTypeId, "name")
    { }

    public static int ObjectTypeId = 10000;
}

public interface IOntraportRecordings : IOntraportBaseCustomObject<ApiRecording>
{ }

public class ApiRecording : ApiCustomObjectBase
{ }
```

2. Register it in ConfigureServices in Startup.cs

```c#
services.AddTransient<IOntraportRecordings, OntraportRecordings>();
```

3. Add all custom fields to your custom object. Your class inherits from ApiCustomObjectBase.

Obtain your list of custom fields using the *OntraportRecordings.GetCustomFieldsAsync()* method. The parent field is of type Int.

```c#
public class ApiRecording : ApiCustomObjectBase
{
    public ApiProperty<int> Custom1Field => _custom1Field ?? (_custom1Field = new ApiProperty<int>(this, Custom1Key));
    private ApiProperty<int> _custom1Field;
    public virtual string Custom1Key => "f3333";
    public int? Custom1 { get => Custom1Field.Value; set => Custom1Field.Value = value; }
}
```


## <a name="switching-accounts"/>Switching Between Live and Dev Ontraport Accounts

You will probably want to use a sandbox Ontraport account for development. One problem is that all custom fields will have a different ID on your live and development servers!

To solve the problem, as of v1.2, you can now create a class deriving from your custom ApiContact class that overrides the field IDs.

In previous versions, you would write custom fields using this

```c#
public const string Custom1Key = "f1234";
```

Replace those lines with

```c#
public virtual string Custom1Key => "f1234";
```

Create your classes like this

```c#
public class IdentityContactDev : IdentityContact
{
    public override string IdentityAccessFailedCountKey => "f0000";
    public override string IdentityLockoutEndKey => "f1111";
    public override string IdentityPasswordHashKey => "f2222";
}

public interface IOntraportContacts : IOntraportContacts<IdentityContact>
{ }

public class OntraportContacts<TOverride> : OntraportContacts<IdentityContact, TOverride>, IOntraportContacts
    where TOverride : IdentityContact
{
    public OntraportContacts(OntraportHttpClient apiRequest, IOntraportObjects ontraObjects) :
        base(apiRequest, ontraObjects)
    { }
}
```

Now, when registering services in Startup.cs, you can switch between these two registrations depending on whether you want to run on the live or development server!

```c#
services.AddTransient<IOntraportContacts, OntraportContacts<IdentityContact>>();
services.AddTransient<IOntraportContacts, OntraportContacts<IdentityContactDev>>();
```


## <a name="ontraport-membership-provider"/>Ontraport Membership Provider for Identity Framework Core


## <a name="unit-testing"/>Unit Testing the Source Code

DO NOT RUN TESTS ON YOUR LIVE ONTRAPORT ACCOUNT

[Ask for a SandBox account here.](https://ontraport.com/tools/sandbox)

We can't control the server environment and thus must run Integration Tests. Current integration tests are sufficient to show it's working, but more work could be done so they can run reliably and test more in-depth.

To run Unit Tests, Ontraport API credentials must be set in your User Secret Manager. Open the command-line tool and navigate to the OntraportApi.IntegrationTests project directory.

Use the following commands to set your keys to your sandbox account
```
dotnet user-secrets set OntraportAppId ""your-app-id-here""
dotnet user-secrets set OntraportApiKey ""your-api-key-here""");
```
 

## <a name="about"/>About The Author

[Etienne Charland](https://www.spiritualselftransformation.com), known as the Emergence Guardian, helps starseeds reconnect with their soul power to accomplish the purpose 
they came here to do. [You can read his book at Satrimono Publishing.](https://satrimono.com/) Warning: non-geek zone.

You may also be interested in the [Natural Grounding Player, Yin Media Encoder, 432hz Player, Powerliminals Player, and Audio Video Muxer.](https://github.com/mysteryx93/NaturalGroundingPlayer)

I've spent a lot of time to develop this professional-grade framework and am making it available for free. However, [please subscribe to Ontraport via my affiliate link to support this project!](https://ontraport.com/?orid=480125&utm_source=referral&utm_medium=inapp&utm_campaign=refer&utm_term=ShareTheLove&utm_content=ontraport)
