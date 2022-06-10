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
        public PagesServices(IPagesRepository pagesRepository)
        {
            this.pagesRepository = pagesRepository;
        }

       

        public List<PiranhaPage> GetListPages()
        {
            return pagesRepository.GetListPages();
        }
        public List<string> GetListNavigationTitle()
        {
            return pagesRepository.GetListTitle();
          
        }
    }
}
