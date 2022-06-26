using System;
using System.Collections.Generic;

namespace LibraSoftSolution.Models
{
    public partial class PiranhaPageField
    {
        public Guid Id { get; set; }
        public string Clrtype { get; set; } = null!;
        public string FieldId { get; set; } = null!;
        public Guid PageId { get; set; }
        public string RegionId { get; set; } = null!;
        public int SortOrder { get; set; }
        public string? Value { get; set; }

        public virtual PiranhaPage Page { get; set; } = null!;
    }
}
