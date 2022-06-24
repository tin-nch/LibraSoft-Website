using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_Posts")]
    [Index("BlogId", "Slug", Name = "IX_Piranha_Posts_BlogId_Slug", IsUnique = true)]
    [Index("CategoryId", Name = "IX_Piranha_Posts_CategoryId")]
    [Index("PostTypeId", Name = "IX_Piranha_Posts_PostTypeId")]
    public partial class PiranhaPost
    {
        public PiranhaPost()
        {
            PiranhaPostBlocks = new HashSet<PiranhaPostBlock>();
            PiranhaPostComments = new HashSet<PiranhaPostComment>();
            PiranhaPostFields = new HashSet<PiranhaPostField>();
            PiranhaPostPermissions = new HashSet<PiranhaPostPermission>();
            PiranhaPostRevisions = new HashSet<PiranhaPostRevision>();
            Tags = new HashSet<PiranhaTag>();
        }

        [Key]
        public Guid Id { get; set; }
        public Guid BlogId { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        [StringLength(256)]
        public string MetaDescription { get; set; }
        [StringLength(128)]
        public string MetaKeywords { get; set; }
        [Required]
        [StringLength(64)]
        public string PostTypeId { get; set; }
        public DateTime? Published { get; set; }
        public int RedirectType { get; set; }
        [StringLength(256)]
        public string RedirectUrl { get; set; }
        [StringLength(256)]
        public string Route { get; set; }
        [Required]
        [StringLength(128)]
        public string Slug { get; set; }
        [Required]
        [StringLength(128)]
        public string Title { get; set; }
        public int CloseCommentsAfterDays { get; set; }
        [Required]
        public bool? EnableComments { get; set; }
        public string Excerpt { get; set; }
        public Guid? PrimaryImageId { get; set; }
        [StringLength(128)]
        public string MetaTitle { get; set; }
        [StringLength(256)]
        public string OgDescription { get; set; }
        public Guid OgImageId { get; set; }
        [StringLength(128)]
        public string OgTitle { get; set; }
        public bool? MetaFollow { get; set; }
        public bool? MetaIndex { get; set; }
        public double MetaPriority { get; set; }

        [ForeignKey("BlogId")]
        [InverseProperty("PiranhaPosts")]
        public virtual PiranhaPage Blog { get; set; }
        [ForeignKey("CategoryId")]
        [InverseProperty("PiranhaPosts")]
        public virtual PiranhaCategory Category { get; set; }
        [ForeignKey("PostTypeId")]
        [InverseProperty("PiranhaPosts")]
        public virtual PiranhaPostType PostType { get; set; }
        [InverseProperty("Post")]
        public virtual ICollection<PiranhaPostBlock> PiranhaPostBlocks { get; set; }
        [InverseProperty("Post")]
        public virtual ICollection<PiranhaPostComment> PiranhaPostComments { get; set; }
        [InverseProperty("Post")]
        public virtual ICollection<PiranhaPostField> PiranhaPostFields { get; set; }
        [InverseProperty("Post")]
        public virtual ICollection<PiranhaPostPermission> PiranhaPostPermissions { get; set; }
        [InverseProperty("Post")]
        public virtual ICollection<PiranhaPostRevision> PiranhaPostRevisions { get; set; }

        [ForeignKey("PostId")]
        [InverseProperty("Posts")]
        public virtual ICollection<PiranhaTag> Tags { get; set; }
    }
}
