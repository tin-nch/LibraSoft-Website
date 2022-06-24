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
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class BlocksController : ControllerBase
    {

        private readonly IBlocksServices blocksServices;
        private readonly IBlockFieldsServices blockFieldsServices;

        public BlocksController(IBlocksServices blocksServices,IBlockFieldsServices blockFieldsServices)
        {
            this.blocksServices = blocksServices;
            this.blockFieldsServices = blockFieldsServices;
        }

        [HttpGet]
        public async Task<RequestResponse> GetListBlockList()
        {

            try
            {
                IEnumerable<PiranhaBlock> result = await blocksServices.GetBlocklistAsync();
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
        public  RequestResponse GetListBlockCLRType()
        {

            try
            {
                List<string> result =  blocksServices.GetBlockCRLTypelist();
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
        public RequestResponse GetListColumnBLock()
        {

            try
            {
                IEnumerable<PiranhaBlock> result = blocksServices.GetColumnBlocklist();
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
        public RequestResponse GetListColumnBLockByPageID(string id)
        {

            try
            {
                List<PiranhaBlock> lst = blocksServices.GetColumnBlocklistByPageID(id).ToList();
                List<BlockParentVM> result = new List<BlockParentVM>();
                if(lst != null)
                {
                    foreach (PiranhaBlock block in lst)
                    {
                        BlockParentVM blockParentVM = new BlockParentVM(block);
                        List<BlockChildVM> h = new List<BlockChildVM>();
                        blockParentVM.blockChildVMs = new List<BlockChildVM>();
                        h = blocksServices.GetBlockChildListByParentID(block.Id.ToString()).ToList();
                        blockParentVM.blockChildVMs.AddRange(h);
                        result.Add(blockParentVM);
                    }
                }
              
              
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
        public RequestResponse GetBlockListHaveParentID(string id)
        {

            try
            {
                IEnumerable<PiranhaBlock> result = blocksServices.GetBlockListHaveParentID(id);
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
