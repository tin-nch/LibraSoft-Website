using Librasoft.Entities.Entities;
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
    public class EventsController : ControllerBase
    {
        private readonly IEventServices eventServices;
        public EventsController(IEventServices eventServices)
        {
            this.eventServices = eventServices;
        }
        [HttpGet]
        public async Task<RequestResponse> GetListEvent()
        {

            try
            {

            
                IEnumerable<PiranhaEvent> result = await eventServices.GetListEvents();
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
            public async Task<RequestResponse> Add(PiranhaEvent e)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        //add contact to dtb
                        PiranhaEvent add = await eventServices.AddEventAsync(e);
                        //send email
                        // var a = await _sendEmailServices.SendEmail(applicationForm);

                        if (add != null /*&& add == true*/)
                        {
                            return new RequestResponse
                            {
                                ErrorCode = ErrorCode.Success,
                                Content = "add successfully"
                            };
                        }

                        return new RequestResponse
                        {
                            ErrorCode = ErrorCode.GeneralFailure,
                            Content = "Empty"
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
