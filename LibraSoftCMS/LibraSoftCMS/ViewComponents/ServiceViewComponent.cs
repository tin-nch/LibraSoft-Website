using LibraSoftSolution.API.ContentBlock;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace LibraSoftCMS.ViewComponents
{
    [ViewComponent(Name = "Service")]
    public class ServiceViewComponent : ViewComponent
    {
        private readonly IServiceCTAPI _HtmlSOAPI;

        public ServiceViewComponent(IServiceCTAPI htmlSOAPI)
        {
            _HtmlSOAPI = htmlSOAPI;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Item = await _HtmlSOAPI.gethtmlbysortordersWithImgService(8);
            return View(Item);
        }
    }
}
