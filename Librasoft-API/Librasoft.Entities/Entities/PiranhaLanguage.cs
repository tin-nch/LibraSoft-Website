using System;
using System.Collections.Generic;

namespace Librasoft.Entities.Entities
{
    public partial class PiranhaLanguage
    {
        public PiranhaLanguage()
        {
            PiranhaContentBlockFieldTranslations = new HashSet<PiranhaContentBlockFieldTranslation>();
            PiranhaContentFieldTranslations = new HashSet<PiranhaContentFieldTranslation>();
            PiranhaContentTranslations = new HashSet<PiranhaContentTranslation>();
            PiranhaSites = new HashSet<PiranhaSite>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Culture { get; set; }
        public bool IsDefault { get; set; }

        public virtual ICollection<PiranhaContentBlockFieldTranslation> PiranhaContentBlockFieldTranslations { get; set; }
        public virtual ICollection<PiranhaContentFieldTranslation> PiranhaContentFieldTranslations { get; set; }
        public virtual ICollection<PiranhaContentTranslation> PiranhaContentTranslations { get; set; }
        public virtual ICollection<PiranhaSite> PiranhaSites { get; set; }
    }
}
