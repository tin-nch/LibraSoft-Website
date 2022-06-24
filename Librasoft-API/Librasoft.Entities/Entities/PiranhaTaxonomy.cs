using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_Taxonomies")]
    [Index("GroupId", "Type", "Slug", Name = "IX_Piranha_Taxonomies_GroupId_Type_Slug", IsUnique = true)]
    public partial class PiranhaTaxonomy
    {
        public PiranhaTaxonomy()
        {
            PiranhaContents = new HashSet<PiranhaContent>();
            Contents = new HashSet<PiranhaContent>();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(64)]
        public string GroupId { get; set; }
        public int Type { get; set; }
        [Required]
        [StringLength(64)]
        public string Title { get; set; }
        [Required]
        [StringLength(64)]
        public string Slug { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<PiranhaContent> PiranhaContents { get; set; }

        [ForeignKey("TaxonomyId")]
        [InverseProperty("Taxonomies")]
        public virtual ICollection<PiranhaContent> Contents { get; set; }
    }
}
