using AutoMapper;
using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.Entities.Entities;
using Librasoft.Entities.Entities.Dtos;
using Librasoft.Services.Constract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.Services
{
    public class BlocksServices : IBlocksServices
    {
        private readonly IBlocksRepository blocksRepository;
        private readonly IBlockFieldsRepository blockFieldsRepository;
        private readonly IPageBlocksRepository pageBlocksRepository;
        private readonly IMapper mapper;

        public BlocksServices(IBlocksRepository blocksRepository, IMapper mapper, IPageBlocksRepository pageBlocksRepository, IBlockFieldsRepository blockFieldsRepository)
        {
            this.blocksRepository = blocksRepository;
            this.mapper = mapper;
            this.pageBlocksRepository = pageBlocksRepository;
            this.blockFieldsRepository = blockFieldsRepository;
        }

        //da sua
        public List<string> GetBlockCRLTypelist()
        {
            List<string> list = new List<string>();
            IEnumerable<PiranhaBlock> piranhaBlocks = new List<PiranhaBlock>();
            piranhaBlocks = (IEnumerable<PiranhaBlock>)blocksRepository.ListAsync();
            if (piranhaBlocks.Count() > 0)
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



        public async Task<IEnumerable<PiranhaBlock>> GetBlocklistAsync()
        {
            IReadOnlyList<PiranhaBlock> block = await blocksRepository.ListAsync();
            return mapper.Map<IEnumerable<PiranhaBlock>>(block);
        }

        public IEnumerable<PiranhaBlock> GetBlockListHaveParentID(string id)
        {
            IReadOnlyList<PiranhaBlock> block = blocksRepository.GetBlockListHaveParentID(id);
            return mapper.Map<IEnumerable<PiranhaBlock>>(block);
        }

        //da sua
        public IEnumerable<PiranhaBlock> GetColumnBlocklistByPageID(string id)
        {
          
            List<PiranhaBlock> piranhaBlocks = new List<PiranhaBlock>();
            List<PiranhaPageBlock> listpg = pageBlocksRepository.GetPageBlockListByPageID(id);
            if (listpg.Count > 0)
            {
                foreach (PiranhaPageBlock a in listpg)
                {
                    PiranhaBlock x = blocksRepository.GetBlockIsColumnBlock(a.Id.ToString());
                    if (x != null)
                    {
                        x.PiranhaPageBlocks = null;
                        string crltype = x.Clrtype.Split('.').Last();
                        x.Clrtype = crltype;

                        piranhaBlocks.Add(x);
                    }


                }
             
                return mapper.Map<IEnumerable<PiranhaBlock>>(piranhaBlocks);
            }
            return null;
        }

        //da sua
        public IEnumerable<PiranhaBlock> GetColumnBlocklist()
        {
            List<PiranhaBlock> rs = new List<PiranhaBlock>();
            IReadOnlyList<PiranhaBlock> piranhaBlocks = (IReadOnlyList<PiranhaBlock>)blocksRepository.ListAsync();
            if (piranhaBlocks.Count > 0)
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

        //da sua
        public IEnumerable<BlockChildVM> GetBlockChildListByParentID(string id)
        {
            List<PiranhaBlock> b = blocksRepository.GetBlockListHaveParentID(id);
            List<BlockChildVM> a = new List<BlockChildVM>();
            foreach (PiranhaBlock x in b)
            {
                PiranhaBlockField g = blockFieldsRepository.GetBlockFieldsByID(x.Id);
                PiranhaPageBlock q = pageBlocksRepository.GetPageBlockByBlockID(x.Id);
                if (g != null && q != null)
                {
                    BlockChildVM v = new BlockChildVM(x);
                    if (!String.IsNullOrEmpty(g.Value))
                    {
                        v.HtmlValue = g.Value.ToString();
                    }

                    v.SortOrder = q.SortOrder;
                    a.Add(v);
                }
            }
            List<BlockChildVM> rs = a.OrderBy(x => x.SortOrder).ToList();

            return rs;
        }


    }
}
