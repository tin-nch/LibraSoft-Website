using System;
using System.Collections.Generic;

namespace LibraSoftSolution.Models
{
    public partial class PiranhaPagePermission
    {
        public Guid PageId { get; set; }
        public string Permission { get; set; } = null!;

        public virtual PiranhaPage Page { get; set; } = null!;
    }
}
