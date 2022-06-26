using System;
using System.Collections.Generic;

namespace LibraSoftSolution.Models
{
    public partial class PiranhaAlias
    {
        public Guid Id { get; set; }
        public string AliasUrl { get; set; } = null!;
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public string RedirectUrl { get; set; } = null!;
        public Guid SiteId { get; set; }
        public int Type { get; set; }

        public virtual PiranhaSite Site { get; set; } = null!;
    }
}
