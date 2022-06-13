using LibraSoftSolution.Models;
using LibraSoftSolution.ViewModels.ContentWeb;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.API.ContentWeb
{
    public class BlockAPI : BaseApiClient, IBlockAPI
    {
        public BlockAPI(IHttpClientFactory httpClientFactory, 
            IHttpContextAccessor httpContextAccessor, 
            IConfiguration configuration) : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<List<BlocksVM>> GetListBlocks()
        {
            var body = await GetAsync<RequestResponse>("api/blocks");
            return OutPutApi.OutPut<BlocksVM>(body);
        }

        public async Task<List<BlockFieldsVM>> GetListBlocksFields()
        {
            var body = await GetAsync<RequestResponse>("api/blockfields");
            return OutPutApi.OutPut<BlockFieldsVM>(body);
        }
    }
}
