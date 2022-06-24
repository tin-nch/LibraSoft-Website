using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_ContentTranslations")]
    [Index("LanguageId", Name = "IX_Piranha_ContentTranslations_LanguageId")]
    public partial class PiranhaContentTranslation
    {
        [Key]
        public Guid ContentId { get; set; }
        [Key]
        public Guid LanguageId { get; set; }
        [Required]
        [StringLength(128)]
        public string Title { get; set; }
        public string Excerpt { get; set; }
        public DateTime LastModified { get; set; }

        [ForeignKey("ContentId")]
        [InverseProperty("PiranhaContentTranslations")]
        public virtual PiranhaContent Content { get; set; }
        [ForeignKey("LanguageId")]
        [InverseProperty("PiranhaContentTranslations")]
        public virtual PiranhaLanguage Language { get; set; }
    }
}
