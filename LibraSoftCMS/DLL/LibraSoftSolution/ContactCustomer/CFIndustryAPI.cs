﻿using LibraSoftSolution.API.Utilities;
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
    public class CFIndustryAPI : BaseApiClient, ICFIndustryAPI
    {
        public CFIndustryAPI(IHttpClientFactory httpClientFactory)
           : base(httpClientFactory)
        {
        }

        public async Task<List<CFIndustryVM>> GetIndustry()
        {
            var body = await GetAsync<RequestResponse>("api/cfindustry");

            return OutPutApi.OutPut<CFIndustryVM>(body);
        }
    }
}
