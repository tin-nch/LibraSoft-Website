using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_PagePermissions")]
    public partial class PiranhaPagePermission
    {
        [Key]
        public Guid PageId { get; set; }
        [Key]
        public string Permission { get; set; }

        [ForeignKey("PageId")]
        [InverseProperty("PiranhaPagePermissions")]
        public virtual PiranhaPage Page { get; set; }
    }
}
