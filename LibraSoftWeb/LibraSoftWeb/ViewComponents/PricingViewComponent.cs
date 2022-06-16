using LibraSoftWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Linq;
using LibraSoftSolution.API;
using LibraSoftSolution.API.ContentWeb;

namespace LibraSoftWeb.ViewComponents
{
    [ViewComponent(Name = "Pricing")]
    public class PricingViewComponent:ViewComponent
    {
        private readonly IBlockAPI _HtmlSOAPI;
        private PiranhaCoreContext _databaseContext;
        public PricingViewComponent(PiranhaCoreContext piranhaCoreContext, IBlockAPI htmlSOAPI)
        {
            _databaseContext = piranhaCoreContext;
            _HtmlSOAPI = htmlSOAPI;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Item = await _HtmlSOAPI.gethtmlbysortordersWithImg(3);
            return View(Item);
        }
    }
}
