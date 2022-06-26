using System;
using System.Collections.Generic;

namespace LibraSoftSolution.Models
{
    public partial class PiranhaUserToken
    {
        public Guid UserId { get; set; }
        public string LoginProvider { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Value { get; set; }

        public virtual PiranhaUser User { get; set; } = null!;
    }
}
