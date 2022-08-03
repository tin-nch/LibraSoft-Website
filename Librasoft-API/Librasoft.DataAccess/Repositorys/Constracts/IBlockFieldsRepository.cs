using Librasoft.Entities.Entities;
using Librasoft.Entities.Entities.Dtos;
using Librasoft_API.Librasoft.DataAccess.Repositorys.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.DataAccess.Repositorys.Constracts
{
    public interface IBlockFieldsRepository: IEfRepository<PiranhaBlockField>
    {
        public string getRootImg();
        public List<PiranhaBlockField> getListBlockFieldByBlockID(Guid blockid);
        public PiranhaBlockField GetBlockFieldsByID(Guid id);
       // public List<string> GetListHTMLWithImg(List<PiranhaBlock> listblk);
        //public List<string> GetListHTML(List<PiranhaBlock> listblk);

       




    }
}
