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
    public class WorkCTAPI: BaseApiClient, IWorkCTAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WorkCTAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<WorkCTVM>> gethtmlbysortordersWithImgWork(int id)
        {
            var body = await GetAsync<RequestResponse>($"api/blockfields/gethtmlbysortorderwork/{id}");
            return OutPutApi.OutPut<WorkCTVM>(body);
        }
    }
}
