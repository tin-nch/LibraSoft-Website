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
    public class CFReasonReachingAPI : BaseApiClient, ICFReasonReachingAPI
    {
        public CFReasonReachingAPI(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<List<CFReasonReachingVM>> GetReasonReaching()
        {
            var body = await GetAsync<RequestResponse>("api/reasonreaching");

            if (body.ErrorCode == 0)
            {
                try
                {
                    List<CFReasonReachingVM> data = (List<CFReasonReachingVM>)JsonConvert.DeserializeObject(body.Content, typeof(List<CFReasonReachingVM>));
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
