using System;
using System.Collections.Generic;

namespace LibraSoftSolution.Models
{
    public partial class PiranhaContentGroup
    {
        public string Id { get; set; } = null!;
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public string Clrtype { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? Icon { get; set; }
        public bool? IsHidden { get; set; }
    }
}
