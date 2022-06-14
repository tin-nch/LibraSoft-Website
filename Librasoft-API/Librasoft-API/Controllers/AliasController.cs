using Librasoft.Services;
using Librasoft_API.Entities;
using Librasoft.DataAccess.EFs;
using Librasoft.Services.Constract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Librasoft_API.DataAccess.Repositorys.Constracts;
using System.Collections.Generic;
using System.Linq;
using Librasoft_API.Entities.Dtos.Response;
using Newtonsoft.Json;
using System;
using Librasoft.Entities.Entities;

namespace Librasoft_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AliasController : ControllerBase
    {
        private readonly IAliasRepository aliases;
        
        public AliasController(IAliasRepository aliases)
        {
           this.aliases = aliases;
        }
        [HttpGet]
        public RequestResponse GetListAlias()
        {

            try
            {
              List<PiranhaAlias> result =  aliases.GetListAlias();
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
