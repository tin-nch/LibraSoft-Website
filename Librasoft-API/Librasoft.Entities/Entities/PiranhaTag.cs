using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_Tags")]
    [Index("BlogId", "Slug", Name = "IX_Piranha_Tags_BlogId_Slug", IsUnique = true)]
    public partial class PiranhaTag
    {
        public PiranhaTag()
        {
            Posts = new HashSet<PiranhaPost>();
        }

        [Key]
        public Guid Id { get; set; }
        public Guid BlogId { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        [Required]
        [StringLength(64)]
        public string Slug { get; set; }
        [Required]
        [StringLength(64)]
        public string Title { get; set; }

        [ForeignKey("BlogId")]
        [InverseProperty("PiranhaTags")]
        public virtual PiranhaPage Blog { get; set; }

        [ForeignKey("TagId")]
        [InverseProperty("Tags")]
        public virtual ICollection<PiranhaPost> Posts { get; set; }
    }
}
