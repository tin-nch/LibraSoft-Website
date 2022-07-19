using System;
using System.Collections.Generic;

namespace LibraSoftCMS.Models
{
    public partial class PiranhaContent
    {
        public PiranhaContent()
        {
            PiranhaContentBlocks = new HashSet<PiranhaContentBlock>();
            PiranhaContentFields = new HashSet<PiranhaContentField>();
            PiranhaContentTranslations = new HashSet<PiranhaContentTranslation>();
            Taxonomies = new HashSet<PiranhaTaxonomy>();
        }

        public Guid Id { get; set; }
        public Guid? CategoryId { get; set; }
        public string TypeId { get; set; }
        public Guid? PrimaryImageId { get; set; }
        public string Excerpt { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }

        public virtual PiranhaTaxonomy Category { get; set; }
        public virtual PiranhaContentType Type { get; set; }
        public virtual ICollection<PiranhaContentBlock> PiranhaContentBlocks { get; set; }
        public virtual ICollection<PiranhaContentField> PiranhaContentFields { get; set; }
        public virtual ICollection<PiranhaContentTranslation> PiranhaContentTranslations { get; set; }

        public virtual ICollection<PiranhaTaxonomy> Taxonomies { get; set; }
    }
}
