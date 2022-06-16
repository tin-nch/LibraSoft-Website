using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace LibraSoftWeb.ViewComponents
{
    [ViewComponent(Name = "MarkdownBlock")]
    public class MarkdownBlock:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
