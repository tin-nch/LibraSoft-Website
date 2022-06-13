using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.Entities.Entities;
using Librasoft.Services;
using Librasoft.Services.Constract;
using Librasoft_API.Entities.Dtos.Response;
using Microsoft.AspNetCore.Cors;
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
    [EnableCors("MyAllowSpecificOrigins")]
    [ApiController]
    public class ContactFormController : ControllerBase
    {

        private readonly IContactFormsServices _contactFormService;
        public ContactFormController(IContactFormsServices _contactFormService)
        {
            this._contactFormService = _contactFormService;
           
        }
        [EnableCors]
        [HttpGet]
        public async Task<RequestResponse> GetListContactForm()
        {

            try
            {
               IEnumerable<PiranhaContactForm> result = await _contactFormService.GetContactFormlistAsync();
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

        [HttpPost("add")]
        public async Task<RequestResponse> Add(PiranhaContactForm contactForm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PiranhaContactForm add = await _contactFormService.AddContactFormAsync(contactForm);
                    if (add != null)
                    {

                        return new RequestResponse
                        {
                            ErrorCode = ErrorCode.Success,
                            Content = string.Empty
                        };
                    }

                    return new RequestResponse
                    {
                        ErrorCode = ErrorCode.GeneralFailure,
                        Content = string.Empty
                    };
                }
                else
                {
                    return new RequestResponse
                    {
                        ErrorCode = ErrorCode.GeneralFailure,
                        Content = "Model invalid"
                    };
                }
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
