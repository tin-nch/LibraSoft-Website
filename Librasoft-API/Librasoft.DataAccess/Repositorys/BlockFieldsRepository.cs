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

        public PiranhaBlockField GetBlockFieldsByID(string id)
        {
            return _context.PiranhaBlockFields.FirstOrDefault(a => a.Id.ToString().Contains(id));
        }

        public List<string> GetAllHTML(List<PiranhaBlock> listblk)
        {
            List<string> list = new List<string>();
            foreach (PiranhaBlock block in listblk)
            {
                List<PiranhaBlockField> lst = _context.PiranhaBlockFields.Where(a => a.BlockId.Equals(block.Id)).ToList();
                foreach (PiranhaBlockField f in lst)
                {
                  
                    list.Add(f.Value);
                }
            }
            return list;
        }

        public List<string> GetListHTML(List<PiranhaBlock> listblk)
        {
            List<string> list = new List<string>();
            foreach (PiranhaBlock block in listblk)
            {
                List<PiranhaBlockField> lst = _context.PiranhaBlockFields.Where(a => a.BlockId.Equals(block.Id)).ToList();
                foreach (PiranhaBlockField f in lst)
                {
                    if (f.Value.Contains("/upload"))
                    {
                        continue;
                    }
                    list.Add(f.Value);
                }
            }
            return list;
        }

      

        public List<string> GetListHTMLWithImg(List<PiranhaBlock> listblk)
        {
            List<string> list = new List<string>();

            string root = (from r in _context.RootImages
                          select r.Root).FirstOrDefault();
         

            foreach (PiranhaBlock block in listblk)
            {
                List<PiranhaBlockField> lst = _context.PiranhaBlockFields.Where(a => a.BlockId.Equals(block.Id)).ToList();
                foreach (PiranhaBlockField s in lst)
                {
                    List<PiranhaPageBlock> listpageblock = new List<PiranhaPageBlock>();
                    foreach(PiranhaPageBlock k in listpageblock)
                    {
                        if (k.BlockId == s.BlockId)
                            continue;
                        else lst.Remove(s);
                    }    
                }    
                foreach(PiranhaBlockField f in lst)
                {
                    if (!f.Value.Contains("/upload"))
                    {
                        continue;
                    }
                    string a = f.Value;
                    string prefix = a.Substring(0, a.IndexOf("/upload"));
                    string postfix = a.Substring(a.IndexOf("/upload"));
                    string res = prefix + root + postfix;
                    list.Add(res);
                }    
            }
            return list;
        }

        //public List<BlockVM> GetListBlockChild(PiranhaBlock parent)
        //{

        //    List<BlockVM> blockVMs = new List<BlockVM>();
        //    foreach (PiranhaBlock block in listblkchild)
        //    {
        //        BlockVM a = new BlockVM();
        //            a.Id = block.Id;
        //        List<PiranhaBlockField> blockFields = _context.PiranhaBlockFields.Where(a=>a.Id.Equals(block.Id)).ToList();
        //        foreach(PiranhaBlockField x in blockFields)
        //        {
        //            a.HtmlValue.Add(x.Value);
        //        }    
                

        //        blockVMs.Add(a);
                
                

        //    }


        //    return blockVMs;
        //}


    }
}
