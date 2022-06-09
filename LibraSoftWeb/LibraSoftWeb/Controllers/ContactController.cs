using LibraSoftWeb.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace LibraSoftWeb.Controllers
{
    public class ContactController : Controller
    {
        private DatabaseContext _databaseContext;
        public ContactController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public IActionResult Index()
        {
            var industryList = (from industry in _databaseContext.Piranha_CFIndustries
                                select new SelectListItem()
                                {
                                    Text = industry.IndustyName,
                                    Value = industry.IndustyId.ToString(),
                                }).ToList();
            industryList.Insert(0, new SelectListItem()
            {
                Text="---Select---",
                Value= string.Empty
            });
            ViewBag.ListOfIndustry = industryList;

            var countryList = (from country in _databaseContext.Piranha_CFCountries
                                select new SelectListItem()
                                {
                                    Text = country.CountryName,
                                    Value = country.CountryId.ToString(),
                                }).ToList();
            countryList.Insert(0, new SelectListItem()
            {
                Text = "---Select---",
                Value = string.Empty
            });

            ViewBag.ListOfCountry = countryList;

            var reasonReachingList = (from rr in _databaseContext.Piranha_CFReasonReachings
                                select new SelectListItem()
                                {
                                    Text = rr.ReasonReachingContent,
                                    Value = rr.ReasonReachingId.ToString(),
                                }).ToList();
            reasonReachingList.Insert(0, new SelectListItem()
            {
                Text = "---Select---",
                Value = string.Empty
            });
            ViewBag.ListOfReasonReaching = reasonReachingList;

            return View();
        }

        [HttpPost]
        public IActionResult Index(Piranha_ContactForm piranha_ContactForm)
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
