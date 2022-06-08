using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraSoftWeb.Models
{
    public class Piranha_Pages
    {
        public Piranha_Pages()
        {
        }

        public System.Guid Id { get; set; }
        public System.DateTime Created { get; set; }
        public bool IsHidden { get; set; }
        public System.DateTime LastModified { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string NavigationTitle { get; set; }
        public string PageTypeId { get; set; }
        public Nullable<System.Guid> ParentId { get; set; }
        public Nullable<System.DateTime> Published { get; set; }
        public int RedirectType { get; set; }
        public string RedirectUrl { get; set; }
        public string Route { get; set; }
        public System.Guid SiteId { get; set; }
        public string Slug { get; set; }
        public int SortOrder { get; set; }
        public string Title { get; set; }
        public string ContentType { get; set; }
        public Nullable<System.Guid> OriginalPageId { get; set; }
        public int CloseCommentsAfterDays { get; set; }
        public bool EnableComments { get; set; }
        public string Excerpt { get; set; }
        public Nullable<System.Guid> PrimaryImageId { get; set; }
        public string MetaTitle { get; set; }
        public string OgDescription { get; set; }
        public System.Guid OgImageId { get; set; }
        public string OgTitle { get; set; }
        public Nullable<bool> MetaFollow { get; set; }
        public Nullable<bool> MetaIndex { get; set; }
        public double MetaPriority { get; set; }
    }
}
