﻿using LibraSoftSolution.Models;
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
        public NavigationTitleAPI(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<List<string>> GetTitle()
        {
            var body = await GetAsync<RequestResponse>("api/pages");

            if (body.ErrorCode == 0)
            {
                try
                {
                    List<string> NavigationTitle = (List<string>)JsonConvert.DeserializeObject(body.Content, typeof(List<string>));
                    return NavigationTitle;
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