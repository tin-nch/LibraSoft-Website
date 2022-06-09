using System;
using System.Collections.Generic;

#nullable disable

namespace LibraSoftWeb.Models
{
    public partial class PiranhaCfreasonReaching
    {
        public PiranhaCfreasonReaching()
        {
            PiranhaContactForms = new HashSet<PiranhaContactForm>();
        }

        public int ReasonReachingId { get; set; }
        public string ReasonReachingContent { get; set; }

        public virtual ICollection<PiranhaContactForm> PiranhaContactForms { get; set; }
    }
}
