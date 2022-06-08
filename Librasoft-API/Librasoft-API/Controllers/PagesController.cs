using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.Services.Constract;
using Librasoft_API.Entities;
using Librasoft_API.Entities.Dtos.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Librasoft_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {

        private readonly IPages pagesServices ;
        public PagesController(IPages pagesServices)
        {
            this.pagesServices = pagesServices;
        }

        [HttpGet]
        public RequestResponse GetListAlias()
        {

            try
            {
                List<string> result = pagesServices.GetListNavigationTitle();
                if (result != null && result.Any())
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


            //List < PiranhaAlias > lst = aliases.GetListAlias();

            //return lst;
        }
    }
}
