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
    public class MapCTAPI: BaseApiClient, IMapCTAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MapCTAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<MapCTVM>> gethtmlbysortordersWithImgMap(int id)
        {
            var body = await GetAsync<RequestResponse>($"api/blockfields/gethtmlbysortordermap/{id}");
            return OutPutApi.OutPut<MapCTVM>(body);
        }
    }
}
