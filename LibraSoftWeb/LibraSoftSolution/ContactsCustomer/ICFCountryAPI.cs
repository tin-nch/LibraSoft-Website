using LibraSoftSolution.ViewModels.ContactForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.API.Contacts_Customer
{
    public interface ICFCountryAPI
    {
        Task<List<CFCountryVM>> GetCountry();
    }
}
