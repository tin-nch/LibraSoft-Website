using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_Content")]
    [Index("CategoryId", Name = "IX_Piranha_Content_CategoryId")]
    [Index("TypeId", Name = "IX_Piranha_Content_TypeId")]
    public partial class PiranhaContent
    {
        public PiranhaContent()
        {
            PiranhaContentBlocks = new HashSet<PiranhaContentBlock>();
            PiranhaContentFields = new HashSet<PiranhaContentField>();
            PiranhaContentTranslations = new HashSet<PiranhaContentTranslation>();
            Taxonomies = new HashSet<PiranhaTaxonomy>();
        }

        [Key]
        public Guid Id { get; set; }
        public Guid? CategoryId { get; set; }
        [Required]
        [StringLength(64)]
        public string TypeId { get; set; }
        public Guid? PrimaryImageId { get; set; }
        public string Excerpt { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("PiranhaContents")]
        public virtual PiranhaTaxonomy Category { get; set; }
        [ForeignKey("TypeId")]
        [InverseProperty("PiranhaContents")]
        public virtual PiranhaContentType Type { get; set; }
        [InverseProperty("Content")]
        public virtual ICollection<PiranhaContentBlock> PiranhaContentBlocks { get; set; }
        [InverseProperty("Content")]
        public virtual ICollection<PiranhaContentField> PiranhaContentFields { get; set; }
        [InverseProperty("Content")]
        public virtual ICollection<PiranhaContentTranslation> PiranhaContentTranslations { get; set; }

        [ForeignKey("ContentId")]
        [InverseProperty("Contents")]
        public virtual ICollection<PiranhaTaxonomy> Taxonomies { get; set; }
    }
}
