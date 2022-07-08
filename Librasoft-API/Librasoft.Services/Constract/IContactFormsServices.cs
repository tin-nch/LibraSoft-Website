using Librasoft.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.Services.Constract
{
    public interface IContactFormsServices
    {
        public Task<IEnumerable<PiranhaContactForm>> GetContactFormlistAsync();
        Task<PiranhaContactForm> GetContactFormByIdAsync(string contactID);
        Task<PiranhaContactForm> AddContactFormAsync(PiranhaContactForm contactForm);
        Task<PiranhaContactForm> UpdateContactFormAsync(PiranhaContactForm contactForm);
        public bool ValidateContactForm(PiranhaContactForm contactForm);
    }
}
