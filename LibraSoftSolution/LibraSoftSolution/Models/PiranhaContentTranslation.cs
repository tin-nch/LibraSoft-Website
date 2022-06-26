using System;
using System.Collections.Generic;

namespace LibraSoftSolution.Models
{
    public partial class PiranhaContentTranslation
    {
        public Guid ContentId { get; set; }
        public Guid LanguageId { get; set; }
        public string Title { get; set; } = null!;
        public string? Excerpt { get; set; }
        public DateTime LastModified { get; set; }

        public virtual PiranhaContent Content { get; set; } = null!;
        public virtual PiranhaLanguage Language { get; set; } = null!;
    }
}
