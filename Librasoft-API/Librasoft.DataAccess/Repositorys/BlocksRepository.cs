using Librasoft.DataAccess.EFs;
using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.Entities.Entities;
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

        public List<PiranhaBlock> GetBlockListHaveParentID(string id)
        {
            List<PiranhaBlock> b = _context.PiranhaBlocks.Where(a => a.ParentId.ToString().Contains(id)).ToList();
            return b;

        }

        public List<string> GetCLRTypeList()
        {
            List<string> list = new List<string>();
            List<PiranhaBlock> piranhaBlocks = new List<PiranhaBlock>();
            piranhaBlocks = _context.PiranhaBlocks.ToList();
            foreach(PiranhaBlock a in piranhaBlocks)
            {
                string crltype = a.Clrtype.Split('.').Last();
                list.Add(crltype);
            }
            return list;
        }
    }
}
