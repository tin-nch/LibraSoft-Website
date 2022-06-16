using LibraSoftSolution.API;
using LibraSoftWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using LibraSoftSolution.API.ContentWeb;

namespace LibraSoftWeb.ViewComponents
{
    [ViewComponent(Name = "Counter")]
    public class CounterViewComponent : ViewComponent       
    {
        private readonly INavigationTitleAPI _NavigationTitle;
        private readonly IBlockAPI _HtmlSOAPI;
        private PiranhaCoreContext _databaseContext;
        public CounterViewComponent(INavigationTitleAPI NavigationTitle, PiranhaCoreContext piranhaCoreContext, IBlockAPI htmlSOAPI)
        {
            _NavigationTitle = NavigationTitle;
            _databaseContext = piranhaCoreContext;
            _HtmlSOAPI = htmlSOAPI;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Item = await _HtmlSOAPI.gethtmlbysortordersWithImg(7);
            return View(Item);
        }
        //public IEnumerable<ViewModel> GetItem()
        //{
        //    var idBlock = from p in _databaseContext.PiranhaBlocks
        //                  where p.ParentId == null
        //                  select p into temp1
        //                  join b in _databaseContext.PiranhaBlocks on temp1.Id equals b.ParentId
        //                  join bf in _databaseContext.PiranhaBlockFields on b.Id equals bf.BlockId
        //                  join pb in _databaseContext.PiranhaPageBlocks on b.Id equals pb.BlockId
        //                  where pb.SortOrder == 7
        //                  select new ViewModel
        //                  {
        //                      PageBlock = pb,
        //                      Block = b,
        //                      BlockField = bf
        //                  };

        //    var temp = from b1 in _databaseContext.PiranhaBlocks
        //               join b2 in _databaseContext.PiranhaBlocks on b1.Id equals b2.Id
        //               where b1.ParentId == null
        //               select new ViewModel
        //               {
        //                   Block = b1
        //               };


        //    var value = from pp in _databaseContext.PiranhaPages
        //                join pb in _databaseContext.PiranhaPageBlocks on pp.Id equals pb.PageId
        //                join b in _databaseContext.PiranhaBlocks on pb.BlockId equals b.Id
        //                join bf in _databaseContext.PiranhaBlockFields on b.Id equals bf.BlockId
        //                where pb.SortOrder == 8
        //                select new ViewModel
        //                {
        //                    Page = pp,
        //                    PageBlock = pb,
        //                    Block = b,
        //                    BlockField = bf
        //                };
        //    return value;
        //}
    }
}
