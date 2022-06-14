using LibraSoftSolution.Models;
using LibraSoftSolution.ViewModels.ContactForm;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LibraSoftSolution.API.Test
{
    public class TestAPI : BaseApiClient, ITestAPI
    {
        public TestAPI(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<List<ContactVM>> GetAll()
        {
            var body = await GetAsync<RequestResponse>("api/contactform");
            return OutPutApi.OutPut<ContactVM>(body);
        }
    }
}
