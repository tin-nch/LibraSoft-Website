using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace LibraSoftWeb.ViewComponents
{
    public class PartnerViewComponent
    {
        [ViewComponent(Name = "Partner")]
        public class HeroViewComponent : ViewComponent
        {
            public async Task<IViewComponentResult> InvokeAsync()
            {
                return View();
            }
        }
    }
}
