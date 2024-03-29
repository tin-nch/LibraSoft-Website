﻿using System;
using System.Collections.Generic;

namespace LibraSoftCMS.Models
{
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

        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public bool IsHidden { get; set; }
        public DateTime LastModified { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string NavigationTitle { get; set; }
        public string PageTypeId { get; set; }
        public Guid? ParentId { get; set; }
        public DateTime? Published { get; set; }
        public int RedirectType { get; set; }
        public string RedirectUrl { get; set; }
        public string Route { get; set; }
        public Guid SiteId { get; set; }
        public string Slug { get; set; }
        public int SortOrder { get; set; }
        public string Title { get; set; }
        public string ContentType { get; set; }
        public Guid? OriginalPageId { get; set; }
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

        public virtual PiranhaPageType PageType { get; set; }
        public virtual PiranhaPage Parent { get; set; }
        public virtual PiranhaSite Site { get; set; }
        public virtual ICollection<PiranhaPage> InverseParent { get; set; }
        public virtual ICollection<PiranhaCategory> PiranhaCategories { get; set; }
        public virtual ICollection<PiranhaPageBlock> PiranhaPageBlocks { get; set; }
        public virtual ICollection<PiranhaPageComment> PiranhaPageComments { get; set; }
        public virtual ICollection<PiranhaPageField> PiranhaPageFields { get; set; }
        public virtual ICollection<PiranhaPagePermission> PiranhaPagePermissions { get; set; }
        public virtual ICollection<PiranhaPageRevision> PiranhaPageRevisions { get; set; }
        public virtual ICollection<PiranhaPost> PiranhaPosts { get; set; }
        public virtual ICollection<PiranhaTag> PiranhaTags { get; set; }
    }
}
