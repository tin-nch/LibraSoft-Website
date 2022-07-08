using LibraSoftSolution.ViewModels.ContentBlock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.API.ContentBlock
{
    public interface IServiceCTAPI
    {
        Task<List<ServiceCTVM>> gethtmlbysortordersWithImgService(int id);
    }
}
