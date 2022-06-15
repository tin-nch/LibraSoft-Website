using LibraSoftSolution.API.Utilities;
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

        public async Task<List<BlockFieldsVM>> gethtmlbysortorders(int id)
        {
            var body = await GetAsync<RequestResponse>($"api/blockfields/gethtmlbysortorder/{id}");
            return OutPutApi.OutPut<BlockFieldsVM>(body);
        }

        public async Task<List<BlocksVM>> GetListBlocks()
        {
            var body = await GetAsync<RequestResponse>("api/blocks/getlistblocklist");
            return OutPutApi.OutPut<BlocksVM>(body);
        }

        public async Task<List<string>> GetListBlocksCLRType()
        {
            var body = await GetAsync<RequestResponse>("api/blocks/GetListBlockCLRType");
            return OutPutApi.OutPut<string>(body);
        }

        public async Task<List<BlockFieldsVM>> GetListBlocksFields()
        {
            var body = await GetAsync<RequestResponse>("api/blockfields/getlistblockfield");
            return OutPutApi.OutPut<BlockFieldsVM>(body);
        }

        public async Task<List<PageRevisionsVM>> GetListPageRevisions()
        {
            var body = await GetAsync<RequestResponse>("api/pagerevisions");
            return OutPutApi.OutPut<PageRevisionsVM>(body);
        }

        public async Task<List<PagesVM>> GetListPages()
        {
            var body = await GetAsync<RequestResponse>("api/pages/getlistpage");
            return OutPutApi.OutPut<PagesVM>(body);
        }
    }
}
