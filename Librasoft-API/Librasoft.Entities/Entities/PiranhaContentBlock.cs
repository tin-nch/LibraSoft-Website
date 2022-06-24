using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_ContentBlocks")]
    [Index("ContentId", Name = "IX_Piranha_ContentBlocks_ContentId")]
    public partial class PiranhaContentBlock
    {
        public PiranhaContentBlock()
        {
            PiranhaContentBlockFields = new HashSet<PiranhaContentBlockField>();
        }

        [Key]
        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
        public int SortOrder { get; set; }
        public Guid? ParentId { get; set; }
        [Required]
        [Column("CLRType")]
        [StringLength(256)]
        public string Clrtype { get; set; }

        [ForeignKey("ContentId")]
        [InverseProperty("PiranhaContentBlocks")]
        public virtual PiranhaContent Content { get; set; }
        [InverseProperty("Block")]
        public virtual ICollection<PiranhaContentBlockField> PiranhaContentBlockFields { get; set; }
    }
}
