using LibraSoftSolution.API;
using LibraSoftWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LibraSoftWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INavigationTitleAPI _NavigationTitle;
        private PiranhaCoreContext _databaseContext;


        public HomeController(ILogger<HomeController> logger, INavigationTitleAPI NavigationTitle, PiranhaCoreContext piranhaCoreContext)
        {
            _logger = logger;
            _NavigationTitle = NavigationTitle;
            _databaseContext = piranhaCoreContext;

        }
        public IActionResult Index()
        {
            var idPage = from p in _databaseContext.PiranhaPages
                              where p.NavigationTitle.Equals("Home")
                              select p;

            var Item = GetItem();
            return View(Item);
        }
        public IEnumerable<ViewModel> GetItem()
        {
            var value = from pp in _databaseContext.PiranhaPages
                        join pb in _databaseContext.PiranhaPageBlocks on pp.Id equals pb.PageId
                        join b in _databaseContext.PiranhaBlocks on pb.BlockId equals b.Id
                        join bf in _databaseContext.PiranhaBlockFields on b.Id equals bf.BlockId
                        orderby pb.SortOrder ascending
                        select new ViewModel
                        {
                            Page = pp,
                            PageBlock = pb,
                            Block = b,
                            BlockField = bf
                        }; 
            return value;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
