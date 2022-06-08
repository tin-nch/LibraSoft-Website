using System.Collections.Generic;
using System.Threading.Tasks;
using Librasoft.Entities.Entities.Dtos;
using Librasoft_API.Entities;

namespace Librasoft.Services.Constract
{
    public interface IAliases
    {
       List<PiranhaAlias> GetListAlias();

    }
}
