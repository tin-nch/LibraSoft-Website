using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_BlockFields")]
    [Index("BlockId", "FieldId", "SortOrder", Name = "IX_Piranha_BlockFields_BlockId_FieldId_SortOrder", IsUnique = true)]
    public partial class PiranhaBlockField
    {
        [Key]
        public Guid Id { get; set; }
        public Guid BlockId { get; set; }
        [Required]
        [Column("CLRType")]
        [StringLength(256)]
        public string Clrtype { get; set; }
        [Required]
        [StringLength(64)]
        public string FieldId { get; set; }
        public int SortOrder { get; set; }
        public string Value { get; set; }

        [ForeignKey("BlockId")]
        [InverseProperty("PiranhaBlockFields")]
        public virtual PiranhaBlock Block { get; set; }
    }
}
