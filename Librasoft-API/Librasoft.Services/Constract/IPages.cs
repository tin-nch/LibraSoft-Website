using Librasoft_API.Entities;
using System.Collections.Generic;

namespace Librasoft.Services.Constract
{
    public interface IPages
    {

      public  List<PiranhaPage> GetListPages();
        public List<string> GetListNavigationTitle();
    }
}
