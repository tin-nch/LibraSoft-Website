using System;
using System.Collections.Generic;

namespace LibraSoftSolution.Models
{
    public partial class PiranhaBlockField
    {
        public Guid Id { get; set; }
        public Guid BlockId { get; set; }
        public string Clrtype { get; set; } = null!;
        public string FieldId { get; set; } = null!;
        public int SortOrder { get; set; }
        public string? Value { get; set; }

        public virtual PiranhaBlock Block { get; set; } = null!;
    }
}
