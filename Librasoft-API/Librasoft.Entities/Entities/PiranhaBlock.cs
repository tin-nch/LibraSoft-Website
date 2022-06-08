using System;
using System.Collections.Generic;

namespace Librasoft_API.Entities
{
    public partial class PiranhaBlock
    {
        public PiranhaBlock()
        {
            PiranhaBlockFields = new HashSet<PiranhaBlockField>();
            PiranhaPageBlocks = new HashSet<PiranhaPageBlock>();
            PiranhaPostBlocks = new HashSet<PiranhaPostBlock>();
        }

        public Guid Id { get; set; }
        public string Clrtype { get; set; }
        public DateTime Created { get; set; }
        public bool IsReusable { get; set; }
        public DateTime LastModified { get; set; }
        public string Title { get; set; }
        public Guid? ParentId { get; set; }

        public virtual ICollection<PiranhaBlockField> PiranhaBlockFields { get; set; }
        public virtual ICollection<PiranhaPageBlock> PiranhaPageBlocks { get; set; }
        public virtual ICollection<PiranhaPostBlock> PiranhaPostBlocks { get; set; }
    }
}
