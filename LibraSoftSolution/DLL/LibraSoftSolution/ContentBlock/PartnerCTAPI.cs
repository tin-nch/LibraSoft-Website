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
    public class PartnerCTAPI : BaseApiClient,IPartnerCTAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PartnerCTAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<PartnerCTVM>> gethtmlbysortordersWithImgPartner(int id)
        {
            var body = await GetAsync<RequestResponse>($"api/blockfields/gethtmlbysortorderwithimgpartner/{id}");
            return OutPutApi.OutPut<PartnerCTVM>(body);
        }
    }
}
