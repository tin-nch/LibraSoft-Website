using System;
using System.Collections.Generic;

namespace Librasoft.Entities.Entities
{
    public partial class PiranhaContentField
    {
        public PiranhaContentField()
        {
            PiranhaContentFieldTranslations = new HashSet<PiranhaContentFieldTranslation>();
        }

        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
        public string RegionId { get; set; }
        public string FieldId { get; set; }
        public int SortOrder { get; set; }
        public string Clrtype { get; set; }
        public string Value { get; set; }

        public virtual PiranhaContent Content { get; set; }
        public virtual ICollection<PiranhaContentFieldTranslation> PiranhaContentFieldTranslations { get; set; }
    }
}
