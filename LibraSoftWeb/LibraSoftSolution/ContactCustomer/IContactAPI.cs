using LibraSoftSolution.ViewModels;
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
        Task<bool> AddContactForm(ContactVM contact);
    }
}
