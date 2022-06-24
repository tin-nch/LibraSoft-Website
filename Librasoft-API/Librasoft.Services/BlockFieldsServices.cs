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

        public PiranhaBlockField GetBlockFieldByID(string id)
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
            return blockFieldsRepository.GetListHTML(listblk);
        }

      



        public List<string> GetListHTMLWithImg(List<PiranhaBlock> listblk)
        {
            return blockFieldsRepository.GetListHTMLWithImg(listblk);
        }

      
    }
}
