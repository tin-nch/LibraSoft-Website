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
        public  RequestResponse Upload(IFormFile file)
        {
            try
            {
                if (ModelState.IsValid)
                {

                 
                    string rs =  UploadFile(file).ToString();

                    //add contact to dtb
                 
                    //send email
                    // var a = await _sendEmailServices.SendEmail(applicationForm);

                    if (rs != null /*&& add == true*/)
                    {
                        return new RequestResponse
                        {
                            ErrorCode = ErrorCode.Success,
                            Content =  rs
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
            string path = "";
            string filepath = "";
       
            try
            {
                if(file.Length>0)
                {
                  
                    string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    filepath = Directory.GetCurrentDirectory() + "/Upload";
                    if (!System.IO.Directory.Exists(filepath))
                    {
                        Directory.CreateDirectory(filepath);
                    }
                    filepath = Directory.GetCurrentDirectory() + "/Upload" + "/" + filename;
                    path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "Upload"));
                    
                    using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                    {
                         file.CopyToAsync(filestream);
                    }
                  
                  
                }
                return filepath;
                
            }
            catch(Exception)
            {
                throw;
            } 
        }
    }
}
