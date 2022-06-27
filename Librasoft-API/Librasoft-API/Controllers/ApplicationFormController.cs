using Librasoft.Entities.Entities;
using Librasoft.Entities.Entities.Dtos;
using Librasoft.Services.Constract;
using Librasoft_API.Entities.Dtos.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Librasoft_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationFormController : ControllerBase
    {

        private readonly IApplicationFormServices _applicationFormService;
        private readonly ISendEmailServices _sendEmailServices;
        public ApplicationFormController(IApplicationFormServices _applicationFormService, ISendEmailServices _sendEmailServices)
        {
            this._applicationFormService = _applicationFormService;
            this._sendEmailServices = _sendEmailServices;
        }


        [HttpPost("add")]
        public async Task<RequestResponse> Add(ApplicationFormDto applicationForm)
        {
            try
            {
                if (ModelState.IsValid)
                {


                        if(_applicationFormService.checkExistsEmail(applicationForm))
                        {
                            return new RequestResponse
                            {
                                ErrorCode = ErrorCode.Success,
                                Content = "Email exists"
                            };
                         }    
    
                    PiranhaApplicationForm a = new PiranhaApplicationForm();
                    a.FullName = applicationForm.FullName;
                    a.Phone = applicationForm.Phone;
                    a.Email = applicationForm.Email;
                    a.FilePath = UploadFile(applicationForm.File).ToString();

                    //add contact to dtb
                    PiranhaApplicationForm add = await _applicationFormService.AddApplicationFormAsync(a);
                    //send email
                    // var a = await _sendEmailServices.SendEmail(applicationForm);

                    if (add != null /*&& add == true*/)
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

        [HttpPost("upload")]
        public RequestResponse Upload(IFormFile file)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    string rs = UploadFile(file).ToString();

                    //add contact to dtb

                    //send email
                    // var a = await _sendEmailServices.SendEmail(applicationForm);

                    if (rs != null /*&& add == true*/)
                    {
                        return new RequestResponse
                        {
                            ErrorCode = ErrorCode.Success,
                            Content = rs
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

        public string UploadFile(IFormFile file)
        {
            DateTime now = DateTime.Now;
            var baseDate = new DateTime(1970, 1, 1, 1, 1, 0, 0);
            var toDate = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, now.Millisecond);
            Int32 dateId = (int)toDate.Subtract(baseDate).TotalSeconds;


            string currentPath = Directory.GetCurrentDirectory() + @"\Upload\Images\CV\" + now.ToString("yyyyMMdd");

            try
            {
                if (file.Length > 0)
                {
                    string filename = "CV_" + Path.GetFileNameWithoutExtension(file.FileName) + "_" + dateId.ToString() + Path.GetExtension(file.FileName);

                    // If directory does not exist, create it
                    if (!Directory.Exists(currentPath))
                    {
                        Directory.CreateDirectory(currentPath);
                    }

                    using (var filestream = new FileStream(Path.Combine(currentPath, filename), FileMode.Create))
                    {
                        file.CopyToAsync(filestream);
                    }
                    return Path.Combine(currentPath, file.FileName);
                }
                return "NO path";

            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }
    }
}
