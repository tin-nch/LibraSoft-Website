using Librasoft.Entities.Entities;
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
        Task<bool> SendEmail(PiranhaContactForm contactForm);
        Task<bool> SendConFirmEmail(PiranhaEventParticipant participant);
    }
}
