using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_ContentBlockFieldTranslations")]
    [Index("LanguageId", Name = "IX_Piranha_ContentBlockFieldTranslations_LanguageId")]
    public partial class PiranhaContentBlockFieldTranslation
    {
        [Key]
        public Guid FieldId { get; set; }
        [Key]
        public Guid LanguageId { get; set; }
        public string Value { get; set; }

        [ForeignKey("FieldId")]
        [InverseProperty("PiranhaContentBlockFieldTranslations")]
        public virtual PiranhaContentBlockField Field { get; set; }
        [ForeignKey("LanguageId")]
        [InverseProperty("PiranhaContentBlockFieldTranslations")]
        public virtual PiranhaLanguage Language { get; set; }
    }
}
