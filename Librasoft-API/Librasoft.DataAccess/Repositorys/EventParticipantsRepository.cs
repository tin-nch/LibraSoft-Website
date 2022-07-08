using Librasoft.DataAccess.EFs;
using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.Entities.Entities;
using Librasoft.Entities.Entities.Dtos;
using Librasoft_API.Librasoft.DataAccess.Repositorys;
using Microsoft.EntityFrameworkCore;
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
        public int CheckExistsEmail(EventParticipantDto eventParticipant)
        {
            PiranhaEventParticipant a = _context.PiranhaEventParticipants.FirstOrDefault(x => x.Email.Trim().Equals(eventParticipant.Email.Trim()));
            if (a != null)
            {
                if (String.IsNullOrEmpty(a.FullName))
                    return 0;
                    return 1;
            }    
               
           
                return -1;    
           
        }

        public bool AddParticipantsToEvent(EventParticipantDto eventParticipant,int idevent)
        {
            try
            {
                PiranhaEventParticipant x = _context.PiranhaEventParticipants.FirstOrDefault(a => a.Email.Equals(eventParticipant.Email));
                PiranhaEvent e = _context.PiranhaEvents.FirstOrDefault(b => b.Id.Equals(idevent));
             
                x.IdEvents.Add(e);
                _context.PiranhaEventParticipants.Update(x);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }




        }


        public bool AddParticipants(EventParticipantDto eventParticipant)
        {
            try
            {
                PiranhaEventParticipant x = new PiranhaEventParticipant();
                x.Id = eventParticipant.Id;
                x.FullName = eventParticipant.FullName;
                x.Phone = eventParticipant.Phone;
                x.Position = eventParticipant.Position;
                x.Email = eventParticipant.Email;
                x.CompanyName = eventParticipant.CompanyName;
             
                _context.PiranhaEventParticipants.Add(x);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }




        }

        public bool UpdateParticipants(EventParticipantDto eventParticipant)
        {
            try
            {
                PiranhaEventParticipant x = _context.PiranhaEventParticipants.Where(a => a.Email.Equals(eventParticipant.Email)).First();
                
                if(x!=null)
                {
                    PiranhaEvent e = _context.PiranhaEvents.FirstOrDefault(a => a.Id.Equals(eventParticipant.IDEvent));
                    x.FullName = eventParticipant.FullName;
                    x.Phone = eventParticipant.Phone;
                    x.Position = eventParticipant.Position;

                    x.CompanyName = eventParticipant.CompanyName;
                    x.IdEvents.Clear();
                    _context.Update(x);
                    _context.SaveChanges();
                  
                 

                    return true;
                }

                return false;
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

            return false;
        }
    }
}
