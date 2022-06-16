using System;
using System.Collections.Generic;

#nullable disable

namespace LibraSoftWeb.Models
{
    public partial class PiranhaContentGroup
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public string Clrtype { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public bool? IsHidden { get; set; }
    }
}
