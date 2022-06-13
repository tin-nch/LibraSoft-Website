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
    public class PageRevisionsServices : IPageRevisionsServices
    {

        private readonly IPageRevisionsRepository pagesRevisionRepository;
        private readonly IMapper mapper;

        public PageRevisionsServices(IPageRevisionsRepository pagesRevisionRepository, IMapper mapper)
        {
            this.pagesRevisionRepository = pagesRevisionRepository;
            this.mapper = mapper;
        }

       
     

       public async Task<IEnumerable<PiranhaPageRevision>> GetPagesRevisionListAsync()
        {
            IReadOnlyList<PiranhaPageRevision> contactForms = await pagesRevisionRepository.ListAsync();
            return mapper.Map<IEnumerable<PiranhaPageRevision>>(contactForms);
        }
    }
}
