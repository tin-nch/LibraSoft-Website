using LibraSoftWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Linq;
namespace LibraSoftWeb.ViewComponents
{
    [ViewComponent(Name = "Hero")]
    public class HeroViewComponent : ViewComponent
    {
        private PiranhaCoreContext _piranhaCoreContext;
        public HeroViewComponent(PiranhaCoreContext piranhaCoreContext)
        {
            _piranhaCoreContext = piranhaCoreContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = (from p in _piranhaCoreContext.PiranhaPages
                      where p.NavigationTitle.Equals("Home")
                      select p.Id).FirstOrDefault();
            var contentPage = _piranhaCoreContext.PiranhaPages.FirstOrDefault(m => m.Id.Equals(id));
            //PiranhaPage pP = (from p in _piranhaCoreContext.PiranhaPages
            //                 where p.Id.Equals(id)
            //                 select p).FirstOrDefault();
            return View(contentPage);
        }
    }
}
