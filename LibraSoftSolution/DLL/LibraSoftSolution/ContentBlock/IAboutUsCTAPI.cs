using LibraSoftSolution.ViewModels.ContentBlock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.API.ContentBlock
{
    public interface IAboutUsCTAPI
    {
        Task<List<About1CTVM>> gethtmlbysortordersWithImgAboutUs1(int id);
        Task<List<About3CTVM>> gethtmlbysortordersWithImgAboutUs3(int id);

    }
}
