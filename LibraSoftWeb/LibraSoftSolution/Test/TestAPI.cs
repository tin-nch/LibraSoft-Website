using LibraSoftSolution.Models;
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

        public async Task<List<string>> GetAll()
        {
            var body = await GetAsync<RequestResponse>("api/pages");
            return OutPutApi.OutPut<string>(body);
        }
    }
}
