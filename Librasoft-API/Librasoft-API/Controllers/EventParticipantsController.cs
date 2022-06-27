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
        public async Task<bool> test(PiranhaEventParticipant participant)
        {
            if (ModelState.IsValid)
            {
                var body = "as";
                await sendEmail.SendConFirmEmail(participant);
                return true;
            }
            return false;
        }

        [HttpPost("add")]
        public async Task<RequestResponse> Add(PiranhaEventParticipant participant)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    //if (eventParticipants.checkExistsEmail(participant))
                    //{
                    //    return new RequestResponse
                    //    {
                    //        ErrorCode = ErrorCode.Success,
                    //        Content = "Email exists"
                    //    };
                    //}
                    //add contact to dtb
                    PiranhaEventParticipant add = await eventParticipants.AddParticipantsAsync(participant);
                    //send email
                    //  var a = await _sendEmailServices.SendEmail(contactForm);

                    if (add != null /*&& a == true*/)
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
