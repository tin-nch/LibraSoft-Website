using LibraSoftCMS.ViewModel;
using LibraSoftSolution.API.ContentBlock;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace LibraSoftCMS.ViewComponents
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
            PartnerDataModel Item = new PartnerDataModel();
            Item.PartnerMain = await _HtmlSOAPI.gethtmlbysortordersWithImgPartner(45);
            Item.Partner = await _HtmlSOAPI.gethtmlbysortordersWithImgPartner(42);
            return View(Item);
        }
    }
}
