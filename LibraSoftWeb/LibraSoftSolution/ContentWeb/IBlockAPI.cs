using LibraSoftSolution.ViewModels.ContentWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.API.ContentWeb
{
    public interface IBlockAPI
    {
        Task<List<BlocksVM>> GetListBlocks();
        Task<List<string>> GetListBlocksCLRType();
        Task<List<BlockFieldsVM>> GetListBlocksFields();
        Task<List<PagesVM>> GetListPages();
        Task<List<PageRevisionsVM>> GetListPageRevisions();
    }
}
