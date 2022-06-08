using System;
using System.Collections.Generic;

namespace Librasoft_API.Entities
{
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

        public Guid Id { get; set; }
        public Guid BlogId { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string PostTypeId { get; set; }
        public DateTime? Published { get; set; }
        public int RedirectType { get; set; }
        public string RedirectUrl { get; set; }
        public string Route { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public int CloseCommentsAfterDays { get; set; }
        public bool? EnableComments { get; set; }
        public string Excerpt { get; set; }
        public Guid? PrimaryImageId { get; set; }
        public string MetaTitle { get; set; }
        public string OgDescription { get; set; }
        public Guid OgImageId { get; set; }
        public string OgTitle { get; set; }
        public bool? MetaFollow { get; set; }
        public bool? MetaIndex { get; set; }
        public double MetaPriority { get; set; }

        public virtual PiranhaPage Blog { get; set; }
        public virtual PiranhaCategory Category { get; set; }
        public virtual PiranhaPostType PostType { get; set; }
        public virtual ICollection<PiranhaPostBlock> PiranhaPostBlocks { get; set; }
        public virtual ICollection<PiranhaPostComment> PiranhaPostComments { get; set; }
        public virtual ICollection<PiranhaPostField> PiranhaPostFields { get; set; }
        public virtual ICollection<PiranhaPostPermission> PiranhaPostPermissions { get; set; }
        public virtual ICollection<PiranhaPostRevision> PiranhaPostRevisions { get; set; }

        public virtual ICollection<PiranhaTag> Tags { get; set; }
    }
}
