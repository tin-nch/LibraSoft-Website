using System;
using System.Collections.Generic;

namespace LibraSoftCMS.Models
{
    public partial class PiranhaPageField
    {
        public Guid Id { get; set; }
        public string Clrtype { get; set; }
        public string FieldId { get; set; }
        public Guid PageId { get; set; }
        public string RegionId { get; set; }
        public int SortOrder { get; set; }
        public string Value { get; set; }

        public virtual PiranhaPage Page { get; set; }
    }
}
