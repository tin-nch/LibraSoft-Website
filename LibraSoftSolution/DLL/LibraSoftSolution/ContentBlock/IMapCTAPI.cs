using LibraSoftSolution.ViewModels.ContentBlock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.API.ContentBlock
{
    public interface IMapCTAPI
    {
        Task<List<MapCTVM>> gethtmlbysortordersWithImgMap(int id);
    }
}
