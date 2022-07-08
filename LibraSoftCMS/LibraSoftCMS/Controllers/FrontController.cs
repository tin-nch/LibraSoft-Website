using System;
using System.Threading.Tasks;
using LibraSoftCMS.Models;
using LibraSoftSolution.API.ContactCustomer;
using LibraSoftSolution.ViewModels.ContactForm;
using Microsoft.AspNetCore.Mvc;
using Piranha;

namespace LibraSoftCMS.Controllers
{
    public class FrontController : Controller
    {
        private readonly ILogger<FrontController> _logger;
        private readonly IContactAPI _ContactAPI;
        private readonly ICFReasonReachingAPI _ReasonReachingAPI;
        private readonly LibraSoftCMSContext _piranhaCoreContext;

        public FrontController(ILogger<FrontController> logger, ICFReasonReachingAPI cFReasonReachingAPI, IContactAPI contactAPI, LibraSoftCMSContext piranhaCoreContext)
        {
            _logger = logger;
            _ContactAPI = contactAPI;
            _ReasonReachingAPI = cFReasonReachingAPI;
            _piranhaCoreContext = piranhaCoreContext;
        }

        [Route("page")]
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
                    string check = await this._ContactAPI.AddContactForm(piranha_ContactForm);
                    ModelState.Clear();
                    if (check.Contains("contact exists"))
                    {
                        return Json(0);
                    }
                    else
                        return Json(1);

                }
                catch (Exception e)
                {

                };
            }
            return Json(-1);
        }
    }
}
