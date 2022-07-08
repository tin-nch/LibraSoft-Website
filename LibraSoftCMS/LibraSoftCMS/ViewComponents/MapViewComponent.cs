using LibraSoftSolution.API.ContentBlock;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace LibraSoftCMS.ViewComponents
{
    [ViewComponent(Name = "Map")]
    public class MapViewComponent : ViewComponent
    {
        private readonly IMapCTAPI _HtmlSOAPI;
        public MapViewComponent(IMapCTAPI partnerCTAPI)
        {
            _HtmlSOAPI = partnerCTAPI;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Item = await _HtmlSOAPI.gethtmlbysortordersWithImgMap(48);
            return View(Item);
        }
    }
}
