using LibraSoftSolution.API.ContentBlock;
using LibraSoftSolution.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace LibraSoftCMS.ViewComponents
{
    [ViewComponent(Name = "AboutUs")]
    public class AboutUsViewComponent : ViewComponent
    {
        private readonly IAboutUsCTAPI _HtmlSOAPI;
        public AboutUsViewComponent(IAboutUsCTAPI blockAPI)
        {
            _HtmlSOAPI = blockAPI;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            AboutUsDataModel aboutDataModel = new AboutUsDataModel();
            aboutDataModel.About1 = await _HtmlSOAPI.gethtmlbysortordersWithImgAboutUs(1);
            aboutDataModel.About3 = await _HtmlSOAPI.gethtmlbysortordersWithImgAboutUs(5);
            return View(aboutDataModel);
        }
    }
}
