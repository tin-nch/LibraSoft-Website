using LibraSoftSolution.API.Contacts_Customer;
using LibraSoftSolution.API.Test;
using LibraSoftSolution.ViewModels.ContactForm;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LibraSoftWeb.Controllers
{
    public class TestController : Controller
    {
        //private readonly INavigationTitle _NavigationTitle;
        private readonly IContactAPI _IContact;
        private readonly ICFCountryAPI _ICFCountryAPI;
        private readonly ICFIndustryAPI _ICFIndustryAPI;
        private readonly ICFReasonReachingAPI cFReasonReachingAPI1;
        private readonly ITestAPI _testAPI;

        //public TempController(INavigationTitle NavigationTitle)
        //{
        //    _NavigationTitle = NavigationTitle;
        //}
        public TestController(IContactAPI IContact, ICFCountryAPI CFCountryAPI, ICFIndustryAPI cFIndustryAPI,
            ICFReasonReachingAPI cFReasonReachingAPI, ITestAPI testAPI)
        {
            _ICFCountryAPI = CFCountryAPI;
            _IContact = IContact;
            _ICFIndustryAPI = cFIndustryAPI;
            cFReasonReachingAPI1 = cFReasonReachingAPI;
            _testAPI = testAPI;
        }

        public async Task<IActionResult> Index()
        {
            //var a = await _NavigationTitle.GetTitle();
            //var a = await cFReasonReachingAPI1.GetReasonReaching();
            //var a = await _ICFIndustryAPI.GetIndustry();
            //var a = await _ICFCountryAPI.GetCountry();
            //var a = await _IContact.GetContacts();
            ContactVM a = new ContactVM();
            bool c = await _IContact.AddContactForm(a);
            //var a = await _testAPI.GetAll();
            ViewBag.test = c;
            return View();
        }
    }
}
