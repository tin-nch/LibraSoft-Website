using LibraSoftSolution.API.Event;
using LibraSoftSolution.ViewModels.Event;
using Microsoft.AspNetCore.Mvc;

namespace LibraSoftSolution.Controllers
{
    public class EventController : Controller
    {
        private readonly IRegistersApi _registersApi;
        public EventController(IRegistersApi registersApi)
        {
            _registersApi = registersApi;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RegistersVM registerForm)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var check = await this._registersApi.AddRegister(registerForm);

                    return RedirectToAction("Index");
                }
                catch (Exception e) { };
            }
            return View(registerForm);
        }
    }
}
