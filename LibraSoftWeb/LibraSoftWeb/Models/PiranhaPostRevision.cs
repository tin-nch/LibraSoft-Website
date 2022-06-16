using System;
using System.Collections.Generic;

#nullable disable

namespace LibraSoftWeb.Models
{
    public partial class PiranhaPostRevision
    {
        public Guid Id { get; set; }
        public string Data { get; set; }
        public DateTime Created { get; set; }
        public Guid PostId { get; set; }

        public virtual PiranhaPost Post { get; set; }
    }
}
