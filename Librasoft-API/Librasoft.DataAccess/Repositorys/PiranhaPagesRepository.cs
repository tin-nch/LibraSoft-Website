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

        public void getPageWithHomeTitle()
        {
            throw new NotImplementedException();
        }


        //public virtual async Task<IReadOnlyList<PiranhaPage>> getPageWithHomeTitle(Expression<Func<PiranhaPage, bool>> filter = null, Func<IQueryable<PiranhaPage>, IOrderedQueryable<PiranhaPage>> orderBy = null)
        //{
        //    IQueryable<PiranhaPage> source = (IQueryable<PiranhaPage>)_context.PiranhaPages.Where(a => a.NavigationTitle.Contains("Home")).ToList();
        //    if (filter != null)
        //    {
        //        source = source.Where(filter);
        //    }

        //    if (orderBy != null)
        //    {
        //        return await orderBy(source).to();
        //    }

        //    return await source.ToListAsync();
        //}
    }
}
