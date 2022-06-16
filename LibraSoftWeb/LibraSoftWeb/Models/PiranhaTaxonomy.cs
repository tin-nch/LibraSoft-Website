using System;
using System.Collections.Generic;

#nullable disable

namespace LibraSoftWeb.Models
{
    public partial class PiranhaTaxonomy
    {
        public PiranhaTaxonomy()
        {
            PiranhaContentTaxonomies = new HashSet<PiranhaContentTaxonomy>();
            PiranhaContents = new HashSet<PiranhaContent>();
        }

        public Guid Id { get; set; }
        public string GroupId { get; set; }
        public int Type { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ICollection<PiranhaContentTaxonomy> PiranhaContentTaxonomies { get; set; }
        public virtual ICollection<PiranhaContent> PiranhaContents { get; set; }
    }
}
