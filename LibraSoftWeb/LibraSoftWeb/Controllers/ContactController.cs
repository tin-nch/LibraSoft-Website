﻿using LibraSoftWeb.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using LibraSoftSolution.API;
using LibraSoftSolution.API.Contacts_Customer;

namespace LibraSoftWeb.Controllers
{
    public class ContactController : Controller
    {
        private readonly ICFCountryAPI _CountryAPI;
        private readonly ICFIndustryAPI _IndustryAPI;
        private readonly ICFReasonReachingAPI _ReasonReachingAPI;
        private readonly IContactAPI _ContactAPI;
        private PiranhaCoreContext _databaseContext;


        public ContactController( ICFCountryAPI cFCountryAPI, ICFIndustryAPI cFIndustryAPI, ICFReasonReachingAPI cFReasonReachingAPI, IContactAPI contactAPI, PiranhaCoreContext piranhaCoreContext )
        {
            _CountryAPI = cFCountryAPI;
            _IndustryAPI = cFIndustryAPI;
            _ReasonReachingAPI = cFReasonReachingAPI;
            _ContactAPI = contactAPI;
            _databaseContext = piranhaCoreContext;


        }
        public async Task<IActionResult> Index()
        {
            var industryList = await _IndustryAPI.GetIndustry();
            ViewBag.ListOfIndustry = industryList;

            var countryList = await _CountryAPI.GetCountry();

            ViewBag.ListOfCountry = countryList;

            var reasonReachingList = await _ReasonReachingAPI.GetReasonReaching();
            ViewBag.ListOfReasonReaching = reasonReachingList;

            return View();
        }

        [HttpPost]
        public IActionResult Index(PiranhaContactForm piranha_ContactForm)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    this._databaseContext.Add(piranha_ContactForm);
                    this._databaseContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception e) { };

            }
            return View(piranha_ContactForm);
        }
    }
}
