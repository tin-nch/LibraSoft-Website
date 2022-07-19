using System;
using System.Collections.Generic;

namespace LibraSoftCMS.Models
{
    public partial class PiranhaEventParticipant
    {
        public PiranhaEventParticipant()
        {
            IdEvents = new HashSet<PiranhaEvent>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }

        public virtual ICollection<PiranhaEvent> IdEvents { get; set; }
    }
}
