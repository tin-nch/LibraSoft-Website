using Librasoft.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Librasoft.Services.Constract
{
    public interface IBlocksServices
    {

        public Task<IEnumerable<PiranhaBlock>> GetBlocklistAsync();
        public List<string> GetBlockCRLTypelist();
    }
}
