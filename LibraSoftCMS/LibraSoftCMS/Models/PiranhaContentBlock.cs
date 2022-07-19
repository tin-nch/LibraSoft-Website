using System;
using System.Collections.Generic;

namespace LibraSoftCMS.Models
{
    public partial class PiranhaContentBlock
    {
        public PiranhaContentBlock()
        {
            PiranhaContentBlockFields = new HashSet<PiranhaContentBlockField>();
        }

        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
        public int SortOrder { get; set; }
        public Guid? ParentId { get; set; }
        public string Clrtype { get; set; }

        public virtual PiranhaContent Content { get; set; }
        public virtual ICollection<PiranhaContentBlockField> PiranhaContentBlockFields { get; set; }
    }
}
