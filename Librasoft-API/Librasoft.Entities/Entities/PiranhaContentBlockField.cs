using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_ContentBlockFields")]
    [Index("BlockId", "FieldId", "SortOrder", Name = "IX_Piranha_ContentBlockFields_BlockId_FieldId_SortOrder", IsUnique = true)]
    public partial class PiranhaContentBlockField
    {
        public PiranhaContentBlockField()
        {
            PiranhaContentBlockFieldTranslations = new HashSet<PiranhaContentBlockFieldTranslation>();
        }

        [Key]
        public Guid Id { get; set; }
        public Guid BlockId { get; set; }
        [Required]
        [StringLength(64)]
        public string FieldId { get; set; }
        public int SortOrder { get; set; }
        [Required]
        [Column("CLRType")]
        [StringLength(256)]
        public string Clrtype { get; set; }
        public string Value { get; set; }

        [ForeignKey("BlockId")]
        [InverseProperty("PiranhaContentBlockFields")]
        public virtual PiranhaContentBlock Block { get; set; }
        [InverseProperty("Field")]
        public virtual ICollection<PiranhaContentBlockFieldTranslation> PiranhaContentBlockFieldTranslations { get; set; }
    }
}
