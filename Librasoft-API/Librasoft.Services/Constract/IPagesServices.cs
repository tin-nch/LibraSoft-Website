using Librasoft.Entities.Entities;
using Librasoft_API.Entities;
using System.Collections.Generic;

namespace Librasoft.Services.Constract
{
    public interface IPagesServices
    {

      public  List<PiranhaPage> GetListPages();
        public List<string> GetListNavigationTitle();
    }
}
