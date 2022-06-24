using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_UserTokens")]
    public partial class PiranhaUserToken
    {
        [Key]
        public Guid UserId { get; set; }
        [Key]
        public string LoginProvider { get; set; }
        [Key]
        public string Name { get; set; }
        public string Value { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("PiranhaUserTokens")]
        public virtual PiranhaUser User { get; set; }
    }
}
