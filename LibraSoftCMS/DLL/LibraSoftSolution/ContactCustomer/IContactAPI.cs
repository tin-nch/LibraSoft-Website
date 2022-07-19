using LibraSoftSolution.Models;
using LibraSoftSolution.ViewModels.Candidate_CV;
using LibraSoftSolution.ViewModels.ContactForm;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.API.ContactCustomer
{
    public interface IContactAPI
    {
        Task<List<ContactVM>> GetContacts();
        Task<string> AddContactForm(ContactVM contact);
        Task<bool> AddCvForm(CandidateFormVM contact);
        Task<RequestResponse> AddFile(IFormFile file);
        Task<bool> AddCandidate(CandidateVM candidate);

    }
}
