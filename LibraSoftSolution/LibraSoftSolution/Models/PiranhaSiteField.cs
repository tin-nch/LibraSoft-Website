using System;
using System.Collections.Generic;

namespace LibraSoftSolution.Models
{
    public partial class PiranhaSiteField
    {
        public Guid Id { get; set; }
        public string Clrtype { get; set; } = null!;
        public string FieldId { get; set; } = null!;
        public string RegionId { get; set; } = null!;
        public Guid SiteId { get; set; }
        public int SortOrder { get; set; }
        public string? Value { get; set; }

        public virtual PiranhaSite Site { get; set; } = null!;
    }
}
