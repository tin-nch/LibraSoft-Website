using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace LibraSoftWeb.Models
{
    public class ViewModel
    {
        public PiranhaPage Page { get; set; }
        public PiranhaPageBlock PageBlock { get; set; }
        public PiranhaBlock Block { get; set; }
        public PiranhaBlockField BlockField { get; set; }
    }
}
