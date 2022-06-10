using Librasoft_API.Librasoft.DataAccess.Repositorys;
using Librasoft_API.Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft_API.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using Librasoft.Entities.Entities;

namespace Librasoft_API.DataAccess.Repositorys.Constracts
{
    public interface IAliasRepository: IEfRepository<PiranhaAlias>
    {
        IEnumerable<PiranhaAlias> GetByID(int id);
        List<PiranhaAlias> GetListAlias();

    }
}
