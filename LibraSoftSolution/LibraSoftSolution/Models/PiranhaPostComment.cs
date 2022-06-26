using System;
using System.Collections.Generic;

namespace LibraSoftSolution.Models
{
    public partial class PiranhaPostComment
    {
        public Guid Id { get; set; }
        public string? UserId { get; set; }
        public string Author { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Url { get; set; }
        public bool IsApproved { get; set; }
        public string? Body { get; set; }
        public DateTime Created { get; set; }
        public Guid PostId { get; set; }

        public virtual PiranhaPost Post { get; set; } = null!;
    }
}
