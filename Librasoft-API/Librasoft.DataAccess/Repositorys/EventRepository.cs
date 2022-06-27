using Librasoft.DataAccess.EFs;
using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.Entities.Entities;
using Librasoft_API.Librasoft.DataAccess.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.DataAccess.Repositorys
{
    public class EventRepository : GenericRepository<PiranhaEvent>, IEventRepository
    {
        public EventRepository(PiranhaCoreContext context) : base(context)
        {

        }

        public PiranhaEvent GetPiranhaEventByID(string id)
        {
            PiranhaEvent a = _context.PiranhaEvents.FirstOrDefault(b => b.Id.Equals(id));
            if (a != null)
                return a;
            return null;
        }
    }
}
