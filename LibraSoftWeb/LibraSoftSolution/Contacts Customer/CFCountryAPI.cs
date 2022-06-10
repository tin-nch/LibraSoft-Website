using LibraSoftSolution.API.Contacts_Customer;
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

namespace LibraSoftSolution.API
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

            if (body.ErrorCode == 0)
            {
                try
                {
                    List<CFCountryVM> data = (List<CFCountryVM>)JsonConvert.DeserializeObject(body.Content, typeof(List<CFCountryVM>));
                    return data;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return null;
        }
    }
}
