using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_SiteFields")]
    [Index("SiteId", "RegionId", "FieldId", "SortOrder", Name = "IX_Piranha_SiteFields_SiteId_RegionId_FieldId_SortOrder")]
    public partial class PiranhaSiteField
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Column("CLRType")]
        [StringLength(256)]
        public string Clrtype { get; set; }
        [Required]
        [StringLength(64)]
        public string FieldId { get; set; }
        [Required]
        [StringLength(64)]
        public string RegionId { get; set; }
        public Guid SiteId { get; set; }
        public int SortOrder { get; set; }
        public string Value { get; set; }

        [ForeignKey("SiteId")]
        [InverseProperty("PiranhaSiteFields")]
        public virtual PiranhaSite Site { get; set; }
    }
}
