using System;
using System.Collections.Generic;

namespace LibraSoftCMS.Models
{
    public partial class PiranhaPagePermission
    {
        public Guid PageId { get; set; }
        public string Permission { get; set; }

        public virtual PiranhaPage Page { get; set; }
    }
}
