using System;
using System.Collections.Generic;

namespace Librasoft_API.Entities
{
    public partial class PiranhaRole
    {
        public PiranhaRole()
        {
            PiranhaRoleClaims = new HashSet<PiranhaRoleClaim>();
            Users = new HashSet<PiranhaUser>();
        }

        public Guid Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }

        public virtual ICollection<PiranhaRoleClaim> PiranhaRoleClaims { get; set; }

        public virtual ICollection<PiranhaUser> Users { get; set; }
    }
}
