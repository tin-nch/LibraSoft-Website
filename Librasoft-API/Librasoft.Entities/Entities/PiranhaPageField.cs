using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_PageFields")]
    [Index("PageId", "RegionId", "FieldId", "SortOrder", Name = "IX_Piranha_PageFields_PageId_RegionId_FieldId_SortOrder")]
    public partial class PiranhaPageField
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
        public Guid PageId { get; set; }
        [Required]
        [StringLength(64)]
        public string RegionId { get; set; }
        public int SortOrder { get; set; }
        public string Value { get; set; }

        [ForeignKey("PageId")]
        [InverseProperty("PiranhaPageFields")]
        public virtual PiranhaPage Page { get; set; }
    }
}
