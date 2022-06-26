using System;
using System.Collections.Generic;

namespace LibraSoftSolution.Models
{
    public partial class PiranhaParam
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public string? Description { get; set; }
        public string Key { get; set; } = null!;
        public DateTime LastModified { get; set; }
        public string? Value { get; set; }
    }
}
