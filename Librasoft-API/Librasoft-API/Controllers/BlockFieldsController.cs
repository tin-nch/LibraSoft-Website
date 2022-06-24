using Librasoft.Entities.Entities;
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
    [EnableCors("MyPolicy")]
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class BlockFieldsController : ControllerBase
    {
        private readonly IBlockFieldsServices blockFieldsServices;
        private readonly IPageBlocksServices pageBlocksServices;
        private readonly IBlocksServices blocksServices;
      public BlockFieldsController(IBlockFieldsServices blockFieldsServices, IPageBlocksServices pageBlocksServices, IBlocksServices blocksServices)
        {
            this.blockFieldsServices = blockFieldsServices;
            this.pageBlocksServices = pageBlocksServices;
            this.blocksServices = blocksServices;
        }

        [HttpGet]
        public async Task<RequestResponse> GetListBlockField()
        {

            try
            {
                IEnumerable<PiranhaBlockField> result = await blockFieldsServices.GetBlockFieldlistAsync();
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
        public RequestResponse GetHTMLBySortOrder(int id)
        {
            try
            {
                string blockid = pageBlocksServices.GetBlockIDBySortOrder(id);
               List<PiranhaBlock> listblk = blocksServices.GetBlockListHaveParentID(blockid).ToList();


                List<string> result = blockFieldsServices.GetListHTML(listblk);
                if (result != null)
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

       

        public RequestResponse GetHTMLBySortOrderWithImg(int id)
        {
            try
            {
                string blockid = pageBlocksServices.GetBlockIDBySortOrder(id);
                List<PiranhaBlock> listblk = blocksServices.GetBlockListHaveParentID(blockid).ToList();


                List<string> result = blockFieldsServices.GetListHTMLWithImg(listblk);
                if (result != null)
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
        public RequestResponse GetBlockFieldByID(string id)
        {

            try
            {
                PiranhaBlockField result =  blockFieldsServices.GetBlockFieldByID(id);
                if (result != null )
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

        //public RequestResponse GetHTMLByPageID(string id)
        //{
        //    try
        //    {
             
        //        List<PiranhaBlock> listblk = blocksServices.GetColumnBlocklistByPageID(id).ToList();
                
        //        List<PiranhaBlock> listblk1 = new List<PiranhaBlock>();
              
        //        foreach (PiranhaBlock a in listblk)
        //        {
        //            listblk1.AddRange( blocksServices.GetBlockListHaveParentID(a.Id.ToString()).ToList());
                  
        //        }
                
        //        List<string> result = blockFieldsServices.GetAllHTML(listblk1);
        //        if (result != null)
        //        {
        //            return new RequestResponse
        //            {
        //                ErrorCode = ErrorCode.Success,
        //                Content = JsonConvert.SerializeObject(result)
        //            };
        //        }
        //        return new RequestResponse
        //        {
        //            ErrorCode = ErrorCode.GeneralFailure,
        //            Content = string.Empty
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        string errorDetail = ex.InnerException != null ? ex.InnerException.ToString() : ex.Message.ToString();
        //        return new RequestResponse
        //        {
        //            ErrorCode = ErrorCode.GeneralFailure,
        //            Content = errorDetail
        //        };
        //    }
        //}
    }
}
