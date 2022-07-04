using LibraSoftSolution.API.ContactCustomer;
using LibraSoftSolution.Models;
using LibraSoftSolution.ViewModel;
using LibraSoftSolution.ViewModels.ContactForm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Linq;

namespace LibraSoftSolution.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactAPI _ContactAPI;
        private readonly ICFReasonReachingAPI _ReasonReachingAPI;
        private readonly PiranhaCoreContext _piranhaCoreContext;


        public HomeController(ILogger<HomeController> logger, ICFReasonReachingAPI cFReasonReachingAPI, IContactAPI contactAPI, PiranhaCoreContext piranhaCoreContext)
        {
            _logger = logger;
            _ContactAPI = contactAPI;
            _ReasonReachingAPI = cFReasonReachingAPI;
            _piranhaCoreContext = piranhaCoreContext;
        }
        public async Task<IActionResult> Index()
        {
            var reasonReachingList = await _ReasonReachingAPI.GetReasonReaching();
            ViewBag.ListOfReasonReaching = reasonReachingList;

            ContactVM ct = new ContactVM();
            return View(ct);
        }
        public async Task<JsonResult> SaveContactForm(ContactVM piranha_ContactForm)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    bool check = await this._ContactAPI.AddContactForm(piranha_ContactForm);
                    ModelState.Clear();
                    if (check)
                    {
                        return Json(1);
                    }
                    else
                        return Json(0);

                }
                catch (Exception e)
                {

                };
            }
            return Json(-1);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}