using LibraSoftSolution.API.Event;
using LibraSoftSolution.ViewModels.Event;
using Microsoft.AspNetCore.Mvc;

namespace LibraSoftCMS.Controllers
{
    public class SubmitFormController : Controller
    {
        private readonly IRegistersApi _registersApi;
        public SubmitFormController(IRegistersApi registersApi)
        {
            _registersApi = registersApi;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> CheckSubmit(string email, int idEvent)
        {
            RegistersVM registerForm = new RegistersVM();
            registerForm.Email = email;
            registerForm.IDEvent = idEvent;
            if (ModelState.IsValid)
            {
                try
                {
                    string check = await this._registersApi.AddRegister(registerForm);
                    if (check.Contains("submit success"))
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
