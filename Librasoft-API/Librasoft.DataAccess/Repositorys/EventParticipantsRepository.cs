using Librasoft.DataAccess.EFs;
using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.Entities.Entities;
using Librasoft.Entities.Entities.Dtos;
using Librasoft_API.Librasoft.DataAccess.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.DataAccess.Repositorys
{
    public class EventParticipantsRepository : GenericRepository<PiranhaEventParticipant>, IEventParticipantsRepository
    {
        public EventParticipantsRepository(PiranhaCoreContext context) : base(context)
        {


        }
        public bool CheckExistsEmail(EventParticipantDto eventParticipant)
        {
            PiranhaEventParticipant a = _context.PiranhaEventParticipants.FirstOrDefault(x => x.Email.Trim().Equals(eventParticipant.Email.Trim()));
            if (a != null)
                return true;
            return false;
        }

        public bool AddParticipants(EventParticipantDto eventParticipant)
        {
            try
            {
                PiranhaEventParticipant x = new PiranhaEventParticipant();
                PiranhaEvent e = _context.PiranhaEvents.FirstOrDefault(b => b.Id.Equals(eventParticipant.IDEvent));
                x.Id = eventParticipant.Id;
                x.FullName = eventParticipant.FullName;
                x.Phone = eventParticipant.Phone;
                x.Position = eventParticipant.Position;
                x.Email = eventParticipant.Email;
                x.CompanyName = eventParticipant.CompanyName;
                x.IdEvents.Add(e);
                _context.PiranhaEventParticipants.Add(x);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }




        }

        public bool CheckRegistedEmail(EventParticipantDto eventParticipant)
        {
            PiranhaEventParticipant a = _context.PiranhaEventParticipants.FirstOrDefault(x => x.Email.Trim().Equals(eventParticipant.Email.Trim()));

            PiranhaEvent e = a.IdEvents.FirstOrDefault(b => b.Id.Equals(eventParticipant.IDEvent));
            if (e != null)
                return true;
       
            e = _context.PiranhaEvents.FirstOrDefault(v => v.Id.Equals(eventParticipant.IDEvent));
            a.IdEvents.Add(e);
            try
            {
                _context.SaveChanges();
                return false; 
            }
            catch
            {
                return true;
            }
          
            
           
           
        }
    }
}
