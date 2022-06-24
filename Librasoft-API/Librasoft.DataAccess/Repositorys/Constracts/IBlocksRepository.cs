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

        public List<string> GetCLRTypeList();
        public List<PiranhaBlock> GetBlockListHaveParentID(string id);
        public List<PiranhaBlock> GeListColumnBlock();
        public List<PiranhaBlock> GeListColumnBlockByPageID(string id);

        public List<BlockChildVM> GetBlockChildListByParentID(string id);

    }
}
