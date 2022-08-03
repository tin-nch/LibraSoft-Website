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
        public  PiranhaEventParticipant GetExistsEmail(EventParticipantDto eventParticipant);
        public PiranhaEvent GetRegistedEvent(EventParticipantDto eventParticipant);
        public bool AddParticipants(EventParticipantDto eventParticipant);
        public bool UpdateParticipants(EventParticipantDto eventParticipant);
        public bool AddParticipantsToEvent(EventParticipantDto eventParticipant,int idevent);

        public bool CheckOTP(int  otp);
    }
}
