using LibraSoftSolution.API.Utilities;
using LibraSoftSolution.Models;
using LibraSoftSolution.ViewModels;
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

namespace LibraSoftSolution.API.ContactCustomer
{
    public class CFCountryAPI : BaseApiClient, ICFCountryAPI
    {
        public CFCountryAPI(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<List<CFCountryVM>> GetCountry()
        {
            var body = await GetAsync<RequestResponse>("api/cfcountry");

            return OutPutApi.OutPut<CFCountryVM>(body);
        }
    }
}
