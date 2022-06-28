using LibraSoftSolution.API.ContactCustomer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace LibraSoftSolution.ViewComponents
{
    [ViewComponent(Name = "Contact")]

    public class ContactViewComponent : ViewComponent
    {
        private readonly IContactAPI _ContactAPI;
        private readonly ICFReasonReachingAPI _ReasonReachingAPI;

        public ContactViewComponent(IContactAPI contactAPI, ICFReasonReachingAPI cFReasonReachingAPI)
        {
            _ContactAPI = contactAPI;
            _ReasonReachingAPI = cFReasonReachingAPI;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var reasonReachingList = await _ReasonReachingAPI.GetReasonReaching();
            ViewBag.ListOfReasonReaching = reasonReachingList;
            return View();
        }
    }
}
