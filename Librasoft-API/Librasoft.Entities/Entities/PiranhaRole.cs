using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_Roles")]
    public partial class PiranhaRole
    {
        public PiranhaRole()
        {
            PiranhaRoleClaims = new HashSet<PiranhaRoleClaim>();
            Users = new HashSet<PiranhaUser>();
        }

        [Key]
        public Guid Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        [StringLength(256)]
        public string Name { get; set; }
        [StringLength(256)]
        public string NormalizedName { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<PiranhaRoleClaim> PiranhaRoleClaims { get; set; }

        [ForeignKey("RoleId")]
        [InverseProperty("Roles")]
        public virtual ICollection<PiranhaUser> Users { get; set; }
    }
}
