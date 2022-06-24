using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_Pages")]
    [Index("PageTypeId", Name = "IX_Piranha_Pages_PageTypeId")]
    [Index("ParentId", Name = "IX_Piranha_Pages_ParentId")]
    [Index("SiteId", "Slug", Name = "IX_Piranha_Pages_SiteId_Slug", IsUnique = true)]
    public partial class PiranhaPage
    {
        public PiranhaPage()
        {
            InverseParent = new HashSet<PiranhaPage>();
            PiranhaCategories = new HashSet<PiranhaCategory>();
            PiranhaPageBlocks = new HashSet<PiranhaPageBlock>();
            PiranhaPageComments = new HashSet<PiranhaPageComment>();
            PiranhaPageFields = new HashSet<PiranhaPageField>();
            PiranhaPagePermissions = new HashSet<PiranhaPagePermission>();
            PiranhaPageRevisions = new HashSet<PiranhaPageRevision>();
            PiranhaPosts = new HashSet<PiranhaPost>();
            PiranhaTags = new HashSet<PiranhaTag>();
        }

        [Key]
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public bool IsHidden { get; set; }
        public DateTime LastModified { get; set; }
        [StringLength(256)]
        public string MetaDescription { get; set; }
        [StringLength(128)]
        public string MetaKeywords { get; set; }
        [StringLength(128)]
        public string NavigationTitle { get; set; }
        [Required]
        [StringLength(64)]
        public string PageTypeId { get; set; }
        public Guid? ParentId { get; set; }
        public DateTime? Published { get; set; }
        public int RedirectType { get; set; }
        [StringLength(256)]
        public string RedirectUrl { get; set; }
        [StringLength(256)]
        public string Route { get; set; }
        public Guid SiteId { get; set; }
        [Required]
        [StringLength(128)]
        public string Slug { get; set; }
        public int SortOrder { get; set; }
        [Required]
        [StringLength(128)]
        public string Title { get; set; }
        [Required]
        [StringLength(255)]
        public string ContentType { get; set; }
        public Guid? OriginalPageId { get; set; }
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

        [ForeignKey("PageTypeId")]
        [InverseProperty("PiranhaPages")]
        public virtual PiranhaPageType PageType { get; set; }
        [ForeignKey("ParentId")]
        [InverseProperty("InverseParent")]
        public virtual PiranhaPage Parent { get; set; }
        [ForeignKey("SiteId")]
        [InverseProperty("PiranhaPages")]
        public virtual PiranhaSite Site { get; set; }
        [InverseProperty("Parent")]
        public virtual ICollection<PiranhaPage> InverseParent { get; set; }
        [InverseProperty("Blog")]
        public virtual ICollection<PiranhaCategory> PiranhaCategories { get; set; }
        [InverseProperty("Page")]
        public virtual ICollection<PiranhaPageBlock> PiranhaPageBlocks { get; set; }
        [InverseProperty("Page")]
        public virtual ICollection<PiranhaPageComment> PiranhaPageComments { get; set; }
        [InverseProperty("Page")]
        public virtual ICollection<PiranhaPageField> PiranhaPageFields { get; set; }
        [InverseProperty("Page")]
        public virtual ICollection<PiranhaPagePermission> PiranhaPagePermissions { get; set; }
        [InverseProperty("Page")]
        public virtual ICollection<PiranhaPageRevision> PiranhaPageRevisions { get; set; }
        [InverseProperty("Blog")]
        public virtual ICollection<PiranhaPost> PiranhaPosts { get; set; }
        [InverseProperty("Blog")]
        public virtual ICollection<PiranhaTag> PiranhaTags { get; set; }
    }
}
