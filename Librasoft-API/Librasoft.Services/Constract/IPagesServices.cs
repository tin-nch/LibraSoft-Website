using Librasoft.Entities.Entities;
using Librasoft_API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Librasoft.Services.Constract
{
    public interface IPagesServices
    {


        public Task<IEnumerable<PiranhaPage>> GetPagesListAsync();
    }
}
