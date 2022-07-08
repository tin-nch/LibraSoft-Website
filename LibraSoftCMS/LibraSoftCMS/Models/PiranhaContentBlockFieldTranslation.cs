using System;
using System.Collections.Generic;

namespace LibraSoftCMS.Models
{
    public partial class PiranhaContentBlockFieldTranslation
    {
        public Guid FieldId { get; set; }
        public Guid LanguageId { get; set; }
        public string Value { get; set; }

        public virtual PiranhaContentBlockField Field { get; set; }
        public virtual PiranhaLanguage Language { get; set; }
    }
}
