using System;
using System.Collections.Generic;

#nullable disable

namespace LibraSoftWeb.Models
{
    public partial class PiranhaPostTag
    {
        public Guid PostId { get; set; }
        public Guid TagId { get; set; }

        public virtual PiranhaPost Post { get; set; }
        public virtual PiranhaTag Tag { get; set; }
    }
}
