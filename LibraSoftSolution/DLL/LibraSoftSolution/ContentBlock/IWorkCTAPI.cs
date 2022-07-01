using LibraSoftSolution.ViewModels.ContentBlock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.API.ContentBlock
{
    public interface IWorkCTAPI
    {
        Task<List<WorkCTVM>> gethtmlbysortordersWithImgWork(int id);
    }
}
