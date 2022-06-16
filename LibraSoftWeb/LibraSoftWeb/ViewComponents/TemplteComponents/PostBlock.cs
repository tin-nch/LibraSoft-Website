using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace LibraSoftWeb.ViewComponents
{
    [ViewComponent(Name = "PostBlock")]

    public class PostBlock:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
