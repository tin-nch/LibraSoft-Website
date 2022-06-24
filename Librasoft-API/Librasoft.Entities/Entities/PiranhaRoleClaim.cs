using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_RoleClaims")]
    [Index("RoleId", Name = "IX_Piranha_RoleClaims_RoleId")]
    public partial class PiranhaRoleClaim
    {
        [Key]
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public Guid RoleId { get; set; }

        [ForeignKey("RoleId")]
        [InverseProperty("PiranhaRoleClaims")]
        public virtual PiranhaRole Role { get; set; }
    }
}
