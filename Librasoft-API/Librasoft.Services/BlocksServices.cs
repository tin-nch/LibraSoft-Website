using AutoMapper;
using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.Entities.Entities;
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

        public async Task<IEnumerable<PiranhaBlock>> GetBlocklistAsync()
        {
            IReadOnlyList<PiranhaBlock> block = await blocksRepository.ListAsync();
            return mapper.Map<IEnumerable<PiranhaBlock>>(block);
        }
    }
}
