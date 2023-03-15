namespace HanumanInstitute.OntraportApi;

/// <summary>
/// Provides Ontraport API support for Contact objects.
/// Contact objects allow you to keep up-to-date records for all the contacts you are managing.
/// Contacts can be associated with many other objects such as tasks, tags, rules, and sequences. You can access additional functionality 
/// for tagging contacts and adding and removing contacts from sequences using the objects API with an objectID of 0.
/// </summary>
/// <typeparam name="T">A type deriving from ApiContact exposing additional custom fields.</typeparam>
public interface IOntraportContacts<T> : IOntraportBaseCustomObject<T>
    where T : ApiContact
{
}
