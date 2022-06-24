using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_Aliases")]
    [Index("SiteId", "AliasUrl", Name = "IX_Piranha_Aliases_SiteId_AliasUrl", IsUnique = true)]
    public partial class PiranhaAlias
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(256)]
        public string AliasUrl { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        [Required]
        [StringLength(256)]
        public string RedirectUrl { get; set; }
        public Guid SiteId { get; set; }
        public int Type { get; set; }

        [ForeignKey("SiteId")]
        [InverseProperty("PiranhaAliases")]
        public virtual PiranhaSite Site { get; set; }
    }
}
