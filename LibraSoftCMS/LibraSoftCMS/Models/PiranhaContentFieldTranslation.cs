using System;
using System.Collections.Generic;

namespace LibraSoftCMS.Models
{
    public partial class PiranhaContentFieldTranslation
    {
        public Guid FieldId { get; set; }
        public Guid LanguageId { get; set; }
        public string Value { get; set; }

        public virtual PiranhaContentField Field { get; set; }
        public virtual PiranhaLanguage Language { get; set; }
    }
}
