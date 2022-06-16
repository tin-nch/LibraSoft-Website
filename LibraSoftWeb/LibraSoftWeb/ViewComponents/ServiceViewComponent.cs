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
    [ViewComponent(Name = "Service")]

    public class ServiceViewComponent:ViewComponent
    {
        private readonly IBlockAPI _HtmlSOAPI;
        private PiranhaCoreContext _databaseContext;
        public ServiceViewComponent( PiranhaCoreContext piranhaCoreContext, IBlockAPI htmlSOAPI)
        {
            _databaseContext = piranhaCoreContext;
            _HtmlSOAPI = htmlSOAPI;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Item = await _HtmlSOAPI.gethtmlbysortordersWithImg(17);
            return View(Item);
        }
    }
}
