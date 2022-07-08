using LibraSoftSolution.API.Utilities;
using LibraSoftSolution.Models;
using LibraSoftSolution.ViewModels.ContentWeb;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LibraSoftSolution.API
{
    public class NavigationTitleAPI : BaseApiClient, INavigationTitleAPI
    {
        public NavigationTitleAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<List<NavigationTitleVM>> GetTitle()
        {
            var body = await GetAsync<RequestResponse>("api/pages/GetListPage");
            //var body = await GetAsync<RequestResponse>("api/pages/GetListPageWithHomeTitle");

            return OutPutApi.OutPut<NavigationTitleVM>(body);
        }
    }
}
