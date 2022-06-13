using LibraSoftSolution.Models;
using LibraSoftSolution.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.API.ContactCustomer
{
    public class ContactAPI : BaseApiClient, IContactAPI
    {
        public ContactAPI(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<bool> AddContactForm(ContactVM contact)
        {
            var body = await AddAsync<RequestResponse, ContactVM>("api/contactform/add", contact);

            return OutPutApi.OutPutBool<bool>(body);
        }

        public async Task<List<ContactVM>> GetContacts()
        {
            var body = await GetAsync<RequestResponse>("api/contactform");

            return OutPutApi.OutPut<ContactVM>(body);
        }
    }
}
