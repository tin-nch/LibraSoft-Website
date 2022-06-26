using System;
using System.Collections.Generic;

namespace LibraSoftSolution.Models
{
    public partial class PiranhaContentBlockField
    {
        public PiranhaContentBlockField()
        {
            PiranhaContentBlockFieldTranslations = new HashSet<PiranhaContentBlockFieldTranslation>();
        }

        public Guid Id { get; set; }
        public Guid BlockId { get; set; }
        public string FieldId { get; set; } = null!;
        public int SortOrder { get; set; }
        public string Clrtype { get; set; } = null!;
        public string? Value { get; set; }

        public virtual PiranhaContentBlock Block { get; set; } = null!;
        public virtual ICollection<PiranhaContentBlockFieldTranslation> PiranhaContentBlockFieldTranslations { get; set; }
    }
}
