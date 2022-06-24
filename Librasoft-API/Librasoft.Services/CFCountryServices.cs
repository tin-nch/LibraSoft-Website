using AutoMapper;
using Librasoft.DataAccess.Repositorys;
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
    public class CFCountryServices:ICFCountryServices
    {

        private readonly ICFCountryRepository cfCountryRepository;

        private readonly IMapper mapper;

        public CFCountryServices(ICFCountryRepository cfCountryRepository, IMapper mapper)
        {
            this.cfCountryRepository = cfCountryRepository;
            this.mapper = mapper;
        }

        public PiranhaCfcountry GetCountryById(int? id)
        {
            return cfCountryRepository.GetCountryById(id);
        }

        public async Task<IEnumerable<PiranhaCfcountry>> GetCountrylistAsync()
        {
            IReadOnlyList<PiranhaCfcountry> cfcountries = await cfCountryRepository.ListAsync();
            return mapper.Map<IEnumerable<PiranhaCfcountry>>(cfcountries);
        }
    }
}
