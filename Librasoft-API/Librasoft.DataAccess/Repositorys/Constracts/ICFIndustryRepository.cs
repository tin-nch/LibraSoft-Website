using Librasoft.Entities.Entities;
using Librasoft_API.Librasoft.DataAccess.Repositorys.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.DataAccess.Repositorys.Constracts
{
    public interface ICFIndustryRepository: IEfRepository<PiranhaCfindustry>
    {
        public PiranhaCfindustry GetIndustryById(int? id);

    }
}
