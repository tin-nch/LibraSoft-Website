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
    [ViewComponent(Name = "MContact")]
    public class MiniContactViewComponent: ViewComponent
    {
        private readonly IBlockAPI _HtmlSOAPI;
        private PiranhaCoreContext _databaseContext;
        public MiniContactViewComponent(PiranhaCoreContext piranhaCoreContext, IBlockAPI htmlSOAPI)
        {
            _databaseContext = piranhaCoreContext;
            _HtmlSOAPI = htmlSOAPI;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Item = await _HtmlSOAPI.gethtmlbysortordersWithImg(22);
            return View(Item);
        }
    }
}
