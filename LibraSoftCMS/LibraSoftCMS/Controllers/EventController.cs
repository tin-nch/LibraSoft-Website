using LibraSoftSolution.API.Event;
using LibraSoftSolution.ViewModels.Event;
using Microsoft.AspNetCore.Mvc;

namespace LibraSoftCMS.Controllers
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
        public async Task<JsonResult> RegisterEvent(RegistersVM registerForm)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    string check = await this._registersApi.AddRegister(registerForm);
                    if (check.Contains("regist success"))
                    {
                        return Json(1);
                    }
                    else
                        return Json(0);

                }
                catch (Exception e)
                {

                };
            }
            return Json(-1);
        }
    }
}
