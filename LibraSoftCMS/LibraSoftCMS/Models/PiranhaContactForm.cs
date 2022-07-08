using System;
using System.Collections.Generic;

namespace LibraSoftCMS.Models
{
    public partial class PiranhaContactForm
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? ReasonReachingId { get; set; }
        public string MessageContent { get; set; }
        public DateTime? Time { get; set; }

        public virtual PiranhaCfreasonReaching ReasonReaching { get; set; }
    }
}
