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
    public class BlockFieldsRepository : GenericRepository<PiranhaBlockField>, IBlockFieldsRepository
    {
        public BlockFieldsRepository(PiranhaCoreContext context) : base(context)
        {


        }

        public PiranhaBlockField GetBlockFieldsByID(Guid id)
        {
            return _context.PiranhaBlockFields.FirstOrDefault(a => a.Id==id);
        }

        public List<PiranhaBlockField> getListBlockFieldByBlockID(Guid blockid)
        {
            List<PiranhaBlockField> lst = _context.PiranhaBlockFields.Where(a => a.BlockId.Equals(blockid)).ToList();
            return lst;
        }


       
        public string getRootImg()
        {
            string root = (from r in _context.RootImages
                           select r.Root).FirstOrDefault();
            return root;
        }
      

  

      


    }
}
