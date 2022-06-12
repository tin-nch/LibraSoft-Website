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
        public async Task<IViewComponentResult> InvokeAsync(Guid id)
        {
            PiranhaPage pP = (from p in _piranhaCoreContext.PiranhaPages
                             where p.Id.Equals(id)
                             select p).FirstOrDefault();
            ViewData["heroPage"] = pP;
            return View();
        }
    }
}
