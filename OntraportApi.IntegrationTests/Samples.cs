using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class Samples
    {
        private readonly IOntraportContacts<ApiContact> _ontraContacts;
        private readonly IOntraportProducts _ontraProducts;
        private readonly IOntraportTransactions _ontraTransactions;
        private readonly IOntraportPostForms _ontraPostForms;

        public Samples()
        {
            var httpClient = new ConfigHelper().GetHttpClient();
            _ontraContacts = new OntraportContacts<ApiContact>(httpClient);
            _ontraProducts = new OntraportProducts(httpClient);
            _ontraTransactions = new OntraportTransactions(httpClient);
            _ontraPostForms = new OntraportPostForms(new HttpClient);
        }

        public async Task<string> GetCustomerNameAndBirthday(string email)
        {
            var customer = await _ontraContacts.SelectAsync(email);
            return $"{customer.FirstNameField} {customer.LastNameField} - {customer.BirthdayField}";
        }

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

        public void PostForm(string email, string firstName)
        {
            _ontraPostForms.ServerPost("my-form-id", new ApiContact()
            {
                Email = email,
                FirstName = firstName
            }.GetChanges());
        }
    }
}
