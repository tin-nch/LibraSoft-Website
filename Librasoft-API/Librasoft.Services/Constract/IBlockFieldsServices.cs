using Librasoft.Entities.Entities;
using Librasoft.Entities.Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Librasoft.Services.Constract
{
    public interface IBlockFieldsServices
    {

        public Task<IEnumerable<PiranhaBlockField>> GetBlockFieldlistAsync();

        public PiranhaBlockField GetBlockFieldByID(string id);

        public List<string> GetListHTMLWithImg(List<PiranhaBlock> listblk);
        public List<string> GetListHTML(List<PiranhaBlock> listblk);
        public BlockParentVM GetBlockParent();


    }
}
