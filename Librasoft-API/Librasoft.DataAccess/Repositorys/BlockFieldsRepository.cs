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
    public class BlockFieldsRepository : GenericRepository<PiranhaBlockField>, IBlockFieldsRepository
    {
        public BlockFieldsRepository(PiranhaCoreContext context) : base(context)
        {


        }

        public PiranhaBlockField GetBlockFieldsByID(string id)
        {
            return _context.PiranhaBlockFields.FirstOrDefault(a => a.Id.ToString().Contains(id));
        }

        public List<string> GetListHTML(List<PiranhaBlock> listblk)
        {
            List<string> list = new List<string>();

            string root = _context.RootImages.FirstOrDefault().ToString();

            foreach (PiranhaBlock block in listblk)
            {
                List<PiranhaBlockField> lst = _context.PiranhaBlockFields.Where(a => a.BlockId.Equals(block.Id)).ToList();
                foreach(PiranhaBlockField f in lst)
                {
                    string a = f.Value;
                    string prefix = a.Substring(0, a.IndexOf("upload"));
                    string postfix = a.Substring(a.IndexOf("upload"));
                    string res = prefix + root + postfix;
                    list.Add(f.Value);
                }    
               
            }
            return list;
        }
    }
}
