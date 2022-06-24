using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_UserLogins")]
    [Index("UserId", Name = "IX_Piranha_UserLogins_UserId")]
    public partial class PiranhaUserLogin
    {
        [Key]
        public string LoginProvider { get; set; }
        [Key]
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("PiranhaUserLogins")]
        public virtual PiranhaUser User { get; set; }
    }
}
