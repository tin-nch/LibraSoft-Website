using LibraSoftSolution.API.ContactCustomer;
using LibraSoftSolution.API.ContentWeb;
using LibraSoftSolution.API.ReceiveMails;
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
        private readonly IEmailAPI emailAPI1;
        private readonly IBlockAPI blockAPI;
        //public TempController(INavigationTitle NavigationTitle)
        //{
        //    _NavigationTitle = NavigationTitle;
        //}
        public TestController(IContactAPI IContact, ICFCountryAPI CFCountryAPI, ICFIndustryAPI cFIndustryAPI,
            ICFReasonReachingAPI cFReasonReachingAPI, ITestAPI testAPI, IEmailAPI emailAPI, IBlockAPI _blocksAPI)
        {
            _ICFCountryAPI = CFCountryAPI;
            _IContact = IContact;
            _ICFIndustryAPI = cFIndustryAPI;
            cFReasonReachingAPI1 = cFReasonReachingAPI;
            _testAPI = testAPI;
            emailAPI1 = emailAPI;
            blockAPI = _blocksAPI; 
        }

        public async Task<IActionResult> Index()
        {
            //var a = await _NavigationTitle.GetTitle();
            //var a = await cFReasonReachingAPI1.GetReasonReaching();
            //var a = await _ICFIndustryAPI.GetIndustry();
            //var a = await _ICFCountryAPI.GetCountry();
            //var a = await _IContact.GetContacts();
            //ContactVM a = new ContactVM {
            //    Email = "customer1@gmail.com",
            //    LastName = "Nguyen Van",
            //    FirstName = "Nam",
            //    MessageContent = "This is Content message"
            //};
            //bool c = await emailAPI1.SendEmail(a);
            var a = await blockAPI.GetListBlocksCLRType();
            //var b = await blockAPI.GetListBlocksFields();
            ViewBag.test = a;
            return View();
        }
    }
}
