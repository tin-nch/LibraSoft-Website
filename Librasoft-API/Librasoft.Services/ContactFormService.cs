using AutoMapper;
using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.Entities.Entities;
using Librasoft.Services.Constract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.Services
{
    public class ContactFormService: IContactFormsServices
    {
        private readonly IContactFormRepository contactFormRepository;

        private readonly IMapper mapper;

        public ContactFormService(IContactFormRepository contactFormRepository, IMapper mapper)
        {
            this.contactFormRepository = contactFormRepository;
            this.mapper = mapper;
        }

        public async Task<PiranhaContactForm> AddContactFormAsync(PiranhaContactForm piranhaContactForm)
        {
            PiranhaContactForm add = await contactFormRepository.AddAsync(mapper.Map<PiranhaContactForm>(piranhaContactForm));
            if (add != null)
            {
                PiranhaContactForm dto = mapper.Map<PiranhaContactForm>(add);
                
                // Task.Run(() => { syncCommunication.PushToSync(ActionType.Insert, DataType.Master, dto.GetType().Name, dto, dto.BlackListID); });
                return dto;
            }
            return null;
        }

        public Task<PiranhaContactForm> GetContactFormByIdAsync(string contactID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PiranhaContactForm>> GetContactFormlistAsync()
        {
            IReadOnlyList<PiranhaContactForm> contactForms = await contactFormRepository.ListAsync();
            return mapper.Map<IEnumerable<PiranhaContactForm>>(contactForms);
        }
        public Task<PiranhaContactForm> UpdateContactFormAsync(PiranhaContactForm contactForm)
        {
            throw new NotImplementedException();
        }
    }
}
