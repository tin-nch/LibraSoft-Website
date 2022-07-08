using Librasoft.Entities.Entities;
using Librasoft.Entities.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.Services.Constract
{
    public interface ISendEmailServices
    {
        Task<IEnumerable<AdminAccount>> GetVirtualAccountAsync();
        public PiranhaApplicationForm GetApplicationForm(PiranhaApplicationForm application);
        Task<bool> SendEmail(PiranhaContactForm contactForm);
        Task<bool> SendConFirmEmail(EventParticipantDto participant);
        public Task<bool> SendCVEmail(PiranhaApplicationForm applicationForm);
        public Task<bool> SendOPT(string email,string usertype);
       
    }
}
