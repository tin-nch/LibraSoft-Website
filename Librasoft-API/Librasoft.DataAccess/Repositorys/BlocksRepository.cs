using Librasoft.DataAccess.EFs;
using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.Entities.Entities;
using Librasoft.Entities.Entities.Dtos;
using Librasoft_API.Librasoft.DataAccess.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.DataAccess.Repositorys
{
    public class BlocksRepository : GenericRepository<PiranhaBlock>, IBlocksRepository
    {
        public BlocksRepository(PiranhaCoreContext context) : base(context)
        {
        }

      

      

        public PiranhaBlock GetBlockIsColumnBlock(string id)
        {
          return  _context.PiranhaBlocks.FirstOrDefault(b => b.Id.ToString().Trim().Contains(id) && b.Clrtype.Trim().Contains("Piranha.Extend.Blocks.ColumnBlock"));
        }
   

        public List<PiranhaBlock> GetBlockListHaveParentID(string id)
        {
            List<PiranhaBlock> b = _context.PiranhaBlocks.Where(a => a.ParentId.ToString().Contains(id)).ToList();
            if(b.Count >0)
             return b;
            return null;

        }

    }
}
