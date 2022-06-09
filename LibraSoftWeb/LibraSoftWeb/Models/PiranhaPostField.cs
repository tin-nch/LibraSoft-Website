using System;
using System.Collections.Generic;

#nullable disable

namespace LibraSoftWeb.Models
{
    public partial class PiranhaPostField
    {
        public Guid Id { get; set; }
        public string Clrtype { get; set; }
        public string FieldId { get; set; }
        public Guid PostId { get; set; }
        public string RegionId { get; set; }
        public int SortOrder { get; set; }
        public string Value { get; set; }

        public virtual PiranhaPost Post { get; set; }
    }
}
