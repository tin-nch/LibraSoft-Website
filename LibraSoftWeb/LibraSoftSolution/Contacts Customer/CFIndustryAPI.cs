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
    public class CFIndustryAPI : BaseApiClient, ICFIndustryAPI
    {
        public CFIndustryAPI(IHttpClientFactory httpClientFactory,
                  IHttpContextAccessor httpContextAccessor,
                   IConfiguration configuration)
           : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<List<CFIndustryVM>> GetIndustry()
        {
            var body = await GetAsync<RequestResponse>("api/cfindustry");

            if (body.ErrorCode == 0)
            {
                try
                {
                    List<CFIndustryVM> data = (List<CFIndustryVM>)JsonConvert.DeserializeObject(body.Content, typeof(List<CFIndustryVM>));
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
