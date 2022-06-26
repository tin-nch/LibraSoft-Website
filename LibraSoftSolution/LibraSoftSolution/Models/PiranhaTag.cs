using System;
using System.Collections.Generic;

namespace LibraSoftSolution.Models
{
    public partial class PiranhaTag
    {
        public PiranhaTag()
        {
            Posts = new HashSet<PiranhaPost>();
        }

        public Guid Id { get; set; }
        public Guid BlogId { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public string Slug { get; set; } = null!;
        public string Title { get; set; } = null!;

        public virtual PiranhaPage Blog { get; set; } = null!;

        public virtual ICollection<PiranhaPost> Posts { get; set; }
    }
}
