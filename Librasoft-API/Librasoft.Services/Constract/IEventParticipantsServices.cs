using Librasoft.Entities.Entities;
using Librasoft.Entities.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.Services.Constract
{
    public interface IEventParticipantsServices
    {
        public Task<IEnumerable<PiranhaEventParticipant>> GetlistParticipantsAsync();
        public Task<PiranhaEventParticipant> AddParticipantsAsync(PiranhaEventParticipant e);
        public bool checkExistsEmail(EventParticipantDto eventParticipant);
        public bool AddParticipants(EventParticipantDto e);
    }
}
