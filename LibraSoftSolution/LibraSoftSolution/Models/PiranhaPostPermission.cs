using System;
using System.Collections.Generic;

namespace LibraSoftSolution.Models
{
    public partial class PiranhaPostPermission
    {
        public Guid PostId { get; set; }
        public string Permission { get; set; } = null!;

        public virtual PiranhaPost Post { get; set; } = null!;
    }
}
