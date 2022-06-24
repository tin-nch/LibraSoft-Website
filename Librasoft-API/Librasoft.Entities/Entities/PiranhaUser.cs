using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_Users")]
    [Index("NormalizedEmail", Name = "EmailIndex")]
    public partial class PiranhaUser
    {
        public PiranhaUser()
        {
            PiranhaUserClaims = new HashSet<PiranhaUserClaim>();
            PiranhaUserLogins = new HashSet<PiranhaUserLogin>();
            PiranhaUserTokens = new HashSet<PiranhaUserToken>();
            Roles = new HashSet<PiranhaRole>();
        }

        [Key]
        public Guid Id { get; set; }
        public int AccessFailedCount { get; set; }
        public string ConcurrencyStamp { get; set; }
        [StringLength(256)]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        [StringLength(256)]
        public string NormalizedEmail { get; set; }
        [StringLength(256)]
        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        [StringLength(256)]
        public string UserName { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<PiranhaUserClaim> PiranhaUserClaims { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<PiranhaUserLogin> PiranhaUserLogins { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<PiranhaUserToken> PiranhaUserTokens { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Users")]
        public virtual ICollection<PiranhaRole> Roles { get; set; }
    }
}
