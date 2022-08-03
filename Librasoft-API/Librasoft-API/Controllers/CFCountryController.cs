﻿using Librasoft.Entities.Entities;
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
    public class CFCountryController : ControllerBase
    {

        private readonly ICFCountryServices _cfCountryService;

        public CFCountryController(ICFCountryServices cfCountryService)
        {
            _cfCountryService = cfCountryService;
        }
        [HttpGet]
        public async Task<RequestResponse> GetListCFCountry()
        {

            try
            {
                IEnumerable<PiranhaCfcountry> result = await _cfCountryService.GetCountrylistAsync();
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