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
            var reasonList = (from r in _piranhaCoreContext.PiranhaCfreasonReachings
                              select new SelectListItem()
                              {
                                  Text = r.ReasonReachingContent
                              }).ToList();

            reasonList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });

            ReasonReachingViewModel reasonReachingViewModel = new ReasonReachingViewModel();
            reasonReachingViewModel.ListofReason = reasonList;

            var reasonReachingList = await _ReasonReachingAPI.GetReasonReaching();
            ViewBag.ListOfReasonReaching = reasonReachingList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index( ContactVM piranha_ContactForm)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var check = await this._ContactAPI.AddContactForm(piranha_ContactForm);

                    return View();
                }
                catch (Exception e) { };
            }
            return View();
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