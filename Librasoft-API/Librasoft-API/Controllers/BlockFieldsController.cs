using Librasoft.Entities.Entities;
using Librasoft.Entities.Entities.Dtos;
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

        [HttpGet]
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

        [HttpGet]
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
        public RequestResponse GetHTMLBySortOrderWithImgPartner(int id)
        {
            try
            {
                string blockid = pageBlocksServices.GetBlockIDBySortOrder(id);
                List<PiranhaBlock> listblk = blocksServices.GetBlockListHaveParentID(blockid).ToList();
                List<ParnerCMS> parnerCMs = new List<ParnerCMS>();



                List<string> result = blockFieldsServices.GetListHTMLWithImg(listblk);
                foreach(string b in result)
                {
                    ParnerCMS p = new ParnerCMS();
          
                        string[] a = b.Split("\n");
                    p.imgpath = a[0];
                    p.title = a[1];
                    p.content = a[2];
                    p.url = a[3];
                      

                   

                        if (p.imgpath.StartsWith("<h"))
                        {

                            p.imgpath = p.imgpath.Substring(4);
                            string g = p.imgpath.Remove(p.imgpath.Length - 5);
                            p.imgpath = g;

                        }
                    
                        else if (p.imgpath.StartsWith("<p"))
                        {





                            p.imgpath = p.imgpath.Substring(3);
                            string g = p.imgpath.Remove(p.imgpath.Length - 5);
                            p.imgpath = g;
                        }

                    if (p.url.StartsWith("<p"))
                    {

                        p.url = p.url.Substring(3);
                        string g = p.url.Remove(p.url.Length - 4);
                        p.url = g;
                    }



                    parnerCMs.Add(p);
               }    
                if (result != null)
                {
                    return new RequestResponse
                    {
                        ErrorCode = ErrorCode.Success,
                        Content = JsonConvert.SerializeObject(parnerCMs)
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
        public RequestResponse GetHTMLBySortOrderWithImgClient(int id)
        {
            try
            {
                string blockid = pageBlocksServices.GetBlockIDBySortOrder(id);
                List<PiranhaBlock> listblk = blocksServices.GetBlockListHaveParentID(blockid).ToList();
                List<ClientCMS> clientCMs = new List<ClientCMS>();
                List<string> result = blockFieldsServices.GetListHTMLWithImg(listblk);

                foreach (string b in result)
                {
                    ClientCMS p = new ClientCMS();
                    string[] a = b.Split("\n");
                    if (!b.Contains("\n"))
                    {
                        p.imgpath = a[0];

                        p.imgpath = p.imgpath.Substring(3);
                        string g = p.imgpath.Remove(p.imgpath.Length - 4);
                        p.imgpath = g;
                    }
                    else
                    {
                       




                        p.imgpath = a[0];

                        p.imgpath = p.imgpath.Substring(3);
                        string g = p.imgpath.Remove(p.imgpath.Length - 4);
                        p.imgpath = g;

                        p.url = a[1];

                        p.url = p.url.Substring(3);
                        string x = p.url.Remove(p.url.Length - 4);
                        p.url = x;
                    }

               


                    clientCMs.Add(p);
                }
                if (result != null)
                {
                    return new RequestResponse
                    {
                        ErrorCode = ErrorCode.Success,
                        Content = JsonConvert.SerializeObject(clientCMs)
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
        public RequestResponse GetHTMLBySortOrderWithImgAbout(int id)
        {
            try
            {
                string blockid = pageBlocksServices.GetBlockIDBySortOrder(id);
                List<PiranhaBlock> listblk = blocksServices.GetBlockListHaveParentID(blockid).ToList();
                List<AboutCMS> aboutCMs = new List<AboutCMS>();
                List<string> result = blockFieldsServices.GetListHTMLWithImg(listblk);

                foreach (string b in result)
                {
                    AboutCMS p = new AboutCMS();
                    string[] a = b.Split("\n");
                    for(int i = 4;i< a.Length-1;i++)
                        {
                        p.Content += a[i];
                    }
                   
                    p.ImgPath = a[0];
                    p.ImgPath = p.ImgPath.Substring(3);
                    string g = p.ImgPath.Remove(p.ImgPath.Length - 4);
                    p.ImgPath = g;
                    p.Title = a[2];
                    p.Title = p.Title.Substring(4);
                    g = p.Title.Remove(p.Title.Length - 11);
                    p.Title = g;

                    p.IconCode = a[a.Length-1];
                    if(p.IconCode.StartsWith("<p"))
                    {
                        p.IconCode = p.IconCode.Substring(3);
                         g = p.IconCode.Remove(p.IconCode.Length - 4);
                        p.IconCode = g;
                    }
                    aboutCMs.Add(p);

                }
                if (result != null)
                {
                    return new RequestResponse
                    {
                        ErrorCode = ErrorCode.Success,
                        Content = JsonConvert.SerializeObject(aboutCMs)
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
        public RequestResponse GetHTMLBySortOrderFact(int id)
        {
            try
            {
                string blockid = pageBlocksServices.GetBlockIDBySortOrder(id);
                List<PiranhaBlock> listblk = blocksServices.GetBlockListHaveParentID(blockid).ToList();
                List<FactCMS> factCMs = new List<FactCMS>();
                List<string> result = blockFieldsServices.GetListHTML(listblk);

                foreach (string b in result)
                {
                    FactCMS p = new FactCMS();
                    string[] a = b.Split("\n");
                    string temp = a[0];
                    if (temp.StartsWith("<h"))
                    {
                        temp = temp.Substring(4);
                        string g = temp.Remove(temp.Length - 6);
                        temp = g;
                    }
                    p.Number = temp;
                  

                    p.Content = a[1];
                    if(p.Content.StartsWith("<p"))
                    {
                        p.Content = p.Content.Substring(3);
                        string g = p.Content.Remove(p.Content.Length - 4);
                        p.Content = g;
                    }
                    if (p.Content.StartsWith("<h"))
                    {
                        p.Content = p.Content.Substring(4);
                        string g = p.Content.Remove(p.Content.Length - 5);
                        p.Content = g;
                    }


                    factCMs.Add(p);

                }
                if (result != null)
                {
                    return new RequestResponse
                    {
                        ErrorCode = ErrorCode.Success,
                        Content = JsonConvert.SerializeObject(factCMs)
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
        public RequestResponse GetHTMLBySortOrderMap(int id)
        {
            try
            {
                string blockid = pageBlocksServices.GetBlockIDBySortOrder(id);
                List<PiranhaBlock> listblk = blocksServices.GetBlockListHaveParentID(blockid).ToList();
                List<MapCMS> mapCMs = new List<MapCMS>();
                List<string> result = blockFieldsServices.GetListHTML(listblk);
                foreach (string b in result)
                {
                    MapCMS p = new MapCMS();
                    string[] a = b.Split("\n");


                    p.IconCode = a[3];
                    p.Title = a[0];
                    for(int i = 1; i < a.Length-1; i++)
                    {
                        p.Content += a[i];
                    }
                  
                    if(p.Title.StartsWith("<h"))
                    {
                        p.Title = p.Title.Substring(4);
                        string g = p.Title.Remove(p.Title.Length - 5);
                        p.Title = g;
                    }    

                    if (p.IconCode.StartsWith("<p"))
                    {
                        p.IconCode = p.IconCode.Substring(3);
                        string g = p.IconCode.Remove(p.IconCode.Length - 4);
                        p.IconCode = g;
                    }


                    mapCMs.Add(p);

                }
                if (mapCMs != null)
                {
                    return new RequestResponse
                    {
                        ErrorCode = ErrorCode.Success,
                        Content = JsonConvert.SerializeObject(mapCMs)
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
        public RequestResponse GetHTMLBySortOrderWithImgServices(int id)
        {
            try
            {
                string blockid = pageBlocksServices.GetBlockIDBySortOrder(id);
                List<PiranhaBlock> listblk = blocksServices.GetBlockListHaveParentID(blockid).ToList();
                List<ServiceCMS> mapCMs = new List<ServiceCMS>();
                List<string> result = blockFieldsServices.GetListHTMLWithImg(listblk);

                foreach (string b in result)
                {
                    ServiceCMS p = new ServiceCMS();
                    string[] a = b.Split("\n");


                    p.ImgPath = a[0];
                    p.Title = a[1];
              //      p.Content = a[2];

                    if (p.ImgPath.StartsWith("<p"))
                    {

                        p.ImgPath = p.ImgPath.Substring(3);
                        if(p.ImgPath.Contains("\r"))
                        {
                            string g = p.ImgPath.Remove(p.ImgPath.Length - 5);
                            p.ImgPath = g;

                        }
                        else
                        {
                            string g = p.ImgPath.Remove(p.ImgPath.Length - 4);
                            p.ImgPath = g;
                        }
                    
                    }

                    if (p.Title.StartsWith("<h"))
                    {
                        p.Title = p.Title.Substring(4);
                        if (p.Title.Contains("\r"))
                        {
                            string g = p.Title.Remove(p.Title.Length - 6);
                            p.Title = g;
                        }
                        else
                        {
                            string g = p.Title.Remove(p.Title.Length - 5);
                            p.Title = g;
                        }
                       
                       
                    }

                    mapCMs.Add(p);

                }
                if (result != null)
                {
                    return new RequestResponse
                    {
                        ErrorCode = ErrorCode.Success,
                        Content = JsonConvert.SerializeObject(mapCMs)
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
        public RequestResponse GetHTMLBySortOrderWork(int id)
        {
            try
            {
                string blockid = pageBlocksServices.GetBlockIDBySortOrder(id);
                List<PiranhaBlock> listblk = blocksServices.GetBlockListHaveParentID(blockid).ToList();
                List<WorkCMS> workCMs = new List<WorkCMS>();
                List<string> result = blockFieldsServices.GetListHTML(listblk);
                string g = "";
                foreach (string b in result)
                {
                    WorkCMS p = new WorkCMS();
                    string[] a = b.Split("\n");
                    string temp = "";
                    if (a[0].StartsWith("<p"))
                    {
                       temp = a[0].Substring(3);
                        temp = temp.Remove(temp.Length - 4);
                        p.Content = temp;
                    }
                    if (a[1].StartsWith("<p"))
                    {
                        temp = a[1].Substring(3);
                        temp = temp.Remove(temp.Length - 4);
                        p.NumberOrder = Convert.ToInt32(temp);
                    }

                   
           
                  

               

                    if (a[2].StartsWith("<p"))
                    {
                        p.IconCode = a[2].Substring(3);
                        g = p.IconCode.Remove(p.IconCode.Length - 4);
                        p.IconCode = g;
                    }

                    workCMs.Add(p);

                }
              workCMs =  workCMs.OrderBy(x => x.NumberOrder).ToList();
                if (result != null)
                {
                    return new RequestResponse
                    {
                        ErrorCode = ErrorCode.Success,
                        Content = JsonConvert.SerializeObject(workCMs)
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
