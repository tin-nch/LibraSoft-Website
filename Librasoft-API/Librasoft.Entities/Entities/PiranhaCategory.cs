using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_Categories")]
    [Index("BlogId", "Slug", Name = "IX_Piranha_Categories_BlogId_Slug", IsUnique = true)]
    public partial class PiranhaCategory
    {
        public PiranhaCategory()
        {
            PiranhaPosts = new HashSet<PiranhaPost>();
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
        [InverseProperty("PiranhaCategories")]
        public virtual PiranhaPage Blog { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<PiranhaPost> PiranhaPosts { get; set; }
    }
}
