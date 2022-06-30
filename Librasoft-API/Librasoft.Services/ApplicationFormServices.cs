using AutoMapper;
using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.Entities.Entities;
using Librasoft.Entities.Entities.Dtos;
using Librasoft.Services.Constract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.Services
{
    public class ApplicationFormServices : IApplicationFormServices
    {
        private readonly IApplicationFormRepository applicationFormRepository;

        private readonly IMapper mapper;
        public ApplicationFormServices(IApplicationFormRepository applicationFormRepository, IMapper mapper)
        {
            this.applicationFormRepository = applicationFormRepository;
            this.mapper = mapper;
        }

        public async Task<PiranhaApplicationForm> AddApplicationFormAsync(PiranhaApplicationForm applicationForm)
        {
            PiranhaApplicationForm add = await applicationFormRepository.AddAsync(mapper.Map<PiranhaApplicationForm>(applicationForm));
            if (add != null)
            {
                PiranhaApplicationForm dto = mapper.Map<PiranhaApplicationForm>(add);

                // Task.Run(() => { syncCommunication.PushToSync(ActionType.Insert, DataType.Master, dto.GetType().Name, dto, dto.BlackListID); });
                return dto;
            }
            return null;
        }

        public bool checkExistsEmail(PiranhaApplicationForm applicationForm)
        {
            return  applicationFormRepository.CheckExistsEmail(applicationForm);
        }

        public async Task<List<PiranhaApplicationForm>> GetApplicaitionFormlistAsync()
        {
            IReadOnlyList<PiranhaApplicationForm> block = await applicationFormRepository.ListAsync();
            return mapper.Map<List<PiranhaApplicationForm>>(block);
        }
    }
}
