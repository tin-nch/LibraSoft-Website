using Librasoft.DataAccess.EFs;
using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.Entities.Entities;

using Librasoft.DataAccess.EFs;
using Librasoft_API.Librasoft.DataAccess.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Librasoft.DataAccess.Repositorys
{
    public class PiranhaPagesRepository : GenericRepository<PiranhaPage>, IPagesRepository
    {
        public PiranhaPagesRepository(PiranhaCoreContext context) : base(context)
        {
        }

        public  List<PiranhaPage> GetPagesListWithHomeTitle()
        {
            List<PiranhaPage> source =_context.PiranhaPages.Where(a => a.NavigationTitle.Contains("Home")).ToList();
       

            return  source;
        }

      
    }
}
