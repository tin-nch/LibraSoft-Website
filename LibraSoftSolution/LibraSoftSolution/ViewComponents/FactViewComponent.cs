using LibraSoftSolution.API.ContentBlock;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace LibraSoftSolution.ViewComponents
{
    [ViewComponent(Name = "Fact")]
    public class FactViewComponent : ViewComponent
    {
        private readonly IFactCTAPI _HtmlSOAPI;
        public FactViewComponent(IFactCTAPI factCTAPI)
        {
            _HtmlSOAPI = factCTAPI;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Item = await _HtmlSOAPI.gethtmlbysortordersWithImgFact(17);
            return View(Item);
        }
    }
}
