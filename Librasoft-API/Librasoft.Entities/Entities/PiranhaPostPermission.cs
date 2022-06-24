using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_PostPermissions")]
    public partial class PiranhaPostPermission
    {
        [Key]
        public Guid PostId { get; set; }
        [Key]
        public string Permission { get; set; }

        [ForeignKey("PostId")]
        [InverseProperty("PiranhaPostPermissions")]
        public virtual PiranhaPost Post { get; set; }
    }
}
