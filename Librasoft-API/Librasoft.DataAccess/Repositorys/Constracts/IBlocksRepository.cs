using Librasoft.Entities.Entities;
using Librasoft.Entities.Entities.Dtos;
using Librasoft_API.Librasoft.DataAccess.Repositorys.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.DataAccess.Repositorys.Constracts
{
    public interface IBlocksRepository: IEfRepository<PiranhaBlock>
    {

      
        public PiranhaBlock GetBlockIsColumnBlock(string id);
        public List<PiranhaBlock> GetBlockListHaveParentID(string id);
  
  

 

    }
}
