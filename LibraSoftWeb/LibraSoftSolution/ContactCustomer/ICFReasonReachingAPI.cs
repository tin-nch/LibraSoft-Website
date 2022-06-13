using LibraSoftSolution.ViewModels;
using LibraSoftSolution.ViewModels.ContactForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.API.ContactCustomer
{
    public interface ICFReasonReachingAPI
    {
        Task<List<CFReasonReachingVM>> GetReasonReaching();
    }
}
