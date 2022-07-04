using LibraSoftSolution.API.Event;
using LibraSoftSolution.Models;
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> RegisterEvent(RegistersVM registerForm)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    string check = await this._registersApi.AddRegister(registerForm);
                    if(check.Contains("submit success"))
                    {
                        return Json(1);
                    }  
                    else
                        return Json(0);

                }
                catch (Exception e) {
                  
                };
            }
            return Json(-1);
        }
    }
}
