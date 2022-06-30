using Librasoft.Entities.Entities;
using Librasoft.Entities.Entities.Dtos;
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
    public class EventParticipantsController : ControllerBase
    {

        private readonly IEventParticipantsServices eventParticipants;
        private readonly ISendEmailServices sendEmail;

        public EventParticipantsController(IEventParticipantsServices eventParticipants, ISendEmailServices sendEmailServices)
        {
            this.eventParticipants = eventParticipants;
            sendEmail = sendEmailServices;
        }
        [HttpGet]
        public async Task<RequestResponse> GetListParticipants()
        {

            try
            {
                IEnumerable<PiranhaEventParticipant> result = await eventParticipants.GetlistParticipantsAsync();
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

        [HttpPost("test")]
        public async Task<bool> test(EventParticipantDto participant)
        {
            if (ModelState.IsValid)
            {
               
                return await sendEmail.SendConFirmEmail(participant); ;
            }
            return false;
        }

        [HttpPost("add")]
        public async Task<RequestResponse> Add(EventParticipantDto participant)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (eventParticipants.checkExistsEmail(participant))
                    {
                        if(eventParticipants.checkRegistedEmail(participant))
                         {
                            return new RequestResponse
                            {
                                ErrorCode = ErrorCode.Success,
                                Content = "Email đã tồn tại"
                            };
                         }
                        else
                        {
                            var l = await sendEmail.SendConFirmEmail(participant);
                            if (l)
                            {
                                return new RequestResponse
                                {
                                    ErrorCode = ErrorCode.Success,
                                    Content = "submit successfully"
                                };
                            }
                        }

                     
                    }
                    //add contact to dtb
              
             
                    bool rs = eventParticipants.AddParticipants(participant);
                  //  send email
                      var a = await sendEmail.SendConFirmEmail(participant); 
                    if (rs && a == true)
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
