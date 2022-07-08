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
    public class FactCTAPI: BaseApiClient, IFactCTAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FactCTAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<FactCTVM>> gethtmlbysortordersWithImgFact(int id)
        {
            var body = await GetAsync<RequestResponse>($"api/blockfields/gethtmlbysortorderfact/{id}");
            return OutPutApi.OutPut<FactCTVM>(body);
        }
    }
}
