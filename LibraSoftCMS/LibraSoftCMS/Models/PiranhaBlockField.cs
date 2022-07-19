using System;
using System.Collections.Generic;

namespace LibraSoftCMS.Models
{
    public partial class PiranhaBlockField
    {
        public Guid Id { get; set; }
        public Guid BlockId { get; set; }
        public string Clrtype { get; set; }
        public string FieldId { get; set; }
        public int SortOrder { get; set; }
        public string Value { get; set; }

        public virtual PiranhaBlock Block { get; set; }
    }
}
