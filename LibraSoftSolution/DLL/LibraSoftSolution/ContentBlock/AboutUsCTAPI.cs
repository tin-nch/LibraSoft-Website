using LibraSoftSolution.API.Utilities;
using LibraSoftSolution.Models;
using LibraSoftSolution.ViewModels.ContentBlock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.API.ContentBlock
{
    public class AboutUsCTAPI: BaseApiClient, IAboutUsCTAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AboutUsCTAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<AboutCTVM>> gethtmlbysortordersWithImgAboutUs(int id)
        {
            var body = await GetAsync<RequestResponse>($"api/blockfields/gethtmlbysortorderwithimgabout/{id}");
            return OutPutApi.OutPut<AboutCTVM>(body);
        }
    }
}
