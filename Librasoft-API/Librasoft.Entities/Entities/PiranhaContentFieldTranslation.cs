using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_ContentFieldTranslations")]
    [Index("LanguageId", Name = "IX_Piranha_ContentFieldTranslations_LanguageId")]
    public partial class PiranhaContentFieldTranslation
    {
        [Key]
        public Guid FieldId { get; set; }
        [Key]
        public Guid LanguageId { get; set; }
        public string Value { get; set; }

        [ForeignKey("FieldId")]
        [InverseProperty("PiranhaContentFieldTranslations")]
        public virtual PiranhaContentField Field { get; set; }
        [ForeignKey("LanguageId")]
        [InverseProperty("PiranhaContentFieldTranslations")]
        public virtual PiranhaLanguage Language { get; set; }
    }
}
