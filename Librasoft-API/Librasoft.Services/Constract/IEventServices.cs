using Librasoft.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.Services.Constract
{
    public interface IEventServices
    {
        public Task<IEnumerable<PiranhaEvent>> GetListEvents();
        public  Task<PiranhaEvent> AddEventAsync(PiranhaEvent e);
        public PiranhaEvent GetEventByID(int id);
    }
}
