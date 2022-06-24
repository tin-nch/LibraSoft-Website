using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_ContentFields")]
    [Index("ContentId", "RegionId", "FieldId", "SortOrder", Name = "IX_Piranha_ContentFields_ContentId_RegionId_FieldId_SortOrder")]
    public partial class PiranhaContentField
    {
        public PiranhaContentField()
        {
            PiranhaContentFieldTranslations = new HashSet<PiranhaContentFieldTranslation>();
        }

        [Key]
        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
        [Required]
        [StringLength(64)]
        public string RegionId { get; set; }
        [Required]
        [StringLength(64)]
        public string FieldId { get; set; }
        public int SortOrder { get; set; }
        [Required]
        [Column("CLRType")]
        [StringLength(256)]
        public string Clrtype { get; set; }
        public string Value { get; set; }

        [ForeignKey("ContentId")]
        [InverseProperty("PiranhaContentFields")]
        public virtual PiranhaContent Content { get; set; }
        [InverseProperty("Field")]
        public virtual ICollection<PiranhaContentFieldTranslation> PiranhaContentFieldTranslations { get; set; }
    }
}
