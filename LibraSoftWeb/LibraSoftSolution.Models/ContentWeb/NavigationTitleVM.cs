using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.ViewModels.ContentWeb
{
    public class NavigationTitleVM
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public bool IsHidden { get; set; }
        public DateTime LastModified { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string NavigationTitle { get; set; }
        public string PageTypeId { get; set; }
        public string ParentId { get; set; }
        public DateTime? Published { get; set; }
        public int RedirectType { get; set; }
        public string RedirectUrl { get; set; }
        public string Route { get; set; }
        public string SiteId { get; set; }
        public string Slug { get; set; }
        public int SortOrder { get; set; }
        public string Title { get; set; }
        public string ContentType { get; set; }
        public string OriginalPageId { get; set; }
        public int CloseCommentsAfterDays { get; set; }
        public bool? EnableComments { get; set; }
        public string Excerpt { get; set; }
        public string PrimaryImageId { get; set; }
        public string MetaTitle { get; set; }
        public string OgDescription { get; set; }
        public string OgImageId { get; set; }
        public string OgTitle { get; set; }
        public bool? MetaFollow { get; set; }
        public bool? MetaIndex { get; set; }
        public double MetaPriority { get; set; }
    }
}
