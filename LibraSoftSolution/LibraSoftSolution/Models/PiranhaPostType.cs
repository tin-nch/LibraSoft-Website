using System;
using System.Collections.Generic;

namespace LibraSoftSolution.Models
{
    public partial class PiranhaPostType
    {
        public PiranhaPostType()
        {
            PiranhaPosts = new HashSet<PiranhaPost>();
        }

        public string Id { get; set; } = null!;
        public string? Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public string? Clrtype { get; set; }

        public virtual ICollection<PiranhaPost> PiranhaPosts { get; set; }
    }
}
