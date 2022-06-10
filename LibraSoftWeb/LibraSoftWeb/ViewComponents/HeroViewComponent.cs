using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace LibraSoftWeb.ViewComponents
{
    [ViewComponent(Name = "Hero")]
    public class HeroViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
