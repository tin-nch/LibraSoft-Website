using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.Services.Constract
{
    public interface ICFIndustryServices
    {
        public Task<IEnumerable<PiranhaCfindustry>> GetCfIndustryListAsync();
        public PiranhaCfindustry GetIndustryById(int? id);

    }
}
