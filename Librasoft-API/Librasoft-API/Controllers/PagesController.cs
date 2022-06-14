﻿using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.Entities.Entities;
using Librasoft.Services.Constract;
using Librasoft_API.Entities;
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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PagesController : ControllerBase
    {

        private readonly IPagesServices pagesServices;
        public PagesController(IPagesServices pagesServices)
        {
            this.pagesServices = pagesServices;
        }

        [HttpGet]
        public async Task<RequestResponse> GetListPage()
        {

            try
            {
                IEnumerable<PiranhaPage> result  =await pagesServices.GetPagesListAsync();
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

        [HttpGet]
        public  RequestResponse GetListPageWithHomeTitle()
        {

            try
            {
                IEnumerable<PiranhaPage> result =  pagesServices.GetPagesListWithHomeTitle();
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
