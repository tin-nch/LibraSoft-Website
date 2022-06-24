using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_Languages")]
    public partial class PiranhaLanguage
    {
        public PiranhaLanguage()
        {
            PiranhaContentBlockFieldTranslations = new HashSet<PiranhaContentBlockFieldTranslation>();
            PiranhaContentFieldTranslations = new HashSet<PiranhaContentFieldTranslation>();
            PiranhaContentTranslations = new HashSet<PiranhaContentTranslation>();
            PiranhaSites = new HashSet<PiranhaSite>();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(64)]
        public string Title { get; set; }
        [StringLength(6)]
        public string Culture { get; set; }
        public bool IsDefault { get; set; }

        [InverseProperty("Language")]
        public virtual ICollection<PiranhaContentBlockFieldTranslation> PiranhaContentBlockFieldTranslations { get; set; }
        [InverseProperty("Language")]
        public virtual ICollection<PiranhaContentFieldTranslation> PiranhaContentFieldTranslations { get; set; }
        [InverseProperty("Language")]
        public virtual ICollection<PiranhaContentTranslation> PiranhaContentTranslations { get; set; }
        [InverseProperty("Language")]
        public virtual ICollection<PiranhaSite> PiranhaSites { get; set; }
    }
}
