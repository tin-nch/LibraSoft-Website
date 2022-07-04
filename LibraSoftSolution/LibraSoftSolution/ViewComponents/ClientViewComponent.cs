using LibraSoftSolution.API.ContentBlock;
using LibraSoftSolution.API.ContentWeb;
using LibraSoftSolution.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace LibraSoftSolution.ViewComponents
{
    [ViewComponent(Name = "Client")]
    public class ClientViewComponent : ViewComponent
    {
        private readonly IClientCTAPI _HtmlSOAPI;
        public ClientViewComponent(IClientCTAPI blockAPI)
        { 
            _HtmlSOAPI = blockAPI;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ClientDataModel clientDataModel = new ClientDataModel();
            clientDataModel.Client1 = await _HtmlSOAPI.gethtmlbysortordersWithImgClient(22);
            clientDataModel.Client2 = await _HtmlSOAPI.gethtmlbysortordersWithImgClient(32);
            return View(clientDataModel);
        }
    }
}
