using Librasoft.Services.Constract;
using Librasoft_API.Entities.Dtos.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace Librasoft_API.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class PageBlocksController : ControllerBase
    {

        private readonly IPageBlocksServices pageblocksServices;
        public PageBlocksController(IPageBlocksServices pageblocksServices)
        {
            this.pageblocksServices = pageblocksServices;
        }

        [HttpGet]
        public RequestResponse GetBlockIDBySortOrder(int id)
        {

            try
            {
               string result = pageblocksServices.GetBlockIDBySortOrder(id);
                if (result != null )
                {
                    return new RequestResponse
                    {
                        ErrorCode = ErrorCode.Success,
                        Content = JsonConvert.SerializeObject(result)
                    };
                }
                return new RequestResponse
                {
                    ErrorCode = ErrorCode.GeneralFailure,
                    Content = string.Empty
                };
            }
            catch (Exception ex)
            {
                string errorDetail = ex.InnerException != null ? ex.InnerException.ToString() : ex.Message.ToString();
                return new RequestResponse
                {
                    ErrorCode = ErrorCode.GeneralFailure,
                    Content = errorDetail
                };
            }



        }

    }
}
