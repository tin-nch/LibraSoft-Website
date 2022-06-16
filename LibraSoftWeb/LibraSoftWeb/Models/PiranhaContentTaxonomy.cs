using System;
using System.Collections.Generic;

#nullable disable

namespace LibraSoftWeb.Models
{
    public partial class PiranhaContentTaxonomy
    {
        public Guid ContentId { get; set; }
        public Guid TaxonomyId { get; set; }

        public virtual PiranhaContent Content { get; set; }
        public virtual PiranhaTaxonomy Taxonomy { get; set; }
    }
}
