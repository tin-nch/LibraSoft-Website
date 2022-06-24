using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_UserClaims")]
    [Index("UserId", Name = "IX_Piranha_UserClaims_UserId")]
    public partial class PiranhaUserClaim
    {
        [Key]
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("PiranhaUserClaims")]
        public virtual PiranhaUser User { get; set; }
    }
}
