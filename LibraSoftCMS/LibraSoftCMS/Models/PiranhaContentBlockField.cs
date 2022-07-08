using System;
using System.Collections.Generic;

namespace LibraSoftCMS.Models
{
    public partial class PiranhaContentBlockField
    {
        public PiranhaContentBlockField()
        {
            PiranhaContentBlockFieldTranslations = new HashSet<PiranhaContentBlockFieldTranslation>();
        }

        public Guid Id { get; set; }
        public Guid BlockId { get; set; }
        public string FieldId { get; set; }
        public int SortOrder { get; set; }
        public string Clrtype { get; set; }
        public string Value { get; set; }

        public virtual PiranhaContentBlock Block { get; set; }
        public virtual ICollection<PiranhaContentBlockFieldTranslation> PiranhaContentBlockFieldTranslations { get; set; }
    }
}
