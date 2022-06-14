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
    public class CFReasonReachingServices : ICFReasonReachingServices
    {

        private readonly ICFReasonReachingRepository cFReasonReachingRepository;

        private readonly IMapper mapper;
        public CFReasonReachingServices(ICFReasonReachingRepository cFReasonReachingRepository, IMapper mapper)
        {
            this.cFReasonReachingRepository = cFReasonReachingRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PiranhaCfreasonReaching>> GetReasonReachinglistAsync()
        {
            IReadOnlyList<PiranhaCfreasonReaching> cfcountries = await cFReasonReachingRepository.ListAsync();
            return mapper.Map<IEnumerable<PiranhaCfreasonReaching>>(cfcountries);
        }

        public PiranhaCfreasonReaching GetRRById(int? id)
        {
            return cFReasonReachingRepository.getRRbyId(id);
        }
    }
}
