using LibraSoftSolution.ViewModels.ContentBlock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.API.ContentBlock
{
    public interface IPartnerCTAPI
    {
        Task<List<PartnerCTVM>> gethtmlbysortordersWithImgPartner(int id);
    }
}
