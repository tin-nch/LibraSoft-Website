using System;
using System.Collections.Generic;

#nullable disable

namespace LibraSoftWeb.Models
{
    public partial class PiranhaSiteField
    {
        public Guid Id { get; set; }
        public string Clrtype { get; set; }
        public string FieldId { get; set; }
        public string RegionId { get; set; }
        public Guid SiteId { get; set; }
        public int SortOrder { get; set; }
        public string Value { get; set; }

        public virtual PiranhaSite Site { get; set; }
    }
}
