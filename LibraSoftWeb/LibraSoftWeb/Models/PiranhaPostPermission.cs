using System;
using System.Collections.Generic;

#nullable disable

namespace LibraSoftWeb.Models
{
    public partial class PiranhaPostPermission
    {
        public Guid PostId { get; set; }
        public string Permission { get; set; }

        public virtual PiranhaPost Post { get; set; }
    }
}
