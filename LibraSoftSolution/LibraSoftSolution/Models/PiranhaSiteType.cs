using System;
using System.Collections.Generic;

namespace LibraSoftSolution.Models
{
    public partial class PiranhaSiteType
    {
        public string Id { get; set; } = null!;
        public string? Body { get; set; }
        public string? Clrtype { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}
