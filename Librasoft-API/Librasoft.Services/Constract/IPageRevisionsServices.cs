using Librasoft.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Librasoft.Services.Constract
{
    public interface IPageRevisionsServices
    {

        public Task<IEnumerable<PiranhaPageRevision>> GetPagesRevisionListAsync();
    }
}
