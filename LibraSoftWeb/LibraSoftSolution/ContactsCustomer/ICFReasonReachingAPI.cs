﻿using LibraSoftSolution.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.API.Contacts_Customer
{
    public interface ICFReasonReachingAPI
    {
        Task<List<CFReasonReachingVM>> GetReasonReaching();
    }
}