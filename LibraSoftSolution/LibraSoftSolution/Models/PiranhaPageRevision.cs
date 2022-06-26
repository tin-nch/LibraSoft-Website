using System;
using System.Collections.Generic;

namespace LibraSoftSolution.Models
{
    public partial class PiranhaPageRevision
    {
        public Guid Id { get; set; }
        public string? Data { get; set; }
        public DateTime Created { get; set; }
        public Guid PageId { get; set; }

        public virtual PiranhaPage Page { get; set; } = null!;
    }
}
