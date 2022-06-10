
using Librasoft.Entities.Entities.Dtos;
using Librasoft.Entities.Entities;
using Librasoft.Services.Constract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Librasoft_API.Entities;
using Librasoft_API.DataAccess.Repositorys.Constracts;
using Librasoft_API.DataAccess.Repositorys;

namespace Librasoft.Services
{
    public class AliasService : IAliasesServices
    {

        private readonly IAliasRepository aliasRepository;
        public AliasService(IAliasRepository aliasRepository)
        {
            this.aliasRepository = aliasRepository;
        }

        public List<PiranhaAlias> GetListAlias()
        {
            return aliasRepository.GetListAlias();
        }
    }
}
