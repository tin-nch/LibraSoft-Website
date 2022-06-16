using LibraSoftWeb.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using LibraSoftSolution.API;
using LibraSoftSolution.ViewModels;
using LibraSoftSolution.API.ReceiveMails;
using LibraSoftSolution.API.ContactCustomer;
using LibraSoftSolution.ViewModels.ContactForm;
using LibraSoftSolution.API.ContentWeb;

namespace LibraSoftWeb.Controllers
{
    public class ContactController : Controller
    {
        private readonly ICFCountryAPI _CountryAPI;
        private readonly ICFIndustryAPI _IndustryAPI;
        private readonly ICFReasonReachingAPI _ReasonReachingAPI;
        private readonly IContactAPI _ContactAPI;
        private readonly IEmailAPI _EmailAPI;
        private readonly IBlockAPI _HtmlSOAPI;
        private PiranhaCoreContext _databaseContext;


        public ContactController( ICFCountryAPI cFCountryAPI, ICFIndustryAPI cFIndustryAPI, ICFReasonReachingAPI cFReasonReachingAPI, IContactAPI contactAPI, IEmailAPI emailAPI, PiranhaCoreContext piranhaCoreContext, IBlockAPI htmlSOAPI)
        {
            _CountryAPI = cFCountryAPI;
            _IndustryAPI = cFIndustryAPI;
            _ReasonReachingAPI = cFReasonReachingAPI;
            _ContactAPI = contactAPI;
            _databaseContext = piranhaCoreContext;
            _EmailAPI = emailAPI;
            _HtmlSOAPI = htmlSOAPI;

        }
        public async Task<IActionResult> Index()
        {
            var industryList = await _IndustryAPI.GetIndustry();
            ViewBag.ListOfIndustry = industryList;

            var countryList = await _CountryAPI.GetCountry();

            ViewBag.ListOfCountry = countryList;

            var reasonReachingList = await _ReasonReachingAPI.GetReasonReaching();
            ViewBag.ListOfReasonReaching = reasonReachingList;

            ViewBag.HtmlWithImg = _HtmlSOAPI.gethtmlbysortordersWithImg(7);


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactVM piranha_ContactForm)
        {

            if (ModelState.IsValid)
            {
                
                try
                {
                    await this._ContactAPI.AddContactForm(piranha_ContactForm);
                    await this._EmailAPI.SendEmail(piranha_ContactForm);
                    return RedirectToAction("Index");
                }
                catch (Exception e) { };

            }
            return View(piranha_ContactForm);
        }
    }
}
