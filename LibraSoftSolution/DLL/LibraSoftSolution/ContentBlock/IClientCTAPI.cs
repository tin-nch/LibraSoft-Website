using LibraSoftSolution.ViewModels.ContentBlock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.API.ContentBlock
{
    public interface IClientCTAPI
    {
        Task<List<Client1CTVM>> gethtmlbysortordersWithImgClient1(int id);
        Task<List<Client2CTVM>> gethtmlbysortordersWithImgClient2(int id);

    }
}
