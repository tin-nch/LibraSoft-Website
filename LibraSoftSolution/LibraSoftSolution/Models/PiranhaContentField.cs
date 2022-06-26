using System;
using System.Collections.Generic;

namespace LibraSoftSolution.Models
{
    public partial class PiranhaContentField
    {
        public PiranhaContentField()
        {
            PiranhaContentFieldTranslations = new HashSet<PiranhaContentFieldTranslation>();
        }

        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
        public string RegionId { get; set; } = null!;
        public string FieldId { get; set; } = null!;
        public int SortOrder { get; set; }
        public string Clrtype { get; set; } = null!;
        public string? Value { get; set; }

        public virtual PiranhaContent Content { get; set; } = null!;
        public virtual ICollection<PiranhaContentFieldTranslation> PiranhaContentFieldTranslations { get; set; }
    }
}
