using LibraSoftSolution.API.ContentBlock;
using LibraSoftSolution.API.Utilities;
using LibraSoftSolution.Models;
using LibraSoftSolution.ViewModels.ContentBlock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.API.ContentBlocsk
{
    public class ServiceCTAPI: BaseApiClient, IServiceCTAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceCTAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<ServiceCTVM>> gethtmlbysortordersWithImgService(int id)
        {
            var body = await GetAsync<RequestResponse>($"api/blockfields/gethtmlbysortorderwithimgservices/{id}");
            return OutPutApi.OutPut<ServiceCTVM>(body);
        }
    }
}
