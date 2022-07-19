using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace LibraSoftCMS.ViewComponents
{
    [ViewComponent(Name = "Contact")]

    public class ContactViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
