using System;
using System.Collections.Generic;

namespace LibraSoftSolution.Models
{
    public partial class PiranhaContentFieldTranslation
    {
        public Guid FieldId { get; set; }
        public Guid LanguageId { get; set; }
        public string? Value { get; set; }

        public virtual PiranhaContentField Field { get; set; } = null!;
        public virtual PiranhaLanguage Language { get; set; } = null!;
    }
}
