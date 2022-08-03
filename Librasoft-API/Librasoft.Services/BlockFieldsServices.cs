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
    public class BlockFieldsServices : IBlockFieldsServices
    {
        private readonly IBlockFieldsRepository blockFieldsRepository;

        private readonly IMapper mapper;

        public BlockFieldsServices(IBlockFieldsRepository blockFieldsRepository, IMapper mapper)
        {
            this.blockFieldsRepository = blockFieldsRepository;
            this.mapper = mapper;
        }

        public PiranhaBlockField GetBlockFieldByID(Guid id)
        {
            return blockFieldsRepository.GetBlockFieldsByID(id);
        }

        public async Task<IEnumerable<PiranhaBlockField>> GetBlockFieldlistAsync()
        {
            IReadOnlyList<PiranhaBlockField> blockFields = await blockFieldsRepository.ListAsync();
            return mapper.Map<IEnumerable<PiranhaBlockField>>(blockFields);
        }

        public BlockParentVM GetBlockParent()
        {
            throw new NotImplementedException();
        }

        public List<string> GetListHTML(List<PiranhaBlock> listblk)
        {
            List<string> list = new List<string>();
            foreach (PiranhaBlock block in listblk)
            {
                List<PiranhaBlockField> lst = blockFieldsRepository.getListBlockFieldByBlockID(block.Id);
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

            string root = blockFieldsRepository.getRootImg();


            foreach (PiranhaBlock block in listblk)
            {
                List<PiranhaBlockField> lst = blockFieldsRepository.getListBlockFieldByBlockID(block.Id);
                foreach (PiranhaBlockField s in lst)
                {
                    List<PiranhaPageBlock> listpageblock = new List<PiranhaPageBlock>();
                    foreach (PiranhaPageBlock k in listpageblock)
                    {
                        if (k.BlockId == s.BlockId)
                            continue;
                        else lst.Remove(s);
                    }
                }
                foreach (PiranhaBlockField f in lst)
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

      
    }
}
