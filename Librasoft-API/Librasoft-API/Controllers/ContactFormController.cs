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
        private readonly ISendEmailServices _sendEmailServices;
        public ContactFormController(IContactFormsServices _contactFormService, ISendEmailServices _sendEmailServices)
        {
            this._contactFormService = _contactFormService;
            this._sendEmailServices = _sendEmailServices;
           
        }
        
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

                    if(_contactFormService.ValidateContactForm(contactForm))
                    {
                        return new RequestResponse
                        {
                            ErrorCode = ErrorCode.Success,
                            Content = "contact exists"
                        };
                    }
                    //add contact to dtb
                    contactForm.Time = DateTime.Now;
                    PiranhaContactForm add = await _contactFormService.AddContactFormAsync(contactForm);
                    //send email
                    var a = await _sendEmailServices.SendEmail(contactForm);

                    if (add != null && a == true)
                    {
                        return new RequestResponse
                        {
                            ErrorCode = ErrorCode.Success,
                            Content = "submit successfully"
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
