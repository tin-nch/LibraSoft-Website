using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_Sites")]
    [Index("InternalId", Name = "IX_Piranha_Sites_InternalId", IsUnique = true)]
    [Index("LanguageId", Name = "IX_Piranha_Sites_LanguageId")]
    public partial class PiranhaSite
    {
        public PiranhaSite()
        {
            PiranhaAliases = new HashSet<PiranhaAlias>();
            PiranhaPages = new HashSet<PiranhaPage>();
            PiranhaSiteFields = new HashSet<PiranhaSiteField>();
        }

        [Key]
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        [StringLength(256)]
        public string Description { get; set; }
        [StringLength(256)]
        public string Hostnames { get; set; }
        [Required]
        [StringLength(64)]
        public string InternalId { get; set; }
        public bool IsDefault { get; set; }
        public DateTime LastModified { get; set; }
        [StringLength(128)]
        public string Title { get; set; }
        [StringLength(64)]
        public string SiteTypeId { get; set; }
        public DateTime? ContentLastModified { get; set; }
        [StringLength(6)]
        public string Culture { get; set; }
        public Guid? LogoId { get; set; }
        public Guid? LanguageId { get; set; }

        [ForeignKey("LanguageId")]
        [InverseProperty("PiranhaSites")]
        public virtual PiranhaLanguage Language { get; set; }
        [InverseProperty("Site")]
        public virtual ICollection<PiranhaAlias> PiranhaAliases { get; set; }
        [InverseProperty("Site")]
        public virtual ICollection<PiranhaPage> PiranhaPages { get; set; }
        [InverseProperty("Site")]
        public virtual ICollection<PiranhaSiteField> PiranhaSiteFields { get; set; }
    }
}
