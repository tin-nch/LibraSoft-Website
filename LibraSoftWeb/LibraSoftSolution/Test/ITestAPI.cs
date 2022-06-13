using LibraSoftSolution.Models;
using LibraSoftSolution.ViewModels.ContactForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.API.Test
{
    public interface ITestAPI
    {
        Task<List<ContactVM>> GetAll();
    }
}
