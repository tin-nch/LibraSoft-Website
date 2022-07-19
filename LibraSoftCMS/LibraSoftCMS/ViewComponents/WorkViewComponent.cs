using LibraSoftSolution.API.ContentBlock;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace LibraSoftCMS.ViewComponents
{
    [ViewComponent(Name = "Work")]
    public class WorkViewComponent : ViewComponent
    {
        private readonly IWorkCTAPI _HtmlSOAPI;
        public WorkViewComponent(IWorkCTAPI partnerCTAPI)
        {
            _HtmlSOAPI = partnerCTAPI;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Item = await _HtmlSOAPI.gethtmlbysortordersWithImgWork(53);
            return View(Item);
        }
    }
}
