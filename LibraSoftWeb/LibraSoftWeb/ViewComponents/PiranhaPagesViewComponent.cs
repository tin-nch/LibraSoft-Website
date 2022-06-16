using LibraSoftWeb.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LibraSoftSolution.API;

namespace LibraSoftWeb.Controllers
{
    [ViewComponent(Name = "Piranha_PagesView")]
    public class Piranha_PagesViewComponent : ViewComponent
    {
        private readonly INavigationTitleAPI _NavigationTitle;

        public Piranha_PagesViewComponent(INavigationTitleAPI NavigationTitle)
        {
            _NavigationTitle = NavigationTitle;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPages = await _NavigationTitle.GetTitle();
            return View(listofPages);
        }
    }
}
