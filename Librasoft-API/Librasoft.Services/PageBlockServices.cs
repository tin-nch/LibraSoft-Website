using AutoMapper;
using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.Services.Constract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.Services
{
    public class PageBlockServices : IPageBlocksServices
    {

        private readonly IPageBlocksRepository pageblocksRepository;
        private readonly IMapper mapper;

        public PageBlockServices(IPageBlocksRepository pageblocksRepository, IMapper mapper)
        {
            this.pageblocksRepository = pageblocksRepository;
            this.mapper = mapper;
        }

        public string GetBlockIDBySortOrder(int order)
        {
           return pageblocksRepository.GetBlockIDBySortOrder(order);
        }
    }
}
