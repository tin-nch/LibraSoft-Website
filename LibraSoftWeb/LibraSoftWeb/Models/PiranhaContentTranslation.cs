using System;
using System.Collections.Generic;

#nullable disable

namespace LibraSoftWeb.Models
{
    public partial class PiranhaContentTranslation
    {
        public Guid ContentId { get; set; }
        public Guid LanguageId { get; set; }
        public string Title { get; set; }
        public string Excerpt { get; set; }
        public DateTime LastModified { get; set; }

        public virtual PiranhaContent Content { get; set; }
        public virtual PiranhaLanguage Language { get; set; }
    }
}
