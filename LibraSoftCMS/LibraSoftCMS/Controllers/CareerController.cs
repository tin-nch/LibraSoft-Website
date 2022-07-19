using LibraSoftSolution.API.ContactCustomer;
using LibraSoftSolution.Models;
using LibraSoftSolution.ViewModels.Candidate_CV;
using Microsoft.AspNetCore.Mvc;

namespace LibraSoftCMS.Controllers
{
    public class CareerController : Controller
    {
        private readonly IContactAPI _ContactAPI;
        public CareerController(IContactAPI contactAPI)
        {
            _ContactAPI = contactAPI;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CandidateFormVM candidateForm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    RequestResponse body = await _ContactAPI.AddFile(candidateForm.File);

                    CandidateVM obj = new CandidateVM
                    {
                        Email = candidateForm.Email,
                        FullName = candidateForm.FullName,
                        Phone = candidateForm.Phone,
                        FilePath = body.Content
                    };

                    await _ContactAPI.AddCandidate(obj);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                };
            }
            return View();
        }
    }
}
