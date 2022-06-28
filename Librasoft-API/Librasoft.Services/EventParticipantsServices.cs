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
    public class EventParticipantsServices : IEventParticipantsServices
    {
        public IEventParticipantsRepository eventParticipantsRepository;
        private readonly IMapper mapper;

        public EventParticipantsServices(IEventParticipantsRepository eventParticipantsRepository, IMapper mapper)
        {
            this.eventParticipantsRepository = eventParticipantsRepository;
            this.mapper = mapper;
        }

        public async Task<PiranhaEventParticipant> AddParticipantsAsync(PiranhaEventParticipant e)
        {
            PiranhaEventParticipant add = await eventParticipantsRepository.AddAsync(mapper.Map<PiranhaEventParticipant>(e));
            if (add != null)
            {
                PiranhaEventParticipant dto = mapper.Map<PiranhaEventParticipant>(add);

                // Task.Run(() => { syncCommunication.PushToSync(ActionType.Insert, DataType.Master, dto.GetType().Name, dto, dto.BlackListID); });
                return dto;
            }
            return null;
        }

        public bool AddParticipants(EventParticipantDto e)
        {
          
         
            return eventParticipantsRepository.AddParticipants(e);
        }

        public async Task<IEnumerable<PiranhaEventParticipant>> GetlistParticipantsAsync()
        {
            IReadOnlyList<PiranhaEventParticipant> evt = await eventParticipantsRepository.ListAsync();
            return mapper.Map<IEnumerable<PiranhaEventParticipant>>(evt);
        }

        public bool checkExistsEmail(EventParticipantDto eventParticipant)
        {
            return eventParticipantsRepository.CheckExistsEmail(eventParticipant);
        }
    }
}
