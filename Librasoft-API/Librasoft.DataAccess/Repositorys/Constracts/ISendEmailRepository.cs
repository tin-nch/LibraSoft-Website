using Librasoft.Entities.Entities;
using Librasoft.Entities.Entities.Dtos;
using Librasoft_API.Librasoft.DataAccess.Repositorys;
using Librasoft_API.Librasoft.DataAccess.Repositorys.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.DataAccess.Repositorys.Constracts
{
    public interface ISendEmailRepository : IEfRepository<AdminAccount>
    {
        AdminAccount GetVirtualEmail();
        PiranhaApplicationForm GetPiranhaApplicationForm(PiranhaApplicationForm a);

        public int GenerateOPTCode();
        
        
       
    }
}
