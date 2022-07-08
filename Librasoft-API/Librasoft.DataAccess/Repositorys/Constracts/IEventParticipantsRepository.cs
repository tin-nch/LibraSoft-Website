using Librasoft.Entities.Entities;
using Librasoft.Entities.Entities.Dtos;
using Librasoft_API.Librasoft.DataAccess.Repositorys.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.DataAccess.Repositorys.Constracts
{
    public interface IEventParticipantsRepository : IEfRepository<PiranhaEventParticipant>
    {
        public int CheckExistsEmail(EventParticipantDto eventParticipant);
        public bool CheckRegistedEmail(EventParticipantDto eventParticipant);
        public bool AddParticipants(EventParticipantDto eventParticipant);
        public bool UpdateParticipants(EventParticipantDto eventParticipant);
        public bool AddParticipantsToEvent(EventParticipantDto eventParticipant,int idevent);
    }
}
