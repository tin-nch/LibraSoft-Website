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
    public class CFIndustryServices : ICFIndustryServices
    {
        private readonly ICFIndustryRepository cFIndustryRepository;

        private readonly IMapper mapper;
        public CFIndustryServices(ICFIndustryRepository cFIndustryRepository, IMapper mapper)
        {
            this.cFIndustryRepository = cFIndustryRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PiranhaCfindustry>> GetCfIndustryListAsync()
        {
            IReadOnlyList<PiranhaCfindustry> cfindustry = await cFIndustryRepository.ListAsync();
            return mapper.Map<IEnumerable<PiranhaCfindustry>>(cfindustry);
        }

       
    }
}
