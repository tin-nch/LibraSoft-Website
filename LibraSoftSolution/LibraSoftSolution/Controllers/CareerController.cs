using Microsoft.AspNetCore.Mvc;

namespace LibraSoftSolution.Controllers
{
    public class CareerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
