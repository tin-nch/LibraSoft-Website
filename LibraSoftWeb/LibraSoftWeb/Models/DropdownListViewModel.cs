using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraSoftWeb.Models
{
    public class DropdownListViewModel
    {
        [DisplayName("Piranha_CFIndustry")]
        public int IndustyId { get; set; }
        [DisplayName("Piranha_CFCountry")]
        public int CountryId { get; set; }
        [DisplayName("Piranha_CFReasonReaching")]
        public int ReasonReachingId { get; set; }
    }
}
