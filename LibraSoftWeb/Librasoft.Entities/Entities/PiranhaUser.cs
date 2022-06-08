using System;
using System.Collections.Generic;

namespace Librasoft_API.Entities
{
    public partial class PiranhaUser
    {
        public PiranhaUser()
        {
            PiranhaUserClaims = new HashSet<PiranhaUserClaim>();
            PiranhaUserLogins = new HashSet<PiranhaUserLogin>();
            PiranhaUserTokens = new HashSet<PiranhaUserToken>();
            Roles = new HashSet<PiranhaRole>();
        }

        public Guid Id { get; set; }
        public int AccessFailedCount { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<PiranhaUserClaim> PiranhaUserClaims { get; set; }
        public virtual ICollection<PiranhaUserLogin> PiranhaUserLogins { get; set; }
        public virtual ICollection<PiranhaUserToken> PiranhaUserTokens { get; set; }

        public virtual ICollection<PiranhaRole> Roles { get; set; }
    }
}
