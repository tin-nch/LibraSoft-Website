using System;
using System.Collections.Generic;

#nullable disable

namespace LibraSoftWeb.Models
{
    public partial class PiranhaUserRole
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public virtual PiranhaRole Role { get; set; }
        public virtual PiranhaUser User { get; set; }
    }
}
