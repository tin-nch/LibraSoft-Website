using System;
using System.Collections.Generic;

#nullable disable

namespace LibraSoftWeb.Models
{
    public partial class PiranhaUserLogin
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public Guid UserId { get; set; }

        public virtual PiranhaUser User { get; set; }
    }
}
