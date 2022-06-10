using LibraSoftSolution.Models;
using LibraSoftSolution.ViewModels.ContactForm;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.API.Contacts_Customer
{
    public class ContactAPI : BaseApiClient, IContactAPI
    {
        public ContactAPI(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<List<ContactVM>> GetContacts()
        {
            var body = await GetAsync<RequestResponse>("api/contactform");

            return OutPutApi.OutPut<ContactVM>(body);
        }

        public async Task<bool> AddContactForm(ContactVM contact)
        {

            var body = await AddAsync<RequestResponse, ContactVM>("api/contactform/add", contact);

            if (body.ErrorCode == 0)
            {
                return true;
            }
            return false;
        }
    }
}
