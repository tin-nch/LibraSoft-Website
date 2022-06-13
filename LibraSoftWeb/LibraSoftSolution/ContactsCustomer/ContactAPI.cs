using LibraSoftSolution.API.ReceiveMails;
using LibraSoftSolution.Models;
using LibraSoftSolution.ViewModels.ContactForm;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
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

            return OutPutApi.OutPutBool<bool>(body);
        }
    }
}
