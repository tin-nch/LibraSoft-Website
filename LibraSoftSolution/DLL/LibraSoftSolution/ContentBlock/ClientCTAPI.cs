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
    public class ClientCTAPI : BaseApiClient, IClientCTAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ClientCTAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<Client1CTVM>> gethtmlbysortordersWithImgClient1(int id)
        {
            var body = await GetAsync<RequestResponse>($"api/blockfields/gethtmlbysortorderwithimgclient/{id}");
            return OutPutApi.OutPut<Client1CTVM>(body);
        }
        public async Task<List<Client2CTVM>> gethtmlbysortordersWithImgClient2(int id)
        {
            var body = await GetAsync<RequestResponse>($"api/blockfields/gethtmlbysortorderwithimgclient/{id}");
            return OutPutApi.OutPut<Client2CTVM>(body);
        }
    }
}
