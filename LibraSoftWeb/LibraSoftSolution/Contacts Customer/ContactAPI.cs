using LibraSoftSolution.Models;
using LibraSoftSolution.ViewModels;
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

            if (body.ErrorCode == 0)
            {
                try
                {
                    List<ContactVM> Contact = (List<ContactVM>)JsonConvert.DeserializeObject(body.Content, typeof(List<ContactVM>));

                    return Contact;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return null;

            //return OutPutApi.OutPut(body);
        }
    }
}
