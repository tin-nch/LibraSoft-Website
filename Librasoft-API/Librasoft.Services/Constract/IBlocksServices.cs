using Librasoft.Entities.Entities;
using Librasoft.Entities.Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Librasoft.Services.Constract
{
    public interface IBlocksServices
    {

        public Task<IEnumerable<PiranhaBlock>> GetBlocklistAsync();
        public List<string> GetBlockCRLTypelist();
        public IEnumerable<PiranhaBlock> GetColumnBlocklist();
        public IEnumerable<PiranhaBlock> GetColumnBlocklistByPageID(string id);
        public IEnumerable<PiranhaBlock> GetBlockListHaveParentID(string id);

        public IEnumerable<BlockChildVM> GetBlockChildListByParentID(string id);
    }
}
