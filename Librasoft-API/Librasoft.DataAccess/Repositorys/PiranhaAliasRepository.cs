using Librasoft_API.DataAccess.Repositorys.Constracts;
using Librasoft_API.Entities;
using System.Linq;
using Librasoft_API.Librasoft.DataAccess.Repositorys;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Librasoft_API.Librasoft.DataAccess.EFs;
using System.Collections.Generic;

namespace Librasoft_API.DataAccess.Repositorys
{
    public class PiranhaAliasRepository : GenericRepository<PiranhaAlias>, IAliasRepository
    {

      
        public PiranhaAliasRepository(PiranhaCoreContext context) : base(context)
        {

          
        }

        public IEnumerable<PiranhaAlias> GetByID(int id)
        {
            return (IEnumerable<PiranhaAlias>)_context.PiranhaAliases.FirstOrDefault(a => a.Id.Equals(id));
        }
        public List<PiranhaAlias> GetListAlias()
        {
            return _context.PiranhaAliases.ToList();
        }

    }
}
