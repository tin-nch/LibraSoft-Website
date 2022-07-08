using System;
using System.Collections.Generic;

namespace LibraSoftCMS.Models
{
    public partial class AdminAccount
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsDelete { get; set; }
        public bool IsVirtualEmail { get; set; }
    }
}
