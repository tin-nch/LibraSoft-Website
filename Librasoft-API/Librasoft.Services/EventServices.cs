using AutoMapper;
using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.Entities.Entities;
using Librasoft.Services.Constract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.Services
{
    public class EventServices: IEventServices
    {
        private readonly IEventRepository eventRepository;

        private readonly IMapper mapper;

        public EventServices(IEventRepository eventRepository, IMapper mapper)
        {
            this.eventRepository = eventRepository;
            this.mapper = mapper;
        }
        public async Task<PiranhaEvent> AddEventAsync(PiranhaEvent e)
        {
            PiranhaEvent add = await eventRepository.AddAsync(mapper.Map<PiranhaEvent>(e));
            if (add != null)
            {
                PiranhaEvent dto = mapper.Map<PiranhaEvent>(add);

                // Task.Run(() => { syncCommunication.PushToSync(ActionType.Insert, DataType.Master, dto.GetType().Name, dto, dto.BlackListID); });
                return dto;
            }
            return null;
        }

        public async Task<IEnumerable<PiranhaEvent>> GetListEvents()
        {
            IReadOnlyList<PiranhaEvent> evt = await eventRepository.ListAsync();
            return mapper.Map<IEnumerable<PiranhaEvent>>(evt);
         
        }
    }
}
