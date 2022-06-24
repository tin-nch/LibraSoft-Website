using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_PostFields")]
    [Index("PostId", "RegionId", "FieldId", "SortOrder", Name = "IX_Piranha_PostFields_PostId_RegionId_FieldId_SortOrder")]
    public partial class PiranhaPostField
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
        public Guid PostId { get; set; }
        [Required]
        [StringLength(64)]
        public string RegionId { get; set; }
        public int SortOrder { get; set; }
        public string Value { get; set; }

        [ForeignKey("PostId")]
        [InverseProperty("PiranhaPostFields")]
        public virtual PiranhaPost Post { get; set; }
    }
}
