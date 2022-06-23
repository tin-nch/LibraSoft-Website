using Microsoft.AspNetCore.Mvc;

namespace LibraSoftSolution.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
