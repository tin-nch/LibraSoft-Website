using LibraSoftSolution.ViewModels.ContentWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.API
{
    public interface INavigationTitleAPI
    {
        Task<List<NavigationTitleVM>> GetTitle();
    }
}
