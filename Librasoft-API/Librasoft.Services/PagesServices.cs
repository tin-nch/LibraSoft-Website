using AutoMapper;
using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.Entities.Entities;
using Librasoft.Services.Constract;
using Librasoft_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.Services
{
    public class PagesServices: IPagesServices
    {

        private readonly IPagesRepository pagesRepository;
        private readonly IMapper mapper;

      public PagesServices(IPagesRepository pagesRepository, IMapper mapper)
        {
            this.pagesRepository = pagesRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PiranhaPage>> GetPagesListAsync()
        {
            IReadOnlyList<PiranhaPage> pages = await pagesRepository.ListAsync();
            return mapper.Map<IEnumerable<PiranhaPage>>(pages);
        }

        public  IEnumerable<PiranhaPage> GetPagesListWithHomeTitle()
        {
            IReadOnlyList<PiranhaPage> pages =  pagesRepository.GetPagesListWithHomeTitle();
            return mapper.Map<IEnumerable<PiranhaPage>>(pages);
        }
    }
}
