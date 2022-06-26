using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;

namespace LibraSoftSolution.ViewModel
{
    public class ReasonReachingViewModel
    {
        [DisplayName("ReasonR")]
        public int ReasonReachingId { get; set; }
        public List<SelectListItem> ListofReason { get; set; }
    }
}
