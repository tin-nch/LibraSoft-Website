using LibraSoftSolution.API.ContentBlock;
using LibraSoftSolution.API.ContentWeb;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace LibraSoftSolution.ViewComponents
{
    [ViewComponent(Name = "Partner")]
    public class PartnerViewComponent : ViewComponent
    {
        private readonly IPartnerCTAPI _HtmlSOAPI;
        public PartnerViewComponent(IPartnerCTAPI partnerCTAPI)
        {
            _HtmlSOAPI = partnerCTAPI;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Item = await _HtmlSOAPI.gethtmlbysortordersWithImgPartner(36);
            return View(Item);
        }
    }
}
