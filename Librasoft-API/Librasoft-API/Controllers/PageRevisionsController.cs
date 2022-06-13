﻿using Librasoft.Entities.Entities;
using Librasoft.Services;
using Librasoft.Services.Constract;
using Librasoft_API.Entities.Dtos.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Librasoft_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageRevisionsController : ControllerBase
    {
        private readonly IPageRevisionsServices pagesRevisionServices;

        public PageRevisionsController(IPageRevisionsServices pagesRevisionServices)
        {
            this.pagesRevisionServices = pagesRevisionServices;
        }

        [HttpGet]
        public async Task<RequestResponse> GetListPageRevisionField()
        {

            try
            {
                IEnumerable<PiranhaPageRevision> result = await pagesRevisionServices.GetPagesRevisionListAsync();
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



        }
    }
}
