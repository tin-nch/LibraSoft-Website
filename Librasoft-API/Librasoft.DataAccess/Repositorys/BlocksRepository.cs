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

        public List<PiranhaBlock> GeListColumnBlock()
        {
            List<PiranhaBlock> rs = new List<PiranhaBlock>();
            List<PiranhaBlock> piranhaBlocks = new List<PiranhaBlock>();
            piranhaBlocks = _context.PiranhaBlocks.ToList();
            if(piranhaBlocks.Count>0)
            {
                foreach (PiranhaBlock a in piranhaBlocks)
                {
                    string crltype = a.Clrtype.Split('.').Last();
                    if (crltype.Trim().Equals("ColumnBlock"))
                    {
                        a.Clrtype = crltype;
                        rs.Add(a);
                    }


                }
                return rs;
            }

            return null;
          
        }

        public List<PiranhaBlock> GeListColumnBlockByPageID(string id)
        {
           
             List<PiranhaBlock> piranhaBlocks = new List<PiranhaBlock>();
            List<PiranhaPageBlock> listpg = _context.PiranhaPageBlocks.Where(a => a.PageId.ToString().Trim().Contains(id)).OrderBy(a=>a.SortOrder).ToList();
          if(listpg.Count > 0)
            {
                foreach (PiranhaPageBlock a in listpg)
                {
                    PiranhaBlock x = _context.PiranhaBlocks.FirstOrDefault(b => b.Id.ToString().Trim().Contains(a.BlockId.ToString()) && b.Clrtype.Trim().Contains("Piranha.Extend.Blocks.ColumnBlock"));
                    if (x != null)
                    {
                        x.PiranhaPageBlocks = null;
                        string crltype = x.Clrtype.Split('.').Last();
                        x.Clrtype = crltype;

                        piranhaBlocks.Add(x);
                    }


                }
                return piranhaBlocks;
              
            }


            return null;
        }

        public List<BlockChildVM> GetBlockChildListByParentID(string id)
        {
            List<PiranhaBlock> b = _context.PiranhaBlocks.Where(a => a.ParentId.ToString().Contains(id)).ToList();

            if(b.Count > 0)
            {
                List<BlockChildVM> a = new List<BlockChildVM>();
                foreach (PiranhaBlock x in b)
                {
                    PiranhaBlockField g = _context.PiranhaBlockFields.FirstOrDefault(j => j.BlockId.Equals(x.Id));
                    PiranhaPageBlock q = _context.PiranhaPageBlocks.FirstOrDefault(m => m.BlockId.Equals(x.Id));
                    if (g != null && q != null)
                    {
                        BlockChildVM v = new BlockChildVM(x);
                        v.HtmlValue = g.Value.ToString();
                        v.SortOrder = q.SortOrder;
                        a.Add(v);
                    }



                }

                List<BlockChildVM> rs = a.OrderBy(x => x.SortOrder).ToList();

                return rs;
            }
            return null;
        
        }

        public List<PiranhaBlock> GetBlockListHaveParentID(string id)
        {
            List<PiranhaBlock> b = _context.PiranhaBlocks.Where(a => a.ParentId.ToString().Contains(id)).ToList();
            if(b.Count >0)
            return b;
            return null;

        }

        public List<string> GetCLRTypeList()
        {
            List<string> list = new List<string>();
            List<PiranhaBlock> piranhaBlocks = new List<PiranhaBlock>();
            piranhaBlocks = _context.PiranhaBlocks.ToList();
            if(piranhaBlocks.Count > 0)
            {
                foreach (PiranhaBlock a in piranhaBlocks)
                {
                    string crltype = a.Clrtype.Split('.').Last();
                    list.Add(crltype);
                }
                return list;
            }
            return null;
           
        }
    }
}
