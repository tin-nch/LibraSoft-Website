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

        private readonly IMapper mapper;

        public BlocksServices(IBlocksRepository blocksRepository, IMapper mapper)
        {
            this.blocksRepository = blocksRepository;
            this.mapper = mapper;
        }

        public List<string> GetBlockCRLTypelist()
        {
            return blocksRepository.GetCLRTypeList();
        }



        public async Task<IEnumerable<PiranhaBlock>> GetBlocklistAsync()
        {
            IReadOnlyList<PiranhaBlock> block = await blocksRepository.ListAsync();
            return mapper.Map<IEnumerable<PiranhaBlock>>(block);
        }

        public IEnumerable<PiranhaBlock> GetBlockListHaveParentID(string id)
        {
            IReadOnlyList<PiranhaBlock> block =  blocksRepository.GetBlockListHaveParentID(id);
            return mapper.Map<IEnumerable<PiranhaBlock>>(block);
        }

        public IEnumerable<PiranhaBlock> GetColumnBlocklistByPageID(string id)
        {
            IReadOnlyList<PiranhaBlock> block = blocksRepository.GeListColumnBlockByPageID(id);
            return mapper.Map<IEnumerable<PiranhaBlock>>(block);
        }

        public IEnumerable<PiranhaBlock> GetColumnBlocklist()
        {

            IReadOnlyList<PiranhaBlock> block = blocksRepository.GeListColumnBlock();
            return mapper.Map<IEnumerable<PiranhaBlock>>(block);
            
        }

        public IEnumerable<BlockChildVM> GetBlockChildListByParentID(string id)
        {
            IReadOnlyList<BlockChildVM> block = blocksRepository.GetBlockChildListByParentID(id);
            if (block == null)
                return null;
            return mapper.Map<IEnumerable<BlockChildVM>>(block);
        }

     
    }
}
